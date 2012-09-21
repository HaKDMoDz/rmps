using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Me.Amon.Da;
using Me.Amon.M;

namespace Me.Amon.Uw
{
    public partial class UdcEditor : Form
    {
        private Udc _Item;
        private UserModel _UserModel;
        private UdcModel _UdcModel;

        #region 构造函数
        public UdcEditor()
        {
            InitializeComponent();
        }

        public UdcEditor(UserModel userModel)
        {
            _UserModel = userModel;

            InitializeComponent();

            this.Icon = Me.Amon.Properties.Resources.Icon;
        }

        public void Init(UdcModel udcModel, Udc udc)
        {
            _UdcModel = udcModel;
            if (_UdcModel != null)
            {
                foreach (Udc tmp in _UdcModel.UdcList)
                {
                    LsUdc.Items.Add(tmp);
                }
            }

            TbName.MaxLength = DBConst.AUDC0104_SIZE;
            TbTips.MaxLength = DBConst.AUDC0105_SIZE;
            TbChar.MaxLength = DBConst.AUDC0106_SIZE;

            LsUdc.SelectedItem = udc;
            ShowData(udc);
        }
        #endregion

        #region 事件处理
        private void LsUcs_SelectedIndexChanged(object sender, EventArgs e)
        {
            Udc item = LsUdc.SelectedItem as Udc;
            if (item == null)
            {
                return;
            }

            ShowData(item);
        }

        private void BtAppend_Click(object sender, EventArgs e)
        {
            LsUdc.SelectedIndex = -1;
            ShowData(new Udc());
        }

        private void BtUpdate_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region 私有函数
        private void ShowData(Udc item)
        {
            _Item = item;

            TbName.Text = _Item.Name;
            TbTips.Text = _Item.Tips;
            TbChar.Text = _Item.Data;
        }

        private void SaveData()
        {
            string text = TbName.Text.Trim();
            if (string.IsNullOrEmpty(text))
            {
                TbName.Text = text;
                MessageBox.Show("请输入标题！");
                TbName.Focus();
                return;
            }
            _Item.Name = text;
            _Item.Tips = TbTips.Text;

            text = Regex.Replace(TbChar.Text, "\\s+", "");
            if (text.Length < 2)
            {
                TbChar.Text = text;
                MessageBox.Show("请输入至少2个不同的有效字符！");
                TbChar.Focus();
                return;
            }

            StringBuilder buf = new StringBuilder(text);
            Dictionary<char, int> dic = new Dictionary<char, int>();
            char[] tmp = text.ToCharArray();
            int j = 0;
            for (int i = 0; i < tmp.Length; i += 1)
            {
                if (dic.ContainsKey(tmp[i]))
                {
                    buf.Remove(j, 1);
                    continue;
                }
                dic[tmp[i]] = i;
                j += 1;
            }

            TbChar.Text = buf.ToString();
            if (buf.Length < 2)
            {
                MessageBox.Show("请输入至少2个不同的有效字符！");
                TbChar.Focus();
                return;
            }
            _Item.Data = buf.ToString();

            _UserModel.DBA.SaveVcs(_Item);
            if (LsUdc.SelectedItem != null)
            {
                LsUdc.Items[LsUdc.SelectedIndex] = _Item;
            }
            else
            {
                LsUdc.Items.Add(_Item);
                ShowData(new Udc());
            }

            if (_UdcModel != null)
            {
                _UdcModel.Modified = -1;
            }
        }
        #endregion
    }
}
