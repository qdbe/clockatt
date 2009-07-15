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
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.grpSampleDisplay = new System.Windows.Forms.GroupBox();
            this.labelSample = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.SettingFontSize = new clockatt.FormControls.NumSelector();
            this.SettingDrawFont = new clockatt.FormControls.FontSelector();
            this.SettingForeColor = new clockatt.FormControls.ColorSelector();
            this.SettingBackColor = new clockatt.FormControls.ColorSelector();
            this.SettingIsShowYear = new clockatt.FormControls.CheckBoxSelector();
            this.SettingIsShowWeek = new clockatt.FormControls.CheckBoxSelector();
            this.SettingIsShowSecond = new clockatt.FormControls.CheckBoxSelector();
            this.SettingIsShowTime = new clockatt.FormControls.CheckBoxSelector();
            this.grpSampleDisplay.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnApply.Location = new System.Drawing.Point(120, 233);
            this.btnApply.Visible = false;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.Location = new System.Drawing.Point(12, 233);
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.CausesValidation = false;
            this.btnCancel.Location = new System.Drawing.Point(392, 233);
            // 
            // grpSampleDisplay
            // 
            this.grpSampleDisplay.BackColor = System.Drawing.Color.LightBlue;
            this.grpSampleDisplay.Controls.Add(this.labelSample);
            this.grpSampleDisplay.Location = new System.Drawing.Point(16, 156);
            this.grpSampleDisplay.Name = "grpSampleDisplay";
            this.grpSampleDisplay.Size = new System.Drawing.Size(464, 64);
            this.grpSampleDisplay.TabIndex = 5;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "フォントサイズ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "フォント名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "文字色";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "背景色";
            // 
            // SettingFontSize
            // 
            this.SettingFontSize.Location = new System.Drawing.Point(100, 20);
            this.SettingFontSize.Name = "SettingFontSize";
            this.SettingFontSize.SelectedValue = 0;
            this.SettingFontSize.Size = new System.Drawing.Size(200, 20);
            this.SettingFontSize.TabIndex = 9;
            // 
            // SettingDrawFont
            // 
            this.SettingDrawFont.Location = new System.Drawing.Point(100, 54);
            this.SettingDrawFont.Name = "SettingDrawFont";
            this.SettingDrawFont.SelectedValue = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SettingDrawFont.Size = new System.Drawing.Size(200, 20);
            this.SettingDrawFont.TabIndex = 10;
            // 
            // SettingForeColor
            // 
            this.SettingForeColor.Location = new System.Drawing.Point(100, 88);
            this.SettingForeColor.Name = "SettingForeColor";
            this.SettingForeColor.SelectedValue = System.Drawing.SystemColors.Control;
            this.SettingForeColor.Size = new System.Drawing.Size(200, 20);
            this.SettingForeColor.TabIndex = 11;
            // 
            // SettingBackColor
            // 
            this.SettingBackColor.Location = new System.Drawing.Point(100, 122);
            this.SettingBackColor.Name = "SettingBackColor";
            this.SettingBackColor.SelectedValue = System.Drawing.SystemColors.Control;
            this.SettingBackColor.Size = new System.Drawing.Size(200, 20);
            this.SettingBackColor.TabIndex = 12;
            // 
            // SettingIsShowYear
            // 
            this.SettingIsShowYear.Checked = true;
            this.SettingIsShowYear.DispText = "年表示";
            this.SettingIsShowYear.Location = new System.Drawing.Point(328, 24);
            this.SettingIsShowYear.Name = "SettingIsShowYear";
            this.SettingIsShowYear.SelectedValue = true;
            this.SettingIsShowYear.Size = new System.Drawing.Size(136, 20);
            this.SettingIsShowYear.TabIndex = 13;
            // 
            // SettingIsShowWeek
            // 
            this.SettingIsShowWeek.Checked = true;
            this.SettingIsShowWeek.DispText = "曜日表示";
            this.SettingIsShowWeek.Location = new System.Drawing.Point(328, 53);
            this.SettingIsShowWeek.Name = "SettingIsShowWeek";
            this.SettingIsShowWeek.SelectedValue = true;
            this.SettingIsShowWeek.Size = new System.Drawing.Size(136, 20);
            this.SettingIsShowWeek.TabIndex = 13;
            // 
            // SettingIsShowSecond
            // 
            this.SettingIsShowSecond.Checked = true;
            this.SettingIsShowSecond.DispText = "秒表示";
            this.SettingIsShowSecond.Location = new System.Drawing.Point(328, 120);
            this.SettingIsShowSecond.Name = "SettingIsShowSecond";
            this.SettingIsShowSecond.SelectedValue = true;
            this.SettingIsShowSecond.Size = new System.Drawing.Size(136, 20);
            this.SettingIsShowSecond.TabIndex = 13;
            // 
            // SettingIsShowTime
            // 
            this.SettingIsShowTime.Checked = true;
            this.SettingIsShowTime.DispText = "時間表示";
            this.SettingIsShowTime.Location = new System.Drawing.Point(328, 86);
            this.SettingIsShowTime.Name = "SettingIsShowTime";
            this.SettingIsShowTime.SelectedValue = true;
            this.SettingIsShowTime.Size = new System.Drawing.Size(136, 20);
            this.SettingIsShowTime.TabIndex = 13;
            this.SettingIsShowTime.ChekedChanged += new System.EventHandler(this.SettingIsShowTime_ChekedChanged);
            // 
            // ConfigClockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(499, 265);
            this.Controls.Add(this.SettingBackColor);
            this.Controls.Add(this.SettingForeColor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SettingDrawFont);
            this.Controls.Add(this.SettingFontSize);
            this.Controls.Add(this.grpSampleDisplay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SettingIsShowWeek);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SettingIsShowTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SettingIsShowSecond);
            this.Controls.Add(this.SettingIsShowYear);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "ConfigClockForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ConfigClock";
            this.Controls.SetChildIndex(this.SettingIsShowYear, 0);
            this.Controls.SetChildIndex(this.SettingIsShowSecond, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.SettingIsShowTime, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.SettingIsShowWeek, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.grpSampleDisplay, 0);
            this.Controls.SetChildIndex(this.SettingFontSize, 0);
            this.Controls.SetChildIndex(this.SettingDrawFont, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.SettingForeColor, 0);
            this.Controls.SetChildIndex(this.SettingBackColor, 0);
            this.Controls.SetChildIndex(this.btnApply, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.grpSampleDisplay.ResumeLayout(false);
            this.grpSampleDisplay.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.GroupBox grpSampleDisplay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelSample;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private clockatt.FormControls.NumSelector SettingFontSize;
        private clockatt.FormControls.FontSelector SettingDrawFont;
        private clockatt.FormControls.ColorSelector SettingForeColor;
        private clockatt.FormControls.ColorSelector SettingBackColor;
        private clockatt.FormControls.CheckBoxSelector SettingIsShowYear;
        private clockatt.FormControls.CheckBoxSelector SettingIsShowWeek;
        private clockatt.FormControls.CheckBoxSelector SettingIsShowSecond;
        private clockatt.FormControls.CheckBoxSelector SettingIsShowTime;

    }
}