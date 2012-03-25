using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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
            if (!Regex.IsMatch(url, ""))
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
            buffer.Append("BM:");
            buffer.Append("SUB:").Append(TbSub.Text).Append(';');
            buffer.Append("URL:").Append(TbUrl.Text).Append(';');
            buffer.Append(';');
            return buffer.ToString();
        }
        #endregion
    }
}
