using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace clockatt
{
    class clockAttMonthCalendar : Panel
    {
        /// <summary>
        /// 表示開始日付
        /// </summary>
        DateTime pStartDate = DateTime.Now;
        /// <summary>
        /// 表示開始日付
        /// </summary>
        public DateTime StartDate
        {
            get { return pStartDate; }
            set { pStartDate = value; }
        }

        protected const int MaxLinePart = 8;

        protected int mergeSize = 8;

        public clockAttMonthCalendar()
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // 各描画を始める
            // サイズを決める
            int TotalHeight = this.Height;
            int restHeight = TotalHeight;
            int headerHeight = this.Height / MaxLinePart;
            restHeight = restHeight - headerHeight;
            int yobiHeight = this.Height / MaxLinePart;
            restHeight = restHeight - yobiHeight;
            int dayHeight = this.Height / MaxLinePart;

            this.mergeSize = this.Font.Height;

            // 現在の年月
            // 曜日
            // ボーダー
            // 日
        }

    }
}
