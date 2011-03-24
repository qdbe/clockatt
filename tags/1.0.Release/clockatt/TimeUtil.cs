using System;
using System.Collections.Generic;
using System.Text;

namespace clockatt
{
    /// <summary>
    /// 日時フォーマット用ツールクラス
    /// </summary>
    static public class DateTimeFormatUtil
    {
        /// <summary>
        /// 設定に基づき描画する日時文字列を作成する
        /// </summary>
        /// <param name="nc"></param>
        /// <param name="isShowYear"></param>
        /// <param name="isShowWeek"></param>
        /// <param name="isWeekWareki"></param>
        /// <param name="isShowTime"></param>
        /// <param name="isShowSecond"></param>
        /// <returns></returns>
        public static string GetFormatedDateTime(
            DateTime nc, 
            bool isShowYear,
            bool isShowWeek,
            bool isWeekWareki,
            bool isShowTime,
            bool isShowSecond
            )
        {
            StringBuilder formatString = new StringBuilder();

            if (isShowYear == true)
            {
                formatString.Append("yyyy/");
            }
            formatString.Append("MM/dd");

            if (isShowWeek == true)
            {
                formatString.Append("(ddd)");
            }

            if (isShowTime == true)
            {
                if (isShowSecond == true)
                {
                    formatString.Append(" HH:mm:ss");
                }
                else
                {
                    formatString.Append(" HH:mm");
                }
            }

            IFormatProvider culture;
            if (isWeekWareki)
            {
                culture = System.Globalization.CultureInfo.CurrentCulture;
            }
            else
            {
                culture = System.Globalization.CultureInfo.InvariantCulture;
            }
            return nc.ToString(formatString.ToString(), culture);
        }
    }
}
