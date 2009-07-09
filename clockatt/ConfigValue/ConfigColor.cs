using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace clockatt.ConfigValue
{
    public class ConfigColor : ConfigStringValue
    {

        Color pColorValue = Color.Black;
        public Color ColorValue
        {
            get { return this.pColorValue; }
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
                Color parsedColor = Color.FromName(strValue);
                if (parsedColor.A == 0 &&
                    parsedColor.R == 0 &&
                    parsedColor.G == 0 &&
                    parsedColor.B == 0)
                {
                    throw new ConfigInitException(this.InitialError);
                }
                this.pColorValue = parsedColor;
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
