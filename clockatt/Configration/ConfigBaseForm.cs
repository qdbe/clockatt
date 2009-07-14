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
        public ConfigBaseForm(ApplicationSettingsBase settings)
        {
            InitializeComponent();
            this.SettingData = settings;
        }

        protected ApplicationSettingsBase SettingData { get; set; }

        private void btnApply_Click(object sender, EventArgs e)
        {
            this.ApplySetting();
        }

        public virtual void ApplySetting()
        {
        }

        protected virtual void BindSettings()
        {
            foreach (SettingsProperty prop in this.SettingData.Properties)
            {
                Binding newbind = new Binding("SelectedValue", this.SettingData, prop.Name, true, DataSourceUpdateMode.OnValidation);
                Control con = this.Controls["Setting" + prop.Name];
                con.DataBindings.Add(newbind);
                if (con is CheckBoxSelector)
                {
                    ((CheckBoxSelector)con).ChekedChanged += new EventHandler(ConfigBaseForm_ChekedChanged);
                }
                else if( con is NumSelector)
                {
                    ((NumSelector)con).ValueChanged += new EventHandler(ConfigBaseForm_ValueChanged);
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
