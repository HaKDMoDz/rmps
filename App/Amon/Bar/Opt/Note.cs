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
            buffer.Append("DTXT:");
            buffer.Append("SUB:;").Append(TbSub.Text).Append(';');
            if (CharUtil.IsValidate(TbTxt.Text))
            {
                buffer.Append("TXT:").Append(TbTxt.Text).Append(';');
            }
            buffer.Append(';');
            return buffer.ToString();
        }
        #endregion
    }
}
