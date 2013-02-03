using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Me.Amon.Api.Enums;
using Me.Amon.Api.Structures;

namespace Me.Amon.Api.User32
{
    public class User32 : User32API
    {
        [DllImport("Psapi.dll", SetLastError = true)]
        public static extern bool EnumProcesses(
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U4)] [In][Out] UInt32[] processIds,
              UInt32 arraySizeBytes,
              [MarshalAs(UnmanagedType.U4)] out UInt32 bytesCopied
           );
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(ProcessAccessFlags dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("psapi.dll")]
        public static extern uint GetModuleBaseName(IntPtr hProcess, IntPtr hModule, out StringBuilder lpBaseName, uint nSize);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(IntPtr hObject);

        [DllImport("psapi.dll", SetLastError = true)]
        public static extern bool EnumProcessModules(IntPtr hProcess,
        [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U4)] [In][Out] uint[] lphModule, uint cb, [MarshalAs(UnmanagedType.U4)] out uint lpcbNeeded);

        public static List<IntPtr> EnumWindows()
        {
            List<IntPtr> windows = new List<IntPtr>();
            StringBuilder title = new StringBuilder(255);
            int len;
            EnumDesktopWindows(IntPtr.Zero, delegate(IntPtr hWnd, IntPtr lParam)
            {
                len = GetWindowText(hWnd, title, title.Capacity + 1);
                if (IsWindowVisible(hWnd) && len > 0)
                {
                    windows.Add(hWnd);
                }
                return true;
            }, IntPtr.Zero);

            return windows;
        }

        public static IntPtr NextWindow(IntPtr curr)
        {
            IntPtr last = IntPtr.Zero;
            StringBuilder title = new StringBuilder(255);
            int len;
            bool find;
            EnumDesktopWindows(IntPtr.Zero, delegate(IntPtr hWnd, IntPtr lParam)
            {
                len = GetWindowText(hWnd, title, title.Capacity + 1);
                if (!IsWindowVisible(hWnd) || len < 1)
                {
                    return true;
                }
                find = (last != curr);
                last = hWnd;
                return find;
            }, IntPtr.Zero);

            return last;
        }

        public static void SwitchWindow(IntPtr dstWnd)
        {
            if (GetForegroundWindow() == dstWnd || dstWnd == IntPtr.Zero)
            {
                return;
            }

            ShowWindow(dstWnd, ShowWindowCmd.SW_RESTORE);
            SetForegroundWindow(dstWnd);

            //IntPtr curWnd = GetForegroundWindow();
            //int temp = 0;
            //uint curTid = GetCurrentThreadId();
            //uint oldTid = GetWindowThreadProcessId(curWnd, ref temp);
            //AttachThreadInput(curTid, oldTid, true);
            //SetForegroundWindow(dstWnd);
            //AttachThreadInput(curTid, oldTid, false);
        }

        public static void SendKeys(IntPtr txtHnd, string text)
        {
            IntPtr wndHnd = GetParent(txtHnd);
            while (wndHnd != IntPtr.Zero)
            {
                txtHnd = wndHnd;
                wndHnd = GetParent(txtHnd);
            }

            ShowWindow(txtHnd, ShowWindowCmd.SW_RESTORE);
            SetForegroundWindow(txtHnd);
            System.Windows.Forms.SendKeys.SendWait(text);
            System.Windows.Forms.SendKeys.Flush();
        }

        public static void RestoreWindow(IntPtr handle)
        {
            var wp = new WINDOWPLACEMENT();
            GetWindowPlacement(handle, ref wp);
            const int cmd = (int)Enums.ShowWindowCmd.SW_SHOWNORMAL;
            if (cmd != wp.showCmd)
            {
                wp.showCmd = cmd; // 1- Normal; 2 - Minimize; 3 - Maximize;
                SetWindowPlacement(handle, ref wp);
            }
        }

        public static void PastMessage(IntPtr txtHnd, string txt)
        {
            if (txtHnd != IntPtr.Zero)
            {
                String old = Clipboard.GetText();
                Clipboard.SetText(txt);
                SendMessageA(txtHnd, (int)WindowMessage.WM_PASTE, 0, 0);
                if (string.IsNullOrEmpty(old))
                {
                    Clipboard.Clear();
                }
                else
                {
                    Clipboard.SetText(old);
                }
            }
        }

        public static void PastMessage(IntPtr txtHnd, Image img)
        {
            if (txtHnd != IntPtr.Zero)
            {
                String old = Clipboard.GetText();
                Clipboard.SetImage(img);
                SendMessageA(txtHnd, (int)WindowMessage.WM_PASTE, 0, 0);
                if (string.IsNullOrEmpty(old))
                {
                    Clipboard.Clear();
                }
                else
                {
                    Clipboard.SetText(old);
                }
            }
        }

        /// <summary>
        /// Get the associated Icon for a file or application, this method always returns
        /// an icon.  If the strPath is invalid or there is no idonc the default icon is returned
        /// </summary>
        /// <param name="strPath">full path to the file</param>
        /// <param name="bSmall">if true, the 16x16 icon is returned otherwise the 32x32</param>
        /// <returns></returns>
        public static SHFILEINFO GetFileInfo(string strPath, bool bSmall)
        {
            SHFILEINFO info = new SHFILEINFO();
            int cbFileInfo = Marshal.SizeOf(info);
            FileInfoFlags flags = FileInfoFlags.SHGFI_ICON | FileInfoFlags.SHGFI_USEFILEATTRIBUTES;
            flags |= bSmall ? FileInfoFlags.SHGFI_SMALLICON : FileInfoFlags.SHGFI_LARGEICON;

            SHGetFileInfo(strPath, (uint)FileAttributes.Normal, ref info, (uint)cbFileInfo, (uint)flags);
            return info;
        }

        public static Rectangle GetWindowRect(IntPtr hWnd)
        {
            Debug.Assert(hWnd != IntPtr.Zero);
            var rect = new RECT();
            if (GetWindowRect(hWnd, ref rect) == false)
                throw new Exception("GetWindowRect failed");
            return rect.ToRectangle();
        }

        public static string GetWindowText(IntPtr hWnd)
        {
            Debug.Assert(hWnd != IntPtr.Zero);
            var WindowText = new StringBuilder(GetWindowTextLength(hWnd) + 1);
            GetWindowText(hWnd, WindowText, WindowText.Capacity);
            return WindowText.ToString();
        }

        public static void MouseEvents()
        {
            IntPtr ptrTaskbar = FindWindow("Shell_TrayWnd", null);
            if (ptrTaskbar == IntPtr.Zero)
            {
                //MessageBox.Show("No taskbar found.");
                return;
            }

            IntPtr ptrStartBtn = FindWindowEx(ptrTaskbar, IntPtr.Zero, "Button", null);
            if (ptrStartBtn == IntPtr.Zero)
            {
                //MessageBox.Show("No start button found.");
                return;
            }

            var rect = new RECT();
            GetWindowRect(ptrStartBtn, ref rect);

            int X = (rect.left + rect.right) / 2;
            int Y = (rect.top + rect.bottom) / 2;

            SetCursorPos(X, Y);
            MouseEvent(Enums.MouseEvent.LeftDown, 0, 0, 0, 0);
            MouseEvent(Enums.MouseEvent.LeftUp, 0, 0, 0, 0);
        }

        /// <summary>
        /// Paint a rect into the given window
        /// </summary>
        /// <param name="window"></param>
        public static void ShowInvertRectTracker(IntPtr window)
        {
            if (window != IntPtr.Zero)
            {
                // get the coordinates from the window on the screen
                Rectangle WindowRect = GetWindowRect(window);
                // get the window's device context
                IntPtr dc = GetWindowDC(window);

                // Create an inverse pen that is the size of the window border
                Gdi32.Gdi32API.SetROP2(dc, (int)RopMode.R2_NOT);

                Color color = Color.FromArgb(0, 255, 0);
                IntPtr Pen = Gdi32.Gdi32API.CreatePen((int)PenStyles.PS_INSIDEFRAME, 3 * GetSystemMetrics((int)SystemMetrics.SM_CXBORDER), (uint)color.ToArgb());

                // Draw the rectangle around the window
                IntPtr OldPen = Gdi32.Gdi32API.SelectObject(dc, Pen);
                IntPtr OldBrush = Gdi32.Gdi32API.SelectObject(dc, Gdi32.Gdi32API.GetStockObject((int)StockObjects.NULL_BRUSH));
                Gdi32.Gdi32API.Rectangle(dc, 0, 0, WindowRect.Width, WindowRect.Height);

                Gdi32.Gdi32API.SelectObject(dc, OldBrush);
                Gdi32.Gdi32API.SelectObject(dc, OldPen);

                //release the device context, and destroy the pen
                ReleaseDC(window, dc);
                Gdi32.Gdi32API.DeleteObject(Pen);
            }
        }

        /// <summary>
        /// return the window from the given point
        /// </summary>
        /// <param name="point"></param>
        /// <returns>if return == IntPtr.Zero no window was found</returns>
        public static IntPtr ChildWindowFromPoint(Point point)
        {
            IntPtr WindowPoint = WindowFromPoint(point);
            if (WindowPoint == IntPtr.Zero)
                return IntPtr.Zero;

            if (ScreenToClient(WindowPoint, ref point) == false)
                throw new Exception("ScreenToClient failed");

            IntPtr Window = ChildWindowFromPointEx(WindowPoint, point, 0);
            if (Window == IntPtr.Zero)
                return WindowPoint;

            if (ClientToScreen(WindowPoint, ref point) == false)
                throw new Exception("ClientToScreen failed");

            if (IsChild(GetParent(Window), Window) == false)
                return Window;

            // create a list to hold all childs under the point
            var WindowList = new ArrayList();
            while (Window != IntPtr.Zero)
            {
                Rectangle rect = GetWindowRect(Window);
                if (rect.Contains(point))
                    WindowList.Add(Window);
                Window = GetWindow(Window, GetWindowCmd.GW_HWNDNEXT);
            }

            // search for the smallest window in the list
            int MinPixel = GetSystemMetrics((int)SystemMetrics.SM_CXFULLSCREEN) * GetSystemMetrics((int)SystemMetrics.SM_CYFULLSCREEN);
            foreach (object t in WindowList)
            {
                Rectangle rect = GetWindowRect((IntPtr)t);
                int ChildPixel = rect.Width * rect.Height;
                if (ChildPixel < MinPixel)
                {
                    MinPixel = ChildPixel;
                    Window = (IntPtr)t;
                }
            }
            return Window;
        }
    }
}
