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
    public partial class ConfigCalendarForm : ConfigBaseForm
    {
        private CalendarConfigration dispConfig;
        private CalenderDrawInfo dayInfos;
        private CalenderDayPanel[] daypanels;

        public ConfigCalendarForm()
        {
            InitializeComponent();
        }

        public ConfigCalendarForm(System.Configuration.SettingsBase settings, HolidayConfigCollection[] holidays)
            : base(settings)
        {
            InitializeComponent();
            this.GetDataFromSettings(this);
            this.SettingBackColor.SetSampleObject(this.samplePanel, "BackColor");
            this.dispConfig = new CalendarConfigration(settings);

            SetSamplePanel(holidays);

            this.samplePanel.Paint += new PaintEventHandler(samplePanel_Paint);

            foreach (Control con in this.Controls)
            {
                if (con is ConfigSelectorBase)
                {
                    ConfigSelectorBase selector = (ConfigSelectorBase)con;
                    selector.SetSampleObject(this.dispConfig,selector.SettingName.Replace("Cal_",""));
                    selector.SamplePropertyChenged += new EventHandler(selector_SamplePropertyChenged);
                }
            }
            this.SettingBackColor.SamplePropertyChenged += new EventHandler(SettingBackColor_SamplePropertyChenged);
        }

        void SettingBackColor_SamplePropertyChenged(object sender, EventArgs e)
        {
            this.samplePanel.BackColor = this.dispConfig.BackColor;
        }

        void selector_SamplePropertyChenged(object sender, EventArgs e)
        {
            Size needSize = dayInfos.SetLocation(10, 10, DateTime.Now.Year, DateTime.Now.Month, daypanels,
                this.samplePanel.CreateGraphics());
            int diffHeight = needSize.Height - this.samplePanel.Height;
            this.Height += diffHeight;
            this.samplePanel.Width = needSize.Width;
            this.samplePanel.Height = needSize.Height;
            this.Invalidate(true);
        }

        void samplePanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SetClip(e.ClipRectangle);
            this.dayInfos.Draw(e.ClipRectangle, e.Graphics);
        }

        private void SetSamplePanel(HolidayConfigCollection[] holidays)
        {
            dayInfos = new CalenderDrawInfo(holidays, this.dispConfig);
            daypanels = CalenderDayPanel.CreatePanels(this.samplePanel, CalenderDrawInfo.MaxDayCount, new MouseEventHandler(dummy_MouseDown));
            Size needSize = dayInfos.SetLocation(10, 10, DateTime.Now.Year, DateTime.Now.Month, daypanels,
                this.samplePanel.CreateGraphics() );
            this.samplePanel.Width = needSize.Width;
            this.samplePanel.Height = needSize.Height;
        }

        public void dummy_MouseDown(object sender, MouseEventArgs e)
        {
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

        public override void RedrawSample()
        {
            this.samplePanel.Invalidate(true);
        }

    }
}
