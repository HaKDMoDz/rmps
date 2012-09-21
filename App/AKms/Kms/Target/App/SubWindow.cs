using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Me.Amon.Api.User32;

namespace Me.Amon.Kms.Target.App
{
    public partial class SubWindow : Form
    {
        private IntPtr _userControl;
        private IntPtr _lastControl;
        private readonly AppWindow _AppWindow;

        public SubWindow()
        {
            InitializeComponent();
        }

        public SubWindow(AppWindow findCmp)
        {
            InitializeComponent();

            _AppWindow = findCmp;
        }

        public IntPtr UserControl
        {
            get
            {
                return _userControl;
            }
            set
            {
                _userControl = value;
                var root = new TreeNode { Name = _userControl.ToString(), Text = DisplayRoot(_userControl) };
                root.Nodes.Add(new TreeNode { Name = "none" });
                TvWndList.Nodes.Add(root);
            }
        }

        private static void TvWndList_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode node = e.Node;
            if (node.Nodes[0].Name != "none")
            {
                return;
            }
            node.Nodes.Clear();

            string name = node.Name;
            if (!Regex.IsMatch(name, "^\\d+$"))
            {
                return;
            }

            var intPtr = (IntPtr)int.Parse(name);
            if (intPtr == IntPtr.Zero)
            {
                return;
            }

            IntPtr subPtr = IntPtr.Zero;
            var classList = new Dictionary<string, int>();
            while (true)
            {
                subPtr = User32API.FindWindowEx(intPtr, subPtr, null, null);
                if (subPtr == IntPtr.Zero)
                {
                    break;
                }
                var temp = new TreeNode { Name = subPtr.ToString(), Text = DisplayNote(subPtr, classList) };
                temp.Nodes.Add(new TreeNode { Name = "none" });
                node.Nodes.Add(temp);
            }
        }

        private void TvWndList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            if (node == null)
            {
                return;
            }

            string name = node.Name;
            if (!Regex.IsMatch(name, "^\\d+$"))
            {
                return;
            }

            if (_lastControl != IntPtr.Zero)
            {
                User32.ShowInvertRectTracker(_lastControl);
            }
            _lastControl = (IntPtr)int.Parse(name);
            User32.ShowInvertRectTracker(_lastControl);
        }

        private static string DisplayRoot(IntPtr window)
        {
            var buf = new StringBuilder(256);
            User32API.GetClassName(window, buf, buf.Capacity);

            return "句柄：" + window + " 类型：" + buf + " 标题：" + User32.GetWindowText(window);
        }

        private static string DisplayNote(IntPtr window, Dictionary<string, int> classList)
        {
            var buf = new StringBuilder(256);
            User32API.GetClassName(window, buf, buf.Capacity);
            string className = buf.ToString();

            if (classList.ContainsKey(className))
            {
                classList[className] += 1;
            }
            else
            {
                classList[className] = 1;
            }

            return "句柄：" + window + " 索引：" + classList[className] + " 类型：" + buf + " 标题：" + User32.GetWindowText(window);
        }

        private void WndList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_lastControl != IntPtr.Zero)
            {
                User32.ShowInvertRectTracker(_lastControl);
            }
        }

        private void BtChoose_Click(object sender, EventArgs e)
        {
            TreeNode node = TvWndList.SelectedNode;
            if (node == null)
            {
                return;
            }

            string name = node.Name;
            if (!Regex.IsMatch(name, "^\\d+$"))
            {
                return;
            }

            var intPtr = (IntPtr)int.Parse(name);
            if (intPtr == IntPtr.Zero)
            {
                return;
            }

            if (_AppWindow != null)
            {
                _AppWindow.UserWindow = intPtr;
            }
            Close();
        }
    }
}
