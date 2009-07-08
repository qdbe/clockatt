using System;
using System.Collections.Generic;
using System.Text;

namespace clockatt.ConfigValue
{
    /// <summary>
    /// 日付の設定値を管理する
    /// </summary>
    public class ConfigDayValue : ConfigHolidayIntValue
    {
        public new static readonly int ALL = -1;
        public new static readonly int InValid = -99;

        /// <summary>
        /// 日の最低値
        /// </summary>
        public static readonly int MinDay = 1;

        /// <summary>
        /// 日の最大値
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

            this.InitialError = "日付の指定が不正です";
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
