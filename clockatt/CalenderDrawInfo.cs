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
        private int fontSize = 12;

        private int margin = 2;

        private string fontName = "ＭＳ ゴシック";

        private static int WeekDayCount = 7;

        public static int MaxDayCount = 31;

        private Point headDrawPoint = new Point();
        private Point[] weekDayDrawPoint = new Point[WeekDayCount];

        private HolidayConfigCollection []pHolidays;

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

        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="holiday"></param>
        public CalenderDrawInfo(HolidayConfigCollection []holiday)
        {
            this.pHolidays = holiday;
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
            int x = startX;
            int y = startY;
            int addHeight = 0;
            int charMargin = 0;

            Size needSize = new Size();
            needSize.Width = startX;
            needSize.Height = startY;

            this.pDispMonth = dispMonth;
            this.pDispYear = dispYear;

            Font baseFont = new Font(this.fontName, this.fontSize);

            // 年＋月の位置
            this.headDrawPoint.X = startX;
            this.headDrawPoint.Y = startY;

            // 曜日の位置
            Font yearMonthFont = baseFont;
            x = startX;
            y = startY + yearMonthFont.Height + 5;
            Font weekDayFont = baseFont;
            charMargin = weekDayFont.Height + 5 + this.margin;

            for (int i = 0; i < WeekDayCount; i++)
            {
                this.weekDayDrawPoint[i].X = x;
                this.weekDayDrawPoint[i].Y = y;

                x += charMargin;
            }


            // 日付の位置
            x = startX;
            y += weekDayFont.Height + 0;
            Font dayFont = baseFont;

            DateTime dt = new DateTime(dispYear, dispMonth, 1);

            string dispstr = string.Format("{0, 2}", 88);
            SizeF strsize = g.MeasureString(dispstr, dayFont);
            strsize.Height += this.margin;
            strsize.Width += this.margin;
            charMargin = dayFont.Height + 5 + this.margin;
            addHeight = dayFont.Height + 0 + this.margin;


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

            int maxDate = DateTime.DaysInMonth(dispYear,dispMonth);
            for (int j = 0; j < panels.Length; j++)
            {
                if (maxDate <= j)
                {
                    panels[j].ClearDrawInfo();
                    continue;
                }
                DateTime dayDt = new DateTime(dispYear, dispMonth, j+1);

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

                if (needSize.Width <
                    x + strsize.Width)
                {
                    needSize.Width = x + (int)strsize.Width;
                }
                if (needSize.Height <
                    y + strsize.Height)
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
        /// 月日を表示する
        /// </summary>
        /// <param name="clip"></param>
        /// <param name="g"></param>
        protected virtual void PaintYearMonth(Rectangle clip, Graphics g)
        {

            Font yearMonthFont = new Font(this.fontName, this.fontSize);
            System.Drawing.Brush yearMonthBrush = new System.Drawing.SolidBrush(Color.Black);

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
            Font weekDayFont = new Font(this.fontName, this.fontSize);
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

        public void PaintDay(object sender, PaintEventArgs e)
        {
            Font dayFont = new Font(this.fontName, this.fontSize);

            System.Drawing.Brush dayBrush = new System.Drawing.SolidBrush(Color.Black);
            System.Drawing.Brush dayBrushHolyDay = new System.Drawing.SolidBrush(Color.Red);
            System.Drawing.Brush dayBrushSun = new System.Drawing.SolidBrush(Color.Red);
            System.Drawing.Brush dayBrushSat = new System.Drawing.SolidBrush(Color.Blue);


            e.Graphics.SetClip(e.ClipRectangle);

            Brush charBrush = dayBrush;
            CalenderDayInfo cdi = ((CalenderDayPanel)sender).DayInfo;
            System.Diagnostics.Debug.WriteLine(cdi.DispDay.ToShortDateString() + " Paint Happend");
            if (cdi.IsToday == true)
            {
                ((CalenderDayPanel)sender).BackColor = Color.Aqua;
            }
            else
            {
                ((CalenderDayPanel)sender).BackColor = Color.FromKnownColor(KnownColor.Control);
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
