using System;
using System.Collections.Generic;
using System.Text;

namespace clockatt
{
    public class ConfigYear : ConfigInt
    {
        public new static readonly int ALL = -1;
        public new static readonly int InValid = -99;

        /// <summary>
        /// 年の最低値
        /// </summary>
        public static readonly int MinYear = 0;

        /// <summary>
        /// 年の最大値
        /// </summary>
        public static readonly int MaxYear = 9999;

        protected override void InitValue()
        {
            this.pCurrentValue = ALL;
        }

        public ConfigYear()
        {
            this.InitValue();
        }


        public ConfigYear(string strValue)
            : base(strValue)
        {
            this.InitValue();
            if (this.TryParse(strValue) == false)
            {
                this.CurrentValue = InValid;
            }
        }

    }
}
