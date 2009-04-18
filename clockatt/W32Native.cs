using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace W32NativeService
{
    class W32Native
    {
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct wWINDOWINFO
        {
            public uint cbSize;
            public wRECT rcWindow;
            public wRECT rcClient;
            public uint dwStyle;
            public uint dwExStyle;
            public uint dwWindowStatus;
            public uint cxWindowBorders;
            public uint cyWindowBorders;
            public ushort atomWindowType;
            public ushort wCreatorVersion;
        }

        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct wRECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct wTITLEBARINFO
        {
            public const int CCHILDREN_TITLEBAR = 5;
            public uint cbSize;
            public wRECT rcTitleBar;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = CCHILDREN_TITLEBAR + 1)]
            public uint[] rgstate;
        }

        public enum wTITLEELEMENT
        {
            TITLE_ITSELF = 0,
            TITLE_RESERVED = 1,
            TITLE_MIN_BUTTON = 2,
            TITLE_MAX_BUTTON = 3,
            TITLE_HELP_BUTTON = 4,
            TITLE_CLOSE_BUTTON = 5
        }

        public const uint STATE_SYSTEM_NONE = 0;
        public const uint STATE_SYSTEM_FOCUSABLE =    0x00100000;
        public const uint STATE_SYSTEM_INVISIBLE =    0x00008000;
        public const uint STATE_SYSTEM_OFFSCREEN =    0x00010000;
        public const uint STATE_SYSTEM_UNAVAILABLE =  0x00000001;
        public const uint STATE_SYSTEM_PRESSED = 0x00000008;


        [DllImport("User32.dll")]
        public static extern int GetWindowText(int hwnd, StringBuilder sb, int maxCount);

        [DllImport("User32.dll")]
        public static extern int GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern bool GetWindowInfo(IntPtr hwnd, ref wWINDOWINFO wi);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetTitleBarInfo(IntPtr hwnd, ref wTITLEBARINFO tbi);

        [DllImport("User32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, ref  uint lpdwProcessId  );

        [DllImport("User32.dll")]
        public static extern int IsWindowVisible(IntPtr hWnd);
    }
}
