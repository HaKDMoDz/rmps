using System.Text;
using System.Windows.Forms;

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
            buffer.Append("MAIL:");
            buffer.Append("TO:").Append(TbAdr.Text).Append(';');
            buffer.Append("SUB:").Append(TbSub.Text).Append(';');
            buffer.Append("TXT:").Append(TbTxt.Text).Append(';');
            buffer.Append(';');
            return buffer.ToString();
        }
        #endregion
    }
}
