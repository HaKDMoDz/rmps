using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Me.Amon.Pwd.M;

namespace Me.Amon.Pwd._Log
{
    public partial class LogViewer : Form
    {
        private APwd _APwd;
        private UserModel _UserModel;
        private SafeModel _SafeModel;
        private List<Att> _AttList;

        #region 构造函数
        public LogViewer()
        {
            InitializeComponent();
        }

        public LogViewer(APwd apwd)
        {
            _APwd = apwd;

            InitializeComponent();

            this.Icon = Me.Amon.Properties.Resources.Icon;
        }

        public void Init(UserModel userModel, SafeModel safeModel)
        {
            _UserModel = userModel;
            _SafeModel = safeModel;
            _AttList = new List<Att>();

            foreach (KeyLog log in _UserModel.DBA.ListKeyLog(_SafeModel.Key.Id))
            {
                LbLog.Items.Add(log);
            }
        }
        #endregion

        #region 事件处理
        private void LbLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyLog recLog = LbLog.SelectedItem as KeyLog;
            if (recLog == null)
            {
                return;
            }

            _AttList.Clear();
            _SafeModel.Decode(recLog.Password, recLog.CipherVer, _AttList);

            StringBuilder buffer = new StringBuilder();
            buffer.Append("时间：").Append(recLog.RegTime).Append(Environment.NewLine);
            buffer.Append("标题：").Append(recLog.Title).Append(Environment.NewLine);
            buffer.Append("搜索：").Append(recLog.MetaKey).Append(Environment.NewLine);
            buffer.Append("徽标：").Append(recLog.IcoName).Append(Environment.NewLine);
            buffer.Append("提醒：").Append(recLog.GtdMemo).Append(Environment.NewLine);
            Att temp;
            for (int i = Att.HEAD_SIZE; i < _AttList.Count; i += 1)
            {
                temp = _AttList[i];
                buffer.Append(temp.Text).Append("：").Append(temp.Data).Append(Environment.NewLine);
            }
            TbLog.Text = buffer.ToString();
        }

        private void BtResume_Click(object sender, EventArgs e)
        {
            KeyLog oldLog = LbLog.SelectedItem as KeyLog;
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

            KeyLog newLog = _SafeModel.Key.ToLog();
            _UserModel.DBA.SaveLog(newLog);

            _SafeModel.Key.FromLog(oldLog);
            _SafeModel.Decode();
            _APwd.ShowKey(_SafeModel.Key);
            _UserModel.DBA.SaveVcs(_SafeModel.Key);

            LbLog.Items.Insert(0, newLog);
        }

        private void BtClearCur_Click(object sender, EventArgs e)
        {
            KeyLog log = LbLog.SelectedItem as KeyLog;
            if (log == null)
            {
                MessageBox.Show("请选择您要恢复到的记录！");
                LbLog.Focus();
                return;
            }

            if (DialogResult.Yes != MessageBox.Show("确认要删除选中的历史信息么，此操作不可恢复？", "", MessageBoxButtons.YesNo))
            {
                return;
            }

            _UserModel.DBA.DeleteLog(log);
            LbLog.Items.Remove(log);
        }

        private void BtClearAll_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != MessageBox.Show("确认要删除此记录的所有历史信息吗，此操作将不可恢复？", "", MessageBoxButtons.YesNo))
            {
                return;
            }

            for (int i = LbLog.Items.Count - 1; i >= 0; i -= 1)
            {
                _UserModel.DBA.DeleteLog(LbLog.Items[i] as KeyLog);
                LbLog.Items.RemoveAt(i);
            }
        }
        #endregion
    }
}
