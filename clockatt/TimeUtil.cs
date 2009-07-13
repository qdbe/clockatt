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
                formatString.Append("(");
                switch (nc.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        formatString.Append("月");
                        break;
                    case DayOfWeek.Tuesday:
                        formatString.Append("火");
                        break;
                    case DayOfWeek.Wednesday:
                        formatString.Append("水");
                        break;
                    case DayOfWeek.Thursday:
                        formatString.Append("木");
                        break;
                    case DayOfWeek.Friday:
                        formatString.Append("金");
                        break;
                    case DayOfWeek.Saturday:
                        formatString.Append("土");
                        break;
                    case DayOfWeek.Sunday:
                        formatString.Append("日");
                        break;
                    default:
                        break;
                }
                formatString.Append(")");
            }

            if (isShowTime == true)
            {
                if (isShowSecond == true)
                {
                    formatString.Append(" " + nc.ToLongTimeString());
                }
                else
                {
                    formatString.Append(" " + nc.ToShortTimeString());
                }
            }
            return nc.ToString(formatString.ToString());
        }
    }
}
