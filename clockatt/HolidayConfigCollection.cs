﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace clockatt
{
    /// <summary>
    /// 休日設定のコレクションクラス
    /// </summary>
    public class HolidayConfigCollection : System.Collections.Generic.List<HolidayConfig>, IConfig
    {
        private const string ERRMSG = "休日設定に記載ミスがあります:";
        private const string ERRMSG_COLUMN = "休日設定に記載ミスがあります:列数が不正です。タブ区切りで設定してください:";

        /// <summary>
        /// 設定ファイルのカラムを指定する
        /// </summary>
        public enum Column
        {
            StartYear = 0,
            EndYear = 1,
            Month = 2,
            Day = 3,
            WeekDay = 4,
            WeekOfMonth = 5,
            HolidayName = 6
        }

        /// <summary>
        /// 休日名の指定なし
        /// </summary>
        private const int NOHOLIDAYNAME = 6;
        /// <summary>
        /// 最低限必要とするカラム数
        /// </summary>
        private const int NEEDCOLUMNCOUNT = 6;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public HolidayConfigCollection()
        {
            this.CanWrite = false;
        }

        #region IConfig メンバ
        /// <summary>
        /// 書き込み可能か否か
        /// </summary>
        public bool CanWrite
        {
            get;
            private set;
        }
    

        /// <summary>
        /// 設定ファイルを読み込む
        /// </summary>
        /// <param name="sr"></param>
        public void ReadConfig(TextReader sr)
        {
            for (;;)
            {
                string rLine = sr.ReadLine();
                if (rLine == null)
                {
                    break;
                }
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
            if (rLine == string.Empty || rLine.Trim() == string.Empty )
            {
                return;
            }
            string[] lineCols = rLine.Split(" \t　".ToCharArray());
            // 休日名はオプション扱い
            if (lineCols.Length < NEEDCOLUMNCOUNT)
            {
                throw new ApplicationException(ERRMSG_COLUMN + rLine);
            }
            HolidayConfig hConf;
            try
            {
                string name;
                if (lineCols.Length == NOHOLIDAYNAME)
                {
                    name = null;
                }
                else
                {
                    name = lineCols[(int)Column.HolidayName];
                }
                hConf = new HolidayConfig(lineCols[(int)Column.StartYear],
                    lineCols[(int)Column.EndYear],
                    lineCols[(int)Column.Month],
                    lineCols[(int)Column.Day],
                    lineCols[(int)Column.WeekDay],
                    lineCols[(int)Column.WeekOfMonth],
                    name);
            }
            catch (ApplicationException exp)
            {
                throw new ApplicationException(exp.Message + ":" + rLine);
            }
            this.Add(hConf);
        }

        /// <summary>
        /// 設定値を書き戻す
        /// </summary>
        /// <param name="sw"></param>
        public void WriteConfig(TextWriter sw)
        {
            if (this.CanWrite != true)
            {
                return;
            }
        }

        /// <summary>
        /// 休日か否かを返す
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public bool IsHoliday(DateTime day)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].IsHoliday(day) == true)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 休日情報を返す
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public HolidayConfig GetHolidayInfo(DateTime day)
        {
            
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].IsHoliday(day) == true)
                {
                    return this[i];
                }
            }
            return null;
        }

        #endregion
    }
}
