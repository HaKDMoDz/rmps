using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using Me.Amon.Api.Struct;
using Me.Amon.Api.Enums;

namespace Me.Amon.Api.User32
{
    public class User32API
    {
        #region User32.dll 常量
        public const int HWND_TOPMOST = -1;
        public const int SWP_SHOWWINDOW = 40;
        #endregion

        #region User32.dll 函数
        [DllImport("user32.dll")]
        public static extern bool AttachThreadInput(IntPtr idAttach, IntPtr idAttachTo, bool fAttach);
        /// <summary>
        /// 该函数将指定的窗口设置到Z序的顶部。
        /// </summary>
        [DllImport("user32.dll")]
        public static extern int BringWindowToTop(IntPtr hWnd);

        /// <summary>
        /// 调用下一个钩子
        /// </summary>
        /// <param name="idHook"></param>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWndRemove"></param>
        /// <param name="hWndNewNext"></param>
        /// <returns></returns>
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWndParent"></param>
        /// <param name="pt"></param>
        /// <param name="uFlags"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr ChildWindowFromPointEx(IntPtr hWndParent, Point pt, uint uFlags);

        /// <summary>
        /// 该函数将指定点的用户坐标转换成屏幕坐标。
        /// </summary>
        [DllImport("user32.dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, ref Point pt);

        /// <summary>
        /// 关闭剪切板
        /// </summary>
        [DllImport("user32.dll")]
        static public extern bool CloseClipboard();

        /// <summary>
        /// 打开清空
        /// </summary>
        [DllImport("user32.dll")]
        static public extern bool EmptyClipboard();

        /// <summary>
        /// 该函数可以激活一个或两个滚动条箭头或是使其失效。
        /// </summary>
        [DllImport("user32.dll")]
        public static extern int EnableScrollBar(IntPtr hWnd, uint flags, uint arrows);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpEnumFunc"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "EnumWindows", SetLastError = true)]
        public static extern bool EnumWindows(WNDENUMPROC lpEnumFunc, uint lParam);

        /// <summary>
        /// 该函数用指定的画刷填充矩形，此函数包括矩形的左上边界，但不包括矩形的右下边界。
        /// </summary>
        [DllImport("user32.dll")]
        public static extern int FillRect(IntPtr hDC, ref RECT rect, IntPtr hBrush);

        /// <summary>
        /// 获得窗口句柄
        /// </summary>
        /// <param name="className">窗体类名</param>
        /// <param name="windowName">窗口标题</param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern IntPtr FindWindow(string className, string windowName);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public extern static IntPtr GetActiveWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern short GetAsyncKeyState(int vkey);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpClassName"></param>
        /// <param name="nMaxCount"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        /// <summary>
        /// 该函数获取窗口客户区的坐标。
        /// </summary>
        [DllImport("user32.dll")]
        public extern static int GetClientRect(IntPtr hWnd, ref RECT rc);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetCurrentThreadId();

        /// <summary>
        /// 该函数检索一指定窗口的客户区域或整个屏幕的显示设备上下文环境的句柄，以后可以在GDI函数中使用该句柄来在设备上下文环境中绘图。hWnd：设备上下文环境被检索的窗口的句柄
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetDC(IntPtr hWnd);

        /// <summary>
        /// 该函数检索指定窗口客户区域或整个屏幕的显示设备上下文环境的句柄，在随后的GDI函数中可以使用该句柄在设备上下文环境中绘图。
        /// </summary>
        [DllImport("user32.dll")]
        public static extern IntPtr GetDCEx(IntPtr hWnd, IntPtr hRegion, uint flags);

        /// <summary>
        /// 该函数返回桌面窗口的句柄。桌面窗口覆盖整个屏幕。
        /// </summary>
        [DllImport("user32.dll")]
        static public extern IntPtr GetDesktopWindow();

        /// <summary>
        /// 获取对话框中子窗口控件的句柄
        /// </summary>
        [DllImport("user32.dll")]
        public extern static IntPtr GetDlgItem(IntPtr hDlg, int nControlID);

        /// <summary>
        /// 确定当前焦点位于哪个控件上。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr GetFocus();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern IntPtr GetForegroundWindow();

        /// <summary>
        /// 该函数将256个虚拟键的状态拷贝到指定的缓冲区中。
        /// </summary>
        [DllImport("user32.dll")]
        public static extern int GetKeyboardState(byte[] pbKeyState);

        /// <summary>
        /// 该函数检取指定虚拟键的状态。
        /// </summary>
        [DllImport("user32.dll")]
        public static extern ushort GetKeyState(int virtKey);

        /// <summary>
        /// 在一个矩形中装载指定菜单条目的屏幕坐标信息 
        /// </summary>
        [DllImport("user32.dll")]
        static public extern bool GetMenuItemRect(IntPtr hWnd, IntPtr hMenu, uint Item, ref RECT rc);

        /// <summary>
        /// 该函数获得一个指定子窗口的父窗口句柄。
        /// </summary>
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetParent(IntPtr hWnd);

        /// <summary>
        /// 用于得到被定义的系统数据或者系统配置信息.
        /// </summary>
        [DllImport("user32.dll")]
        static public extern int GetSystemMetrics(int nIndex);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="uCmd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);

        /// <summary>
        /// 获取整个窗口（包括边框、滚动条、标题栏、菜单等）的设备场景 返回值 Long。
        /// </summary>
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        /// <summary>
        /// 该函数返回指定窗口的边框矩形的尺寸。该尺寸以相对于屏幕坐标左上角的屏幕坐标给出。
        /// </summary>
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT rect);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpString"></param>
        /// <param name="nMaxCount"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        /// <summary>
        /// 获得指定窗口句柄的进程ID
        /// </summary>
        /// <param name="handle">窗口句柄</param>
        /// <param name="processId">存放进程ID的变量</param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern IntPtr GetWindowThreadProcessId(IntPtr handle, IntPtr processId);

        /// <summary>
        /// 该函数向指定的窗体添加一个矩形，然后窗口客户区域的这一部分将被重新绘制。
        /// </summary>
        [DllImport("user32.dll")]
        public extern static int InvalidateRect(IntPtr hWnd, IntPtr rect, int bErase);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWndParent"></param>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool IsChild(IntPtr hWndParent, IntPtr hWnd);

        /// <summary>
        /// 该函数确定给定的窗口句柄是否识别一个已存在的窗口。
        /// </summary>
        [DllImport("user32.dll")]
        public static extern int IsWindow(IntPtr hWnd);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vk"></param>
        /// <param name="scan"></param>
        /// <param name="flags"></param>
        /// <param name="extraInfo"></param>
        [DllImport("user32.dll", EntryPoint = "keybd_event", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern void KeyEvent(byte vk, byte scan, int flags, int extraInfo);

        /// <summary>
        /// 该函数从一个与应用事例相关的可执行文件（EXE文件）中载入指定的光标资源.
        /// </summary>
        [DllImport("user32.dll")]
        public static extern IntPtr LoadCursor(IntPtr hInstance, uint cursor);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dwFlags">鼠标事件</param>
        /// <param name="dx">坐标x</param>
        /// <param name="dy">坐标y</param>
        /// <param name="dwData">0</param>
        /// <param name="dwExtraInfo">0</param>
        [DllImport("user32.dll", EntryPoint = "mouse_event")]
        public static extern void MouseEvent(MouseEvent dwFlags, uint dx, uint dy, uint dwData, uint dwExtraInfo);

        /// <summary>
        /// 该函数改变指定窗口的位置和尺寸。对于顶层窗口，位置和尺寸是相对于屏幕的左上角的：对于子窗口，位置和尺寸是相对于父窗口客户区的左上角坐标的。
        /// </summary>
        [DllImport("user32.dll")]
        public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int width, int height, bool repaint);

        /// <summary>
        /// 打开剪切板
        /// </summary>
        [DllImport("user32.dll")]
        static public extern bool OpenClipboard(IntPtr hWndNewOwner);

        /// <summary>
        /// 该函数将一个消息放入（寄送）到与指定窗口创建的线程相联系消息队列里
        /// </summary>
        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="threadId"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool PostThreadMessage(uint threadId, int msg, UIntPtr wParam, IntPtr lParam);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd">要注册热键的窗口句柄</param>
        /// <param name="id">热键编号</param>
        /// <param name="fsModifiers">特殊键如：Ctrl，Alt，Shift，Window</param>
        /// <param name="vk">一般键如：A B C F1，F2 等</param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "RegisterHotKey")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        /// <summary>
        /// 该函数从当前线程中的窗口释放鼠标捕获，并恢复通常的鼠标输入处理。捕获鼠标的窗口接收所有的鼠标输入（无论光标的位置在哪里），除非点击鼠标键时，光标热点在另一个线程的窗口中。
        /// </summary>
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        /// <summary>
        /// 函数释放设备上下文环境（DC）供其他应用程序使用。
        /// </summary>
        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool ScreenToClient(IntPtr handle, ref Point point);

        /// <summary>
        /// 该函数滚动指定窗体客户区域的目录。
        /// </summary>
        [DllImport("user32.dll")]
        public static extern int ScrollWindowEx(IntPtr hWnd, int dx, int dy, ref RECT rcScroll, ref RECT rcClip, IntPtr UpdateRegion, ref RECT rcInvalidated, uint flags);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint SendInput(uint nInput, ref INPUT pInput, int cbSize);

        /// <summary>
        /// 该函数将指定的消息发送到一个或多个窗口。此函数为指定的窗口调用窗口程序，直到窗口程序处理完消息再返回。　
        /// </summary>
        /// <param name="hWnd">其窗口程序将接收消息的窗口的句柄</param>
        /// <param name="wMsg">指定被发送的消息</param>
        /// <param name="wParam">指定附加的消息指定信息</param>
        /// <param name="lParam">指定附加的消息指定信息</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern void SendMessage(IntPtr hWnd, WindowMessage wMsg, int wParam, ref RECT lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessageA(IntPtr hwnd, WindowMessage wMsg, int wParam, byte[] lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessageA(IntPtr hwnd, WindowMessage wMsg, IntPtr wParam, string lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessageA(IntPtr hwnd, int wMsg, int wParam, int lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageW")]
        public static extern int SendMessageW(IntPtr hwnd, int wMsg, int wParam, int lParam);

        /// <summary>
        /// 将存放有数据的内存块放入剪切板的资源管理中
        /// </summary>
        [DllImport("user32.dll")]
        public static extern IntPtr SetClipboardData(uint Format, IntPtr hData);

        [DllImport("User32.dll")]
        public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);

        /// <summary>
        /// 该函数确定光标的形状。
        /// </summary>
        [DllImport("user32.dll")]
        public static extern IntPtr SetCursor(IntPtr hCursor);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int x, int y);

        /// <summary>
        /// 该函数对指定的窗口设置键盘焦点。
        /// </summary>
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr SetFocus(IntPtr hwnd);

        /// <summary>
        /// 该函数将创建指定窗口的线程设置到前台，并且激活该窗口。键盘输入转向该窗口，并为用户改各种可视的记号。系统给创建前台窗口的线程分配的权限稍高于其他线程。
        /// </summary>
        [DllImport("user32.dll")]
        static public extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dwErrCode"></param>
        [DllImport("kernel32.dll", EntryPoint = "SetLastError")]
        public static extern void SetLastError(uint dwErrCode);

        /// <summary>
        /// 该函数改变指定子窗口的父窗口。
        /// </summary>
        [DllImport("User32", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr SetParent(IntPtr hChild, IntPtr hParent);

        /// <summary>
        /// 该函数改变指定窗口的属性
        /// </summary>
        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        public static extern bool SetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        /// <summary>
        /// 该函数改变一个子窗口，弹出式窗口式顶层窗口的尺寸，位置和Z序。
        /// </summary>
        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int Width, int Height, uint flags);

        /// <summary>
        /// 
        /// </summary>
        [DllImport("user32.dll")]
        public static extern bool SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool redraw);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hookid"></param>
        /// <param name="pfnhook"></param>
        /// <param name="hinst"></param>
        /// <param name="threadid"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr SetWindowsHookEx(int hookid, HookProc pfnhook, IntPtr hinst, int threadid);

        /// <summary>
        /// 该函数改变指定窗口的标题栏的文本内容
        /// </summary>
        [DllImport("user32.dll")]
        public static extern int SetWindowText(IntPtr hWnd, string text);

        /// <summary>
        /// 该函数显示或隐藏所指定的滚动条。
        /// </summary>
        [DllImport("user32.dll")]
        public static extern int ShowScrollBar(IntPtr hWnd, int bar, int show);

        /// <summary>
        /// 该函数设置指定窗口的显示状态。
        /// </summary>
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, ShowWindow State);

        /// <summary>
        /// 该函数将指定的虚拟键码和键盘状态翻译为相应的字符或字符串。该函数使用由给定的键盘布局句柄标识的物理键盘布局和输入语言来翻译代码。
        /// </summary>
        [DllImport("user32.dll")]
        public static extern int ToAscii(int uVirtKey, int uScanCode, byte[] lpbKeyState, byte[] lpwTransKey, int fuState);

        /// <summary>
        /// 抽掉钩子
        /// </summary>
        /// <param name="idHook"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(IntPtr idHook);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd">注册热键的窗口句柄</param>
        /// <param name="id">热键编号上面注册热键的编号</param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "UnregisterHotKey")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        /// <summary>
        /// 通过发送重绘消息 WM_PAINT 给目标窗体来更新目标窗体客户区的无效区域。
        /// </summary>
        [DllImport("user32.dll")]
        public static extern bool UpdateWindow(IntPtr hWnd);

        /// <summary>
        /// 该函数产生对其他线程的控制，如果一个线程没有其他消息在其消息队列里。
        /// </summary>
        [DllImport("user32.dll")]
        public static extern bool WaitMessage();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(Point point);

        #endregion

        #region 代理
        public delegate bool WNDENUMPROC(IntPtr hwnd, uint lParam);

        public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);
        #endregion
    }
}
