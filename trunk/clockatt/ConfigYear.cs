using System;
using System.Collections.Generic;
using System.Text;

namespace clockatt
{
    public class ConfigYear : ConfigAbstract
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly ConfigYear ALLVALUE = new ConfigYear();
        public static readonly int ALL = -1;
        public static readonly int InValid = -99;

        /// <summary>
        /// 年の最低値
        /// </summary>
        public static readonly int MinYear = 0;

        /// <summary>
        /// 年の最大値
        /// </summary>
        public static readonly int MaxYear = 9999;

        public ConfigYear()
        {
            this.pCurrentValue = ALL;
        }


        public ConfigYear(string strValue)
            : base()
        {
            if (this.TryParse(strValue) == false)
            {
                this.CurrentValue = InValid;
            }
        }


        public override bool TryParse(string strValue)
        {
            if (strValue == null)
            {
                return false;
            }
            if (this.isWildCard(strValue) == true)
            {
                this.pCurrentValue = ALL;
                return true;
            }
            int parseValue = 0;
            if (int.TryParse(strValue, out parseValue) == true)
            {
                if (parseValue < MinYear ||
                    parseValue > MaxYear)
                {
                    return false;
                }
                this.pCurrentValue = parseValue;
            }
            return false;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is ConfigYear)
            {
                if (this.pCurrentValue == ((ConfigYear)obj).CurrentValue)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsSame(int checkValue)
        {
            if( this.CurrentValue == ALL )
            {
                return true;
            }

            if (this.CurrentValue == checkValue)
            {
                return true;
            }

            return false;
        }
    }
}
