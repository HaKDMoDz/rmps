using System;
using System.Windows.Forms;
using Me.Amon.Event;
using Me.Amon.Model;
using Me.Amon.Model.Pwd;

namespace Me.Amon.Pwd.V.Wiz
{
    public partial class AWiz : UserControl, IPwd
    {
        private APwd _APwd;
        private IWizView _LastView;
        private BeanInfo _InfoBean;
        private BeanGuid _GuidBean;
        private BeanHead _HeadBean;
        private BeanBody _BodyBean;
        private SafeModel _SafeModel;
        private DataModel _DataModel;
        private ViewModel _ViewModel;

        public AWiz()
        {
            InitializeComponent();
        }

        public void Init(APwd apwd, SafeModel safeModel, DataModel dataModel, ViewModel viewModel)
        {
            _APwd = apwd;
            _SafeModel = safeModel;
            _DataModel = dataModel;
            _ViewModel = viewModel;
        }

        #region 接口实现
        public void InitView(Panel panel)
        {
            _InfoBean = new BeanInfo();
            _InfoBean.Init(_DataModel);
            _InfoBean.InitView(TpGrid);
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
                _InfoBean.Init(_DataModel);
            }
            if (_LastView != null && _LastView != _InfoBean)
            {
                _LastView.HideView(TpGrid);
                _InfoBean.InitView(TpGrid);
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

        public void UpdateAtt(int type)
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

        public void ShowIcoSeeker(string rootDir, AmonHandler<Pwd.Ico> handler)
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

        private void BtCopy_Click(object sender, EventArgs e)
        {
            if (_LastView != null)
            {
                _LastView.CopyData();
            }
        }
        #endregion

        #region 私有函数
        private void ShowGuid()
        {
            if (_GuidBean == null)
            {
                _GuidBean = new BeanGuid(this, _SafeModel);
                _GuidBean.Init(_DataModel, _ViewModel);
                _GuidBean.Name = "guid";
            }
            if (_LastView != null && _LastView != _GuidBean)
            {
                _LastView.HideView(TpGrid);
                _GuidBean.InitView(TpGrid);

                BtPrev.Visible = false;
                BtNext.Visible = true;
            }

            _LastView = _GuidBean;
            _LastView.ShowData();
        }

        private void ShowHead()
        {
            if (_HeadBean == null)
            {
                _HeadBean = new BeanHead(this, _SafeModel);
                _HeadBean.Init(_DataModel, _ViewModel);
                _HeadBean.Name = "head";
            }
            if (_LastView != null && _LastView != _HeadBean)
            {
                _LastView.HideView(TpGrid);
                _HeadBean.InitView(TpGrid);

                BtPrev.Visible = true;
                BtNext.Visible = true;
            }

            _LastView = _HeadBean;
            _LastView.ShowData();
        }

        private void ShowBody()
        {
            if (_BodyBean == null)
            {
                _BodyBean = new BeanBody(_SafeModel);
                _BodyBean.Init(_DataModel, _ViewModel);
                _BodyBean.Name = "body";
            }
            if (_LastView != null && _LastView != _BodyBean)
            {
                _LastView.HideView(TpGrid);
                _BodyBean.InitView(TpGrid);

                BtPrev.Visible = true;
                BtNext.Visible = false;
            }

            _LastView = _BodyBean;
            _LastView.ShowData();
        }
        #endregion
    }
}
