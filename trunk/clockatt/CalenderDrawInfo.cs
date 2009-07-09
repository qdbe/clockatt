using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace clockatt
{
    internal class CalenderDrawInfo : System.Collections.Generic.List<CalenderDayInfo>
    {
        private int margin = 2;

        private static int WeekDayCount = 7;

        public static int MaxDayCount = 31;

        private Point headDrawPoint = new Point();
        private Point[] weekDayDrawPoint = new Point[WeekDayCount];

        private HolidayConfigCollection []pHolidays;

        private CalendarConfigration Config { get; set; }

        public int DispYear { get; set; }

        public int DispMonth { get; set ; }

        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="holiday"></param>
        public CalenderDrawInfo(HolidayConfigCollection []holiday, CalendarConfigration config)
        {
            this.pHolidays = holiday;
            this.Config = config;
        }

        /// <summary>
        /// 年月の出力位置を決定する
        /// </summary>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <param name="yearFont"></param>
        /// <returns></returns>
        private int SetRectYearMonth(
            int startX,
            int startY,
            Font yearFont)
        {
            // 年＋月の位置
            this.headDrawPoint.X = startX;
            this.headDrawPoint.Y = startY;

            return startY + yearFont.Height + 5;
        }

        private int SetRectWeek(
            int startX,
            int startY,
            Font weekFont)
        {
            int charMargin = weekFont.Height + 5 + this.margin;

            int x = startX;

            for (int i = 0; i < WeekDayCount; i++)
            {
                this.weekDayDrawPoint[i].X = x;
                this.weekDayDrawPoint[i].Y = startY;

                x += charMargin;
            }

            return startY += weekFont.Height + 0;
        }


        private int GetDayStartX(
            DateTime dt,
            int startX,
            int charMargin
            )
        {
            int x = startX;

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

            return x;
        }

        private SizeF GetDayStringSize(Graphics g, Font dayFont)
        {
            string dispstr = string.Format("{0, 2}", 88);
            SizeF strsize = g.MeasureString(dispstr, dayFont);
            strsize.Height += this.margin;
            strsize.Width += this.margin;

            return strsize;
        }

        private Size SetRectDay(
            int startX,
            int startY,
            Font dayFont,
            CalenderDayPanel[] panels,
            Graphics g)
        {
            int x = startX;
            int y = startY;


            DateTime dt = new DateTime(this.DispYear, this.DispMonth, 1);


            SizeF strsize = GetDayStringSize(g, dayFont);


            int charMargin = dayFont.Height + 5 + this.margin;
            int addHeight = dayFont.Height + 0 + this.margin;


            x = GetDayStartX(dt, startX, charMargin);

            this.Clear();

            Size needSize = new Size(startX,startY);

            int maxDate = DateTime.DaysInMonth(this.DispYear, this.DispMonth);
            for (int j = 0; j < panels.Length; j++)
            {
                if (maxDate <= j)
                {
                    panels[j].ClearDrawInfo();
                    continue;
                }
                DateTime dayDt = new DateTime(this.DispYear, this.DispMonth, j + 1);

                if (dayDt.DayOfWeek == DayOfWeek.Sunday)
                {
                    x = startX;
                    if (j != 0)
                    {
                        y += addHeight;
                    }
                }

                CalenderDayInfo info = new CalenderDayInfo(
                    dayDt,
                    new Rectangle(x, y, (int)strsize.Width, (int)strsize.Height),
                    this.pHolidays);

                if (needSize.Width < (x + (int)strsize.Width))
                {
                    needSize.Width = x + (int)strsize.Width;
                }
                if (needSize.Height < (y + (int)strsize.Height))
                {
                    needSize.Height = y + (int)strsize.Height;
                }


                this.Add(info);

                panels[j].SetDrawInfo(info);
                panels[j].DrawDay += new CalenderDayPanel.DrawDayEventHandler(this.PaintDay);

                x += charMargin;
            }

            needSize.Width += startX;
            needSize.Height += addHeight / 2;

            return needSize;
        }



        /// <summary>
        /// 出力位置を決定する
        /// </summary>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <param name="dispYear"></param>
        /// <param name="dispMonth"></param>
        /// <param name="fontSize"></param>
        /// <param name="g"></param>
        public virtual Size SetRect(
            int startX, 
            int startY, 
            int dispYear, 
            int dispMonth, 
            int fontSize,
            CalenderDayPanel []panels,
            Graphics g)
        {
            this.DispMonth = dispMonth;
            this.DispYear = dispYear;

            Font basefont = new Font(this.Config.YearMonthFont.FontFamily.Name, this.Config.FontSize);


            // 年＋月の位置
            int y = SetRectYearMonth(startX, startY, basefont);

            // 曜日の位置

            y = SetRectWeek(startX, y, basefont);

            // 日付の位置

            Size needSize = SetRectDay(startX, y, basefont, panels, g);

            return needSize;
        }

        /// <summary>
        /// 月日を表示する
        /// </summary>
        /// <param name="clip"></param>
        /// <param name="g"></param>
        protected virtual void PaintYearMonth(Rectangle clip, Graphics g)
        {

            Font yearMonthFont = new Font(this.Config.YearMonthFont.FontFamily.Name, this.Config.FontSize);
            System.Drawing.Brush yearMonthBrush = new System.Drawing.SolidBrush(this.Config.YearMonthColor);

            string dispString = string.Format("{0}年 {1}月",
                this.DispYear,
                this.DispMonth
                );

            g.DrawString(dispString, yearMonthFont, yearMonthBrush, this.headDrawPoint.X, this.headDrawPoint.Y);

        }

        /// <summary>
        /// 曜日を表示する
        /// </summary>
        /// <param name="clip"></param>
        /// <param name="g"></param>
        protected virtual void PaintWeekDay(Rectangle clip, Graphics g)
        {
            Font weekDayFont = new Font(this.Config.WeekFont.FontFamily.Name, this.Config.FontSize);
            System.Drawing.Brush weekDayBrush = new System.Drawing.SolidBrush(this.Config.WeekColor);
            System.Drawing.Brush weekDayBrushSun = new System.Drawing.SolidBrush(this.Config.WeekSundayColor);
            System.Drawing.Brush weekDayBrushSat = new System.Drawing.SolidBrush(this.Config.WeekSaturndayColor);

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

        public void PaintDay(object sender, PaintEventArgs e)
        {
            Font dayFont = new Font(this.Config.DayFont.FontFamily.Name, this.Config.FontSize);

            System.Drawing.Brush dayBrush = new System.Drawing.SolidBrush(this.Config.DayColor);
            System.Drawing.Brush dayBrushHolyDay = new System.Drawing.SolidBrush(this.Config.DayHolidayColor);
            System.Drawing.Brush dayBrushSun = new System.Drawing.SolidBrush(this.Config.DaySundayColor);
            System.Drawing.Brush dayBrushSat = new System.Drawing.SolidBrush(this.Config.DaySaturndayColor);


            e.Graphics.SetClip(e.ClipRectangle);

            Brush charBrush = dayBrush;
            CalenderDayInfo cdi = ((CalenderDayPanel)sender).DayInfo;
            System.Diagnostics.Debug.WriteLine(cdi.DispDay.ToShortDateString() + " Paint Happend");
            if (cdi.IsToday == true)
            {
                ((CalenderDayPanel)sender).BackColor = this.Config.DayTodayBackColor;
            }
            else
            {
                ((CalenderDayPanel)sender).BackColor = this.Config.BackColor;
            }

            if (cdi.IsHoliday == true)
            {
                charBrush = dayBrushSun;
                System.Diagnostics.Debug.WriteLine(cdi.DispDay.ToShortDateString() + " is Holiday");
            }
            else if (cdi.IsSunday == true)
            {
                charBrush = dayBrushSun;
                System.Diagnostics.Debug.WriteLine(cdi.DispDay.ToShortDateString() + " IsSunday");
            }
            else if (cdi.IsSaturday == true)
            {
                charBrush = dayBrushSat;
                System.Diagnostics.Debug.WriteLine(cdi.DispDay.ToShortDateString() + " IsSaturday");
            }
            else
            {
                charBrush = dayBrush;
                System.Diagnostics.Debug.WriteLine(cdi.DispDay.ToShortDateString() + " Is Normal");
            }

            string str = cdi.GetDispStr();
            e.Graphics.DrawString(str,
                dayFont,
                charBrush,
                1,1);

        }

        public virtual void Draw(
            Rectangle clicpRect,
            Graphics g
            )
        {
            PaintYearMonth(clicpRect, g);
            PaintWeekDay(clicpRect, g);
            //PaintDay(clicpRect, g);
        }
    }
}
