using System;
using System.Collections.Generic;
using System.Text;

namespace clockatt
{
    static public class TimeUtil
    {
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
            StringBuilder weekTime = new StringBuilder();

            if (isShowYear == true)
            {
                formatString.Append("yyyy/");
            }
            formatString.Append("MM/dd");
            weekTime.Append(nc.ToString(formatString.ToString()));
            if (isShowWeek == true)
            {
                weekTime.Append("(");
                if (isWeekWareki == true)
                {
                    switch (nc.DayOfWeek)
                    {
                        case DayOfWeek.Monday:
                            weekTime.Append("月");
                            break;
                        case DayOfWeek.Tuesday:
                            weekTime.Append("火");
                            break;
                        case DayOfWeek.Wednesday:
                            weekTime.Append("水");
                            break;
                        case DayOfWeek.Thursday:
                            weekTime.Append("木");
                            break;
                        case DayOfWeek.Friday:
                            weekTime.Append("金");
                            break;
                        case DayOfWeek.Saturday:
                            weekTime.Append("土");
                            break;
                        case DayOfWeek.Sunday:
                            weekTime.Append("日");
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
                            weekTime.Append("Mon");
                            break;
                        case DayOfWeek.Tuesday:
                            weekTime.Append("Tue");
                            break;
                        case DayOfWeek.Wednesday:
                            weekTime.Append("Wed");
                            break;
                        case DayOfWeek.Thursday:
                            weekTime.Append("Thu");
                            break;
                        case DayOfWeek.Friday:
                            weekTime.Append("Fri");
                            break;
                        case DayOfWeek.Saturday:
                            weekTime.Append("Sat");
                            break;
                        case DayOfWeek.Sunday:
                            weekTime.Append("Sun");
                            break;
                        default:
                            break;
                    }
                }
                weekTime.Append(")");
            }

            if (isShowTime == true)
            {
                if (isShowSecond == true)
                {
                    weekTime.Append(" " + nc.ToLongTimeString());
                }
                else
                {
                    weekTime.Append(" " + nc.ToShortTimeString());
                }
            }
            return weekTime.ToString();
        }
    }
}
