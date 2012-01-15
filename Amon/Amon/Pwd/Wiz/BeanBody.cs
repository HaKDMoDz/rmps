using System.Collections.Generic;
using System.Windows.Forms;
using Me.Amon.Model;

namespace Me.Amon.Pwd.Wiz
{
    public partial class BeanBody : UserControl, IWizView
    {
        private SafeModel _SafeModel;
        private RowStyle _DefStyle;
        private Label _DefLabel;

        public BeanBody()
        {
            InitializeComponent();
        }

        public BeanBody(SafeModel safeModel)
        {
            _SafeModel = safeModel;

            InitializeComponent();
        }

        public void Init(DataModel dataModel)
        {
            _DefStyle = new RowStyle(SizeType.Percent, 100F);

            _DefLabel = new Label { Dock = DockStyle.Fill };
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

                IAttEdit ctl = GetCtl(att.Type);
                ctl.InitView(row);
                ctl.ShowData(att);

                row += 1;
            }

            TpGrid.RowStyles.Add(_DefStyle);
            TpGrid.RowCount = row;

            TpGrid.Controls.Add(_DefLabel, 1, row);
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
                    case AAtt.TYPE_TEXT:
                        ctl = new BeanText(this, TpGrid);
                        break;
                    case AAtt.TYPE_PASS:
                        ctl = new BeanPass(this, TpGrid);
                        break;
                    case AAtt.TYPE_LINK:
                        ctl = new BeanLink(this, TpGrid);
                        break;
                    case AAtt.TYPE_MAIL:
                        ctl = new BeanMail(this, TpGrid);
                        break;
                    case AAtt.TYPE_DATE:
                        ctl = new BeanDate(this, TpGrid);
                        break;
                    case AAtt.TYPE_DATA:
                        ctl = new BeanData(this, TpGrid);
                        break;
                    case AAtt.TYPE_LIST:
                        ctl = new BeanList(this, TpGrid);
                        break;
                    case AAtt.TYPE_MEMO:
                        ctl = new BeanMemo(this, TpGrid);
                        break;
                    case AAtt.TYPE_FILE:
                        ctl = new BeanFile(this, TpGrid);
                        break;
                    case AAtt.TYPE_LINE:
                        ctl = new BeanLine(this, TpGrid);
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
        private Dictionary<int, List<IAttEdit>> _CmpList = new Dictionary<int, List<IAttEdit>>(AAtt.TYPE_SIZE);
    }
}
