using System.Windows.Forms;

namespace Me.Amon.Bar.Opt
{
    public partial class Text : UserControl, IOpt
    {
        public Text()
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
            if (string.IsNullOrEmpty(TbTxt.Text))
            {
                Main.ShowAlert("请输入文本！");
                TbTxt.Focus();
                return false;
            }
            return true;
        }

        public string Encode()
        {
            return TbTxt.Text;
        }

        public void Decode(string data)
        {
            TbTxt.Text = data;
        }
        #endregion
    }
}
