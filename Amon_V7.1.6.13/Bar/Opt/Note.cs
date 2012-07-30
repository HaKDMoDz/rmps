using System.Text;
using System.Windows.Forms;
using Me.Amon.Util;

namespace Me.Amon.Bar.Opt
{
    public partial class Note : UserControl, IOpt
    {
        public Note()
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
            if (string.IsNullOrEmpty(TbSub.Text))
            {
                Main.ShowAlert("请输入标题！");
                TbSub.Focus();
                return false;
            }
            return true;
        }

        public string Encode()
        {
            StringBuilder buffer = new StringBuilder();
            buffer.Append(EBar.OPT_NOTE).Append(':');
            buffer.Append("SUB:;").Append(TbSub.Text).Append(';');
            if (CharUtil.IsValidate(TbTxt.Text))
            {
                buffer.Append("TXT:").Append(TbTxt.Text).Append(';');
            }
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
                if (tmp == "TXT")
                {
                    TbTxt.Text = arr[i].Substring(idx + 1);
                }
            }
        }
        #endregion
    }
}
