using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Configuration;

namespace clockatt
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
        [DefaultSettingValue("Control")]
        public Color BackColor { get; set; }

        
        /// <summary>
        /// フォントサイズ
        /// </summary>
        [UserScopedSetting()]
        [DefaultSettingValue("9")]
        public float FontSize { get; set; }

        /// <summary>
        /// フォント名
        /// </summary>
        [UserScopedSetting()]
        [DefaultSettingValue("ＭＳ ゴシック")]
        public Font YearMonthFont { get; set; }

        /// <summary>
        /// フォント色
        /// </summary>
        [UserScopedSetting()]
        [DefaultSettingValue("Black")]
        public Color YearMonthColor { get; set; }


        /// <summary>
        /// フォント名
        /// </summary>
        [UserScopedSetting()]
        [DefaultSettingValue("ＭＳ ゴシック")]
        public Font WeekFont { get; set; }

        /// <summary>
        /// フォント色
        /// </summary>
        [UserScopedSetting()]
        [DefaultSettingValue("Black")]
        public Color WeekColor { get; set; }

        /// <summary>
        /// フォント色
        /// </summary>
        [UserScopedSetting()]
        [DefaultSettingValue("Red")]
        public Color WeekSundayColor { get; set; }

        /// <summary>
        /// フォント色
        /// </summary>
        [UserScopedSetting()]
        [DefaultSettingValue("Blue")]
        public Color WeekSaturndayColor { get; set; }


        /// <summary>
        /// フォント名
        /// </summary>
        [UserScopedSetting()]
        [DefaultSettingValue("ＭＳ ゴシック")]
        public Font DayFont { get; set; }

        /// <summary>
        /// フォント色
        /// </summary>
        [UserScopedSetting()]
        [DefaultSettingValue("Black")]
        public Color DayColor { get; set; }

        /// <summary>
        /// フォント色
        /// </summary>
        [UserScopedSetting()]
        [DefaultSettingValue("Red")]
        public Color DaySundayColor { get; set; }

        /// <summary>
        /// フォント色
        /// </summary>
        [UserScopedSetting()]
        [DefaultSettingValue("Blue")]
        public Color DaySaturndayColor { get; set; }


        /// <summary>
        /// フォント色
        /// </summary>
        [UserScopedSetting()]
        [DefaultSettingValue("Red")]
        public Color DayHolidayColor { get; set; }

        /// <summary>
        /// フォント色
        /// </summary>
        [UserScopedSetting()]
        [DefaultSettingValue("Aqua")]
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
