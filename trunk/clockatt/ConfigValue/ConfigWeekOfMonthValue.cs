using System;
using System.Collections.Generic;
using System.Text;

namespace clockatt.ConfigValue
{
    /// <summary>
    /// 第何週目かをあらわす設定値を管理する
    /// </summary>
    public class ConfigWeekOfMonthValue : ConfigHolidayIntValue
    {
        /// <summary>
        /// 全て
        /// </summary>
        public new static readonly int ALL = 0;
        /// <summary>
        /// 不正値
        /// </summary>
        public new static readonly int InValid = -99;

        /// <summary>
        /// 年の最低値
        /// </summary>
        public static readonly int MinWeekOfMonth = 1;

        /// <summary>
        /// 年の最大値
        /// </summary>
        public static readonly int MaxWeekOfMonth = 6;

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void InitValue()
        {
            this.CurrentValue = ALL;
            this.MaxValue = MaxWeekOfMonth;
            this.MinValue = MinWeekOfMonth;
            this.InitialError = "第何週かの指定が不正です";
        }


        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ConfigWeekOfMonthValue() : base()
        {
        }


        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="strValue"></param>
        public ConfigWeekOfMonthValue(string strValue)
            : base(strValue)
        {
        }
    }
}
