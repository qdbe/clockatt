using System;
using System.Collections.Generic;
using System.Text;
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

        public CalenderDayPanel() : base()
        {
            this.BorderStyle = BorderStyle.None;
            this.Click += new EventHandler(CalenderDayPanel_Click);
        }

        private void CalenderDayPanel_Click(object sender, EventArgs e)
        {
            // 親のマウスクリックを呼び出す
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if( this.DrawDay != null )
            {
                this.DrawDay(this, e);
            }
        }

        public static CalenderDayPanel[] CreatePanels(Form parents)
        {
            parents.SuspendLayout();

            CalenderDayPanel[] panels = new CalenderDayPanel[CalenderDayPanel.MAXDAYCOUNT];

            for( int i = 0; i < panels.Length; i++ )
            {
                panels[i] = new CalenderDayPanel();
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
