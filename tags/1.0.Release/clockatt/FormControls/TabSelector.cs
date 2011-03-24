using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace clockatt.FormControls
{
    /// <summary>
    /// 背景色を指定可能にしたタブコントロール
    /// </summary>
    public class TabSelector : TabControl
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TabSelector() : base()
        {
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
        }

        /// <summary>
        /// 背景色
        /// </summary>
        public Color TabBackColor { get; set; }

        /// <summary>
        /// ページ切替表示位置はTOPのみに制限する
        /// </summary>
        public new TabAlignment Alignment
        {
            get { return base.Alignment; }
            set
            {
                if (value != TabAlignment.Top)
                {
                    throw new ArgumentException("TabのAlignmentはTOPのみ指定できます");
                }
                base.Alignment = value;
            }
        }

        /// <summary>
        /// 描画は独自に実施
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.TabCount == 0)
            {
                base.OnPaint(e);
                return;
            }

            e.Graphics.SetClip(e.ClipRectangle);
            e.Graphics.FillRectangle(GetBackBrush(), 0, 0, this.Width, this.Height);
        }

        /// <summary>
        /// 各ページ描画も独自に実施する
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            TabPage currentPage = this.TabPages[e.Index];

            DrawBackColor(e);

            DrawPageFocusRectangle(e);

            int selectMargin = GetPageTextMargin(e);

            DrawPageText(e, currentPage, selectMargin);

            if (IsLastPage(e))
            {
                // タブの右側も描画する
                DrawPageRightArea(e);
            }
        }

        /// <summary>
        /// タブページの右側の空白エリアを描画する
        /// </summary>
        /// <param name="e"></param>
        private void DrawPageRightArea(DrawItemEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Rectangle r = this.GetTabRect(e.Index);

            g.FillRectangle(GetBackBrush(), r.Right, 0, this.Width - r.Right, r.Height);
        }

        /// <summary>
        /// 背景用のブラシを取得する
        /// </summary>
        /// <returns></returns>
        private Brush GetBackBrush()
        {
            return new SolidBrush(this.TabBackColor);
        }

        /// <summary>
        /// 全体の背景を描画する
        /// </summary>
        /// <param name="e"></param>
        private void DrawBackColor(DrawItemEventArgs e)
        {
            e.Graphics.FillRectangle(GetBackBrush(), e.Bounds);
        }

        /// <summary>
        /// ページのフォーカス状態を描画する
        /// </summary>
        /// <param name="e"></param>
        private static void DrawPageFocusRectangle(DrawItemEventArgs e)
        {
            if (e.State == DrawItemState.Selected)
            {
                e.DrawFocusRectangle();
            }
        }

        /// <summary>
        /// ページ文字の描画マージンを取得する
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private static int GetPageTextMargin(DrawItemEventArgs e)
        {
            int selectMargin = 0;
            if (e.State == DrawItemState.Selected)
            {
                selectMargin = 1;
            }
            return selectMargin;
        }

        /// <summary>
        /// ページの文字を描画する
        /// </summary>
        /// <param name="e"></param>
        /// <param name="currentPage"></param>
        /// <param name="selectMargin"></param>
        private static void DrawPageText(DrawItemEventArgs e, TabPage currentPage, int selectMargin)
        {
            Brush foreBrush = new SolidBrush(currentPage.ForeColor);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;

            e.Graphics.DrawString(currentPage.Text, e.Font, foreBrush, e.Bounds.X + 3 + selectMargin, e.Bounds.Y + 3 + selectMargin, format);
        }

        /// <summary>
        /// 最後のページか否か
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private bool IsLastPage(DrawItemEventArgs e)
        {
            return (e.Index + 1) == this.TabPages.Count;
        }
    }
}
