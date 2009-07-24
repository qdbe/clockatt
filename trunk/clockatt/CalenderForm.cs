using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using clockatt.Configration;

namespace clockatt
{
    /// <summary>
    /// カレンダー表示クラス
    /// </summary>
    public partial class CalenderForm : Form
    {
        /// <summary>
        /// 描画開始位置 X
        /// </summary>
        private const int StartLeft = 10;

        /// <summary>
        /// 描画開始位置 Y
        /// </summary>
        private const int StartTop = 5;

        /// <summary>
        /// 現在表示中の年
        /// </summary>
        private int DispYear{ get; set; }
        /// <summary>
        /// 現在表示中の月
        /// </summary>
        private int DispMonth { get; set; }

        /// <summary>
        /// 呼び出し元フォーム(親の位置に合わせてダイアログを表示するため)
        /// </summary>
        private Form CallerForm { get; set; }

        /// <summary>
        /// 休日設定
        /// </summary>
        private HolidayConfigCollection[] pHolidays;

        /// <summary>
        /// カレンダー 日表示設定
        /// </summary>
        private CalenderDrawInfo dayInfos;

        /// <summary>
        /// 日表示用パネル 常に31日分を保持する
        /// </summary>
        private CalenderDayPanel []dayPanes;

        /// <summary>
        /// カレンダーの表示用設定
        /// </summary>
        private CalendarConfigration Config { get; set; }


        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="holidays"></param>
        /// <param name="config"></param>
        public CalenderForm(Form parent, HolidayConfigCollection[] holidays, CalendarConfigration config)
        {
            this.CallerForm = parent;
            this.Config = config;
            this.pHolidays = holidays;
            this.BackColor = config.BackColor;

            InitializeComponent();

            SetDisplayDateTime(DateTime.Now);

            CreateChildControls();

            SetPaintLocationInfo();

            InvalidateWithChild();
        }

        /// <summary>
        /// 描画用に日のパネルと描画情報を生成する
        /// </summary>
        private void CreateChildControls()
        {
            this.dayInfos = new CalenderDrawInfo(this.pHolidays, this.Config);
            this.dayPanes = CalenderDayPanel.CreatePanels(this, CalenderDrawInfo.MaxDayCount, new MouseEventHandler(DoMouseClick));
        }

        /// <summary>
        /// 再描画を実施する
        /// </summary>
        private void InvalidateWithChild()
        {
            this.Invalidate(true);
        }

        /// <summary>
        /// 描画する年月に応じた描画位置情報を設定し、必要なサイズに自身をセットする
        /// </summary>
        private void SetPaintLocationInfo()
        {
            Size needSize = dayInfos.SetLocation(
                StartLeft,
                StartTop,
                this.DispYear,
                this.DispMonth,
                dayPanes,
                this.CreateGraphics());
            this.Size = needSize;
            ResetPos(needSize);
        }

        /// <summary>
        /// 描画する年月を設定する
        /// </summary>
        /// <param name="dt"></param>
        private void SetDisplayDateTime(DateTime dt)
        {
            this.DispYear = dt.Year;
            this.DispMonth = dt.Month;
        }

        /// <summary>
        /// 自身の表示位置を設定する
        /// </summary>
        /// <param name="needSize"></param>
        private void ResetPos(Size needSize)
        {
            // 親の右端から
            Point newpos = this.CallerForm.Location;
            newpos.X += this.CallerForm.Width;
            newpos.Y += this.CallerForm.Height;

            newpos.X -= needSize.Width;
            if (newpos.X <= 0)
            {
                newpos.X = 0;
            }
            if (newpos.X + needSize.Width > Screen.PrimaryScreen.WorkingArea.Width)
            {
                newpos.X = Screen.PrimaryScreen.WorkingArea.Width - needSize.Width;
            }

            if (newpos.Y <= 0)
            {
                newpos.Y = 0;
            }
            if (newpos.Y + needSize.Height > Screen.PrimaryScreen.WorkingArea.Height)
            {
                newpos.Y = Screen.PrimaryScreen.WorkingArea.Height - needSize.Height;
            }

            this.Location = newpos;
        }

        /// <summary>
        /// 描画は独自で実施
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SetClip(e.ClipRectangle);
            this.dayInfos.Draw(e.ClipRectangle, e.Graphics);
        }


        /// <summary>
        /// カレンダー上をマウスクリックされた場合の処置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CalenderForm_MouseDown(object sender, MouseEventArgs e)
        {
            this.DoMouseClick(sender, e);
        }

        /// <summary>
        /// カレンダー上をマウスクリックされた場合の処置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DoMouseClick(object sender, MouseEventArgs e)
        {
            DoMonthPaging(e.X);

            SetPaintLocationInfo();

            InvalidateWithChild();
        }

        /// <summary>
        /// クリックされた位置に基づき表示する年・月を前後に移動する
        /// </summary>
        /// <param name="x"></param>
        private void DoMonthPaging(int x)
        {

            int limits = this.Width / 2;

            DateTime dt = new DateTime(this.DispYear, this.DispMonth, 1);
            if (x < limits)
            {
                dt = dt.AddMonths(-1);
            }
            else
            {
                dt = dt.AddMonths(1);
            }
            SetDisplayDateTime(dt);
        }

        /// <summary>
        /// 自身のフォーカスを失った場合には、自動的に閉じる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CalenderForm_LostFocus(object sender, System.EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// エスケープキーでも自身を閉じる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalenderForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }

}
