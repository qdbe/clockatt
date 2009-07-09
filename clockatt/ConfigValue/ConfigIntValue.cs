using System;
using System.Collections.Generic;
using System.Text;

namespace clockatt.ConfigValue
{
    /// <summary>
    /// 数値を管理する 継承元クラス
    /// </summary>
    public abstract class ConfigIntValue : ConfigAbstract
    {

        /// <summary>
        /// 現在の値
        /// </summary>
        protected int pCurrentValue;
        public int CurrentValue
        {
            get { return pCurrentValue; }
            set { pCurrentValue = value; }
        }


        protected int MaxValue = Int32.MaxValue;
        protected int MinValue = Int32.MinValue;



        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ConfigIntValue()
        {
            InitValue();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="strValue"></param>
        public ConfigIntValue(string strValue)
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
                if (this.pCurrentValue == ((ConfigIntValue)obj).CurrentValue)
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


        /// <summary>
        /// 同一の値か否かをチェックする
        /// </summary>
        /// <param name="checkValue"></param>
        /// <returns></returns>
        public virtual bool IsSame(int checkValue)
        {
            if (this.CurrentValue == checkValue)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return this.CurrentValue.ToString();
        }
    }
}
