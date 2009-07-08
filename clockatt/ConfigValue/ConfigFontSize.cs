using System;
using System.Collections.Generic;
using System.Text;

namespace clockatt.ConfigValue
{
    public class ConfigFontSize : ConfigIntValue
    {
        public static readonly int InValid = -1;
        public static readonly int DefaultValue = 9;

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void InitValue()
        {
            this.pCurrentValue = DefaultValue;

            this.InitialError = "月の指定が不正です";
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ConfigFontSize() : base()
        {
        }


        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="strValue"></param>
        public ConfigFontSize(string strValue) :
            base(strValue)
        {
        }
    }
}
