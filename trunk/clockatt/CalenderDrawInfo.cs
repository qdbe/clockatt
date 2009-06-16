using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Text;

namespace clockatt
{
    internal class CalenderDrawInfo : System.Collections.Generic.List<CalenderDayInfo>
    {
        private int fontSize = 12;

        private static int WeekDayCount = 7;

        private Point headDrawPoint = new Point();
        private Point[] weekDayDrawPoint = new Point[WeekDayCount];

        private int pDispYear = 0;
        public int DispYear
        {
            get { return pDispYear; }
            set { pDispYear = value; }
        }

        private int pDispMonth = 0;
        public int DispMonth
        {
            get { return pDispMonth; }
            set { pDispMonth = value; }
        }

        public CalenderDrawInfo()
            : base()
        {
        }

        public virtual void Draw(
            Rectangle clicpRect,
            Graphics g
            )
        {

            PaintYearMonth(clicpRect, g);
            PaintWeekDay(clicpRect, g);
            
            
            Font dayFont = new Font("ＭＳ ゴシック", fontSize);

            System.Drawing.Brush dayBrush = new System.Drawing.SolidBrush(Color.Black);
            System.Drawing.Brush dayBrushHolyDay = new System.Drawing.SolidBrush(Color.Red);
            System.Drawing.Brush dayBrushSun = new System.Drawing.SolidBrush(Color.Red);
            System.Drawing.Brush dayBrushSat = new System.Drawing.SolidBrush(Color.Blue);
            System.Drawing.Brush dayBrushToDay = new System.Drawing.SolidBrush(Color.Aqua);
            Brush b = dayBrush;
            CalenderDayInfo cdi;
            for (int i = 0; i < this.Count; i++)
            {
                cdi = this[i];

                if (cdi.DispDay.DayOfWeek == DayOfWeek.Sunday)
                {
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

        protected virtual void PaintYearMonth(Rectangle clip, Graphics g)
        {

            Font yearMonthFont = new Font("ＭＳ ゴシック", fontSize);
            System.Drawing.Brush yearMonthBrush = new System.Drawing.SolidBrush(Color.Black);

            string dispString = string.Format("{0}年 {1}月",
                this.DispYear,
                this.DispMonth
                );

            g.DrawString(dispString, yearMonthFont, yearMonthBrush, this.headDrawPoint.X, this.headDrawPoint.Y);

        }

        protected virtual void PaintWeekDay(Rectangle clip, Graphics g)
        {
            Font weekDayFont = new Font("ＭＳ ゴシック", fontSize);
            System.Drawing.Brush weekDayBrush = new System.Drawing.SolidBrush(Color.Black);
            System.Drawing.Brush weekDayBrushSun = new System.Drawing.SolidBrush(Color.Red);
            System.Drawing.Brush weekDayBrushSat = new System.Drawing.SolidBrush(Color.Blue);

            object[][] strWeekDay = new object[][]{
                        new object[]{ "日", weekDayBrushSun },
                        new object[]{ "月", weekDayBrush },
                        new object[]{ "火", weekDayBrush },
                        new object[]{ "水", weekDayBrush },
                        new object[]{ "木", weekDayBrush },
                        new object[]{ "金", weekDayBrush },
                        new object[]{ "土", weekDayBrushSat }
            };

            Brush b = weekDayBrush;
            for (int i = 0; i < strWeekDay.Length; i++)
            {
                g.DrawString(strWeekDay[i][0].ToString(), weekDayFont, (Brush)strWeekDay[i][1], this.weekDayDrawPoint[i].X, this.weekDayDrawPoint[i].Y);
            }
        }



        public virtual void SetRect(
            int startX, 
            int startY, 
            int dispYear, 
            int dispMonth, 
            int fontSize,
            Graphics g)
        {
            int x = startX;
            int y = startY;
            int addHeight = 0;
            int charMargin = 0;

            Font baseFont = new Font("ＭＳ ゴシック", fontSize);

            // 年＋月の位置
            this.headDrawPoint.X = startX;
            this.headDrawPoint.Y = startY;

            // 曜日の位置
            Font yearMonthFont = baseFont;
            x = startX;
            y = startY + yearMonthFont.Height + 5;
            Font weekDayFont = baseFont;
            charMargin = weekDayFont.Height + 5;

            for (int i = 0; i < WeekDayCount; i++)
            {
                this.weekDayDrawPoint[i].X = x;
                this.weekDayDrawPoint[i].Y = y;

                x += charMargin;
            }


            // 日付の位置
            y += weekDayFont.Height + 0;
            Font dayFont = baseFont;
            charMargin = dayFont.Height + 5;
            addHeight = dayFont.Height + 0;

            DateTime dt = new DateTime(dispYear, dispMonth, 1);

            if (dt.DayOfWeek != DayOfWeek.Sunday)
            {
                if (dt.DayOfWeek == DayOfWeek.Monday)
                {
                    x += charMargin;
                }
                if (dt.DayOfWeek == DayOfWeek.Tuesday)
                {
                    x += charMargin * 2;
                }
                if (dt.DayOfWeek == DayOfWeek.Wednesday)
                {
                    x += charMargin * 3;
                }
                if (dt.DayOfWeek == DayOfWeek.Thursday)
                {
                    x += charMargin * 4;
                }
                if (dt.DayOfWeek == DayOfWeek.Friday)
                {
                    x += charMargin * 5;
                }
                if (dt.DayOfWeek == DayOfWeek.Saturday)
                {
                    x += charMargin * 6;
                }
            }

            this.Clear();

            for (int j = 0; ; j++)
            {
                if (dt.DayOfWeek == DayOfWeek.Sunday)
                {
                    x = startX;
                    if (j != 0)
                    {
                        y += addHeight;
                    }
                }
                string dispstr = string.Format("{0, 2}", dt.Day);
                CalenderDayInfo info = new CalenderDayInfo();
                SizeF strsize = g.MeasureString(dispstr,dayFont);
                info.DispDay = dt;
                info.DispRect = new Rectangle(x, y, (int)strsize.Width, (int)strsize.Height);
                this.Add(info);

                x += charMargin;

                dt = dt.AddDays(1);
                if (dt.Month != dispMonth)
                {
                    break;
                }
            }
        }


    }
}
