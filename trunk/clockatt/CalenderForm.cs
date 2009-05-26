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
        private int YearMonthTop = 10;
        private int YearMonthLeft = 10;

        private int WeekDayTop = 10;
        private int WeekDayLeft = 10;


        private int DayTop = 10;
        private int DayLeft = 10;

        private int DispYear;
        private int DispMonth;

        private int CharMargin = 10;

        private int fontSize = 12;

        private HolidayConfigCollection pHolidays;


        public CalenderForm(HolidayConfigCollection holidays)
        {
            InitializeComponent();
            DateTime dt = DateTime.Now;
            this.DispYear = dt.Year;
            this.DispMonth = dt.Month;
            this.pHolidays = holidays;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.Paints(e.ClipRectangle, e.Graphics);
        }

        protected virtual void Paints(Rectangle clip, Graphics g)
        {
            g.SetClip(clip);
            // 年＋月の描画
            PaintYearMonth(clip, g);
            // 曜日の描画
            PaintWeekDay(clip, g);
            // 日付の描画
            PaintDay(clip, g);
        }

        protected virtual void PaintYearMonth(Rectangle clip, Graphics g)
        {
            int x = YearMonthLeft;
            int y = YearMonthTop;

            Font yearMonthFont = new Font("ＭＳ ゴシック", fontSize);
            this.CharMargin = yearMonthFont.Height;
            System.Drawing.Brush yearMonthBrush = new System.Drawing.SolidBrush(Color.Black);

            this.WeekDayTop = YearMonthTop + yearMonthFont.Height + 5;

            string dispString = string.Format("{0}年 {1}月",
                this.DispYear,
                this.DispMonth
                );

            g.DrawString(dispString, yearMonthFont, yearMonthBrush, x, y);

        }

        protected virtual void PaintWeekDay(Rectangle clip, Graphics g)
        {
            int x = WeekDayLeft;
            int y = WeekDayTop;
            Font weekDayFont = new Font("ＭＳ ゴシック", fontSize);
            this.CharMargin = weekDayFont.Height + 5;
            System.Drawing.Brush weekDayBrush = new System.Drawing.SolidBrush(Color.Black);
            System.Drawing.Brush weekDayBrushSun = new System.Drawing.SolidBrush(Color.Red);
            System.Drawing.Brush weekDayBrushSat = new System.Drawing.SolidBrush(Color.Blue);

            this.DayTop = WeekDayTop + weekDayFont.Height + 0;

            object [][] strWeekDay = new object[][]{
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
                g.DrawString(strWeekDay[i][0].ToString(), weekDayFont, (Brush)strWeekDay[i][1], x, y);
                x += this.CharMargin;
            }
        }

        protected virtual void PaintDay(Rectangle clip, Graphics g)
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
                if (dt.DayOfWeek == DayOfWeek.Sunday )
                {
                    x = DayLeft;
                    if (i != 0)
                    {
                        y += addHeight;
                    }
                    b = dayBrushSun;
                }
                else if( this.pHolidays.IsHoliday(dt) == true )
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
        }

    }

}
