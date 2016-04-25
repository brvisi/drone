namespace IMU_module
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
            this.plot1 = new OxyPlot.WindowsForms.PlotView();
            this.togglechart = new System.Windows.Forms.Button();
            this.preview = new System.Windows.Forms.Button();
            this.alignyaw = new System.Windows.Forms.Button();
            this.bw_calibrar = new System.ComponentModel.BackgroundWorker();
            this.label42 = new System.Windows.Forms.Label();
            this.COM_port = new System.Windows.Forms.TextBox();
            this.start_serial = new System.Windows.Forms.Button();
            this.stop_serial = new System.Windows.Forms.Button();
            this.bw_serial_data = new System.ComponentModel.BackgroundWorker();
            this.label29 = new System.Windows.Forms.Label();
            this.roll_dcm = new System.Windows.Forms.Label();
            this.yaw_dcm = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pitch_dcm = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.yaw_offset = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // system_message
            // 
            this.system_message.BackColor = System.Drawing.SystemColors.Menu;
            this.system_message.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.system_message.Enabled = false;
            this.system_message.Location = new System.Drawing.Point(7, 19);
            this.system_message.Name = "system_message";
            this.system_message.Size = new System.Drawing.Size(165, 13);
            this.system_message.TabIndex = 4;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.sender_info);
            this.groupBox5.Controls.Add(this.system_message);
            this.groupBox5.Location = new System.Drawing.Point(12, 106);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(178, 64);
            this.groupBox5.TabIndex = 19;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "messages";
            // 
            // sender_info
            // 
            this.sender_info.BackColor = System.Drawing.SystemColors.Menu;
            this.sender_info.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sender_info.Enabled = false;
            this.sender_info.Location = new System.Drawing.Point(7, 38);
            this.sender_info.Name = "sender_info";
            this.sender_info.Size = new System.Drawing.Size(165, 13);
            this.sender_info.TabIndex = 5;
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
            this.togglechart.Location = new System.Drawing.Point(196, 144);
            this.togglechart.Name = "togglechart";
            this.togglechart.Size = new System.Drawing.Size(63, 23);
            this.togglechart.TabIndex = 23;
            this.togglechart.Text = "chart";
            this.togglechart.UseVisualStyleBackColor = true;
            this.togglechart.Click += new System.EventHandler(this.chart_Click);
            // 
            // preview
            // 
            this.preview.Location = new System.Drawing.Point(196, 115);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(63, 23);
            this.preview.TabIndex = 30;
            this.preview.Text = "3d model";
            this.preview.UseVisualStyleBackColor = true;
            this.preview.Click += new System.EventHandler(this.preview_Click);
            // 
            // alignyaw
            // 
            this.alignyaw.Location = new System.Drawing.Point(129, 44);
            this.alignyaw.Name = "alignyaw";
            this.alignyaw.Size = new System.Drawing.Size(61, 23);
            this.alignyaw.TabIndex = 34;
            this.alignyaw.Text = "align yaw";
            this.alignyaw.UseVisualStyleBackColor = true;
            this.alignyaw.Click += new System.EventHandler(this.alignyaw_Click);
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
            this.stop_serial.Size = new System.Drawing.Size(63, 23);
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
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(6, 42);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(20, 13);
            this.label29.TabIndex = 13;
            this.label29.Text = "roll";
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
            // yaw_dcm
            // 
            this.yaw_dcm.AutoSize = true;
            this.yaw_dcm.Location = new System.Drawing.Point(45, 16);
            this.yaw_dcm.Name = "yaw_dcm";
            this.yaw_dcm.Size = new System.Drawing.Size(13, 13);
            this.yaw_dcm.TabIndex = 6;
            this.yaw_dcm.Text = "0";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 29);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(30, 13);
            this.label23.TabIndex = 12;
            this.label23.Text = "pitch";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "yaw";
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
            this.groupBox6.Size = new System.Drawing.Size(111, 63);
            this.groupBox6.TabIndex = 18;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "angles in degrees";
            // 
            // yaw_offset
            // 
            this.yaw_offset.AutoSize = true;
            this.yaw_offset.Location = new System.Drawing.Point(196, 49);
            this.yaw_offset.Name = "yaw_offset";
            this.yaw_offset.Size = new System.Drawing.Size(55, 13);
            this.yaw_offset.TabIndex = 48;
            this.yaw_offset.Text = "yaw offset";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 182);
            this.Controls.Add(this.yaw_offset);
            this.Controls.Add(this.stop_serial);
            this.Controls.Add(this.start_serial);
            this.Controls.Add(this.COM_port);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.alignyaw);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker bw_worker;
        private System.Windows.Forms.TextBox system_message;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox sender_info;
        private OxyPlot.WindowsForms.PlotView plot1;
        private System.Windows.Forms.Button togglechart;
        private System.Windows.Forms.Button preview;
        private System.Windows.Forms.Button alignyaw;
        private System.ComponentModel.BackgroundWorker bw_calibrar;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox COM_port;
        private System.Windows.Forms.Button start_serial;
        private System.Windows.Forms.Button stop_serial;
        private System.ComponentModel.BackgroundWorker bw_serial_data;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label roll_dcm;
        private System.Windows.Forms.Label yaw_dcm;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label pitch_dcm;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label yaw_offset;
    }
}

