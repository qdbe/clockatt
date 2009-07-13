using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Configuration;

namespace clockatt.Configration
{
    /// <summary>
    /// カレンダーの設定値
    /// </summary>
    public class CalendarConfigration : ApplicationSettingsBase
    {
        /// <summary>
        /// フォントサイズ
        /// </summary>
        [UserScopedSetting()]
        public Color BackColor { get; set; }

        
        /// <summary>
        /// フォントサイズ
        /// </summary>
        [UserScopedSetting()]
        public float FontSize { get; set; }

        /// <summary>
        /// フォント名
        /// </summary>
        [UserScopedSetting()]
        public Font YearMonthFont { get; set; }

        /// <summary>
        /// フォント色
        /// </summary>
        [UserScopedSetting()]
        public Color YearMonthColor { get; set; }


        /// <summary>
        /// フォント名
        /// </summary>
        [UserScopedSetting()]
        public Font WeekFont { get; set; }

        /// <summary>
        /// フォント色
        /// </summary>
        [UserScopedSetting()]
        public Color WeekColor { get; set; }

        /// <summary>
        /// フォント色
        /// </summary>
        [UserScopedSetting()]
        public Color WeekSundayColor { get; set; }

        /// <summary>
        /// フォント色
        /// </summary>
        [UserScopedSetting()]
        public Color WeekSaturndayColor { get; set; }


        /// <summary>
        /// フォント名
        /// </summary>
        [UserScopedSetting()]
        public Font DayFont { get; set; }

        /// <summary>
        /// フォント色
        /// </summary>
        [UserScopedSetting()]
        public Color DayColor { get; set; }

        /// <summary>
        /// フォント色
        /// </summary>
        [UserScopedSetting()]
        public Color DaySundayColor { get; set; }

        /// <summary>
        /// フォント色
        /// </summary>
        [UserScopedSetting()]
        public Color DaySaturndayColor { get; set; }


        /// <summary>
        /// フォント色
        /// </summary>
        [UserScopedSetting()]
        public Color DayHolidayColor { get; set; }

        /// <summary>
        /// フォント色
        /// </summary>
        [UserScopedSetting()]
        public Color DayTodayBackColor { get; set; }

        public CalendarConfigration()
        {
            this.BackColor = Color.FromKnownColor(KnownColor.Control);
            this.FontSize = 12;
            this.YearMonthFont = new Font("ＭＳ ゴシック", this.FontSize);
            this.YearMonthColor = Color.Black;
            this.WeekFont = new Font("ＭＳ ゴシック", this.FontSize);
            this.WeekColor = Color.Black;
            this.WeekSaturndayColor = Color.Blue;
            this.WeekSundayColor = Color.Red;
            this.DayFont = new Font("ＭＳ ゴシック", this.FontSize);
            this.DayColor = Color.Black;
            this.DayHolidayColor = Color.Red;
            this.DaySaturndayColor = Color.Blue;
            this.DaySundayColor = Color.Red;
            this.DayTodayBackColor = Color.Aqua;
        }
    }
}
