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

        public ConfigCalendarForm()
        {
            InitializeComponent();
        }

        public ConfigCalendarForm(System.Configuration.SettingsBase settings, HolidayConfigCollection[] holidays)
            : base(settings)
        {
            InitializeComponent();
            this.GetDataFromSettings();
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
            this.samplePanel.Invalidate();
        }

        void samplePanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SetClip(e.ClipRectangle);
            this.dayInfos.Draw(e.ClipRectangle, e.Graphics);
        }

        private void SetSamplePanel(HolidayConfigCollection[] holidays)
        {
            dayInfos = new CalenderDrawInfo(holidays, this.dispConfig);
            CalenderDayPanel[] daypanels = CalenderDayPanel.CreatePanels(this.samplePanel, new CalenderDayPanel.DayPanelMouseDownEnventHandler(dummy_MouseDown));
            Size needSize = dayInfos.SetRect(10, 10, DateTime.Now.Year, DateTime.Now.Month, daypanels,
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
                this.SetDataToSettings();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        public override void RedrawSample()
        {
            this.samplePanel.Invalidate();
        }

    }
}
