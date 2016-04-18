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

            bw_serial_data.ProgressChanged += bw_serial_data_ProgressChanged;

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
           // yaw_offset_text.Text = yaw_dcm.Text;
            yaw_offset = float.Parse(yaw_dcm.Text);
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
