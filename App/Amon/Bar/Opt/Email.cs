using System.Text;
using System.Windows.Forms;
using Me.Amon.Util;

namespace Me.Amon.Bar.Opt
{
    public partial class Email : UserControl, IOpt
    {
        public Email()
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
            string adr = TbAdr.Text;
            if (string.IsNullOrEmpty(adr))
            {
                Main.ShowAlert("请输入收件人地址！");
                TbAdr.Focus();
                return false;
            }
            if (!CharUtil.IsValidateMail(adr))
            {
                Main.ShowAlert("请输入一个有效的邮件地址！");
                TbAdr.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(TbSub.Text))
            {
                Main.ShowAlert("请输入邮件标题！");
                TbSub.Focus();
                return false;
            }
            return true;
        }

        public string Encode()
        {
            StringBuilder buffer = new StringBuilder();
            //buffer.Append("MAIL:");
            //buffer.Append("TO:").Append(TbAdr.Text).Append(';');
            //buffer.Append("SUB:").Append(TbSub.Text).Append(';');
            //buffer.Append("TXT:").Append(TbTxt.Text).Append(';');
            //buffer.Append(';');
            buffer.Append(EBar.OPT_EMAIL).Append(':');
            buffer.Append(TbAdr.Text);
            if (CharUtil.IsValidate(TbSub.Text))
            {
                buffer.Append("?SUBJECT=").Append(TbSub.Text);
            }
            if (CharUtil.IsValidate(TbTxt.Text))
            {
                buffer.Append("&BODY=").Append(TbTxt.Text.Replace("\r", "%0D").Replace("\n", "%0A"));
            }
            return buffer.ToString();
        }

        public void Decode(string data)
        {
            if (!CharUtil.IsValidate(data))
            {
                return;
            }
            string[] arr = data.Split('?', '&');
            TbAdr.Text = arr[0];

            for (int i = 1; i < arr.Length; i += 1)
            {
                if (!CharUtil.IsValidate(arr[i]))
                {
                    continue;
                }
                int idx = arr[i].IndexOf('=');
                if (idx < 1)
                {
                    continue;
                }
                string tmp = arr[i].Substring(0, idx).Trim().ToUpper();
                if (tmp == "SUBJECT")
                {
                    TbSub.Text = arr[i].Substring(idx + 1);
                    continue;
                }
                if (tmp == "BODY")
                {
                    TbTxt.Text = arr[i].Substring(idx + 1).Replace("%0D", "\r").Replace("%0A", "\n");
                }
            }
        }
        #endregion
    }
}
