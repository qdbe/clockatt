using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace clockatt
{
    class CalenderDayPanel : Panel
    {
        int pDispDay;
        public int DispDay
        {
            get { return pDispDay; }
        }

        public static readonly int MAXDAYCOUNT = 31;

        private ToolTip holidayTooltip = new ToolTip();

        public delegate void DrawDayEventHandler(object sender, PaintEventArgs e);

        public event DrawDayEventHandler DrawDay = null;

        private CalenderDayInfo pDayInfo;
        public CalenderDayInfo DayInfo
        {
            get { return pDayInfo; }
        }

        public delegate void DayPanelMouseDownEnventHandler(object sender, MouseEventArgs e);
        public event DayPanelMouseDownEnventHandler MouseDownOnDay = null;

        public CalenderDayPanel() : base()
        {
            this.BorderStyle = BorderStyle.None;
            this.MouseDown += new MouseEventHandler(CalenderDayPanel_MouseDown);
        }

        void CalenderDayPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // 月日の変更を実施する
                if (this.MouseDownOnDay != null)
                {
                    MouseEventArgs args = new MouseEventArgs(
                        e.Button,
                        e.Clicks,
                        e.X + this.Location.X,
                        e.Y + this.Location.Y,
                        e.Delta);

                    this.MouseDownOnDay(Parent, args);
               }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if( this.DrawDay != null )
            {
                this.DrawDay(this, e);
            }
        }

        public static CalenderDayPanel[] CreatePanels(Control parents, DayPanelMouseDownEnventHandler mouseDownDay)
        {
            parents.SuspendLayout();

            CalenderDayPanel[] panels = new CalenderDayPanel[CalenderDayPanel.MAXDAYCOUNT];

            for( int i = 0; i < panels.Length; i++ )
            {
                panels[i] = new CalenderDayPanel();
                panels[i].MouseDownOnDay += mouseDownDay;
                parents.Controls.Add(panels[i]);
            }
            parents.ResumeLayout();
            return panels;
        }

        public void ClearDrawInfo()
        {
            this.Visible = false;
            this.ClearToolTip();
        }

        public void SetDrawInfo(CalenderDayInfo dayInfo)
        {
            System.Diagnostics.Debug.WriteLine(dayInfo.DispDay.ToShortDateString() + " Is Set to Panel");

            this.Location = dayInfo.DispRect.Location;
            this.Width = dayInfo.DispRect.Width;
            this.Height = dayInfo.DispRect.Height;
            this.Visible = true;
            this.SetToolTip(dayInfo.HolidayName);
            this.pDayInfo = dayInfo;
            this.pDispDay = dayInfo.DispDay.Day;
            this.DrawDay = null;
        }

        public void SetToolTip(string strValue)
        {
            this.holidayTooltip.SetToolTip(this,strValue);
        }

        public void ClearToolTip()
        {
            this.holidayTooltip.SetToolTip(this, "");
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }
    }
}
