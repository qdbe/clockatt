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
    public class CalendarConfigration
    {
        /// <summary>
        /// フォントサイズ
        /// </summary>
        public Color BackColor { get; set; }

        
        /// <summary>
        /// フォント名
        /// </summary>
        public Font YearMonthFont { get; set; }

        /// <summary>
        /// フォント色
        /// </summary>
        public Color YearMonthColor { get; set; }


        /// <summary>
        /// フォント名
        /// </summary>
        public Font WeekFont { get; set; }

        /// <summary>
        /// フォント色
        /// </summary>
        public Color WeekColor { get; set; }

        /// <summary>
        /// フォント色
        /// </summary>
        public Color WeekSundayColor { get; set; }

        /// <summary>
        /// フォント色
        /// </summary>
        public Color WeekSaturndayColor { get; set; }


        /// <summary>
        /// フォント名
        /// </summary>
        public Font DayFont { get; set; }

        /// <summary>
        /// フォント色
        /// </summary>
        public Color DayColor { get; set; }

        /// <summary>
        /// フォント色
        /// </summary>
        public Color DaySundayColor { get; set; }

        /// <summary>
        /// フォント色
        /// </summary>
        public Color DaySaturndayColor { get; set; }


        /// <summary>
        /// フォント色
        /// </summary>
        public Color DayHolidayColor { get; set; }

        /// <summary>
        /// フォント色
        /// </summary>
        public Color DayTodayBackColor { get; set; }

        private const int INITIAL_FONTSIZE = 10;

        public CalendarConfigration(System.Configuration.SettingsBase setting)
        {
            this.BackColor = (Color)setting.PropertyValues["Cal_BackColor"].PropertyValue;
            this.YearMonthFont = (Font)setting.PropertyValues["Cal_YearMonthFont"].PropertyValue;
            this.YearMonthColor = (Color)setting.PropertyValues["Cal_YearMonthColor"].PropertyValue; ;
            this.WeekFont = (Font)setting.PropertyValues["Cal_WeekFont"].PropertyValue;
            this.WeekColor = (Color)setting.PropertyValues["Cal_WeekColor"].PropertyValue; ; ;
            this.WeekSaturndayColor = (Color)setting.PropertyValues["Cal_WeekSaturndayColor"].PropertyValue; ; ;
            this.WeekSundayColor = (Color)setting.PropertyValues["Cal_WeekSundayColor"].PropertyValue; ; ;
            this.DayFont = (Font)setting.PropertyValues["Cal_DayFont"].PropertyValue;
            this.DayColor = (Color)setting.PropertyValues["Cal_DayColor"].PropertyValue; ; ;
            this.DayHolidayColor = (Color)setting.PropertyValues["Cal_DayHolidayColor"].PropertyValue; ; ;
            this.DaySaturndayColor = (Color)setting.PropertyValues["Cal_DaySaturndayColor"].PropertyValue; ; ;
            this.DaySundayColor = (Color)setting.PropertyValues["Cal_DaySundayColor"].PropertyValue; ; ;
            this.DayTodayBackColor = (Color)setting.PropertyValues["Cal_DayTodayBackColor"].PropertyValue; ; ;
        }
    }
}
