using System;
using System.Windows.Forms;
using Me.Amon.C;
using Me.Amon.Pwd.M;

namespace Me.Amon.Pwd.V.Wiz.Editer
{
    public partial class AttEditer : Form
    {
        #region 全局变量
        private WPwd _WPwd;
        private IKeyEditer _LastView;
        private KeyHead _HeadBean;
        private KeyBody _BodyBean;
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

        public void Init(WPwd wPwd, UserModel userModel, SafeModel safeModel, DataModel dataModel, ViewModel viewModel)
        {
            _WPwd = wPwd;
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
                _LastView.HideView(PlMain);
            }

            _HeadBean = new KeyHead();
            _HeadBean.Init(_DataModel, _ViewModel);
            _HeadBean.InitView(PlMain);
            _HeadBean.ShowData();

            panel.Controls.Add(this);
            Dock = DockStyle.Fill;

            _LastView = _HeadBean;
        }

        public void HideView(Panel panel)
        {
            panel.Controls.Remove(this);
        }

        public void ShowData()
        {
            ShowHead();
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

            ShowHead();
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

        public void CopyAtt(CopyType type)
        {
            if (_LastView != null)
            {
                _LastView.CopyData(type);
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
            _WPwd.ShowTips(control, caption);
        }

        public void ShowIcoSeeker(string rootDir, AmonHandler<Png> handler)
        {
            _WPwd.ShowIcoSeeker(rootDir, handler);
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

            ShowHead();
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
                _LastView.HideView(PlMain);
                _HeadBean.InitView(PlMain);

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
                _LastView.HideView(PlMain);
                _BodyBean.InitView(PlMain);

                //BtPrev.Enabled = true;
                //BtNext.Enabled = false;
            }

            _LastView = _BodyBean;
            _LastView.ShowData();
        }
        #endregion

        private void BtStep_Click(object sender, EventArgs e)
        {

        }

        private void BtOk_Click(object sender, EventArgs e)
        {

        }

        private void BtNo_Click(object sender, EventArgs e)
        {

        }
    }
}
