using System;
using System.Windows.Forms;
using Me.Amon.Bean;
using Me.Amon.Bean.Att;
using Me.Amon.Model;

namespace Me.Amon.Pwd.Pro
{
    public partial class BeanGuid : UserControl, IAttEdit
    {
        private AAtt _Att;
        private SafeModel _SafeModel;
        private DataModel _DataModel;

        public BeanGuid()
        {
            InitializeComponent();
        }

        public BeanGuid(SafeModel safeModel)
        {
            _SafeModel = safeModel;

            InitializeComponent();
        }

        public void InitOnce(DataModel dataModel, ViewModel viewModel)
        {
            _DataModel = dataModel;

            BtOpt.Image = viewModel.GetImage("");
        }

        #region 接口实现
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
                    if (_SafeModel.Count < AAtt.HEAD_SIZE)
                    {
                        _SafeModel.InitMeta();
                        _SafeModel.InitLogo();
                        _SafeModel.InitHint();
                    }
                    _SafeModel.InitData(header);
                }
                _Att.Modified = true;
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
