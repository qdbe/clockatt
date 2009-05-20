using System;
using System.Collections.Generic;
using System.Text;

namespace clockatt
{
    public abstract class ConfigInt : ConfigAbstract
    {
        public static readonly int ALL = 0;
        public static readonly int InValid = -1;

        protected int MaxValue = Int32.MaxValue;
        protected int MinValue = Int32.MinValue;

        /// <summary>
        /// 表示文字列
        /// </summary>
        protected string[][] strFormats;


        protected abstract void InitValue();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ConfigInt()
        {
            this.pCurrentValue = ALL;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="strValue"></param>
        public ConfigInt(string strValue)
            : base()
        {
            if (this.TryParse(strValue) == false)
            {
                this.CurrentValue = InValid;
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
            }

            return false;
        }

        /// <summary>
        /// 等価であるかどうかの判定
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (this.GetType().Equals(obj))
            {
                if (this.pCurrentValue == ((ConfigInt)obj).CurrentValue)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// ハッシュコードを返す
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return pCurrentValue;
        }


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
