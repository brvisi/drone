using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;

namespace IMU_sensor_headtracker
{

    public partial class Form1 : Form
    {

        public graph chart_1 = new graph();
        public graphic_model graphics = new graphic_model();

        System.Timers.Timer _timer = new System.Timers.Timer(10000);

        public float yaw_offset=0; //alinhar YAW

        Stopwatch sw_math = new Stopwatch();
        Stopwatch sw_interface = new Stopwatch();
        long sw_math_sample = 0;
        long sw_math_total_time = 0;
        long sw_interface_sample = 0;
        long sw_interface_total_time = 0;

        static class Constants
        {
            public const int data_interval = 20; //ms

        }

        // Calculate the scaled gyro readings in radians per second
        

        public Form1()
        {
            InitializeComponent();

            bw_worker.ProgressChanged += bw_worker_ProgressChanged;
            bw_serial_data.ProgressChanged += bw_serial_data_ProgressChanged;

            acc_x_max.Text = Properties.Settings.Default.acc_x_max.ToString();
            acc_x_min.Text = Properties.Settings.Default.acc_x_min.ToString();
            acc_y_max.Text = Properties.Settings.Default.acc_y_max.ToString();
            acc_y_min.Text = Properties.Settings.Default.acc_y_min.ToString();
            acc_z_max.Text = Properties.Settings.Default.acc_z_max.ToString();
            acc_z_min.Text = Properties.Settings.Default.acc_z_min.ToString();
            gyro_x_offset.Text = Properties.Settings.Default.gyro_x_offset.ToString();
            gyro_y_offset.Text = Properties.Settings.Default.gyro_y_offset.ToString();
            gyro_z_offset.Text = Properties.Settings.Default.gyro_z_offset.ToString();
            mag_x_max.Text = Properties.Settings.Default.mag_x_max.ToString();
            mag_x_min.Text = Properties.Settings.Default.mag_x_min.ToString();
            mag_y_max.Text = Properties.Settings.Default.mag_y_max.ToString();
            mag_y_min.Text = Properties.Settings.Default.mag_y_min.ToString();
            mag_z_max.Text = Properties.Settings.Default.mag_z_max.ToString();
            mag_z_min.Text = Properties.Settings.Default.mag_z_min.ToString();

        }


        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void stop_Click(object sender, EventArgs e)
        {
            bw_worker.CancelAsync();
        }

        private void start_Click(object sender, EventArgs e)
        {

            if (!bw_worker.IsBusy)
            { 
                bw_worker.RunWorkerAsync();
                this.system_message.Text = "Background worker started";
  
               
            }
            else
            {
                this.system_message.Text = "Background worker already running";
            }
        }


        private void bw_worker_DoWork(object sender, DoWorkEventArgs e)
        {

            ///
            /// medir performance
            ///
            sw_math_sample = 0;
            sw_math_total_time = 0;
            sw_interface_sample = 0;
            sw_interface_total_time = 0;

            ///
            ///inicializar servidor UDP para capturar dados dos sensores
            ///
            int listenPort = int.Parse(listenport.Text);
            Udp_server_client udp_server = new Udp_server_client();
            udp_server.open_conn(listenPort);


            ///
            ///inicializa client UDP envio de dados por UDP
            ///
            Udp_server_client udp_client = new Udp_server_client();
            int sendPort = int.Parse(clientport.Text);
            string sendIP = clientip.Text;
            udp_client.client_conn(sendIP, sendPort);
       

            string[] received_raw_data;
            /*formato do vetor string raw data
             [(TIMESTAMP)],   0.123,0.586,0.2637,  0.259,-0.5963,9.815,  5.36,0.00,0.00#]
                                Sensor1                Sensor2            Sensor3(eol)
           */
 
            float[] acc = new float[3]; //accelerometer
            float[] mag = new float[3]; //magnetometer
            float[] gyr = new float[3]; //gyroscope
          
            float[] acc_calibrado = { 0, 0, 0 }; //accelerometer calibrado
            float[] mag_calibrado = { 0, 0, 0 }; //magnetometer calibrado
            float[] gyro_calibrado = { 0, 0, 0 }; //gyro calibrado
            float[] gyro_scaled = { 0, 0, 0 }; //gyroscope com ganho

            ulong timestamp = 0;
            ulong timestamp_old;

            float yaw, pitch, roll; //Euler angles
            float yaw_cal = 0, pitch_cal = 0, roll_cal = 0; //Angulos de Euler calibrados
            float yaw_dcm=0, pitch_dcm=0, roll_dcm=0; //Angulos de Euler DCM

            float[] temp1 = new float[3];
            float[] temp2 = new float[3];
            float[] xAxis = { 1.0f, 0.0f, 0.0f };

            float G_Dt; // Integration time for DCM algorithm
            float mag_heading; // ponta da agulha
            float mag_heading_cal; //calibrada
            float mag_heading_comp_filter; //filtro complementar

            float[][] DCM_Rotation_Matrix = new float[3][];
            ///
            ///primeira leitura
            ///
            received_raw_data = udp_server.receive_data();
            timestamp = Sensors.read_timestamp(received_raw_data);
            Sensors.read_sensors(received_raw_data, ref acc, ref mag, ref gyr);
            ///
            ///aplicar calibração dos sensores (compensar offset/aplicar escalar)
            ///
            Sensors.sensor_calibration(acc, mag, gyr, ref acc_calibrado, ref mag_calibrado, ref gyro_calibrado);

            // get pitch, roll and yaw
            pitch = (float)-Math.Atan2(acc_calibrado[0], Math.Sqrt(acc_calibrado[1] * acc_calibrado[1] + acc_calibrado[2] * acc_calibrado[2]));
            // Compensate pitch of gravity vector 
            Matematica.Vector_Cross_Product(ref temp1, acc_calibrado, xAxis);
            Matematica.Vector_Cross_Product(ref temp2, xAxis, temp1);
            //roll = (float)Math.Atan2(temp2[1], temp2[2]);

            roll = (float)Math.Atan2(acc_calibrado[1], Math.Sqrt(acc_calibrado[0] * acc_calibrado[0] + acc_calibrado[2] * acc_calibrado[2]));

            yaw = Sensors.bussola(mag_calibrado, pitch, roll); //magnectic heading

            ///
            ///Inicializa o object Comp Filter
            ///
            Complementary_filter comp_filter = new Complementary_filter();

            //
            //Inicializa o objeto DCM e reseta a fusão de sensores
            //
            DCM dcm_algorithm = new DCM(); //Objeto DCM
            dcm_algorithm.init_rotation_matrix(yaw, pitch, roll); //inicializa matriz de rotação DCM - usando euler raw (yaw,roll,pitch atual) (snapshot)

            ///
            ///thread principal -> intervalo de dados(delta de integração do gyro - algoritmo DCM), reler sensores, aplicar filtro
            ///
            while (!bw_worker.CancellationPending)
            {
                try
                {
                    sw_math.Reset();
                    sw_math.Start(); //STOPWATCH para medir performance

                    //read new sensor vector data
                    received_raw_data = udp_server.receive_data();
                    
                    //thread timestamp delays (Delta de integração)
                    if ((Sensors.read_timestamp(received_raw_data) - timestamp) >= Constants.data_interval)
                    {
                        timestamp_old = timestamp;
                        //received_raw_data = udp_server.receive_data(); //performance tosca - corrigir!!!!
                        timestamp = Sensors.read_timestamp(received_raw_data);
                        if (timestamp > timestamp_old) { G_Dt = (timestamp - timestamp_old) / 1000.0f; }
                        else { G_Dt = 0; }
                        
                        ///
                        ///read sensor readings
                        ///
                        Sensors.read_sensors(received_raw_data, ref acc, ref mag, ref gyr);

                        ///
                        ///aplicar calibração dos sensores (compensar offset/aplicar escalar)
                        ///
                        Sensors.sensor_calibration(acc, mag, gyr, ref acc_calibrado, ref mag_calibrado, ref gyro_calibrado);

                        ///
                        ///saida sem filtros
                        ///
                        pitch = (float)-Math.Atan2(acc[0], Math.Sqrt(acc[1] * acc[1] + acc[2] * acc[2]));

                        Matematica.Vector_Cross_Product(ref temp1, acc, xAxis);
                        Matematica.Vector_Cross_Product(ref temp2, xAxis, temp1);
                        roll = (float)Math.Atan2(temp2[1], temp2[2]);

                        //roll = (float)Math.Atan2(acc_calibrado[1], Math.Sqrt(acc_calibrado[0] * acc_calibrado[0] + acc_calibrado[2] * acc_calibrado[2]));
                        mag_heading = Sensors.bussola(mag, pitch, roll);
                        yaw = mag_heading;

                        ///
                        ///ganho no gyroscopio ----> ESTUDAR MAIS!
                        ///
                        gyro_scaled[0] = Sensors.gyro_ganho_radians(gyr[0]); //gyro x roll
                        gyro_scaled[1] = Sensors.gyro_ganho_radians(gyr[1]); //gyro y pitch
                        gyro_scaled[2] = Sensors.gyro_ganho_radians(gyr[2]); //gyro z yaw

                        pitch_cal = (float)-Math.Atan2(acc_calibrado[0], Math.Sqrt(acc_calibrado[1] * acc_calibrado[1] + acc_calibrado[2] * acc_calibrado[2]));
                        Matematica.Vector_Cross_Product(ref temp1, acc_calibrado, xAxis);
                        Matematica.Vector_Cross_Product(ref temp2, xAxis, temp1);
                        roll_cal = (float)Math.Atan2(temp2[1], temp2[2]);

                        mag_heading_cal = Sensors.bussola(mag_calibrado, pitch_cal, roll_cal);
                        yaw_cal = mag_heading_cal;

                        ///
                        ///Complementary_filter
                        ///
                        
                        comp_filter.read_gyro(gyr, G_Dt);
                        comp_filter.calculate_angles_acc(acc);
                        comp_filter.complementary_filter();                  
                        //comp_filter.complementary_filter_yaw(acc, mag);
                        

                        ///
                        ///Algoritmo DCM (objeto/classe)
                        ///
                        dcm_algorithm.Matrix_update(acc_calibrado, gyro_calibrado, G_Dt, true);
                        dcm_algorithm.Normalize();
                        dcm_algorithm.Drift_correction(mag_heading_cal);

                        ///
                        ///outputs dcm (matriz e angulos de euler)
                        ///
                        dcm_algorithm.Retrieve_rotation_matrix(ref DCM_Rotation_Matrix);
                        dcm_algorithm.Euler_angles(ref pitch_dcm, ref roll_dcm, ref yaw_dcm); //transformação em angulos de euler                    

                        sw_math.Stop();
                        sw_math_sample++;
                        sw_math_total_time += sw_math.ElapsedMilliseconds;
                        sw_interface.Reset();
                        sw_interface.Start();

                        string udp_data="";
                        double[] udp_data_double = new double[6];
                        if (send_udp_packet.Checked)
                        {
                            udp_data_double[0] = 0;
                            udp_data_double[1] = 0;
                            udp_data_double[2] = 0;
                            udp_data_double[3] = Matematica.Deg(yaw_dcm);
                            udp_data_double[4] = Matematica.Deg(roll_dcm);
                            udp_data_double[5] = Matematica.Deg(pitch_dcm);

                            udp_data = "[0,0,0," + Matematica.Deg(yaw_dcm).ToString() + "," + Matematica.Deg(pitch_dcm).ToString() + "," + Matematica.Deg(roll_dcm).ToString() + "]";
                            udp_client.send_data(udp_data_double);

                        }

                        ///
                        ///alimentar estrutura de saida
                        ///
                        Sensors_structure data = new Sensors_structure();
                        data.timestamp = timestamp;
                        data.gyro_integration_time = G_Dt;
                        data.acc = acc; 
                        data.mag = mag;
                        data.gyro = gyr;          
                        data.acc_cali = acc_calibrado;
                        data.mag_cali = mag_calibrado;
                        data.gyro_cali = gyro_calibrado;
                        data.gyro_scale = gyro_scaled;
                        data.pitch = Matematica.Deg(pitch);
                        data.roll = Matematica.Deg(roll);
                        data.yaw = Matematica.Deg(yaw);
                        data.pitch_cal = Matematica.Deg(pitch_cal);
                        data.roll_cal = Matematica.Deg(roll_cal);
                        data.yaw_cal = Matematica.Deg(yaw_cal);
                        data.yaw_dcm = Matematica.Deg(yaw_dcm);
                        data.pitch_dcm = Matematica.Deg(pitch_dcm);
                        data.roll_dcm = Matematica.Deg(roll_dcm);
                        data.client_info = udp_server.endpoint_ip.ToString(); //tempo de integração do gyro (teste)
                        data.yaw_offset = yaw_offset;
                        data.dcm_rotation_matrix = DCM_Rotation_Matrix;
                        data.udp_packet_sent = udp_data;

                        data.comp_filter_angles = comp_filter.comp_filter_angles;

                        ///
                        ///callback progress (para atualizar interface)
                        ///
                        bw_worker.ReportProgress(0, data);
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.ToString());
                    bw_worker.CancelAsync();
                    udp_server.client.Close();
                }
            }

            udp_server.client.Close();
            e.Result = 0;
        }

        private void bw_worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Sensors_structure display_data = new Sensors_structure();
            display_data = e.UserState as Sensors_structure;
            
            this.acc_x.Text = display_data.acc[0].ToString();
            this.acc_y.Text = display_data.acc[1].ToString();
            this.acc_z.Text = display_data.acc[2].ToString();
            this.gyro_x.Text = display_data.gyro[0].ToString();
            this.gyro_y.Text = display_data.gyro[1].ToString();
            this.gyro_z.Text = display_data.gyro[2].ToString();
            this.mag_x.Text = display_data.mag[0].ToString();
            this.mag_y.Text = display_data.mag[1].ToString();
            this.mag_z.Text = display_data.mag[2].ToString();
            this.timestamp.Text =  display_data.gyro_integration_time.ToString();

            this.pitch_cali.Text = display_data.pitch_cal.ToString("F3");
            this.roll_cali.Text = display_data.roll_cal.ToString("F3");
            this.yaw_cali.Text = display_data.yaw_cal.ToString("F3");

            this.gyro_scaled_x.Text = display_data.gyro_scale[0].ToString();
            this.gyro_scaled_y.Text = display_data.gyro_scale[1].ToString();
            this.gyro_scaled_z.Text = display_data.gyro_scale[2].ToString();

            this.yaw_dcm.Text = display_data.yaw_dcm.ToString("F3");
            this.pitch_dcm.Text = display_data.pitch_dcm.ToString("F3");
            this.roll_dcm.Text = display_data.roll_dcm.ToString("F3");

            this.yaw.Text = display_data.yaw.ToString("F3");
            this.pitch.Text = display_data.pitch.ToString("F3");
            this.roll.Text = display_data.roll.ToString("F3");

            this.acc_cali_x.Text = display_data.acc_cali[0].ToString();
            this.acc_cali_y.Text = display_data.acc_cali[1].ToString();
            this.acc_cali_z.Text = display_data.acc_cali[2].ToString();
            this.mag_cali_x.Text = display_data.mag_cali[0].ToString();
            this.mag_cali_y.Text = display_data.mag_cali[1].ToString();
            this.mag_cali_z.Text = display_data.mag_cali[2].ToString();
            this.gyro_calibrated_x.Text = display_data.gyro_cali[0].ToString();
            this.gyro_calibrated_y.Text = display_data.gyro_cali[1].ToString();
            this.gyro_calibrated_z.Text = display_data.gyro_cali[2].ToString();
            this.sender_info.Text = display_data.client_info;
            this.dcm_matriz_0.Text = display_data.dcm_rotation_matrix[0][0].ToString("F3") + "   " + display_data.dcm_rotation_matrix[0][1].ToString("F3") + "   " + display_data.dcm_rotation_matrix[0][2].ToString("F3");
            this.dcm_matriz_1.Text = display_data.dcm_rotation_matrix[1][0].ToString("F3") + "   " + display_data.dcm_rotation_matrix[1][1].ToString("F3") + "   " + display_data.dcm_rotation_matrix[1][2].ToString("F3");
            this.dcm_matriz_2.Text = display_data.dcm_rotation_matrix[2][0].ToString("F3") + "   " + display_data.dcm_rotation_matrix[2][1].ToString("F3") + "   " + display_data.dcm_rotation_matrix[2][2].ToString("F3");

            this.udp_packet_sent.Text = display_data.udp_packet_sent;

            this.compfilter_x.Text = display_data.comp_filter_angles[0].ToString("F3");
            this.compfilter_y.Text = display_data.comp_filter_angles[1].ToString("F3");
            this.compfilter_z.Text = display_data.comp_filter_angles[2].ToString("F3");


            ///
            ///objeto 3D & grafico tempo real
            ///

            if (this.preview_method.Text == "Matriz Cosenos")
            {
                graphics.userControl11.Rotate(display_data.roll_dcm, display_data.pitch_dcm, display_data.yaw_dcm - display_data.yaw_offset); //display_data.dcm_rotation_matrix);

                chart_1.euler_angles[0] = display_data.yaw_dcm;
                chart_1.euler_angles[1] = display_data.pitch_dcm;
                chart_1.euler_angles[2] = display_data.roll_dcm;
              


            }
            else
            {
                chart_1.euler_angles[0] = display_data.comp_filter_angles[2];
                chart_1.euler_angles[1] = display_data.comp_filter_angles[1];
                chart_1.euler_angles[2] = display_data.comp_filter_angles[0];

                graphics.userControl11.Rotate(display_data.comp_filter_angles[0], display_data.comp_filter_angles[1], display_data.comp_filter_angles[2] - display_data.yaw_offset); //display_data.dcm_rotation_matrix);

            }

            
            ///
            ///to file
            ///

            //File.AppendAllText(Environment.CurrentDirectory + @"\acc_raw.txt", display_data.acc[0].ToString() + " " + display_data.acc[1].ToString() + " " + display_data.acc[2].ToString() + Environment.NewLine);
            //File.AppendAllText(Environment.CurrentDirectory + @"\mag_raw.txt", display_data.mag[0].ToString() + " " + display_data.mag[1].ToString() + " " + display_data.mag[2].ToString() + Environment.NewLine);
            //File.AppendAllText(Environment.CurrentDirectory + @"\gyro_raw.txt", display_data.gyro[0].ToString() + " " + display_data.gyro[1].ToString() + " " + display_data.gyro[2].ToString() + Environment.NewLine);

            sw_interface.Stop();
            sw_interface_total_time += sw_interface.ElapsedMilliseconds;
            sw_interface_sample++;
            math_loop_time.Text = (sw_math_total_time / sw_math_sample).ToString();
            interface_loop_time.Text = (sw_interface_total_time / sw_interface_sample).ToString();

        }

        private void bw_worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.system_message.Text = "Background worker stopped";
        }

        private void chart_Click(object sender, EventArgs e)
        {
            if (chart_1.Visible)
            {
                chart_1.Hide();
            }
            else
            {
                chart_1.Show();
            }
        }

        private void preview_Click(object sender, EventArgs e)
        {
            if (graphics.Visible)
            {
                graphics.Hide();
            }
            else
            {
                graphics.Show();
            }

        }

        private void yawoffset_Click(object sender, EventArgs e)
        {
            yaw_offset_text.Text = yaw_dcm.Text;
            yaw_offset = float.Parse(yaw_dcm.Text);
        }

        private void calibrar_Click(object sender, EventArgs e)
        {

            
            ///
            ///bw_calibrar background worker thread
            ///
            bw_calibrar.DoWork += new DoWorkEventHandler(bw_calibrar_DoWork);
            bw_calibrar.ProgressChanged += new ProgressChangedEventHandler(bw_calibrar_ProgressChanged);
            bw_calibrar.RunWorkerCompleted += bw_calibrar_RunWorkerCompleted;
            bw_calibrar.WorkerReportsProgress = false;
            bw_calibrar.WorkerSupportsCancellation = true;

            ///
            ///setup dos arquivos de saida 
            ///
           
            //File.Delete(Environment.CurrentDirectory + @"\offsets.txt"); ////->>>>>>>> não usado

            ///
            ///calibration step
            ///

            _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);

            string sstep = calib_option.Text;
            int _step=0;

            if (sstep == "Accel X MAX")
            { 
                _step = 0;
                Properties.Settings.Default.acc_x_max = 0;
            }
            else if(sstep == "Accel X MIN")
            {
                _step = 1;
                Properties.Settings.Default.acc_x_min = 0;
            }
            else if (sstep == "Accel Y MAX")
            {
                _step = 2;
                Properties.Settings.Default.acc_y_max = 0;
            }
            else if (sstep == "Accel Y MIN")
            {
                _step = 3;
                Properties.Settings.Default.acc_y_min = 0;
            }
            else if (sstep == "Accel Z MAX")
            {
                _step = 4;
                Properties.Settings.Default.acc_z_max = 0;
            }
            else if (sstep == "Accel Z MIN")
            {
                _step = 5;
                Properties.Settings.Default.acc_z_min = 0;
            }
            else if (sstep == "Gyro")
            {
                _step = 6;
                Properties.Settings.Default.gyro_x_offset = 0;
                Properties.Settings.Default.gyro_y_offset = 0;
                Properties.Settings.Default.gyro_z_offset = 0;
            }
            else if (sstep == "Mag X MAX")
            {
                _step = 7;
                Properties.Settings.Default.mag_x_max = 0;
            }
            else if (sstep == "Mag X MIN")
            {
                _step = 8;
                Properties.Settings.Default.mag_x_min = 0;
            }
            else if (sstep == "Mag Y MAX")
            {
                _step = 9;
                Properties.Settings.Default.mag_y_max = 0;
            }
            else if (sstep == "Mag Y MIN")
            {
                _step = 10;
                Properties.Settings.Default.mag_y_min = 0;
            }
            else if (sstep == "Mag Z MAX")
            {
                _step = 11;
                Properties.Settings.Default.mag_z_max = 0;
            }
            else if (sstep == "Mag Z MIN")
            {
                _step = 12;
                Properties.Settings.Default.mag_z_min = 0;
            }


            if (!bw_calibrar.IsBusy)
            {
                bw_calibrar.RunWorkerAsync(_step);
                _timer.Enabled = true; // Enable it     
                system_message.Text = "Calibration worker started";
                system_message.ForeColor = Color.FromArgb(255, 0, 0);

            }
            else
            {
                system_message.Text = "Calibration worker already running";
            }
            

        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs args)
        {
            _timer.Enabled = false;
            bw_calibrar.CancelAsync();
            
        }



        private void bw_calibrar_DoWork(object sender, DoWorkEventArgs e)
        {

            float[] acc_raw = new float[3]; //accelerometer raw
            float[] mag_raw = new float[3]; //magnetometer raw
            float[] gyr_raw = new float[3]; //gyroscope raw
            string[] received_raw_data_cal;

            float[] acc_max_cal = { 0, 0, 0 }; //valores maximos do acc (X,Y,Z);
            float[] acc_min_cal = { 0, 0, 0 }; //valores minimos do acc (-X,-Y,-Z);
            float[] gyro_offset_cal = { 0, 0, 0 }; //offset gyroscope
            float[] mag_max_cal = { 0, 0, 0 };
            float[] mag_min_cal = { 0, 0, 0 };

            double n_amostras=0;

            //System.Timers.Timer _timer_show_onscreen = new System.Timers.Timer(1000);
            //_timer_show_onscreen.Elapsed += _timer_show_onscreen_Elapsed;


            int cal_step = (int)e.Argument;

            int listenPort = int.Parse(listenport.Text);
            Udp_server_client udp_server_cal = new Udp_server_client();
            udp_server_cal.open_conn(listenPort);

            Sensors_calibration calibration_data = new Sensors_calibration();
            calibration_data.acc_max = acc_max_cal;
            calibration_data.acc_min = acc_min_cal;
            calibration_data.gyro_offset = gyro_offset_cal;
            calibration_data.mag_max = mag_max_cal;
            calibration_data.mag_min = mag_min_cal;

            calibration_data.acc_max[0] = Properties.Settings.Default.acc_x_max;
            calibration_data.acc_min[0] = Properties.Settings.Default.acc_x_min;
            calibration_data.acc_max[1] = Properties.Settings.Default.acc_y_max;
            calibration_data.acc_min[1] = Properties.Settings.Default.acc_y_min;
            calibration_data.acc_max[2] = Properties.Settings.Default.acc_z_max;
            calibration_data.acc_min[2] = Properties.Settings.Default.acc_z_min;
            calibration_data.gyro_offset[0] = Properties.Settings.Default.gyro_x_offset;
            calibration_data.gyro_offset[1] = Properties.Settings.Default.gyro_y_offset;
            calibration_data.gyro_offset[2] = Properties.Settings.Default.gyro_z_offset;
            calibration_data.mag_max[0] = Properties.Settings.Default.mag_x_max;
            calibration_data.mag_min[0] = Properties.Settings.Default.mag_x_min;
            calibration_data.mag_max[1] = Properties.Settings.Default.mag_y_max;
            calibration_data.mag_min[1] = Properties.Settings.Default.mag_y_min;
            calibration_data.mag_max[2] = Properties.Settings.Default.mag_z_max;
            calibration_data.mag_min[2] = Properties.Settings.Default.mag_z_min;
            ///
            ///thread de leitura
            ///
            while (!bw_calibrar.CancellationPending)
            {
                received_raw_data_cal = udp_server_cal.receive_data();
                Sensors.read_sensors(received_raw_data_cal, ref acc_raw, ref mag_raw, ref gyr_raw);
                

                //Thread.Sleep(20);

                if (cal_step == 0)
                {
                    if(acc_raw[0]> calibration_data.acc_max[0])
                    {        
                        calibration_data.acc_max[0] = acc_raw[0];  //accx max                     
                    }
                }
                if (cal_step == 1)
                {
                    if (acc_raw[0] < calibration_data.acc_min[0]) //accx min
                    {
                        calibration_data.acc_min[0] = acc_raw[0]; 
                    }
                }
                if (cal_step == 2)
                {
                    if (acc_raw[1] > calibration_data.acc_max[1]) //accy max
                    {
                        calibration_data.acc_max[1] = acc_raw[1];
                    }
                }
                if (cal_step == 3)
                {
                    if (acc_raw[1] < calibration_data.acc_min[1]) //accy min
                    {
                        calibration_data.acc_min[1] = acc_raw[1];

                    }
                }
                if (cal_step == 4)
                {
                    if (acc_raw[2] > calibration_data.acc_max[2]) //accz max
                    {
                        calibration_data.acc_max[2] = acc_raw[2];

                    }
                }
                if (cal_step == 5)
                {
                    if (acc_raw[2] < calibration_data.acc_min[2]) //accz min
                    {
                        calibration_data.acc_min[2] = acc_raw[2];
                    }
                }
                if (cal_step == 6)
                {
                    n_amostras++;

                    calibration_data.gyro_offset[0] = (calibration_data.gyro_offset[0] + gyr_raw[0]) / (float)n_amostras; //offset x - average
                    calibration_data.gyro_offset[1] = (calibration_data.gyro_offset[1] + gyr_raw[1]) / (float)n_amostras; //offset y - average
                    calibration_data.gyro_offset[2] = (calibration_data.gyro_offset[2] + gyr_raw[2]) / (float)n_amostras; //offset z - average
                }
                if (cal_step == 7)
                {
                    if (mag_raw[0] > calibration_data.mag_max[0])
                    {
                        calibration_data.mag_max[0] = mag_raw[0];  //magx max                     
                    }
                }
                if (cal_step == 8)
                {
                    if (mag_raw[0] < calibration_data.mag_min[0]) //magx min
                    {
                        calibration_data.mag_min[0] = mag_raw[0];
                    }
                }
                if (cal_step == 9)
                {
                    if (mag_raw[1] > calibration_data.mag_max[1]) //magy max
                    {
                        calibration_data.mag_max[1] = mag_raw[1];
                    }
                }
                if (cal_step == 10)
                {
                    if (mag_raw[1] < calibration_data.mag_min[1]) //magy min
                    {
                        calibration_data.mag_min[1] = mag_raw[1];

                    }
                }
                if (cal_step == 11)
                {
                    if (mag_raw[2] > calibration_data.mag_max[2]) //magz max
                    {
                        calibration_data.mag_max[2] = mag_raw[2];

                    }
                }
                if (cal_step == 12)
                {
                    if (mag_raw[2] < calibration_data.mag_min[2]) //magz min
                    {
                        calibration_data.mag_min[2] = mag_raw[2];
                    }
                }
            }

            udp_server_cal.client.Close();
            e.Result = calibration_data;
           
        }

        private void _timer_show_onscreen_Elapsed(object sender, ElapsedEventArgs args)
        {

        }


        private void bw_calibrar_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //NADA
        }
        private void bw_calibrar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Sensors_calibration data = new Sensors_calibration();
            data = e.Result as Sensors_calibration;

            Properties.Settings.Default.acc_x_max = data.acc_max[0];
            Properties.Settings.Default.acc_x_min = data.acc_min[0];
            Properties.Settings.Default.acc_y_max = data.acc_max[1];
            Properties.Settings.Default.acc_y_min = data.acc_min[1];
            Properties.Settings.Default.acc_z_max = data.acc_max[2];
            Properties.Settings.Default.acc_z_min = data.acc_min[2];
            Properties.Settings.Default.gyro_x_offset = data.gyro_offset[0];
            Properties.Settings.Default.gyro_y_offset = data.gyro_offset[1];
            Properties.Settings.Default.gyro_z_offset = data.gyro_offset[2];
            Properties.Settings.Default.mag_x_max = data.mag_max[0];
            Properties.Settings.Default.mag_x_min = data.mag_min[0];
            Properties.Settings.Default.mag_y_max = data.mag_max[1];
            Properties.Settings.Default.mag_y_min = data.mag_min[1];
            Properties.Settings.Default.mag_z_max = data.mag_max[2];
            Properties.Settings.Default.mag_z_min = data.mag_min[2];

            Properties.Settings.Default.Save();

            acc_x_max.Text = Properties.Settings.Default.acc_x_max.ToString();
            acc_x_min.Text = Properties.Settings.Default.acc_x_min.ToString();
            acc_y_max.Text = Properties.Settings.Default.acc_y_max.ToString();
            acc_y_min.Text = Properties.Settings.Default.acc_y_min.ToString();
            acc_z_max.Text = Properties.Settings.Default.acc_z_max.ToString();
            acc_z_min.Text = Properties.Settings.Default.acc_z_min.ToString();
            gyro_x_offset.Text = Properties.Settings.Default.gyro_x_offset.ToString();
            gyro_y_offset.Text = Properties.Settings.Default.gyro_y_offset.ToString();
            gyro_z_offset.Text = Properties.Settings.Default.gyro_z_offset.ToString();
            mag_x_max.Text = Properties.Settings.Default.mag_x_max.ToString();
            mag_x_min.Text = Properties.Settings.Default.mag_x_min.ToString();
            mag_y_max.Text = Properties.Settings.Default.mag_y_max.ToString();
            mag_y_min.Text = Properties.Settings.Default.mag_y_min.ToString();
            mag_z_max.Text = Properties.Settings.Default.mag_z_max.ToString();
            mag_z_min.Text = Properties.Settings.Default.mag_z_min.ToString();

            system_message.Text = "Calibration worker finished";
            system_message.ForeColor = Color.FromArgb(0, 0, 0);

          

        }

        private void clear_calibration_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.acc_x_max = 9.8f;
            Properties.Settings.Default.acc_x_min = -9.8f;
            Properties.Settings.Default.acc_y_max = 9.8f;
            Properties.Settings.Default.acc_y_min = -9.8f;
            Properties.Settings.Default.acc_z_max = 9.8f;
            Properties.Settings.Default.acc_z_min = -9.8f;
            Properties.Settings.Default.gyro_x_offset = 0;
            Properties.Settings.Default.gyro_y_offset = 0;
            Properties.Settings.Default.gyro_z_offset = 0;
            Properties.Settings.Default.mag_x_max = 30f;
            Properties.Settings.Default.mag_x_min = -30f;
            Properties.Settings.Default.mag_y_max = 30f;
            Properties.Settings.Default.mag_y_min = -30f;
            Properties.Settings.Default.mag_z_max = 30f;
            Properties.Settings.Default.mag_z_min = -30f;



            Properties.Settings.Default.Save();

            acc_x_max.Text = Properties.Settings.Default.acc_x_max.ToString();
            acc_x_min.Text = Properties.Settings.Default.acc_x_min.ToString();
            acc_y_max.Text = Properties.Settings.Default.acc_y_max.ToString();
            acc_y_min.Text = Properties.Settings.Default.acc_y_min.ToString();
            acc_z_max.Text = Properties.Settings.Default.acc_z_max.ToString();
            acc_z_min.Text = Properties.Settings.Default.acc_z_min.ToString();
            gyro_x_offset.Text = Properties.Settings.Default.gyro_x_offset.ToString();
            gyro_y_offset.Text = Properties.Settings.Default.gyro_y_offset.ToString();
            gyro_z_offset.Text = Properties.Settings.Default.gyro_z_offset.ToString();
            mag_x_max.Text = Properties.Settings.Default.mag_x_max.ToString();
            mag_x_min.Text = Properties.Settings.Default.mag_x_min.ToString();
            mag_y_max.Text = Properties.Settings.Default.mag_y_max.ToString();
            mag_y_min.Text = Properties.Settings.Default.mag_y_min.ToString();
            mag_z_max.Text = Properties.Settings.Default.mag_z_max.ToString();
            mag_z_min.Text = Properties.Settings.Default.mag_z_min.ToString();

        }

        private void start_serial_Click(object sender, EventArgs e)
        {
            if (!bw_serial_data.IsBusy)
            {
                bw_serial_data.RunWorkerAsync();
                this.system_message.Text = "Background worker SERIAL started";


            }
            else
            {
                this.system_message.Text = "Background worker SERIAL already running";
            }

        }

        private void stop_serial_Click(object sender, EventArgs e)
        {
            bw_serial_data.CancelAsync();
        }

        private void bw_serial_data_DoWork(object sender, DoWorkEventArgs e)
        {

            string[] received_serial_data;
            float yaw, pitch, roll;


            SerialData Data = new SerialData();
            Data.OpenConn(this.COM_port.Text, 115200);

            while (!bw_serial_data.CancellationPending)
            {
                try
                {
                    received_serial_data = Data.receive_serial_data();

                    pitch = float.Parse(received_serial_data[0], CultureInfo.InvariantCulture.NumberFormat);
                    roll = float.Parse(received_serial_data[1], CultureInfo.InvariantCulture.NumberFormat);
                    yaw = float.Parse(received_serial_data[2], CultureInfo.InvariantCulture.NumberFormat);

                    Sensors_structure serial_data = new Sensors_structure();
                    serial_data.pitch = pitch;
                    serial_data.roll = roll;
                    serial_data.yaw = yaw;

                    bw_serial_data.ReportProgress(0, serial_data);
                    
                }
                catch (Exception error)
                {
                    //MessageBox.Show(error.ToString());
                    //bw_serial_data.CancelAsync();
                    //Data.port.Close();
                }
            }

            Data.port.Close();
            e.Result = 0;            
        }

        private void bw_serial_data_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            Sensors_structure serial_display_data = new Sensors_structure();
            serial_display_data = e.UserState as Sensors_structure;

            COM_data.Text = serial_display_data.pitch.ToString() + ',' + serial_display_data.roll.ToString() + ',' + serial_display_data.yaw.ToString();

            graphics.userControl11.Rotate(serial_display_data.roll, serial_display_data.pitch, serial_display_data.yaw);

            chart_1.euler_angles[0] = serial_display_data.yaw;
            chart_1.euler_angles[1] = serial_display_data.pitch;
            chart_1.euler_angles[2] = serial_display_data.roll;



        }

        private void bw_serial_data_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.system_message.Text = "Background worker SERIAL stopped";
        }

    }
}
