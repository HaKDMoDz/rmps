using System;
using System.Text;
using System.Windows.Forms;

namespace Me.Amon.Kms.V.Sln
{
    public partial class HotKeys : UserControl
    {
        public HotKeys()
        {
            InitializeComponent();
        }

        public string HotKey
        {
            get
            {
                return (TbKeys.Text ?? "").Trim();
            }
            set
            {
                TbKeys.Text = value;
            }
        }

        #region 菜单事件
        private void MiMonitor_Click(object sender, EventArgs e)
        {
            MiMonitor.Checked = !MiMonitor.Checked;
        }

        private void MiEnter_Click(object sender, EventArgs e)
        {
            TbKeys.Text = "Return";
        }

        private void MiBackspace_Click(object sender, EventArgs e)
        {
            TbKeys.Text = "Backspace";
        }

        private void MiHome_Click(object sender, EventArgs e)
        {
            TbKeys.Text = "Home";
        }

        private void MiEnd_Click(object sender, EventArgs e)
        {
            TbKeys.Text = "End";
        }

        private void MiInsert_Click(object sender, EventArgs e)
        {
            TbKeys.Text = "Insert";
        }

        private void MiDelete_Click(object sender, EventArgs e)
        {
            TbKeys.Text = "Delete";
        }

        private void PbKeys_Click(object sender, EventArgs e)
        {
            CmMenu.Show(PbKeys, 0, PbKeys.Height);
        }
        #endregion

        #region 键盘事件
        private void TbKeys_KeyDown(object sender, KeyEventArgs e)
        {
            if (!MiMonitor.Checked)
            {
                return;
            }
            e.Handled = true;

            if (e.KeyCode == Keys.ControlKey)
            {
                TbKeys.Text = "Control";
                return;
            }
            if (e.KeyCode == Keys.ShiftKey)
            {
                TbKeys.Text = "Shift";
                return;
            }
            if (e.KeyCode == Keys.Menu)
            {
                TbKeys.Text = "Alt";
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
            TbKeys.Text = buf.ToString();
        }

        private void TbKeys_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!MiMonitor.Checked)
            {
                return;
            }
            e.Handled = true;
        }

        private void TbKeys_KeyUp(object sender, KeyEventArgs e)
        {
            if (!MiMonitor.Checked)
            {
                return;
            }
            e.Handled = true;
        }
        #endregion
    }
}
