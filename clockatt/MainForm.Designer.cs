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
            this.dateTimeLabel = new System.Windows.Forms.Label();
            this.DspTimer = new System.Windows.Forms.Timer(this.components);
            this.LocateTimer = new System.Windows.Forms.Timer(this.components);
            this.taskInfoNotify = new System.Windows.Forms.NotifyIcon(this.components);
            this.RightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miConfigClock = new System.Windows.Forms.ToolStripMenuItem();
            this.miQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.RightClickMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimeLabel
            // 
            this.dateTimeLabel.AutoSize = true;
            this.dateTimeLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.dateTimeLabel.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dateTimeLabel.ForeColor = System.Drawing.Color.Red;
            this.dateTimeLabel.Location = new System.Drawing.Point(24, 1);
            this.dateTimeLabel.MaximumSize = new System.Drawing.Size(155, 14);
            this.dateTimeLabel.Name = "dateTimeLabel";
            this.dateTimeLabel.Size = new System.Drawing.Size(133, 12);
            this.dateTimeLabel.TabIndex = 2;
            this.dateTimeLabel.Text = "2009/03/21(日)  21:12:12";
            this.dateTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dateTimeLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dateTimeLabel_MouseClick);
            // 
            // DspTimer
            // 
            this.DspTimer.Tick += new System.EventHandler(this.DspTimer_Tick);
            // 
            // LocateTimer
            // 
            this.LocateTimer.Enabled = true;
            this.LocateTimer.Tick += new System.EventHandler(this.LocateTimer_Tick);
            // 
            // taskInfoNotify
            // 
            this.taskInfoNotify.ContextMenuStrip = this.RightClickMenu;
            this.taskInfoNotify.Text = "ClockAtt";
            this.taskInfoNotify.Visible = true;
            // 
            // RightClickMenu
            // 
            this.RightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miConfigClock,
            this.miQuit});
            this.RightClickMenu.Name = "RightClickMenu";
            this.RightClickMenu.ShowImageMargin = false;
            this.RightClickMenu.Size = new System.Drawing.Size(118, 48);
            // 
            // miConfigClock
            // 
            this.miConfigClock.Name = "miConfigClock";
            this.miConfigClock.Size = new System.Drawing.Size(117, 22);
            this.miConfigClock.Text = "時計表示設定";
            this.miConfigClock.Click += new System.EventHandler(this.miConfigClock_Click);
            // 
            // miQuit
            // 
            this.miQuit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.miQuit.Name = "miQuit";
            this.miQuit.ShortcutKeyDisplayString = "";
            this.miQuit.Size = new System.Drawing.Size(117, 22);
            this.miQuit.Text = "終了(&Q)";
            this.miQuit.Click += new System.EventHandler(this.miQuit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(157, 17);
            this.ContextMenuStrip = this.RightClickMenu;
            this.Controls.Add(this.dateTimeLabel);
            this.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(157, 17);
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "MainForm";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.RightClickMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Label dateTimeLabel;
        private System.Windows.Forms.Timer DspTimer;
        private System.Windows.Forms.Timer LocateTimer;
        private System.Windows.Forms.NotifyIcon taskInfoNotify;
        private System.Windows.Forms.ContextMenuStrip RightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem miQuit;
        private System.Windows.Forms.ToolStripMenuItem miConfigClock;
    }
}