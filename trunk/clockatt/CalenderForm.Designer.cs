namespace clockatt
{
    partial class CalenderForm
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
            this.dayToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // dayToolTip
            // 
            this.dayToolTip.AutoPopDelay = 5000;
            this.dayToolTip.InitialDelay = 100;
            this.dayToolTip.ReshowDelay = 100;
            // 
            // CalenderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::clockatt.Properties.Settings.Default.Cal_BackColor;
            this.ClientSize = new System.Drawing.Size(178, 180);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::clockatt.Properties.Settings.Default, "Cal_BackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::clockatt.Properties.Settings.Default, "Cal_Font", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::clockatt.Properties.Settings.Default, "Cal_ForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = global::clockatt.Properties.Settings.Default.Cal_Font;
            this.ForeColor = global::clockatt.Properties.Settings.Default.Cal_ForeColor;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CalenderForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CalenderForm";
            this.LostFocus += new System.EventHandler(this.CalenderForm_LostFocus);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CalenderForm_MouseDown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CalenderForm_KeyDown);
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.ToolTip dayToolTip;

    }
}