using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Me.Amon.M;
using Me.Amon.Util;

namespace Me.Amon.Rcg
{
    public partial class ARcg : Form
    {
        public ARcg()
        {
            InitializeComponent();
        }

        public ARcg(IList<Udc> udcs)
        {
            InitializeComponent();

            this.Icon = Me.Amon.Properties.Resources.Icon;

            CbCharset.Items.Add(new Udc { Name = "请选择" });
            foreach (Udc udc in udcs)
            {
                CbCharset.Items.Add(udc);
            }
        }

        public int Length
        {
            get
            {
                return decimal.ToInt32(SpLength.Value);
            }
            set
            {
                if (value > 0 && value <= 1024)
                {
                    SpLength.Value = value;
                }
            }
        }

        public string SelectedUdc
        {
            get
            {
                Udc udc = CbCharset.SelectedItem as Udc;
                return udc != null ? udc.Id : "";
            }
            set
            {
                CbCharset.SelectedItem = value;
            }
        }

        public bool Repeatable
        {
            get
            {
                return CbRepeatable.Checked;
            }
            set
            {
                CbRepeatable.Checked = value;
            }
        }

        public string Key { get; private set; }

        private void BtGen_Click(object sender, EventArgs e)
        {
            int len = decimal.ToInt32(SpLength.Value);
            if (len < 1)
            {
                Main.ShowAlert("字符长度不能小于1！");
                SpLength.Focus();
                return;
            }

            Udc udc = CbCharset.SelectedItem as Udc;
            if (udc == null || !CharUtil.IsValidateHash(udc.Id))
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

            TbKey.Text = new string(tmp);
        }

        private void BtOk_Click(object sender, EventArgs e)
        {
            Key = TbKey.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtNo_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
