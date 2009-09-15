using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime;

namespace clockatt
{
    /// <summary>
    /// タイトル履歴を記録するログ出力クラス
    /// </summary>
    public class TitileHistoryLogger : IDisposable
    {
        /// <summary>
        /// 保存日数
        /// </summary>
        private int LogRetainDay;

        /// <summary>
        /// ログ出力フォルダ
        /// </summary>
        private string LogDir;

        /// <summary>
        /// 現在のログ出力先ファイル
        /// </summary>
        private FileInfo LogFile;

        /// <summary>
        /// ログファイル名フォーマット
        /// </summary>
        private const string LogFileNameFormat = "yyyyMMdd";

        /// <summary>
        /// ログファイル名拡張子
        /// </summary>
        private const string LogFileExtension = ".log";

        /// <summary>
        /// ログ出力フォーマット
        /// </summary>
        private const string LogFileFormat = "{0}\t{1}\t{2}\t{3}\t{4}";

        /// <summary>
        /// ログの見出し
        /// </summary>
        private const string LogFileTitleFormat = "開始日時\t開始時間\t作業時間\tプロセス名\tタイトル";


        /// <summary>
        /// ログ出力用ストリーム
        /// </summary>
        private StreamWriter logStreamWriter;

        /// <summary>
        /// 一定時間にログにフラッシュする為のタイマー
        /// </summary>
        private System.Windows.Forms.Timer flushTimer;

        /// <summary>
        /// 出力情報
        /// </summary>
        class OutputInfo
        {
            internal string ProgramName { get; set; }
            internal string TitleName { get; set; }
            internal DateTime StartTime { get; set; }

            internal OutputInfo(string pgName, string titleName, DateTime startTime)
            {
                this.ProgramName = pgName;
                this.TitleName = titleName;
                this.StartTime = startTime;
            }

            /// <summary>
            /// 同一値か否か
            /// </summary>
            /// <param name="pgName"></param>
            /// <param name="titleName"></param>
            /// <returns></returns>
            internal bool IsSame(string pgName, string titleName)
            {
                return (pgName == this.ProgramName && titleName == this.TitleName) ? true : false;
            }

            /// <summary>
            /// 初回は空白が入るので、その情報は出力する必要なし
            /// </summary>
            /// <returns></returns>
            internal bool IsValid()
            {
                return this.ProgramName != string.Empty ? true : false;
            }
        }

        /// <summary>
        /// 出力情報の記憶用
        /// </summary>
        OutputInfo preInfo;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TitileHistoryLogger()
        {
            this.LogFile = null;

            preInfo = new OutputInfo("", "", DateTime.Now);

            InitFlushTimer();
        }

        /// <summary>
        /// ログのフラッシュ用タイマーの初期化
        /// </summary>
        private void InitFlushTimer()
        {
            flushTimer = new System.Windows.Forms.Timer();
            flushTimer.Interval = 60 * 1000;
            flushTimer.Tick += new EventHandler(flushTimer_Tick);
            flushTimer.Start();
        }

        /// <summary>
        /// ログのフラッシュ処理
        /// タイマーにより起動される
        /// </summary>
        /// <param name="sender">-</param>
        /// <param name="e">-</param>
        private void flushTimer_Tick(object sender, EventArgs e)
        {
            if (this.logStreamWriter != null)
            {
                this.logStreamWriter.Flush();
            }
        }

        /// <summary>
        /// ログ出力を行う
        /// </summary>
        /// <param name="logRetainDay"></param>
        /// <param name="logDir"></param>
        /// <param name="titleText"></param>
        public void LogOutput(int logRetainDay, string logDir, string titleText, string processName)
        {
            if( this.preInfo.IsSame(processName, titleText ) == true )
            {
                return;
            }

            DateTime currentDateTime = DateTime.Now;

            FileInfo fi = SetLogFileInfo(logRetainDay, logDir, ref currentDateTime);

            OpenLogFile(fi);

            DeleteOldLogIfNeed(currentDateTime);

            LogOutPutDetail(currentDateTime);

            this.preInfo = new OutputInfo(processName, titleText, currentDateTime);
        }


        private void LogOutPutDetail(DateTime currentDateTime)
        {
            if (this.preInfo.IsValid() == false)
            {
                return;
            }
            this.logStreamWriter.WriteLine(
                CreateLogOutput(currentDateTime)
                );
        }

        /// <summary>
        /// ログ出力内容を作成する
        /// </summary>
        /// <param name="titleText"></param>
        /// <param name="currentDateTime"></param>
        /// <returns></returns>
        private string CreateLogOutput(DateTime currentDateTime)
        {
            string writeLog = string.Format(
                LogFileFormat,
                this.preInfo.StartTime.ToShortDateString(),
                this.preInfo.StartTime.ToLongTimeString(),
                (currentDateTime - this.preInfo.StartTime).ToString(),
                this.preInfo.ProgramName,
                this.preInfo.TitleName);
            return writeLog;
        }

        /// <summary>
        /// ログ出力先のファイル情報を生成する
        /// </summary>
        /// <param name="logRetainDay"></param>
        /// <param name="logDir"></param>
        /// <param name="currentDateTime"></param>
        /// <returns></returns>
        private FileInfo SetLogFileInfo(int logRetainDay, string logDir, ref DateTime currentDateTime)
        {
            this.LogRetainDay = logRetainDay;
            this.LogDir = logDir;
            if (this.LogDir.EndsWith(@"\") == false)
            {
                this.LogDir = this.LogDir + "\\";
            }
            FileInfo fi = new FileInfo(MakeLogFileName(currentDateTime));
            return fi;
        }

        private string MakeLogFileName(DateTime currentDateTime)
        {
            return this.LogDir +
                            currentDateTime.ToString(LogFileNameFormat) +
                            "." +
                            System.Diagnostics.Process.GetCurrentProcess().Id.ToString() +
                            "." +
                            LogFileExtension;
        }

        /// <summary>
        /// ログファイルをオープンする
        /// </summary>
        /// <param name="newfile"></param>
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
            this.logStreamWriter = new StreamWriter(this.LogFile.Open(FileMode.Append,FileAccess.Write,FileShare.Read), Encoding.GetEncoding("shift-jis"));
            this.logStreamWriter.WriteLine(LogFileTitleFormat);
        }

        /// <summary>
        /// 不要なログを削除する
        /// </summary>
        /// <param name="current"></param>
        private void DeleteOldLogIfNeed(DateTime current)
        {
            DirectoryInfo di = new DirectoryInfo(this.LogDir);
            DateTime deleteBaseDate = current.AddDays(-this.LogRetainDay);
            string deleteBaseName = deleteBaseDate.ToString(LogFileNameFormat);

            FileInfo[] files = di.GetFiles("*" + LogFileExtension);
            for (int i = 0; i < files.Length; i++)
            {
                string targetBasename = files[i].Name.Replace(files[i].Extension, "");
                if (deleteBaseName.CompareTo(targetBasename) >= 0)
                {
                    // 削除できなくともエラーは無視する
                    try
                    {
                        files[i].Delete();
                    }
                    catch 
                    {
                    }
                }
            }
        }


        #region IDisposable メンバ
        /// <summary>
        /// 最終処理
        /// </summary>
        public void Dispose()
        {
            if (flushTimer != null)
            {
                flushTimer.Stop();
                flushTimer = null;
            }
            if (logStreamWriter != null)
            {
                this.logStreamWriter.WriteLine(
                    CreateLogOutput(DateTime.Now)
                    );
                logStreamWriter.Flush();
                logStreamWriter.Close();
                logStreamWriter.Dispose();
                logStreamWriter = null;
            }
        }

        #endregion
    }
}
