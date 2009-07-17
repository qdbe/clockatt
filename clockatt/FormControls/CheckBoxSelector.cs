using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace clockatt.FormControls
{
    public partial class CheckBoxSelector : ConfigSelectorBase
    {
        public override void SetValue(object value)
        {
            if (!(value is bool))
            {
                throw new ArgumentException(value.GetType().Name + "は引数にセットできません");
            }

            this.chkBox.Checked = (bool)value;
        }

        public string DispText
        {
            get
            {
                return this.chkBox.Text;
            }
            set
            {
                this.chkBox.Text = value;
            }
        }

        public bool Checked
        {
            get { return this.chkBox.Checked; }
            set {
                this.SetValue(value);
            }
        }

        public event EventHandler ChekedChanged = null;

        public CheckBoxSelector()
        {
            InitializeComponent();
            this.SetValue(true);
            this.chkBox.CheckedChanged += new EventHandler(chkBox_CheckedChanged);
        }

        void chkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ChekedChanged != null)
            {
                this.ChekedChanged(this, e);
            }
        }

        protected override Type GetSamplePropertyType()
        {
            return typeof(bool);
        }

        public override void SetDataToSettings(System.Configuration.SettingsBase setting)
        {
            setting.PropertyValues[this.SettingName].PropertyValue = this.chkBox.Checked;
        }
    }
}
