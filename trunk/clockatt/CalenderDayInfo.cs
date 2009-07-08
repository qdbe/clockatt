using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace clockatt
{
    public class CalenderDayInfo
    {
        /// <summary>
        /// 表示する日付
        /// </summary>
        DateTime pDispDay;
        public DateTime DispDay
        {
            get { return pDispDay; }
        }

        /// <summary>
        /// 休日か否か
        /// </summary>
        private bool pIsHoliday = false;
        public bool IsHoliday
        {
          get { return pIsHoliday; }
        }

        /// <summary>
        /// 土曜日か否か
        /// </summary>
        private bool pIsSaturday = false;
        public bool IsSaturday
        {
            get { return pIsSaturday; }
        }

        /// <summary>
        /// 日曜日か否か
        /// </summary>
        private bool pIsSunday = false;
        public bool IsSunday
        {
            get { return pIsSunday; }
        }

        public string GetDispStr()
        {
            return string.Format("{0, 2}", this.pDispDay.Day);
        }

        /// <summary>
        /// 今日か否か(システム日付で判断)
        /// </summary>
        public bool IsToday
        {
            get
            {
                if (this.pDispDay.Date.CompareTo(DateTime.Now.Date) == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 休日名称
        /// </summary>
        private string pHolidayName;
        public string HolidayName
        {
          get { return pHolidayName; }
        }

        /// <summary>
        /// 該当日を表示する矩形
        /// </summary>
        Rectangle pDispRect;
        public Rectangle DispRect
        {
            get { return pDispRect; }
            set { pDispRect = value; }
        }

        public CalenderDayInfo(DateTime dt, Rectangle rect, HolidayConfigCollection []holidays)
        {
            this.pDispDay = dt;
            this.pDispRect = rect;
            this.pHolidayName = string.Empty;
            for (int i = 0; i < holidays.Length; i++)
            {
                HolidayConfig hconf = holidays[i].GetHolidayInfo(dt);
                if (hconf != null)
                {
                    this.pHolidayName = hconf.HolidayName.CurrentValue;
                    this.pIsHoliday = true;
                }
                else
                {
                    this.pHolidayName = string.Empty;
                    this.pIsHoliday = false;
                }
            }
            if (dt.DayOfWeek == DayOfWeek.Saturday)
            {
                this.pIsSaturday = true;
            }
            if (dt.DayOfWeek == DayOfWeek.Sunday)
            {
                this.pIsSunday = true;
            }
        }
    }
}
