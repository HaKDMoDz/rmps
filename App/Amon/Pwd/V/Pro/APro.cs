using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Me.Amon.C;
using Me.Amon.M;
using Me.Amon.Pwd._Att;
using Me.Amon.Pwd.M;
using Me.Amon.Util;

namespace Me.Amon.Pwd.V.Pro
{
    public partial class APro : UserControl, IPwd
    {
        private WPwd _WPwd;
        private SafeModel _SafeModel;
        private DataModel _DataModel;
        private ViewModel _ViewModel;
        private int _LastIndex;
        private bool _UserAction;
        private Att _AAtt;
        private IAttEditer _CmpLast;
        private Dictionary<int, IAttEditer> _CmpList;
        private DataTable _DataList;

        #region 构造函数
        public APro()
        {
            InitializeComponent();
        }

        public void Init(WPwd wPwd, SafeModel safeModel, DataModel dataModel, ViewModel viewModel)
        {
            _WPwd = wPwd;
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

            _CmpList = new Dictionary<int, IAttEditer>(Att.TYPE_SIZE + 2);

            BtSave.Image = _ViewModel.GetImage("att-save");
            _WPwd.ShowTips(BtSave, "保存属性");

            BtDrop.Image = _ViewModel.GetImage("att-drop");
            _WPwd.ShowTips(BtDrop, "移除属性");
        }
        #endregion

        #region 接口实现
        public void InitView(Panel panel)
        {
            panel.Controls.Add(this);
            Dock = DockStyle.Fill;
        }

        public void HideView(Panel panel)
        {
            panel.Controls.Remove(this);
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
            MetaAtt meta = _SafeModel.Meta;
            if (string.IsNullOrWhiteSpace(meta.Text))
            {
                Main.ShowAlert("请输入记录标题！");
                GvAttList.Rows[1].Selected = true;
                return false;
            }

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

            SelectRow(index);
        }

        public void ChangeAtt(int type)
        {
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
            Att att = _SafeModel.ChangeType(index, type);
            if (att == null)
            {
                return;
            }
            _SafeModel.Modified = true;

            ShowView(att);
        }

        public void SelectPrev()
        {
            if (_SafeModel.Key == null || _SafeModel.Count < Att.HEAD_SIZE)
            {
                return;
            }
            if (GvAttList.SelectedRows.Count < 1)
            {
                return;
            }
            int index = GvAttList.SelectedRows[0].Index;
            if (index <= 0)
            {
                return;
            }

            index -= 1;
            SelectRow(index);
            ShowView(_SafeModel.GetAtt(index));
        }

        public void SelectNext()
        {
            if (_SafeModel.Key == null || _SafeModel.Count < Att.HEAD_SIZE)
            {
                return;
            }
            if (GvAttList.SelectedRows.Count < 1)
            {
                return;
            }
            int index = GvAttList.SelectedRows[0].Index;
            if (index >= _SafeModel.Count - 1)
            {
                return;
            }

            index += 1;
            SelectRow(index);
            ShowView(_SafeModel.GetAtt(index));
        }

        public void MoveUp()
        {
            if (_SafeModel.Key == null || _SafeModel.Count < Att.HEAD_SIZE)
            {
                return;
            }
            if (GvAttList.SelectedRows.Count < 1)
            {
                return;
            }
            int i0 = GvAttList.SelectedRows[0].Index;
            if (i0 <= Att.HEAD_SIZE)
            {
                return;
            }
            int i1 = i0 - 1;
            _SafeModel.ChangeOrder(i0, i1);
            _DataList.Rows[i0][1] = _SafeModel.GetAtt(i0);
            _DataList.Rows[i1][1] = _SafeModel.GetAtt(i1);
            SelectRow(i1);
        }

        public void MoveDown()
        {
            if (_SafeModel.Key == null || _SafeModel.Count < Att.HEAD_SIZE)
            {
                return;
            }
            if (GvAttList.SelectedRows.Count < 1)
            {
                return;
            }
            int i0 = GvAttList.SelectedRows[0].Index;
            if (i0 >= _SafeModel.Count - 1)
            {
                return;
            }
            int i1 = i0 + 1;
            _SafeModel.ChangeOrder(i0, i1);
            _DataList.Rows[i0][1] = _SafeModel.GetAtt(i0);
            _DataList.Rows[i1][1] = _SafeModel.GetAtt(i1);
            SelectRow(i1);
        }

        public void CutAtt()
        {
            _CmpLast.Cut();
        }

        public void CopyAtt()
        {
            _CmpLast.Copy();
        }

        public void PasteAtt()
        {
            _CmpLast.Paste();
        }

        public void ClearAtt()
        {
            _CmpLast.Clear();
        }

        public void SaveAtt()
        {
            if (!_CmpLast.Save())
            {
                return;
            }
            _SafeModel.Modified |= _AAtt.Modified;

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

        public void FillAtt()
        {
        }

        public Cat SelectedCat
        {
            get;
            set;
        }
        #endregion

        #region 公有函数
        public void ShowIcoSeeker(AmonHandler<Png> handler)
        {
            _WPwd.ShowIcoSeeker(_DataModel.KeyDir, handler);
        }

        public void SelectRow(int row)
        {
            GvAttList.Rows[row].Selected = true;
            GvAttList.FirstDisplayedScrollingRowIndex = row < 1 ? row : row - 1;
        }

        public void ShowTips(Control control, string caption)
        {
            _WPwd.ShowTips(control, caption);
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

        private void BtOpt1_Click(object sender, EventArgs e)
        {
            if (_SafeModel.EditMode)
            {
                SaveAtt();
            }
            else
            {
                CopyAtt();
            }
        }

        private void BtOpt2_Click(object sender, EventArgs e)
        {
            if (_SafeModel.EditMode)
            {
                DropAtt();
            }
            else
            {
                FillAtt();
            }
        }
        #endregion

        #region 选单事件
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
            ChangeAtt(Att.TYPE_TEXT);
        }

        private void CmiUpdateAttPass_Click(object sender, EventArgs e)
        {
            ChangeAtt(Att.TYPE_PASS);
        }

        private void CmiUpdateAttLink_Click(object sender, EventArgs e)
        {
            ChangeAtt(Att.TYPE_LINK);
        }

        private void CmiUpdateAttMail_Click(object sender, EventArgs e)
        {
            ChangeAtt(Att.TYPE_MAIL);
        }

        private void CmiUpdateAttDate_Click(object sender, EventArgs e)
        {
            ChangeAtt(Att.TYPE_DATE);
        }

        private void CmiUpdateAttData_Click(object sender, EventArgs e)
        {
            ChangeAtt(Att.TYPE_DATA);
        }

        private void CmiUpdateAttCall_Click(object sender, EventArgs e)
        {
            ChangeAtt(Att.TYPE_CALL);
        }

        private void CmiUpdateAttList_Click(object sender, EventArgs e)
        {
            ChangeAtt(Att.TYPE_LIST);
        }

        private void CmiUpdateAttMemo_Click(object sender, EventArgs e)
        {
            ChangeAtt(Att.TYPE_MEMO);
        }

        private void CmiUpdateAttFile_Click(object sender, EventArgs e)
        {
            ChangeAtt(Att.TYPE_FILE);
        }

        private void CmiUpdateAttLine_Click(object sender, EventArgs e)
        {
            ChangeAtt(Att.TYPE_LINE);
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

        private IAttEditer GetCtl(int type)
        {
            if (_CmpList.ContainsKey(type))
            {
                return _CmpList[type];
            }

            IAttEditer ctl;
            switch (type)
            {
                case Att.TYPE_TEXT:
                    ctl = new UcTextAtt(this);
                    break;
                case Att.TYPE_PASS:
                    ctl = new UcPassAtt(this);
                    break;
                case Att.TYPE_LINK:
                    ctl = new UcLinkAtt(this);
                    break;
                case Att.TYPE_MAIL:
                    ctl = new UcMailAtt(this);
                    break;
                case Att.TYPE_DATE:
                    ctl = new UcDateAtt(this);
                    break;
                case Att.TYPE_DATA:
                    ctl = new UcDataAtt(this);
                    break;
                case Att.TYPE_CALL:
                    ctl = new UcCallAtt(this);
                    break;
                case Att.TYPE_LIST:
                    ctl = new UcListAtt(this);
                    break;
                case Att.TYPE_MEMO:
                    ctl = new UcMemoAtt(this);
                    break;
                case Att.TYPE_FILE:
                    ctl = new UcFileAtt(this);
                    break;
                case Att.TYPE_LINE:
                    ctl = new UcLineAtt(this);
                    break;
                case Att.TYPE_GUID:
                    ctl = new UcGuidAtt(this, _SafeModel, _DataList);
                    break;
                case Att.TYPE_META:
                    ctl = new UcMetaAtt(this);
                    break;
                case Att.TYPE_LOGO:
                    ctl = new UcLogoAtt(this);
                    break;
                case Att.TYPE_HINT:
                    ctl = new UcHintAtt(this);
                    break;
                case Att.TYPE_AUTO:
                    ctl = new UcAutoAtt(this);
                    break;
                default:
                    ctl = null;
                    break;
            }
            ctl.InitOnce(_DataModel, _ViewModel);
            _CmpList[type] = ctl;

            ctl.Control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ctl.Control.Location = new Point(6, 20);
            ctl.Control.Size = new Size(GbGroup.Width - 42, 84);
            ctl.Control.TabIndex = 0;

            return ctl;
        }
        #endregion

        private void GvAttList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    if (!GvAttList.Rows[e.RowIndex].Selected)
                    {
                        GvAttList.ClearSelection();
                        GvAttList.Rows[e.RowIndex].Selected = true;
                    }
                    //CmAtt.Show(MousePosition);
                }
            }
        }
    }
}
