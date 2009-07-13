﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using W32NativeService;
using System.Runtime.InteropServices;
using System.IO;


namespace clockatt
{
    public partial class MainForm : Form
    {
        private int preHwnd = 0;
        private Rectangle preRect = Rectangle.Empty;

        static private readonly string HOLIDAY_CONDIGDIR = "Holiday";

        ClockConfigration pClockConfig;
        CalendarConfigration pCelnedarConfig;

        private HolidayConfigCollection []pHolidaySettings;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            this.Icon = clockatt.Properties.Resources.clockatt256;
            initData();
        }

        private DirectoryInfo CreateHolidayDirectoryIfNeed(DirectoryInfo executeDirectory)
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

        private void initHolidayConfig(DirectoryInfo executeDirectory)
        {
            this.pHolidaySettings = new HolidayConfigCollection[] { };
            DirectoryInfo holidayDir = CreateHolidayDirectoryIfNeed(executeDirectory);

            FileInfo[] holidayConfigFileInfos = holidayDir.GetFiles();
            if (holidayConfigFileInfos.Length == 0)
            {
                MessageBox.Show("休日設定がされていません");
            }

            pHolidaySettings = new HolidayConfigCollection[holidayConfigFileInfos.Length];
            string holidayConfigFile;
            for (int i = 0; i < pHolidaySettings.Length; i++)
            {
                holidayConfigFile = holidayConfigFileInfos[i].FullName;
                pHolidaySettings[i] = new HolidayConfigCollection();
                if (File.Exists(holidayConfigFile))
                {
                    StreamReader sr = null;
                    try
                    {
                        sr = new StreamReader(holidayConfigFile);
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show("休日の設定ファイルが開けませんでした" + exp.Message);
                    }
                    if (sr != null)
                    {
                        try
                        {
                            pHolidaySettings[i].ReadConfig(sr);
                        }
                        catch (ApplicationException exp)
                        {
                            MessageBox.Show(exp.Message);
                        }
                        sr.Close();
                    }

                }
            }
        }

        private void initClockConfig()
        {
            pClockConfig = new ClockConfigration();
            pClockConfig.Reload();
            dateTimeLabel.Font = new Font(pClockConfig.DrawFont.FontFamily.Name,pClockConfig.FontSize);
            dateTimeLabel.ForeColor = pClockConfig.ForeColor;
            dateTimeLabel.BackColor = pClockConfig.BackColor;
            this.BackColor = pClockConfig.BackColor;
        }

        private void initCalendarConfig()
        {
            pCelnedarConfig = new CalendarConfigration();
            pCelnedarConfig.Reload();
        }

        private void initData()
        {
            DirectoryInfo executeDirectory = new DirectoryInfo((new FileInfo(Application.ExecutablePath)).DirectoryName);

            initHolidayConfig(executeDirectory);
            initClockConfig();
            initCalendarConfig();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.pClockConfig.Save();
            this.pClockConfig.Save();
            this.taskInfoNotify.Visible = false;
            this.taskInfoNotify.Dispose();
        }

        /// <summary>
        /// 表示位置決定 タイマー処理
        /// 一定間隔で呼び出される
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LocateTimer_Tick(object sender, EventArgs e)
        {
            // 現在のアクティブウィンドウのハンドルを取得
            int hwnd =  W32Native.GetForegroundWindow();
            if (hwnd == 0)
            {
                return;
            }
            if (hwnd == (int)this.Handle)
            {
                // アクティブウィンドが自分自身だった場合は
                if (preHwnd == 0)
                {
                    // 前のアクティブウィンドウがない場合にはデスクトップ右上にする
                    this.SetDeskTopRight();
                    return;
                }
                hwnd = this.preHwnd;
            }
            uint wpid = 0;
            W32Native.GetWindowThreadProcessId((IntPtr)hwnd, ref wpid);
            if( Process.GetCurrentProcess().Id == wpid )
            {
                return;
            }

            W32Native.wWINDOWINFO info = new W32Native.wWINDOWINFO();
            info.cbSize = (uint)Marshal.SizeOf(info);
            bool ret = W32Native.GetWindowInfo((IntPtr)hwnd, ref info);
            if (ret == true)
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

                // 前回と同じ結果である
                if (this.Height == newheight &&
                    newpos.Equals(this.Location))
                {
                    return ;
                }

                if( ( titleWidth - this.Width - leftLength - 1 ) < 0 )
                {
                    this.Hide();
                }
                else{
                    this.Show();
                }
                this.Location = new Point(leftposx, info.rcWindow.top + 3);
                this.Height = newheight;

                this.preHwnd = hwnd;
            }
            else
            {
                if (preHwnd == 0)
                {
                    SetDeskTopRight();
                }
            }
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.DspTimer.Start();
            this.LocateTimer.Start();
            this.taskInfoNotify.Icon = clockatt.Properties.Resources.clockatt256;
            this.taskInfoNotify.Visible = true;
        }

        private void DspTimer_Tick(object sender, EventArgs e)
        {
            DspTimer.Stop();

            this.SetTimeLabel();

            DateTime nt = DateTime.Now;
            this.DspTimer.Interval = 1000 - nt.Millisecond;
            DspTimer.Start();
        }

        private void SetTimeLabel()
        {
            DateTime nc = DateTime.Now;
            this.dateTimeLabel.Text = GetFormatDateTime(nc);
            this.Invalidate();
            Application.DoEvents();

            // 必要ならサイズを変更する
            if (this.Width != this.dateTimeLabel.Width)
            {
                this.Width = this.dateTimeLabel.Width;
            }
            //if (this.Height != this.dateTimeLabel.Height)
            //{
            //    this.Height = this.dateTimeLabel.Height;
            //}
            this.taskInfoNotify.Text = this.dateTimeLabel.Text;
        }

        private string GetFormatDateTime(DateTime nc)
        {
            StringBuilder formatString = new StringBuilder();

            if (this.pClockConfig.IsShowYear == true)
            {
                formatString.Append("yyyy/");
            }
            formatString.Append("mm/dd");
            if (this.pClockConfig.IsShowWeek == true)
            {
                formatString.Append("(");
                switch (nc.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        formatString.Append("月");
                        break;
                    case DayOfWeek.Tuesday:
                        formatString.Append("火");
                        break;
                    case DayOfWeek.Wednesday:
                        formatString.Append("水");
                        break;
                    case DayOfWeek.Thursday:
                        formatString.Append("木");
                        break;
                    case DayOfWeek.Friday:
                        formatString.Append("金");
                        break;
                    case DayOfWeek.Saturday:
                        formatString.Append("土");
                        break;
                    case DayOfWeek.Sunday:
                        formatString.Append("日");
                        break;
                    default:
                        break;
                }
                formatString.Append(")");
            }

            if (this.pClockConfig.IsShowTime == true)
            {
                if (this.pClockConfig.IsShowSecond == true)
                {
                    formatString.Append(" " + nc.ToLongTimeString());
                }
                else
                {
                    formatString.Append(" " + nc.ToShortTimeString());
                }
            }
            return nc.ToString(formatString.ToString());
        }

        private void dateTimeLabel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.RightClickMenu.Show(this,0,0);
            }
            else
            {
                CalenderForm dlg = new CalenderForm(this,this.pHolidaySettings,this.pCelnedarConfig);
                dlg.ShowDialog(this);
            }
        }

        private void miQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
