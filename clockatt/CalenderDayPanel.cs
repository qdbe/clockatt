using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace clockatt
{
    class CalenderDayPanel : Panel, clockatt.ICalenderDayPanel
    {
        /// <summary>
        /// 表示する日
        /// </summary>
        public int DispDay { get; private set; }

        /// <summary>
        /// 休日名称を表示する為のToolTip
        /// </summary>
        private ToolTip holidayTooltip = new ToolTip();

        /// <summary>
        /// 日の描画イベントハンドラ
        /// </summary>
        public event PaintEventHandler DrawDay = null;

        /// <summary>
        /// 出力日の情報
        /// </summary>
        public CalenderDayInfo DayInfo
        {
            get;
            private set;
        }


        /// <summary>
        /// マウスクリック時のハンドラ
        /// </summary>
        public event MouseEventHandler MouseDownOnDay = null;

        /// <summary>
        /// private コンストラクタ
        /// </summary>
        private CalenderDayPanel() : base()
        {
            this.BorderStyle = BorderStyle.None;
            this.MouseDown += new MouseEventHandler(CalenderDayPanel_MouseDown);
        }

        /// <summary>
        /// コンストラクタはこのメソッドを通じてのみ行う
        /// </summary>
        /// <param name="parents"></param>
        /// <param name="createCount"></param>
        /// <param name="mouseDownDay"></param>
        /// <returns></returns>
        public static CalenderDayPanel[] CreatePanels(Control parents, int createCount, MouseEventHandler mouseDownDay)
        {
            parents.SuspendLayout();

            CalenderDayPanel[] panels = new CalenderDayPanel[createCount];

            for (int i = 0; i < panels.Length; i++)
            {
                panels[i] = new CalenderDayPanel();
                panels[i].MouseDownOnDay += mouseDownDay;
                parents.Controls.Add(panels[i]);
            }
            parents.ResumeLayout();
            return panels;
        }

        /// <summary>
        /// 左クリック時は年月の切り替えを行う
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CalenderDayPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // 月日の変更を実施する
                if (this.MouseDownOnDay != null)
                {
                    MouseEventArgs args = new MouseEventArgs(
                        e.Button,
                        e.Clicks,
                        e.X + this.Location.X,
                        e.Y + this.Location.Y,
                        e.Delta);

                    this.MouseDownOnDay(Parent, args);
               }
            }
        }

        /// <summary>
        /// 描画は独自に実施
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if( this.DrawDay != null )
            {
                this.DrawDay(this, e);
            }
        }

        /// <summary>
        /// 背景色を設定する
        /// </summary>
        /// <param name="backColor"></param>
        public void SetBackColor(Color backColor)
        {
            this.BackColor = backColor;
        }


        /// <summary>
        /// 自身を描画しないようにする
        /// </summary>
        public void HideMe()
        {
            this.Visible = false;
            this.ClearToolTip();
        }

        /// <summary>
        /// 描画情報を初期化する
        /// </summary>
        /// <param name="dayInfo"></param>
        public void SetDrawInfo(CalenderDayInfo dayInfo)
        {
            this.Location = dayInfo.DispRect.Location;
            this.Width = dayInfo.DispRect.Width;
            this.Height = dayInfo.DispRect.Height;
            this.Visible = true;
            this.SetToolTip(dayInfo.HolidayName);
            
            this.DayInfo = dayInfo;
            this.DispDay = dayInfo.DispDay.Day;
            this.DrawDay = null;
        }

        /// <summary>
        /// ツールチップを設定する
        /// </summary>
        /// <param name="strValue"></param>
        public void SetToolTip(string strValue)
        {
            this.holidayTooltip.SetToolTip(this,strValue);
        }

        /// <summary>
        /// ツールチップをクリアする
        /// </summary>
        public void ClearToolTip()
        {
            this.holidayTooltip.SetToolTip(this, "");
        }

    }
}
