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
        public MainForm()
        {
            InitializeComponent();

            this.SetStyle(
                ControlStyles.DoubleBuffer |
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint,
                true);

            this.UpdateStyles();
        }

        private void LocateTimer_Tick(object sender, EventArgs e)
        {
            int hwnd =  W32Native.GetForegroundWindow();
            if (hwnd == (int)this.Handle)
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
                for( int i = 0; i < ar.Count; i++ )
                {
                    if (
                        !((tbi.rgstate[(int)ar[i]] & W32Native.STATE_SYSTEM_INVISIBLE) == W32Native.STATE_SYSTEM_INVISIBLE) &&
                        !((tbi.rgstate[(int)ar[i]] & W32Native.STATE_SYSTEM_OFFSCREEN) == W32Native.STATE_SYSTEM_OFFSCREEN)
                    )
                    {
                        leftLength += titleHeight - 2;
                    }
                }
                this.Location = new Point(info.rcWindow.right - this.Width - leftLength, info.rcWindow.top + 1);
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.DspTimer.Start();
            this.LocateTimer.Start();
            this.taskInfoNotify.Visible = true;
        }

        private void DspTimer_Tick(object sender, EventArgs e)
        {
            this.SetTimeLabel();
        }

        private void SetTimeLabel()
        {
            this.timeLabel.Text = DateTime.Now.ToString();
            this.taskInfoNotify.BalloonTipText = this.timeLabel.Text;
        }
    }
}
