using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Me.Amon.Da;
using Me.Amon.Model;
using Me.Amon.Model.Att;

namespace Me.Amon.Pwd.Log
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
            dba.AddTable(IDat.APWD0A00);
            dba.AddColumn(IDat.APWD0A01);
            dba.AddWhere(IDat.APWD0A04, _UserModel.Code);
            dba.AddWhere(IDat.APWD0A05, key.Id);
            dba.AddSort(IDat.APWD0A01, false);

            DataTable dt = dba.ExecuteSelect();
            foreach (DataRow row in dt.Rows)
            {
                Model.Log log = new Model.Log();
                log.Id = (long)row[IDat.APWD0A01];
                LbLog.Items.Add(log);
            }
            dt.Dispose();
        }

        private void LbLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model.Log log = LbLog.SelectedItem as Model.Log;
            if (log == null)
            {
                return;
            }

            DBAccess dba = _UserModel.DBAccess;
            #region 口令信息
            dba.ReInit();
            dba.AddTable(IDat.APWD0A00);
            dba.AddWhere(IDat.APWD0A01, log.Id.ToString());
            dba.AddWhere(IDat.APWD0A04, _UserModel.Code);
            dba.AddWhere(IDat.APWD0A05, _Key.Id);
            using (DataTable dt = dba.ExecuteSelect())
            {
                if (dt.Rows.Count != 1)
                {
                    return;
                }

                DataRow row = dt.Rows[0];
                Key key = new Key();
                key.Id = row[IDat.APWD0A05] as string;
                key.Label = (int)row[IDat.APWD0A02];
                key.Major = (int)row[IDat.APWD0A03];
                key.CatId = row[IDat.APWD0A06] as string;
                key.RegDate = row[IDat.APWD0A07] as string;
                key.LibId = row[IDat.APWD0A08] as string;
                key.Title = row[IDat.APWD0A09] as string;
                key.MetaKey = row[IDat.APWD0A0A] as string;
                key.IcoName = row[IDat.APWD0A0B] as string;
                key.IcoPath = row[IDat.APWD0A0C] as string;
                key.IcoMemo = row[IDat.APWD0A0D] as string;
                key.GtdId = row[IDat.APWD0A0E] as string;
                key.GtdMemo = row[IDat.APWD0A0F] as string;
                key.Memo = row[IDat.APWD0A10] as string;
                key.CipherVer = row[IDat.APWD0A12] as string;
                _SafeModel.Key = key;
            }
            #endregion

            #region 口令内容
            dba.ReInit();
            dba.AddTable(IDat.APWD0B00);
            dba.AddWhere(IDat.APWD0B01, log.Id.ToString());
            dba.AddWhere(IDat.APWD0B03, _Key.Id);
            dba.AddSort(IDat.APWD0B02, true);
            StringBuilder buf = new StringBuilder();
            using (DataTable dt = dba.ExecuteSelect())
            {
                foreach (DataRow row in dt.Rows)
                {
                    buf.Append(row[IDat.APWD0B04] as string);
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
            Model.Log log = LbLog.SelectedItem as Model.Log;
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
            long t = DateTime.Now.Millisecond;
            #region 数据备份
            if (_SafeModel.Key.Backup)
            {
                dba.ReInit();
                dba.AddParam(IDat.APWD0A01, t);
                dba.AddParam(IDat.APWD0A02, IDat.APWD0102);
                dba.AddParam(IDat.APWD0A03, IDat.APWD0103);
                dba.AddParam(IDat.APWD0A04, IDat.APWD0104);
                dba.AddParam(IDat.APWD0A05, IDat.APWD0105);
                dba.AddParam(IDat.APWD0A06, IDat.APWD0106);
                dba.AddParam(IDat.APWD0A07, IDat.APWD0107);
                dba.AddParam(IDat.APWD0A08, IDat.APWD0108);
                dba.AddParam(IDat.APWD0A09, IDat.APWD0109);
                dba.AddParam(IDat.APWD0A0A, IDat.APWD010A);
                dba.AddParam(IDat.APWD0A0B, IDat.APWD010B);
                dba.AddParam(IDat.APWD0A0C, IDat.APWD010C);
                dba.AddParam(IDat.APWD0A0D, IDat.APWD010D);
                dba.AddParam(IDat.APWD0A0E, IDat.APWD010E);
                dba.AddParam(IDat.APWD0A0F, IDat.APWD010F);
                dba.AddParam(IDat.APWD0A10, IDat.APWD0110);
                dba.AddParam(IDat.APWD0A11, IDat.APWD0111);
                dba.AddParam(IDat.APWD0A12, IDat.APWD0112);
                dba.AddWhere(IDat.APWD0104, _UserModel.Code);
                dba.AddWhere(IDat.APWD0105, _SafeModel.Key.Id);
                dba.AddBackupBatch(IDat.APWD0A00, IDat.APWD0100);

                dba.ReInit();
                dba.AddParam(IDat.APWD0B01, t);
                dba.AddParam(IDat.APWD0B02, IDat.APWD0201);
                dba.AddParam(IDat.APWD0B03, IDat.APWD0202);
                dba.AddParam(IDat.APWD0B04, IDat.APWD0203);
                dba.AddWhere(IDat.APWD0202, _SafeModel.Key.Id);
                dba.AddBackupBatch(IDat.APWD0B00, IDat.APWD0200);
            }
            #endregion

            #region 数据恢复
            dba.ReInit();
            dba.AddParam(IDat.APWD0102, _SafeModel.Key.Label);
            dba.AddParam(IDat.APWD0103, _SafeModel.Key.Major);
            dba.AddParam(IDat.APWD0106, _SafeModel.Key.CatId);
            dba.AddParam(IDat.APWD0107, _SafeModel.Key.RegDate);
            dba.AddParam(IDat.APWD0108, _SafeModel.Key.LibId);
            dba.AddParam(IDat.APWD0109, _SafeModel.Key.Title);
            dba.AddParam(IDat.APWD010A, _SafeModel.Key.MetaKey);
            dba.AddParam(IDat.APWD010B, _SafeModel.Key.IcoName);
            dba.AddParam(IDat.APWD010C, _SafeModel.Key.IcoPath);
            dba.AddParam(IDat.APWD010D, _SafeModel.Key.IcoMemo);
            dba.AddParam(IDat.APWD010E, _SafeModel.Key.GtdId);
            dba.AddParam(IDat.APWD010F, _SafeModel.Key.GtdMemo);
            dba.AddParam(IDat.APWD0110, _SafeModel.Key.Memo);
            dba.AddParam(IDat.APWD0112, _SafeModel.Key.CipherVer);
            dba.AddWhere(IDat.APWD0104, _UserModel.Code);
            dba.AddWhere(IDat.APWD0105, _Key.Id);
            dba.AddUpdateBatch();

            dba.ReInit();
            dba.AddTable(IDat.APWD0B00);
            dba.AddWhere(IDat.APWD0B03, _Key.Id);
            dba.AddDeleteBatch();

            dba.ReInit();
            dba.AddParam(IDat.APWD0201, IDat.APWD0B02);
            dba.AddParam(IDat.APWD0202, IDat.APWD0B03);
            dba.AddParam(IDat.APWD0203, IDat.APWD0B04);
            dba.AddParam(IDat.APWD0B01, log.Id.ToString());
            dba.AddWhere(IDat.APWD0B03, _Key.Id);
            dba.AddBackupBatch(IDat.APWD0200, IDat.APWD0B00);
            #endregion

            LbLog.Items.Insert(0, new Model.Log { Id = t });
        }

        private void BtClearCur_Click(object sender, EventArgs e)
        {
            Model.Log log = LbLog.SelectedItem as Model.Log;
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
            dba.AddTable(IDat.APWD0A00);
            dba.AddWhere(IDat.APWD0A01, log.Id.ToString());
            dba.AddWhere(IDat.APWD0A04, _UserModel.Code);
            dba.AddWhere(IDat.APWD0A05, _Key.Id);
            dba.AddDeleteBatch();

            dba.ReInit();
            dba.AddTable(IDat.APWD0B00);
            dba.AddWhere(IDat.APWD0B01, log.Id.ToString());
            dba.AddWhere(IDat.APWD0B03, _Key.Id);
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
            dba.AddTable(IDat.APWD0A00);
            dba.AddWhere(IDat.APWD0A04, _UserModel.Code);
            dba.AddWhere(IDat.APWD0A05, _Key.Id);
            dba.AddDeleteBatch();

            dba.ReInit();
            dba.AddTable(IDat.APWD0B00);
            dba.AddWhere(IDat.APWD0B03, _Key.Id);
            dba.AddDeleteBatch();

            dba.ExecuteBatch();
            LbLog.Items.Clear();
        }
    }
}
