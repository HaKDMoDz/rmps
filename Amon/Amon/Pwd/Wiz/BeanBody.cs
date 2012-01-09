using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Me.Amon.Model;

namespace Me.Amon.Pwd.Wiz
{
    public partial class BeanBody : UserControl
    {
        public BeanBody()
        {
            InitializeComponent();
        }
        public void ShowData()
        {
            Controls.Clear();

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

                IWizEdit ctl = GetCmp(att.Type);
                ctl.InitView(LayoutRoot, row);
                ctl.ShowData(att);

                row += 1;
            }
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

            for (int i = AAtt.HEAD_SIZE; i < _SafeModel.Count; i += 1)
            {
                AAtt att = _SafeModel.GetAtt(i);
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

        public IWizEdit EditCtl { get; set; }

        private IWizEdit GetCmp(int type)
        {
            if (!_IdxList.ContainsKey(type))
            {
                _IdxList.Add(type, 0);
                _CmpList.Add(type, new List<IWizEdit>());
            }
            int index = _IdxList[type];
            List<IWizEdit> list = _CmpList[type];

            IWizEdit ctl;
            if (list.Count <= index)
            {
                switch (type)
                {
                    case AAtt.TYPE_TEXT:
                        ctl = new BeanText(this);
                        break;
                    case AAtt.TYPE_PASS:
                        ctl = new BeanPass(this);
                        break;
                    case AAtt.TYPE_LINK:
                        ctl = new BeanLink(this);
                        break;
                    case AAtt.TYPE_MAIL:
                        ctl = new BeanMail(this);
                        break;
                    case AAtt.TYPE_DATE:
                        ctl = new BeanDate(this);
                        break;
                    case AAtt.TYPE_DATA:
                        ctl = new BeanData(this);
                        break;
                    case AAtt.TYPE_LIST:
                        ctl = new BeanList(this);
                        break;
                    case AAtt.TYPE_AREA:
                        ctl = new BeanArea(this);
                        break;
                    case AAtt.TYPE_FILE:
                        ctl = new BeanFile(this);
                        break;
                    case AAtt.TYPE_SIGN:
                        ctl = new BeanSign(this);
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
        private Dictionary<int, List<IWizEdit>> _CmpList = new Dictionary<int, List<IWizEdit>>(AAtt.TYPE_SIZE);
    }
}
