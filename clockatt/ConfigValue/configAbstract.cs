using System;
using System.Collections.Generic;
using System.Text;

namespace clockatt.ConfigValue
{
    public abstract class ConfigAbstract
    {
        /// <summary>
        /// 初期化失敗時のエラーメッセージ
        /// </summary>
        protected string InitialError = "";

        /// <summary>
        /// 表示文字列
        /// </summary>
        protected string[][] strFormats;


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

        protected abstract void InitValue();

    }
}
