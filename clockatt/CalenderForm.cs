using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using clockatt.Configration;

namespace clockatt
{
    public partial class CalenderForm : Form
    {
        private int StartTop = 5;
        private int StartLeft = 10;

        private int DispYear;
        private int DispMonth;

        private Form callerForm;

        private int fontSize = 12;

        private HolidayConfigCollection[] pHolidays;

        private CalenderDrawInfo dayInfos;

        private CalenderDayPanel []dayPanes;

        private CalendarConfigration Config { get; set; }


        public CalenderForm(Form parent, HolidayConfigCollection[] holidays, CalendarConfigration config)
        {
            this.callerForm = parent;
            this.Config = config;
            InitializeComponent();
            DateTime dt = DateTime.Now;
            this.DispYear = dt.Year;
            this.DispMonth = dt.Month;
            this.pHolidays = holidays;
            this.dayInfos = new CalenderDrawInfo(this.pHolidays, this.Config);
            this.dayPanes = CalenderDayPanel.CreatePanels(this, new CalenderDayPanel.DayPanelMouseDownEnventHandler(DoMouseClick));
            Size needSize = dayInfos.SetRect(StartLeft, StartTop, this.DispYear, this.DispMonth, this.fontSize,
                dayPanes,
                this.CreateGraphics());
            this.Size = needSize;
            ResetPos(needSize);

            this.Invalidate(true);
        }

        private void ResetPos(Size needSize)
        {
            // 親の右端から
            Point newpos = this.callerForm.Location;
            newpos.X += this.callerForm.Width;
            newpos.Y += this.callerForm.Height;

            newpos.X -= needSize.Width;
            if (newpos.X <= 0)
            {
                newpos.X = 0;
            }
            if (newpos.X + needSize.Width > Screen.PrimaryScreen.WorkingArea.Width)
            {
                newpos.X = Screen.PrimaryScreen.WorkingArea.Width - needSize.Width;
            }

            if (newpos.Y <= 0)
            {
                newpos.Y = 0;
            }
            if (newpos.Y + needSize.Height > Screen.PrimaryScreen.WorkingArea.Height)
            {
                newpos.Y = Screen.PrimaryScreen.WorkingArea.Height - needSize.Height;
            }

            this.Location = newpos;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SetClip(e.ClipRectangle);
            this.dayInfos.Draw(e.ClipRectangle, e.Graphics);
        }



        public void CalenderForm_MouseDown(object sender, MouseEventArgs e)
        {
            this.DoMouseClick(sender, e);
        }

        public void DoMouseClick(object sender, MouseEventArgs e)
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

            Size needSize = dayInfos.SetRect(StartLeft, StartTop, this.DispYear, this.DispMonth, this.fontSize,
                this.dayPanes,
                this.CreateGraphics());
            this.Size = needSize;
            ResetPos(needSize);

            this.Invalidate(true);

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
        }

        private void CalenderForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }

}
