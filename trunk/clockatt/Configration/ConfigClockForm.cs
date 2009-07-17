using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace clockatt.Configration
{
    public partial class ConfigClockForm : ConfigBaseForm
    {
        public ConfigClockForm()
        {
            InitializeComponent();
        }

        public ConfigClockForm(System.Configuration.SettingsBase settings) : base(settings)
        {
            InitializeComponent();
            this.GetDataFromSettings();
            this.SettingDrawFont.SetSampleObject(this.labelSample, "Font");
            this.SettingBackColor.SetSampleObject(this.labelSample, "BackColor");
            this.SettingForeColor.SetSampleObject(this.labelSample, "ForeColor");
        }

        public override void RedrawSample()
        {
            this.labelSample.Font =  this.SettingDrawFont.SelectedValue;

            this.labelSample.Text = TimeUtil.GetFormatDateTime(DateTime.Now,
                this.SettingIsShowYear.Checked,
                this.SettingIsShowWeek.Checked,
                this.SettingIsWeekWareki.Checked,
                this.SettingIsShowTime.Checked,
                this.SettingIsShowSecond.Checked);
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

        private void SettingIsShowTime_ChekedChanged(object sender, EventArgs e)
        {
            if (this.SettingIsShowTime.Checked == false)
            {
                this.SettingIsShowSecond.Checked = false;
            }
            this.SettingIsShowSecond.Enabled = this.SettingIsShowTime.Checked;
        }

        private void SettingIsShowWeek_ChekedChanged(object sender, EventArgs e)
        {
            if (this.SettingIsShowWeek.Checked == false)
            {
                this.SettingIsWeekWareki.Checked = false;
            }
            this.SettingIsWeekWareki.Enabled = this.SettingIsShowWeek.Checked;
        }

        private void ConfigClockForm_Load(object sender, EventArgs e)
        {
            RedrawSample();
        }
    }
}
