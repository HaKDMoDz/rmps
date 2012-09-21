using System.Text.RegularExpressions;
using System.Windows.Forms;
using Me.Amon.Kms.Enums;
using Me.Amon.Kms.M;

namespace Me.Amon._uc
{
    public partial class KeybdInput : UserControl, IFunction
    {
        private MFunction _function;

        public KeybdInput()
        {
            InitializeComponent();
        }

        #region 键盘事件
        private void TbKeybd_KeyDown(object sender, KeyEventArgs e)
        {
            if (MiDown.Checked)
            {
                TbKeybd.Text = e.KeyCode + " Down";
            }
            e.Handled = true;
        }

        private void TbKeybd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (MiPress.Checked)
            {
                TbKeybd.Text = e.KeyChar + " Press";
            }
            e.Handled = true;
        }

        private void TbKeybd_KeyUp(object sender, KeyEventArgs e)
        {
            if (MiUp.Checked)
            {
                TbKeybd.Text = e.KeyCode + " Up";
            }
            e.Handled = true;
        }

        private void PbKeybd_Click(object sender, System.EventArgs e)
        {
            CmMenu.Show(PbKeybd, 0, PbKeybd.Height);
        }
        #endregion

        #region 菜单事件
        private void MiListen_Click(object sender, System.EventArgs e)
        {
            MiListen.Checked = !MiListen.Checked;
        }

        private void MiPress_Click(object sender, System.EventArgs e)
        {
            MiPress.Checked = true;
            MiDown.Checked = false;
            MiUp.Checked = false;
        }

        private void MiDown_Click(object sender, System.EventArgs e)
        {
            MiPress.Checked = false;
            MiDown.Checked = true;
            MiUp.Checked = false;
        }

        private void MiUp_Click(object sender, System.EventArgs e)
        {
            MiPress.Checked = false;
            MiDown.Checked = false;
            MiUp.Checked = true;
        }

        private void MiSpace_Click(object sender, System.EventArgs e)
        {
            if (MiPress.Checked)
            {
                TbKeybd.Text = "Space Press";
                return;
            }
            if (MiDown.Checked)
            {
                TbKeybd.Text = "Space Down";
                return;
            }
            if (MiUp.Checked)
            {
                TbKeybd.Text = "Space Up";
                return;
            }
        }

        private void MiBackspace_Click(object sender, System.EventArgs e)
        {
            if (MiPress.Checked)
            {
                TbKeybd.Text = "Backspace Press";
                return;
            }
            if (MiDown.Checked)
            {
                TbKeybd.Text = "Backspace Down";
                return;
            }
            if (MiUp.Checked)
            {
                TbKeybd.Text = "Backspace Up";
                return;
            }
        }

        private void MiEnter_Click(object sender, System.EventArgs e)
        {
            if (MiPress.Checked)
            {
                TbKeybd.Text = "Return Press";
                return;
            }
            if (MiDown.Checked)
            {
                TbKeybd.Text = "Return Down";
                return;
            }
            if (MiUp.Checked)
            {
                TbKeybd.Text = "Return Up";
                return;
            }
        }

        private void MiEsc_Click(object sender, System.EventArgs e)
        {
            if (MiPress.Checked)
            {
                TbKeybd.Text = "Escape Press";
                return;
            }
            if (MiDown.Checked)
            {
                TbKeybd.Text = "Escape Down";
                return;
            }
            if (MiUp.Checked)
            {
                TbKeybd.Text = "Escape Up";
                return;
            }
        }

        private void MiTab_Click(object sender, System.EventArgs e)
        {
            if (MiPress.Checked)
            {
                TbKeybd.Text = "Tab Press";
                return;
            }
            if (MiDown.Checked)
            {
                TbKeybd.Text = "Tab Down";
                return;
            }
            if (MiUp.Checked)
            {
                TbKeybd.Text = "Tab Up";
                return;
            }
        }

        private void MiCaps_Click(object sender, System.EventArgs e)
        {
            if (MiPress.Checked)
            {
                TbKeybd.Text = "Capital Press";
                return;
            }
            if (MiDown.Checked)
            {
                TbKeybd.Text = "Capital Down";
                return;
            }
            if (MiUp.Checked)
            {
                TbKeybd.Text = "Capital Up";
                return;
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
                TbKeybd.Text = _function.Param ?? "";
            }
        }

        public bool SaveFunction()
        {
            if (_function == null)
            {
                return false;
            }

            string param = (TbKeybd.Text ?? "").Trim();
            if (string.IsNullOrEmpty(param))
            {
                MessageBox.Show(this, "请输入按键信息！", "键盘输入", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TbKeybd.Focus();
                return false;
            }
            param = Regex.Replace(param, "\\s+", " ");

            string temp = param.ToUpper().Replace("ESCAPE", "~").Replace("TAB", "~").Replace("CAPS", "~").Replace("SHIFT", "~").Replace("CONTROL", "~").Replace("ALT", "~").Replace("SPACE", "~").Replace("ENTER", "~").Replace("BACKSPACE", "~");
            temp = temp.Replace("RETURN", "~").Replace("BACK", "~").Replace("CAPITAL", "~").Replace("CONTROLKEY", "~").Replace("SHIFTKEY", "~").Replace("MENUKEY", "~");
            if (!Regex.IsMatch(temp, "^[^\\s] \\w+$"))
            {
                MessageBox.Show(this, "您输入的键盘事件格式有误，正确格式为key event！", "键盘输入", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TbKeybd.Focus();
                return false;
            }

            _function.Action = EAction.KeybdInput;
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
    }
}
