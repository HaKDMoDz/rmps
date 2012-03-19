using System.Text;
using System.Windows.Forms;
using Me.Amon.Util;

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
            string name = TbName.Text;
            if (string.IsNullOrEmpty(name))
            {
                Main.ShowAlert("请输入姓名！");
                TbName.Focus();
                return false;
            }
            return true;
        }

        public string Encode()
        {
            StringBuilder buffer = new StringBuilder();
            buffer.Append("CARD:");
            buffer.Append("N:").Append(TbName.Text).Append(';');
            if (CharUtil.IsValidate(TbMbl.Text))
            {
                buffer.Append("M:").Append(TbMbl.Text).Append(';');
            }
            if (CharUtil.IsValidate(TbMail.Text))
            {
                buffer.Append("EM:").Append(TbMail.Text).Append(';');
            }
            if (CharUtil.IsValidate(TbOrg.Text))
            {
                buffer.Append("COR:").Append(TbOrg.Text).Append(';');
            }
            if (CharUtil.IsValidate(TbDiv.Text))
            {
                buffer.Append("DIV:").Append(TbDiv.Text).Append(';');
            }
            if (CharUtil.IsValidate(TbTitle.Text))
            {
                buffer.Append("TIL:").Append(TbTitle.Text).Append(';');
            }
            if (CharUtil.IsValidate(TbAdr.Text))
            {
                buffer.Append("ADR:").Append(TbAdr.Text).Append(';');
            }
            if (CharUtil.IsValidate(TbZip.Text))
            {
                buffer.Append("ZIP:").Append(TbZip.Text).Append(';');
            }
            if (CharUtil.IsValidate(TbTel.Text))
            {
                buffer.Append("TEL:").Append(TbTel.Text).Append(';');
            }
            if (CharUtil.IsValidate(TbFax.Text))
            {
                buffer.Append("FAX:").Append(TbFax.Text).Append(';');
            }
            if (CharUtil.IsValidate(TbUrl.Text))
            {
                buffer.Append("URL:").Append(TbUrl.Text).Append(';');
            }
            if (CharUtil.IsValidate(TbIm.Text))
            {
                buffer.Append("IM:").Append(TbIm.Text).Append(';');
            }
            buffer.Append(';');
            return buffer.ToString();
        }
        #endregion
    }
}
