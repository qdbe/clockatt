using System;
using System.Collections.Generic;
using System.Text;
using clockatt.ConfigValue;

namespace clockatt
{
    /// <summary>
    /// 休日の設定
    /// </summary>
    public class HolydayConfig
    {

        /// <summary>
        /// 開始年
        /// </summary>
        private ConfigYearValue pStartYear;
        public ConfigYearValue StartYear
        {
            get { return pStartYear; }
            set { pStartYear = value; }
        }

        /// <summary>
        /// 終了年
        /// </summary>
        private ConfigYearValue pEndYear;
        public ConfigYearValue EndYear
        {
            get { return pEndYear; }
            set { pEndYear = value; }
        }

        /// <summary>
        /// 月
        /// </summary>
        private ConfigMonthValue pMonth;
        public ConfigMonthValue Month
        {
            get { return pMonth; }
            set { pMonth = value; }
        }

        /// <summary>
        /// 日付指定
        /// </summary>
        private ConfigDayValue pDay;
        public ConfigDayValue Day
        {
            get { return pDay; }
            set
            {
                this.pDayWeek.SetAllValue();
                this.pWeekOfMonth.SetAllValue();
                pDay = value;
            }
        }


        /// <summary>
        /// 曜日
        /// </summary>
        private ConfigDayWeekValue pDayWeek;
        public ConfigDayWeekValue DayAtWeek
        {
            get { return pDayWeek; }
            set
            {
                this.pDay.SetAllValue();
                pDayWeek = value;
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
        private ConfigHolidayName pHolidayName;

        public ConfigHolidayName HolidayName
        {
            get { return pHolidayName; }
            set { pHolidayName = value; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public HolydayConfig()
        {
            this.pStartYear = new ConfigYearValue();
            this.pEndYear = new ConfigYearValue();
            this.pMonth = new ConfigMonthValue();
            this.pDay = new ConfigDayValue();
            this.pDayWeek = new ConfigDayWeekValue();
            this.pWeekOfMonth = new ConfigWeekOfMonthValue();
            this.pHolidayName = new ConfigHolidayName();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="strStartYear"></param>
        /// <param name="?"></param>
        public HolydayConfig(
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
            this.pStartYear = new ConfigYearValue(strStartYear,true);
            this.pEndYear = new ConfigYearValue(strEndYear,false);
            this.pMonth = new ConfigMonthValue(strMonth);
            this.pDay = new ConfigDayValue(strDay);
            this.pDayWeek = new ConfigDayWeekValue(strWeekDay);
            this.pWeekOfMonth = new ConfigWeekOfMonthValue(strWeekOfMonth);
            this.pHolidayName = new ConfigHolidayName(strHolidayName);

            if (this.pDay.IsAllValue == false &&
                this.pDayWeek.IsAllValue == false )
            {
                throw new ConfigInitException("日付と曜日は同時に指定できません");
            }

            if (this.pWeekOfMonth.IsAllValue == false &&
                this.pDayWeek.IsAllValue == true )
            {
                throw new ConfigInitException("第何週かを指定した場合には曜日も指定する必要があります");
            }
        }

        /// <summary>
        /// 春分の日のチェック
        /// </summary>
        /// <param name="yy"></param>
        /// <param name="mm"></param>
        /// <param name="dd"></param>
        /// <returns></returns>
        protected bool isVernalEquinoxDay(int yy, int mm, int dd)
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
        /// 春分の日のチェック
        /// </summary>
        /// <param name="yy"></param>
        /// <param name="mm"></param>
        /// <param name="dd"></param>
        /// <returns></returns>
        protected bool isAutumnEquinoxDay(int yy, int mm, int dd)
        {
            if (mm != 9)
            {
                return false;
            }
            // 春分の日のチェック

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
        public bool IsHolyday(DateTime checkdate)
        {
            int yy = checkdate.Year;
            int mm = checkdate.Month;
            int dd = checkdate.Day;

            if (isVernalEquinoxDay(yy, mm, dd) == true ||
                isAutumnEquinoxDay(yy, mm, dd) == true)
            {
                return true;
            }

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
