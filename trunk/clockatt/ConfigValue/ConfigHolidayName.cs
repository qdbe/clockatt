using System;
using System.Collections.Generic;
using System.Text;

namespace clockatt.ConfigValue
{
    public class ConfigHolidayName : ConfigStringValue
    {

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void InitValue()
        {
            this.pCurrentValue = string.Empty;
        }


        public ConfigHolidayName()
        {
            this.InitValue();
        }

        public ConfigHolidayName(string name)
        {
            this.TryParse(name);
        }

        public override bool TryParse(string strValue)
        {
            if (strValue == null)
            {
                this.pCurrentValue = string.Empty;
                return true;
            }

            this.pCurrentValue = strValue;

            return true;
        }

        public override int GetHashCode()
        {
            return this.pCurrentValue.GetHashCode();
        }
    }
}
