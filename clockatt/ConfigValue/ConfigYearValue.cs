using System;
using System.Collections.Generic;
using System.Text;

namespace clockatt.ConfigValue
{
    /// <summary>
    /// 年の設定値を管理する
    /// </summary>
    public class ConfigYearValue : ConfigHolidayIntValue
    {
        public new static readonly int ALL = -1;
        public new static readonly int InValid = -99;

        /// <summary>
        /// 年の最低値
        /// </summary>
        public static readonly int MinYear = 0;

        /// <summary>
        /// 年の最大値
        /// </summary>
        public static readonly int MaxYear = 9999;

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void InitValue()
        {
            this.pCurrentValue = ALL;
            this.MaxValue = MaxYear;
            this.MinValue = MinYear;
            this.InitialError = "年の指定が不正です";
        }


        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ConfigYearValue() : base()
        {
        }


        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="strValue"></param>
        /// <param name="isStartYear">開始年か否か</param>
        public ConfigYearValue(string strValue, bool isStartYear)
        {
            InitValue();
            if (isWildCard(strValue))
            {
                if (isStartYear == true)
                {
                    this.pCurrentValue = MinYear;
                }
                else
                {
                    this.pCurrentValue = MaxYear;
                }
                return;
            }
            if (this.TryParse(strValue) == false)
            {
                throw new ConfigInitException(this.InitialError);
            }
        }


        /// <summary>
        /// 年が指定範囲の間かどうかをチェックする
        /// </summary>
        /// <param name="yy"></param>
        /// <param name="st"></param>
        /// <param name="ed"></param>
        /// <returns></returns>
        public static bool IsYearRange(int yy, ConfigYearValue st, ConfigYearValue ed)
        {
            if (yy >= st.CurrentValue && yy <= ed.CurrentValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
