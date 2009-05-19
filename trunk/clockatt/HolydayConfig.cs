using System;
using System.Collections.Generic;
using System.Text;

namespace clockatt
{
    /// <summary>
    /// 休日の設定
    /// </summary>
    public class HolydayConfig
    {
        /// <summary>
        /// 曜日
        /// </summary>
        /// <remarks>DayOfWeek は指定がないな状態を表せないので独自に定義</remarks>

        public enum Column
        {
            StartYear = 1,
            EndYear,
            Month,
            Day,
            WeekDay,
            Week
        }

        /// <summary>
        /// 年の最低値
        /// </summary>
        private const int minYear = 0;

        /// <summary>
        /// 年の最大値
        /// </summary>
        private const int maxYear = 9999;

        /// <summary>
        /// 特定値がセットされていないことを指す
        /// </summary>
        public const int ALLVALUE = -1;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public HolydayConfig()
        {
            this.pStartYear = ALLVALUE;
            this.pEndYear = ALLVALUE;
            this.pMonth = ALLVALUE;
            this.pDay = ALLVALUE;
            this.pWeekOfMonth = ALLVALUE;
            this.pDayWeek = DayWeek.ALLVALUE;
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
            this.pStartYear = this.GetYear(strStartYear);
            this.pEndYear = this.GetYear(strEndYear);
            this.pMonth = this.GetMonth(strMonth);
            this.pDay = this.GetDay(strDay);
            this.pDayWeek = this.GetWeekDay();


        }



        /// <summary>
        /// 開始年
        /// </summary>
        private int pStartYear;
        public int StartYear
        {
            get { return pStartYear; }
            set { pStartYear = value; }
        }

        /// <summary>
        /// 終了年
        /// </summary>
        private int pEndYear;
        public int EndYear
        {
            get { return pEndYear; }
            set { pEndYear = value; }
        }

        /// <summary>
        /// 月
        /// </summary>
        private int pMonth;
        public int Month
        {
            get { return pMonth; }
            set { pMonth = value; }
        }

        /// <summary>
        /// 日付指定
        /// </summary>
        private int pDay;
        public int Day
        {
            get { return pDay; }
            set {
                this.pDayWeek = DayWeek.ALLVALUE;
                this.pWeekOfMonth = ALLVALUE;
                pDay = value; 
            }
        }


        /// <summary>
        /// 曜日
        /// </summary>
        private DayWeek pDayWeek;
        public DayWeek DayAtWeek
        {
            get { return pDayWeek; }
            set {
                this.pDay = ALLVALUE;
                pDayWeek = value; 
            }
        }

        /// <summary>
        /// 第 x 週(曜日指定とセットで指定が必要)
        /// </summary>
        private int pWeekOfMonth;
        public int WeekOfMonth
        {
            get { return pWeekOfMonth; }
            set {
                this.pDay = ALLVALUE;
                pWeekOfMonth = value; 
            }
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

            if (IsYearRange(yy, this.StartYear, this.EndYear) != true ||
                    IsSame(mm, this.Month) != true )
            {
                return false;
            }

            if(IsSame(dd, this.Day) != true)
            {
                return false;
            }

            //第何週目かをチェック
            if( IsSame(this.GetWeekOfMonth(dd),this.WeekOfMonth) != true )
            {
                return false;
            }

            // 曜日をチェック
            if( IsSame(checkdate.DayOfWeek,this.DayAtWeek) != true)
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

        /// <summary>
        /// 年が指定範囲の間かどうかをチェックする
        /// </summary>
        /// <param name="yy"></param>
        /// <param name="st"></param>
        /// <param name="ed"></param>
        /// <returns></returns>
        private bool IsYearRange(int yy, int st, int ed)
        {
            if (st == ALLVALUE )
            {
                st = minYear;
            }
            if (ed == ALLVALUE)
            {
                ed = maxYear;
            }
            if (yy >= st && yy <= ed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 値が同じか否かをチェックする
        /// </summary>
        /// <param name="checkValue"></param>
        /// <param name="settingValue"></param>
        /// <returns></returns>
        private bool IsSame(int checkValue,int settingValue)
        {
            if (settingValue == ALLVALUE)
            {
                return true;
            }
            else if (settingValue == checkValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 値が同じか否かをチェックする
        /// </summary>
        /// <param name="checkValue"></param>
        /// <param name="settingValue"></param>
        /// <returns></returns>
        private bool IsSame(DayOfWeek checkValue, DayWeek settingValue)
        {
            if (settingValue == DayWeek.ALL ||
                settingValue == DayWeek.Mon && checkValue == DayOfWeek.Monday ||
                settingValue == DayWeek.Tue && checkValue == DayOfWeek.Tuesday ||
                settingValue == DayWeek.Wed && checkValue == DayOfWeek.Wednesday ||
                settingValue == DayWeek.Thu && checkValue == DayOfWeek.Thursday ||
                settingValue == DayWeek.Fri && checkValue == DayOfWeek.Friday ||
                settingValue == DayWeek.Sat && checkValue == DayOfWeek.Saturday ||
                settingValue == DayWeek.Sun && checkValue == DayOfWeek.Sunday
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool isWildCard(string words)
        {
            if (words == "*")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int GetInt(string rLine, string[] lineCols, int Cols)
        {
            string words = lineCols[Cols];
            if (isWildCard(words) == true)
            {
                return HolydayConfig.ALLVALUE;
            }
            else
            {
                int result;
                if (int.TryParse(words, out result) == true)
                {
                    return result;
                }
                else
                {
                    throw new ApplicationException(ERRMSG + rLine);
                }
            }
        }

    }
}
