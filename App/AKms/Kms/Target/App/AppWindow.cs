using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Me.Amon.Api.User32;
using Me.Amon.Kms.V;
using Me.Amon.Properties;

namespace Me.Amon.Kms.Target.App
{
    public partial class AppWindow : UserControl
    {
        private IntPtr _findWindow;
        private readonly MagicPtn _MagicPtn;

        public AppWindow()
        {
            InitializeComponent();

            _MagicPtn = new MagicPtn(this);
            _MagicPtn.LoadRes();
            _MagicPtn.InitExitButton(Properties.Resources._del, null, null);
            _MagicPtn.ExitButtonToolTip = "取消";
            _MagicPtn.ExitButtonHandler = PbExit_Click;
            _MagicPtn.InitHideButton(Properties.Resources._add, null, null);
            _MagicPtn.HideButtonToolTip = "选择";
            _MagicPtn.HideButtonHandler = PbHide_Click;
            _MagicPtn.InitMenuButton(Properties.Resources._win, null, null);
            _MagicPtn.MenuButtonToolTip = "窗体列表";
            _MagicPtn.MenuButtonVisible = true;
            _MagicPtn.MenuButtonHandler = PbMenu_Click;

            Rectangle rect = Screen.PrimaryScreen.WorkingArea;
            _MagicPtn.Location = new Point(rect.Width - _MagicPtn.Width, rect.Height - _MagicPtn.Height);
            _MagicPtn.Text = "查找组件";
        }

        public IntPtr UserWindow
        {
            get
            {
                return _findWindow;
            }
            set
            {
                _findWindow = value;
                DisplayInfo(_findWindow);
            }
        }

        #region 鼠标事件处理
        private IntPtr _lastWindow = IntPtr.Zero;
        private void PbApp_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Cursor = new Cursor(Resources._cur.GetHicon());
                PbApp.Image = Properties.Resources._run;
            }
        }

        private void PbApp_MouseMove(object sender, MouseEventArgs e)
        {
            if (Cursor != Cursors.Default)
            {
                IntPtr FoundWindow = User32.ChildWindowFromPoint(Cursor.Position);

                // not this application
                Control control = FromHandle(FoundWindow);
                if (control == null)
                {
                    if (FoundWindow != _lastWindow)
                    {
                        // clear old window
                        User32.ShowInvertRectTracker(_lastWindow);
                        // set new window
                        _lastWindow = FoundWindow;
                        // paint new window
                        User32.ShowInvertRectTracker(_lastWindow);
                    }
                    DisplayInfo(_lastWindow);
                }
                // show global mouse cursor
                //Point p = Cursor.Position;
                //LbPos.Text = "位置：[" + p.X + "," + p.Y + "]";
            }
        }

        private void PbApp_MouseUp(object sender, MouseEventArgs e)
        {
            if (Cursor != Cursors.Default)
            {
                // reset all done things from mouse_down and mouse_move ...
                User32.ShowInvertRectTracker(_lastWindow);
                _findWindow = _lastWindow;
                _lastWindow = IntPtr.Zero;

                Cursor = Cursors.Default;
                PbApp.Image = Properties.Resources._def;
            }
        }

        /// <summary>
        /// Show informations about the given window
        /// </summary>
        /// <param name="window"></param>
        private void DisplayInfo(IntPtr window)
        {
            if (window == IntPtr.Zero)
            {
                // reset all edit box
                LbCmpLoc.Text = "";
            }
            else
            {
                // Handler
                _MagicPtn.Text = "组件句柄：" + window;

                // Point
                Point point = Cursor.Position;
                User32API.ScreenToClient(window, ref point);
                TbCmpLoc.Text = point.ToString();

                // Rect
                Rectangle windowRect = User32.GetWindowRect(window);
                TbCmpDim.Text = windowRect.ToString();

                // Caption
                TbCmpTitle.Text = User32.GetWindowText(window);

                // Class
                var className = new StringBuilder(256);
                User32API.GetClassName(window, className, className.Capacity);
                TbCmpClass.Text = className.ToString();
            }
        }
        #endregion

        #region 窗口事件
        public void Start()
        {
            _MagicPtn.ShowDialog();
        }

        private void PbExit_Click(object sender, EventArgs e)
        {
            _MagicPtn.Close();
            _MagicPtn.DialogResult = DialogResult.Cancel;
        }

        private void PbHide_Click(object sender, EventArgs e)
        {
            if (_findWindow == IntPtr.Zero)
            {
                MessageBox.Show(_MagicPtn, "请选择您的目标窗体。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _MagicPtn.Close();
            _MagicPtn.DialogResult = DialogResult.OK;
        }

        private void PbMenu_Click(object sender, EventArgs e)
        {
            if (_findWindow == IntPtr.Zero)
            {
                MessageBox.Show(_MagicPtn, "请选择您的目标窗体。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var win = new SubWindow(this);
            win.Show(this);
            win.UserControl = _findWindow;
        }
        #endregion
    }
}
