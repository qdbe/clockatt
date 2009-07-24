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

        private CalendarConfigration dispConfig;
        private CalenderDrawInfo dayInfos;
        private CalenderDayPanel[] daypanels;

        public ConfigrationDlg()
        {
            InitializeComponent();
            this.configTabs.BackColor = this.BackColor;
        }

        public ConfigrationDlg(System.Configuration.SettingsBase settings, HolidayConfigCollection[] holidays)
            : base(settings)
        {
            InitializeComponent();
            this.GetDataFromSettings(this);
            this.ClockDrawFont.SetSampleObject(this.clockSamplelabel, "Font");
            this.ClockBackColor.SetSampleObject(this.clockSamplelabel, "BackColor");
            this.ClockForeColor.SetSampleObject(this.clockSamplelabel, "ForeColor");

            this.CalBackColor.SetSampleObject(this.calendarSamplePanel, "BackColor");
            this.dispConfig = new CalendarConfigration(settings);

            SetCalendarSamplePanel(holidays);


            this.calendarSamplePanel.Paint += new PaintEventHandler(sampleCalendarPanel_Paint);

            foreach (Control con in this.calendarTab.Controls)
            {
                if (con is ConfigSelectorBase)
                {
                    ConfigSelectorBase selector = (ConfigSelectorBase)con;
                    selector.SetSampleObject(this.dispConfig, selector.SettingName.Replace("Cal_", ""));
                    selector.SamplePropertyChenged += new EventHandler(selector_SampleCalendarPropertyChenged);
                }
            }
            this.CalBackColor.SamplePropertyChenged += new EventHandler(CalBackColor_SamplePropertyChenged);

        }

        private void SetCalendarSamplePanel(HolidayConfigCollection[] holidays)
        {
            dayInfos = new CalenderDrawInfo(holidays, this.dispConfig);
            daypanels = CalenderDayPanel.CreatePanels(this.calendarSamplePanel, CalenderDrawInfo.MaxDayCount, new MouseEventHandler(dummy_MouseDown));
            Size needSize = dayInfos.SetLocation(10, 10, DateTime.Now.Year, DateTime.Now.Month, daypanels,
                this.calendarSamplePanel.CreateGraphics());
            this.calendarSamplePanel.Width = needSize.Width;
            this.calendarSamplePanel.Height = needSize.Height;
        }

        public void dummy_MouseDown(object sender, MouseEventArgs e)
        {
        }
        
        void sampleCalendarPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SetClip(e.ClipRectangle);
            this.dayInfos.Draw(e.ClipRectangle, e.Graphics);
        }

        void CalBackColor_SamplePropertyChenged(object sender, EventArgs e)
        {
            this.calendarSamplePanel.BackColor = this.dispConfig.BackColor;
        }

        void selector_SampleCalendarPropertyChenged(object sender, EventArgs e)
        {
            Size needSize = dayInfos.SetLocation(10, 10, DateTime.Now.Year, DateTime.Now.Month, daypanels,
                this.calendarSamplePanel.CreateGraphics());
            int diffHeight = needSize.Height - this.calendarSamplePanel.Height;
            this.Height += diffHeight;
            this.calendarSamplePanel.Width = needSize.Width;
            this.calendarSamplePanel.Height = needSize.Height;
            this.Invalidate(true);
        }



        private void SettingIsShowTime_ChekedChanged(object sender, EventArgs e)
        {
            if (this.ClockIsShowTime.Checked == false)
            {
                this.ClockIsShowSecond.Checked = false;
            }
            this.ClockIsShowSecond.Enabled = this.ClockIsShowTime.Checked;
        }

        private void SettingIsShowWeek_ChekedChanged(object sender, EventArgs e)
        {
            if (this.ClockIsShowWeek.Checked == false)
            {
                this.ClockIsWeekWareki.Checked = false;
            }
            this.ClockIsWeekWareki.Enabled = this.ClockIsShowWeek.Checked;
        }


        public override void RedrawSample()
        {
            this.clockSamplelabel.Font = this.ClockDrawFont.SelectedValue;

            this.clockSamplelabel.Text = DateTimeFormatUtil.GetFormatedDateTime(DateTime.Now,
                this.ClockIsShowYear.Checked,
                this.ClockIsShowWeek.Checked,
                this.ClockIsWeekWareki.Checked,
                this.ClockIsShowTime.Checked,
                this.ClockIsShowSecond.Checked);

            this.calendarSamplePanel.Invalidate(true);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren() == true)
            {
                this.SetDataToSettings(this);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void ConfigrationDlg_Load(object sender, EventArgs e)
        {
            RedrawSample();
        }

        private void LogIsLogTitleHistory_ChekedChanged(object sender, EventArgs e)
        {
            this.LogTitleHistoryLogDir.Enabled = this.LogIsLogTitleHistory.Checked;
            this.LogTitleHistoryLogRetainDay.Enabled = this.LogIsLogTitleHistory.Checked;
        }
    }
}
