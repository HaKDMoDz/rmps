using System;
using System.Text;
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

        bool FindExplorer()
        {
            UInt32 arraySize = 120;
            UInt32 arrayBytesSize = arraySize * sizeof(UInt32);
            UInt32[] processIds = new UInt32[arraySize];
            UInt32 bytesCopied;

            bool success = User32.EnumProcesses(processIds, arrayBytesSize, out bytesCopied);

            if (!success)
            {
                return false;
            }
            if (0 == bytesCopied)
            {
                return false;
            }

            UInt32 numIdsCopied = bytesCopied >> 2;

            if (0 != (bytesCopied & 3))
            {
                UInt32 partialDwordBytes = bytesCopied & 3;

                MessageBox.Show(string.Format("EnumProcesses copied {0} and {1}/4th DWORDS...  Please ask it for the other {2}/4th DWORD",
                    numIdsCopied, partialDwordBytes, 4 - partialDwordBytes));
                return false;
            }

            for (UInt32 index = 0; index < numIdsCopied; index++)
            {
                var w = User32.OpenProcess(ProcessAccessFlags.QueryInformation | ProcessAccessFlags.VMRead, false, (int)processIds[index]);
                if ((int)w <= 4)
                    continue;
                StringBuilder BaseName = new StringBuilder(256);
                var len = User32.GetModuleBaseName(w, (IntPtr)0, out BaseName, 256);
                var name = Encoding.Default.GetBytes(BaseName.ToString());
                textBox1.Text += Encoding.UTF8.GetString(name) + Environment.NewLine;
                User32.CloseHandle(w);
            }
            return true;
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtShow_Click(object sender, EventArgs e)
        {
            FindClock();
        }

        /// <summary>
        /// 隐藏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtHide_Click(object sender, EventArgs e)
        {
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                textBox1.Text += string.Format("{0}\t{1}{2}", lang.Culture.Name, lang.LayoutName,Environment.NewLine);
            }
            if (InputLanguage.DefaultInputLanguage.LayoutName.IndexOf("Keyboard") == -1 && InputLanguage.DefaultInputLanguage.Culture.Name.Equals("zh-CN"))
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
            }
            else
            {
                foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
                {
                    if (lang.Culture.Name.Equals("zh-CN") && lang.LayoutName.IndexOf("Keyboard") == -1)
                    {
                        InputLanguage.CurrentInputLanguage = lang;
                        break;
                    }
                }
            }
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
        }

        private IntPtr WindowProc(IntPtr hWnd, uint msg, string wParam, string lParam)
        {
            return IntPtr.Zero;
        }
    }
}
