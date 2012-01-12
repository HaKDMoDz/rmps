using System.Collections.Generic;
using System.Windows.Forms;
using Me.Amon.Model;

namespace Me.Amon.Pwd.Wiz
{
    public partial class BeanBody : UserControl, IWizView
    {
        private SafeModel _SafeModel;
        private RowStyle _DefStyle;

        public BeanBody()
        {
            InitializeComponent();

            _DefStyle = new RowStyle(SizeType.Percent, 100F);
        }

        public BeanBody(SafeModel safeModel)
        {
            _SafeModel = safeModel;
            _DefStyle = new RowStyle(SizeType.Percent, 100F);

            InitializeComponent();
        }

        public void Init(DataModel dataModel)
        {
        }

        public void InitView(TableLayoutPanel grid)
        {
            grid.Controls.Add(this, 0, 0);
            Dock = DockStyle.Fill;
            grid.RowStyles[1].Height = 32;
        }

        public void HideView(TableLayoutPanel grid)
        {
            grid.Controls.Remove(this);
        }

        public void ShowData()
        {
            TpGrid.Controls.Clear();
            TpGrid.RowStyles.Clear();

            for (int i = 0; i < AAtt.TYPE_SIZE - AAtt.HEAD_SIZE; i += 1)
            {
                if (_IdxList.ContainsKey(i))
                {
                    _IdxList[i] = 0;
                }
            }

            int row = 0;
            for (int i = AAtt.HEAD_SIZE; i < _SafeModel.Count; i += 1)
            {
                AAtt att = _SafeModel.GetAtt(i);

                IRecEdit ctl = GetCtl(att.Type);
                ctl.InitView(row);
                ctl.ShowData(att);

                row += 1;
            }

            TpGrid.RowStyles.Add(_DefStyle);
        }

        public bool SaveData()
        {
            for (int i = 0; i < AAtt.TYPE_SIZE - AAtt.HEAD_SIZE; i += 1)
            {
                if (_IdxList.ContainsKey(i))
                {
                    _IdxList[i] = 0;
                }
            }

            _SafeModel.Key.Modified = false;
            for (int i = AAtt.HEAD_SIZE; i < _SafeModel.Count; i += 1)
            {
                AAtt att = _SafeModel.GetAtt(i);
                if (!GetCtl(att.Type).Save())
                {
                    return false;
                }
                _SafeModel.Key.Modified |= att.Modified;
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

        public IRecEdit EditCtl { get; set; }

        private IRecEdit GetCtl(int type)
        {
            if (!_IdxList.ContainsKey(type))
            {
                _IdxList.Add(type, 0);
                _CmpList.Add(type, new List<IRecEdit>());
            }
            int index = _IdxList[type];
            List<IRecEdit> list = _CmpList[type];

            IRecEdit ctl;
            if (list.Count <= index)
            {
                switch (type)
                {
                    case AAtt.TYPE_TEXT:
                        ctl = new BeanText(TpGrid);
                        break;
                    case AAtt.TYPE_PASS:
                        ctl = new BeanPass(TpGrid);
                        break;
                    case AAtt.TYPE_LINK:
                        ctl = new BeanLink(TpGrid);
                        break;
                    case AAtt.TYPE_MAIL:
                        ctl = new BeanMail(TpGrid);
                        break;
                    case AAtt.TYPE_DATE:
                        ctl = new BeanDate(TpGrid);
                        break;
                    case AAtt.TYPE_DATA:
                        ctl = new BeanData(TpGrid);
                        break;
                    case AAtt.TYPE_LIST:
                        ctl = new BeanList(TpGrid);
                        break;
                    case AAtt.TYPE_AREA:
                        ctl = new BeanArea(TpGrid);
                        break;
                    case AAtt.TYPE_FILE:
                        ctl = new BeanFile(TpGrid);
                        break;
                    case AAtt.TYPE_SIGN:
                        ctl = new BeanSign(TpGrid);
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
        private Dictionary<int, List<IRecEdit>> _CmpList = new Dictionary<int, List<IRecEdit>>(AAtt.TYPE_SIZE);
    }
}
