using System.Text;
using System.Windows.Forms;

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
            buffer.Append("WIFI:");
            buffer.Append("T:").Append(CbType.SelectedText).Append(';');
            buffer.Append("S:").Append(TbSsid.Text).Append(';');
            buffer.Append("P:").Append(TbPass.Text).Append(';');
            buffer.Append(';');
            return buffer.ToString();
        }
        #endregion
    }
}
