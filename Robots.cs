using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using com.magickms.api.User32;
using com.magickms.api.Enum;
using System.Text.RegularExpressions;
using com.magickms.api.Enums;

namespace com.magickms
{
    public class Robots
    {
        private MSolution _solution;
        private IntPtr _srcWnd;
        private IntPtr _srcCmp;
        private IntPtr _dstWnd;
        private IntPtr _dstCmp;
        private Random _random;

        public void Deal(MSolution solution)
        {
            _solution = solution;
            if (solution == null)
            {
                return;
            }

            #region 属性合法性检查
            // 与应用程序交互时，检查输出及输入源是否存在
            if (_solution.Target == ETarget.App)
            {
                if (_dstWnd == IntPtr.Zero || (_solution.Answer == EAnswer.Active && _srcWnd == IntPtr.Zero))
                {
                    return;
                }
            }
            // 不指定标签时，使用所有标签
            if (_solution.TagIds == null)
            {
                _solution.TagIds = new List<string> { "0" };
            }
            #endregion

            if (_random == null)
            {
                _random = new Random();
            }

            Deal(_solution.PreFunction);
            User32.PastMessage(_dstCmp, _solution.TxtList[_random.Next(_solution.TxtList.Count)]);
            Deal(_solution.SufFunction);
        }

        /// <summary>
        /// 信息输入组件
        /// </summary>
        public IntPtr SrcWnd
        {
            get
            {
                return _srcWnd;
            }
            set
            {
                _srcWnd = value;
            }
        }

        /// <summary>
        /// 信息输出组件
        /// </summary>
        public IntPtr DstWnd
        {
            get
            {
                return _dstWnd;
            }
            set
            {
                _dstWnd = value;
            }
        }

        private void Deal(List<MFunction> functions)
        {
            if (functions == null)
            {
                return;
            }

            foreach (MFunction function in functions)
            {
                if (function == null)
                {
                    continue;
                }

                switch (function.Action)
                {
                    case EAction.ExecuteApp:
                        ExecuteApp(function.Param);
                        break;
                    case EAction.ShowWindow:
                        if (ShowWindow(function.Param))
                        {
                            break;
                        }
                        return;
                    case EAction.HideWindow:
                        HideWindow(function.Param);
                        break;
                    case EAction.GetControl:
                        GetControl(function.Param);
                        break;
                    case EAction.KeybdInput:
                        KeybdInput(function.Param);
                        break;
                    case EAction.MouseInput:
                        MouseInput(function.Param);
                        break;
                    default:
                        break;
                }
            }
        }

        private void ExecuteApp(string app)
        {
            try
            {
                Process.Start(app);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private bool ShowWindow(string title)
        {
            try
            {
                _dstWnd = User32.FindWindow(null, title);
                if (_dstWnd != IntPtr.Zero)
                {
                    User32.SwitchWindow(_dstWnd);
                    return true;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            return false;
        }

        private void HideWindow(string title)
        {
            try
            {
                IntPtr intPtr = User32.FindWindow(null, title);
                if (intPtr != IntPtr.Zero)
                {
                    User32.ShowWindow(intPtr, api.Enum.ShowWindow.SW_SHOWMINIMIZED);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void KeybdInput(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return;
            }

            string[] arr = Regex.Split(key, "[^\\w]+");
            if (arr == null || arr.Length < 1)
            {
                return;
            }

            KeybdInput(arr, 0);
        }

        private void GetControl(string param)
        {
            if (string.IsNullOrEmpty(param))
            {
                return;
            }

            if (!Regex.IsMatch(param, "^\\d+,[.$\\w]+$"))
            {
                return;
            }
            string[] arr = param.Split(',');
            if (arr == null || arr.Length != 2)
            {
                return;
            }

            int idx = int.Parse(arr[0]);

            IntPtr intPtr = IntPtr.Zero;
            int tmp = 0;
            while (tmp++ < idx)
            {
                intPtr = User32.FindWindowEx(_dstWnd, intPtr, arr[1], "");
            }
            if (intPtr != IntPtr.Zero)
            {
                _dstCmp = intPtr;
            }
        }

        private void KeybdInput(string[] key, int idx)
        {
            if (key == null || idx < 0 || idx >= key.Length)
            {
                return;
            }

            string tmp = key[idx].ToUpper().Replace("CTRL", "CONTROL");
            VirtualKey vk = (VirtualKey)Enum.Parse(typeof(VirtualKey), "VK_" + tmp, true);
            if (vk != VirtualKey.VK_NONE)
            {
                ushort uk = (ushort)((byte)vk & 0xFF);
                User32.KeyDown(uk);
                KeybdInput(key, ++idx);
                User32.KeyUp(uk);
            }
        }

        private void MouseInput(string point)
        {
            if (string.IsNullOrEmpty(point))
            {
                return;
            }

            if (!Regex.IsMatch(point, "^\\[\\d+,\\d+\\]\\(\\d+,\\d+\\)$"))
            {
                return;
            }
            string[] arr = Regex.Split(point, "[^\\d]+");
            if (arr == null || arr.Length != 4)
            {
                return;
            }

            int x = int.Parse(arr[0]);
            int y = int.Parse(arr[1]);
            int cnt = int.Parse(arr[2]);
            MouseButton mb = (MouseButton)Enum.Parse(typeof(MouseButton), arr[3], true);
            for (int i = 0; i < cnt; i += 1)
            {
                User32.MouseClick(x, y, mb);
            }
        }
    }
}
