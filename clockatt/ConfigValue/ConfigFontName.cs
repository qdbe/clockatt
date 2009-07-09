using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace clockatt.ConfigValue
{
    public class ConfigFontName : ConfigStringValue
    {
        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void InitValue()
        {
            this.pCurrentValue = "ＭＳ ゴシック";
            this.InitialError = "月の指定が不正です";
        }


        public ConfigFontName()
        {
            this.InitValue();
        }

        public ConfigFontName(string name)
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

            try
            {
                Font testFont = new Font(strValue, 10);
                if( testFont == null )
                {
                    throw new ConfigInitException(this.InitialError);
                }
                this.pCurrentValue = strValue;
            }
            catch (Exception e)
            {
                throw new ConfigInitException(this.InitialError,e);
            }

            return true;
        }

        public override int GetHashCode()
        {
            return this.pCurrentValue.GetHashCode();
        }
    }
}
