using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace clockatt
{
    /// <summary>
    /// 設定ファイルを扱うインターフェース
    /// </summary>
    public interface IConfig
    {
        void ReadConfig(TextReader sr);
        void WriteConfig(TextWriter sw);
        void ReadLine(string rLine);
        bool CanWrite{get;}
    }
}
