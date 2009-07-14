using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace clockatt.FormControls
{
    public partial class FontSelector : UserControl
    {
        private Font pSelectedFont;

        public Font SelectedFont
        {
            get { return pSelectedFont; }
            set { 
                pSelectedFont = value;
                this.txtFontName.Text = pSelectedFont.Name;
                this.toolTip1.SetToolTip(this.txtFontName, this.txtFontName.Text);
            }
        }

        private Control pSampleControl;
        public Control SampleControl
        {
            get { return pSampleControl; }
        }

        private string pSampleProperty;
        public string SampleProperty
        {
            get { return pSampleProperty; }
        }


        public FontSelector()
        {
            InitializeComponent();
            this.SelectedFont = this.Font;
        }

        private void btnFontSearch_Click(object sender, EventArgs e)
        {
            this.fontSelectDialog.Font = this.SelectedFont;
            if (this.fontSelectDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.SelectedFont = this.fontSelectDialog.Font;
            }
        }

        public void SetSampleControl(Control target, string targetProperty)
        {
            this.pSampleControl = target;
            this.pSampleProperty = targetProperty;
        }
    }
}
