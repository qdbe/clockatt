using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using clockatt.FormControls;

namespace clockatt.Configration
{
    public partial class ConfigBaseForm : Form
    {
        public ConfigBaseForm()
        {
            InitializeComponent();
        }
        public ConfigBaseForm(System.Configuration.SettingsBase settings)
        {
            InitializeComponent();
            this.SettingData = settings;
        }

        protected System.Configuration.SettingsBase SettingData { get; set; }

        private void btnApply_Click(object sender, EventArgs e)
        {
            this.ApplySetting();
        }

        public virtual void ApplySetting()
        {
        }

        protected virtual void GetFromSettings()
        {
            foreach (Control con in this.Controls)
            {
                if (con is ConfigSelectorBase)
                {
                    ConfigSelectorBase selecor = (ConfigSelectorBase)con;
                    selecor.GetDataFromSettings(this.SettingData);
                }

                if (con is CheckBoxSelector)
                {
                    ((CheckBoxSelector)con).ChekedChanged += new EventHandler(ConfigBaseForm_ChekedChanged);
                }
            }
        }

        protected virtual void SetDataToSettings()
        {
            foreach (Control con in this.Controls)
            {
                if (con is ConfigSelectorBase)
                {
                    ConfigSelectorBase selecor = (ConfigSelectorBase)con;
                    selecor.SetDataToSettings(this.SettingData);
                }
            }
        }

        void ConfigBaseForm_ValueChanged(object sender, EventArgs e)
        {
            this.RedrawSample();
        }

        void ConfigBaseForm_ChekedChanged(object sender, EventArgs e)
        {
            this.RedrawSample();
        }

        public virtual void RedrawSample()
        {
        }

    }
}
