using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Me.Amon.Api.User32;

namespace Me.Amon._uc
{
    public partial class PostAction : UserControl
    {
        public PostAction()
        {
            InitializeComponent();
        }

        public string UserAction
        {
            get
            {
                return Regex.Replace(TbAction.Text.Trim(), "\\s+", " ");
            }
            set
            {
                TbAction.Text = value;
                ChangeState(!string.IsNullOrEmpty(value) && Regex.IsMatch(value, "^[@&]\\[\\d+,\\d+\\]\\(\\w+,\\d+\\)$"));
            }
        }

        private void ChangeState(bool mouseAction)
        {
            MiKeybd.Checked = !mouseAction;
            MiMonitor.Checked = true;
            MiMonitor.Enabled = !mouseAction;
            MiSpecial.Enabled = !mouseAction;

            MiMouse.Checked = mouseAction;
            MiRelative.Checked = true;
            MiRelative.Enabled = mouseAction;
        }

        #region 菜单事件
        private void MiKeybd_Click(object sender, EventArgs e)
        {
            TbAction.Text = "";
            ChangeState(false);
        }

        private void MiMouse_Click(object sender, EventArgs e)
        {
            TbAction.Text = "";
            ChangeState(true);
        }

        private void MiEnter_Click(object sender, EventArgs e)
        {
            TbAction.Text = "Enter";
        }

        private void MiBackspace_Click(object sender, EventArgs e)
        {
            TbAction.Text = "Backspace";
        }

        private void MiHome_Click(object sender, EventArgs e)
        {
            TbAction.Text = "Home";
        }

        private void MiEnd_Click(object sender, EventArgs e)
        {
            TbAction.Text = "End";
        }

        private void MiInsert_Click(object sender, EventArgs e)
        {
            TbAction.Text = "Insert";
        }

        private void MiDelete_Click(object sender, EventArgs e)
        {
            TbAction.Text = "Delete";
        }
        #endregion

        #region 图标事件
        private IntPtr _lastWindow = IntPtr.Zero;
        private void PbAction_Click(object sender, EventArgs e)
        {
            CmMenu.Show(PbAction, 0, PbAction.Height);
        }

        private void PbAction_MouseDown(object sender, MouseEventArgs e)
        {
            if (!MiMouse.Checked)
            {
                return;
            }
            if (e.Button == MouseButtons.Left)
            {
                Stream stream = File.OpenRead(@"ico\_cur.png");
                var bmp = (Bitmap)Image.FromStream(stream);
                stream.Close();
                Cursor = new Cursor(bmp.GetHicon());
            }
        }

        private void PbAction_MouseMove(object sender, MouseEventArgs e)
        {
            if (!MiMouse.Checked)
            {
                return;
            }
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

        private void PbAction_MouseUp(object sender, MouseEventArgs e)
        {
            if (!MiMouse.Checked)
            {
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
                TbAction.Text = "";
            }
            else
            {
                Point point = Cursor.Position;
                if (MiRelative.Checked)
                {
                    User32API.ScreenToClient(window, ref point);
                }
                var className = new StringBuilder(256);
                User32API.GetClassName(window, className, className.Capacity);

                var buf = new StringBuilder();
                buf.Append(MiRelative.Checked ? '@' : '&');
                buf.Append('[');
                buf.Append(point.X);
                buf.Append(',');
                buf.Append(point.Y);
                buf.Append("](");
                buf.Append(className.ToString());
                buf.Append(",1)");

                TbAction.Text = buf.ToString();
            }
        }
        #endregion

        #region 文本框事件
        private void TbAction_KeyDown(object sender, KeyEventArgs e)
        {
            if (!MiKeybd.Checked)
            {
                return;
            }
            e.Handled = true;

            if (e.KeyCode == Keys.ControlKey)
            {
                TbAction.Text = "Control";
                return;
            }
            if (e.KeyCode == Keys.ShiftKey)
            {
                TbAction.Text = "Shift";
                return;
            }
            if (e.KeyCode == Keys.Menu)
            {
                TbAction.Text = "Alt";
                return;
            }

            var buf = new StringBuilder();
            if (e.Control)
            {
                buf.Append("Control ");
            }
            if (e.Shift)
            {
                buf.Append("Shift ");
            }
            if (e.Alt)
            {
                buf.Append("Alt ");
            }
            buf.Append(e.KeyCode.ToString());
            TbAction.Text = buf.ToString();
        }

        private void TbAction_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!MiKeybd.Checked)
            {
                return;
            }
            e.Handled = true;
        }

        private void TbAction_KeyUp(object sender, KeyEventArgs e)
        {
            if (!MiKeybd.Checked)
            {
                return;
            }
            e.Handled = true;
        }
        #endregion
    }
}
