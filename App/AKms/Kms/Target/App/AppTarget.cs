using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Me.Amon.Api.Enums;
using Me.Amon.Api.Input;
using Me.Amon.Api.User32;
using Me.Amon.Kms.Enums;
using Me.Amon.Kms.M;

namespace Me.Amon.Kms.Target.App
{
    class AppTarget : ITarget
    {
        private MSession _session;

        /// <summary>
        /// The <see cref="IKeyboardSimulator"/> instance to use for simulating keyboard input.
        /// </summary>
        private readonly IKeyboardSimulator _KeyboardSimulator;

        /// <summary>
        /// The <see cref="IMouseSimulator"/> instance to use for simulating mouse input.
        /// </summary>
        private readonly IMouseSimulator _MouseSimulator;

        /// <summary>
        /// The <see cref="IInputDeviceStateAdaptor"/> instance to use for interpreting the state of the input devices.
        /// </summary>
        private readonly IInputDeviceStateAdaptor _InputDeviceState;

        #region 公共属性

        /// <summary>
        /// 信息来源窗体
        /// </summary>
        public IntPtr SrcWindow { get; set; }

        /// <summary>
        /// 信息来源组件
        /// </summary>
        public IntPtr SrcControl { get; set; }

        /// <summary>
        /// 信息输出窗体
        /// </summary>
        public IntPtr DstWindow { get; set; }

        /// <summary>
        /// 信息输出组件
        /// </summary>
        public IntPtr DstControl { get; set; }

        #endregion

        public AppTarget()
        {
            _KeyboardSimulator = new KeyboardSimulator();
            _MouseSimulator = new MouseSimulator();
            _InputDeviceState = new WindowsInputDeviceStateAdaptor();
        }

        #region ITarget 成员

        public ETarget Target
        {
            get
            {
                return ETarget.App;
            }
        }

        public string TargetName
        {
            get
            {
                return "程序";
            }
        }

        public bool HintByStep
        {
            get;
            set;
        }

        public AKms TrayWin
        {
            get;
            set;
        }

        public bool Start()
        {
            if (_session == null)
            {
                _session = new MSession();
            }

            SrcWindow = IntPtr.Zero;
            SrcControl = IntPtr.Zero;
            DstWindow = IntPtr.Zero;
            DstControl = IntPtr.Zero;

            return Deal(TrayWin.Solution.PreFunction);
        }

        public void SendMessage(string text)
        {
            if (DstControl == IntPtr.Zero)
            {
                return;
            }
            if (DstWindow == IntPtr.Zero)
            {
                IntPtr handle = DstControl;
                do
                {
                    DstWindow = handle;
                    handle = User32API.GetParent(DstWindow);
                }
                while (handle != IntPtr.Zero);
            }
            User32.SwitchWindow(DstWindow);
            Thread.Sleep(100);

            // 准备输入
            MSolution sln = TrayWin.Solution;
            if (!string.IsNullOrEmpty(sln.PostPrepare))
            {
                if (Regex.IsMatch(sln.PostPrepare, "^[@&]\\[\\d+,\\d+\\]\\(\\w+,\\d+\\)$"))
                {
                    MouseAction(sln.PostPrepare);
                }
                else
                {
                    KeybdAction(sln.PostPrepare.Split(' '), 0);
                }
            }

            text = MSentence.Decode(text);
            switch (sln.Output)
            {
                // 剪贴板
                case EOutput.ClipBoard:
                    User32.PastMessage(DstControl, text);
                    break;
                // 消息发送
                case EOutput.SendMessage:
                    _KeyboardSimulator.TextEntry(text);
                    break;
                // 模拟输入
                case EOutput.SimulateInput:
                    foreach (char item in text)
                    {
                        _KeyboardSimulator.TextEntry(item);
                        Thread.Sleep(100);
                    }
                    break;
                default:
                    return;
            }

            // 输入确认
            if (!string.IsNullOrEmpty(sln.PostConfirm))
            {
                if (Regex.IsMatch(sln.PostConfirm, "^[@&]\\[\\d+,\\d+\\]\\(\\w+,\\d+\\)$"))
                {
                    MouseAction(sln.PostConfirm);
                }
                else
                {
                    KeybdAction(sln.PostConfirm.Split(' '), 0);
                }
            }
        }

        public void SendMessage(Image image)
        {
            if (DstControl == IntPtr.Zero)
            {
                return;
            }
            if (DstWindow == IntPtr.Zero)
            {
                IntPtr handle = DstControl;
                do
                {
                    DstWindow = handle;
                    handle = User32API.GetParent(DstWindow);
                }
                while (handle != IntPtr.Zero);
            }
            User32.SwitchWindow(DstWindow);
            Thread.Sleep(100);

            // 准备输入
            MSolution sln = TrayWin.Solution;
            if (!string.IsNullOrEmpty(sln.PostPrepare))
            {
                if (Regex.IsMatch(sln.PostPrepare, "^[@&]\\[\\d+,\\d+\\]\\(\\w+,\\d+\\)$"))
                {
                    MouseAction(sln.PostPrepare);
                }
                else
                {
                    KeybdAction(sln.PostPrepare.Split(' '), 0);
                }
            }

            User32.PastMessage(DstControl, image);

            // 输入确认
            if (!string.IsNullOrEmpty(sln.PostConfirm))
            {
                if (Regex.IsMatch(sln.PostConfirm, "^[@&]\\[\\d+,\\d+\\]\\(\\w+,\\d+\\)$"))
                {
                    MouseAction(sln.PostConfirm);
                }
                else
                {
                    KeybdAction(sln.PostConfirm.Split(' '), 0);
                }
            }
        }

        public void ShowWarning(string text)
        {
            MessageBox.Show(null, MSentence.Decode(text), "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public DialogResult ShowConfirm(string text)
        {
            return MessageBox.Show(null, MSentence.Decode(text), "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public bool Close()
        {
            bool b = Deal(TrayWin.Solution.SufFunction);
            TrayWin.SessionClose();
            return b;
        }

        #endregion

        #region 特殊操作
        private bool ExecuteApp(string param)
        {
            if (string.IsNullOrEmpty(param))
            {
                if (HintByStep)
                {
                    ShowWarning("您输入了空程序路径！", "执行程序");
                }
                return false;
            }

            try
            {
                Process.Start(param);
                return true;
            }
            catch (Exception exp)
            {
                ShowWarning(exp.Message, "执行程序");
                return false;
            }
        }

        private bool GetControl(string param)
        {
            if (string.IsNullOrEmpty(param))
            {
                if (HintByStep)
                {
                    ShowWarning("您输入了空组件名称！", "查找组件");
                }
                return false;
            }

            if (!Regex.IsMatch(param, "^\\d+,[$@.\\s\\w]+$"))
            {
                if (HintByStep)
                {
                    ShowWarning("您输入的组件名称格式有误：" + param, "查找组件");
                }
                return false;
            }

            IntPtr intPtr = IntPtr.Zero;

            // 获取焦点组件
            if ("0,@" == param)
            {
                Thread.Sleep(100);
                //获取当前活动窗口的线程句柄
                IntPtr curThread = User32API.GetCurrentThreadId();
                //获得指定句柄的线程句柄
                IntPtr winThread = User32API.GetWindowThreadProcessId(DstWindow, IntPtr.Zero);
                User32API.AttachThreadInput(winThread, curThread, true);
                //得到当前的具有输入焦点的子窗口(控件)的句柄
                intPtr = User32API.GetFocus();
                //将连到一起的两个线程的输入队列分离
                User32API.AttachThreadInput(winThread, curThread, false);
                if (intPtr == IntPtr.Zero)
                {
                    ShowWarning("无法获取活动窗口的焦点组件！", "查找组件");
                    return false;
                }
                DstControl = intPtr;
                return true;
            }

            // 即时查找组件
            if ("0,$" == param)
            {
                intPtr = FindControl();
                if (intPtr == IntPtr.Zero)
                {
                    ShowWarning("您没有选择一个有效的组件，系统无法继续！", "查找组件");
                    return false;
                }
                DstControl = intPtr;
                return true;
            }

            string[] arr = param.Split(',');
            if (arr.Length != 2)
            {
                if (HintByStep)
                {
                    ShowWarning("您输入的组件名称格式有误！", "查找组件");
                }
                return false;
            }

            int idx = int.Parse(arr[0]);

            IntPtr tmpWnd = DstControl != IntPtr.Zero ? DstControl : DstWindow;
            int tmp = 0;
            while (tmp++ < idx)
            {
                intPtr = User32API.FindWindowEx(tmpWnd, intPtr, arr[1], null);
            }
            if (intPtr == IntPtr.Zero)
            {
                ShowWarning("无法定位组件：" + param + "，系统无法继续！", "查找组件");
                return true;
            }
            DstControl = intPtr;
            return true;
        }

        private bool ShowWindow(string param)
        {
            if (string.IsNullOrEmpty(param))
            {
                if (HintByStep)
                {
                    ShowWarning("您输入了空窗口标题！", "激活窗口");
                }
                return false;
            }

            string[] arr = param.Split(':');
            if (arr.Length != 2)
            {
                if (HintByStep)
                {
                    ShowWarning("您输入的窗口标题格式有误：" + param, "激活窗口");
                }
                return false;
            }

            try
            {
                DstWindow = User32API.FindWindow(string.IsNullOrEmpty(arr[0]) ? null : arr[0], string.IsNullOrEmpty(arr[1]) ? null : arr[1]);
                if (DstWindow != IntPtr.Zero)
                {
                    User32.SwitchWindow(DstWindow);
                    return true;
                }
            }
            catch (Exception exp)
            {
                ShowWarning(exp.Message, "激活窗口");
            }
            return false;
        }

        private bool HideWindow(string param)
        {
            if (string.IsNullOrEmpty(param))
            {
                if (HintByStep)
                {
                    ShowWarning("您输入了空窗口标题！", "隐藏窗口");
                }
                return false;
            }

            string[] arr = param.Split(':');
            if (arr.Length != 2)
            {
                if (HintByStep)
                {
                    ShowWarning("您输入的窗口标题格式有误：" + param, "隐藏窗口");
                }
                return false;
            }

            try
            {
                IntPtr intPtr = User32API.FindWindow(string.IsNullOrEmpty(arr[0]) ? null : arr[0], string.IsNullOrEmpty(arr[1]) ? null : arr[1]);
                if (intPtr != IntPtr.Zero)
                {
                    User32API.ShowWindow(intPtr, Api.Enums.ShowWindow.SW_SHOWMINIMIZED);
                }
                return true;
            }
            catch (Exception exp)
            {
                ShowWarning(exp.Message, "隐藏窗口");
                return false;
            }
        }

        private bool KeybdInput(string param)
        {
            if (string.IsNullOrEmpty(param))
            {
                if (HintByStep)
                {
                    ShowWarning("您输入了空键盘事件！", "键盘输入");
                }
                return false;
            }

            string[] arr = param.Split(' ');
            if (arr.Length != 2)
            {
                if (HintByStep)
                {
                    ShowWarning("您输入的键盘事件格式有误：" + param, "键盘输入");
                }
                return false;
            }

            return KeybdInput(arr[0], arr[1]);
        }

        private bool KeybdInput(string key, string action)
        {
            VirtualKeyCode vk;
            try
            {
                vk = (VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), key.ToUpper(), true);
            }
            catch (Exception exp)
            {
                if (HintByStep)
                {
                    ShowWarning(exp.Message, "键盘输入");
                }
                return false;
            }

            if (vk == VirtualKeyCode.NONE)
            {
                return false;
            }

            switch (action.ToLower())
            {
                case "press":
                    _KeyboardSimulator.KeyPress(vk);
                    return true;
                case "down":
                    _KeyboardSimulator.KeyDown(vk);
                    return true;
                case "up":
                    _KeyboardSimulator.KeyUp(vk);
                    return true;
                default:
                    if (HintByStep)
                    {
                        ShowWarning("未知的键盘操作：" + action, "键盘输入");
                    }
                    return false;
            }
        }

        private bool MouseInput(string param)
        {
            if (string.IsNullOrEmpty(param))
            {
                if (HintByStep)
                {
                    ShowWarning("您输入了空鼠标事件！", "鼠标输入");
                }
                return false;
            }

            if (!Regex.IsMatch(param, "^[&@]\\[[0-9]+,[0-9]+\\]\\([A-Za-z]+,[A-Za-z]+\\)$"))
            {
                if (HintByStep)
                {
                    ShowWarning("您输入的鼠标事件格式有误：" + param, "鼠标输入");
                }
                return false;
            }
            string[] arr = Regex.Split(param, "[^&@0-9A-Za-z]+");
            if (arr.Length != 6)
            {
                if (HintByStep)
                {
                    ShowWarning("您输入的鼠标事件格式有误：" + param, "鼠标输入");
                }
                return false;
            }

            var point = new Point { X = int.Parse(arr[1]), Y = int.Parse(arr[2]) };
            if (arr[0] == "@")
            {
                User32API.ClientToScreen(DstControl, ref point);
            }

            bool click = ("click" == arr[4].ToLower());

            //var input = new INPUT();
            //input.Type = InputType.INPUT_MOUSE;
            //uint flag = MouseInput(arr[3], click ? "down" : arr[4]);
            //if (flag == 0)
            //{
            //    return false;
            //}
            //input.ki.dwFlags = flag;

            //User32API.SetCursorPos(point.X, point.Y);
            //User32API.SendInput(1, ref input, Marshal.SizeOf(input));

            //if (click)
            //{
            //    input = new INPUT();
            //    input.Type = InputType.INPUT_MOUSE;
            //    flag = MouseInput(arr[3], "up");
            //    if (flag == 0)
            //    {
            //        return false;
            //    }
            //    input.ki.dwFlags = flag;

            //    User32API.SendInput(1, ref input, Marshal.SizeOf(input));
            //}
            return true;
        }

        private uint MouseInput(string button, string action)
        {
            switch (action.ToLower())
            {
                case "down":
                    switch (button.ToLower())
                    {
                        case "left":
                            return (uint)MouseEvent.LeftDown;
                        case "right":
                            return (uint)MouseEvent.RightDown;
                        case "middle":
                            return (uint)MouseEvent.MiddleDown;
                        case "xbutton":
                            return (uint)MouseEvent.XDown;
                        default:
                            if (HintByStep)
                            {
                                ShowWarning("未知的鼠标按键：" + button, "鼠标输入");
                            }
                            return 0;
                    }

                case "up":
                    switch (button.ToLower())
                    {
                        case "left":
                            return (uint)MouseEvent.LeftUp;
                        case "right":
                            return (uint)MouseEvent.RightUp;
                        case "middle":
                            return (uint)MouseEvent.MiddleUp;
                        case "xbutton":
                            return (uint)MouseEvent.XUp;
                        default:
                            if (HintByStep)
                            {
                                ShowWarning("未知的鼠标按键：" + button, "鼠标输入");
                            }
                            return 0;
                    }

                case "move":
                    return (uint)MouseEvent.Move;

                case "wheel":
                    return (uint)MouseEvent.VerticalWheel;

                default:
                    if (HintByStep)
                    {
                        ShowWarning("未知的鼠标事件：" + button, "鼠标输入");
                    }
                    return 0;
            }
        }
        #endregion

        #region 消息发送
        /// <summary>
        /// 键盘输入
        /// </summary>
        /// <param name="key"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        protected bool KeybdAction(string[] key, int idx)
        {
            if (key == null || idx < 0 || idx >= key.Length)
            {
                return false;
            }

            VirtualKeyCode vk;
            try
            {
                vk = (VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), key[idx].ToUpper(), true);
            }
            catch (Exception exp)
            {
                if (HintByStep)
                {
                    ShowWarning(exp.Message, "提示");
                }
                return false;
            }

            if (vk == VirtualKeyCode.NONE)
            {
                return false;
            }

            _KeyboardSimulator.KeyDown(vk);
            KeybdAction(key, ++idx);
            _KeyboardSimulator.KeyUp(vk);
            return true;
        }

        /// <summary>
        /// 鼠标点击
        /// </summary>
        /// <param name="mouse"></param>
        /// <returns></returns>
        protected bool MouseAction(string mouse)
        {
            if (string.IsNullOrEmpty(mouse))
            {
                if (HintByStep)
                {
                    ShowWarning("您输入了空鼠标事件！", "提示");
                }
                return false;
            }

            if (!Regex.IsMatch(mouse, "^[&@]\\[[0-9]+,[0-9]+\\]\\([A-Za-z]+,\\d+\\)$"))
            {
                if (HintByStep)
                {
                    ShowWarning("您输入的鼠标事件格式有误：" + mouse, "提示");
                }
                return false;
            }
            string[] arr = Regex.Split(mouse, "[^&@0-9A-Za-z]+");
            if (arr.Length != 6)
            {
                if (HintByStep)
                {
                    ShowWarning("您输入的鼠标事件格式有误：" + mouse, "提示");
                }
                return false;
            }

            var point = new Point { X = int.Parse(arr[1]), Y = int.Parse(arr[2]) };
            if (arr[0] == "@")
            {
                User32API.ClientToScreen(DstControl, ref point);
            }

            int j = int.Parse(arr[4]);
            for (var i = 0; i < j; i += 1)
            {
                ClickAt(point.X, point.Y, MouseButton.Left);
            }
            return true;
        }
        #endregion

        #region 私有函数
        private bool Deal(IEnumerable<MFunction> functions)
        {
            if (functions == null)
            {
                return false;
            }

            foreach (MFunction function in functions)
            {
                if (function == null)
                {
                    continue;
                }

                switch (function.Action)
                {
                    case EAction.ThreadWait:
                        ThreadWait(function.Param);
                        break;
                    case EAction.ExecuteApp:
                        if (!ExecuteApp(function.Param))
                        {
                            return false;
                        }
                        break;
                    case EAction.ShowWindow:
                        if (!ShowWindow(function.Param))
                        {
                            return false;
                        }
                        break;
                    case EAction.HideWindow:
                        if (!HideWindow(function.Param))
                        {
                            return false;
                        }
                        break;
                    case EAction.GetControl:
                        if (!GetControl(function.Param))
                        {
                            return false;
                        }
                        break;
                    case EAction.KeybdInput:
                        if (!KeybdInput(function.Param))
                        {
                            return false;
                        }
                        break;
                    case EAction.MouseInput:
                        if (!MouseInput(function.Param))
                        {
                            return false;
                        }
                        break;
                    default:
                        return false;
                }
            }

            return true;
        }

        public IntPtr FindControl()
        {
            var fc = new AppWindow();
            Rectangle rect = Screen.PrimaryScreen.WorkingArea;
            fc.Location = new Point(rect.Width - fc.Width - 10, rect.Height - fc.Height - 10);
            fc.Start();
            return fc.UserWindow;
        }

        private void ClickAt(int x, int y, MouseButton button)
        {
            _MouseSimulator.MoveMouseTo(x, y);
            switch (button)
            {
                case MouseButton.Left:
                    _MouseSimulator.LeftButtonClick();
                    break;
                case MouseButton.Right:
                    _MouseSimulator.RightButtonClick();
                    break;
            }
        }
        #endregion

        private static void ShowWarning(string text, string tips)
        {
            MessageBox.Show(null, text, tips, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// 执行等待
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public bool ThreadWait(string param)
        {
            if (string.IsNullOrEmpty(param))
            {
                if (HintByStep)
                {
                    ShowWarning("您输入了空等待时间！");
                }
                return false;
            }

            int time = 0;
            if (Regex.IsMatch(param, "^\\{\\d+,\\d+\\}$"))
            {
                string[] arr = param.Substring(1, param.Length - 2).Split(',');
                int min = int.Parse(arr[0]);
                int max = int.Parse(arr[1]);
                time = new Random().Next(max - min) + min;
            }
            else if (Regex.IsMatch(param, "^\\d+$"))
            {
                time = int.Parse(param);
            }

            if (time > 0)
            {
                Thread.Sleep(time);
            }
            return true;
        }
    }
}
