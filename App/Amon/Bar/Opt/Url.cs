using System.Text;
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
            Location = new System.Drawing.Point(6, 20);
            Size = new System.Drawing.Size(296, 148);
            TabIndex = 0;
            gBox.Controls.Add(this);
        }

        public void HideView(GroupBox gBox)
        {
            gBox.Controls.Remove(this);
        }

        public bool Check()
        {
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
