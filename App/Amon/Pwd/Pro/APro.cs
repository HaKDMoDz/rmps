using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Bean;
using Me.Amon.Model;

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
        private AAtt _AAtt;
        private IAttEdit _CmpLast;
        private BeanInfo _CmpInfo;
        private Dictionary<int, IAttEdit> _CmpList;

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

            GvAttList.AutoGenerateColumns = false;
            OrderCol.DataPropertyName = "Order";
            ValueCol.DataPropertyName = "Name";

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

            _CmpList = new Dictionary<int, IAttEdit>(AAtt.TYPE_SIZE + 2);
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
            GvAttList.DataSource = null;

            GbGroup.Controls.Remove(_CmpLast.Control);

            GbGroup.Text = _CmpInfo.Title;
            GbGroup.Controls.Add(_CmpInfo);
            _CmpInfo.ShowData(null);

            _CmpLast = _CmpInfo;
        }

        public void ShowData()
        {
            GvAttList.DataSource = null;

            _UserAction = false;
            _SafeModel.BindTo(GvAttList);
            _UserAction = true;

            GvAttList.Rows[1].Selected = true;
        }

        public void AppendKey()
        {
            _UserAction = false;
            _SafeModel.Clear();
            _SafeModel.Key.SetDefault();
            _AAtt = _SafeModel.InitGuid();
            GvAttList.DataSource = null;
            _SafeModel.BindTo(GvAttList);
            _UserAction = true;

            ShowView(_AAtt);
        }

        public bool UpdateKey()
        {
            return true;
        }

        public void DeleteKey()
        {
        }

        public void AppendAtt(int type)
        {
            if (type < AAtt.TYPE_TEXT || type > AAtt.TYPE_LINE)
            {
                return;
            }
            if (_SafeModel.Key == null || _SafeModel.Count < AAtt.HEAD_SIZE)
            {
                return;
            }
            if (GvAttList.SelectedRows.Count < 1)
            {
                return;
            }
            AAtt att = AAtt.GetInstance(type);
            int index = GvAttList.SelectedRows[0].Index;
            if (index < 0)
            {
                index = _SafeModel.Count;
            }
            else if (index < AAtt.HEAD_SIZE)
            {
                index = AAtt.HEAD_SIZE;
            }
            else
            {
                index += 1;
            }
            _UserAction = false;
            _SafeModel.Insert(index, att);
            GvAttList.DataSource = null;
            _SafeModel.BindTo(GvAttList);
            _UserAction = true;
            _SafeModel.Key.Modified = true;

            GvAttList.Rows[index].Selected = true;
        }

        public void UpdateAtt(int type)
        {
            if (type < AAtt.TYPE_TEXT || type > AAtt.TYPE_LINE)
            {
                return;
            }
            if (_SafeModel.Key == null || _SafeModel.Count < AAtt.HEAD_SIZE)
            {
                return;
            }
            if (GvAttList.SelectedRows.Count < 1)
            {
                return;
            }
            AAtt att = GvAttList.SelectedRows[0].DataBoundItem as AAtt;
            if (att == null || att.Type >= AAtt.TYPE_GUID)
            {
                return;
            }
            att.Type = type;
            _SafeModel.Key.Modified = true;

            ShowView(att);
        }

        public void CopyAtt()
        {
            _CmpLast.Copy();
        }

        public void SaveAtt()
        {
            _UserAction = false;
            _CmpLast.Save();
            GvAttList.DataSource = null;
            _SafeModel.BindTo(GvAttList);
            _UserAction = true;

            if (!_SafeModel.Key.IsUpdate && _LastIndex < _SafeModel.Count - 1)
            {
                _LastIndex += 1;
            }
            GvAttList.Rows[_LastIndex].Selected = true;
        }

        public void DropAtt()
        {
            _UserAction = false;
            _SafeModel.Remove(_AAtt);
            GvAttList.DataSource = null;
            _SafeModel.BindTo(GvAttList);
            _UserAction = true;

            if (_LastIndex >= _SafeModel.Count)
            {
                _LastIndex = _SafeModel.Count - 1;
            }
            GvAttList.Rows[_LastIndex].Selected = true;
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
            AppendAtt(AAtt.TYPE_TEXT);
        }

        private void CmiAppendAttPass_Click(object sender, EventArgs e)
        {
            AppendAtt(AAtt.TYPE_PASS);
        }

        private void CmiAppendAttLink_Click(object sender, EventArgs e)
        {
            AppendAtt(AAtt.TYPE_LINK);
        }

        private void CmiAppendAttMail_Click(object sender, EventArgs e)
        {
            AppendAtt(AAtt.TYPE_MAIL);
        }

        private void CmiAppendAttDate_Click(object sender, EventArgs e)
        {
            AppendAtt(AAtt.TYPE_DATE);
        }

        private void CmiAppendAttData_Click(object sender, EventArgs e)
        {
            AppendAtt(AAtt.TYPE_DATA);
        }

        private void CmiAppendAttList_Click(object sender, EventArgs e)
        {
            AppendAtt(AAtt.TYPE_LIST);
        }

        private void CmiAppendAttMemo_Click(object sender, EventArgs e)
        {
            AppendAtt(AAtt.TYPE_MEMO);
        }

        private void CmiAppendAttFile_Click(object sender, EventArgs e)
        {
            AppendAtt(AAtt.TYPE_FILE);
        }

        private void CmiAppendAttLine_Click(object sender, EventArgs e)
        {
            AppendAtt(AAtt.TYPE_LINE);
        }
        #endregion

        #region 转换属性
        private void CmiUpdateAttText_Click(object sender, EventArgs e)
        {
            UpdateAtt(AAtt.TYPE_TEXT);
        }

        private void CmiUpdateAttPass_Click(object sender, EventArgs e)
        {
            UpdateAtt(AAtt.TYPE_PASS);
        }

        private void CmiUpdateAttLink_Click(object sender, EventArgs e)
        {
            UpdateAtt(AAtt.TYPE_LINK);
        }

        private void CmiUpdateAttMail_Click(object sender, EventArgs e)
        {
            UpdateAtt(AAtt.TYPE_MAIL);
        }

        private void CmiUpdateAttDate_Click(object sender, EventArgs e)
        {
            UpdateAtt(AAtt.TYPE_DATE);
        }

        private void CmiUpdateAttData_Click(object sender, EventArgs e)
        {
            UpdateAtt(AAtt.TYPE_DATA);
        }

        private void CmiUpdateAttList_Click(object sender, EventArgs e)
        {
            UpdateAtt(AAtt.TYPE_LIST);
        }

        private void CmiUpdateAttMemo_Click(object sender, EventArgs e)
        {
            UpdateAtt(AAtt.TYPE_MEMO);
        }

        private void CmiUpdateAttFile_Click(object sender, EventArgs e)
        {
            UpdateAtt(AAtt.TYPE_FILE);
        }

        private void CmiUpdateAttLine_Click(object sender, EventArgs e)
        {
            UpdateAtt(AAtt.TYPE_LINE);
        }
        #endregion

        private void CmiDeleteAtt_Click(object sender, EventArgs e)
        {
            DropAtt();
        }
        #endregion

        #region 私有函数
        private void ShowView(AAtt att)
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
                case AAtt.TYPE_TEXT:
                    ctl = new BeanText();
                    break;
                case AAtt.TYPE_PASS:
                    ctl = new BeanPass();
                    break;
                case AAtt.TYPE_LINK:
                    ctl = new BeanLink();
                    break;
                case AAtt.TYPE_MAIL:
                    ctl = new BeanMail();
                    break;
                case AAtt.TYPE_DATE:
                    ctl = new BeanDate();
                    break;
                case AAtt.TYPE_DATA:
                    ctl = new BeanData();
                    break;
                case AAtt.TYPE_LIST:
                    ctl = new BeanList();
                    break;
                case AAtt.TYPE_MEMO:
                    ctl = new BeanMemo();
                    break;
                case AAtt.TYPE_FILE:
                    ctl = new BeanFile();
                    break;
                case AAtt.TYPE_LINE:
                    ctl = new BeanLine();
                    break;
                case AAtt.TYPE_GUID:
                    ctl = new BeanGuid(_SafeModel);
                    break;
                case AAtt.TYPE_META:
                    ctl = new BeanMeta();
                    break;
                case AAtt.TYPE_LOGO:
                    ctl = new BeanLogo();
                    break;
                case AAtt.TYPE_HINT:
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
