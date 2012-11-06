using System.Collections.Generic;
using System.Windows.Forms;
using Me.Amon.Pwd.M;

namespace Me.Amon.Pwd.V.Wiz.Editer
{
    public partial class KeyBody : UserControl, IKeyEditer
    {
        #region 全局变量
        private WWiz _AWiz;
        private UserModel _UserModel;
        private SafeModel _SafeModel;
        private DataModel _DataModel;
        private ViewModel _ViewModel;
        #endregion

        #region 构造函数
        public KeyBody()
        {
            InitializeComponent();
        }

        public KeyBody(WWiz awiz, UserModel userModel, SafeModel safeModel)
        {
            _AWiz = awiz;
            _UserModel = userModel;
            _SafeModel = safeModel;

            InitializeComponent();
        }

        public void Init(DataModel dataModel, ViewModel viewModel)
        {
            _DataModel = dataModel;
            _ViewModel = viewModel;
        }
        #endregion

        #region 接口实现
        public void InitView(Panel panel)
        {
            panel.Controls.Add(this);
            Dock = DockStyle.Fill;
            TabIndex = 0;
        }

        public void HideView(Panel panel)
        {
            panel.Controls.Remove(this);
        }

        public void ShowData()
        {
            SuspendLayout();
            TpGrid.SuspendLayout();

            TpGrid.Controls.Clear();
            TpGrid.RowStyles.Clear();

            for (int i = 0; i < Att.TYPE_SIZE - Att.HEAD_SIZE; i += 1)
            {
                if (_IdxList.ContainsKey(i))
                {
                    _IdxList[i] = 0;
                }
            }

            int row = 0;
            int max = 0;
            for (int i = Att.HEAD_SIZE; i < _SafeModel.Count; i += 1)
            {
                Att att = _SafeModel.GetAtt(i);

                IAttEditer ctl = GetCtl(att.Type);
                max += ctl.InitView(row);
                ctl.ShowData(_DataModel, att);

                row += 1;
            }

            TpGrid.Height = max;
            TpGrid.RowCount = row;
            TpGrid.ResumeLayout(true);
            ResumeLayout(true);

            Focus();
        }

        public bool SaveData()
        {
            for (int i = 0; i < Att.TYPE_SIZE - Att.HEAD_SIZE; i += 1)
            {
                if (_IdxList.ContainsKey(i))
                {
                    _IdxList[i] = 0;
                }
            }

            _SafeModel.Modified = false;
            for (int i = Att.HEAD_SIZE; i < _SafeModel.Count; i += 1)
            {
                Att att = _SafeModel.GetAtt(i);
                if (!GetCtl(att.Type).Save())
                {
                    return false;
                }
                _SafeModel.Modified |= att.Modified;
            }
            return true;
        }

        public void CutData()
        {
            if (EditCtl != null)
            {
                EditCtl.Cut();
            }
        }

        public void CopyData()
        {
            if (EditCtl != null)
            {
                EditCtl.Copy();
            }
        }

        public void PasteData()
        {
            if (EditCtl != null)
            {
                EditCtl.Paste();
            }
        }

        public void ClearData()
        {
            if (EditCtl != null)
            {
                EditCtl.Clear();
            }
        }
        #endregion

        #region 公共函数
        public IAttEditer EditCtl { get; set; }

        private IAttEditer GetCtl(int type)
        {
            if (!_IdxList.ContainsKey(type))
            {
                _IdxList.Add(type, 0);
                _CmpList.Add(type, new List<IAttEditer>());
            }
            int index = _IdxList[type];
            List<IAttEditer> list = _CmpList[type];

            IAttEditer ctl;
            if (list.Count <= index)
            {
                switch (type)
                {
                    case Att.TYPE_TEXT:
                        ctl = new UcTextAtt(this);
                        break;
                    case Att.TYPE_PASS:
                        ctl = new UcPassAtt(this, _UserModel);
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
                    default:
                        ctl = null;
                        break;
                }
                ctl.InitOnce(TpGrid, _ViewModel);
                list.Add(ctl);
            }
            else
            {
                ctl = list[index];
            }

            _IdxList[type] = ++index;
            return ctl;
        }

        public void ShowTips(Control control, string caption)
        {
            _AWiz.ShowTips(control, caption);
        }
        #endregion

        private Dictionary<int, int> _IdxList = new Dictionary<int, int>();
        private Dictionary<int, List<IAttEditer>> _CmpList = new Dictionary<int, List<IAttEditer>>(Att.TYPE_SIZE);
    }
}
