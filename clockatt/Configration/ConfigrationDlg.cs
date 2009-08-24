using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using clockatt.FormControls;


namespace clockatt.Configration
{
    public partial class ConfigrationDlg : clockatt.Configration.ConfigBaseForm
    {
        /// <summary>
        /// カレンダーの表示設定
        /// </summary>
        private CalendarConfigration dispConfig;

        /// <summary>
        /// デザイン用コンストラクタ
        /// </summary>
        public ConfigrationDlg()
        {
            if (this.DesignMode != true)
            {
                throw new ApplicationException("実行時の初期化には利用できません");
            }
            InitializeComponent();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="holidays"></param>
        public ConfigrationDlg(System.Configuration.SettingsBase settings, HolidayConfigCollection[] holidays)
            : base(settings)
        {
            InitializeComponent();

            this.GetDataFromSettings(this);

            SetClockSampleDisplay();


            SetCalendarSamplePanel(holidays);

            SetCalendarSampleDisplay();

        }

        /// <summary>
        /// 時計表示のサンプル連動設定
        /// </summary>
        private void SetClockSampleDisplay()
        {
            this.ClockDrawFont.SetSampleObject(this.clockSamplelabel, "Font");
            this.ClockBackColor.SetSampleObject(this.clockSamplelabel, "BackColor");
            this.ClockForeColor.SetSampleObject(this.clockSamplelabel, "ForeColor");
        }

        /// <summary>
        /// カレンダー表示のサンプル連動設定
        /// </summary>
        private void SetCalendarSampleDisplay()
        {
            foreach (Control con in this.calendarTab.Controls)
            {
                if (con is ConfigSelectorBase)
                {
                    ConfigSelectorBase selector = (ConfigSelectorBase)con;
                    selector.SetSampleObject(this.dispConfig, selector.SettingName.Replace("Cal_", ""));
                    selector.SamplePropertyChanged += new EventHandler(selector_SampleCalendarPropertyChanged);
                }
            }
            // 背景色はパネル自体の色も変更する必要がある為、追加で設定
            this.CalBackColor.SamplePropertyChanged += new EventHandler(CalBackColor_SamplePropertyChanged);
        }

        /// <summary>
        /// カレンダー表示のパネルの初期化
        /// </summary>
        /// <param name="holidays"></param>
        private void SetCalendarSamplePanel(HolidayConfigCollection[] holidays)
        {
            this.CalBackColor.SetSampleObject(this.calendarSamplePanel, "BackColor");

            this.dispConfig = new CalendarConfigration(this.SettingData);

            this.calendarSamplePanel.Initialize(this, holidays, this.dispConfig);

            this.calendarSamplePanel.PanelSizeChanged += new SizeChangedEventHandler(calendarSamplePanel_PanelSizeChanged);
        }

        void calendarSamplePanel_PanelSizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Size = Size.Add(this.Size, e.DiffSize);
        }

        /// <summary>
        /// 背景色はパネル自体の色も変更する必要がある
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CalBackColor_SamplePropertyChanged(object sender, EventArgs e)
        {
            this.calendarSamplePanel.BackColor = this.dispConfig.BackColor;
        }


        /// <summary>
        /// サンプル連動設定変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void selector_SampleCalendarPropertyChanged(object sender, EventArgs e)
        {
            this.Invalidate(true);
        }


        /// <summary>
        /// 時刻描画変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingIsShowTime_ChekedChanged(object sender, EventArgs e)
        {
            if (this.ClockIsShowTime.Checked == false)
            {
                this.ClockIsShowSecond.Checked = false;
            }
            this.ClockIsShowSecond.Enabled = this.ClockIsShowTime.Checked;
        }

        /// <summary>
        /// 曜日描画変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingIsShowWeek_ChekedChanged(object sender, EventArgs e)
        {
            if (this.ClockIsShowWeek.Checked == false)
            {
                this.ClockIsWeekWareki.Checked = false;
            }
            this.ClockIsWeekWareki.Enabled = this.ClockIsShowWeek.Checked;
        }


        /// <summary>
        /// 時刻の再描画を行う
        /// </summary>
        public override void RedrawSample()
        {
            this.clockSamplelabel.Text = DateTimeFormatUtil.GetFormatedDateTime(DateTime.Now,
                this.ClockIsShowYear.Checked,
                this.ClockIsShowWeek.Checked,
                this.ClockIsWeekWareki.Checked,
                this.ClockIsShowTime.Checked,
                this.ClockIsShowSecond.Checked);

            this.calendarSamplePanel.Invalidate(true);
        }

        /// <summary>
        /// 決定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren() == true)
            {
                this.SetDataToSettings(this);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// 時刻表示の初期化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfigrationDlg_Load(object sender, EventArgs e)
        {
            RedrawSample();
        }

        /// <summary>
        /// タイトル履歴の取得変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogIsLogTitleHistory_ChekedChanged(object sender, EventArgs e)
        {
            this.LogTitleHistoryLogDir.Enabled = this.LogIsLogTitleHistory.Checked;
            this.LogTitleHistoryLogRetainDay.Enabled = this.LogIsLogTitleHistory.Checked;
        }
    }
}
