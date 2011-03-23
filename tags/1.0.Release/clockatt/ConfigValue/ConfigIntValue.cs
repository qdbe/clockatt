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
        public int CurrentValue { get; set; }


        /// <summary>
        /// 最大値
        /// </summary>
        protected int MaxValue = Int32.MaxValue;

        /// <summary>
        /// 最小値
        /// </summary>
        protected int MinValue = Int32.MinValue;



        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ConfigIntValue():base()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="strValue"></param>
        public ConfigIntValue(string strValue)
            : base()
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

            // 書式文字からの変換
            if (ParseFromFormat(strValue) == true)
            {
                return true;
            }

            // 数字からの変換
            return ParseAsInt(strValue);
        }

        /// <summary>
        /// 数値としてパースする
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        protected virtual bool ParseAsInt(string strValue)
        {
            int parseValue = 0;
            if (int.TryParse(strValue, out parseValue) == true)
            {
                if (parseValue < MinValue ||
                    parseValue > MaxValue)
                {
                    return false;
                }
                this.CurrentValue = parseValue;
                return true;
            }

            return false;
        }

        /// <summary>
        /// 特別な書式としてパースする
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        protected virtual bool ParseFromFormat(string strValue)
        {
            if (this.strFormats != null &&
                this.strFormats.Length > 0)
            {
                string lowerValue = strValue.ToLower();
                for (int i = 0; i < this.strFormats.Length; i++)
                {
                    for (int j = 0; j < this.strFormats[i].Length; j++)
                    {
                        if (this.strFormats[i][j].ToLower() == lowerValue)
                        {
                            this.CurrentValue = j;
                            return true;
                        }
                    }
                }
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
                if (this.CurrentValue == ((ConfigIntValue)obj).CurrentValue)
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
            return CurrentValue;
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

        /// <summary>
        /// 文字列化
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.CurrentValue.ToString();
        }
    }
}
