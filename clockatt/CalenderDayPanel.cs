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

        public delegate void DrawDayEventHandler(object sender, PaintEventArgs e);

        public event DrawDayEventHandler DrawDay = null;

        public CalenderDayPanel(int day) : base()
        {
            this.BorderStyle = BorderStyle.None;
            this.pDispDay = day;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if( this.DrawDay != null )
            {
                this.DrawDay(this, e);
            }
        }
    }
}
