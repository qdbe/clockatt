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
            this.DspTimer = new System.Windows.Forms.Timer(this.components);
            this.LocateTimer = new System.Windows.Forms.Timer(this.components);
            this.taskInfoNotify = new System.Windows.Forms.NotifyIcon(this.components);
            this.RightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miConfigration = new System.Windows.Forms.ToolStripMenuItem();
            this.miQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.RightClickMenu.SuspendLayout();
            this.SuspendLayout();
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
            this.miConfigration,
            this.miQuit});
            this.RightClickMenu.Name = "RightClickMenu";
            this.RightClickMenu.ShowImageMargin = false;
            this.RightClickMenu.Size = new System.Drawing.Size(86, 48);
            // 
            // miConfigration
            // 
            this.miConfigration.Name = "miConfigration";
            this.miConfigration.Size = new System.Drawing.Size(85, 22);
            this.miConfigration.Text = "設定(&C)";
            this.miConfigration.Click += new System.EventHandler(this.miConfigClock_Click);
            // 
            // miQuit
            // 
            this.miQuit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.miQuit.Name = "miQuit";
            this.miQuit.ShortcutKeyDisplayString = "";
            this.miQuit.Size = new System.Drawing.Size(85, 22);
            this.miQuit.Text = "終了(&Q)";
            this.miQuit.Click += new System.EventHandler(this.miQuit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::clockatt.Properties.Settings.Default.BackColor;
            this.ClientSize = new System.Drawing.Size(154, 100);
            this.ContextMenuStrip = this.RightClickMenu;
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::clockatt.Properties.Settings.Default, "BackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::clockatt.Properties.Settings.Default, "Font", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::clockatt.Properties.Settings.Default, "ForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = global::clockatt.Properties.Settings.Default.Font;
            this.ForeColor = global::clockatt.Properties.Settings.Default.ForeColor;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "MainForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseClick);
            this.RightClickMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Timer DspTimer;
        private System.Windows.Forms.Timer LocateTimer;
        private System.Windows.Forms.NotifyIcon taskInfoNotify;
        private System.Windows.Forms.ContextMenuStrip RightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem miQuit;
        private System.Windows.Forms.ToolStripMenuItem miConfigration;
    }
}