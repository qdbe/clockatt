using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace clockatt
{
    public class HolidayConfigCollection : System.Collections.Generic.List<HolydayConfig>, IConfig
    {
        protected const string ERRMSG="休日設定に記載ミスがあります:";

        #region IConfig メンバ
        private bool CanWrite = false;

        public void ReadConfig(StreamReader sr)
        {
            for (;!sr.EndOfStream; )
            {
                string rLine = sr.ReadLine();
                this.ReadLine(rLine);
            }
        }

        public void ReadLine(string rLine)
        {
            rLine = rLine.TrimStart(" 　".ToCharArray());
            if (rLine.StartsWith("#") == true)
            {
                // # で始まる場合はコメント扱い
                return;
            }
            string[] lineCols = rLine.Split(" \t　".ToCharArray());
            if (lineCols.Length < 6)
            {
                throw new ApplicationException(ERRMSG + rLine);
            }
            HolydayConfig hConf = new HolydayConfig();
            hConf.StartYear = this.GetInt(rLine, lineCols, 1);
        }

        public void WriteConfig(System.IO.StreamWriter sw)
        {
            if (this.CanWrite != true)
            {
                return;
            }
        }

        #endregion

        private bool isWildCard(string words)
        {
            if( words == "*" )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int GetInt(string rLine, string[] lineCols, int Cols)
        {
            string words = lineCols[Cols];
            if (isWildCard(words) == true)
            {
                return HolydayConfig.ALLVALUE;
            }
            else
            {
                int result;
                if (int.TryParse(words, out result) == true)
                {
                    return result;
                }
                else
                {
                    throw new ApplicationException(ERRMSG + rLine);
                }
            }
        }
    
}
}
