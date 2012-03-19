using System.Text;
using System.Windows.Forms;
using Me.Amon.Util;

namespace Me.Amon.Bar.Opt
{
    public partial class Sms : UserControl, IOpt
    {
        public Sms()
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
            string tel = TbSub.Text.Trim();
            if (string.IsNullOrEmpty(tel))
            {
                Main.ShowAlert("请输入手机号码！");
                TbSub.Focus();
                return false;
            }
            if (!CharUtil.IsValidateCall(tel))
            {
                Main.ShowAlert("请输入一个有效的手机号码！");
                TbSub.Focus();
                return false;
            }
            return true;
        }

        public string Encode()
        {
            StringBuilder buffer = new StringBuilder();
            //buffer.Append("SMS:");
            //buffer.Append("SM:").Append(TbSub.Text).Append(';');
            //buffer.Append("TXT:").Append(TbTxt.Text).Append(';');
            //buffer.Append(';');
            buffer.Append("SMSTO:");
            buffer.Append(TbSub.Text);
            if (CharUtil.IsValidate(TbTxt.Text))
            {
                buffer.Append(':').Append(TbTxt.Text);
            }
            return buffer.ToString();
        }
        #endregion
    }
}
