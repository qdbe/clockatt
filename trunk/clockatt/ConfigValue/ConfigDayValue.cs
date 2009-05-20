using System;
using System.Collections.Generic;
using System.Text;

namespace clockatt.ConfigValue
{
    /// <summary>
    /// 日付の設定値を管理する
    /// </summary>
    public class ConfigDayValue : ConfigIntValue
    {
        public new static readonly int ALL = -1;
        public new static readonly int InValid = -99;

        /// <summary>
        /// 年の最低値
        /// </summary>
        public static readonly int MinDay = 1;

        /// <summary>
        /// 年の最大値
        /// </summary>
        public static readonly int MaxDay = 31;

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void InitValue()
        {
            this.pCurrentValue = ALL;
            this.MaxValue = MaxDay;
            this.MinValue = MinDay;
        }


        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ConfigDayValue() : base()
        {
        }


        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="strValue"></param>
        public ConfigDayValue(string strValue)
            : base(strValue)
        {
        }
    }
}
