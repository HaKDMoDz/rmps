using System.Text;
using System.Windows.Forms;
using Me.Amon.Util;

namespace Me.Amon.Bar.Opt
{
    public partial class Url : UserControl, IOpt
    {
        public Url()
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
            string url = TbUrl.Text;
            if (!CharUtil.IsValidateURL(url))
            {
                Main.ShowAlert("请输入一个有效的链接！");
                TbUrl.Focus();
                return false;
            }
            return true;
        }

        public string Encode()
        {
            StringBuilder buffer = new StringBuilder();
            buffer.Append(EBar.OPT_URL).Append(':');
            buffer.Append("SUB:").Append(TbSub.Text).Append(';');
            buffer.Append("URL:").Append(TbUrl.Text).Append(';');
            buffer.Append(';');
            return buffer.ToString();
        }

        public void Decode(string data)
        {
            if (!CharUtil.IsValidate(data))
            {
                return;
            }

            string[] arr = data.Split(';');
            for (int i = 1; i < arr.Length; i += 1)
            {
                if (!CharUtil.IsValidate(arr[i]))
                {
                    continue;
                }
                int idx = arr[i].IndexOf(':');
                if (idx < 1)
                {
                    continue;
                }
                string tmp = arr[i].Substring(0, idx).Trim().ToUpper();
                if (tmp == "SUB")
                {
                    TbSub.Text = arr[i].Substring(idx + 1);
                    continue;
                }
                if (tmp == "URL")
                {
                    TbUrl.Text = arr[i].Substring(idx + 1);
                }
            }
        }
        #endregion
    }
}
