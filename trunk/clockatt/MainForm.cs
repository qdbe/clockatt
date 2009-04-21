using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using W32NativeService;
using System.Runtime.InteropServices;


namespace clockatt
{
    public partial class MainForm : Form
    {
        int preHwnd = 0;

        public MainForm()
        {
            InitializeComponent();

            //this.SetStyle(
            //    ControlStyles.DoubleBuffer |
            //    ControlStyles.UserPaint |
            //    ControlStyles.AllPaintingInWmPaint,
            //    true);

            //this.UpdateStyles();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.taskInfoNotify.Visible = false;
        }

        private void LocateTimer_Tick(object sender, EventArgs e)
        {
            int hwnd =  W32Native.GetForegroundWindow();
            if (hwnd == 0)
            {
                return;
            }
            if (hwnd == (int)this.Handle)
            {
                if (preHwnd == 0)
                {
                    this.SetDeskTopLeft();
                }
                return;
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
                if( ( titleWidth - this.Width - leftLength - 1 ) < 0 )
                {
                    this.Hide();
                }
                else{
                    this.Show();
                }
                this.Location = new Point(leftposx, info.rcWindow.top + 3);
                this.Height = titleHeight - 2;
                preHwnd = hwnd;
            }
            else
            {
                if (preHwnd == 0)
                {
                    SetDeskTopLeft();
                }
            }
        }

        private void SetDeskTopLeft()
        {
            this.Location = new Point(Screen.FromControl(this).WorkingArea.Right - this.Width,
                Screen.FromControl(this).WorkingArea.Top + 0);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.DspTimer.Start();
            this.LocateTimer.Start();
            this.taskInfoNotify.Icon = clockatt.Properties.Resources.clockAttIcon;
            this.taskInfoNotify.Visible = true;
        }

        private void DspTimer_Tick(object sender, EventArgs e)
        {
            this.SetTimeLabel();
        }

        private void SetTimeLabel()
        {
            DspTimer.Stop();
            DateTime nc = DateTime.Now;
            this.dateTimeLabel.Text = GetFormatDateTime(nc);
            this.Invalidate();
            Application.DoEvents();
            this.taskInfoNotify.Text = this.dateTimeLabel.Text;
            DateTime nt = DateTime.Now;
            this.DspTimer.Interval = 1000 - nt.Millisecond;
            DspTimer.Start();
        }

        private string GetFormatDateTime(DateTime nc)
        {
            return nc.ToString();
        }

        private void timeLabel_Click(object sender, EventArgs e)
        {
        }

        private void dateTimeLabel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.RightClickMenu.Show(this,0,0);
            }
            else
            {
                CalenderForm dlg = new CalenderForm();
                dlg.ShowDialog(this);
            }
        }

        private void miQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
