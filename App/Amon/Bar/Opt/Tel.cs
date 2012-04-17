using System.Text;
using System.Windows.Forms;
using Me.Amon.Util;

namespace Me.Amon.Bar.Opt
{
    public partial class Tel : UserControl, IOpt
    {
        public Tel()
        {
            InitializeComponent();
        }

        #region 接口实现
        public void InitView(GroupBox gBox)
        {
            Location = new System.Drawing.Point(6, 18);
            Size = new System.Drawing.Size(296, 156);
            TabIndex = 0;
            gBox.Controls.Add(this);
        }

        public void HideView(GroupBox gBox)
        {
            gBox.Controls.Remove(this);
        }

        public bool Check()
        {
            string tel = TbTel.Text;
            if (string.IsNullOrEmpty(tel))
            {
                Main.ShowAlert("请输入电话号码！");
                TbTel.Focus();
                return false;
            }
            if (!CharUtil.IsValidateCall(tel))
            {
                Main.ShowAlert("请输入一个有效的电话号码！");
                TbTel.Focus();
                return false;
            }
            return true;
        }

        public string Encode()
        {
            StringBuilder buffer = new StringBuilder();
            buffer.Append(EBar.OPT_TEL).Append(':');
            buffer.Append(TbTel.Text);
            return buffer.ToString();
        }

        public void Decode(string data)
        {
            TbTel.Text = data;
        }
        #endregion
    }
}
