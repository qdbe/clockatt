using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace clockatt.FormControls
{
    public class TabSelector : TabControl
    {
        public TabSelector() : base()
        {
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
        }

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

        private const string SelectChar = "*";

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            TabPage currentPage = this.TabPages[e.Index];

            Brush backBrush = new SolidBrush(currentPage.BackColor);
            Brush foreBrush = new SolidBrush(currentPage.ForeColor);

            if (e.Index == 0)
            {
                // タブの右側も描画する
                Graphics g = this.CreateGraphics();

                g.FillRectangle(backBrush, 0, 0, e.Bounds.Width, e.Bounds.Height);
            }


            e.Graphics.FillRectangle(backBrush, e.Bounds);

            if (e.State == DrawItemState.Selected)
            {
                e.DrawFocusRectangle();
            }

            StringFormat format = new StringFormat();
		    format.Alignment=StringAlignment.Near;

            e.Graphics.DrawString(currentPage.Text, e.Font, foreBrush, e.Bounds.X+2, e.Bounds.Y + 2, format);

            if ((e.Index + 1) == this.TabPages.Count)
            {
                // タブの右側も描画する
                Graphics g = this.CreateGraphics();
                Rectangle r = this.GetTabRect(e.Index);

                g.FillRectangle(backBrush, r.Right, 0, this.Width - r.Right, r.Height);
            }
        }
    }
}
