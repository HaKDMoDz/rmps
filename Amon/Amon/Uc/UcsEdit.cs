using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Me.Amon.Da;
using Me.Amon.Model;
using Me.Amon.Util;

namespace Me.Amon.Uc
{
    public partial class UcsEdit : Form
    {
        private Ucs _Item;
        private UserModel _UserModel;
        private DataModel _DataModel;

        public UcsEdit()
        {
            InitializeComponent();
        }

        public UcsEdit(UserModel userModel)
        {
            _UserModel = userModel;

            InitializeComponent();
        }

        public void Init(DataModel dataModel)
        {
            _DataModel = dataModel;
            ShowData(new Ucs());
        }

        #region 事件处理
        private void LsUcs_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ucs item = LsUcs.SelectedItem as Ucs;
            if (item == null)
            {
                return;
            }

            ShowData(item);
        }

        private void BtAppend_Click(object sender, EventArgs e)
        {
            ShowData(new Ucs());
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
        private void ShowData(Ucs item)
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
            for (int i = tmp.Length - 1; i >= 0; i -= 1)
            {
                if (dic.ContainsKey(tmp[i]))
                {
                    buf.Remove(i, 1);
                    continue;
                }
                dic[tmp[i]] = i;
            }

            TbChar.Text = buf.ToString();
            if (buf.Length < 2)
            {
                MessageBox.Show("请输入至少2个不同的有效字符！");
                TbChar.Focus();
                return;
            }
            _Item.Data = buf.ToString();

            DBAccess dba = _UserModel.DBAccess;
            dba.ReInit();
            dba.AddTable(IDat.AICO0100);
            dba.AddParam(IDat.AICO0104, _Item.Name);
            dba.AddParam(IDat.AICO0105, _Item.Tips);
            dba.AddParam(IDat.AICO0106, _Item.Data);
            dba.AddParam(IDat.AICO0107, "");
            dba.AddParam(IDat.AICO0108, IDat.SQL_NOW, false);
            if (CharUtil.IsValidateHash(_Item.Id))
            {
                dba.AddWhere(IDat.AICO0102, _UserModel.Code);
                dba.AddWhere(IDat.AICO0103, _Item.Id);
                dba.AddVcs(IDat.AICO010A, 1);
                dba.AddOpt(IDat.AICO010B, _Item.Operate, IDat.OPT_UPDATE);
                dba.ExecuteUpdate();

                LsUcs.Items[LsUcs.SelectedIndex] = _Item;
            }
            else
            {
                _Item.Id = HashUtil.GetCurrTimeHex(false);
                dba.AddParam(IDat.AICO0101, LsUcs.Items.Count);
                dba.AddParam(IDat.AICO0102, _UserModel.Code);
                dba.AddParam(IDat.AICO0103, _Item.Id);
                dba.AddParam(IDat.AICO0109, IDat.SQL_NOW, false);
                dba.AddParam(IDat.AICO010A, IDat.VCS_DEFAULT);
                dba.AddParam(IDat.AICO010B, IDat.OPT_UPDATE);
                dba.ExecuteInsert();

                LsUcs.Items.Add(_Item);
                ShowData(new Ucs());
            }
            //_DataModel.UcsChanged = true;
        }
        #endregion
    }
}
