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

        public ConfigClockForm(ApplicationSettingsBase settings) : base(settings)
        {
            InitializeComponent();
            this.BindSettings();
            this.SettingDrawFont.SetSampleControl(this.labelSample, "Font");
            this.SettingBackColor.SetSampleControl(this.labelSample, "BackColor");
            this.SettingForeColor.SetSampleControl(this.labelSample, "ForeColor");
        }

        private void chkDispTime_CheckedChanged(object sender, EventArgs e)
        {
            this.SettingIsShowSecond.Enabled = this.SettingIsShowTime.Checked;
            if (this.SettingIsShowSecond.Enabled == false)
            {
                this.SettingIsShowSecond.Checked = false;
            }
        }

        public override void RedrawSample()
        {
            this.labelSample.Font =  new Font(this.SettingDrawFont.SelectedValue.FontFamily,
                this.SettingFontSize.SelectedValue);

            this.labelSample.Text = TimeUtil.GetFormatDateTime(DateTime.Now,
                this.SettingIsShowYear.Checked,
                this.SettingIsShowWeek.Checked,
                this.SettingIsShowTime.Checked,
                this.SettingIsShowSecond.Checked);
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren() == true)
            {
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
    }
}
