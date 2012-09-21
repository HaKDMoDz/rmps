using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Me.Amon.Api.User32;
using Me.Amon.Kms.Enums;
using Me.Amon.Kms.M;

namespace Me.Amon._uc
{
    public partial class MouseInput : UserControl, IFunction
    {
        private MFunction _function;
        private IntPtr _lastWindow = IntPtr.Zero;

        public MouseInput()
        {
            InitializeComponent();
        }

        #region 鼠标事件
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PbMouse_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Stream stream = File.OpenRead(@"ico\_cur.png");
                var bmp = (Bitmap)Image.FromStream(stream);
                stream.Close();
                Cursor = new Cursor(bmp.GetHicon());
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PbMouse_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && Cursor != Cursors.Default)
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
        private void PbMouse_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                CmMenu.Show(PbMouse, 0, PbMouse.Height);
                return;
            }

            if (e.Button == MouseButtons.Left && Cursor != Cursors.Default)
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
                TbMouse.Text = "";
            }
            else
            {
                Point point = Cursor.Position;
                if (MiLocRef.Checked)
                {
                    User32API.ScreenToClient(window, ref point);
                }

                var buf = new StringBuilder();
                buf.Append(MiLocRef.Checked ? '@' : '&');
                buf.Append('[');
                buf.Append(point.X);
                buf.Append(',');
                buf.Append(point.Y);
                buf.Append("](");
                if (MiLButton.Checked)
                {
                    buf.Append("Left");
                }
                else if (MiMButton.Checked)
                {
                    buf.Append("Middle");
                }
                else if (MiRButton.Checked)
                {
                    buf.Append("Right");
                }
                buf.Append(',');

                if (MiClick.Checked)
                {
                    buf.Append("Click");
                }
                else if (MiDown.Checked)
                {
                    buf.Append("Down");
                }
                else if (MiMove.Checked)
                {
                    buf.Append("Move");
                }
                else if (MiUp.Checked)
                {
                    buf.Append("Up");
                }
                buf.Append(')');

                TbMouse.Text = buf.ToString();
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
                TbMouse.Text = text;
                MiLocRef.Checked = text.Length < 1 || '@' == text[0];
            }
        }

        public bool SaveFunction()
        {
            if (_function == null)
            {
                return false;
            }

            string param = (TbMouse.Text ?? "").Trim();
            if (string.IsNullOrEmpty(param))
            {
                MessageBox.Show(this, "请输入鼠标信息！", "鼠标输入", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TbMouse.Focus();
                return false;
            }
            param = Regex.Replace(param, "\\s+", "");

            if (!Regex.IsMatch(param, "^[&@]\\[[0-9]+,[0-9]+\\]\\([A-Za-z]+,[A-Za-z]+\\)$"))
            {
                MessageBox.Show(this, "您输入的鼠标事件格式有误，正确格式为[x,y](button,event)！", "鼠标输入", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TbMouse.Focus();
                return false;
            }

            _function.Action = EAction.MouseInput;
            _function.Param = param;
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

        #region 鼠标菜单

        private void MiLocRef_Click(object sender, EventArgs e)
        {
            MiLocRef.Checked = !MiLocRef.Checked;
        }

        private void MiLButton_Click(object sender, EventArgs e)
        {
            MiLButton.Checked = true;
            MiMButton.Checked = false;
            MiRButton.Checked = false;

            if (string.IsNullOrEmpty(TbMouse.Text))
            {
                return;
            }
            TbMouse.Text = Regex.Replace(TbMouse.Text, "\\(\\s*\\w+\\s*,", "(Left,", RegexOptions.IgnoreCase);
        }

        private void MiMButton_Click(object sender, System.EventArgs e)
        {
            MiLButton.Checked = false;
            MiMButton.Checked = true;
            MiRButton.Checked = false;

            if (string.IsNullOrEmpty(TbMouse.Text))
            {
                return;
            }
            TbMouse.Text = Regex.Replace(TbMouse.Text, "\\(\\s*\\w+\\s*,", "(Middle,", RegexOptions.IgnoreCase);
        }

        private void MiRButton_Click(object sender, System.EventArgs e)
        {
            MiLButton.Checked = false;
            MiMButton.Checked = false;
            MiRButton.Checked = true;

            if (string.IsNullOrEmpty(TbMouse.Text))
            {
                return;
            }
            TbMouse.Text = Regex.Replace(TbMouse.Text, "\\(\\s*\\w+\\s*,", "(Right,", RegexOptions.IgnoreCase);
        }

        private void MiClick_Click(object sender, System.EventArgs e)
        {
            MiClick.Checked = true;
            MiDown.Checked = false;
            MiMove.Checked = false;
            MiUp.Checked = false;

            if (string.IsNullOrEmpty(TbMouse.Text))
            {
                return;
            }
            TbMouse.Text = Regex.Replace(TbMouse.Text, ",\\s*\\w+\\s*\\)", ",Click)", RegexOptions.IgnoreCase);
        }

        private void MiDown_Click(object sender, System.EventArgs e)
        {
            MiClick.Checked = false;
            MiDown.Checked = true;
            MiMove.Checked = false;
            MiUp.Checked = false;

            if (string.IsNullOrEmpty(TbMouse.Text))
            {
                return;
            }
            TbMouse.Text = Regex.Replace(TbMouse.Text, ",\\s*\\w+\\s*\\)", ",Down)", RegexOptions.IgnoreCase);
        }

        private void MiMove_Click(object sender, System.EventArgs e)
        {
            MiClick.Checked = false;
            MiDown.Checked = false;
            MiMove.Checked = true;
            MiUp.Checked = false;

            if (string.IsNullOrEmpty(TbMouse.Text))
            {
                return;
            }
            TbMouse.Text = Regex.Replace(TbMouse.Text, ",\\s*\\w+\\s*\\)", ",Move)", RegexOptions.IgnoreCase);
        }

        private void MiUp_Click(object sender, System.EventArgs e)
        {
            MiClick.Checked = false;
            MiDown.Checked = false;
            MiMove.Checked = false;
            MiUp.Checked = true;

            if (string.IsNullOrEmpty(TbMouse.Text))
            {
                return;
            }
            TbMouse.Text = Regex.Replace(TbMouse.Text, ",\\s*\\w+\\s*\\)", ",Up)", RegexOptions.IgnoreCase);
        }
        #endregion
    }
}
