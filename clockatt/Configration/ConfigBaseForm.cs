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

        protected virtual void GetDataFromSettings(Control parent)
        {
            foreach (Control con in parent.Controls)
            {
                if (con is ConfigSelectorBase)
                {
                    ConfigSelectorBase selecor = (ConfigSelectorBase)con;
                    selecor.GetDataFromSettings(this.SettingData);
                }
                else if (con.Controls.Count > 0)
                {
                    GetDataFromSettings(con);
                }

                if (con is CheckBoxSelector)
                {
                    ((CheckBoxSelector)con).SamplePropertyChanged += new EventHandler(ConfigBaseForm_ChekedChanged);
                }
            }
        }

        protected virtual void GetDefaultDataFromSettings(Control parent)
        {
            Properties.Settings defset = Properties.Settings.Default;
            defset.Reset();
            foreach (Control con in parent.Controls)
            {
                if (con is ConfigSelectorBase)
                {
                    ConfigSelectorBase selecor = (ConfigSelectorBase)con;
                    selecor.GetDataFromSettings(defset);
                }
                else if (con.Controls.Count > 0)
                {
                    GetDefaultDataFromSettings(con);
                }
            }
        }

        protected virtual void SetDataToSettings(Control parent)
        {
            foreach (Control con in parent.Controls)
            {
                if (con is ConfigSelectorBase)
                {
                    ConfigSelectorBase selecor = (ConfigSelectorBase)con;
                    selecor.SetDataToSettings(this.SettingData);
                }
                else if (con.Controls.Count > 0)
                {
                    SetDataToSettings(con);
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.GetDataFromSettings(this);
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            if( MessageBox.Show(this,"設定を既定値に戻してよろしいですか？","",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes )
            {
                this.GetDefaultDataFromSettings(this);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

    }
}
