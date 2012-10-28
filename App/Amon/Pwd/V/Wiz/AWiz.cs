using System;
using System.Windows.Forms;
using Me.Amon.C;
using Me.Amon.Pwd.M;
using Me.Amon.Pwd.V.Wiz.Editer;

namespace Me.Amon.Pwd.V.Wiz
{
    public partial class AWiz : UserControl, IPwd
    {
        private WPwd _WPwd;
        private UserModel _UserModel;
        private SafeModel _SafeModel;
        private DataModel _DataModel;
        private ViewModel _ViewModel;
        private IKeyEditer _LastView;
        private Panel TpGrid;
        private KeyGuid _GuidBean;
        private KeyHead _HeadBean;
        private KeyBody _BodyBean;

        #region
        public AWiz()
        {
            InitializeComponent();
        }

        public void Init(WPwd wPwd, UserModel userModel, SafeModel safeModel, DataModel dataModel, ViewModel viewModel)
        {
            _WPwd = wPwd;
            _UserModel = userModel;
            _SafeModel = safeModel;
            _DataModel = dataModel;
            _ViewModel = viewModel;
        }
        #endregion

        public void FillData()
        {
            _WPwd.FillData();
        }

        public void FillData(string data)
        {
            _WPwd.FillData(data);
        }

        public void ShowHint(string hints)
        {
            _WPwd.ShowHint(hints);
        }

        #region 接口实现
        public void InitView(Panel panel)
        {
            Dock = DockStyle.Fill;
            panel.Controls.Add(this);
            Dock = DockStyle.Fill;
        }

        public void HideView(Panel panel)
        {
            panel.Controls.Remove(this);
        }

        public void ShowInfo()
        {
            throw new System.NotImplementedException();
        }

        public void ShowData()
        {
            throw new System.NotImplementedException();
        }

        public void AppendKey()
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateKey()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteKey()
        {
            throw new System.NotImplementedException();
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
        }

        public void CopyAtt()
        {
        }

        public void PasteAtt()
        {
        }

        public void ClearAtt()
        {
        }

        public void SaveAtt()
        {
        }

        public void DropAtt()
        {
        }

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
                _GuidBean = new KeyGuid();
                _GuidBean.Init(this, _UserModel, _SafeModel, _DataModel, _ViewModel);
                _GuidBean.Name = "guid";
            }
            if (_LastView != null && _LastView != _GuidBean)
            {
                _LastView.HideView();
                _GuidBean.InitView();

                BtPrevStep.Enabled = false;
                BtNextStep.Enabled = true;
            }

            _LastView = _GuidBean;
            _LastView.ShowData();
        }

        private void ShowHead()
        {
            if (_HeadBean == null)
            {
                _HeadBean = new KeyHead(this, _UserModel, _SafeModel);
                _HeadBean.Init(TpGrid, _DataModel, _ViewModel);
                _HeadBean.Name = "head";
            }
            if (_LastView != null && _LastView != _HeadBean)
            {
                _LastView.HideView();
                _HeadBean.InitView();

                BtPrevStep.Enabled = true;
                BtNextStep.Enabled = true;
            }

            _LastView = _HeadBean;
            _LastView.ShowData();
        }

        private void ShowBody()
        {
            if (_BodyBean == null)
            {
                _BodyBean = new KeyBody(this, _UserModel, _SafeModel);
                _BodyBean.Init(TpGrid, _DataModel, _ViewModel);
                _BodyBean.Name = "body";
            }
            if (_LastView != null && _LastView != _BodyBean)
            {
                _LastView.HideView();
                _BodyBean.InitView();

                BtPrevStep.Enabled = true;
                BtNextStep.Enabled = false;
            }

            _LastView = _BodyBean;
            _LastView.ShowData();
        }
        #endregion
        #endregion
    }
}
