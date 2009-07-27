using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace clockatt.FormControls
{
    public partial class IntSelector : ConfigSelectorBase
    {
        /// <summary>
        /// 値の初期値
        /// </summary>
        private const int INITIAL_NUM = 9;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public IntSelector()
        {
            InitializeComponent();
            this.numText.Value = INITIAL_NUM;
            this.numText.ValueChanged += new EventHandler(numText_ValueChanged);
        }

        /// <summary>
        /// 値を設定する
        /// </summary>
        /// <param name="value"></param>
        public override void SetValue(object value)
        {
            if (!(value is int))
            {
                throw new ArgumentException(value.GetType().Name + "は引数にセットできません");
            }

            this.pSelectedValue = value;
            this.numText.Value = (int)value;
            this.SetSampleProperty(this.pSelectedValue);
        }

        /// <summary>
        /// 値変更イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void numText_ValueChanged(object sender, EventArgs e)
        {
            this.SetValue((int)this.numText.Value);
        }

        /// <summary>
        /// サンプルプロパティ値の型
        /// </summary>
        /// <returns></returns>
        protected override Type GetSamplePropertyType()
        {
            return typeof(int);
        }
    }
}
