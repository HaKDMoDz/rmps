﻿using System.Collections.Generic;
using System.Windows.Forms;
using Me.Amon.Pwd.M;

namespace Me.Amon.Pwd.V.Wiz.Viewer
{
    public partial class KeyBody : UserControl, IKeyViewer
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

        public void Init(WWiz aWiz, UserModel userModel, SafeModel safeModel, DataModel dataModel, ViewModel viewModel)
        {
            _AWiz = aWiz;
            _UserModel = userModel;
            _SafeModel = safeModel;
            _DataModel = dataModel;
            _ViewModel = viewModel;
        }
        #endregion

        #region 接口实现
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

                IAttViewer ctl = GetCtl(att.Type);
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

        public void CopyData()
        {
            if (EditCtl != null)
            {
                EditCtl.Copy();
            }
        }
        #endregion

        #region 公共函数
        public IAttViewer EditCtl { get; set; }

        private IAttViewer GetCtl(int type)
        {
            if (!_IdxList.ContainsKey(type))
            {
                _IdxList.Add(type, 0);
                _CmpList.Add(type, new List<IAttViewer>());
            }
            int index = _IdxList[type];
            List<IAttViewer> list = _CmpList[type];

            IAttViewer ctl;
            if (list.Count <= index)
            {
                switch (type)
                {
                    case Att.TYPE_TEXT:
                        ctl = new AttText(this);
                        break;
                    case Att.TYPE_PASS:
                        ctl = new AttPass(this, _UserModel);
                        break;
                    case Att.TYPE_LINK:
                        ctl = new AttLink(this);
                        break;
                    case Att.TYPE_MAIL:
                        ctl = new AttMail(this);
                        break;
                    case Att.TYPE_DATE:
                        ctl = new AttDate(this);
                        break;
                    case Att.TYPE_DATA:
                        ctl = new AttData(this);
                        break;
                    case Att.TYPE_CALL:
                        ctl = new AttCall(this);
                        break;
                    case Att.TYPE_LIST:
                        ctl = new AttList(this);
                        break;
                    case Att.TYPE_MEMO:
                        ctl = new AttMemo(this);
                        break;
                    case Att.TYPE_FILE:
                        ctl = new AttFile(this);
                        break;
                    case Att.TYPE_LINE:
                        ctl = new AttLine(this);
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

        public void FillData(string data)
        {
            _AWiz.FillData(data);
        }

        public void ShowTips(Control control, string caption)
        {
            _AWiz.ShowTips(control, caption);
        }
        #endregion

        private Dictionary<int, int> _IdxList = new Dictionary<int, int>();
        private Dictionary<int, List<IAttViewer>> _CmpList = new Dictionary<int, List<IAttViewer>>(Att.TYPE_SIZE);
    }
}
