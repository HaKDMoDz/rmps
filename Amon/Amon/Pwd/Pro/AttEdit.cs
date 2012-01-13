using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Model;

namespace Me.Amon.Pwd.Pro
{
    public partial class AttEdit : UserControl
    {
        private APro _APro;
        private IAttEdit _CmpLast;
        private BeanInfo _CmpInfo;
        private Dictionary<int, IAttEdit> _CmpList;

        public AttEdit()
        {
            InitializeComponent();
        }

        public AttEdit(APro apro)
        {
            _APro = apro;

            InitializeComponent();
        }

        public void Init()
        {
            _CmpList = new Dictionary<int, IAttEdit>(AAtt.TYPE_SIZE + 2);

            ShowInfo();
        }

        private void BtCopy_Click(object sender, EventArgs e)
        {
            _CmpLast.Copy();
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            _CmpLast.Save();
        }

        private void BtDrop_Click(object sender, EventArgs e)
        {
            _APro.DeleteAtt();
        }

        public void ShowInfo()
        {
            _CmpInfo = new BeanInfo();
            _CmpInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _CmpInfo.Location = new Point(6, 19);
            _CmpInfo.Size = new Size(347, 94);
            _CmpLast = _CmpInfo;
        }

        public void ShowView(IAttEdit recEdit)
        {
            GbGroup.Controls.Remove(_CmpLast.Control);
            _CmpLast = recEdit;
            GbGroup.Controls.Add(_CmpLast.Control);
        }

        private IAttEdit GetCtl(int type)
        {
            if (_CmpList.ContainsKey(type))
            {
                return _CmpList[type];
            }

            IAttEdit ctl;
            switch (type)
            {
                case AAtt.TYPE_TEXT:
                    ctl = new BeanText();
                    break;
                case AAtt.TYPE_PASS:
                    ctl = new BeanPass();
                    break;
                case AAtt.TYPE_LINK:
                    ctl = new BeanLink();
                    break;
                case AAtt.TYPE_MAIL:
                    ctl = new BeanMail();
                    break;
                case AAtt.TYPE_DATE:
                    ctl = new BeanDate();
                    break;
                case AAtt.TYPE_DATA:
                    ctl = new BeanData();
                    break;
                case AAtt.TYPE_LIST:
                    ctl = new BeanList();
                    break;
                case AAtt.TYPE_MEMO:
                    ctl = new BeanMemo();
                    break;
                case AAtt.TYPE_FILE:
                    ctl = new BeanFile();
                    break;
                case AAtt.TYPE_LINE:
                    ctl = new BeanLine();
                    break;
                case AAtt.TYPE_GUID:
                    ctl = new BeanGuid();
                    break;
                case AAtt.TYPE_META:
                    ctl = new BeanMeta();
                    break;
                case AAtt.TYPE_LOGO:
                    ctl = new BeanLogo();
                    break;
                case AAtt.TYPE_HINT:
                    ctl = new BeanHint();
                    break;
                default:
                    ctl = null;
                    break;
            }
            _CmpList[type] = ctl;

            ctl.Control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ctl.Control.Location = new Point(6, 20);
            ctl.Control.Size = new Size(347, 84);

            return ctl;
        }
    }
}
