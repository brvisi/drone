namespace IMU_sensor_headtracker
{
    partial class graph
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
            this.uiMainPlot = new OxyPlot.WindowsForms.PlotView();
            this.graph_data = new System.Windows.Forms.ComboBox();
            this.checkYaw = new System.Windows.Forms.CheckBox();
            this.checkPitch = new System.Windows.Forms.CheckBox();
            this.checkRoll = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // uiMainPlot
            // 
            this.uiMainPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiMainPlot.Location = new System.Drawing.Point(0, 0);
            this.uiMainPlot.Name = "uiMainPlot";
            this.uiMainPlot.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.uiMainPlot.Size = new System.Drawing.Size(977, 456);
            this.uiMainPlot.TabIndex = 0;
            this.uiMainPlot.Text = "plotView1";
            this.uiMainPlot.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.uiMainPlot.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.uiMainPlot.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // graph_data
            // 
            this.graph_data.FormattingEnabled = true;
            this.graph_data.Location = new System.Drawing.Point(12, 12);
            this.graph_data.Name = "graph_data";
            this.graph_data.Size = new System.Drawing.Size(99, 21);
            this.graph_data.TabIndex = 1;
            this.graph_data.Text = "Valores \"raw\"";
            // 
            // checkYaw
            // 
            this.checkYaw.AutoSize = true;
            this.checkYaw.Location = new System.Drawing.Point(122, 14);
            this.checkYaw.Name = "checkYaw";
            this.checkYaw.Size = new System.Drawing.Size(47, 17);
            this.checkYaw.TabIndex = 3;
            this.checkYaw.Text = "Yaw";
            this.checkYaw.UseVisualStyleBackColor = true;
            // 
            // checkPitch
            // 
            this.checkPitch.AutoSize = true;
            this.checkPitch.Location = new System.Drawing.Point(175, 14);
            this.checkPitch.Name = "checkPitch";
            this.checkPitch.Size = new System.Drawing.Size(50, 17);
            this.checkPitch.TabIndex = 3;
            this.checkPitch.Text = "Pitch";
            this.checkPitch.UseVisualStyleBackColor = true;
            // 
            // checkRoll
            // 
            this.checkRoll.AutoSize = true;
            this.checkRoll.Location = new System.Drawing.Point(231, 14);
            this.checkRoll.Name = "checkRoll";
            this.checkRoll.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkRoll.Size = new System.Drawing.Size(44, 17);
            this.checkRoll.TabIndex = 3;
            this.checkRoll.Text = "Roll";
            this.checkRoll.UseVisualStyleBackColor = true;
            // 
            // graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 456);
            this.ControlBox = false;
            this.Controls.Add(this.checkRoll);
            this.Controls.Add(this.checkPitch);
            this.Controls.Add(this.checkYaw);
            this.Controls.Add(this.graph_data);
            this.Controls.Add(this.uiMainPlot);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "graph";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chart Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OxyPlot.WindowsForms.PlotView uiMainPlot;
        private System.Windows.Forms.ComboBox graph_data;
        private System.Windows.Forms.CheckBox checkYaw;
        private System.Windows.Forms.CheckBox checkPitch;
        private System.Windows.Forms.CheckBox checkRoll;
    }
}