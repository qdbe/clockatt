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
        private Font pSelectedFont;

        public Font SelectedValue
        {
            get { return pSelectedFont; }
            set { 
                pSelectedFont = value;
                this.txtFontName.Text = pSelectedFont.Name;
                this.toolTip1.SetToolTip(this.txtFontName, this.txtFontName.Text);
                this.SetSampleProperty(this.pSelectedFont);
            }
        }

        public FontSelector()
        {
            InitializeComponent();
            this.SelectedValue = this.Font;
        }

        private void btnFontSearch_Click(object sender, EventArgs e)
        {
            this.fontSelectDialog.Font = this.SelectedValue;
            if (this.fontSelectDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.SelectedValue = this.fontSelectDialog.Font;
            }
        }

        protected override Type GetSamplePropertyType()
        {
            return Font.GetType();
        }
    }
}
