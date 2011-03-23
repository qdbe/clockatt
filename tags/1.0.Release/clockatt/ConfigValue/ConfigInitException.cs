using System;
using System.Collections.Generic;
using System.Text;

namespace clockatt.ConfigValue
{
    /// <summary>
    /// 設定値に不正値があった場合の例外
    /// </summary>
    public class ConfigInitException : ArgumentException
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="msg"></param>
        public ConfigInitException(string msg) :
            base(msg)
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        public ConfigInitException(string msg, Exception e) :
            base(msg,e)
        {
        }
    }
}
