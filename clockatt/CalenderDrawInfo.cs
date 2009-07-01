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

        private string fontName = "ＭＳ ゴシック";

        private static int WeekDayCount = 7;

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
            charMargin = weekDayFont.Height + 5;

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
                SizeF strsize = g.MeasureString(dispstr,dayFont);
                CalenderDayInfo info = new CalenderDayInfo(
                    dt,
                    new Rectangle(x, y, (int)strsize.Width, (int)strsize.Height),
                    this.pHolidays);
                this.Add(info);

                x += charMargin;

                dt = dt.AddDays(1);
                if (dt.Month != dispMonth)
                {
                    break;
                }
            }
        }

        public virtual void SetDayPanels(Panel[] dayPanel)
        {
            int i = 0;
            for (; i < this.Count; i++)
            {
                Panel pn = dayPanel[i];
                pn.BorderStyle = BorderStyle.None;

                pn.Visible = true;

                pn.Location = this[i].DispRect.Location;
                pn.Width = this[i].DispRect.Width;
                pn.Height = this[i].DispRect.Height;
            }

            for (; i < dayPanel.Length; i++)
            {
                dayPanel[i].Visible = false;
            }
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


            System.Drawing.Brush normalBackBrush = new System.Drawing.SolidBrush(Color.FromKnownColor(KnownColor.Control));
            System.Drawing.Brush brushToDay = new System.Drawing.SolidBrush(Color.Aqua);

            Brush charBrush = dayBrush;
            Brush backBrush = normalBackBrush;
            CalenderDayInfo cdi;
            Control targetCon = (Control)sender;
            cdi = (CalenderDayInfo)targetCon.Tag;
            if (cdi.IsToday == true)
            {
                backBrush = brushToDay;
            }
            else
            {
                backBrush = normalBackBrush;
            }

            if (cdi.IsHoliday == true)
            {
                charBrush = dayBrushSun;
            }
            else if (cdi.IsSunday == true)
            {
                charBrush = dayBrushSun;
            }
            else if (cdi.IsSaturday == true)
            {
                charBrush = dayBrushSat;
            }
            else
            {
                charBrush = dayBrush;
            }
            e.Graphics.FillRectangle(backBrush, 0, 0, targetCon.Width, targetCon.Height);

            e.Graphics.SetClip(e.ClipRectangle);

            string str = cdi.GetDispStr();
            e.Graphics.DrawString(str,
                dayFont,
                charBrush,
                0,0);

        }

        /// <summary>
        /// 日を表示する
        /// </summary>
        /// <param name="clicpRect"></param>
        /// <param name="g"></param>
        public virtual void PaintDay(
            Rectangle clicpRect,
            Graphics g
            )
        {
            Font dayFont = new Font(this.fontName, this.fontSize);

            System.Drawing.Brush dayBrush = new System.Drawing.SolidBrush(Color.Black);
            System.Drawing.Brush dayBrushHolyDay = new System.Drawing.SolidBrush(Color.Red);
            System.Drawing.Brush dayBrushSun = new System.Drawing.SolidBrush(Color.Red);
            System.Drawing.Brush dayBrushSat = new System.Drawing.SolidBrush(Color.Blue);


            System.Drawing.Brush normalBackBrush = new System.Drawing.SolidBrush(Color.FromKnownColor(KnownColor.Control));
            System.Drawing.Brush brushToDay = new System.Drawing.SolidBrush(Color.Aqua);

            Brush charBrush = dayBrush;
            Brush backBrush = normalBackBrush;
            CalenderDayInfo cdi;
            for (int i = 0; i < this.Count; i++)
            {
                cdi = this[i];
                if (cdi.IsToday == true)
                {
                    backBrush = brushToDay;
                }
                else
                {
                    backBrush = normalBackBrush;
                }

                if (cdi.IsHoliday == true)
                {
                    charBrush = dayBrushSun;
                }
                else if (cdi.IsSunday == true)
                {
                    charBrush = dayBrushSun;
                }
                else if (cdi.IsSaturday == true)
                {
                    charBrush = dayBrushSat;
                }
                else
                {
                    charBrush = dayBrush;
                }

                g.FillRectangle(backBrush, cdi.DispRect);

                string str = cdi.GetDispStr();
                g.DrawString(str, 
                    dayFont, 
                    charBrush, 
                    cdi.DispRect.X,
                    cdi.DispRect.Y);
            }
        }


        public virtual void Draw(
            Rectangle clicpRect,
            Graphics g
            )
        {

            PaintYearMonth(clicpRect, g);
            PaintWeekDay(clicpRect, g);
            PaintDay(clicpRect, g);
        }


        public void SetToolTip(Control target, ToolTip dayToolTip, int x, int y)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].SetToolTipIfInRect(target, dayToolTip, x, y) == true)
                {
                    break;
                }
            }
        }

        internal CalenderDayPanel CalenderDayPanel
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public CalenderDayInfo CalenderDayInfo
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

    }
}
