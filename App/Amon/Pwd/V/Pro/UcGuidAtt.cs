using System.Data;
using System.Windows.Forms;
using Me.Amon.Pwd.M;
using Me.Amon.Util;

namespace Me.Amon.Pwd.V.Pro
{
    public partial class UcGuidAtt : UserControl, IAttEditer
    {
        private WPro _APro;
        private Att _Att;
        private SafeModel _SafeModel;
        private DataModel _DataModel;
        private DataTable _DataTable;
        private Lib _DefLib;

        #region 构造函数
        public UcGuidAtt()
        {
            InitializeComponent();
        }

        public UcGuidAtt(WPro aPro, SafeModel safeModel, DataTable dataTable)
        {
            _APro = aPro;
            _SafeModel = safeModel;
            _DataTable = dataTable;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void InitOnce(DataModel dataModel, ViewModel viewModel)
        {
            _DataModel = dataModel;
            _DefLib = new Lib { Id = "", Text = "请选择", Target = "", Script = "" };
        }

        public Control Control { get { return this; } }

        public string Title { get { return "向导"; } }

        public bool ShowData(Att att)
        {
            if ((_DataModel.LibModified & CPwd.KEY_APRO) > 0)
            {
                CbName.Items.Clear();
                CbName.Items.Add(_DefLib);
                foreach (Lib header in _DataModel.LibList)
                {
                    CbName.Items.Add(header);
                }
                _DataModel.LibModified &= ~CPwd.KEY_APRO;
            }

            _Att = att;

            CbName.SelectedItem = new Lib { Id = _Att.Data ?? "" };
            return true;
        }

        public new bool Focus()
        {
            return CbName.Focus();
        }

        public void Cut()
        {
        }

        public void Copy(CopyType type)
        {
        }

        public void Paste()
        {
        }

        public void Clear()
        {
        }

        public bool Save()
        {
            Lib header = CbName.SelectedItem as Lib;
            if (header == null || !CharUtil.IsValidateHash(header.Id))
            {
                Main.ShowAlert("请选择您要使用的模板！");
                CbName.Focus();
                return false;
            }

            if (header.Id != _Att.Data)
            {
                _Att.Data = header.Id;
                if (!_SafeModel.IsUpdate)
                {
                    Att att;
                    if (_SafeModel.Count < Att.HEAD_SIZE)
                    {
                        att = _SafeModel.InitMeta();
                        _DataTable.Rows.Add(att.Order, att);
                        att = _SafeModel.InitLogo();
                        _DataTable.Rows.Add(att.Order, att);
                        att = _SafeModel.InitHint();
                        _DataTable.Rows.Add(att.Order, att);
                        att = _SafeModel.InitAuto();
                        _DataTable.Rows.Add(att.Order, att);
                    }
                    _SafeModel.InitData(header);
                    for (int i = _DataTable.Rows.Count - 1; i >= Att.HEAD_SIZE; i -= 1)
                    {
                        _DataTable.Rows.RemoveAt(i);
                    }
                    for (int i = Att.HEAD_SIZE; i < _SafeModel.Count; i += 1)
                    {
                        att = _SafeModel.GetAtt(i);
                        _DataTable.Rows.Add(att.Order, att);
                    }
                }
                _Att.Modified = true;
            }

            return true;
        }
        #endregion
    }
}
