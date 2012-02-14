using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Me.Amon.Uc;

namespace Me.Amon.Sec.Uw
{
    public partial class Mask : Form, IForm<Item>
    {
        private Item _Item;

        public Mask()
        {
            InitializeComponent();
        }

        public CallBackHandler<Item> CallBack { get; set; }

        public void Show(ASec asec, Item data)
        {
            _Item = data;
            TbName.Text = data.V;
            TbData.Text = data.D;
            BtOk.Enabled = _Item.K != "0";
            base.Show(asec);
        }

        private void BtOk_Click(object sender, System.EventArgs e)
        {
            string text = TbName.Text;
            if (string.IsNullOrWhiteSpace(text))
            {
                TbName.Text = text;
                // "请输入标题！";
                return;
            }
            _Item.V = text;

            text = Regex.Replace(TbData.Text, "\\s+", "");
            if (text.Length < 2)
            {
                TbData.Text = text;
                // "请输入至少2个不同的有效字符！";
                return;
            }
            StringBuilder buf = new StringBuilder(text);
            Dictionary<char, int> dic = new Dictionary<char, int>();
            char[] tmp = text.ToCharArray();
            for (int i = tmp.Length - 1; i >= 0; i -= 1)
            {
                if (dic.ContainsKey(tmp[i]))
                {
                    buf.Remove(i, 1);
                    continue;
                }
                dic[tmp[i]] = i;
            }
            if (text.Length < 2)
            {
                TbData.Text = buf.ToString();
                // "请输入至少2个不同的有效字符！";
                return;
            }
            _Item.D = text;

            if (CallBack != null)
            {
                CallBack.Invoke(_Item);
            }

            Close();
        }

        private void BtNo_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}