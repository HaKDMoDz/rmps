using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Me.Amon.Properties;
using Me.Amon.Api.User32;
using Me.Amon.Kms.Enums;
using Me.Amon.Kms.M;
using Me.Amon.Util;

namespace Me.Amon.Kms.V.Uc
{
    public partial class GetControl : UserControl, IFunction
    {
        private MFunction _function;

        public GetControl()
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
        private void PbCtl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || MiOnTimeFind.Checked)
            {
                return;
            }
            Cursor = new Cursor(Resources._cur.GetHicon());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PbCtl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || MiOnTimeFind.Checked)
            {
                return;
            }

            if (Cursor == Cursors.Default) return;
            var foundWindow = User32.ChildWindowFromPoint(Cursor.Position);

            // not this application
            var control = FromHandle(foundWindow);
            if (control != null) return;

            if (foundWindow != _lastWindow)
            {
                // clear old window
                User32.ShowInvertRectTracker(_lastWindow);
                // set new window
                _lastWindow = foundWindow;
                // paint new window
                User32.ShowInvertRectTracker(_lastWindow);
            }
            DisplayInfo(_lastWindow);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PbCtl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                CmMenu.Show(PbCtl, 0, PbCtl.Height);
                return;
            }

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
                // reset all edit box
                TbCtl.Text = "";
            }
            else
            {
                var className = new StringBuilder(256);
                User32API.GetClassName(window, className, className.Capacity);
                TbCtl.Text = "1," + className;
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
                string text = (_function.Param ?? "").Trim();
                MiFocusedCmp.Checked = ("0,@" == text);
                MiOnTimeFind.Checked = ("0,$" == text);
                TbCtl.Text = text;
                TbCtl.ReadOnly = MiFocusedCmp.Checked || MiOnTimeFind.Checked;
            }
        }

        public bool SaveFunction()
        {
            if (_function == null)
            {
                return false;
            }

            // 焦点组件
            if (MiFocusedCmp.Checked)
            {
                _function.Action = EAction.GetControl;
                _function.Param = "0,@";
                return true;
            }

            // 即时查找
            if (MiOnTimeFind.Checked)
            {
                _function.Action = EAction.GetControl;
                _function.Param = "0,$";
                return true;
            }

            if (!CharUtil.IsValidate(TbCtl.Text))
            {
                return false;
            }

            _function.Action = EAction.GetControl;
            _function.Param = TbCtl.Text.Trim();
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

        #region 菜单事件
        private void MiOnTimeFind_Click(object sender, EventArgs e)
        {
            bool b = !MiOnTimeFind.Checked;
            TbCtl.ReadOnly = b;
            MiOnTimeFind.Checked = b;
            if (MiFocusedCmp.Checked)
            {
                MiFocusedCmp.Checked = false;
            }
        }

        private void MiFocusedCmp_Click(object sender, EventArgs e)
        {
            bool b = !MiFocusedCmp.Checked;
            TbCtl.ReadOnly = b;
            MiFocusedCmp.Checked = b;
            if (MiOnTimeFind.Checked)
            {
                MiOnTimeFind.Checked = false;
            }
        }
        #endregion
    }
}
