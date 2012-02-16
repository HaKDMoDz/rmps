using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Me.Amon.Da;
using Me.Amon.Model;
using Me.Amon.Util;

namespace Me.Amon.Uw
{
    public partial class UdcEdit : Form
    {
        private Udc _Item;
        private UserModel _UserModel;
        private DataModel _DataModel;

        public UdcEdit()
        {
            InitializeComponent();
        }

        public UdcEdit(UserModel userModel)
        {
            _UserModel = userModel;

            InitializeComponent();
        }

        public void Init(DataModel dataModel)
        {
            _DataModel = dataModel;

            TbName.MaxLength = DBConst.AUCS0104_SIZE;
            TbTips.MaxLength = DBConst.AUCS0105_SIZE;
            TbChar.MaxLength = DBConst.AUCS0106_SIZE;

            ShowData(new Udc());
        }

        #region 事件处理
        private void LsUcs_SelectedIndexChanged(object sender, EventArgs e)
        {
            Udc item = LsUcs.SelectedItem as Udc;
            if (item == null)
            {
                return;
            }

            ShowData(item);
        }

        private void BtAppend_Click(object sender, EventArgs e)
        {
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
            dba.AddTable(DBConst.AUCS0100);
            dba.AddParam(DBConst.AUCS0104, _Item.Name);
            dba.AddParam(DBConst.AUCS0105, _Item.Tips);
            dba.AddParam(DBConst.AUCS0106, _Item.Data);
            dba.AddParam(DBConst.AUCS0107, "");
            dba.AddParam(DBConst.AUCS0108, DBConst.SQL_NOW, false);
            if (CharUtil.IsValidateHash(_Item.Id))
            {
                dba.AddWhere(DBConst.AUCS0102, _UserModel.Code);
                dba.AddWhere(DBConst.AUCS0103, _Item.Id);
                dba.AddVcs(DBConst.AUCS010A, DBConst.AUCS010B, _Item.Operate, DBConst.OPT_UPDATE);
                dba.ExecuteUpdate();

                LsUcs.Items[LsUcs.SelectedIndex] = _Item;
            }
            else
            {
                _Item.Id = HashUtil.UtcTimeInHex(false);
                dba.AddParam(DBConst.AUCS0101, LsUcs.Items.Count);
                dba.AddParam(DBConst.AUCS0102, _UserModel.Code);
                dba.AddParam(DBConst.AUCS0103, _Item.Id);
                dba.AddParam(DBConst.AUCS0109, DBConst.SQL_NOW, false);
                dba.AddVcs(DBConst.AUCS010A, DBConst.AUCS010B);
                dba.ExecuteInsert();

                LsUcs.Items.Add(_Item);
                ShowData(new Udc());
            }
            _DataModel.UcsModified = -1;
        }
        #endregion
    }
}
