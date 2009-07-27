using System;
using System.Collections.Generic;
using System.Text;

namespace clockatt.ConfigValue
{
    public abstract class ConfigHolidayIntValue : ConfigIntValue
    {
        /// <summary>
        /// 全てを表す
        /// </summary>
        public static readonly int ALL = 0;

        /// <summary>
        /// 不正値
        /// </summary>
        public static readonly int InValid = -1;

        /// <summary>
        /// すべてをあらわす数値か否か
        /// </summary>
        public virtual bool IsAllValue
        {
            get
            {
                if (this.CurrentValue == ALL)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 不正値か否か
        /// </summary>
        public virtual bool IsInValid
        {
            get
            {
                if (this.CurrentValue == InValid)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ConfigHolidayIntValue() : base()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="strValue"></param>
        public ConfigHolidayIntValue(string strValue)
        {
            if (this.TryParse(strValue) == false)
            {
                throw new ConfigInitException(this.InitialError);
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public override bool TryParse(string strValue)
        {
            if (strValue == null)
            {
                return false;
            }
            if (this.isWildCard(strValue) == true)
            {
                this.CurrentValue = ALL;
                return true;
            }

            // 書式文字からの変換
            if (this.ParseFromFormat(strValue) == true)
            {
                return true;
            }

            // 数字からの変換
            return this.ParseAsInt(strValue);
        }

        /// <summary>
        /// 全ての値を現在値としてセットする
        /// </summary>
        public virtual void SetAllValue()
        {
            this.CurrentValue = ALL;
        }

        /// <summary>
        /// 同一の値か否かをチェックする
        /// </summary>
        /// <param name="checkValue"></param>
        /// <returns></returns>
        public override bool IsSame(int checkValue)
        {
            if (this.CurrentValue == ALL)
            {
                return true;
            }

            if (this.CurrentValue == checkValue)
            {
                return true;
            }

            return false;
        }

    }
}
