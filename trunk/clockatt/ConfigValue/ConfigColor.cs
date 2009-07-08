using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace clockatt.ConfigValue
{
    public class ConfigColor : ConfigAbstract
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
        protected override void InitValue()
        {
            this.pCurrentValue = string.Empty;
            this.InitialError = "色の指定が不正です";
        }


        public ConfigColor()
        {
            this.InitValue();
        }

        public ConfigColor(string name)
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
                Color testColor = Color.FromName(strValue);
                if( testColor.A == 0 &&
                    testColor.R == 0 &&
                    testColor.G == 0 &&
                    testColor.B == 0 )
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
