using System.Text;
using System.Windows.Forms;
using Me.Amon.Util;

namespace Me.Amon.Bar.Opt
{
    public partial class Wifi : UserControl, IOpt
    {
        public Wifi()
        {
            InitializeComponent();
        }

        #region 接口实现
        public void InitView(GroupBox gBox)
        {
            CbType.SelectedIndex = 0;

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
            string tel = TbSsid.Text;
            if (string.IsNullOrEmpty(tel))
            {
                Main.ShowAlert("请输入SSID！");
                TbSsid.Focus();
                return false;
            }
            return true;
        }

        public string Encode()
        {
            StringBuilder buffer = new StringBuilder();
            buffer.Append(EBar.OPT_WIFI).Append(':');
            buffer.Append("T:").Append(CbType.SelectedText).Append(';');
            buffer.Append("S:").Append(TbSsid.Text).Append(';');
            buffer.Append("P:").Append(TbPass.Text).Append(';');
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
                if (tmp == "T")
                {
                    CbType.SelectedItem = arr[i].Substring(idx + 1);
                    continue;
                }
                if (tmp == "S")
                {
                    TbSsid.Text = arr[i].Substring(idx + 1);
                    continue;
                }
                if (tmp == "P")
                {
                    TbPass.Text = arr[i].Substring(idx + 1);
                }
            }
        }
        #endregion
    }
}
