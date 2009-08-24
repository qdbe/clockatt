using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using clockatt.Configration;

namespace clockatt
{
    public class CalendarPanel : Panel
    {
        private void InitializeComponent()
        {
            this.dayToolTip = new System.Windows.Forms.ToolTip();
            this.SuspendLayout();
            // 
            // dayToolTip
            // 
            this.dayToolTip.AutoPopDelay = 5000;
            this.dayToolTip.InitialDelay = 100;
            this.dayToolTip.ReshowDelay = 100;
            // 
            // CalenderForm
            // 
            this.BackColor = global::clockatt.Properties.Settings.Default.Cal_BackColor;
            this.ClientSize = new System.Drawing.Size(178, 208);
            this.Font = global::clockatt.Properties.Settings.Default.Cal_Font;
            this.ForeColor = global::clockatt.Properties.Settings.Default.Cal_ForeColor;
            this.Name = "CalenderForm";
            this.Text = "CalenderForm";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CalenderPanel_MouseDown);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ToolTip dayToolTip;

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
        private Form Caller { get; set; }

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

        private bool isInitialized = false;

        /// <summary>
        /// パネルのサイズ変更があった場合のイベント
        /// </summary>
        /// 
        private event SizeChangedEventHandler pPanelSizeChanged = null;
        public event SizeChangedEventHandler PanelSizeChanged
        {
            add { this.pPanelSizeChanged += value; }
            remove { this.pPanelSizeChanged -= value; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CalendarPanel()
        {
            InitializeComponent();
            SetDisplayDateTime(DateTime.Now);
        }


        /// <summary>
        /// 初期化処理
        /// 当パネルを生成した後、この処理を実施しないと描画されない
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="holidays"></param>
        /// <param name="config"></param>
        public void Initialize(Form parent, HolidayConfigCollection[] holidays, CalendarConfigration config)
        {
            this.Caller = parent;
            this.Config = config;
            this.pHolidays = holidays;
            this.BackColor = config.BackColor;

            SetDisplayDateTime(DateTime.Now);

            CreateChildControls();

            SetPaintLocationInfo();

            this.isInitialized = true;

            InvalidateWithChild();
        }

        /// <summary>
        /// 描画用に日のパネルと描画情報を生成する
        /// </summary>
        private void CreateChildControls()
        {
            this.dayInfos = new CalenderDrawInfo(this.pHolidays, this.Config);
            this.dayPanes = CalenderDayPanel.CreatePanels(this, new MouseEventHandler(DoMouseClick));
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

            SizeChangedEventArgs sizeChangeArg = new SizeChangedEventArgs(this.Size, needSize);

            this.Size = needSize;
            ResetCallerSize(sizeChangeArg);
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
        private void ResetCallerSize(SizeChangedEventArgs sizeChangeArg)
        {
            if (this.pPanelSizeChanged != null)
            {
                this.pPanelSizeChanged(this, sizeChangeArg);
            }
        }

        /// <summary>
        /// 描画は独自で実施
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.DesignMode == true) return;
            if (this.isInitialized == false) return;

            e.Graphics.SetClip(e.ClipRectangle);
            this.dayInfos.Draw(e.ClipRectangle, e.Graphics);
        }


        /// <summary>
        /// カレンダー上をマウスクリックされた場合の処置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CalenderPanel_MouseDown(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("CalenderForm_MouseDown");
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

    }

    /// <summary>
    /// サイズ変更に伴う情報の引数
    /// </summary>
    public class SizeChangedEventArgs : EventArgs
    {
        /// <summary>
        /// 以前のサイズ
        /// </summary>
        public Size OldSize { get; private set; }
        /// <summary>
        /// 新しいサイズ
        /// </summary>
        public Size NewSize { get; private set; }
        /// <summary>
        /// サイズの差分
        /// </summary>
        public Size DiffSize { get; private set; }

        public SizeChangedEventArgs(Size oldSize, Size newSize)
        {

            this.OldSize = new Size(oldSize.Width, oldSize.Height);
            this.NewSize = new Size(newSize.Width, newSize.Height);
            this.DiffSize = this.CalculateDiffSize(oldSize, newSize);
        }

        private Size CalculateDiffSize(Size oldSize, Size newSize)
        {
            return Size.Subtract(newSize, oldSize);
        }

    }

    public delegate void SizeChangedEventHandler(object sender, SizeChangedEventArgs e);
}
