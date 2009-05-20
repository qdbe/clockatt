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
            string strWeekOfMonth
            )
        {
            this.setConfValue(
                strStartYear,
                strEndYear,
                strMonth,
                strDay,
                strWeekDay,
                strWeekOfMonth
                );
        }

        private void setConfValue(
            string strStartYear,
            string strEndYear,
            string strMonth,
            string strDay,
            string strWeekDay,
            string strWeekOfMonth
            )
        {
            this.pStartYear = new ConfigYearValue(strStartYear,true);
            this.pEndYear = new ConfigYearValue(strEndYear,false);
            this.pMonth = new ConfigMonthValue(strMonth);
            this.pDay = new ConfigDayValue(strDay);
            this.pDayWeek = new ConfigDayWeekValue(strWeekDay);
            this.pWeekOfMonth = new ConfigWeekOfMonthValue(strWeekOfMonth);
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
