using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace clockatt
{
    public interface IConfig
    {
        void ReadConfig(StreamReader sr);
        void WriteConfig(StreamWriter sw);
        void ReadLine(string rLine);
        bool CanWrite{get;}
    }
}
