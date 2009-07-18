namespace clockatt.Configration
{
    partial class ConfigClockForm
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
            this.grpSampleDisplay = new System.Windows.Forms.GroupBox();
            this.labelSample = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SettingDrawFont = new clockatt.FormControls.FontSelector();
            this.SettingForeColor = new clockatt.FormControls.ColorSelector();
            this.SettingBackColor = new clockatt.FormControls.ColorSelector();
            this.SettingIsShowYear = new clockatt.FormControls.CheckBoxSelector();
            this.SettingIsShowWeek = new clockatt.FormControls.CheckBoxSelector();
            this.SettingIsShowSecond = new clockatt.FormControls.CheckBoxSelector();
            this.SettingIsShowTime = new clockatt.FormControls.CheckBoxSelector();
            this.SettingIsWeekWareki = new clockatt.FormControls.CheckBoxSelector();
            this.grpSampleDisplay.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(120, 244);
            this.btnReset.TabIndex = 11;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 244);
            this.btnOk.TabIndex = 10;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.CausesValidation = false;
            this.btnCancel.Location = new System.Drawing.Point(392, 244);
            this.btnCancel.TabIndex = 12;
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(228, 244);
            this.btnDefault.TabIndex = 11;
            // 
            // grpSampleDisplay
            // 
            this.grpSampleDisplay.BackColor = System.Drawing.Color.LightBlue;
            this.grpSampleDisplay.Controls.Add(this.labelSample);
            this.grpSampleDisplay.Location = new System.Drawing.Point(16, 160);
            this.grpSampleDisplay.Name = "grpSampleDisplay";
            this.grpSampleDisplay.Size = new System.Drawing.Size(464, 64);
            this.grpSampleDisplay.TabIndex = 9;
            this.grpSampleDisplay.TabStop = false;
            this.grpSampleDisplay.Text = "サンプル表示";
            // 
            // labelSample
            // 
            this.labelSample.AutoSize = true;
            this.labelSample.Location = new System.Drawing.Point(12, 20);
            this.labelSample.Name = "labelSample";
            this.labelSample.Size = new System.Drawing.Size(0, 12);
            this.labelSample.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "フォント名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "文字色";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "背景色";
            // 
            // SettingDrawFont
            // 
            this.SettingDrawFont.Location = new System.Drawing.Point(92, 12);
            this.SettingDrawFont.Name = "SettingDrawFont";
            this.SettingDrawFont.SettingName = "Font";
            this.SettingDrawFont.Size = new System.Drawing.Size(200, 20);
            this.SettingDrawFont.TabIndex = 1;
            // 
            // SettingForeColor
            // 
            this.SettingForeColor.Location = new System.Drawing.Point(92, 46);
            this.SettingForeColor.Name = "SettingForeColor";
            this.SettingForeColor.SettingName = "ForeColor";
            this.SettingForeColor.Size = new System.Drawing.Size(200, 20);
            this.SettingForeColor.TabIndex = 2;
            // 
            // SettingBackColor
            // 
            this.SettingBackColor.Location = new System.Drawing.Point(92, 80);
            this.SettingBackColor.Name = "SettingBackColor";
            this.SettingBackColor.SettingName = "BackColor";
            this.SettingBackColor.Size = new System.Drawing.Size(200, 20);
            this.SettingBackColor.TabIndex = 3;
            // 
            // SettingIsShowYear
            // 
            this.SettingIsShowYear.Checked = true;
            this.SettingIsShowYear.DispText = "年表示";
            this.SettingIsShowYear.Location = new System.Drawing.Point(328, 11);
            this.SettingIsShowYear.Name = "SettingIsShowYear";
            this.SettingIsShowYear.SettingName = "IsShowYear";
            this.SettingIsShowYear.Size = new System.Drawing.Size(136, 20);
            this.SettingIsShowYear.TabIndex = 4;
            // 
            // SettingIsShowWeek
            // 
            this.SettingIsShowWeek.Checked = true;
            this.SettingIsShowWeek.DispText = "曜日表示";
            this.SettingIsShowWeek.Location = new System.Drawing.Point(328, 40);
            this.SettingIsShowWeek.Name = "SettingIsShowWeek";
            this.SettingIsShowWeek.SettingName = "IsShowWeek";
            this.SettingIsShowWeek.Size = new System.Drawing.Size(136, 20);
            this.SettingIsShowWeek.TabIndex = 5;
            this.SettingIsShowWeek.ChekedChanged += new System.EventHandler(this.SettingIsShowWeek_ChekedChanged);
            // 
            // SettingIsShowSecond
            // 
            this.SettingIsShowSecond.Checked = true;
            this.SettingIsShowSecond.DispText = "秒表示";
            this.SettingIsShowSecond.Location = new System.Drawing.Point(328, 127);
            this.SettingIsShowSecond.Name = "SettingIsShowSecond";
            this.SettingIsShowSecond.SettingName = "IsShowSecond";
            this.SettingIsShowSecond.Size = new System.Drawing.Size(136, 20);
            this.SettingIsShowSecond.TabIndex = 8;
            // 
            // SettingIsShowTime
            // 
            this.SettingIsShowTime.Checked = true;
            this.SettingIsShowTime.DispText = "時間表示";
            this.SettingIsShowTime.Location = new System.Drawing.Point(328, 98);
            this.SettingIsShowTime.Name = "SettingIsShowTime";
            this.SettingIsShowTime.SettingName = "IsShowTime";
            this.SettingIsShowTime.Size = new System.Drawing.Size(136, 20);
            this.SettingIsShowTime.TabIndex = 7;
            this.SettingIsShowTime.ChekedChanged += new System.EventHandler(this.SettingIsShowTime_ChekedChanged);
            // 
            // SettingIsWeekWareki
            // 
            this.SettingIsWeekWareki.Checked = true;
            this.SettingIsWeekWareki.DispText = "曜日和暦";
            this.SettingIsWeekWareki.Location = new System.Drawing.Point(328, 69);
            this.SettingIsWeekWareki.Name = "SettingIsWeekWareki";
            this.SettingIsWeekWareki.SettingName = "IsWeekWareki";
            this.SettingIsWeekWareki.Size = new System.Drawing.Size(136, 20);
            this.SettingIsWeekWareki.TabIndex = 6;
            // 
            // ConfigClockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(499, 276);
            this.Controls.Add(this.SettingBackColor);
            this.Controls.Add(this.SettingForeColor);
            this.Controls.Add(this.SettingDrawFont);
            this.Controls.Add(this.grpSampleDisplay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SettingIsShowWeek);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SettingIsShowTime);
            this.Controls.Add(this.SettingIsWeekWareki);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SettingIsShowSecond);
            this.Controls.Add(this.SettingIsShowYear);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "ConfigClockForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ConfigClock";
            this.Load += new System.EventHandler(this.ConfigClockForm_Load);
            this.Controls.SetChildIndex(this.SettingIsShowYear, 0);
            this.Controls.SetChildIndex(this.SettingIsShowSecond, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.SettingIsWeekWareki, 0);
            this.Controls.SetChildIndex(this.SettingIsShowTime, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.SettingIsShowWeek, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.grpSampleDisplay, 0);
            this.Controls.SetChildIndex(this.btnDefault, 0);
            this.Controls.SetChildIndex(this.SettingDrawFont, 0);
            this.Controls.SetChildIndex(this.SettingForeColor, 0);
            this.Controls.SetChildIndex(this.SettingBackColor, 0);
            this.Controls.SetChildIndex(this.btnReset, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.grpSampleDisplay.ResumeLayout(false);
            this.grpSampleDisplay.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSampleDisplay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelSample;
        private clockatt.FormControls.FontSelector SettingDrawFont;
        private clockatt.FormControls.ColorSelector SettingForeColor;
        private clockatt.FormControls.ColorSelector SettingBackColor;
        private clockatt.FormControls.CheckBoxSelector SettingIsShowYear;
        private clockatt.FormControls.CheckBoxSelector SettingIsShowWeek;
        private clockatt.FormControls.CheckBoxSelector SettingIsShowSecond;
        private clockatt.FormControls.CheckBoxSelector SettingIsShowTime;
        private clockatt.FormControls.CheckBoxSelector SettingIsWeekWareki;

    }
}