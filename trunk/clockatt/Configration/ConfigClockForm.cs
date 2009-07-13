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
            this.labelSample.Font =  new Font(this.SettingDrawFont.Text.Split(",".ToCharArray())[0], Convert.ToSingle(this.SettingFontSize.Value));
            this.labelSample.ForeColor = Color.FromName(this.SettingForeColor.Text);
            this.labelSample.BackColor = Color.FromName(this.SettingBackColor.Text);

            this.labelSample.Text = TimeUtil.GetFormatDateTime(DateTime.Now,
                this.SettingIsShowYear.Checked,
                this.SettingIsShowWeek.Checked,
                this.SettingIsShowTime.Checked,
                this.SettingIsShowSecond.Checked);
        }

        private void btnFontSearch_Click(object sender, EventArgs e)
        {
            this.fontDialog1.Font = new Font(this.SettingDrawFont.Text, 10);
            this.fontDialog1.ShowColor = false;
            if (this.fontDialog1.ShowDialog(this) == DialogResult.OK)
            {
                this.SettingDrawFont.Text = this.fontDialog1.Font.Name;
            }
        }

        private void btnForeColorSearch_Click(object sender, EventArgs e)
        {
            this.colorDialog1.Color = Color.FromName(this.SettingForeColor.Text);
            if (this.colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                this.SettingForeColor.Text = this.colorDialog1.Color.Name;
            }
        }

        private void btnBackColorSearch_Click(object sender, EventArgs e)
        {
            this.colorDialog1.Color = Color.FromName(this.SettingBackColor.Text);
            if (this.colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                this.SettingBackColor.Text = this.colorDialog1.Color.Name;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren() == true)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
