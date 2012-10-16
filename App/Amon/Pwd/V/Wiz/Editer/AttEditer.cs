using System;
using System.Windows.Forms;
using Me.Amon.C;
using Me.Amon.Pwd.M;

namespace Me.Amon.Pwd.V.Wiz.Editer
{
    public partial class AttEditer : Form
    {
        #region 全局变量
        private APwd _APwd;
        private IEditer _LastView;
        private BeanInfo _InfoBean;
        private BeanGuid _GuidBean;
        private BeanHead _HeadBean;
        private BeanBody _BodyBean;
        private UserModel _UserModel;
        private SafeModel _SafeModel;
        private DataModel _DataModel;
        private ViewModel _ViewModel;
        #endregion

        #region 构造函数
        public AttEditer()
        {
            InitializeComponent();
        }
        #endregion

        public void Init(APwd apwd, UserModel userModel, SafeModel safeModel, DataModel dataModel, ViewModel viewModel)
        {
            _APwd = apwd;
            _UserModel = userModel;
            _SafeModel = safeModel;
            _DataModel = dataModel;
            _ViewModel = viewModel;
        }

        #region 接口实现
        public ICatTree CatTree { get; set; }
        public IKeyList KeyList { get; set; }

        public void InitView(Panel panel)
        {
            if (_LastView != null)
            {
                _LastView.HideView();
            }

            _InfoBean = new BeanInfo();
            _InfoBean.Init(null, _DataModel);
            _InfoBean.InitView();
            _InfoBean.ShowData();

            panel.Controls.Add(this);
            Dock = DockStyle.Fill;

            _LastView = _InfoBean;
        }

        public void HideView(Panel panel)
        {
            panel.Controls.Remove(this);
        }

        public void ShowInfo()
        {
            if (_InfoBean == null)
            {
                _InfoBean = new BeanInfo();
                _InfoBean.Init(null, _DataModel);
            }
            if (_LastView != null && _LastView != _InfoBean)
            {
                _LastView.HideView();
                _InfoBean.InitView();
            }

            _LastView = _InfoBean;
            _LastView.ShowData();
        }

        public void ShowData()
        {
            ShowGuid();
        }

        public void AppendKey()
        {
            _SafeModel.Clear();
            _SafeModel.Key = new Key();

            _SafeModel.InitGuid();
            _SafeModel.InitMeta();
            _SafeModel.InitLogo();
            _SafeModel.InitHint();
            _SafeModel.InitAuto();

            ShowGuid();
            _LastView.Focus();
        }

        public bool UpdateKey()
        {
            if (_LastView == null)
            {
                return false;
            }
            return _LastView.SaveData();
        }

        public void DeleteKey()
        {
        }

        public void AppendAtt(int type)
        {
        }

        public void ChangeAtt(int type)
        {
        }

        public void SelectPrev()
        {
        }

        public void SelectNext()
        {
        }

        public void MoveUp()
        {
        }

        public void MoveDown()
        {
        }

        public void CutAtt()
        {
            if (_LastView != null)
            {
                _LastView.CutData();
            }
        }

        public void CopyAtt()
        {
            if (_LastView != null)
            {
                _LastView.CopyData();
            }
        }

        public void PasteAtt()
        {
            if (_LastView != null)
            {
                _LastView.PasteData();
            }
        }

        public void ClearAtt()
        {
            if (_LastView != null)
            {
                _LastView.ClearData();
            }
        }

        public void SaveAtt()
        {
        }

        public void DropAtt()
        {
        }
        #endregion

        #region 公共函数
        public void ShowTips(Control control, string caption)
        {
            _APwd.ShowTips(control, caption);
        }

        public void ShowIcoSeeker(string rootDir, AmonHandler<Png> handler)
        {
            _APwd.ShowIcoSeeker(rootDir, handler);
        }
        #endregion

        #region 事件处理
        private void BtPrev_Click(object sender, EventArgs e)
        {
            if (_LastView != null && !_LastView.SaveData())
            {
                return;
            }

            if (_LastView.Name == "body")
            {
                ShowHead();
                return;
            }

            ShowGuid();
        }

        private void BtNext_Click(object sender, EventArgs e)
        {
            if (_LastView != null && !_LastView.SaveData())
            {
                return;
            }

            if (_LastView.Name == "head")
            {
                ShowBody();
                return;
            }

            ShowHead();
        }
        #endregion

        #region 私有函数
        private void ShowGuid()
        {
            if (_GuidBean == null)
            {
                _GuidBean = new BeanGuid(null, _UserModel, _SafeModel);
                _GuidBean.Init(null, _DataModel, _ViewModel);
                _GuidBean.Name = "guid";
            }
            if (_LastView != null && _LastView != _GuidBean)
            {
                _LastView.HideView();
                _GuidBean.InitView();

                //BtPrev.Enabled = false;
                //BtNext.Enabled = true;
            }

            _LastView = _GuidBean;
            _LastView.ShowData();
        }

        private void ShowHead()
        {
            if (_HeadBean == null)
            {
                //_HeadBean = new BeanHead(this, _UserModel, _SafeModel);
                //_HeadBean.Init(PlMain, _DataModel, _ViewModel);
                _HeadBean.Name = "head";
            }
            if (_LastView != null && _LastView != _HeadBean)
            {
                _LastView.HideView();
                _HeadBean.InitView();

                //BtPrev.Enabled = true;
                //BtNext.Enabled = true;
            }

            _LastView = _HeadBean;
            _LastView.ShowData();
        }

        private void ShowBody()
        {
            if (_BodyBean == null)
            {
                //_BodyBean = new BeanBody(this, _UserModel, _SafeModel);
                //_BodyBean.Init(PlMain, _DataModel, _ViewModel);
                _BodyBean.Name = "body";
            }
            if (_LastView != null && _LastView != _BodyBean)
            {
                _LastView.HideView();
                _BodyBean.InitView();

                //BtPrev.Enabled = true;
                //BtNext.Enabled = false;
            }

            _LastView = _BodyBean;
            _LastView.ShowData();
        }
        #endregion
    }
}
