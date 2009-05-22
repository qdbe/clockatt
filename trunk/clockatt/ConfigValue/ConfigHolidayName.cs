using System;
using System.Collections.Generic;
using System.Text;

namespace clockatt.ConfigValue
{
    public class ConfigHolidayName : ConfigAbstract
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

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected void InitValue()
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

            this.pCurrentValue = name;

            return true;
        }

        public override int GetHashCode()
        {
            return this.pCurrentValue.GetHashCode();
        }
    }
}
