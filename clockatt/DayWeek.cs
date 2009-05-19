using System;
using System.Collections.Generic;
using System.Text;

namespace clockatt
{
    public class DayWeek
    {

        public static readonly DayWeek ALLVALUE = new DayWeek();

        public static readonly int ALL = 0;
        public static readonly int Mon = 1;
        public static readonly int Tue = 2;
        public static readonly int Wed = 3;
        public static readonly int Thu = 4;
        public static readonly int Fri = 5;
        public static readonly int Sat = 6;
        public static readonly int Sun = 7;

        private int currentValue;

        private string[] strDayWeek = new string[]{
        "ALL",
        "Mon",
        "Tue",
        "Wed",
        "Thu",
        "Fri",
        "Sat",
        "Sun"
        };
 
        private string[] strLongDayWeek = new string[]{
        "ALL",
        "Monday",
        "Tuesday",
        "Wednesday",
        "Thursday",
        "Friday",
        "Saturnday",
        "Sunday"
        };

        private string[] strJpDayWeek = new string[]{
        "ALL",
        "月",
        "火",
        "水",
        "木",
        "金",
        "土",
        "日"
        };

        private string[] strLongJpDayWeek = new string[]{
        "ALL",
        "月曜日",
        "火曜日",
        "水曜日",
        "木曜日",
        "金曜日",
        "土曜日",
        "日曜日"
        };

        public DayWeek()
        {
            this.currentValue = ALL;
        }

        public DayWeek(string strValue)
        {
        }

    }
}
