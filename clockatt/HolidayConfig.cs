using System;
using System.Collections.Generic;
using System.Text;
using clockatt.ConfigValue;

namespace clockatt
{
    /// <summary>
    /// 休日の設定
    /// </summary>
    public class HolidayConfig
    {

        public const string VERNALEQUINOXDAY = "春分の日";
        public const string AUTUMNEQUINOXDAY = "秋分の日";

        /// <summary>
        /// 開始年
        /// </summary>
        public ConfigYearValue StartYear { get; set; }

        /// <summary>
        /// 終了年
        /// </summary>
        public ConfigYearValue EndYear { get; set; }

        /// <summary>
        /// 月
        /// </summary>
        public ConfigMonthValue Month { get; set; }

        /// <summary>
        /// 日付指定
        /// </summary>
        private ConfigDayValue pDay;
        public ConfigDayValue Day {
            get { return pDay; }
            set
            {
                this.pDayAtWeek.SetAllValue();
                this.pWeekOfMonth.SetAllValue();
                pDay = value;
            }
        }


        /// <summary>
        /// 曜日
        /// </summary>
        private ConfigDayWeekValue pDayAtWeek;
        public ConfigDayWeekValue DayAtWeek
        {
            get { return pDayAtWeek; }
            set
            {
                this.pDay.SetAllValue();
                pDayAtWeek = value;
            }
        }

        /// <summary>
        /// 第 x 週(曜日指定とセットで指定が必要)
        /// </summary>
        private ConfigWeekOfMonthValue pWeekOfMonth;
        public ConfigWeekOfMonthValue WeekOfMonth
        {
            get { return pWeekOfMonth; }
            set
            {
                this.pDay.SetAllValue();
                pWeekOfMonth = value;
            }
        }


        /// <summary>
        /// 休日名称
        /// </summary>
        public ConfigHolidayName HolidayName { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public HolidayConfig()
        {
            this.StartYear = new ConfigYearValue();
            this.EndYear = new ConfigYearValue();
            this.Month = new ConfigMonthValue();
            this.Day = new ConfigDayValue();
            this.DayAtWeek = new ConfigDayWeekValue();
            this.WeekOfMonth = new ConfigWeekOfMonthValue();
            this.HolidayName = new ConfigHolidayName();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="strStartYear"></param>
        /// <param name="?"></param>
        public HolidayConfig(
            string strStartYear,
            string strEndYear,
            string strMonth,
            string strDay,
            string strWeekDay,
            string strWeekOfMonth,
            string strHolidayName
            )
        {
            this.setConfValue(
                strStartYear,
                strEndYear,
                strMonth,
                strDay,
                strWeekDay,
                strWeekOfMonth,
                strHolidayName
                );
        }

        /// <summary>
        /// 値をセットする
        /// </summary>
        /// <param name="strStartYear"></param>
        /// <param name="strEndYear"></param>
        /// <param name="strMonth"></param>
        /// <param name="strDay"></param>
        /// <param name="strWeekDay"></param>
        /// <param name="strWeekOfMonth"></param>
        /// <param name="strHolidayName"></param>
        private void setConfValue(
            string strStartYear,
            string strEndYear,
            string strMonth,
            string strDay,
            string strWeekDay,
            string strWeekOfMonth,
            string strHolidayName
            )
        {
            this.StartYear = new ConfigYearValue(strStartYear,true);
            this.EndYear = new ConfigYearValue(strEndYear,false);
            this.Month = new ConfigMonthValue(strMonth);
            this.pDay = new ConfigDayValue(strDay);
            this.pDayAtWeek = new ConfigDayWeekValue(strWeekDay);
            this.pWeekOfMonth = new ConfigWeekOfMonthValue(strWeekOfMonth);
            this.HolidayName = new ConfigHolidayName(strHolidayName);

            if (this.pDay.IsAllValue == false &&
                this.pDayAtWeek.IsAllValue == false )
            {
                throw new ConfigInitException("日付と曜日は同時に指定できません");
            }

            if (this.pWeekOfMonth.IsAllValue == false &&
                this.pDayAtWeek.IsAllValue == true )
            {
                throw new ConfigInitException("第何週かを指定した場合には曜日も指定する必要があります");
            }
        }

        /// <summary>
        /// 計算による春分の日のチェック
        /// 利用していないが残しておく
        /// </summary>
        /// <param name="yy"></param>
        /// <param name="mm"></param>
        /// <param name="dd"></param>
        /// <returns></returns>
        public static bool IsVernalEquinoxDay(DateTime dt)
        {
            return IsVernalEquinoxDay(dt.Year, dt.Month, dt.Day);
        }

        /// <summary>
        /// 計算による春分の日のチェック
        /// 利用していないが残しておく
        /// </summary>
        /// <param name="yy"></param>
        /// <param name="mm"></param>
        /// <param name="dd"></param>
        /// <returns></returns>
        public static bool IsVernalEquinoxDay(int yy, int mm, int dd)
        {
            if (mm != 3 )
            {
                return false;
            }
            // 春分の日のチェック

            // 西暦年数の4での剰余が0の場合
            // 　　1900年～1956年までは3月21日
            // 　　1960年～2088年までは3月20日
            // 　　2092年～2096年までは3月19日
            if ( yy % 4 == 0 )
            {
                if (1900 <= yy && yy <= 1956 && dd == 21)
                {
                    return true;
                }
                if (1960 <= yy && yy <= 2088 && dd == 20)
                {
                    return true;
                }
                if (2092 <= yy && yy <= 2096 && dd == 19)
                {
                    return true;
                }
            }
            // 西暦年数の4での剰余が1の場合
            // 　　1901年～1989年までは3月21日
            // 　　1993年～2097年までは3月20日
            if (yy % 4 == 1)
            {
                if (1901 <= yy && yy <= 1989 && dd == 21)
                {
                    return true;
                }
                if (1993 <= yy && yy <= 2097 && dd == 20)
                {
                    return true;
                }
            }
            // 西暦年数の4での剰余が2の場合
            // 　　1902年～2022年までは3月21日
            // 　　2026年～2098年までは3月20日
            if (yy % 4 == 2)
            {
                if (1902 <= yy && yy <= 2022 && dd == 21)
                {
                    return true;
                }
                if (2026 <= yy && yy <= 2098 && dd == 20)
                {
                    return true;
                }
            }
            // 西暦年数の4での剰余が3の場合
            // 　　1903年～1923年までは3月22日
            // 　　1927年～2055年までは3月21日
　　        //     2059年～2099年までは3月20日
            if (yy % 4 == 3)
            {
                if (1903 <= yy && yy <= 1923 && dd == 22)
                {
                    return true;
                }
                if (1927 <= yy && yy <= 2055 && dd == 21)
                {
                    return true;
                }
                if (2059 <= yy && yy <= 2099 && dd == 20)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 計算による秋分の日のチェック
        /// 利用していないが残しておく
        /// </summary>
        /// <param name="yy"></param>
        /// <param name="mm"></param>
        /// <param name="dd"></param>
        /// <returns></returns>
        public static bool IsAutumnEquinoxDay(DateTime dt)
        {
            return IsAutumnEquinoxDay(dt.Year, dt.Month, dt.Day);
        }

        /// <summary>
        /// 計算による秋分の日のチェック
        /// 利用していないが残しておく
        /// </summary>
        /// <param name="yy"></param>
        /// <param name="mm"></param>
        /// <param name="dd"></param>
        /// <returns></returns>
        public static bool IsAutumnEquinoxDay(int yy, int mm, int dd)
        {
            if (mm != 9)
            {
                return false;
            }
            // 秋分の日のチェック

            //西暦年数の4での剰余が0の場合
            //  1900年～2008年までは9月23日
            //  2012年～2096年までは9月22日
            if (yy % 4 == 0)
            {
                if (1900 <= yy && yy <= 2008 && dd == 23)
                {
                    return true;
                }
                if (2012 <= yy && yy <= 2096 && dd == 22)
                {
                    return true;
                }
            }
            //西暦年数の4での剰余が1の場合
            //  1901年～1917年までは9月24日
            //  1921年～2041年までは9月23日
            //  2045年～2097年までは9月22日
            if (yy % 4 == 1)
            {
                if (1901 <= yy && yy <= 1917 && dd == 24)
                {
                    return true;
                }
                if (1921 <= yy && yy <= 2041 && dd == 23)
                {
                    return true;
                }
                if (2045 <= yy && yy <= 2097 && dd == 22)
                {
                    return true;
                }
            }
            //西暦年数の4での剰余が2の場合
            //  1902年～1946年までは9月24日
            //  1950年～2074年までは9月23日
            //  2078年～2098年までは9月22日
            if (yy % 4 == 2)
            {
                if (1902 <= yy && yy <= 1946 && dd == 24)
                {
                    return true;
                }
                if (1950 <= yy && yy <= 2074 && dd == 23)
                {
                    return true;
                }
                if (2078 <= yy && yy <= 2098 && dd == 22)
                {
                    return true;
                }
            }

            //西暦年数の4での剰余が3の場合
            //  1903年～1979年までは9月24日
            //  1983年～2099年までは9月23日
            if (yy % 4 == 3)
            {
                if (1903 <= yy && yy <= 1979 && dd == 24)
                {
                    return true;
                }
                if (1983 <= yy && yy <= 2099 && dd == 23)
                {
                    return true;
                }
            }

            return false;
        }


        /// <summary>
        /// 休日かどうかをチェックする
        /// </summary>
        /// <param name="checkdate"></param>
        /// <returns></returns>
        public bool IsHoliday(DateTime checkdate)
        {
            int yy = checkdate.Year;
            int mm = checkdate.Month;
            int dd = checkdate.Day;

            if ( ConfigYearValue.IsYearRange(yy, this.StartYear, this.EndYear) != true ||
                    this.Month.IsSame(mm) != true )
            {
                return false;
            }

            if(this.Day.IsSame(dd) != true)
            {
                return false;
            }

            //第何週目かをチェック
            if( this.WeekOfMonth.IsSame(this.GetWeekOfMonth(dd)) != true )
            {
                return false;
            }

            // 曜日をチェック
            if( this.DayAtWeek.IsSame(checkdate.DayOfWeek) != true)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 何週目かを指定する
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        private int GetWeekOfMonth(int day)
        {
            return (day - 1) / 7 + 1;
        }
    }
}
