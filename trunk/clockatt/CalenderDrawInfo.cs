using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using clockatt.Configration;

namespace clockatt
{
    internal class CalenderDrawInfo : System.Collections.Generic.List<CalenderDayInfo>
    {
        /// <summary>
        /// 描画用マージン値
        /// </summary>
        private int margin = 2;

        /// <summary>
        /// 一週間の曜日数
        /// </summary>
        private static int WeekDayCount = 7;

        /// <summary>
        /// 年・月の表示位置
        /// </summary>
        private Point headDrawPoint = new Point();

        /// <summary>
        /// 曜日の表示位置
        /// </summary>
        private Point[] weekDayDrawPoint = new Point[WeekDayCount];

        /// <summary>
        /// 休日情報
        /// </summary>
        private HolidayConfigCollection []pHolidays;

        /// <summary>
        /// カレンダーの表示設定
        /// </summary>
        private CalendarConfigration Config { get; set; }

        /// <summary>
        /// 表示年
        /// </summary>
        private int DispYear { get; set; }

        /// <summary>
        /// 表示月
        /// </summary>
        private int DispMonth { get; set; }

        /// <summary>
        /// 表示に必要なサイズ
        /// </summary>
        private Size pNeedSize;

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
        /// <param name="startX">左側の開始位置</param>
        /// <param name="startY">上側の開始位置</param>
        /// <param name="yearFont">表示フォント</param>
        /// <param name="g">描画対象</param>
        /// <returns></returns>
        private void SetYearMonthLocation(
            int startX,
            int startY,
            Graphics g,
            Font yearFont)
        {
            // 年＋月の位置
            this.headDrawPoint.X = startX;
            this.headDrawPoint.Y = startY;

            string dispString = string.Format("{0}年 {1}月",
                2000,
                12
                );

            SizeF strsize = g.MeasureString(dispString, yearFont);

            SetNeedSize(
                startX + (int)strsize.Width + startX,
                startY + yearFont.Height + 5
                );
        }

        /// <summary>
        /// 曜日の表示位置を決定する
        /// </summary>
        /// <param name="startX">左側の開始位置</param>
        /// <param name="startY">上側の開始位置</param>
        /// <param name="weekFont">曜日の表示フォント</param>
        /// <param name="g">描画対象</param>
        private void SetWeekDayLocation(
            int startX,
            int startY,
            Font weekFont,
            Graphics g)
        {
            int charMargin = weekFont.Height + 5 + this.margin;

            int x = startX;

            for (int i = 0; i < WeekDayCount; i++)
            {
                this.weekDayDrawPoint[i].X = x;
                this.weekDayDrawPoint[i].Y = startY;

                x += charMargin;
            }
            SizeF strsize = g.MeasureString("日", weekFont);


            SetNeedSizeWidth(
                x + startX
                );
            AddNeedSizeHeight((int)strsize.Height + 5);
        }

        /// <summary>
        /// １日の表示開始位置を取得する
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="startX"></param>
        /// <param name="charMargin"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 一日分の描画サイズを計算する
        /// </summary>
        /// <param name="g"></param>
        /// <param name="dayFont"></param>
        /// <returns></returns>
        private SizeF GetDayStringSize(Graphics g, Font dayFont)
        {
            string dispstr = string.Format("{0, 2}", 88);
            SizeF strsize = g.MeasureString(dispstr, dayFont);
            strsize.Height += this.margin;
            strsize.Width += this.margin;

            return strsize;
        }

        /// <summary>
        /// 日の表示位置を決定する
        /// </summary>
        /// <param name="startX">左側の開始位置</param>
        /// <param name="startY">上側の開始位置</param>
        /// <param name="dayFont">描画フォント</param>
        /// <param name="panels">日配置用パネル</param>
        /// <param name="g">描画対象</param>
        private void SetDayLocation(
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

            SetEachDayLocation(startX, panels, x, y, strsize, charMargin, addHeight);

            //マージン分を追加
            AddNeedSize(startX, addHeight / 2);
        }

        /// <summary>
        /// 各日の配置場所を決定する
        /// </summary>
        /// <param name="startX"></param>
        /// <param name="panels"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="strsize"></param>
        /// <param name="charMargin"></param>
        /// <param name="addHeight"></param>
        private void SetEachDayLocation(int startX, CalenderDayPanel[] panels, int x, int y, SizeF strsize, int charMargin, int addHeight)
        {
            int maxDate = DateTime.DaysInMonth(this.DispYear, this.DispMonth);

            for (int j = 0; j < panels.Length; j++)
            {
                if (maxDate <= j)
                {
                    panels[j].HideMe();
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

                this.Add(info);

                panels[j].SetDrawInfo(info);
                panels[j].DrawDay += new PaintEventHandler(this.PaintDay);

                SetNeedSize(
                    x + (int)strsize.Width, 
                    y + (int)strsize.Height);

                x += charMargin;
            }

        }

        /// <summary>
        /// 必要サイズを更新する
        /// </summary>
        /// <param name="x"></param>
        private void SetNeedSizeWidth(int x)
        {
            if (this.pNeedSize.Width < x)
            {
                this.pNeedSize.Width = x;
            }
        }

        /// <summary>
        /// 必要サイズを更新する
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void SetNeedSize(int x, int y)
        {
            SetNeedSizeWidth(x);
            if (this.pNeedSize.Height < y)
            {
                this.pNeedSize.Height = y;
            }
        }

        /// <summary>
        /// 必要サイズを追加する
        /// </summary>
        /// <param name="y"></param>
        private void AddNeedSizeHeight(int y)
        {
            this.pNeedSize.Height += y;
        }

        /// <summary>
        /// 必要サイズを追加する
        /// </summary>
        private void AddNeedSize(int x, int y)
        {
            this.pNeedSize.Width += x;
            this.pNeedSize.Height += y;
        }


        /// <summary>
        /// 出力位置を決定する
        /// </summary>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <param name="dispYear"></param>
        /// <param name="dispMonth"></param>
        /// <param name="g"></param>
        public virtual Size SetLocation(
            int startX, 
            int startY, 
            int dispYear, 
            int dispMonth, 
            CalenderDayPanel []panels,
            Graphics g)
        {
            this.DispMonth = dispMonth;
            this.DispYear = dispYear;

            this.pNeedSize = new Size(0,0);

            // 年＋月の位置
            SetYearMonthLocation(startX, startY, g, this.Config.YearMonthFont);

            // 曜日の位置
            SetWeekDayLocation(startX, this.pNeedSize.Height, this.Config.WeekFont, g);

            // 日付の位置

            SetDayLocation(startX, this.pNeedSize.Height, this.Config.DayFont, panels, g);

            return this.pNeedSize;
        }

        /// <summary>
        /// 月日を表示する
        /// </summary>
        /// <param name="clip"></param>
        /// <param name="g"></param>
        protected virtual void PaintYearMonth(Graphics g)
        {
            DrawYearMonthString(
                g, 
                string.Format("{0}年 {1}月",this.DispYear,this.DispMonth)
                );

        }

        /// <summary>
        /// 年月を描画する
        /// </summary>
        /// <param name="g"></param>
        /// <param name="dispString"></param>
        private void DrawYearMonthString(Graphics g, string dispString)
        {
            g.DrawString(dispString,
                this.Config.YearMonthFont,
                new System.Drawing.SolidBrush(this.Config.YearMonthColor),
                this.headDrawPoint.X,
                this.headDrawPoint.Y);
        }

        /// <summary>
        /// 曜日を表示する
        /// </summary>
        /// <param name="clip"></param>
        /// <param name="g"></param>
        protected virtual void PaintWeekDay(Graphics g)
        {
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
                DrawWeekDayString(
                    g, 
                    strWeekDay[i][0].ToString(),
                    (Brush)strWeekDay[i][1],
                    strWeekDay, 
                    this.weekDayDrawPoint[i]);
            }
        }

        /// <summary>
        /// 曜日を描画する
        /// </summary>
        /// <param name="g"></param>
        /// <param name="outputString"></param>
        /// <param name="weekdayBrush"></param>
        /// <param name="strWeekDay"></param>
        /// <param name="pos"></param>
        private void DrawWeekDayString(Graphics g, string outputString, Brush weekdayBrush, object[][] strWeekDay, Point pos)
        {
            g.DrawString(
                outputString,
                this.Config.WeekFont,
                weekdayBrush,
                pos.X, pos.Y);
        }

        /// <summary>
        /// 日を表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PaintDay(object sender, PaintEventArgs e)
        {
            Font dayFont = this.Config.DayFont;

            e.Graphics.SetClip(e.ClipRectangle);

            CalenderDayPanel panel = (CalenderDayPanel)sender;

            SetDayBackColor(panel);
            DrawDayString(e.Graphics, dayFont, panel.DayInfo);
        }

        /// <summary>
        /// 日の文字を描画する
        /// </summary>
        /// <param name="g"></param>
        /// <param name="dayFont"></param>
        /// <param name="cdi"></param>
        private void DrawDayString(Graphics g, Font dayFont, CalenderDayInfo cdi)
        {
            g.DrawString(
                cdi.GetDispStr(),
                dayFont,
                GetDayBrush(cdi),
                1, 1);
        }

        /// <summary>
        /// 日の背景色をセットする
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="cdi"></param>
        private void SetDayBackColor(CalenderDayPanel panel)
        {
            if (panel.DayInfo.IsToday == true)
            {
                panel.SetBackColor(this.Config.DayTodayBackColor);
            }
            else
            {
                panel.SetBackColor(this.Config.BackColor);
            }
        }

        /// <summary>
        /// 日の文字色を取得する
        /// </summary>
        /// <param name="cdi"></param>
        /// <returns></returns>
        private Brush GetDayBrush(CalenderDayInfo cdi)
        {
            if (cdi.IsHoliday == true)
            {
                return new System.Drawing.SolidBrush(this.Config.DayHolidayColor);
            }
            else if (cdi.IsSunday == true)
            {
                return new System.Drawing.SolidBrush(this.Config.DaySundayColor);
            }
            else if (cdi.IsSaturday == true)
            {
                return new System.Drawing.SolidBrush(this.Config.DaySaturndayColor);
            }
            else
            {
                return new System.Drawing.SolidBrush(this.Config.DayColor);
            }
        }

        /// <summary>
        /// 描画処理
        /// </summary>
        /// <param name="clicpRect"></param>
        /// <param name="g"></param>
        public virtual void Draw(
            Rectangle clicpRect,
            Graphics g
            )
        {
            PaintYearMonth(g);
            PaintWeekDay(g);
            // 日の描画は各パネルが行う
        }
    }
}
