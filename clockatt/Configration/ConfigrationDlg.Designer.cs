namespace clockatt.Configration
{
    partial class ConfigrationDlg
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            clockatt.FormControls.FontSelector CalWeekFont;
            this.configTabs = new clockatt.FormControls.TabSelector();
            this.clockTab = new System.Windows.Forms.TabPage();
            this.ClockBackColor = new clockatt.FormControls.ColorSelector();
            this.ClockForeColor = new clockatt.FormControls.ColorSelector();
            this.ClockDrawFont = new clockatt.FormControls.FontSelector();
            this.grpSampleDisplay = new System.Windows.Forms.GroupBox();
            this.clockSamplelabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.ClockIsShowWeek = new clockatt.FormControls.CheckBoxSelector();
            this.label15 = new System.Windows.Forms.Label();
            this.ClockIsShowTime = new clockatt.FormControls.CheckBoxSelector();
            this.ClockIsWeekWareki = new clockatt.FormControls.CheckBoxSelector();
            this.label16 = new System.Windows.Forms.Label();
            this.ClockIsShowSecond = new clockatt.FormControls.CheckBoxSelector();
            this.ClockIsShowYear = new clockatt.FormControls.CheckBoxSelector();
            this.calendarTab = new System.Windows.Forms.TabPage();
            this.calendarSamplePanel = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CalDayTodayBackColor = new clockatt.FormControls.ColorSelector();
            this.CalDayHolidayColor = new clockatt.FormControls.ColorSelector();
            this.CalBackColor = new clockatt.FormControls.ColorSelector();
            this.label4 = new System.Windows.Forms.Label();
            this.CalYearMonthFont = new clockatt.FormControls.FontSelector();
            this.label3 = new System.Windows.Forms.Label();
            this.CalDayFont = new clockatt.FormControls.FontSelector();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.CalWeekColor = new clockatt.FormControls.ColorSelector();
            this.CalYearMonthColor = new clockatt.FormControls.ColorSelector();
            this.CalDayColor = new clockatt.FormControls.ColorSelector();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.CalWeekSaturndayColor = new clockatt.FormControls.ColorSelector();
            this.label7 = new System.Windows.Forms.Label();
            this.CalDaySaturndayColor = new clockatt.FormControls.ColorSelector();
            this.label8 = new System.Windows.Forms.Label();
            this.CalWeekSundayColor = new clockatt.FormControls.ColorSelector();
            this.CalDaySundayColor = new clockatt.FormControls.ColorSelector();
            CalWeekFont = new clockatt.FormControls.FontSelector();
            this.configTabs.SuspendLayout();
            this.clockTab.SuspendLayout();
            this.grpSampleDisplay.SuspendLayout();
            this.calendarTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(120, 454);
            this.btnReset.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 454);
            this.btnOk.TabIndex = 1;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(650, 454);
            this.btnCancel.TabIndex = 4;
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(248, 454);
            this.btnDefault.TabIndex = 3;
            // 
            // CalWeekFont
            // 
            CalWeekFont.Location = new System.Drawing.Point(127, 77);
            CalWeekFont.Name = "CalWeekFont";
            CalWeekFont.SettingName = "Cal_WeekFont";
            CalWeekFont.Size = new System.Drawing.Size(200, 20);
            CalWeekFont.TabIndex = 3;
            // 
            // configTabs
            // 
            this.configTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.configTabs.Controls.Add(this.clockTab);
            this.configTabs.Controls.Add(this.calendarTab);
            this.configTabs.Location = new System.Drawing.Point(25, 12);
            this.configTabs.Name = "configTabs";
            this.configTabs.SelectedIndex = 0;
            this.configTabs.ShowToolTips = true;
            this.configTabs.Size = new System.Drawing.Size(697, 436);
            this.configTabs.TabIndex = 0;
            // 
            // clockTab
            // 
            this.clockTab.BackColor = System.Drawing.Color.LightSteelBlue;
            this.clockTab.Controls.Add(this.ClockBackColor);
            this.clockTab.Controls.Add(this.ClockForeColor);
            this.clockTab.Controls.Add(this.ClockDrawFont);
            this.clockTab.Controls.Add(this.grpSampleDisplay);
            this.clockTab.Controls.Add(this.label14);
            this.clockTab.Controls.Add(this.ClockIsShowWeek);
            this.clockTab.Controls.Add(this.label15);
            this.clockTab.Controls.Add(this.ClockIsShowTime);
            this.clockTab.Controls.Add(this.ClockIsWeekWareki);
            this.clockTab.Controls.Add(this.label16);
            this.clockTab.Controls.Add(this.ClockIsShowSecond);
            this.clockTab.Controls.Add(this.ClockIsShowYear);
            this.clockTab.Location = new System.Drawing.Point(4, 21);
            this.clockTab.Name = "clockTab";
            this.clockTab.Padding = new System.Windows.Forms.Padding(3);
            this.clockTab.Size = new System.Drawing.Size(689, 411);
            this.clockTab.TabIndex = 0;
            this.clockTab.Text = "時計";
            // 
            // ClockBackColor
            // 
            this.ClockBackColor.Location = new System.Drawing.Point(103, 81);
            this.ClockBackColor.Name = "ClockBackColor";
            this.ClockBackColor.SettingName = "BackColor";
            this.ClockBackColor.Size = new System.Drawing.Size(200, 20);
            this.ClockBackColor.TabIndex = 2;
            // 
            // ClockForeColor
            // 
            this.ClockForeColor.Location = new System.Drawing.Point(103, 47);
            this.ClockForeColor.Name = "ClockForeColor";
            this.ClockForeColor.SettingName = "ForeColor";
            this.ClockForeColor.Size = new System.Drawing.Size(200, 20);
            this.ClockForeColor.TabIndex = 1;
            // 
            // ClockDrawFont
            // 
            this.ClockDrawFont.Location = new System.Drawing.Point(103, 13);
            this.ClockDrawFont.Name = "ClockDrawFont";
            this.ClockDrawFont.SettingName = "Font";
            this.ClockDrawFont.Size = new System.Drawing.Size(200, 20);
            this.ClockDrawFont.TabIndex = 0;
            // 
            // grpSampleDisplay
            // 
            this.grpSampleDisplay.BackColor = System.Drawing.Color.LightBlue;
            this.grpSampleDisplay.Controls.Add(this.clockSamplelabel);
            this.grpSampleDisplay.Location = new System.Drawing.Point(27, 161);
            this.grpSampleDisplay.Name = "grpSampleDisplay";
            this.grpSampleDisplay.Size = new System.Drawing.Size(464, 64);
            this.grpSampleDisplay.TabIndex = 21;
            this.grpSampleDisplay.TabStop = false;
            this.grpSampleDisplay.Text = "サンプル表示";
            // 
            // clockSamplelabel
            // 
            this.clockSamplelabel.AutoSize = true;
            this.clockSamplelabel.Location = new System.Drawing.Point(12, 20);
            this.clockSamplelabel.Name = "clockSamplelabel";
            this.clockSamplelabel.Size = new System.Drawing.Size(0, 12);
            this.clockSamplelabel.TabIndex = 4;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(52, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 12);
            this.label14.TabIndex = 16;
            this.label14.Text = "フォント名";
            // 
            // ClockIsShowWeek
            // 
            this.ClockIsShowWeek.Checked = true;
            this.ClockIsShowWeek.DispText = "曜日表示";
            this.ClockIsShowWeek.Location = new System.Drawing.Point(339, 41);
            this.ClockIsShowWeek.Name = "ClockIsShowWeek";
            this.ClockIsShowWeek.SettingName = "IsShowWeek";
            this.ClockIsShowWeek.Size = new System.Drawing.Size(136, 20);
            this.ClockIsShowWeek.TabIndex = 4;
            this.ClockIsShowWeek.ChekedChanged += new System.EventHandler(this.SettingIsShowWeek_ChekedChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(61, 51);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 18;
            this.label15.Text = "文字色";
            // 
            // ClockIsShowTime
            // 
            this.ClockIsShowTime.Checked = true;
            this.ClockIsShowTime.DispText = "時間表示";
            this.ClockIsShowTime.Location = new System.Drawing.Point(339, 99);
            this.ClockIsShowTime.Name = "ClockIsShowTime";
            this.ClockIsShowTime.SettingName = "IsShowTime";
            this.ClockIsShowTime.Size = new System.Drawing.Size(136, 20);
            this.ClockIsShowTime.TabIndex = 6;
            this.ClockIsShowTime.ChekedChanged += new System.EventHandler(this.SettingIsShowTime_ChekedChanged);
            // 
            // ClockIsWeekWareki
            // 
            this.ClockIsWeekWareki.Checked = true;
            this.ClockIsWeekWareki.DispText = "曜日和暦";
            this.ClockIsWeekWareki.Location = new System.Drawing.Point(339, 70);
            this.ClockIsWeekWareki.Name = "ClockIsWeekWareki";
            this.ClockIsWeekWareki.SettingName = "IsWeekWareki";
            this.ClockIsWeekWareki.Size = new System.Drawing.Size(136, 20);
            this.ClockIsWeekWareki.TabIndex = 5;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(61, 85);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 17;
            this.label16.Text = "背景色";
            // 
            // ClockIsShowSecond
            // 
            this.ClockIsShowSecond.Checked = true;
            this.ClockIsShowSecond.DispText = "秒表示";
            this.ClockIsShowSecond.Location = new System.Drawing.Point(339, 128);
            this.ClockIsShowSecond.Name = "ClockIsShowSecond";
            this.ClockIsShowSecond.SettingName = "IsShowSecond";
            this.ClockIsShowSecond.Size = new System.Drawing.Size(136, 20);
            this.ClockIsShowSecond.TabIndex = 7;
            // 
            // ClockIsShowYear
            // 
            this.ClockIsShowYear.Checked = true;
            this.ClockIsShowYear.DispText = "年表示";
            this.ClockIsShowYear.Location = new System.Drawing.Point(339, 12);
            this.ClockIsShowYear.Name = "ClockIsShowYear";
            this.ClockIsShowYear.SettingName = "IsShowYear";
            this.ClockIsShowYear.Size = new System.Drawing.Size(136, 20);
            this.ClockIsShowYear.TabIndex = 3;
            // 
            // calendarTab
            // 
            this.calendarTab.BackColor = System.Drawing.Color.LightSteelBlue;
            this.calendarTab.Controls.Add(this.calendarSamplePanel);
            this.calendarTab.Controls.Add(this.label13);
            this.calendarTab.Controls.Add(this.label12);
            this.calendarTab.Controls.Add(this.label1);
            this.calendarTab.Controls.Add(this.CalDayTodayBackColor);
            this.calendarTab.Controls.Add(this.CalDayHolidayColor);
            this.calendarTab.Controls.Add(this.CalBackColor);
            this.calendarTab.Controls.Add(CalWeekFont);
            this.calendarTab.Controls.Add(this.label4);
            this.calendarTab.Controls.Add(this.CalYearMonthFont);
            this.calendarTab.Controls.Add(this.label3);
            this.calendarTab.Controls.Add(this.CalDayFont);
            this.calendarTab.Controls.Add(this.label5);
            this.calendarTab.Controls.Add(this.label11);
            this.calendarTab.Controls.Add(this.label10);
            this.calendarTab.Controls.Add(this.CalWeekColor);
            this.calendarTab.Controls.Add(this.CalYearMonthColor);
            this.calendarTab.Controls.Add(this.CalDayColor);
            this.calendarTab.Controls.Add(this.label6);
            this.calendarTab.Controls.Add(this.label2);
            this.calendarTab.Controls.Add(this.label9);
            this.calendarTab.Controls.Add(this.CalWeekSaturndayColor);
            this.calendarTab.Controls.Add(this.label7);
            this.calendarTab.Controls.Add(this.CalDaySaturndayColor);
            this.calendarTab.Controls.Add(this.label8);
            this.calendarTab.Controls.Add(this.CalWeekSundayColor);
            this.calendarTab.Controls.Add(this.CalDaySundayColor);
            this.calendarTab.Location = new System.Drawing.Point(4, 21);
            this.calendarTab.Name = "calendarTab";
            this.calendarTab.Padding = new System.Windows.Forms.Padding(3);
            this.calendarTab.Size = new System.Drawing.Size(689, 411);
            this.calendarTab.TabIndex = 1;
            this.calendarTab.Text = "カレンダー";
            // 
            // calendarSamplePanel
            // 
            this.calendarSamplePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.calendarSamplePanel.Location = new System.Drawing.Point(47, 235);
            this.calendarSamplePanel.Name = "calendarSamplePanel";
            this.calendarSamplePanel.Size = new System.Drawing.Size(196, 164);
            this.calendarSamplePanel.TabIndex = 40;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(388, 195);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 28;
            this.label13.Text = "当日背景色";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(72, 195);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 25;
            this.label12.Text = "休日色";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 26;
            this.label1.Text = "背景色";
            // 
            // CalDayTodayBackColor
            // 
            this.CalDayTodayBackColor.Location = new System.Drawing.Point(469, 195);
            this.CalDayTodayBackColor.Name = "CalDayTodayBackColor";
            this.CalDayTodayBackColor.SettingName = "Cal_DayTodayBackColor";
            this.CalDayTodayBackColor.Size = new System.Drawing.Size(200, 20);
            this.CalDayTodayBackColor.TabIndex = 12;
            // 
            // CalDayHolidayColor
            // 
            this.CalDayHolidayColor.Location = new System.Drawing.Point(124, 195);
            this.CalDayHolidayColor.Name = "CalDayHolidayColor";
            this.CalDayHolidayColor.SettingName = "Cal_DayHolidayColor";
            this.CalDayHolidayColor.Size = new System.Drawing.Size(200, 20);
            this.CalDayHolidayColor.TabIndex = 11;
            // 
            // CalBackColor
            // 
            this.CalBackColor.Location = new System.Drawing.Point(127, 12);
            this.CalBackColor.Name = "CalBackColor";
            this.CalBackColor.SettingName = "Cal_BackColor";
            this.CalBackColor.Size = new System.Drawing.Size(200, 20);
            this.CalBackColor.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 12);
            this.label4.TabIndex = 31;
            this.label4.Text = "曜日 フォント";
            // 
            // CalYearMonthFont
            // 
            this.CalYearMonthFont.Location = new System.Drawing.Point(469, 12);
            this.CalYearMonthFont.Name = "CalYearMonthFont";
            this.CalYearMonthFont.SettingName = "Cal_YearMonthFont";
            this.CalYearMonthFont.Size = new System.Drawing.Size(200, 20);
            this.CalYearMonthFont.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(387, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 12);
            this.label3.TabIndex = 29;
            this.label3.Text = "年月 フォント";
            // 
            // CalDayFont
            // 
            this.CalDayFont.Location = new System.Drawing.Point(469, 77);
            this.CalDayFont.Name = "CalDayFont";
            this.CalDayFont.SettingName = "Cal_DayFont";
            this.CalDayFont.Size = new System.Drawing.Size(200, 20);
            this.CalDayFont.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "曜日 表示色";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(399, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 12);
            this.label11.TabIndex = 27;
            this.label11.Text = "日 フォント";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(396, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 12);
            this.label10.TabIndex = 23;
            this.label10.Text = "日 表示色";
            // 
            // CalWeekColor
            // 
            this.CalWeekColor.Location = new System.Drawing.Point(127, 103);
            this.CalWeekColor.Name = "CalWeekColor";
            this.CalWeekColor.SettingName = "Cal_WeekColor";
            this.CalWeekColor.Size = new System.Drawing.Size(200, 20);
            this.CalWeekColor.TabIndex = 4;
            // 
            // CalYearMonthColor
            // 
            this.CalYearMonthColor.Location = new System.Drawing.Point(469, 38);
            this.CalYearMonthColor.Name = "CalYearMonthColor";
            this.CalYearMonthColor.SettingName = "Cal_YearMonthColor";
            this.CalYearMonthColor.Size = new System.Drawing.Size(200, 20);
            this.CalYearMonthColor.TabIndex = 2;
            // 
            // CalDayColor
            // 
            this.CalDayColor.Location = new System.Drawing.Point(469, 103);
            this.CalDayColor.Name = "CalDayColor";
            this.CalDayColor.SettingName = "Cal_DayColor";
            this.CalDayColor.Size = new System.Drawing.Size(200, 20);
            this.CalDayColor.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 12);
            this.label6.TabIndex = 22;
            this.label6.Text = "曜日 土曜表示色";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(384, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "年月 表示色";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(372, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 12);
            this.label9.TabIndex = 21;
            this.label9.Text = "日 土曜表示色";
            // 
            // CalWeekSaturndayColor
            // 
            this.CalWeekSaturndayColor.Location = new System.Drawing.Point(127, 127);
            this.CalWeekSaturndayColor.Name = "CalWeekSaturndayColor";
            this.CalWeekSaturndayColor.SettingName = "Cal_WeekSaturndayColor";
            this.CalWeekSaturndayColor.Size = new System.Drawing.Size(200, 20);
            this.CalWeekSaturndayColor.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "曜日 日曜表示色";
            // 
            // CalDaySaturndayColor
            // 
            this.CalDaySaturndayColor.Location = new System.Drawing.Point(469, 127);
            this.CalDaySaturndayColor.Name = "CalDaySaturndayColor";
            this.CalDaySaturndayColor.SettingName = "Cal_DaySaturndayColor";
            this.CalDaySaturndayColor.Size = new System.Drawing.Size(200, 20);
            this.CalDaySaturndayColor.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(372, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 12);
            this.label8.TabIndex = 30;
            this.label8.Text = "日 日曜表示色";
            // 
            // CalWeekSundayColor
            // 
            this.CalWeekSundayColor.Location = new System.Drawing.Point(127, 153);
            this.CalWeekSundayColor.Name = "CalWeekSundayColor";
            this.CalWeekSundayColor.SettingName = "Cal_WeekSundayColor";
            this.CalWeekSundayColor.Size = new System.Drawing.Size(200, 20);
            this.CalWeekSundayColor.TabIndex = 6;
            // 
            // CalDaySundayColor
            // 
            this.CalDaySundayColor.Location = new System.Drawing.Point(469, 153);
            this.CalDaySundayColor.Name = "CalDaySundayColor";
            this.CalDaySundayColor.SettingName = "Cal_DaySundayColor";
            this.CalDaySundayColor.Size = new System.Drawing.Size(200, 20);
            this.CalDaySundayColor.TabIndex = 10;
            // 
            // ConfigrationDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(757, 486);
            this.Controls.Add(this.configTabs);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigrationDlg";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.ConfigrationDlg_Load);
            this.Controls.SetChildIndex(this.configTabs, 0);
            this.Controls.SetChildIndex(this.btnReset, 0);
            this.Controls.SetChildIndex(this.btnDefault, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.configTabs.ResumeLayout(false);
            this.clockTab.ResumeLayout(false);
            this.clockTab.PerformLayout();
            this.grpSampleDisplay.ResumeLayout(false);
            this.grpSampleDisplay.PerformLayout();
            this.calendarTab.ResumeLayout(false);
            this.calendarTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private clockatt.FormControls.TabSelector configTabs;
        private System.Windows.Forms.TabPage clockTab;
        private System.Windows.Forms.TabPage calendarTab;
        private System.Windows.Forms.Panel calendarSamplePanel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private clockatt.FormControls.ColorSelector CalDayTodayBackColor;
        private clockatt.FormControls.ColorSelector CalDayHolidayColor;
        private clockatt.FormControls.ColorSelector CalBackColor;
        private System.Windows.Forms.Label label4;
        private clockatt.FormControls.FontSelector CalYearMonthFont;
        private System.Windows.Forms.Label label3;
        private clockatt.FormControls.FontSelector CalDayFont;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private clockatt.FormControls.ColorSelector CalWeekColor;
        private clockatt.FormControls.ColorSelector CalYearMonthColor;
        private clockatt.FormControls.ColorSelector CalDayColor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private clockatt.FormControls.ColorSelector CalWeekSaturndayColor;
        private System.Windows.Forms.Label label7;
        private clockatt.FormControls.ColorSelector CalDaySaturndayColor;
        private System.Windows.Forms.Label label8;
        private clockatt.FormControls.ColorSelector CalWeekSundayColor;
        private clockatt.FormControls.ColorSelector CalDaySundayColor;
        private clockatt.FormControls.ColorSelector ClockBackColor;
        private clockatt.FormControls.ColorSelector ClockForeColor;
        private clockatt.FormControls.FontSelector ClockDrawFont;
        private System.Windows.Forms.GroupBox grpSampleDisplay;
        private System.Windows.Forms.Label clockSamplelabel;
        private System.Windows.Forms.Label label14;
        private clockatt.FormControls.CheckBoxSelector ClockIsShowWeek;
        private System.Windows.Forms.Label label15;
        private clockatt.FormControls.CheckBoxSelector ClockIsShowTime;
        private clockatt.FormControls.CheckBoxSelector ClockIsWeekWareki;
        private System.Windows.Forms.Label label16;
        private clockatt.FormControls.CheckBoxSelector ClockIsShowSecond;
        private clockatt.FormControls.CheckBoxSelector ClockIsShowYear;
    }
}
