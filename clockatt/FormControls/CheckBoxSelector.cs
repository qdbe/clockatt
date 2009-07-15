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
        public bool SelectedValue
        {
            get { return this.chkBox.Checked; }
            set
            {
                System.Diagnostics.Debug.WriteLine(this.Name + "SelectedValue=" + value.ToString());
                System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(true);
                System.Diagnostics.Debug.WriteLine(st.ToString());
                this.chkBox.Checked = value;
                this.SetSampleProperty(this.chkBox.Checked);
            }
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
            get { return this.SelectedValue; }
            set {
                this.chkBox.Checked = value;
                this.SetSampleProperty(this.chkBox.Checked);
                System.Diagnostics.Debug.WriteLine(this.Name + "Checked=" + value.ToString());
                System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(true);
                System.Diagnostics.Debug.WriteLine(st.ToString());
            }
        }

        public event EventHandler ChekedChanged = null;

        public CheckBoxSelector()
        {
            InitializeComponent();
            System.Diagnostics.Debug.WriteLine(this.Name + "CheckBoxSelector");
            this.SelectedValue = true;
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
    }
}
