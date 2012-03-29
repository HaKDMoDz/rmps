using System.Collections.Generic;
using System.Windows.Forms;
using Me.Amon.Bean;
using Me.Amon.Model;
using Me.Amon.Model.Pwd;

namespace Me.Amon.Pwd.Wiz
{
    public partial class BeanBody : UserControl, IWizView
    {
        private SafeModel _SafeModel;
        private DataModel _DataModel;
        private ViewModel _ViewModel;

        public BeanBody()
        {
            InitializeComponent();
        }

        public BeanBody(SafeModel safeModel)
        {
            _SafeModel = safeModel;

            InitializeComponent();
        }

        public void Init(DataModel dataModel, ViewModel viewModel)
        {
            _DataModel = dataModel;
            _ViewModel = viewModel;
        }

        public void InitView(TableLayoutPanel grid)
        {
            grid.Controls.Add(this, 0, 0);
            Dock = DockStyle.Fill;
            TabIndex = 0;
            grid.RowStyles[1].Height = 32;
        }

        public void HideView(TableLayoutPanel grid)
        {
            grid.Controls.Remove(this);
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

                IAttEdit ctl = GetCtl(att.Type);
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

        public void CopyData()
        {
            if (EditCtl != null)
            {
                EditCtl.Copy();
            }
        }

        public IAttEdit EditCtl { get; set; }

        private IAttEdit GetCtl(int type)
        {
            if (!_IdxList.ContainsKey(type))
            {
                _IdxList.Add(type, 0);
                _CmpList.Add(type, new List<IAttEdit>());
            }
            int index = _IdxList[type];
            List<IAttEdit> list = _CmpList[type];

            IAttEdit ctl;
            if (list.Count <= index)
            {
                switch (type)
                {
                    case Att.TYPE_TEXT:
                        ctl = new BeanText(this);
                        break;
                    case Att.TYPE_PASS:
                        ctl = new BeanPass(this);
                        break;
                    case Att.TYPE_LINK:
                        ctl = new BeanLink(this);
                        break;
                    case Att.TYPE_MAIL:
                        ctl = new BeanMail(this);
                        break;
                    case Att.TYPE_DATE:
                        ctl = new BeanDate(this);
                        break;
                    case Att.TYPE_DATA:
                        ctl = new BeanData(this);
                        break;
                    case Att.TYPE_CALL:
                        ctl = new BeanCall(this);
                        break;
                    case Att.TYPE_LIST:
                        ctl = new BeanList(this);
                        break;
                    case Att.TYPE_MEMO:
                        ctl = new BeanMemo(this);
                        break;
                    case Att.TYPE_FILE:
                        ctl = new BeanFile(this);
                        break;
                    case Att.TYPE_LINE:
                        ctl = new BeanLine(this);
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

        private Dictionary<int, int> _IdxList = new Dictionary<int, int>();
        private Dictionary<int, List<IAttEdit>> _CmpList = new Dictionary<int, List<IAttEdit>>(Att.TYPE_SIZE);
    }
}
