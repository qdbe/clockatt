using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace clockatt
{
    public class ClockConfig
    {
        /// <summary>
        /// カレンダーに関する設定値
        /// </summary>
        private CalendarConfig pCalendarConfig;
        internal CalendarConfig Calendar
        {
            get { return pCalendarConfig; }
            set { pCalendarConfig = value; }
        }

        /// <summary>
        /// フォントサイズ
        /// </summary>
        private int pFontSize;
        public int FontSize
        {
            get { return pFontSize; }
            set { pFontSize = value; }
        }

        /// <summary>
        /// フォント名
        /// </summary>
        private string pFontName;
        public string FontName
        {
            get { return pFontName; }
            set
            {
                Font tFont = new Font(value, 9);
                pFontName = value;
            }
        }

        /// <summary>
        /// フォント色
        /// </summary>
        private string pFontColor;
        public string FontColor
        {
            get { return pFontColor; }
            set
            {
                Color tColor = Color.FromName(value);
                pFontColor = value;
            }
        }

        /// <summary>
        /// 背景色
        /// </summary>
        private string pBackColor;
        public string BackColor
        {
            get { return pBackColor; }
            set
            {
                Color tColor = Color.FromName(value);
                pBackColor = value;
            }
        }

        public ClockConfig()
        {
            this.BackColor = "Control";
            this.FontColor = "ControlText";
            this.FontName = "ＭＳ ゴシック";
            this.FontSize = 9;
            this.Calendar = new CalendarConfig();
        }
    }
}
