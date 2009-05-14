using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace clockatt
{
    public class HolidayConfigCollection : System.Collections.Generic.List<HolydayConfig>, IConfig
    {
        protected const string ERRMSG = "休日設定に記載ミスがあります:";
        protected const string ERRMSG_COLUMN = "休日設定に記載ミスがあります:列数が不正です。タブ区切りで設定してください:";

        #region IConfig メンバ
        private bool pCanWrite = false;

        /// <summary>
        /// 書き込み可能か否か
        /// </summary>
        public bool CanWrite
        {
            get { return this.pCanWrite; }
        }
    

        /// <summary>
        /// 設定ファイルを読み込む
        /// </summary>
        /// <param name="sr"></param>
        public void ReadConfig(StreamReader sr)
        {
            for (;!sr.EndOfStream; )
            {
                string rLine = sr.ReadLine();
                this.ReadLine(rLine);
            }
        }

        /// <summary>
        /// 一行の設定を読み込む
        /// </summary>
        /// <param name="rLine"></param>
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
                throw new ApplicationException(ERRMSG_COLUMN + rLine);
            }
            HolydayConfig hConf = new HolydayConfig();
            hConf.StartYear = this.GetInt(rLine, lineCols, HolydayConfig.Column.StartYear);
            hConf.EndYear = this.GetInt(rLine, lineCols, HolydayConfig.Column.EndYear);
            hConf.Month = this.GetInt(rLine, lineCols, HolydayConfig.Column.Month);
            hConf.Day = this.GetInt(rLine, lineCols, HolydayConfig.Column.Day);
            hConf.DayAtWeek = this.GetDayAtWeek(rLine, lineCols, HolydayConfig.Column.WeekDay);
            hConf.WeekOfMonth = this.GetInt
            this.Add(hConf);
        }

        /// <summary>
        /// 設定値を書き戻す
        /// </summary>
        /// <param name="sw"></param>
        public void WriteConfig(System.IO.StreamWriter sw)
        {
            if (this.CanWrite != true)
            {
                return;
            }
        }

        #endregion

        /// <summary>
        /// ワイルドカード指定か否かを判定する
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        private bool IsWildCard(string words)
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

        /// <summary>
        /// 一行からInt の値を取得する
        /// </summary>
        /// <param name="rLine"></param>
        /// <param name="lineCols"></param>
        /// <param name="Cols"></param>
        /// <returns></returns>
        private int GetInt(string rLine, string[] lineCols, HolydayConfig.Column Cols)
        {
            string words = lineCols[(int)Cols];
            if (lineCols.Length < (int)Cols )
            {
                return HolydayConfig.ALLVALUE;
            }
            if (IsWildCard(words) == true)
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
        /// <summary>
        /// 一行から曜日の値を取得する
        /// </summary>
        /// <param name="rLine"></param>
        /// <param name="lineCols"></param>
        /// <param name="Cols"></param>
        /// <returns></returns>
        private HolydayConfig.DayWeek GetDayAtWeek(string rLine, string[] lineCols, HolydayConfig.Column Cols)
        {
            string words = lineCols[(int)Cols];
            if (lineCols.Length < (int)Cols)
            {
                return HolydayConfig.ALLVALUE;
            }
            if (IsWildCard(words) == true)
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
