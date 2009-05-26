using System;
using System.Collections.Generic;
using System.Text;

namespace clockatt
{
    internal class CalenderDayInfoCollection : System.Collections.Generic.List<CalenderDayInfo>
    {
        CalenderDaysInfo

        protected virtual void SetRect(Graphics g)
        {
            int x = DayLeft;
            int y = DayTop;
            int addHeight = 0;
            Font dayFont = new Font("ＭＳ ゴシック", fontSize);
            this.CharMargin = dayFont.Height + 5;
            System.Drawing.Brush dayBrush = new System.Drawing.SolidBrush(Color.Black);
            System.Drawing.Brush dayBrushHolyDay = new System.Drawing.SolidBrush(Color.Red);
            System.Drawing.Brush dayBrushSun = new System.Drawing.SolidBrush(Color.Red);
            System.Drawing.Brush dayBrushSat = new System.Drawing.SolidBrush(Color.Blue);
            System.Drawing.Brush dayBrushToDay = new System.Drawing.SolidBrush(Color.Aqua);

            addHeight = dayFont.Height + 0;


            DateTime dt = new DateTime(this.DispYear, this.DispMonth, 1);

            if (dt.DayOfWeek != DayOfWeek.Sunday)
            {
                if (dt.DayOfWeek == DayOfWeek.Monday)
                {
                    x += this.CharMargin;
                }
                if (dt.DayOfWeek == DayOfWeek.Tuesday)
                {
                    x += this.CharMargin * 2;
                }
                if (dt.DayOfWeek == DayOfWeek.Wednesday)
                {
                    x += this.CharMargin * 3;
                }
                if (dt.DayOfWeek == DayOfWeek.Thursday)
                {
                    x += this.CharMargin * 4;
                }
                if (dt.DayOfWeek == DayOfWeek.Friday)
                {
                    x += this.CharMargin * 5;
                }
                if (dt.DayOfWeek == DayOfWeek.Saturday)
                {
                    x += this.CharMargin * 6;
                }
            }


            Brush b = dayBrush;
            for (int i = 0; ; i++)
            {
                if (dt.DayOfWeek == DayOfWeek.Sunday)
                {
                    x = DayLeft;
                    if (i != 0)
                    {
                        y += addHeight;
                    }
                    b = dayBrushSun;
                }
                else if (this.pHolidays.IsHoliday(dt) == true)
                {
                    b = dayBrushSun;
                }
                else if (dt.DayOfWeek == DayOfWeek.Saturday)
                {
                    b = dayBrushSat;
                }
                else
                {
                    b = dayBrush;
                }
                string dispstr = string.Format("{0, 2}", dt.Day);
                g.DrawString(dispstr, dayFont, b, x, y);

                x += this.CharMargin;

                dt = dt.AddDays(1);
                if (dt.Month != this.DispMonth)
                {
                    break;
                }
            }
        }


    }
}
