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
            this.bw_worker = new System.ComponentModel.BackgroundWorker();
            this.system_message = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.sender_info = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.pitch_dcm = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.yaw_dcm = new System.Windows.Forms.Label();
            this.roll_dcm = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.plot1 = new OxyPlot.WindowsForms.PlotView();
            this.togglechart = new System.Windows.Forms.Button();
            this.preview = new System.Windows.Forms.Button();
            this.yawoffset = new System.Windows.Forms.Button();
            this.bw_calibrar = new System.ComponentModel.BackgroundWorker();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.dcm_matriz_1 = new System.Windows.Forms.Label();
            this.dcm_matriz_0 = new System.Windows.Forms.Label();
            this.dcm_matriz_2 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.COM_port = new System.Windows.Forms.TextBox();
            this.start_serial = new System.Windows.Forms.Button();
            this.stop_serial = new System.Windows.Forms.Button();
            this.bw_serial_data = new System.ComponentModel.BackgroundWorker();
            this.COM_data = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.SuspendLayout();
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
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.sender_info);
            this.groupBox5.Controls.Add(this.system_message);
            this.groupBox5.Location = new System.Drawing.Point(12, 106);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(388, 64);
            this.groupBox5.TabIndex = 19;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "messages";
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
            this.groupBox6.Location = new System.Drawing.Point(12, 38);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(102, 63);
            this.groupBox6.TabIndex = 18;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "angles";
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
            this.togglechart.Location = new System.Drawing.Point(263, 44);
            this.togglechart.Name = "togglechart";
            this.togglechart.Size = new System.Drawing.Size(67, 23);
            this.togglechart.TabIndex = 23;
            this.togglechart.Text = "chart";
            this.togglechart.UseVisualStyleBackColor = true;
            this.togglechart.Click += new System.EventHandler(this.chart_Click);
            // 
            // preview
            // 
            this.preview.Location = new System.Drawing.Point(336, 44);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(64, 23);
            this.preview.TabIndex = 30;
            this.preview.Text = "3d model";
            this.preview.UseVisualStyleBackColor = true;
            this.preview.Click += new System.EventHandler(this.preview_Click);
            // 
            // yawoffset
            // 
            this.yawoffset.Location = new System.Drawing.Point(335, 73);
            this.yawoffset.Name = "yawoffset";
            this.yawoffset.Size = new System.Drawing.Size(64, 23);
            this.yawoffset.TabIndex = 34;
            this.yawoffset.Text = "alinhar";
            this.yawoffset.UseVisualStyleBackColor = true;
            this.yawoffset.Click += new System.EventHandler(this.yawoffset_Click);
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.dcm_matriz_1);
            this.groupBox14.Controls.Add(this.dcm_matriz_0);
            this.groupBox14.Controls.Add(this.dcm_matriz_2);
            this.groupBox14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox14.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox14.Location = new System.Drawing.Point(120, 38);
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
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(15, 15);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(52, 13);
            this.label42.TabIndex = 44;
            this.label42.Text = "COM port";
            // 
            // COM_port
            // 
            this.COM_port.Location = new System.Drawing.Point(75, 12);
            this.COM_port.Name = "COM_port";
            this.COM_port.Size = new System.Drawing.Size(48, 20);
            this.COM_port.TabIndex = 45;
            this.COM_port.Text = "COM3";
            // 
            // start_serial
            // 
            this.start_serial.Location = new System.Drawing.Point(129, 12);
            this.start_serial.Name = "start_serial";
            this.start_serial.Size = new System.Drawing.Size(61, 23);
            this.start_serial.TabIndex = 46;
            this.start_serial.Text = "start";
            this.start_serial.UseVisualStyleBackColor = true;
            this.start_serial.Click += new System.EventHandler(this.start_serial_Click);
            // 
            // stop_serial
            // 
            this.stop_serial.Location = new System.Drawing.Point(196, 12);
            this.stop_serial.Name = "stop_serial";
            this.stop_serial.Size = new System.Drawing.Size(56, 23);
            this.stop_serial.TabIndex = 47;
            this.stop_serial.Text = "stop";
            this.stop_serial.UseVisualStyleBackColor = true;
            this.stop_serial.Click += new System.EventHandler(this.stop_serial_Click);
            // 
            // bw_serial_data
            // 
            this.bw_serial_data.WorkerReportsProgress = true;
            this.bw_serial_data.WorkerSupportsCancellation = true;
            this.bw_serial_data.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_serial_data_DoWork);
            this.bw_serial_data.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_serial_data_RunWorkerCompleted);
            // 
            // COM_data
            // 
            this.COM_data.AutoSize = true;
            this.COM_data.Location = new System.Drawing.Point(260, 15);
            this.COM_data.Name = "COM_data";
            this.COM_data.Size = new System.Drawing.Size(36, 13);
            this.COM_data.TabIndex = 48;
            this.COM_data.Text = "[Data]";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 182);
            this.Controls.Add(this.COM_data);
            this.Controls.Add(this.stop_serial);
            this.Controls.Add(this.start_serial);
            this.Controls.Add(this.COM_port);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.groupBox14);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.yawoffset);
            this.Controls.Add(this.preview);
            this.Controls.Add(this.togglechart);
            this.Controls.Add(this.groupBox5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "imu interface";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker bw_worker;
        private System.Windows.Forms.TextBox system_message;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox sender_info;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label pitch_dcm;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label yaw_dcm;
        private System.Windows.Forms.Label roll_dcm;
        private System.Windows.Forms.Label label29;
        private OxyPlot.WindowsForms.PlotView plot1;
        private System.Windows.Forms.Button togglechart;
        private System.Windows.Forms.Button preview;
        private System.Windows.Forms.Button yawoffset;
        private System.ComponentModel.BackgroundWorker bw_calibrar;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.Label dcm_matriz_1;
        private System.Windows.Forms.Label dcm_matriz_0;
        private System.Windows.Forms.Label dcm_matriz_2;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox COM_port;
        private System.Windows.Forms.Button start_serial;
        private System.Windows.Forms.Button stop_serial;
        private System.ComponentModel.BackgroundWorker bw_serial_data;
        private System.Windows.Forms.Label COM_data;
    }
}

