using System;
using System.Drawing;
using System.Windows.Forms;

namespace clockatt
{
    interface ICalenderDayPanel
    {
        void HideMe();
        event PaintEventHandler DrawDay;
        CalenderDayInfo DayInfo {get;}
        void SetDrawInfo(CalenderDayInfo dayInfo);
        void SetBackColor(Color backColor);
    }
}
