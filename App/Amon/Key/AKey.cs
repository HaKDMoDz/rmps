using System;
using System.Windows.Forms;
using Me.Amon.M;
using Me.Amon.Util;

namespace Me.Amon.Key
{
    public partial class AKey : Form
    {
        public AKey()
        {
            InitializeComponent();
        }

        public int Length { get; set; }

        public string Key { get; private set; }

        private void BtOk_Click(object sender, EventArgs e)
        {
            int len = decimal.ToInt32(SpLength.Value);
            if (len < 1)
            {
                Main.ShowAlert("字符长度不能小于1！");
                SpLength.Focus();
                return;
            }

            Udc udc = CbCharset.SelectedItem as Udc;
            if (udc == null)
            {
                Main.ShowAlert("请选择字符空间！");
                CbCharset.Focus();
                return;
            }

            char[] tmp = SafeUtil.NextRandomKey(udc.Data.ToCharArray(), len, CbRepeatable.Checked);
            if (tmp == null)
            {
                Main.ShowAlert(string.Format("无法生成长度为 {0} 且{1}重复的随机口令！", len, CbRepeatable.Checked ? "可" : "不可"));
                return;
            }

            Key = new string(tmp);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtNo_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
