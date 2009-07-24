﻿using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using clockatt.Configration;
using W32NativeService;

namespace clockatt
{
    public partial class MainForm : Form
    {

        /// <summary>
        /// 文字描画以外に必要なウィンドウサイズのマージン
        /// </summary>
        private const int SizeMargin = 4;

        /// <summary>
        /// 前回のアクティブウィンドウハンドル
        /// </summary>
        private int preHwnd = 0;

        /// <summary>
        /// 前回のフォームサイズ
        /// </summary>
        private Rectangle preRect = Rectangle.Empty;

        /// <summary>
        /// 休日設定ファイルが保存されているフォルダ名
        /// </summary>
        private const string HOLIDAY_CONDIGDIR = "Holiday";

        /// <summary>
        /// 休日設定(複数可)
        /// </summary>
        private HolidayConfigCollection[] HolidaySettings { get; set; }

        /// <summary>
        /// 日時描画時のブラシ
        /// </summary>
        private Brush DrawBrush { get; set; }

        /// <summary>
        /// タイトル履歴用ログ出力クラス
        /// </summary>
        private TitileHistoryLogger logger;

        private const int NOCURRENTWINDOW = 0;

        /// <summary>
        /// 日時表示文字列
        /// </summary>
        public string DispString { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainForm()
        {
            this.DrawBrush = new SolidBrush(this.ForeColor);
            InitializeComponent();
            this.Icon = clockatt.Properties.Resources.clockatt256;
            this.SetDateTimeLabel();
            logger = new TitileHistoryLogger();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitData();
            StartTimers();
            InitTaskInfoNotify();
        }

        #region 初期化処理
        /// <summary>
        /// タスクバーに表示するNotifyの設定
        /// </summary>
        private void InitTaskInfoNotify()
        {
            this.taskInfoNotify.Icon = clockatt.Properties.Resources.clockatt256;
            this.taskInfoNotify.Visible = true;
        }

        /// <summary>
        /// 各種タイマーの開始
        /// </summary>
        private void StartTimers()
        {
            this.DspTimer.Start();
            this.LocateTimer.Start();
        }
        
        /// <summary>
        /// 休日設定のフォルダ情報を取得する
        /// 休日設定フォルダがない場合には、休日設定フォルダを作成する
        /// </summary>
        /// <param name="executeDirectory">実行ファイルパス情報</param>
        /// <returns>休日設定のフォルダ情報</returns>
        private DirectoryInfo GetHolidayDirectoryInfo(DirectoryInfo executeDirectory)
        {
            DirectoryInfo []subdir =  executeDirectory.GetDirectories(HOLIDAY_CONDIGDIR);
            if (subdir.Length != 0)
            {
                return subdir[0];
            }
            executeDirectory.CreateSubdirectory(HOLIDAY_CONDIGDIR);

            subdir =  executeDirectory.GetDirectories(HOLIDAY_CONDIGDIR);
            if (subdir.Length != 0)
            {
                return subdir[0];
            }
            return null;
        }

        /// <summary>
        /// 休日設定を読み込む
        /// </summary>
        /// <param name="executeDirectory"></param>
        private void ReadHolidayConfig(DirectoryInfo executeDirectory)
        {
            DirectoryInfo holidayDir = GetHolidayDirectoryInfo(executeDirectory);

            FileInfo[] holidayConfigFileInfos = holidayDir.GetFiles();
            if (holidayConfigFileInfos.Length == 0)
            {
                MessageBox.Show("休日設定がされていません");
            }

            this.HolidaySettings = new HolidayConfigCollection[holidayConfigFileInfos.Length];
            for (int i = 0; i < HolidaySettings.Length; i++)
            {
                this.HolidaySettings[i] = ReadEachHolidayConfig(holidayConfigFileInfos[i].FullName);
            }
        }

        /// <summary>
        /// ここの休日設定を読み込む
        /// </summary>
        /// <param name="holidayConfigFileInfo"></param>
        /// <returns></returns>
        private HolidayConfigCollection ReadEachHolidayConfig(string holidayConfigFileName)
        {
            HolidayConfigCollection　result = new HolidayConfigCollection();
            if (File.Exists(holidayConfigFileName))
            {
                StreamReader sr = null;
                try
                {
                    sr = new StreamReader(holidayConfigFileName);
                }
                catch (Exception exp)
                {
                    MessageBox.Show("休日の設定ファイルが開けませんでした" + exp.Message);
                }
                if (sr != null)
                {
                    try
                    {
                        result.ReadConfig(sr);
                    }
                    catch (ApplicationException exp)
                    {
                        MessageBox.Show(exp.Message);
                    }
                    finally
                    {
                        sr.Close();
                    }
                }

            }
            return result;
        }


        /// <summary>
        /// 各種データの初期化
        /// </summary>
        private void InitData()
        {
            DirectoryInfo executeDirectory = new DirectoryInfo((new FileInfo(Application.ExecutablePath)).DirectoryName);

            ReadHolidayConfig(executeDirectory);
            if (Properties.Settings.Default.IsInitial == true)
            {
                Properties.Settings.Default.Upgrade();

                Properties.Settings.Default.IsInitial = false;
            }
            SetDisplayDesign();
        }

        #endregion 初期化処理

        #region 終了処理

        /// <summary>
        /// 閉じる場合の処理
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            Properties.Settings.Default.Save();
            this.taskInfoNotify.Visible = false;
            this.taskInfoNotify.Dispose();
            this.logger.Dispose();
        }

        #endregion 終了処理


        #region タイマー関連

        /// <summary>
        /// 表示用タイマーのイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DspTimer_Tick(object sender, EventArgs e)
        {
            SetNewDateTime();
        }

        /// <summary>
        /// 表示位置決定 タイマー処理
        /// 一定間隔で呼び出される
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LocateTimer_Tick(object sender, EventArgs e)
        {
            SetForeGround();
        }

        #endregion タイマー関連


        #region アクティブウィンドウ張り付き

        /// <summary>
        /// カレントウィンドウ位置をアクティブウィンドウのタイトルバーにあわせる
        /// </summary>
        private void SetForeGround()
        {
            int hwnd = GetForeGroundWhnd();
            if (hwnd == 0)
            {
                return;
            }

            W32Native.wWINDOWINFO info;
            bool ret = GetWindowInfo(hwnd, out info);
            if (ret == false)
            {
                if (preHwnd == 0)
                {
                    SetDeskTopRight();
                }
                return;
            }

            OutputTitleHistory(hwnd);

            SetWindowRectangle(hwnd, info);

            this.preHwnd = hwnd;

        }

        /// <summary>
        /// アクティブウィンドウのウィンドウハンドルを取得する
        /// </summary>
        /// <returns></returns>
        private int GetForeGroundWhnd()
        {
            // 現在のアクティブウィンドウのハンドルを取得
            int hwnd = W32Native.GetForegroundWindow();
            if (hwnd == 0)
            {
                return NOCURRENTWINDOW;
            }
            if (hwnd == (int)this.Handle)
            {
                // アクティブウィンドが自分自身だった場合は
                if (preHwnd == 0)
                {
                    // 前のアクティブウィンドウがない場合にはデスクトップ右上にする
                    this.SetDeskTopRight();
                    return NOCURRENTWINDOW;
                }
                hwnd = this.preHwnd;
            }
            uint wpid = 0;
            W32Native.GetWindowThreadProcessId((IntPtr)hwnd, ref wpid);
            if (Process.GetCurrentProcess().Id == wpid)
            {
                return NOCURRENTWINDOW;
            }

            return hwnd;
        }

        /// <summary>
        /// カレントウィンドウの表示位置をセットする
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="info"></param>
        private void SetWindowRectangle(int hwnd, W32Native.wWINDOWINFO info)
        {
            W32Native.wTITLEBARINFO tbi = new W32Native.wTITLEBARINFO();
            tbi.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(tbi);
            bool result = W32Native.GetTitleBarInfo((IntPtr)hwnd, ref tbi);
            // Get TitleBar Size
            int titleHeight = tbi.rcTitleBar.bottom - tbi.rcTitleBar.top;
            int titleWidth = tbi.rcTitleBar.right - tbi.rcTitleBar.left;
            ArrayList ar = new ArrayList();
            ar.Add(W32Native.wTITLEELEMENT.TITLE_CLOSE_BUTTON);
            ar.Add(W32Native.wTITLEELEMENT.TITLE_HELP_BUTTON);
            ar.Add(W32Native.wTITLEELEMENT.TITLE_MAX_BUTTON);
            ar.Add(W32Native.wTITLEELEMENT.TITLE_MIN_BUTTON);
            int leftLength = 0;
            for (int i = 0; i < ar.Count; i++)
            {
                if (
                    !((tbi.rgstate[(int)ar[i]] & W32Native.STATE_SYSTEM_INVISIBLE) == W32Native.STATE_SYSTEM_INVISIBLE) &&
                    !((tbi.rgstate[(int)ar[i]] & W32Native.STATE_SYSTEM_OFFSCREEN) == W32Native.STATE_SYSTEM_OFFSCREEN)
                )
                {
                    leftLength += titleHeight - 1;
                }
            }
            int leftposx = info.rcWindow.right - this.Width - leftLength - 1;
            Point newpos = new Point(leftposx, info.rcWindow.top + 3);
            int newheight = titleHeight - 2;

            if( newheight > Screen.PrimaryScreen.WorkingArea.Height ||
                newheight < 0 )
            {
                newheight = 0;
            }

            // 前回と同じ結果である
            if (this.Height == newheight &&
                newpos.Equals(this.Location))
            {
                return;
            }

            if ((titleWidth - this.Width - leftLength - 1) < 0)
            {
                this.Hide();
            }
            else
            {
                this.Show();
            }
            this.Location = new Point(leftposx, info.rcWindow.top + 4);
            this.Height = newheight;

        }

        /// <summary>
        /// ウィンドウ情報を取得する
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        private bool GetWindowInfo(int hwnd, out W32Native.wWINDOWINFO info)
        {
            info = new W32Native.wWINDOWINFO();
            info.cbSize = (uint)Marshal.SizeOf(info);
            bool ret = W32Native.GetWindowInfo((IntPtr)hwnd, ref info);
            return ret;
        }

        /// <summary>
        /// 表示位置をデスクトップの右上に設定する
        /// アクティブウィンドウがない場合に利用
        /// </summary>
        private void SetDeskTopRight()
        {
            this.Location = new Point(Screen.FromControl(this).WorkingArea.Right - this.Width,
                Screen.FromControl(this).WorkingArea.Top + 0);
        }
        
        /// <summary>
        /// タイトル履歴ログを出力する
        /// </summary>
        /// <param name="hwnd"></param>
        private void OutputTitleHistory(int hwnd)
        {
            if (Properties.Settings.Default.IsLogTitleHistory == true)
            {
                StringBuilder titleSb = new StringBuilder(200);
                W32Native.GetWindowText(hwnd, titleSb, 100);
                logger.LogOutput(Properties.Settings.Default.TitleHistoryLogRetainDay,
                    Properties.Settings.Default.TitleHistoryLogDir,
                    titleSb.ToString());
            }
        }

        #endregion アクティブウィンドウ張り付き

        #region 描画関連

        /// <summary>
        /// 日時表示用の設定値をセットする
        /// </summary>
        private void SetDisplayDesign()
        {
            this.Font = (Font)Properties.Settings.Default.PropertyValues["Font"].PropertyValue;
            this.ForeColor = (Color)Properties.Settings.Default.PropertyValues["ForeColor"].PropertyValue;
            DrawBrush = new SolidBrush(this.ForeColor);
            this.BackColor = (Color)Properties.Settings.Default.PropertyValues["BackColor"].PropertyValue;
        }


        /// <summary>
        /// 新しい日時描画文字を設定する
        /// </summary>
        private void SetNewDateTime()
        {
            DspTimer.Stop();

            this.SetDateTimeLabel();

            DateTime nt = DateTime.Now;
            this.DspTimer.Interval = 1000 - nt.Millisecond;
            DspTimer.Start();
        }

        /// <summary>
        /// 日時描画文字を設定する
        /// </summary>
        private void SetDateTimeLabel()
        {
            DateTime nc = DateTime.Now;
            this.DispString = DateTimeFormatUtil.GetFormatedDateTime(nc,
                (bool)Properties.Settings.Default.PropertyValues["IsShowYear"].PropertyValue,
                (bool)Properties.Settings.Default.PropertyValues["IsShowWeek"].PropertyValue,
                (bool)Properties.Settings.Default.PropertyValues["IsWeekWareki"].PropertyValue,
                (bool)Properties.Settings.Default.PropertyValues["IsShowTime"].PropertyValue,
                (bool)Properties.Settings.Default.PropertyValues["IsShowSecond"].PropertyValue);

            this.taskInfoNotify.Text = this.DispString;

            ResizeToDispString();

            this.Invalidate();
        }

        /// <summary>
        /// 描画文字に応じてウィンドウサイズを変更する
        /// </summary>
        private void ResizeToDispString()
        {
            Graphics g = Graphics.FromHwnd(this.Handle);
            SizeF newsize = g.MeasureString(this.DispString, this.Font);


            newsize.Width += SizeMargin;
            newsize.Height += SizeMargin;

            // 必要ならサイズを変更する
            if (this.Width != (int)newsize.Width)
            {
                this.Width = (int)newsize.Width;
            }
            if (this.Height != (int)newsize.Height)
            {
                this.Height = (int)newsize.Height;
            }
        }

        /// <summary>
        /// 描画は独自に行う
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SetClip(e.ClipRectangle);
            e.Graphics.DrawString(this.DispString, this.Font, this.DrawBrush, 2, 2);
        }

        #endregion 描画関連

        #region マウス処理

        /// <summary>
        /// マウスクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                OpenContextMenu();
            }
            else
            {
                OpenCalendarDlg();
            }
        }

        /// <summary>
        /// 右クリックメニューの表示
        /// </summary>
        private void OpenContextMenu()
        {
            this.RightClickMenu.Show(this, 0, 0);
        }

        /// <summary>
        /// カレンダーを表示する
        /// </summary>
        private void OpenCalendarDlg()
        {
            CalendarConfigration calConf = new CalendarConfigration(Properties.Settings.Default);

            CalenderForm dlg = new CalenderForm(this, this.HolidaySettings, calConf);
            dlg.ShowDialog(this);
        }

        /// <summary>
        /// 右クリック設定 選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void miConfigClock_Click(object sender, System.EventArgs e)
        {
            OpenSettingDlg();
        }

        /// <summary>
        /// 設定ダイアログを表示する
        /// </summary>
        private void OpenSettingDlg()
        {
            Configration.ConfigrationDlg dlg = new ConfigrationDlg(Properties.Settings.Default, this.HolidaySettings);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                this.SetDateTimeLabel();
                SetDisplayDesign();
            }
        }

        /// <summary>
        /// 終了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion マウス処理
    }
}
