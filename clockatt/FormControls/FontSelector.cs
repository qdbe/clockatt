using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace clockatt.FormControls
{
    public partial class FontSelector : ConfigSelectorBase
    {
        public Font SelectedValue
        {
            get { return (Font)this.pSelectedValue; }
        }

        public FontSelector()
        {
            InitializeComponent();
            this.SetValue(this.Font);
        }

        public override void SetValue(object value)
        {
            if (!(value is Font))
            {
                throw new ArgumentException(value.GetType().Name + "は引数にセットできません");
            }
            pSelectedValue = value;
            this.txtFontName.Text = ((Font)pSelectedValue).Name + ", " + ((Font)pSelectedValue).SizeInPoints.ToString() + "Point";
            this.toolTip1.SetToolTip(this.txtFontName, this.txtFontName.Text);
            this.SetSampleProperty(this.pSelectedValue);
        }


        private void btnFontSearch_Click(object sender, EventArgs e)
        {
            this.fontSelectDialog.Font = (Font)this.pSelectedValue;
            if (this.fontSelectDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.SetValue(this.fontSelectDialog.Font);
            }
        }

        protected override Type GetSamplePropertyType()
        {
            return Font.GetType();
        }
    }
}
