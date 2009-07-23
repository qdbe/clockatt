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
        public static string GetFormatDateTime(
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

            StringBuilder weekTimeBuilder = new StringBuilder();
            weekTimeBuilder.Append(nc.ToString(formatString.ToString()));
            if (isShowWeek == true)
            {
                weekTimeBuilder.Append("(");
                if (isWeekWareki == true)
                {
                    switch (nc.DayOfWeek)
                    {
                        case DayOfWeek.Monday:
                            weekTimeBuilder.Append("月");
                            break;
                        case DayOfWeek.Tuesday:
                            weekTimeBuilder.Append("火");
                            break;
                        case DayOfWeek.Wednesday:
                            weekTimeBuilder.Append("水");
                            break;
                        case DayOfWeek.Thursday:
                            weekTimeBuilder.Append("木");
                            break;
                        case DayOfWeek.Friday:
                            weekTimeBuilder.Append("金");
                            break;
                        case DayOfWeek.Saturday:
                            weekTimeBuilder.Append("土");
                            break;
                        case DayOfWeek.Sunday:
                            weekTimeBuilder.Append("日");
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (nc.DayOfWeek)
                    {
                        case DayOfWeek.Monday:
                            weekTimeBuilder.Append("Mon");
                            break;
                        case DayOfWeek.Tuesday:
                            weekTimeBuilder.Append("Tue");
                            break;
                        case DayOfWeek.Wednesday:
                            weekTimeBuilder.Append("Wed");
                            break;
                        case DayOfWeek.Thursday:
                            weekTimeBuilder.Append("Thu");
                            break;
                        case DayOfWeek.Friday:
                            weekTimeBuilder.Append("Fri");
                            break;
                        case DayOfWeek.Saturday:
                            weekTimeBuilder.Append("Sat");
                            break;
                        case DayOfWeek.Sunday:
                            weekTimeBuilder.Append("Sun");
                            break;
                        default:
                            break;
                    }
                }
                weekTimeBuilder.Append(")");
            }

            if (isShowTime == true)
            {
                if (isShowSecond == true)
                {
                    weekTimeBuilder.Append(" " + nc.ToLongTimeString());
                }
                else
                {
                    weekTimeBuilder.Append(" " + nc.ToShortTimeString());
                }
            }
            return weekTimeBuilder.ToString();
        }
    }
}
