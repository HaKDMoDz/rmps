using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Me.Amon.Da;
using Me.Amon.Model;
using Me.Amon.Model.Att;
using Me.Amon.Util;

namespace Me.Amon.Pwd._Log
{
    public partial class LogEdit : Form
    {
        private UserModel _UserModel;
        private SafeModel _SafeModel;
        private Key _Key;

        public LogEdit()
        {
            InitializeComponent();
        }

        public LogEdit(UserModel userModel)
        {
            _UserModel = userModel;
            _SafeModel = new SafeModel(userModel);

            InitializeComponent();
        }

        public void Init(Key key)
        {
            _Key = key;

            DBAccess dba = _UserModel.DBAccess;
            dba.ReInit();
            dba.AddTable(DBConst.APWD0A00);
            dba.AddColumn(DBConst.APWD0A01);
            dba.AddWhere(DBConst.APWD0A04, _UserModel.Code);
            dba.AddWhere(DBConst.APWD0A05, key.Id);
            dba.AddSort(DBConst.APWD0A01, false);

            DataTable dt = dba.ExecuteSelect();
            foreach (DataRow row in dt.Rows)
            {
                Log log = new Log();
                log.Id = row[DBConst.APWD0A01] as string;
                LbLog.Items.Add(log);
            }
            dt.Dispose();
        }

        private void LbLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            Log log = LbLog.SelectedItem as Log;
            if (log == null)
            {
                return;
            }

            DBAccess dba = _UserModel.DBAccess;
            #region 口令信息
            dba.ReInit();
            dba.AddTable(DBConst.APWD0A00);
            dba.AddWhere(DBConst.APWD0A01, log.Id.ToString());
            dba.AddWhere(DBConst.APWD0A04, _UserModel.Code);
            dba.AddWhere(DBConst.APWD0A05, _Key.Id);
            using (DataTable dt = dba.ExecuteSelect())
            {
                if (dt.Rows.Count != 1)
                {
                    return;
                }

                DataRow row = dt.Rows[0];
                Key key = new Key();
                key.Id = row[DBConst.APWD0A05] as string;
                key.Label = (int)row[DBConst.APWD0A02];
                key.Major = (int)row[DBConst.APWD0A03];
                key.CatId = row[DBConst.APWD0A06] as string;
                key.RegDate = row[DBConst.APWD0A07] as string;
                key.LibId = row[DBConst.APWD0A08] as string;
                key.Title = row[DBConst.APWD0A09] as string;
                key.MetaKey = row[DBConst.APWD0A0A] as string;
                key.IcoName = row[DBConst.APWD0A0B] as string;
                key.IcoPath = row[DBConst.APWD0A0C] as string;
                key.IcoMemo = row[DBConst.APWD0A0D] as string;
                key.GtdId = row[DBConst.APWD0A0E] as string;
                key.GtdMemo = row[DBConst.APWD0A0F] as string;
                key.Memo = row[DBConst.APWD0A10] as string;
                key.CipherVer = row[DBConst.APWD0A13] as string;
                _SafeModel.Key = key;
            }
            #endregion

            #region 口令内容
            dba.ReInit();
            dba.AddTable(DBConst.APWD0B00);
            dba.AddWhere(DBConst.APWD0B01, log.Id.ToString());
            dba.AddWhere(DBConst.APWD0B04, _Key.Id);
            dba.AddSort(DBConst.APWD0B02, true);
            StringBuilder buf = new StringBuilder();
            using (DataTable dt = dba.ExecuteSelect())
            {
                foreach (DataRow row in dt.Rows)
                {
                    buf.Append(row[DBConst.APWD0B05] as string);
                }
            }
            _SafeModel.Decode(buf.ToString());
            #endregion

            buf.Clear();
            GuidAtt guid = _SafeModel.Guid;
            buf.Append("时间：").Append(guid.Name).Append(Environment.NewLine);
            MetaAtt meta = _SafeModel.Meta;
            buf.Append("标题：").Append(meta.Name).Append(Environment.NewLine);
            buf.Append("搜索：").Append(meta.Data).Append(Environment.NewLine);
            LogoAtt logo = _SafeModel.Logo;
            buf.Append("徽标：").Append(logo.Data).Append(Environment.NewLine);
            HintAtt hint = _SafeModel.Hint;
            buf.Append("提醒：").Append(hint.Data).Append(Environment.NewLine);
            AAtt temp;
            for (int j = AAtt.HEAD_SIZE; j < _SafeModel.Count; j += 1)
            {
                temp = _SafeModel.GetAtt(j);
                buf.Append(temp.Name).Append("：").Append(temp.Data).Append(Environment.NewLine);
            }
            TbLog.Text = buf.ToString();
        }

        private void BtResume_Click(object sender, EventArgs e)
        {
            Log log = LbLog.SelectedItem as Log;
            if (log == null)
            {
                MessageBox.Show("请选择您要恢复到的记录！");
                LbLog.Focus();
                return;
            }

            if (DialogResult.OK != MessageBox.Show("为了确保您的数据安全，此操作仅复制一份选中的数据为最新数据，\n确认要执行此操作么？", "", MessageBoxButtons.YesNo))
            {
                return;
            }

            DBAccess dba = _UserModel.DBAccess;
            string t = HashUtil.UtcTimeInHex();
            #region 数据备份
            if (_SafeModel.Key.Backup)
            {
                dba.ReInit();
                dba.AddParam(DBConst.APWD0A01, t);
                dba.AddParam(DBConst.APWD0A02, DBConst.APWD0102);
                dba.AddParam(DBConst.APWD0A03, DBConst.APWD0103);
                dba.AddParam(DBConst.APWD0A04, DBConst.APWD0104);
                dba.AddParam(DBConst.APWD0A05, DBConst.APWD0105);
                dba.AddParam(DBConst.APWD0A06, DBConst.APWD0106);
                dba.AddParam(DBConst.APWD0A07, DBConst.APWD0107);
                dba.AddParam(DBConst.APWD0A08, DBConst.APWD0108);
                dba.AddParam(DBConst.APWD0A09, DBConst.APWD0109);
                dba.AddParam(DBConst.APWD0A0A, DBConst.APWD010A);
                dba.AddParam(DBConst.APWD0A0B, DBConst.APWD010B);
                dba.AddParam(DBConst.APWD0A0C, DBConst.APWD010C);
                dba.AddParam(DBConst.APWD0A0D, DBConst.APWD010D);
                dba.AddParam(DBConst.APWD0A0E, DBConst.APWD010E);
                dba.AddParam(DBConst.APWD0A0F, DBConst.APWD010F);
                dba.AddParam(DBConst.APWD0A10, DBConst.APWD0110);
                dba.AddParam(DBConst.APWD0A11, DBConst.APWD0111);
                dba.AddParam(DBConst.APWD0A12, DBConst.APWD0112);
                dba.AddParam(DBConst.APWD0A13, DBConst.APWD0113);
                dba.AddWhere(DBConst.APWD0104, _UserModel.Code);
                dba.AddWhere(DBConst.APWD0105, _SafeModel.Key.Id);
                dba.AddBackupBatch(DBConst.APWD0A00, DBConst.APWD0100);

                dba.ReInit();
                dba.AddParam(DBConst.APWD0B01, t);
                dba.AddParam(DBConst.APWD0B02, DBConst.APWD0201);
                dba.AddParam(DBConst.APWD0B04, DBConst.APWD0203);
                dba.AddParam(DBConst.APWD0B05, DBConst.APWD0204);
                dba.AddWhere(DBConst.APWD0203, _SafeModel.Key.Id);
                dba.AddBackupBatch(DBConst.APWD0B00, DBConst.APWD0200);
            }
            #endregion

            #region 数据恢复
            dba.ReInit();
            dba.AddParam(DBConst.APWD0102, _SafeModel.Key.Label);
            dba.AddParam(DBConst.APWD0103, _SafeModel.Key.Major);
            dba.AddParam(DBConst.APWD0106, _SafeModel.Key.CatId);
            dba.AddParam(DBConst.APWD0107, _SafeModel.Key.RegDate);
            dba.AddParam(DBConst.APWD0108, _SafeModel.Key.LibId);
            dba.AddParam(DBConst.APWD0109, _SafeModel.Key.Title);
            dba.AddParam(DBConst.APWD010A, _SafeModel.Key.MetaKey);
            dba.AddParam(DBConst.APWD010B, _SafeModel.Key.IcoName);
            dba.AddParam(DBConst.APWD010C, _SafeModel.Key.IcoPath);
            dba.AddParam(DBConst.APWD010D, _SafeModel.Key.IcoMemo);
            dba.AddParam(DBConst.APWD010E, _SafeModel.Key.GtdId);
            dba.AddParam(DBConst.APWD010F, _SafeModel.Key.GtdMemo);
            dba.AddParam(DBConst.APWD0110, _SafeModel.Key.Memo);
            dba.AddParam(DBConst.APWD0112, _SafeModel.Key.Backup ? "t" : "f");
            dba.AddParam(DBConst.APWD0113, _SafeModel.Key.CipherVer);
            dba.AddWhere(DBConst.APWD0104, _UserModel.Code);
            dba.AddWhere(DBConst.APWD0105, _Key.Id);
            dba.AddUpdateBatch();

            dba.ReInit();
            dba.AddTable(DBConst.APWD0B00);
            dba.AddWhere(DBConst.APWD0B04, _Key.Id);
            dba.AddDeleteBatch();

            dba.ReInit();
            dba.AddParam(DBConst.APWD0201, DBConst.APWD0B02);
            dba.AddParam(DBConst.APWD0203, DBConst.APWD0B04);
            dba.AddParam(DBConst.APWD0204, DBConst.APWD0B05);
            dba.AddParam(DBConst.APWD0B01, log.Id.ToString());
            dba.AddWhere(DBConst.APWD0B04, _Key.Id);
            dba.AddBackupBatch(DBConst.APWD0200, DBConst.APWD0B00);
            #endregion

            LbLog.Items.Insert(0, new Log { Id = t });
        }

        private void BtClearCur_Click(object sender, EventArgs e)
        {
            Log log = LbLog.SelectedItem as Log;
            if (log == null)
            {
                MessageBox.Show("请选择您要恢复到的记录！");
                LbLog.Focus();
                return;
            }

            if (DialogResult.OK != MessageBox.Show("确认要删除选中的历史信息么，此操作不可恢复？", "", MessageBoxButtons.YesNo))
            {
                return;
            }

            DBAccess dba = _UserModel.DBAccess;
            dba.ReInit();
            dba.AddTable(DBConst.APWD0A00);
            dba.AddWhere(DBConst.APWD0A01, log.Id.ToString());
            dba.AddWhere(DBConst.APWD0A04, _UserModel.Code);
            dba.AddWhere(DBConst.APWD0A05, _Key.Id);
            dba.AddDeleteBatch();

            dba.ReInit();
            dba.AddTable(DBConst.APWD0B00);
            dba.AddWhere(DBConst.APWD0B01, log.Id.ToString());
            dba.AddWhere(DBConst.APWD0B04, _Key.Id);
            dba.AddDeleteBatch();

            dba.ExecuteBatch();
            LbLog.Items.Remove(log);
        }

        private void BtClearAll_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK != MessageBox.Show("确认要删除此记录的所有历史信息吗，此操作将不可恢复？", "", MessageBoxButtons.YesNo))
            {
                return;
            }

            DBAccess dba = _UserModel.DBAccess;
            dba.ReInit();
            dba.AddTable(DBConst.APWD0A00);
            dba.AddWhere(DBConst.APWD0A04, _UserModel.Code);
            dba.AddWhere(DBConst.APWD0A05, _Key.Id);
            dba.AddDeleteBatch();

            dba.ReInit();
            dba.AddTable(DBConst.APWD0B00);
            dba.AddWhere(DBConst.APWD0B04, _Key.Id);
            dba.AddDeleteBatch();

            dba.ExecuteBatch();
            LbLog.Items.Clear();
        }
    }
}
