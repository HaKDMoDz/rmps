using System.Collections.Generic;
using System.Windows.Controls;
using Me.Amon.Apwd.Model;

namespace Me.Amon.Apwd.Win.Wiz
{
    public partial class BodyCmp : UserControl, ICardCtl
    {
        private Awiz _Mwiz;
        private SafeModel _SafeModel;

        public BodyCmp()
        {
            InitializeComponent();
        }

        public BodyCmp(Awiz mwiz, SafeModel safeModel)
        {
            _Mwiz = mwiz;
            _SafeModel = safeModel;

            InitializeComponent();
        }

        #region
        public void InitView(Grid grid)
        {
            //grid.Children.Add(this);
            //SetValue(Grid.RowProperty, 0);
            //SetValue(Grid.ColumnProperty, 0);
        }

        public void HideView(Grid grid)
        {
            //grid.Children.Remove(this);
        }

        public void ShowData()
        {
            LayoutRoot.RowDefinitions.Clear();
            LayoutRoot.Children.Clear();

            for (int i = 0; i < Att.TYPE_SIZE - Att.HEAD_SIZE; i += 1)
            {
                if (_IdxList.ContainsKey(i))
                {
                    _IdxList[i] = 0;
                }
            }

            int row = 0;
            for (int i = Att.HEAD_SIZE; i < _SafeModel.Count; i += 1)
            {
                Att att = _SafeModel.GetAtt(i);

                IEditCtl ctl = GetCmp(att.Type);
                ctl.InitView(LayoutRoot, row);
                ctl.ShowData(att);

                row += 1;
            }
            LayoutRoot.RowDefinitions.Add(new RowDefinition());
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

            for (int i = Att.HEAD_SIZE; i < _SafeModel.Count; i += 1)
            {
                Att att = _SafeModel.GetAtt(i);
                GetCmp(att.Type).Save();
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
        #endregion

        public IEditCtl EditCtl { get; set; }

        private IEditCtl GetCmp(int type)
        {
            if (!_IdxList.ContainsKey(type))
            {
                _IdxList.Add(type, 0);
                _CmpList.Add(type, new List<IEditCtl>());
            }
            int index = _IdxList[type];
            List<IEditCtl> list = _CmpList[type];

            IEditCtl ctl;
            if (list.Count <= index)
            {
                switch (type)
                {
                    case Att.TYPE_TEXT:
                        ctl = new TextCmp(this);
                        break;
                    case Att.TYPE_PASS:
                        ctl = new PassCmp(this);
                        break;
                    case Att.TYPE_LINK:
                        ctl = new LinkCmp(this);
                        break;
                    case Att.TYPE_MAIL:
                        ctl = new MailCmp(this);
                        break;
                    case Att.TYPE_DATE:
                        ctl = new DateCmp(this);
                        break;
                    case Att.TYPE_DATA:
                        ctl = new DataCmp(this);
                        break;
                    case Att.TYPE_LIST:
                        ctl = new ListCmp(this);
                        break;
                    case Att.TYPE_AREA:
                        ctl = new AreaCmp(this);
                        break;
                    case Att.TYPE_FILE:
                        ctl = new FileCmp(this);
                        break;
                    case Att.TYPE_SIGN:
                        ctl = new SignCmp(this);
                        break;
                    default:
                        ctl = null;
                        break;
                }
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
        private Dictionary<int, List<IEditCtl>> _CmpList = new Dictionary<int, List<IEditCtl>>(Att.TYPE_SIZE);
    }
}
