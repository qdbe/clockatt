using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace clockatt.Configration
{
    public partial class ConfigCalendarForm : ConfigBaseForm
    {
        public ConfigCalendarForm()
        {
            InitializeComponent();
        }

        public ConfigCalendarForm(System.Configuration.SettingsBase settings)
            : base(settings)
        {
            InitializeComponent();
            this.GetDataFromSettings();
            this.SettingBackColor.SetSampleControl(this.samplePanel, "BackColor");
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
