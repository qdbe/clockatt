using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace clockatt
{
    /// <summary>
    /// カレンダーの設定値
    /// </summary>
    public class CalendarConfig
    {
        public CalendarConfig()
        {
            this.BackColor = "Control";
            this.FontColor = "ControlText";
            this.FontName = "ＭＳ ゴシック";
            this.FontSize = 9;
            this.HolidayColor = "Red";
            this.SaturDayColor = "Blue";
            this.ShowBorder = true;
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
            set {
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
            set {
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
            set {
                Color tColor = Color.FromName(value);
                pBackColor = value; 
            }
        }

        /// <summary>
        /// 休日のフォント色
        /// </summary>
        private string pHolidayColor;
        public string HolidayColor
        {
            get { return pHolidayColor; }
            set {
                Color tColor = Color.FromName(value);
                pHolidayColor = value; 
            }
        }

        /// <summary>
        /// 土曜日のフォント色
        /// </summary>
        private string pSaturnDayColor;
        public string SaturDayColor
        {
            get { return pSaturnDayColor; }
            set {
                Color tColor = Color.FromName(value);
                pSaturnDayColor = value; 
            }
        }

        /// <summary>
        /// 日曜日のフォント色
        /// </summary>
        private string pSunDayColor;
        public string SunDayColor
        {
            get { return pSunDayColor; }
            set
            {
                Color tColor = Color.FromName(value);
                pSunDayColor = value;
            }
        }

        /// <summary>
        /// 曜日表示のフォント色
        /// </summary>
        private string pWeekColor;
        public string WeekColor
        {
            get { return pWeekColor; }
            set
            {
                Color tColor = Color.FromName(value);
                pWeekColor = value;
            }
        }

        /// <summary>
        /// 曜日と日付の間にボーダーを描画するか否か
        /// </summary>
        private bool pShowBorder = true;
        public bool ShowBorder
        {
            get { return pShowBorder; }
            set { pShowBorder = value; }
        }

    }
}
