using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace clockatt
{
    public partial class CalenderForm : Form
    {
        private int StartTop = 15;
        private int StartLeft = 10;

        private int DispYear;
        private int DispMonth;

        private int fontSize = 12;

        private HolidayConfigCollection[] pHolidays;

        private CalenderDrawInfo dayInfos;


        public CalenderForm(HolidayConfigCollection[] holidays)
        {
            InitializeComponent();
            DateTime dt = DateTime.Now;
            this.DispYear = dt.Year;
            this.DispMonth = dt.Month;
            this.pHolidays = holidays;
            this.dayInfos = new CalenderDrawInfo(this.pHolidays);
            dayInfos.SetRect(StartLeft, StartTop, this.DispYear, this.DispMonth, this.fontSize,
                this.CreateGraphics());
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SetClip(e.ClipRectangle);
            this.dayInfos.Draw(e.ClipRectangle, e.Graphics);
        }



        private void CalenderForm_MouseDown(object sender, MouseEventArgs e)
        {
            int limits = this.Width / 2;

            DateTime dt = new DateTime(this.DispYear, this.DispMonth, 1);
            if (e.X < limits)
            {
                dt = dt.AddMonths(-1);
            }
            else
            {
                dt = dt.AddMonths(1);
            }
            this.DispMonth = dt.Month;
            this.DispYear = dt.Year;

            dayInfos.SetRect(StartLeft, StartTop, this.DispYear, this.DispMonth, this.fontSize,
                this.CreateGraphics());

            this.Invalidate();

        }

        void CalenderForm_LostFocus(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void CalenderForm_MouseMove(object sender, MouseEventArgs e)
        {
            ChangeToolTip(e.X, e.Y);
        }

        private void ChangeToolTip(int x, int y)
        {
            this.dayToolTip.SetToolTip(this, string.Empty);
            this.dayInfos.SetToolTip(this, this.dayToolTip, x, y);
        }

    }

}
