namespace IMU_sensor_headtracker
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.start = new System.Windows.Forms.Button();
            this.listenport = new System.Windows.Forms.TextBox();
            this.stop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bw_worker = new System.ComponentModel.BackgroundWorker();
            this.system_message = new System.Windows.Forms.TextBox();
            this.acc_x = new System.Windows.Forms.Label();
            this.acc_y = new System.Windows.Forms.Label();
            this.acc_z = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.mag_x = new System.Windows.Forms.Label();
            this.mag_y = new System.Windows.Forms.Label();
            this.mag_z = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.gyro_x = new System.Windows.Forms.Label();
            this.gyro_y = new System.Windows.Forms.Label();
            this.gyro_z = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.yaw_cali = new System.Windows.Forms.Label();
            this.pitch_cali = new System.Windows.Forms.Label();
            this.roll_cali = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.sender_info = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.acc_cali_x = new System.Windows.Forms.Label();
            this.acc_cali_y = new System.Windows.Forms.Label();
            this.acc_cali_z = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.mag_cali_x = new System.Windows.Forms.Label();
            this.mag_cali_y = new System.Windows.Forms.Label();
            this.mag_cali_z = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.timestamp = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.pitch_dcm = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.yaw_dcm = new System.Windows.Forms.Label();
            this.roll_dcm = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.pitch = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.yaw = new System.Windows.Forms.Label();
            this.roll = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.plot1 = new OxyPlot.WindowsForms.PlotView();
            this.togglechart = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.gyro_scaled_x = new System.Windows.Forms.Label();
            this.gyro_scaled_y = new System.Windows.Forms.Label();
            this.gyro_scaled_z = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.preview = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.yaw_offset_text = new System.Windows.Forms.Label();
            this.yawoffset = new System.Windows.Forms.Button();
            this.calibrar = new System.Windows.Forms.Button();
            this.math_loop_time = new System.Windows.Forms.Label();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gyro_z_offset = new System.Windows.Forms.Label();
            this.gyro_y_offset = new System.Windows.Forms.Label();
            this.mag_z_min = new System.Windows.Forms.Label();
            this.gyro_x_offset = new System.Windows.Forms.Label();
            this.mag_z_max = new System.Windows.Forms.Label();
            this.acc_z_min = new System.Windows.Forms.Label();
            this.mag_y_min = new System.Windows.Forms.Label();
            this.acc_z_max = new System.Windows.Forms.Label();
            this.mag_y_max = new System.Windows.Forms.Label();
            this.acc_y_min = new System.Windows.Forms.Label();
            this.mag_x_min = new System.Windows.Forms.Label();
            this.acc_y_max = new System.Windows.Forms.Label();
            this.mag_x_max = new System.Windows.Forms.Label();
            this.acc_x_min = new System.Windows.Forms.Label();
            this.acc_x_max = new System.Windows.Forms.Label();
            this.clear_calibration = new System.Windows.Forms.Button();
            this.bw_calibrar = new System.ComponentModel.BackgroundWorker();
            this.calib_option = new System.Windows.Forms.ComboBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.gyro_calibrated_x = new System.Windows.Forms.Label();
            this.gyro_calibrated_y = new System.Windows.Forms.Label();
            this.gyro_calibrated_z = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.dcm_matriz_1 = new System.Windows.Forms.Label();
            this.dcm_matriz_0 = new System.Windows.Forms.Label();
            this.dcm_matriz_2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.interface_loop_time = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.clientport = new System.Windows.Forms.TextBox();
            this.send_udp_packet = new System.Windows.Forms.CheckBox();
            this.udp_packet_sent = new System.Windows.Forms.Label();
            this.clientip = new System.Windows.Forms.TextBox();
            this.preview_method = new System.Windows.Forms.ComboBox();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.compfilter_x = new System.Windows.Forms.Label();
            this.compfilter_y = new System.Windows.Forms.Label();
            this.compfilter_z = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.COM_port = new System.Windows.Forms.TextBox();
            this.start_serial = new System.Windows.Forms.Button();
            this.stop_serial = new System.Windows.Forms.Button();
            this.bw_serial_data = new System.ComponentModel.BackgroundWorker();
            this.COM_data = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(155, 4);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(61, 23);
            this.start.TabIndex = 0;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // listenport
            // 
            this.listenport.Location = new System.Drawing.Point(101, 6);
            this.listenport.Name = "listenport";
            this.listenport.Size = new System.Drawing.Size(48, 20);
            this.listenport.TabIndex = 1;
            this.listenport.Text = "5554";
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(222, 4);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(56, 23);
            this.stop.TabIndex = 2;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "UDP Listen Port";
            // 
            // bw_worker
            // 
            this.bw_worker.WorkerReportsProgress = true;
            this.bw_worker.WorkerSupportsCancellation = true;
            this.bw_worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_worker_DoWork);
            this.bw_worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_worker_RunWorkerCompleted);
            // 
            // system_message
            // 
            this.system_message.BackColor = System.Drawing.SystemColors.Menu;
            this.system_message.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.system_message.Location = new System.Drawing.Point(7, 19);
            this.system_message.Name = "system_message";
            this.system_message.Size = new System.Drawing.Size(324, 13);
            this.system_message.TabIndex = 4;
            this.system_message.Text = "system_message";
            // 
            // acc_x
            // 
            this.acc_x.AutoSize = true;
            this.acc_x.Location = new System.Drawing.Point(26, 17);
            this.acc_x.Name = "acc_x";
            this.acc_x.Size = new System.Drawing.Size(13, 13);
            this.acc_x.TabIndex = 6;
            this.acc_x.Text = "0";
            // 
            // acc_y
            // 
            this.acc_y.AutoSize = true;
            this.acc_y.Location = new System.Drawing.Point(26, 30);
            this.acc_y.Name = "acc_y";
            this.acc_y.Size = new System.Drawing.Size(13, 13);
            this.acc_y.TabIndex = 8;
            this.acc_y.Text = "0";
            // 
            // acc_z
            // 
            this.acc_z.AutoSize = true;
            this.acc_z.Location = new System.Drawing.Point(26, 43);
            this.acc_z.Name = "acc_z";
            this.acc_z.Size = new System.Drawing.Size(13, 13);
            this.acc_z.TabIndex = 10;
            this.acc_z.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "X";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Y";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Z";
            // 
            // mag_x
            // 
            this.mag_x.AutoSize = true;
            this.mag_x.Location = new System.Drawing.Point(33, 17);
            this.mag_x.Name = "mag_x";
            this.mag_x.Size = new System.Drawing.Size(13, 13);
            this.mag_x.TabIndex = 6;
            this.mag_x.Text = "0";
            // 
            // mag_y
            // 
            this.mag_y.AutoSize = true;
            this.mag_y.Location = new System.Drawing.Point(33, 30);
            this.mag_y.Name = "mag_y";
            this.mag_y.Size = new System.Drawing.Size(13, 13);
            this.mag_y.TabIndex = 8;
            this.mag_y.Text = "0";
            // 
            // mag_z
            // 
            this.mag_z.AutoSize = true;
            this.mag_z.Location = new System.Drawing.Point(33, 43);
            this.mag_z.Name = "mag_z";
            this.mag_z.Size = new System.Drawing.Size(13, 13);
            this.mag_z.TabIndex = 10;
            this.mag_z.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "X";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Y";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 43);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Z";
            // 
            // gyro_x
            // 
            this.gyro_x.AutoSize = true;
            this.gyro_x.Location = new System.Drawing.Point(36, 17);
            this.gyro_x.Name = "gyro_x";
            this.gyro_x.Size = new System.Drawing.Size(13, 13);
            this.gyro_x.TabIndex = 6;
            this.gyro_x.Text = "0";
            // 
            // gyro_y
            // 
            this.gyro_y.AutoSize = true;
            this.gyro_y.Location = new System.Drawing.Point(36, 30);
            this.gyro_y.Name = "gyro_y";
            this.gyro_y.Size = new System.Drawing.Size(13, 13);
            this.gyro_y.TabIndex = 8;
            this.gyro_y.Text = "0";
            // 
            // gyro_z
            // 
            this.gyro_z.AutoSize = true;
            this.gyro_z.Location = new System.Drawing.Point(36, 43);
            this.gyro_z.Name = "gyro_z";
            this.gyro_z.Size = new System.Drawing.Size(13, 13);
            this.gyro_z.TabIndex = 10;
            this.gyro_z.Text = "0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(19, 17);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(14, 13);
            this.label18.TabIndex = 11;
            this.label18.Text = "X";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(19, 30);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(14, 13);
            this.label19.TabIndex = 12;
            this.label19.Text = "Y";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(19, 43);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(14, 13);
            this.label20.TabIndex = 13;
            this.label20.Text = "Z";
            // 
            // yaw_cali
            // 
            this.yaw_cali.AutoSize = true;
            this.yaw_cali.Location = new System.Drawing.Point(45, 16);
            this.yaw_cali.Name = "yaw_cali";
            this.yaw_cali.Size = new System.Drawing.Size(13, 13);
            this.yaw_cali.TabIndex = 6;
            this.yaw_cali.Text = "0";
            // 
            // pitch_cali
            // 
            this.pitch_cali.AutoSize = true;
            this.pitch_cali.Location = new System.Drawing.Point(45, 29);
            this.pitch_cali.Name = "pitch_cali";
            this.pitch_cali.Size = new System.Drawing.Size(13, 13);
            this.pitch_cali.TabIndex = 8;
            this.pitch_cali.Text = "0";
            // 
            // roll_cali
            // 
            this.roll_cali.AutoSize = true;
            this.roll_cali.Location = new System.Drawing.Point(45, 42);
            this.roll_cali.Name = "roll_cali";
            this.roll_cali.Size = new System.Drawing.Size(13, 13);
            this.roll_cali.TabIndex = 10;
            this.roll_cali.Text = "0";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(11, 16);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(28, 13);
            this.label24.TabIndex = 11;
            this.label24.Text = "Yaw";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(11, 29);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(31, 13);
            this.label25.TabIndex = 12;
            this.label25.Text = "Pitch";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(11, 42);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(25, 13);
            this.label26.TabIndex = 13;
            this.label26.Text = "Roll";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.acc_x);
            this.groupBox1.Controls.Add(this.acc_y);
            this.groupBox1.Controls.Add(this.acc_z);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(15, 132);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(102, 63);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "accelerometer";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.mag_x);
            this.groupBox2.Controls.Add(this.mag_y);
            this.groupBox2.Controls.Add(this.mag_z);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(123, 132);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(100, 63);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "magnetometer";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.gyro_x);
            this.groupBox3.Controls.Add(this.gyro_y);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.gyro_z);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Location = new System.Drawing.Point(229, 132);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(124, 63);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "gyroscope";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pitch_cali);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.yaw_cali);
            this.groupBox4.Controls.Add(this.roll_cali);
            this.groupBox4.Controls.Add(this.label26);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox4.Location = new System.Drawing.Point(112, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(99, 63);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Calibrado";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.sender_info);
            this.groupBox5.Controls.Add(this.system_message);
            this.groupBox5.Location = new System.Drawing.Point(15, 431);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(340, 64);
            this.groupBox5.TabIndex = 19;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "mensagens";
            // 
            // sender_info
            // 
            this.sender_info.BackColor = System.Drawing.SystemColors.Menu;
            this.sender_info.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sender_info.Location = new System.Drawing.Point(7, 38);
            this.sender_info.Name = "sender_info";
            this.sender_info.Size = new System.Drawing.Size(324, 13);
            this.sender_info.TabIndex = 5;
            this.sender_info.Text = "conn_info";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.acc_cali_x);
            this.groupBox8.Controls.Add(this.acc_cali_y);
            this.groupBox8.Controls.Add(this.acc_cali_z);
            this.groupBox8.Controls.Add(this.label11);
            this.groupBox8.Controls.Add(this.label15);
            this.groupBox8.Controls.Add(this.label16);
            this.groupBox8.Location = new System.Drawing.Point(16, 201);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(102, 63);
            this.groupBox8.TabIndex = 15;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "accel calibrado";
            // 
            // acc_cali_x
            // 
            this.acc_cali_x.AutoSize = true;
            this.acc_cali_x.Location = new System.Drawing.Point(26, 17);
            this.acc_cali_x.Name = "acc_cali_x";
            this.acc_cali_x.Size = new System.Drawing.Size(13, 13);
            this.acc_cali_x.TabIndex = 6;
            this.acc_cali_x.Text = "0";
            // 
            // acc_cali_y
            // 
            this.acc_cali_y.AutoSize = true;
            this.acc_cali_y.Location = new System.Drawing.Point(26, 30);
            this.acc_cali_y.Name = "acc_cali_y";
            this.acc_cali_y.Size = new System.Drawing.Size(13, 13);
            this.acc_cali_y.TabIndex = 8;
            this.acc_cali_y.Text = "0";
            // 
            // acc_cali_z
            // 
            this.acc_cali_z.AutoSize = true;
            this.acc_cali_z.Location = new System.Drawing.Point(26, 43);
            this.acc_cali_z.Name = "acc_cali_z";
            this.acc_cali_z.Size = new System.Drawing.Size(13, 13);
            this.acc_cali_z.TabIndex = 10;
            this.acc_cali_z.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "X";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 43);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 13);
            this.label15.TabIndex = 13;
            this.label15.Text = "Z";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 30);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(14, 13);
            this.label16.TabIndex = 12;
            this.label16.Text = "Y";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.mag_cali_x);
            this.groupBox9.Controls.Add(this.mag_cali_y);
            this.groupBox9.Controls.Add(this.mag_cali_z);
            this.groupBox9.Controls.Add(this.label17);
            this.groupBox9.Controls.Add(this.label21);
            this.groupBox9.Controls.Add(this.label22);
            this.groupBox9.Location = new System.Drawing.Point(124, 201);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(99, 63);
            this.groupBox9.TabIndex = 15;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "mag calibrado";
            // 
            // mag_cali_x
            // 
            this.mag_cali_x.AutoSize = true;
            this.mag_cali_x.Location = new System.Drawing.Point(26, 17);
            this.mag_cali_x.Name = "mag_cali_x";
            this.mag_cali_x.Size = new System.Drawing.Size(13, 13);
            this.mag_cali_x.TabIndex = 6;
            this.mag_cali_x.Text = "0";
            // 
            // mag_cali_y
            // 
            this.mag_cali_y.AutoSize = true;
            this.mag_cali_y.Location = new System.Drawing.Point(26, 30);
            this.mag_cali_y.Name = "mag_cali_y";
            this.mag_cali_y.Size = new System.Drawing.Size(13, 13);
            this.mag_cali_y.TabIndex = 8;
            this.mag_cali_y.Text = "0";
            // 
            // mag_cali_z
            // 
            this.mag_cali_z.AutoSize = true;
            this.mag_cali_z.Location = new System.Drawing.Point(26, 43);
            this.mag_cali_z.Name = "mag_cali_z";
            this.mag_cali_z.Size = new System.Drawing.Size(13, 13);
            this.mag_cali_z.TabIndex = 10;
            this.mag_cali_z.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(11, 17);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(14, 13);
            this.label17.TabIndex = 11;
            this.label17.Text = "X";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(11, 43);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(14, 13);
            this.label21.TabIndex = 13;
            this.label21.Text = "Z";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(11, 30);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(14, 13);
            this.label22.TabIndex = 12;
            this.label22.Text = "Y";
            // 
            // timestamp
            // 
            this.timestamp.AutoSize = true;
            this.timestamp.Location = new System.Drawing.Point(401, 81);
            this.timestamp.Name = "timestamp";
            this.timestamp.Size = new System.Drawing.Size(13, 13);
            this.timestamp.TabIndex = 0;
            this.timestamp.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(383, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "it";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.pitch_dcm);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.label23);
            this.groupBox6.Controls.Add(this.yaw_dcm);
            this.groupBox6.Controls.Add(this.roll_dcm);
            this.groupBox6.Controls.Add(this.label29);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox6.Location = new System.Drawing.Point(15, 363);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(102, 63);
            this.groupBox6.TabIndex = 18;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "DCM (Euler)";
            // 
            // pitch_dcm
            // 
            this.pitch_dcm.AutoSize = true;
            this.pitch_dcm.Location = new System.Drawing.Point(45, 29);
            this.pitch_dcm.Name = "pitch_dcm";
            this.pitch_dcm.Size = new System.Drawing.Size(13, 13);
            this.pitch_dcm.TabIndex = 8;
            this.pitch_dcm.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Yaw";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(11, 29);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(31, 13);
            this.label23.TabIndex = 12;
            this.label23.Text = "Pitch";
            // 
            // yaw_dcm
            // 
            this.yaw_dcm.AutoSize = true;
            this.yaw_dcm.Location = new System.Drawing.Point(45, 16);
            this.yaw_dcm.Name = "yaw_dcm";
            this.yaw_dcm.Size = new System.Drawing.Size(13, 13);
            this.yaw_dcm.TabIndex = 6;
            this.yaw_dcm.Text = "0";
            // 
            // roll_dcm
            // 
            this.roll_dcm.AutoSize = true;
            this.roll_dcm.Location = new System.Drawing.Point(45, 42);
            this.roll_dcm.Name = "roll_dcm";
            this.roll_dcm.Size = new System.Drawing.Size(13, 13);
            this.roll_dcm.TabIndex = 10;
            this.roll_dcm.Text = "0";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(11, 42);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(25, 13);
            this.label29.TabIndex = 13;
            this.label29.Text = "Roll";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.pitch);
            this.groupBox10.Controls.Add(this.label27);
            this.groupBox10.Controls.Add(this.label28);
            this.groupBox10.Controls.Add(this.yaw);
            this.groupBox10.Controls.Add(this.roll);
            this.groupBox10.Controls.Add(this.label32);
            this.groupBox10.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox10.Location = new System.Drawing.Point(6, 19);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(100, 63);
            this.groupBox10.TabIndex = 18;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Raw";
            // 
            // pitch
            // 
            this.pitch.AutoSize = true;
            this.pitch.Location = new System.Drawing.Point(45, 29);
            this.pitch.Name = "pitch";
            this.pitch.Size = new System.Drawing.Size(13, 13);
            this.pitch.TabIndex = 8;
            this.pitch.Text = "0";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(11, 16);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(28, 13);
            this.label27.TabIndex = 11;
            this.label27.Text = "Yaw";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(11, 29);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(31, 13);
            this.label28.TabIndex = 12;
            this.label28.Text = "Pitch";
            // 
            // yaw
            // 
            this.yaw.AutoSize = true;
            this.yaw.Location = new System.Drawing.Point(45, 16);
            this.yaw.Name = "yaw";
            this.yaw.Size = new System.Drawing.Size(13, 13);
            this.yaw.TabIndex = 6;
            this.yaw.Text = "0";
            // 
            // roll
            // 
            this.roll.AutoSize = true;
            this.roll.Location = new System.Drawing.Point(45, 42);
            this.roll.Name = "roll";
            this.roll.Size = new System.Drawing.Size(13, 13);
            this.roll.TabIndex = 10;
            this.roll.Text = "0";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(11, 42);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(25, 13);
            this.label32.TabIndex = 13;
            this.label32.Text = "Roll";
            // 
            // plot1
            // 
            this.plot1.Location = new System.Drawing.Point(0, 0);
            this.plot1.Name = "plot1";
            this.plot1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plot1.Size = new System.Drawing.Size(0, 0);
            this.plot1.TabIndex = 0;
            this.plot1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plot1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plot1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // togglechart
            // 
            this.togglechart.Location = new System.Drawing.Point(411, 4);
            this.togglechart.Name = "togglechart";
            this.togglechart.Size = new System.Drawing.Size(67, 23);
            this.togglechart.TabIndex = 23;
            this.togglechart.Text = "Chart";
            this.togglechart.UseVisualStyleBackColor = true;
            this.togglechart.Click += new System.EventHandler(this.chart_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.gyro_scaled_x);
            this.groupBox7.Controls.Add(this.gyro_scaled_y);
            this.groupBox7.Controls.Add(this.gyro_scaled_z);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.label30);
            this.groupBox7.Controls.Add(this.label31);
            this.groupBox7.Location = new System.Drawing.Point(229, 270);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(124, 63);
            this.groupBox7.TabIndex = 15;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "gyro escala TESTE";
            // 
            // gyro_scaled_x
            // 
            this.gyro_scaled_x.AutoSize = true;
            this.gyro_scaled_x.Location = new System.Drawing.Point(26, 17);
            this.gyro_scaled_x.Name = "gyro_scaled_x";
            this.gyro_scaled_x.Size = new System.Drawing.Size(13, 13);
            this.gyro_scaled_x.TabIndex = 6;
            this.gyro_scaled_x.Text = "0";
            // 
            // gyro_scaled_y
            // 
            this.gyro_scaled_y.AutoSize = true;
            this.gyro_scaled_y.Location = new System.Drawing.Point(26, 30);
            this.gyro_scaled_y.Name = "gyro_scaled_y";
            this.gyro_scaled_y.Size = new System.Drawing.Size(13, 13);
            this.gyro_scaled_y.TabIndex = 8;
            this.gyro_scaled_y.Text = "0";
            // 
            // gyro_scaled_z
            // 
            this.gyro_scaled_z.AutoSize = true;
            this.gyro_scaled_z.Location = new System.Drawing.Point(26, 43);
            this.gyro_scaled_z.Name = "gyro_scaled_z";
            this.gyro_scaled_z.Size = new System.Drawing.Size(13, 13);
            this.gyro_scaled_z.TabIndex = 10;
            this.gyro_scaled_z.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "X";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(11, 43);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(14, 13);
            this.label30.TabIndex = 13;
            this.label30.Text = "Z";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(11, 30);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(14, 13);
            this.label31.TabIndex = 12;
            this.label31.Text = "Y";
            // 
            // preview
            // 
            this.preview.Location = new System.Drawing.Point(484, 4);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(64, 23);
            this.preview.TabIndex = 30;
            this.preview.Text = "Preview";
            this.preview.UseVisualStyleBackColor = true;
            this.preview.Click += new System.EventHandler(this.preview_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.groupBox10);
            this.groupBox11.Controls.Add(this.groupBox4);
            this.groupBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox11.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox11.Location = new System.Drawing.Point(5, 270);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(218, 87);
            this.groupBox11.TabIndex = 32;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Output sem filtro em º (Euler)";
            // 
            // yaw_offset_text
            // 
            this.yaw_offset_text.AutoSize = true;
            this.yaw_offset_text.Location = new System.Drawing.Point(491, 81);
            this.yaw_offset_text.Name = "yaw_offset_text";
            this.yaw_offset_text.Size = new System.Drawing.Size(13, 13);
            this.yaw_offset_text.TabIndex = 33;
            this.yaw_offset_text.Text = "0";
            // 
            // yawoffset
            // 
            this.yawoffset.Location = new System.Drawing.Point(483, 33);
            this.yawoffset.Name = "yawoffset";
            this.yawoffset.Size = new System.Drawing.Size(64, 23);
            this.yawoffset.TabIndex = 34;
            this.yawoffset.Text = "Alinhar";
            this.yawoffset.UseVisualStyleBackColor = true;
            this.yawoffset.Click += new System.EventHandler(this.yawoffset_Click);
            // 
            // calibrar
            // 
            this.calibrar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.calibrar.Location = new System.Drawing.Point(386, 138);
            this.calibrar.Name = "calibrar";
            this.calibrar.Size = new System.Drawing.Size(58, 24);
            this.calibrar.TabIndex = 35;
            this.calibrar.Text = "Calibrar";
            this.calibrar.UseVisualStyleBackColor = true;
            this.calibrar.Click += new System.EventHandler(this.calibrar_Click);
            // 
            // math_loop_time
            // 
            this.math_loop_time.AutoSize = true;
            this.math_loop_time.Location = new System.Drawing.Point(458, 94);
            this.math_loop_time.Name = "math_loop_time";
            this.math_loop_time.Size = new System.Drawing.Size(13, 13);
            this.math_loop_time.TabIndex = 36;
            this.math_loop_time.Text = "0";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.label39);
            this.groupBox12.Controls.Add(this.label38);
            this.groupBox12.Controls.Add(this.label37);
            this.groupBox12.Controls.Add(this.label54);
            this.groupBox12.Controls.Add(this.label36);
            this.groupBox12.Controls.Add(this.label53);
            this.groupBox12.Controls.Add(this.label35);
            this.groupBox12.Controls.Add(this.label52);
            this.groupBox12.Controls.Add(this.label34);
            this.groupBox12.Controls.Add(this.label51);
            this.groupBox12.Controls.Add(this.label33);
            this.groupBox12.Controls.Add(this.label50);
            this.groupBox12.Controls.Add(this.label4);
            this.groupBox12.Controls.Add(this.label49);
            this.groupBox12.Controls.Add(this.label3);
            this.groupBox12.Controls.Add(this.gyro_z_offset);
            this.groupBox12.Controls.Add(this.gyro_y_offset);
            this.groupBox12.Controls.Add(this.mag_z_min);
            this.groupBox12.Controls.Add(this.gyro_x_offset);
            this.groupBox12.Controls.Add(this.mag_z_max);
            this.groupBox12.Controls.Add(this.acc_z_min);
            this.groupBox12.Controls.Add(this.mag_y_min);
            this.groupBox12.Controls.Add(this.acc_z_max);
            this.groupBox12.Controls.Add(this.mag_y_max);
            this.groupBox12.Controls.Add(this.acc_y_min);
            this.groupBox12.Controls.Add(this.mag_x_min);
            this.groupBox12.Controls.Add(this.acc_y_max);
            this.groupBox12.Controls.Add(this.mag_x_max);
            this.groupBox12.Controls.Add(this.acc_x_min);
            this.groupBox12.Controls.Add(this.acc_x_max);
            this.groupBox12.Location = new System.Drawing.Point(386, 168);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(161, 258);
            this.groupBox12.TabIndex = 37;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "offsets calibração";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(5, 138);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(60, 13);
            this.label39.TabIndex = 1;
            this.label39.Text = "gyro Z oset";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(5, 125);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(60, 13);
            this.label38.TabIndex = 1;
            this.label38.Text = "gyro Y oset";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(5, 112);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(60, 13);
            this.label37.TabIndex = 1;
            this.label37.Text = "gyro X oset";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(6, 237);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(59, 13);
            this.label54.TabIndex = 1;
            this.label54.Text = "mag Z MIX";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(6, 82);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(57, 13);
            this.label36.TabIndex = 1;
            this.label36.Text = "acc Z MIX";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(6, 224);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(63, 13);
            this.label53.TabIndex = 1;
            this.label53.Text = "mag Z MAX";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(6, 69);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(61, 13);
            this.label35.TabIndex = 1;
            this.label35.Text = "acc Z MAX";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(6, 211);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(60, 13);
            this.label52.TabIndex = 1;
            this.label52.Text = "mag Y MIN";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(6, 56);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(58, 13);
            this.label34.TabIndex = 1;
            this.label34.Text = "acc Y MIN";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(6, 198);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(63, 13);
            this.label51.TabIndex = 1;
            this.label51.Text = "mag Y MAX";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(6, 43);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(61, 13);
            this.label33.TabIndex = 1;
            this.label33.Text = "acc Y MAX";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(6, 184);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(60, 13);
            this.label50.TabIndex = 1;
            this.label50.Text = "mag X MIN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "acc X MIN";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(6, 171);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(63, 13);
            this.label49.TabIndex = 1;
            this.label49.Text = "mag X MAX";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "acc X MAX";
            // 
            // gyro_z_offset
            // 
            this.gyro_z_offset.AutoSize = true;
            this.gyro_z_offset.Location = new System.Drawing.Point(72, 138);
            this.gyro_z_offset.Name = "gyro_z_offset";
            this.gyro_z_offset.Size = new System.Drawing.Size(13, 13);
            this.gyro_z_offset.TabIndex = 0;
            this.gyro_z_offset.Text = "0";
            // 
            // gyro_y_offset
            // 
            this.gyro_y_offset.AutoSize = true;
            this.gyro_y_offset.Location = new System.Drawing.Point(72, 125);
            this.gyro_y_offset.Name = "gyro_y_offset";
            this.gyro_y_offset.Size = new System.Drawing.Size(13, 13);
            this.gyro_y_offset.TabIndex = 0;
            this.gyro_y_offset.Text = "0";
            // 
            // mag_z_min
            // 
            this.mag_z_min.AutoSize = true;
            this.mag_z_min.Location = new System.Drawing.Point(73, 237);
            this.mag_z_min.Name = "mag_z_min";
            this.mag_z_min.Size = new System.Drawing.Size(13, 13);
            this.mag_z_min.TabIndex = 0;
            this.mag_z_min.Text = "0";
            // 
            // gyro_x_offset
            // 
            this.gyro_x_offset.AutoSize = true;
            this.gyro_x_offset.Location = new System.Drawing.Point(72, 112);
            this.gyro_x_offset.Name = "gyro_x_offset";
            this.gyro_x_offset.Size = new System.Drawing.Size(13, 13);
            this.gyro_x_offset.TabIndex = 0;
            this.gyro_x_offset.Text = "0";
            // 
            // mag_z_max
            // 
            this.mag_z_max.AutoSize = true;
            this.mag_z_max.Location = new System.Drawing.Point(73, 224);
            this.mag_z_max.Name = "mag_z_max";
            this.mag_z_max.Size = new System.Drawing.Size(13, 13);
            this.mag_z_max.TabIndex = 0;
            this.mag_z_max.Text = "0";
            // 
            // acc_z_min
            // 
            this.acc_z_min.AutoSize = true;
            this.acc_z_min.Location = new System.Drawing.Point(73, 82);
            this.acc_z_min.Name = "acc_z_min";
            this.acc_z_min.Size = new System.Drawing.Size(13, 13);
            this.acc_z_min.TabIndex = 0;
            this.acc_z_min.Text = "0";
            // 
            // mag_y_min
            // 
            this.mag_y_min.AutoSize = true;
            this.mag_y_min.Location = new System.Drawing.Point(73, 211);
            this.mag_y_min.Name = "mag_y_min";
            this.mag_y_min.Size = new System.Drawing.Size(13, 13);
            this.mag_y_min.TabIndex = 0;
            this.mag_y_min.Text = "0";
            // 
            // acc_z_max
            // 
            this.acc_z_max.AutoSize = true;
            this.acc_z_max.Location = new System.Drawing.Point(73, 69);
            this.acc_z_max.Name = "acc_z_max";
            this.acc_z_max.Size = new System.Drawing.Size(13, 13);
            this.acc_z_max.TabIndex = 0;
            this.acc_z_max.Text = "0";
            // 
            // mag_y_max
            // 
            this.mag_y_max.AutoSize = true;
            this.mag_y_max.Location = new System.Drawing.Point(73, 198);
            this.mag_y_max.Name = "mag_y_max";
            this.mag_y_max.Size = new System.Drawing.Size(13, 13);
            this.mag_y_max.TabIndex = 0;
            this.mag_y_max.Text = "0";
            // 
            // acc_y_min
            // 
            this.acc_y_min.AutoSize = true;
            this.acc_y_min.Location = new System.Drawing.Point(73, 56);
            this.acc_y_min.Name = "acc_y_min";
            this.acc_y_min.Size = new System.Drawing.Size(13, 13);
            this.acc_y_min.TabIndex = 0;
            this.acc_y_min.Text = "0";
            // 
            // mag_x_min
            // 
            this.mag_x_min.AutoSize = true;
            this.mag_x_min.Location = new System.Drawing.Point(73, 185);
            this.mag_x_min.Name = "mag_x_min";
            this.mag_x_min.Size = new System.Drawing.Size(13, 13);
            this.mag_x_min.TabIndex = 0;
            this.mag_x_min.Text = "0";
            // 
            // acc_y_max
            // 
            this.acc_y_max.AutoSize = true;
            this.acc_y_max.Location = new System.Drawing.Point(73, 43);
            this.acc_y_max.Name = "acc_y_max";
            this.acc_y_max.Size = new System.Drawing.Size(13, 13);
            this.acc_y_max.TabIndex = 0;
            this.acc_y_max.Text = "0";
            // 
            // mag_x_max
            // 
            this.mag_x_max.AutoSize = true;
            this.mag_x_max.Location = new System.Drawing.Point(73, 172);
            this.mag_x_max.Name = "mag_x_max";
            this.mag_x_max.Size = new System.Drawing.Size(13, 13);
            this.mag_x_max.TabIndex = 0;
            this.mag_x_max.Text = "0";
            // 
            // acc_x_min
            // 
            this.acc_x_min.AutoSize = true;
            this.acc_x_min.Location = new System.Drawing.Point(73, 30);
            this.acc_x_min.Name = "acc_x_min";
            this.acc_x_min.Size = new System.Drawing.Size(13, 13);
            this.acc_x_min.TabIndex = 0;
            this.acc_x_min.Text = "0";
            // 
            // acc_x_max
            // 
            this.acc_x_max.AutoSize = true;
            this.acc_x_max.Location = new System.Drawing.Point(73, 17);
            this.acc_x_max.Name = "acc_x_max";
            this.acc_x_max.Size = new System.Drawing.Size(13, 13);
            this.acc_x_max.TabIndex = 0;
            this.acc_x_max.Text = "0";
            // 
            // clear_calibration
            // 
            this.clear_calibration.Location = new System.Drawing.Point(521, 431);
            this.clear_calibration.Name = "clear_calibration";
            this.clear_calibration.Size = new System.Drawing.Size(26, 23);
            this.clear_calibration.TabIndex = 39;
            this.clear_calibration.Text = "clr";
            this.clear_calibration.UseVisualStyleBackColor = true;
            this.clear_calibration.Click += new System.EventHandler(this.clear_calibration_Click);
            // 
            // calib_option
            // 
            this.calib_option.FormattingEnabled = true;
            this.calib_option.Items.AddRange(new object[] {
            "Accel X MAX",
            "Accel X MIN",
            "Accel Y MAX",
            "Accel Y MIN",
            "Accel Z MAX",
            "Accel Z MIN",
            "Mag X MAX",
            "Mag X MIN",
            "Mag Y MAX",
            "Mag Y MIN",
            "Mag Z MAX",
            "Mag Z MIN",
            "Gyro"});
            this.calib_option.Location = new System.Drawing.Point(450, 138);
            this.calib_option.Name = "calib_option";
            this.calib_option.Size = new System.Drawing.Size(97, 21);
            this.calib_option.TabIndex = 38;
            this.calib_option.Tag = "";
            this.calib_option.Text = "Accel X MAX";
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.gyro_calibrated_x);
            this.groupBox13.Controls.Add(this.gyro_calibrated_y);
            this.groupBox13.Controls.Add(this.gyro_calibrated_z);
            this.groupBox13.Controls.Add(this.label43);
            this.groupBox13.Controls.Add(this.label44);
            this.groupBox13.Controls.Add(this.label45);
            this.groupBox13.Location = new System.Drawing.Point(229, 201);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(124, 63);
            this.groupBox13.TabIndex = 15;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "gyro calibrado";
            // 
            // gyro_calibrated_x
            // 
            this.gyro_calibrated_x.AutoSize = true;
            this.gyro_calibrated_x.Location = new System.Drawing.Point(26, 17);
            this.gyro_calibrated_x.Name = "gyro_calibrated_x";
            this.gyro_calibrated_x.Size = new System.Drawing.Size(13, 13);
            this.gyro_calibrated_x.TabIndex = 6;
            this.gyro_calibrated_x.Text = "0";
            // 
            // gyro_calibrated_y
            // 
            this.gyro_calibrated_y.AutoSize = true;
            this.gyro_calibrated_y.Location = new System.Drawing.Point(26, 30);
            this.gyro_calibrated_y.Name = "gyro_calibrated_y";
            this.gyro_calibrated_y.Size = new System.Drawing.Size(13, 13);
            this.gyro_calibrated_y.TabIndex = 8;
            this.gyro_calibrated_y.Text = "0";
            // 
            // gyro_calibrated_z
            // 
            this.gyro_calibrated_z.AutoSize = true;
            this.gyro_calibrated_z.Location = new System.Drawing.Point(26, 43);
            this.gyro_calibrated_z.Name = "gyro_calibrated_z";
            this.gyro_calibrated_z.Size = new System.Drawing.Size(13, 13);
            this.gyro_calibrated_z.TabIndex = 10;
            this.gyro_calibrated_z.Text = "0";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(11, 17);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(14, 13);
            this.label43.TabIndex = 11;
            this.label43.Text = "X";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(11, 43);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(14, 13);
            this.label44.TabIndex = 13;
            this.label44.Text = "Z";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(11, 30);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(14, 13);
            this.label45.TabIndex = 12;
            this.label45.Text = "Y";
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.dcm_matriz_1);
            this.groupBox14.Controls.Add(this.dcm_matriz_0);
            this.groupBox14.Controls.Add(this.dcm_matriz_2);
            this.groupBox14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox14.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox14.Location = new System.Drawing.Point(123, 363);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(131, 63);
            this.groupBox14.TabIndex = 18;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "DCM (Matriz)";
            // 
            // dcm_matriz_1
            // 
            this.dcm_matriz_1.AutoSize = true;
            this.dcm_matriz_1.Location = new System.Drawing.Point(6, 29);
            this.dcm_matriz_1.Name = "dcm_matriz_1";
            this.dcm_matriz_1.Size = new System.Drawing.Size(13, 13);
            this.dcm_matriz_1.TabIndex = 8;
            this.dcm_matriz_1.Text = "0";
            // 
            // dcm_matriz_0
            // 
            this.dcm_matriz_0.AutoSize = true;
            this.dcm_matriz_0.Location = new System.Drawing.Point(6, 16);
            this.dcm_matriz_0.Name = "dcm_matriz_0";
            this.dcm_matriz_0.Size = new System.Drawing.Size(13, 13);
            this.dcm_matriz_0.TabIndex = 6;
            this.dcm_matriz_0.Text = "0";
            // 
            // dcm_matriz_2
            // 
            this.dcm_matriz_2.AutoSize = true;
            this.dcm_matriz_2.Location = new System.Drawing.Point(6, 42);
            this.dcm_matriz_2.Name = "dcm_matriz_2";
            this.dcm_matriz_2.Size = new System.Drawing.Size(13, 13);
            this.dcm_matriz_2.TabIndex = 10;
            this.dcm_matriz_2.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(383, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "math (avg ms)";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(383, 108);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(70, 13);
            this.label40.TabIndex = 22;
            this.label40.Text = "inter (avg ms)";
            // 
            // interface_loop_time
            // 
            this.interface_loop_time.AutoSize = true;
            this.interface_loop_time.Location = new System.Drawing.Point(458, 108);
            this.interface_loop_time.Name = "interface_loop_time";
            this.interface_loop_time.Size = new System.Drawing.Size(13, 13);
            this.interface_loop_time.TabIndex = 36;
            this.interface_loop_time.Text = "0";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(133, 82);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(41, 13);
            this.label41.TabIndex = 3;
            this.label41.Text = "IP/Port";
            // 
            // clientport
            // 
            this.clientport.Location = new System.Drawing.Point(268, 79);
            this.clientport.Name = "clientport";
            this.clientport.Size = new System.Drawing.Size(46, 20);
            this.clientport.TabIndex = 1;
            this.clientport.Text = "5555";
            // 
            // send_udp_packet
            // 
            this.send_udp_packet.AutoSize = true;
            this.send_udp_packet.Location = new System.Drawing.Point(15, 81);
            this.send_udp_packet.Name = "send_udp_packet";
            this.send_udp_packet.Size = new System.Drawing.Size(118, 17);
            this.send_udp_packet.TabIndex = 40;
            this.send_udp_packet.Text = "Send UDP packets";
            this.send_udp_packet.UseVisualStyleBackColor = true;
            // 
            // udp_packet_sent
            // 
            this.udp_packet_sent.AutoSize = true;
            this.udp_packet_sent.Location = new System.Drawing.Point(13, 108);
            this.udp_packet_sent.Name = "udp_packet_sent";
            this.udp_packet_sent.Size = new System.Drawing.Size(13, 13);
            this.udp_packet_sent.TabIndex = 41;
            this.udp_packet_sent.Text = "[]";
            // 
            // clientip
            // 
            this.clientip.Location = new System.Drawing.Point(180, 79);
            this.clientip.Name = "clientip";
            this.clientip.Size = new System.Drawing.Size(82, 20);
            this.clientip.TabIndex = 42;
            this.clientip.Text = "192.168.1.2";
            // 
            // preview_method
            // 
            this.preview_method.FormattingEnabled = true;
            this.preview_method.Items.AddRange(new object[] {
            "Matriz Cosenos",
            "Complementar"});
            this.preview_method.Location = new System.Drawing.Point(305, 4);
            this.preview_method.Name = "preview_method";
            this.preview_method.Size = new System.Drawing.Size(100, 21);
            this.preview_method.TabIndex = 43;
            this.preview_method.Text = "Matriz Cosenos";
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.compfilter_x);
            this.groupBox15.Controls.Add(this.compfilter_y);
            this.groupBox15.Controls.Add(this.compfilter_z);
            this.groupBox15.Controls.Add(this.label48);
            this.groupBox15.Controls.Add(this.label55);
            this.groupBox15.Controls.Add(this.label56);
            this.groupBox15.Location = new System.Drawing.Point(260, 363);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(124, 63);
            this.groupBox15.TabIndex = 15;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Comp filter";
            // 
            // compfilter_x
            // 
            this.compfilter_x.AutoSize = true;
            this.compfilter_x.Location = new System.Drawing.Point(26, 17);
            this.compfilter_x.Name = "compfilter_x";
            this.compfilter_x.Size = new System.Drawing.Size(13, 13);
            this.compfilter_x.TabIndex = 6;
            this.compfilter_x.Text = "0";
            // 
            // compfilter_y
            // 
            this.compfilter_y.AutoSize = true;
            this.compfilter_y.Location = new System.Drawing.Point(26, 30);
            this.compfilter_y.Name = "compfilter_y";
            this.compfilter_y.Size = new System.Drawing.Size(13, 13);
            this.compfilter_y.TabIndex = 8;
            this.compfilter_y.Text = "0";
            // 
            // compfilter_z
            // 
            this.compfilter_z.AutoSize = true;
            this.compfilter_z.Location = new System.Drawing.Point(26, 43);
            this.compfilter_z.Name = "compfilter_z";
            this.compfilter_z.Size = new System.Drawing.Size(13, 13);
            this.compfilter_z.TabIndex = 10;
            this.compfilter_z.Text = "0";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(11, 17);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(14, 13);
            this.label48.TabIndex = 11;
            this.label48.Text = "X";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(11, 43);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(14, 13);
            this.label55.TabIndex = 13;
            this.label55.Text = "Z";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(11, 30);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(14, 13);
            this.label56.TabIndex = 12;
            this.label56.Text = "Y";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(41, 38);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(53, 13);
            this.label42.TabIndex = 44;
            this.label42.Text = "COM Port";
            // 
            // COM_port
            // 
            this.COM_port.Location = new System.Drawing.Point(101, 35);
            this.COM_port.Name = "COM_port";
            this.COM_port.Size = new System.Drawing.Size(48, 20);
            this.COM_port.TabIndex = 45;
            this.COM_port.Text = "COM3";
            // 
            // start_serial
            // 
            this.start_serial.Location = new System.Drawing.Point(155, 35);
            this.start_serial.Name = "start_serial";
            this.start_serial.Size = new System.Drawing.Size(61, 23);
            this.start_serial.TabIndex = 46;
            this.start_serial.Text = "Start";
            this.start_serial.UseVisualStyleBackColor = true;
            this.start_serial.Click += new System.EventHandler(this.start_serial_Click);
            // 
            // stop_serial
            // 
            this.stop_serial.Location = new System.Drawing.Point(222, 35);
            this.stop_serial.Name = "stop_serial";
            this.stop_serial.Size = new System.Drawing.Size(56, 23);
            this.stop_serial.TabIndex = 47;
            this.stop_serial.Text = "Stop";
            this.stop_serial.UseVisualStyleBackColor = true;
            this.stop_serial.Click += new System.EventHandler(this.stop_serial_Click);
            // 
            // bw_serial_data
            // 
            this.bw_serial_data.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_serial_data_DoWork);
            this.bw_serial_data.WorkerReportsProgress = true;
            this.bw_serial_data.WorkerSupportsCancellation = true;
            this.bw_serial_data.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_serial_data_RunWorkerCompleted);



            // 
            // COM_data
            // 
            this.COM_data.AutoSize = true;
            this.COM_data.Location = new System.Drawing.Point(286, 38);
            this.COM_data.Name = "COM_data";
            this.COM_data.Size = new System.Drawing.Size(36, 13);
            this.COM_data.TabIndex = 48;
            this.COM_data.Text = "[Data]";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 508);
            this.Controls.Add(this.COM_data);
            this.Controls.Add(this.stop_serial);
            this.Controls.Add(this.start_serial);
            this.Controls.Add(this.COM_port);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.preview_method);
            this.Controls.Add(this.clientip);
            this.Controls.Add(this.udp_packet_sent);
            this.Controls.Add(this.send_udp_packet);
            this.Controls.Add(this.clear_calibration);
            this.Controls.Add(this.calib_option);
            this.Controls.Add(this.groupBox12);
            this.Controls.Add(this.groupBox14);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.interface_loop_time);
            this.Controls.Add(this.math_loop_time);
            this.Controls.Add(this.groupBox15);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.calibrar);
            this.Controls.Add(this.yawoffset);
            this.Controls.Add(this.yaw_offset_text);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.preview);
            this.Controls.Add(this.togglechart);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.timestamp);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.clientport);
            this.Controls.Add(this.listenport);
            this.Controls.Add(this.start);
            this.Controls.Add(this.groupBox13);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "IMU interface";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.TextBox listenport;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker bw_worker;
        private System.Windows.Forms.TextBox system_message;
        private System.Windows.Forms.Label acc_x;
        private System.Windows.Forms.Label acc_y;
        private System.Windows.Forms.Label acc_z;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label mag_x;
        private System.Windows.Forms.Label mag_y;
        private System.Windows.Forms.Label mag_z;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label gyro_x;
        private System.Windows.Forms.Label gyro_y;
        private System.Windows.Forms.Label gyro_z;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label yaw_cali;
        private System.Windows.Forms.Label pitch_cali;
        private System.Windows.Forms.Label roll_cali;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox sender_info;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label acc_cali_x;
        private System.Windows.Forms.Label acc_cali_y;
        private System.Windows.Forms.Label acc_cali_z;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label mag_cali_x;
        private System.Windows.Forms.Label mag_cali_y;
        private System.Windows.Forms.Label mag_cali_z;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label timestamp;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label pitch_dcm;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label yaw_dcm;
        private System.Windows.Forms.Label roll_dcm;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label pitch;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label yaw;
        private System.Windows.Forms.Label roll;
        private System.Windows.Forms.Label label32;
        private OxyPlot.WindowsForms.PlotView plot1;
        private System.Windows.Forms.Button togglechart;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label gyro_scaled_x;
        private System.Windows.Forms.Label gyro_scaled_y;
        private System.Windows.Forms.Label gyro_scaled_z;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Button preview;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label yaw_offset_text;
        private System.Windows.Forms.Button yawoffset;
        private System.Windows.Forms.Button calibrar;
        private System.Windows.Forms.Label math_loop_time;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.ComponentModel.BackgroundWorker bw_calibrar;
        private System.Windows.Forms.Label acc_x_max;
        private System.Windows.Forms.Label acc_x_min;
        private System.Windows.Forms.ComboBox calib_option;
        private System.Windows.Forms.Button clear_calibration;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label acc_z_min;
        private System.Windows.Forms.Label acc_z_max;
        private System.Windows.Forms.Label acc_y_min;
        private System.Windows.Forms.Label acc_y_max;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label gyro_z_offset;
        private System.Windows.Forms.Label gyro_y_offset;
        private System.Windows.Forms.Label gyro_x_offset;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.Label gyro_calibrated_x;
        private System.Windows.Forms.Label gyro_calibrated_y;
        private System.Windows.Forms.Label gyro_calibrated_z;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label mag_z_min;
        private System.Windows.Forms.Label mag_z_max;
        private System.Windows.Forms.Label mag_y_min;
        private System.Windows.Forms.Label mag_y_max;
        private System.Windows.Forms.Label mag_x_min;
        private System.Windows.Forms.Label mag_x_max;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.Label dcm_matriz_1;
        private System.Windows.Forms.Label dcm_matriz_0;
        private System.Windows.Forms.Label dcm_matriz_2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label interface_loop_time;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox clientport;
        private System.Windows.Forms.CheckBox send_udp_packet;
        private System.Windows.Forms.Label udp_packet_sent;
        private System.Windows.Forms.TextBox clientip;
        private System.Windows.Forms.ComboBox preview_method;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.Label compfilter_x;
        private System.Windows.Forms.Label compfilter_y;
        private System.Windows.Forms.Label compfilter_z;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox COM_port;
        private System.Windows.Forms.Button start_serial;
        private System.Windows.Forms.Button stop_serial;
        private System.ComponentModel.BackgroundWorker bw_serial_data;
        private System.Windows.Forms.Label COM_data;
    }
}

