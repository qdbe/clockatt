using System;
using System.Collections.Generic;
using System.Text;

namespace clockatt
{
    public abstract class ConfigAbstract
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

        /// <summary>
        /// ワイルドカード指定か否か
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        protected virtual bool isWildCard(string words)
        {
            if (words == "*")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public abstract bool TryParse(string strValue);

        /// <summary>
        /// ハッシュコードを返す
        /// </summary>
        /// <returns></returns>
        public override abstract int GetHashCode();
    }
}
