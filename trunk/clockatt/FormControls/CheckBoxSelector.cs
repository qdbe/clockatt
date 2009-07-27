using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace clockatt.FormControls
{
    /// <summary>
    /// チェックボックス指定コントロール
    /// </summary>
    public partial class CheckBoxSelector : ConfigSelectorBase
    {

        /// <summary>
        /// 表示テキスト
        /// </summary>
        public string DispText
        {
            get
            {
                return this.chkBox.Text;
            }
            set
            {
                this.chkBox.Text = value;
            }
        }

        /// <summary>
        /// チェックされているか否か
        /// </summary>
        public bool Checked
        {
            get { return this.chkBox.Checked; }
            set {
                this.SetValue(value);
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CheckBoxSelector()
        {
            InitializeComponent();
            this.SetValue(true);
            this.chkBox.CheckedChanged += new EventHandler(chkBox_CheckedChanged);
        }

        /// <summary>
        /// 値をセットする
        /// </summary>
        /// <param name="value"></param>
        public override void SetValue(object value)
        {
            if (!(value is bool))
            {
                throw new ArgumentException(value.GetType().Name + "は引数にセットできません");
            }

            this.chkBox.Checked = (bool)value;
            this.pSelectedValue = value;
            this.SetSampleProperty(value);
        }


        /// <summary>
        /// 内部のチェックボックス変更時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void chkBox_CheckedChanged(object sender, EventArgs e)
        {
            this.SetValue(this.chkBox.Checked);
        }

        /// <summary>
        /// サンプルプロパティ値の型
        /// </summary>
        /// <returns></returns>
        protected override Type GetSamplePropertyType()
        {
            return typeof(bool);
        }

        //public override void SetDataToSettings(System.Configuration.SettingsBase setting)
        //{
        //    setting.PropertyValues[this.SettingName].PropertyValue = this.chkBox.Checked;
        //}
    }
}
