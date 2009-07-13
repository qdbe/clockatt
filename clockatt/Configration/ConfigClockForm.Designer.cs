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
            this.SettingDrawFont = new System.Windows.Forms.TextBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.grpSampleDisplay = new System.Windows.Forms.GroupBox();
            this.labelSample = new System.Windows.Forms.Label();
            this.SettingFontSize = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SettingIsShowYear = new System.Windows.Forms.CheckBox();
            this.SettingIsShowWeek = new System.Windows.Forms.CheckBox();
            this.SettingIsShowTime = new System.Windows.Forms.CheckBox();
            this.SettingIsShowSecond = new System.Windows.Forms.CheckBox();
            this.SettingForeColor = new System.Windows.Forms.TextBox();
            this.SettingBackColor = new System.Windows.Forms.TextBox();
            this.btnFontSearch = new System.Windows.Forms.Button();
            this.btnForeColorSearch = new System.Windows.Forms.Button();
            this.btnBackColorSearch = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.grpSampleDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SettingFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            // 
            // SettingDrawFont
            // 
            this.SettingDrawFont.Location = new System.Drawing.Point(116, 56);
            this.SettingDrawFont.Name = "SettingDrawFont";
            this.SettingDrawFont.ReadOnly = true;
            this.SettingDrawFont.Size = new System.Drawing.Size(100, 19);
            this.SettingDrawFont.TabIndex = 3;
            // 
            // grpSampleDisplay
            // 
            this.grpSampleDisplay.Controls.Add(this.labelSample);
            this.grpSampleDisplay.Location = new System.Drawing.Point(52, 204);
            this.grpSampleDisplay.Name = "grpSampleDisplay";
            this.grpSampleDisplay.Size = new System.Drawing.Size(260, 64);
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
            // SettingFontSize
            // 
            this.SettingFontSize.Location = new System.Drawing.Point(116, 20);
            this.SettingFontSize.Name = "SettingFontSize";
            this.SettingFontSize.Size = new System.Drawing.Size(120, 19);
            this.SettingFontSize.TabIndex = 6;
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
            this.label2.Location = new System.Drawing.Point(32, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "フォント名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "文字色";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "背景色";
            // 
            // SettingIsShowYear
            // 
            this.SettingIsShowYear.AutoSize = true;
            this.SettingIsShowYear.Location = new System.Drawing.Point(332, 28);
            this.SettingIsShowYear.Name = "SettingIsShowYear";
            this.SettingIsShowYear.Size = new System.Drawing.Size(60, 16);
            this.SettingIsShowYear.TabIndex = 8;
            this.SettingIsShowYear.Text = "年表示";
            this.SettingIsShowYear.UseVisualStyleBackColor = true;
            // 
            // SettingIsShowWeek
            // 
            this.SettingIsShowWeek.AutoSize = true;
            this.SettingIsShowWeek.Location = new System.Drawing.Point(332, 56);
            this.SettingIsShowWeek.Name = "SettingIsShowWeek";
            this.SettingIsShowWeek.Size = new System.Drawing.Size(72, 16);
            this.SettingIsShowWeek.TabIndex = 8;
            this.SettingIsShowWeek.Text = "曜日表示";
            this.SettingIsShowWeek.UseVisualStyleBackColor = true;
            // 
            // SettingIsShowTime
            // 
            this.SettingIsShowTime.AutoSize = true;
            this.SettingIsShowTime.Location = new System.Drawing.Point(332, 84);
            this.SettingIsShowTime.Name = "SettingIsShowTime";
            this.SettingIsShowTime.Size = new System.Drawing.Size(72, 16);
            this.SettingIsShowTime.TabIndex = 8;
            this.SettingIsShowTime.Text = "時刻表示";
            this.SettingIsShowTime.UseVisualStyleBackColor = true;
            this.SettingIsShowTime.CheckedChanged += new System.EventHandler(this.chkDispTime_CheckedChanged);
            // 
            // SettingIsShowSecond
            // 
            this.SettingIsShowSecond.AutoSize = true;
            this.SettingIsShowSecond.Location = new System.Drawing.Point(332, 116);
            this.SettingIsShowSecond.Name = "SettingIsShowSecond";
            this.SettingIsShowSecond.Size = new System.Drawing.Size(60, 16);
            this.SettingIsShowSecond.TabIndex = 8;
            this.SettingIsShowSecond.Text = "秒表示";
            this.SettingIsShowSecond.UseVisualStyleBackColor = true;
            // 
            // SettingForeColor
            // 
            this.SettingForeColor.Location = new System.Drawing.Point(116, 88);
            this.SettingForeColor.Name = "SettingForeColor";
            this.SettingForeColor.ReadOnly = true;
            this.SettingForeColor.Size = new System.Drawing.Size(100, 19);
            this.SettingForeColor.TabIndex = 3;
            // 
            // SettingBackColor
            // 
            this.SettingBackColor.Location = new System.Drawing.Point(116, 120);
            this.SettingBackColor.Name = "SettingBackColor";
            this.SettingBackColor.ReadOnly = true;
            this.SettingBackColor.Size = new System.Drawing.Size(100, 19);
            this.SettingBackColor.TabIndex = 3;
            // 
            // btnFontSearch
            // 
            this.btnFontSearch.Location = new System.Drawing.Point(224, 56);
            this.btnFontSearch.Name = "btnFontSearch";
            this.btnFontSearch.Size = new System.Drawing.Size(75, 23);
            this.btnFontSearch.TabIndex = 9;
            this.btnFontSearch.Text = "フォント名";
            this.btnFontSearch.UseVisualStyleBackColor = true;
            this.btnFontSearch.Click += new System.EventHandler(this.btnFontSearch_Click);
            // 
            // btnForeColorSearch
            // 
            this.btnForeColorSearch.Location = new System.Drawing.Point(224, 88);
            this.btnForeColorSearch.Name = "btnForeColorSearch";
            this.btnForeColorSearch.Size = new System.Drawing.Size(75, 23);
            this.btnForeColorSearch.TabIndex = 9;
            this.btnForeColorSearch.Text = "前景色";
            this.btnForeColorSearch.UseVisualStyleBackColor = true;
            this.btnForeColorSearch.Click += new System.EventHandler(this.btnForeColorSearch_Click);
            // 
            // btnBackColorSearch
            // 
            this.btnBackColorSearch.Location = new System.Drawing.Point(224, 120);
            this.btnBackColorSearch.Name = "btnBackColorSearch";
            this.btnBackColorSearch.Size = new System.Drawing.Size(75, 23);
            this.btnBackColorSearch.TabIndex = 9;
            this.btnBackColorSearch.Text = "背景色";
            this.btnBackColorSearch.UseVisualStyleBackColor = true;
            this.btnBackColorSearch.Click += new System.EventHandler(this.btnBackColorSearch_Click);
            // 
            // ConfigClockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 312);
            this.Controls.Add(this.grpSampleDisplay);
            this.Controls.Add(this.SettingFontSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFontSearch);
            this.Controls.Add(this.SettingIsShowYear);
            this.Controls.Add(this.SettingDrawFont);
            this.Controls.Add(this.btnForeColorSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SettingIsShowWeek);
            this.Controls.Add(this.btnBackColorSearch);
            this.Controls.Add(this.SettingForeColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SettingBackColor);
            this.Controls.Add(this.SettingIsShowTime);
            this.Controls.Add(this.SettingIsShowSecond);
            this.Name = "ConfigClockForm";
            this.Text = "ConfigClock";
            this.Controls.SetChildIndex(this.SettingIsShowSecond, 0);
            this.Controls.SetChildIndex(this.SettingIsShowTime, 0);
            this.Controls.SetChildIndex(this.SettingBackColor, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.SettingForeColor, 0);
            this.Controls.SetChildIndex(this.btnBackColorSearch, 0);
            this.Controls.SetChildIndex(this.SettingIsShowWeek, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnForeColorSearch, 0);
            this.Controls.SetChildIndex(this.SettingDrawFont, 0);
            this.Controls.SetChildIndex(this.SettingIsShowYear, 0);
            this.Controls.SetChildIndex(this.btnFontSearch, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.SettingFontSize, 0);
            this.Controls.SetChildIndex(this.grpSampleDisplay, 0);
            this.Controls.SetChildIndex(this.btnApply, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.grpSampleDisplay.ResumeLayout(false);
            this.grpSampleDisplay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SettingFontSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SettingDrawFont;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.GroupBox grpSampleDisplay;
        private System.Windows.Forms.NumericUpDown SettingFontSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox SettingIsShowYear;
        private System.Windows.Forms.CheckBox SettingIsShowWeek;
        private System.Windows.Forms.CheckBox SettingIsShowTime;
        private System.Windows.Forms.CheckBox SettingIsShowSecond;
        private System.Windows.Forms.TextBox SettingForeColor;
        private System.Windows.Forms.TextBox SettingBackColor;
        private System.Windows.Forms.Label labelSample;
        private System.Windows.Forms.Button btnFontSearch;
        private System.Windows.Forms.Button btnForeColorSearch;
        private System.Windows.Forms.Button btnBackColorSearch;
        private System.Windows.Forms.ColorDialog colorDialog1;

    }
}