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
        private Color pSelectedColor;

        public Color SelectedValue
        {
            get { return pSelectedColor; }
            set
            {
                pSelectedColor = value;
                this.txtColorName.Text = pSelectedColor.Name;
                this.toolTip1.SetToolTip(this.txtColorName, this.txtColorName.Text);
                this.SetSampleProperty(this.pSelectedColor);
            }
        }



        public ColorSelector()
        {
            InitializeComponent();
            this.SelectedValue = this.BackColor;
        }

        private void btnColorSearch_Click(object sender, EventArgs e)
        {
            this.colorSelectDialog.Color = this.SelectedValue;
            if (this.colorSelectDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.SelectedValue = this.colorSelectDialog.Color;
            }
        }

        protected override Type GetSamplePropertyType()
        {
            return typeof(Color);
        }

   }
}
