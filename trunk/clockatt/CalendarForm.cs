using System;
using System.Drawing;
using System.Windows.Forms;
using clockatt.Configration;

namespace clockatt
{
    /// <summary>
    /// カレンダー表示クラス
    /// </summary>
    public partial class CalendarForm : Form
    {
        /// <summary>
        /// 呼び出し元フォーム(親の位置に合わせてダイアログを表示するため)
        /// </summary>
        private Form CallerForm { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="holidays"></param>
        /// <param name="config"></param>
        public CalendarForm(Form parent, HolidayConfigCollection[] holidays, CalendarConfigration config)
        {
            InitializeComponent();

            this.calendarPanel = new CalendarPanel(this, holidays, config);
            this.calendarPanel.PanelSizeChanged += new SizeChangedEventHandler(calendarPanel_PanelSizeChanged);
            this.CallerForm = parent;
            this.BackColor = config.BackColor;

            InvalidateWithChild();
        }

        void calendarPanel_PanelSizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.ResetPos(e.NewSize);
        }

        /// <summary>
        /// 再描画を実施する
        /// </summary>
        private void InvalidateWithChild()
        {
            this.Invalidate(true);
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
