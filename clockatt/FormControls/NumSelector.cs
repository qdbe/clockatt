﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace clockatt.FormControls
{
    public partial class NumSelector : ConfigSelectorBase
    {
        private int pSelectedValue;
        private const int INITIAL_FONT_SIZE = 9;

        public event EventHandler ValueChanged;

        public int SelectedValue
        {
            get { return pSelectedValue; }
            set
            {
                pSelectedValue = value;
                this.numText.Value = pSelectedValue;
                this.SetSampleProperty(this.pSelectedValue);
            }
        }

        public NumSelector()
        {
            InitializeComponent();
            this.numText.Value = INITIAL_FONT_SIZE;
            this.numText.ValueChanged += new EventHandler(numFontSize_ValueChanged);
        }

        void numFontSize_ValueChanged(object sender, EventArgs e)
        {
            this.pSelectedValue = (int)this.numText.Value;
            if (this.ValueChanged != null)
            {
                this.ValueChanged(this, e);
            }
        }

        protected override Type GetSamplePropertyType()
        {
            return typeof(int);
        }
    }
}
