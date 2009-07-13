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
                if (this.Controls["Setting" + prop.Name] is NumericUpDown )
                {
                    ((NumericUpDown)this.Controls["Setting" + prop.Name]).ValueChanged += new EventHandler(ConfigBaseForm_ValueChanged);
                    Binding newbind = new Binding("Value", this.SettingData, prop.Name, true, DataSourceUpdateMode.OnValidation);
                    this.Controls["Setting" + prop.Name].DataBindings.Add(newbind);
                }
                if (this.Controls["Setting" + prop.Name] is TextBox)
                {
                    ((TextBox)this.Controls["Setting" + prop.Name]).TextChanged += new EventHandler(ConfigBaseForm_TextChanged);
                    Binding newbind = new Binding("Text", this.SettingData, prop.Name, true, DataSourceUpdateMode.OnValidation);
                    this.Controls["Setting" + prop.Name].DataBindings.Add(newbind);
                }

                if (this.Controls["Setting" + prop.Name] is CheckBox)
                {
                    ((CheckBox)this.Controls["Setting" + prop.Name]).CheckedChanged += new EventHandler(ConfigBaseForm_CheckedChanged);
                    Binding newbind = new Binding("Checked", this.SettingData, prop.Name, true, DataSourceUpdateMode.OnValidation);
                    this.Controls["Setting" + prop.Name].DataBindings.Add(newbind);
                }
            }
        }

        void ConfigBaseForm_ValueChanged(object sender, EventArgs e)
        {
            this.RedrawSample();
        }

        public virtual void RedrawSample()
        {
        }

        void ConfigBaseForm_CheckedChanged(object sender, EventArgs e)
        {
            this.RedrawSample();
        }

        void ConfigBaseForm_TextChanged(object sender, EventArgs e)
        {
            this.RedrawSample();
        }
    }
}
