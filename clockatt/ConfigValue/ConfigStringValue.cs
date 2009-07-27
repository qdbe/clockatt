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
        public string CurrentValue { get; set; }

        public override string ToString()
        {
            return CurrentValue;
        }

    }
}
