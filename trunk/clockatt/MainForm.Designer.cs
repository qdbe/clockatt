namespace clockatt
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.timeLabel = new System.Windows.Forms.Label();
            this.DspTimer = new System.Windows.Forms.Timer(this.components);
            this.LocateTimer = new System.Windows.Forms.Timer(this.components);
            this.taskInfoNotify = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.ForeColor = System.Drawing.Color.Red;
            this.timeLabel.Location = new System.Drawing.Point(64, 4);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(109, 12);
            this.timeLabel.TabIndex = 0;
            this.timeLabel.Text = "2009/03/21 12:22:45";
            // 
            // DspTimer
            // 
            this.DspTimer.Tick += new System.EventHandler(this.DspTimer_Tick);
            // 
            // LocateTimer
            // 
            this.LocateTimer.Enabled = true;
            this.LocateTimer.Interval = 10;
            this.LocateTimer.Tick += new System.EventHandler(this.LocateTimer_Tick);
            // 
            // taskInfoNotify
            // 
            this.taskInfoNotify.Text = "ClockAtt";
            this.taskInfoNotify.Visible = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(174, 19);
            this.Controls.Add(this.timeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.Text = "MainForm";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Timer DspTimer;
        private System.Windows.Forms.Timer LocateTimer;
        private System.Windows.Forms.NotifyIcon taskInfoNotify;
    }
}