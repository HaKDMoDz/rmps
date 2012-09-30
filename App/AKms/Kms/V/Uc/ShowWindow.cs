using System;
using System.Text;
using System.Windows.Forms;
using Me.Amon.Api.User32;
using Me.Amon.Kms.Enums;
using Me.Amon.Kms.M;
using Me.Amon.Properties;

namespace Me.Amon.Kms.V.Uc
{
    public partial class ShowWindow : UserControl, IFunction
    {
        private MFunction _function;

        public ShowWindow()
        {
            InitializeComponent();
        }

        #region 鼠标拖动查找组件
        private IntPtr _lastWindow = IntPtr.Zero;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PbWin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Cursor = new Cursor(Resources._cur.GetHicon());
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PbWin_MouseMove(object sender, MouseEventArgs e)
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
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PbWin_MouseUp(object sender, MouseEventArgs e)
        {
            if (Cursor != Cursors.Default)
            {
                // reset all done things from mouse_down and mouse_move ...
                User32.ShowInvertRectTracker(_lastWindow);
                _lastWindow = IntPtr.Zero;

                Cursor = Cursors.Default;
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
                TbWin.Text = "";
            }
            else
            {
                var ClassName = new StringBuilder(256);
                User32API.GetClassName(window, ClassName, ClassName.Capacity);

                var WindowText = new StringBuilder(User32API.GetWindowTextLength(window) + 1);
                User32API.GetWindowText(window, WindowText, WindowText.Capacity);

                TbWin.Text = ClassName + ":" + WindowText;
            }
        }
        #endregion

        #region IFunction 成员

        public MFunction UserFunction
        {
            get
            {
                return _function;
            }
            set
            {
                _function = value;
                TbWin.Text = _function.Param ?? "";
            }
        }

        public bool SaveFunction()
        {
            _function.Action = EAction.ShowWindow;
            _function.Param = TbWin.Text;
            return true;
        }

        public UserControl UserControl
        {
            get
            {
                return this;
            }
        }

        #endregion
    }
}
