using System;
using System.Collections.Generic;
using System.Text;

namespace clockatt.ConfigValue
{
    public abstract class ConfigStringValue : ConfigAbstract
    {
        /// <summary>
        /// 現在の値
        /// </summary>
        protected string pCurrentValue;
        public string CurrentValue
        {
            get { return pCurrentValue; }
            set { pCurrentValue = value; }
        }

        public override string ToString()
        {
            return pCurrentValue;
        }

    }
}
