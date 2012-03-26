using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Me.Amon.Bean;
using Me.Amon.Model;
using Me.Amon.Model.Pwd;

namespace Me.Amon.Pwd._Log
{
    public partial class LogEdit : Form
    {
        private APwd _APwd;
        private UserModel _UserModel;
        private SafeModel _SafeModel;
        private List<AAtt> _AttList;

        #region 构造函数
        public LogEdit()
        {
            InitializeComponent();
        }

        public LogEdit(APwd apwd)
        {
            _APwd = apwd;

            InitializeComponent();
        }

        public void Init(UserModel userModel, SafeModel safeModel)
        {
            _UserModel = userModel;
            _SafeModel = safeModel;
            _AttList = new List<AAtt>();

            foreach (RecLog log in _UserModel.DBObject.ListRecLog(_SafeModel.Rec.Id))
            {
                LbLog.Items.Add(log);
            }
        }
        #endregion

        #region 事件处理
        private void LbLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecLog log = LbLog.SelectedItem as RecLog;
            if (log == null)
            {
                return;
            }

            RecLog recLog = _UserModel.DBObject.ReadRecLog(log.Id);
            if (recLog == null)
            {
                return;
            }

            _AttList.Clear();
            _SafeModel.Decode(recLog.UserData, recLog.CipherVer, _AttList);

            StringBuilder buffer = new StringBuilder();
            buffer.Append("时间：").Append(recLog.RegTime).Append(Environment.NewLine);
            buffer.Append("标题：").Append(recLog.Title).Append(Environment.NewLine);
            buffer.Append("搜索：").Append(recLog.MetaKey).Append(Environment.NewLine);
            buffer.Append("徽标：").Append(recLog.IcoName).Append(Environment.NewLine);
            buffer.Append("提醒：").Append(recLog.GtdMemo).Append(Environment.NewLine);
            AAtt temp;
            for (int i = AAtt.HEAD_SIZE; i < _AttList.Count; i += 1)
            {
                temp = _AttList[i];
                buffer.Append(temp.Name).Append("：").Append(temp.Data).Append(Environment.NewLine);
            }
            TbLog.Text = buffer.ToString();
        }

        private void BtResume_Click(object sender, EventArgs e)
        {
            RecLog oldLog = LbLog.SelectedItem as RecLog;
            if (oldLog == null)
            {
                MessageBox.Show("请选择您要恢复到的记录！");
                LbLog.Focus();
                return;
            }

            if (DialogResult.Yes != MessageBox.Show("为了确保您的数据安全，此操作仅复制一份选中的数据为最新数据，\n确认要执行此操作么？", "", MessageBoxButtons.YesNo))
            {
                return;
            }

            RecLog newLog = _SafeModel.Rec.ToLog();
            newLog.UserData = _SafeModel.Key.Data;
            _UserModel.DBObject.SaveLog(newLog);

            _SafeModel.Rec.FromLog(oldLog);
            _SafeModel.Key.Data = oldLog.UserData;
            _SafeModel.Decode(_SafeModel.Key, _SafeModel.Rec.CipherVer);
            _APwd.ShowRec(_SafeModel.Rec);

            LbLog.Items.Insert(0, newLog);
        }

        private void BtClearCur_Click(object sender, EventArgs e)
        {
            RecLog log = LbLog.SelectedItem as RecLog;
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

            _UserModel.DBObject.DeleteLog(log);
            LbLog.Items.Remove(log);
        }

        private void BtClearAll_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK != MessageBox.Show("确认要删除此记录的所有历史信息吗，此操作将不可恢复？", "", MessageBoxButtons.YesNo))
            {
                return;
            }

            foreach (object obj in LbLog.Items)
            {
                _UserModel.DBObject.DeleteLog(obj as RecLog);
                LbLog.Items.Remove(obj);
            }
        }
        #endregion
    }
}
