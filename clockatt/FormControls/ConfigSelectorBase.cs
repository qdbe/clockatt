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
    public partial class ConfigSelectorBase : UserControl
    {
        /// <summary>
        /// 対応するサンプル表示の変更イベント
        /// 値に変更があった場合に呼び出される
        /// </summary>
        public event EventHandler SamplePropertyChanged = null;

        /// <summary>
        /// 現在の設定値
        /// </summary>
        protected object pSelectedValue;

        /// <summary>
        /// サンプル表示を行う対象コントロール
        /// </summary>
        public object SampleObject
        {
            get;
            private set;
        }


        /// <summary>
        /// サンプル表示を行う対象コントロールのプロパティ名
        /// </summary>
        public string SampleProperty
        {
            get;
            private set;
        }

        /// <summary>
        /// 対応するアプリケーション設定値の名称
        /// </summary>
        public string SettingName { get; set; }


        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ConfigSelectorBase()
        {
            InitializeComponent();
        }

        /// <summary>
        /// サンプル表示を行う対象コントロールのプロパティの型
        /// </summary>
        /// <returns></returns>
        protected virtual Type GetSamplePropertyType()
        {
            return null;
        }

        /// <summary>
        /// サンプル表示を行う対象コントロールを設定する
        /// </summary>
        /// <param name="target"></param>
        /// <param name="targetProperty"></param>
        public void SetSampleObject(object target, string targetProperty)
        {
            this.SampleObject = target;
            this.SampleProperty = targetProperty;
            this.SetSampleProperty(this.pSelectedValue);
        }

        /// <summary>
        /// サンプル表示のプロパティ値を設定する
        /// </summary>
        /// <param name="setValue"></param>
        public void SetSampleProperty(object setValue)
        {
            if (this.SampleObject == null)
            {
                CallSamplePropertyChanged(this, new EventArgs());
                return;
            }
            PropertyInfo pi = this.SampleObject.GetType().GetProperty(this.SampleProperty);
            Type ptype = this.GetSamplePropertyType();
            if( ptype.FullName == pi.PropertyType.FullName)
            {
                pi.SetValue(this.SampleObject, setValue, null);
                if (this.SampleObject is Control)
                {
                    ((Control)this.SampleObject).Invalidate(true);
                }
                CallSamplePropertyChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// 変更イベントを呼び出す
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CallSamplePropertyChanged(object sender, EventArgs e)
        {
            if (SamplePropertyChanged != null)
            {
                SamplePropertyChanged(sender, e);
            }
        }

        /// <summary>
        /// 現在の値を設定する
        /// </summary>
        /// <param name="value"></param>
        public virtual void SetValue(object value)
        {
            this.pSelectedValue = value;
        }

        /// <summary>
        /// アプリケーション設定から値を取得し現在値として保持する
        /// </summary>
        /// <param name="setting"></param>
        public virtual void GetDataFromSettings(System.Configuration.SettingsBase setting)
        {
            this.SetValue(setting.PropertyValues[this.SettingName].PropertyValue);
        }

        /// <summary>
        /// アプリケーション設定に現在地を設定する
        /// </summary>
        /// <param name="setting"></param>
        public virtual void SetDataToSettings(System.Configuration.SettingsBase setting)
        {
            setting.PropertyValues[this.SettingName].PropertyValue = this.pSelectedValue;
        }
    }
}
