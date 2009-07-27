using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace clockatt.FormControls
{
    public partial class FontSelector : ConfigSelectorBase
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FontSelector()
        {
            InitializeComponent();
            this.SetValue(this.Font);
        }

        /// <summary>
        /// 値の設定
        /// </summary>
        /// <param name="value"></param>
        public override void SetValue(object value)
        {
            if (!(value is Font))
            {
                throw new ArgumentException(value.GetType().Name + "は引数にセットできません");
            }
            pSelectedValue = value;
            this.txtFontName.Text = ((Font)pSelectedValue).Name + ", " + ((Font)pSelectedValue).SizeInPoints.ToString() + "Point";
            this.toolTip1.SetToolTip(this.txtFontName, this.txtFontName.Text);
            this.SetSampleProperty(this.pSelectedValue);
        }

        /// <summary>
        /// フォント選択ダイアログの表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFontSearch_Click(object sender, EventArgs e)
        {
            this.fontSelectDialog.Font = (Font)this.pSelectedValue;
            if (this.fontSelectDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.SetValue(this.fontSelectDialog.Font);
            }
        }

        /// <summary>
        /// サンプルプロパティ値の型
        /// </summary>
        /// <returns></returns>
        protected override Type GetSamplePropertyType()
        {
            return Font.GetType();
        }
    }
}
