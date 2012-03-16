using System;
using System.Windows.Forms;
using Me.Amon.Bean;
using Me.Amon.Bean.Att;
using Me.Amon.Model;
using System.Data;

namespace Me.Amon.Pwd.Pro
{
    public partial class BeanGuid : UserControl, IAttEdit
    {
        private AAtt _Att;
        private SafeModel _SafeModel;
        private DataModel _DataModel;
        private DataTable _DataTable;

        #region 构造函数
        public BeanGuid()
        {
            InitializeComponent();
        }

        public BeanGuid(SafeModel safeModel, DataTable dataTable)
        {
            _SafeModel = safeModel;
            _DataTable = dataTable;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void InitOnce(DataModel dataModel, ViewModel viewModel)
        {
            _DataModel = dataModel;

            BtOpt.Image = viewModel.GetImage("");
        }

        public Control Control { get { return this; } }

        public string Title { get { return "向导"; } }

        public bool ShowData(AAtt att)
        {
            if ((_DataModel.LibModified & IEnv.KEY_APWD) > 0)
            {
                CbName.DataSource = null;
                CbName.DataSource = _DataModel.LibList;
                CbName.DisplayMember = "Name";
                CbName.ValueMember = "Id";
                _DataModel.LibModified &= ~IEnv.KEY_APWD;
            }

            _Att = att;

            CbName.Focus();
            return true;
        }

        public void Copy()
        {
        }

        public void Save()
        {
            LibHeader header = CbName.SelectedItem as LibHeader;
            if (header == null || header.Id == "0")
            {
                return;
            }

            if (header.Id != _Att.GetSpec(GuidAtt.SPEC_GUID_TPLT))
            {
                _Att.SetSpec(GuidAtt.SPEC_GUID_TPLT, header.Id);
                if (!_SafeModel.Key.IsUpdate)
                {
                    AAtt att;
                    if (_SafeModel.Count < AAtt.HEAD_SIZE)
                    {
                        att = _SafeModel.InitMeta();
                        _DataTable.Rows.Add(att.Order, att);
                        att = _SafeModel.InitLogo();
                        _DataTable.Rows.Add(att.Order, att);
                        att = _SafeModel.InitHint();
                        _DataTable.Rows.Add(att.Order, att);
                    }
                    _SafeModel.InitData(header);
                    for (int i = _DataTable.Rows.Count - 1; i >= AAtt.HEAD_SIZE; i -= 1)
                    {
                        _DataTable.Rows.RemoveAt(i);
                    }
                    for (int i = AAtt.HEAD_SIZE; i < _SafeModel.Count; i += 1)
                    {
                        att = _SafeModel.GetAtt(i);
                        _DataTable.Rows.Add(att.Order, att);
                    }
                }
                _Att.Modified = true;
            }
        }
        #endregion

        #region 事件处理
        private void button1_Click(object sender, EventArgs e)
        {
        }
        #endregion
    }
}
