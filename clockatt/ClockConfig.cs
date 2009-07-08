using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using clockatt.ConfigValue;
using System.Xml;
using System.Xml.Serialization;

namespace clockatt
{
    public class ClockConfig : IConfig
    {
        /// <summary>
        /// フォントサイズ
        /// </summary>
        private ConfigFontSize pFontSize;
        public ConfigFontSize FontSize
        {
            get { return pFontSize; }
            set { pFontSize = value; }
        }
        private static readonly string DATA_FONTSIZE = "FontSize";

        /// <summary>
        /// フォント名
        /// </summary>
        private ConfigFontName pFontName;
        public ConfigFontName FontName
        {
            get { return pFontName; }
            set { pFontName = value; }
        }
        private static readonly string DATA_FONTNAME = "FontName";

        /// <summary>
        /// フォント色
        /// </summary>
        private ConfigColor pFontColor;
        internal ConfigColor FontColor
        {
            get { return pFontColor; }
            set { pFontColor = value; }
        }
        private static readonly string DATA_FONTCOLOR = "FontColor";

        /// <summary>
        /// 背景色
        /// </summary>
        private ConfigColor pBackColor;
        internal ConfigColor BackColor
        {
            get { return pBackColor; }
            set { pBackColor = value; }
        }
        private static readonly string DATA_BACKCOLOR = "BackColor";

        public ClockConfig()
        {
            this.BackColor = new ConfigColor("Control");
            this.FontColor = new ConfigColor("ControlText");
            this.FontName = new ConfigFontName();
            this.FontSize = new ConfigFontSize();
        }

        private bool GetNodeValue(XmlDocument doc, string nodeName, out string value)
        {
            value = string.Empty;
            XmlNode node = doc.SelectSingleNode(nodeName);
            if (node == null)
            {
                return false;
            }
            value = node.Value;
            return true;
        }

        #region IConfig メンバ

        public void ReadConfig(System.IO.StreamReader sr)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(sr);

            string strValue = string.Empty;
            if (GetNodeValue(doc, DATA_BACKCOLOR, out strValue) == true)
            {
                this.BackColor = new ConfigColor(strValue);
            }
            if (GetNodeValue(doc, DATA_FONTCOLOR, out strValue) == true)
            {
                this.FontColor = new ConfigColor(strValue);
            }
            if (GetNodeValue(doc, DATA_FONTNAME, out strValue) == true)
            {
                this.FontName = new ConfigFontName(strValue);
            }
            if (GetNodeValue(doc, DATA_FONTSIZE, out strValue) == true)
            {
                this.FontSize = new ConfigFontSize(strValue);
            }
        }

        public void WriteConfig(System.IO.StreamWriter sw)
        {
            XmlDocument doc = new XmlDocument();

            doc.CreateNode(XmlNodeType.Element, DATA_BACKCOLOR, DATA_BACKCOLOR).Value = this.BackColor.CurrentValue;
            doc.CreateNode(XmlNodeType.Element, DATA_FONTCOLOR, DATA_FONTCOLOR).Value = this.FontColor.CurrentValue;
            doc.CreateNode(XmlNodeType.Element, DATA_FONTNAME, DATA_FONTNAME).Value = this.FontName.CurrentValue;
            doc.CreateNode(XmlNodeType.Element, DATA_FONTSIZE, DATA_FONTSIZE).Value = this.FontSize.CurrentValue.ToString();
            doc.Save(sw);
        }

        public void ReadLine(string rLine)
        {
            throw new NotImplementedException();
        }

        public bool CanWrite
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
