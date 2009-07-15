using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace clockatt.FormControls
{
    public partial class ColorSelector : ConfigSelectorBase
    {
        public override void SetValue(object value)
        {
            if (!(value is Color))
            {
                throw new ArgumentException(value.GetType().Name + "は引数にセットできません");
            }
            pSelectedValue = value;
            this.txtColorName.Text = ((Color)value).Name;
            this.toolTip1.SetToolTip(this.txtColorName, this.txtColorName.Text);
            this.SetSampleProperty(this.pSelectedValue);
        }


        public ColorSelector()
        {
            InitializeComponent();
            this.SetValue(this.BackColor);
        }

        private void btnColorSearch_Click(object sender, EventArgs e)
        {
            this.colorSelectDialog.Color = (Color)this.pSelectedValue;
            if (this.colorSelectDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.SetValue(this.colorSelectDialog.Color);
            }
        }

        protected override Type GetSamplePropertyType()
        {
            return typeof(Color);
        }

   }
}
