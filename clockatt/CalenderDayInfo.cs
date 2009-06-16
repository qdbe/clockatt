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
            set { pDispDay = value; }
        }

        /// <summary>
        /// 休日か否か
        /// </summary>
        private bool pIsHoliday = false;
        public bool IsHoliday
        {
          get { return pIsHoliday; }
          set { pIsHoliday = value; }
        }

        /// <summary>
        /// 休日名称
        /// </summary>
        private string pHolidayName;
        public string HolidayName
        {
          get { return pHolidayName; }
          set { pHolidayName = value; }
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

        public CalenderDayInfo(DateTime dt, Rectangle rect, HolidayConfigCollection holidays)
        {
            this.DispDay = dt;
            this.DispRect = rect;
            HolidayConfig hconf = holidays.GetHolidayInfo(dt);
            if( hconf != null )
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

        public void SetToolTip(Control con, ToolTip tooltip)
        {
            if (this.IsHoliday == true)
            {
                tooltip.SetToolTip(con, this.HolidayName);
            }
            else
            {
                tooltip.SetToolTip(con, string.Empty);
            }
        }
    }
}
