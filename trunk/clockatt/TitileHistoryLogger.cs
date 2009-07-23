using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace clockatt
{
    public class TitileHistoryLogger : IDisposable
    {
        private int LogRetainDay;
        private string LogDir;
        private FileInfo LogFile;
        private const string LogFileNameFormat = "yyyyMMdd";
        private StreamWriter logStreamWriter;
        private string preOutput = string.Empty;
        private const string LogFileFormat = "{0}\t{1}\t{2}";

        public TitileHistoryLogger()
        {
            this.LogFile = null;
        }

        public void LogOutput(int logRetainDay, string logDir, string titleText)
        {
            if (preOutput == titleText)
            {
                return;
            }
            preOutput = titleText;

            this.LogRetainDay = logRetainDay;
            this.LogDir = logDir;
            if (this.LogDir.EndsWith(@"\") == false)
            {
                this.LogDir = this.LogDir + "\\";
            }
            DateTime current = DateTime.Now;
            FileInfo fi = new FileInfo(this.LogDir +
                current.ToString(LogFileNameFormat) +
                ".log");
            OpenLogFile(fi);
            DeleteOldLogIfNeed(current);

            string writeLog = string.Format(
                LogFileFormat,
                current.ToShortDateString(),
                current.ToLongTimeString(),
                titleText);

            this.logStreamWriter.WriteLine(writeLog);
        }

        private void OpenLogFile(FileInfo newfile)
        {
            if (this.LogFile != null && 
                this.LogFile.FullName == newfile.FullName)
            {
                return;
            }
            this.LogFile = newfile;
            if (this.logStreamWriter != null)
            {
                this.logStreamWriter.Close();
            }
            this.logStreamWriter = new StreamWriter(this.LogFile.Open(FileMode.Append,FileAccess.Write), Encoding.GetEncoding("shift-jis"));
        }

        private void DeleteOldLogIfNeed(DateTime current)
        {
            DirectoryInfo di = new DirectoryInfo(this.LogDir);
            FileInfo []files = di.GetFiles("*.log");
            DateTime deleteDate = new DateTime(current.Ticks);
            deleteDate.AddDays(-this.LogRetainDay);
            string currentName = current.ToString(LogFileNameFormat);
            
            for (int i = 0; i < files.Length; i++)
            {
                string basename = files[i].Name.Replace(files[i].Extension, "");
                if (currentName.CompareTo(basename) > 0)
                {
                    files[i].Delete();
                }
            }
        }


        #region IDisposable メンバ

        public void Dispose()
        {
            if (logStreamWriter != null)
            {
                logStreamWriter.Flush();
                logStreamWriter.Close();
                logStreamWriter.Dispose();
                logStreamWriter = null;
            }
        }

        #endregion
    }
}
