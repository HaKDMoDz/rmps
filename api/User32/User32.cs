using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using com.magickms.api.Enum;
using com.magickms.api.Struct;
using com.magickms.api.Enums;

namespace com.magickms.api.User32
{
    public class User32 : User32API
    {
        public static void SwitchWindow(IntPtr dstWnd)
        {
            if (GetForegroundWindow() == dstWnd)
            {
                return;
            }

            ShowWindow(dstWnd, api.Enum.ShowWindow.SW_RESTORE);
            SetForegroundWindow(dstWnd);

            //IntPtr curWnd = GetForegroundWindow();
            //int temp = 0;
            //uint curTid = GetCurrentThreadId();
            //uint oldTid = GetWindowThreadProcessId(curWnd, ref temp);
            //AttachThreadInput(curTid, oldTid, true);
            //SetForegroundWindow(dstWnd);
            //AttachThreadInput(curTid, oldTid, false);
        }

        public static void KeyPress(ushort scanCode)
        {
            INPUT input = new INPUT();
            input.type = InputType.INPUT_KEYBOARD;
            input.ki.dwFlags = (uint)api.Enum.KeyEvent.Zero;
            input.ki.wVk = scanCode;
            SendInput(1, ref input, Marshal.SizeOf(input));

            input = new INPUT();
            input.type = InputType.INPUT_KEYBOARD;
            input.ki.dwFlags = (uint)api.Enum.KeyEvent.Keyup;
            input.ki.wVk = scanCode;
            SendInput(1, ref input, Marshal.SizeOf(input));
        }

        public static bool KeyDown(ushort scanCode)
        {
            INPUT input = new INPUT();
            input.type = InputType.INPUT_KEYBOARD;
            input.ki.dwFlags = (uint)api.Enum.KeyEvent.Zero;
            input.ki.wVk = scanCode;

            return 1 == SendInput(1, ref input, Marshal.SizeOf(input));
        }

        public static bool KeyUp(ushort scanCode)
        {
            INPUT input = new INPUT();
            input.type = InputType.INPUT_KEYBOARD;
            input.ki.dwFlags = (uint)api.Enum.KeyEvent.Keyup;
            input.ki.wVk = scanCode;

            return 1 == SendInput(1, ref input, Marshal.SizeOf(input));
        }

        public static void MouseClick(int x, int y, MouseButton btn)
        {
            INPUT input1 = new INPUT();
            INPUT input2 = new INPUT();
            input1.type = InputType.INPUT_MOUSE;
            input2.type = InputType.INPUT_MOUSE;

            switch (btn)
            {
                case MouseButton.Left:
                    input1.ki.dwFlags = (uint)api.Enum.MouseEvent.LeftDown;
                    input2.ki.dwFlags = (uint)api.Enum.MouseEvent.LeftUp;
                    break;
                case MouseButton.Right:
                    input1.ki.dwFlags = (uint)api.Enum.MouseEvent.RightDown;
                    input2.ki.dwFlags = (uint)api.Enum.MouseEvent.RightUp;
                    break;
                case MouseButton.Middle:
                    input1.ki.dwFlags = (uint)api.Enum.MouseEvent.MiddleDown;
                    input2.ki.dwFlags = (uint)api.Enum.MouseEvent.MiddleUp;
                    break;
                default:
                    return;
            }

            SetCursorPos(x, y);

            SendInput(1, ref input1, Marshal.SizeOf(input1));
            SendInput(1, ref input2, Marshal.SizeOf(input2));
        }

        public static bool MouseDown(int x, int y, MouseEvent mEvent)
        {
            SetCursorPos(x, y);

            INPUT input = new INPUT();
            input.type = InputType.INPUT_MOUSE;
            input.ki.dwFlags = (uint)mEvent;

            return 1 == SendInput(1, ref input, Marshal.SizeOf(input));
        }

        public static bool MouseUp(int x, int y, MouseEvent mEvent)
        {
            SetCursorPos(x, y);

            INPUT input = new INPUT();
            input.type = InputType.INPUT_MOUSE;
            input.ki.dwFlags = (uint)mEvent;

            return 1 == SendInput(1, ref input, Marshal.SizeOf(input));
        }

        public static void SendKeys(IntPtr txtHnd, string text)
        {
            IntPtr wndHnd = GetParent(txtHnd);
            while (wndHnd != IntPtr.Zero)
            {
                txtHnd = wndHnd;
                wndHnd = GetParent(txtHnd);
            }

            ShowWindow(txtHnd, api.Enum.ShowWindow.SW_RESTORE);
            SetForegroundWindow(txtHnd);
            System.Windows.Forms.SendKeys.SendWait(text);
            System.Windows.Forms.SendKeys.Flush();
        }

        public static string ReadMessage(IntPtr txtHnd)
        {
            if (txtHnd != IntPtr.Zero)
            {
                int TextLen;
                TextLen = SendMessage(txtHnd, WindowMessage.WM_GETTEXTLENGTH, 0, 0);
                Byte[] byt = new Byte[TextLen];
                User32.SendMessageA(txtHnd, WindowMessage.WM_GETTEXT, TextLen + 1, byt);
                return Encoding.Default.GetString(byt);
            }
            return null;
        }

        public static void SendMessage(IntPtr txtHnd, string txt)
        {
            if (txtHnd != IntPtr.Zero)
            {
                SendMessageA(txtHnd, WindowMessage.WM_SETTEXT, 0, txt);
            }
        }

        public static void PastMessage(IntPtr txtHnd, string txt)
        {
            if (txtHnd != IntPtr.Zero)
            {
                String old = Clipboard.GetText();
                Clipboard.SetText(txt);
                SendMessageA(txtHnd, WindowMessage.WM_PASTE, 0, 0);
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

        public static Rectangle GetWindowRect(IntPtr hWnd)
        {
            Debug.Assert(hWnd != IntPtr.Zero);
            RECT rect = new RECT();
            if (GetWindowRect(hWnd, ref rect) == false)
                throw new Exception("GetWindowRect failed");
            return rect.ToRectangle();
        }

        public static string GetWindowText(IntPtr hWnd)
        {
            Debug.Assert(hWnd != IntPtr.Zero);
            StringBuilder WindowText = new StringBuilder(GetWindowTextLength(hWnd) + 1);
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

            RECT rect = new RECT();
            GetWindowRect(ptrStartBtn, ref rect);

            int X = (rect.Left + rect.Right) / 2;
            int Y = (rect.Top + rect.Bottom) / 2;

            SetCursorPos(X, Y);
            MouseEvent(api.Enum.MouseEvent.LeftDown, 0, 0, 0, 0);
            MouseEvent(api.Enum.MouseEvent.LeftUp, 0, 0, 0, 0);
        }
    }
}
