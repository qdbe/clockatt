﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace clockatt
{
    public partial class CalenderForm : Form
    {
        public CalenderForm()
        {
            InitializeComponent();
        }

        private void CalenderForm_Load(object sender, EventArgs e)
        {
            this.monthCalendar1.TodayDate = DateTime.Now;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

    }
}