using System;
using System.Windows.Forms;
using Me.Amon.Api.Delegates;
using Me.Amon.Api.Enums;
using Me.Amon.Api.User32;

namespace Me.Amon
{
    public partial class Demo : Form
    {
        public Demo()
        {
            InitializeComponent();
        }

        bool FindClock()
        {
            IntPtr hTaskbar = User32.FindWindowEx(IntPtr.Zero, IntPtr.Zero, "Shell_TrayWnd", null);
            if (hTaskbar == IntPtr.Zero)
            {
                return false;
            }
            IntPtr hNotify = User32.FindWindowEx(hTaskbar, IntPtr.Zero, "TrayNotifyWnd", null);
            if (hNotify == IntPtr.Zero)
            {
                return false;
            }
            IntPtr hClock = User32.FindWindowEx(hNotify, IntPtr.Zero, "TrayClockWClass", null);
            if (hClock == IntPtr.Zero)
            {
                return false;
            }
            IntPtr process = User32.GetWindowThreadProcessId(hClock, IntPtr.Zero);
            if (!User32.AttachThreadInput(Handle, process, false))
            {
                int err = System.Runtime.InteropServices.Marshal.GetLastWin32Error();
                return false;
            }
            IntPtr ptr = User32.SetWindowLongPtr(hClock, (int)WindowLongFlags.GWL_USERDATA, Handle);
            //ptr = User32.SetWindowLongPtr(hClock, (int)WindowLongFlags.GWL_WNDPROC, WindowProc);
            if (!User32.SetWindowPos(hClock, hNotify, 0, 0, 0, 0, 0))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            FindClock();
        }

        /// <summary>
        /// 隐藏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
        }

        private IntPtr WindowProc(IntPtr hWnd, uint msg, string wParam, string lParam)
        {
            return IntPtr.Zero;
        }
    }
}
