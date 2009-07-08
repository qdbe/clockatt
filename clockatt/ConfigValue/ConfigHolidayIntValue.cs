using System;
using System.Collections.Generic;
using System.Text;

namespace clockatt.ConfigValue
{
    public abstract class ConfigHolidayIntValue : ConfigIntValue
    {
        public static readonly int ALL = 0;
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
        public ConfigHolidayIntValue()
        {
            InitValue();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="strValue"></param>
        public ConfigHolidayIntValue(string strValue)
            : base()
        {
            InitValue();
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
                this.pCurrentValue = ALL;
                return true;
            }

            // 書式文字からの変換
            if (strFormats != null &&
                strFormats.Length > 0)
            {
                string lowerValue = strValue.ToLower();
                for (int i = 0; i < strFormats.Length; i++)
                {
                    for (int j = 0; j < strFormats[i].Length; j++)
                    {
                        if (strFormats[i][j].ToLower() == lowerValue)
                        {
                            this.pCurrentValue = j;
                            return true;
                        }
                    }
                }
            }

            // 数字からの変換
            int parseValue = 0;
            if (int.TryParse(strValue, out parseValue) == true)
            {
                if (parseValue < MinValue ||
                    parseValue > MaxValue)
                {
                    return false;
                }
                this.pCurrentValue = parseValue;
                return true;
            }

            return false;
        }

        public virtual void SetAllValue()
        {
            this.pCurrentValue = ALL;
        }

        /// <summary>
        /// 同一の値か否かをチェックする
        /// </summary>
        /// <param name="checkValue"></param>
        /// <returns></returns>
        public virtual bool IsSame(int checkValue)
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
