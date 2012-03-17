using System.Text;
using System.Windows.Forms;

namespace Me.Amon.Bar.Opt
{
    public partial class Vcard : UserControl, IOpt
    {
        public Vcard()
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
            buffer.Append("CARD:");
            buffer.Append("N:").Append(TbName.Text).Append(';');
            buffer.Append("M:").Append(TbMbl.Text).Append(';');
            buffer.Append("EM:").Append(TbMail.Text).Append(';');
            buffer.Append("COR:").Append(TbOrg.Text).Append(';');
            buffer.Append("DIV:").Append(TbDiv.Text).Append(';');
            buffer.Append("TIL:").Append(TbTitle.Text).Append(';');
            buffer.Append("ADR:").Append(TbAdr.Text).Append(';');
            buffer.Append("ZIP:").Append(TbZip.Text).Append(';');
            buffer.Append("FAX:").Append(TbFax.Text).Append(';');
            buffer.Append("URL:http://amon.me/;");
            buffer.Append("TEL:").Append(TbTel.Text).Append(';');
            buffer.Append("IM:a@b.c;");
            buffer.Append(';');
            return buffer.ToString();
        }
        #endregion
    }
}
