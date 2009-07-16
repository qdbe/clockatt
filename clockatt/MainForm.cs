using System;
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
using clockatt.Configration;

namespace clockatt
{
    public partial class MainForm : Form
    {
        private const int SizeMargin = 2;
        private int preHwnd = 0;
        private Rectangle preRect = Rectangle.Empty;

        static private readonly string HOLIDAY_CONDIGDIR = "Holiday";

        private HolidayConfigCollection []pHolidaySettings;

        private string pDispString = string.Empty;

        private Brush pDrawBrush;

        public string DispString
        {
            get { return pDispString; }
            set { pDispString = value; }
        }


        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainForm()
        {
            pDrawBrush = new SolidBrush(this.ForeColor);
            InitializeComponent();
            this.Icon = clockatt.Properties.Resources.clockatt256;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            initData();
            this.DspTimer.Start();
            this.LocateTimer.Start();
            this.taskInfoNotify.Icon = clockatt.Properties.Resources.clockatt256;
            this.taskInfoNotify.Visible = true;
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

        private void setTimeLabelDesign()
        {
            this.Font = (Font)Properties.Settings.Default.PropertyValues["Font"].PropertyValue;
            this.ForeColor = (Color)Properties.Settings.Default.PropertyValues["ForeColor"].PropertyValue;
            pDrawBrush = new SolidBrush(this.ForeColor);
            this.BackColor = (Color)Properties.Settings.Default.PropertyValues["BackColor"].PropertyValue;
        }


        private void initData()
        {
            DirectoryInfo executeDirectory = new DirectoryInfo((new FileInfo(Application.ExecutablePath)).DirectoryName);

            initHolidayConfig(executeDirectory);
            Properties.Settings.Default.Reload();
            setTimeLabelDesign();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Properties.Settings.Default.Save();
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
            this.pDispString = TimeUtil.GetFormatDateTime(nc,
                (bool)Properties.Settings.Default.PropertyValues["IsShowYear"].PropertyValue,
                (bool)Properties.Settings.Default.PropertyValues["IsShowWeek"].PropertyValue,
                (bool)Properties.Settings.Default.PropertyValues["IsWeekWareki"].PropertyValue,
                (bool)Properties.Settings.Default.PropertyValues["IsShowTime"].PropertyValue,
                (bool)Properties.Settings.Default.PropertyValues["IsShowSecond"].PropertyValue);

            Graphics g = Graphics.FromHwnd(this.Handle);
            SizeF newsize = g.MeasureString(this.pDispString, this.Font);

            this.Invalidate();

            // 必要ならサイズを変更する
            if (this.Width != newsize.Width)
            {
                this.Width = (int)newsize.Width + SizeMargin;
            }
            this.taskInfoNotify.Text = this.pDispString;
        }


        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.RightClickMenu.Show(this, 0, 0);
            }
            else
            {
                CalendarConfigration calConf = new CalendarConfigration(Properties.Settings.Default);

                CalenderForm dlg = new CalenderForm(this, this.pHolidaySettings, calConf);
                dlg.ShowDialog(this);
            }
        }

        void miConfigClock_Click(object sender, System.EventArgs e)
        {
            Configration.ConfigClockForm dlg = new ConfigClockForm(Properties.Settings.Default);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                this.SetTimeLabel();
                setTimeLabelDesign();
            }
        }


        private void miQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SetClip(e.ClipRectangle);
            e.Graphics.DrawString(this.pDispString, this.Font, this.pDrawBrush, 1, 1);
        }


    }
}
