using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Pwd;
using Me.Amon.Event;
using Me.Amon.Model;
using Me.Amon.Model.Pwd;

namespace Me.Amon.Pwd.Pro
{
    public partial class APro : UserControl, IPwd
    {
        private APwd _APwd;
        private SafeModel _SafeModel;
        private DataModel _DataModel;
        private ViewModel _ViewModel;
        private int _LastIndex;
        private bool _UserAction;
        private Att _AAtt;
        private IAttEdit _CmpLast;
        private BeanInfo _CmpInfo;
        private Dictionary<int, IAttEdit> _CmpList;
        private DataTable _DataList;

        #region 构造函数
        public APro()
        {
            InitializeComponent();
        }

        public void Init(APwd apwd, SafeModel safeModel, DataModel dataModel, ViewModel viewModel)
        {
            _APwd = apwd;
            _SafeModel = safeModel;
            _DataModel = dataModel;
            _ViewModel = viewModel;
            _LastIndex = -1;

            _DataList = new DataTable();
            _DataList.Columns.Add("Order", typeof(string));
            _DataList.Columns.Add("Name", typeof(Att));
            OrderCol.DataPropertyName = "Order";
            ValueCol.DataPropertyName = "Name";
            GvAttList.AutoGenerateColumns = false;
            GvAttList.DataSource = _DataList;

            BtCopy.Image = viewModel.GetImage("att-copy");
            _APwd.ShowTips(BtCopy, "复制属性");
            BtSave.Image = viewModel.GetImage("att-save");
            _APwd.ShowTips(BtSave, "保存属性");
            BtDrop.Image = viewModel.GetImage("att-drop");
            _APwd.ShowTips(BtDrop, "移除属性");

            _CmpInfo = new BeanInfo();
            _CmpInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _CmpInfo.Location = new Point(6, 20);
            _CmpInfo.Size = new Size(347, 84);
            _CmpInfo.TabIndex = 0;
            GbGroup.Controls.Add(_CmpInfo);
            _CmpLast = _CmpInfo;

            _CmpList = new Dictionary<int, IAttEdit>(Att.TYPE_SIZE + 2);
        }
        #endregion

        #region 接口实现
        public void InitView(TableLayoutPanel grid)
        {
            grid.Controls.Add(this, 0, 1);
            Dock = DockStyle.Fill;
        }

        public void HideView(TableLayoutPanel grid)
        {
            grid.Controls.Remove(this);
        }

        public void ShowInfo()
        {
            _DataList.Rows.Clear();
            //GvAttList.DataSource = null;

            GbGroup.Controls.Remove(_CmpLast.Control);

            GbGroup.Text = _CmpInfo.Title;
            GbGroup.Controls.Add(_CmpInfo);
            _CmpInfo.ShowData(null);

            _CmpLast = _CmpInfo;
        }

        public void ShowData()
        {
            _UserAction = false;
            _DataList.Rows.Clear();
            Att att;
            for (int i = 0; i < _SafeModel.Count; i += 1)
            {
                att = _SafeModel.GetAtt(i);
                _DataList.Rows.Add(att.Order, att);
            }
            _UserAction = true;

            GvAttList.Rows[1].Selected = true;
        }

        public void AppendKey()
        {
            _UserAction = false;
            _SafeModel.Clear();
            _SafeModel.Key = new Key();

            _AAtt = _SafeModel.InitGuid();

            _DataList.Rows.Clear();
            _DataList.Rows.Add(_AAtt.Order, _AAtt);
            _LastIndex = 0;
            _UserAction = true;

            ShowView(_AAtt);
        }

        public bool UpdateKey()
        {
            _LastIndex = -1;
            _AAtt = null;
            return true;
        }

        public void DeleteKey()
        {
        }

        public void AppendAtt(int type)
        {
            if (type < Att.TYPE_TEXT || type > Att.TYPE_LINE)
            {
                return;
            }
            if (_SafeModel.Key == null || _SafeModel.Count < Att.HEAD_SIZE)
            {
                return;
            }
            if (GvAttList.SelectedRows.Count < 1)
            {
                return;
            }
            Att att = Att.GetInstance(type);
            int index = GvAttList.SelectedRows[0].Index;
            if (index < 0)
            {
                index = _SafeModel.Count;
            }
            else if (index < Att.HEAD_SIZE)
            {
                index = Att.HEAD_SIZE;
            }
            else
            {
                index += 1;
            }

            _UserAction = false;
            _SafeModel.Insert(index, att);
            DataRow row = _DataList.NewRow();
            row[0] = att.Order;
            row[1] = att;
            _DataList.Rows.InsertAt(row, index);
            _UserAction = true;
            _SafeModel.Modified = true;

            GvAttList.Rows[index].Selected = true;
        }

        public void UpdateAtt(int type)
        {
            if (type < Att.TYPE_TEXT || type > Att.TYPE_LINE || type == Att.TYPE_DATE)
            {
                return;
            }
            if (_SafeModel.Key == null || _SafeModel.Count < Att.HEAD_SIZE)
            {
                return;
            }
            if (GvAttList.SelectedRows.Count < 1)
            {
                return;
            }

            int index = GvAttList.SelectedRows[0].Index;
            if (index < Att.HEAD_SIZE)
            {
                return;
            }
            Att att = _SafeModel.GetAtt(index);
            if (att == null || att.Type >= Att.TYPE_GUID)
            {
                return;
            }
            att.Type = type;
            _SafeModel.Modified = true;

            ShowView(att);
        }

        public void CopyAtt()
        {
            _CmpLast.Copy();
        }

        public void SaveAtt()
        {
            if (!_CmpLast.Save())
            {
                return;
            }

            _UserAction = false;
            DataRow row = _DataList.Rows[_LastIndex];
            row[1] = _SafeModel.GetAtt(_LastIndex);
            _UserAction = true;

            if (!_SafeModel.IsUpdate && _LastIndex < _SafeModel.Count - 1)
            {
                _LastIndex += 1;
            }
            GvAttList.Rows[_LastIndex].Selected = true;
        }

        public void DropAtt()
        {
            if (_SafeModel.Key == null || _SafeModel.Count < Att.HEAD_SIZE)
            {
                return;
            }
            if (_LastIndex < Att.HEAD_SIZE || _AAtt == null)
            {
                return;
            }

            _UserAction = false;
            _SafeModel.Remove(_AAtt);
            _DataList.Rows.RemoveAt(_LastIndex);
            _UserAction = true;

            if (_LastIndex >= _SafeModel.Count)
            {
                _LastIndex = _SafeModel.Count - 1;
            }
            GvAttList.Rows[_LastIndex].Selected = true;
        }
        #endregion

        #region 公有函数
        public void ShowIcoSeeker(AmonHandler<Pwd.Ico> handler)
        {
            _APwd.ShowIcoSeeker(_DataModel.KeyDir, handler);
        }
        #endregion

        #region 界面事件
        private void GvAttList_SelectionChanged(object sender, System.EventArgs e)
        {
            if (!_UserAction || GvAttList.SelectedRows.Count < 1)
            {
                return;
            }

            _LastIndex = GvAttList.SelectedRows[0].Index;
            _AAtt = _SafeModel.GetAtt(_LastIndex);
            if (_AAtt == null)
            {
                return;
            }

            ShowView(_AAtt);
        }

        private void BtCopy_Click(object sender, EventArgs e)
        {
            CopyAtt();
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            SaveAtt();
        }

        private void BtDrop_Click(object sender, EventArgs e)
        {
            DropAtt();
        }
        #endregion

        #region 菜单事件
        #region 添加属性
        private void CmiAppendAttText_Click(object sender, EventArgs e)
        {
            AppendAtt(Att.TYPE_TEXT);
        }

        private void CmiAppendAttPass_Click(object sender, EventArgs e)
        {
            AppendAtt(Att.TYPE_PASS);
        }

        private void CmiAppendAttLink_Click(object sender, EventArgs e)
        {
            AppendAtt(Att.TYPE_LINK);
        }

        private void CmiAppendAttMail_Click(object sender, EventArgs e)
        {
            AppendAtt(Att.TYPE_MAIL);
        }

        private void CmiAppendAttDate_Click(object sender, EventArgs e)
        {
            AppendAtt(Att.TYPE_DATE);
        }

        private void CmiAppendAttData_Click(object sender, EventArgs e)
        {
            AppendAtt(Att.TYPE_DATA);
        }

        private void CmiAppendAttCall_Click(object sender, EventArgs e)
        {
            AppendAtt(Att.TYPE_CALL);
        }

        private void CmiAppendAttList_Click(object sender, EventArgs e)
        {
            AppendAtt(Att.TYPE_LIST);
        }

        private void CmiAppendAttMemo_Click(object sender, EventArgs e)
        {
            AppendAtt(Att.TYPE_MEMO);
        }

        private void CmiAppendAttFile_Click(object sender, EventArgs e)
        {
            AppendAtt(Att.TYPE_FILE);
        }

        private void CmiAppendAttLine_Click(object sender, EventArgs e)
        {
            AppendAtt(Att.TYPE_LINE);
        }
        #endregion

        #region 转换属性
        private void CmiUpdateAttText_Click(object sender, EventArgs e)
        {
            UpdateAtt(Att.TYPE_TEXT);
        }

        private void CmiUpdateAttPass_Click(object sender, EventArgs e)
        {
            UpdateAtt(Att.TYPE_PASS);
        }

        private void CmiUpdateAttLink_Click(object sender, EventArgs e)
        {
            UpdateAtt(Att.TYPE_LINK);
        }

        private void CmiUpdateAttMail_Click(object sender, EventArgs e)
        {
            UpdateAtt(Att.TYPE_MAIL);
        }

        private void CmiUpdateAttDate_Click(object sender, EventArgs e)
        {
            UpdateAtt(Att.TYPE_DATE);
        }

        private void CmiUpdateAttData_Click(object sender, EventArgs e)
        {
            UpdateAtt(Att.TYPE_DATA);
        }

        private void CmiUpdateAttCall_Click(object sender, EventArgs e)
        {
            UpdateAtt(Att.TYPE_CALL);
        }

        private void CmiUpdateAttList_Click(object sender, EventArgs e)
        {
            UpdateAtt(Att.TYPE_LIST);
        }

        private void CmiUpdateAttMemo_Click(object sender, EventArgs e)
        {
            UpdateAtt(Att.TYPE_MEMO);
        }

        private void CmiUpdateAttFile_Click(object sender, EventArgs e)
        {
            UpdateAtt(Att.TYPE_FILE);
        }

        private void CmiUpdateAttLine_Click(object sender, EventArgs e)
        {
            UpdateAtt(Att.TYPE_LINE);
        }
        #endregion

        private void CmiDeleteAtt_Click(object sender, EventArgs e)
        {
            DropAtt();
        }
        #endregion

        #region 私有函数
        private void ShowView(Att att)
        {
            if (_CmpLast != null)
            {
                GbGroup.Controls.Remove(_CmpLast.Control);
            }

            _CmpLast = GetCtl(att.Type);
            GbGroup.Text = _CmpLast.Title;
            GbGroup.Controls.Add(_CmpLast.Control);
            _CmpLast.ShowData(att);
        }

        private IAttEdit GetCtl(int type)
        {
            if (_CmpList.ContainsKey(type))
            {
                return _CmpList[type];
            }

            IAttEdit ctl;
            switch (type)
            {
                case Att.TYPE_TEXT:
                    ctl = new BeanText();
                    break;
                case Att.TYPE_PASS:
                    ctl = new BeanPass();
                    break;
                case Att.TYPE_LINK:
                    ctl = new BeanLink();
                    break;
                case Att.TYPE_MAIL:
                    ctl = new BeanMail();
                    break;
                case Att.TYPE_DATE:
                    ctl = new BeanDate();
                    break;
                case Att.TYPE_DATA:
                    ctl = new BeanData();
                    break;
                case Att.TYPE_CALL:
                    ctl = new BeanCall();
                    break;
                case Att.TYPE_LIST:
                    ctl = new BeanList();
                    break;
                case Att.TYPE_MEMO:
                    ctl = new BeanMemo();
                    break;
                case Att.TYPE_FILE:
                    ctl = new BeanFile();
                    break;
                case Att.TYPE_LINE:
                    ctl = new BeanLine();
                    break;
                case Att.TYPE_GUID:
                    ctl = new BeanGuid(_SafeModel, _DataList);
                    break;
                case Att.TYPE_META:
                    ctl = new BeanMeta();
                    break;
                case Att.TYPE_LOGO:
                    ctl = new BeanLogo(this);
                    break;
                case Att.TYPE_HINT:
                    ctl = new BeanHint();
                    break;
                default:
                    ctl = null;
                    break;
            }
            ctl.InitOnce(_DataModel, _ViewModel);
            _CmpList[type] = ctl;

            ctl.Control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ctl.Control.Location = new Point(6, 20);
            ctl.Control.Size = new Size(309, 84);
            ctl.Control.TabIndex = 0;

            return ctl;
        }
        #endregion
    }
}
