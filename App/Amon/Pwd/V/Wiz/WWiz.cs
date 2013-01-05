using System;
using System.Windows.Forms;
using Me.Amon.C;
using Me.Amon.Pwd.M;
using Me.Amon.Pwd.V.Wiz.Editer;

namespace Me.Amon.Pwd.V.Wiz
{
    public partial class WWiz : UserControl, IPwd
    {
        private WPwd _WPwd;
        private UserModel _UserModel;
        private SafeModel _SafeModel;
        private DataModel _DataModel;
        private ViewModel _ViewModel;
        private IKeyEditer _LastView;
        private Panel TpGrid;
        private KeyGuid _KeyGuid;
        private KeyHead _KeyHead;
        private KeyBody _KeyBody;

        #region
        public WWiz()
        {
            InitializeComponent();
        }

        public WWiz(WPwd wPwd, UserModel userModel, SafeModel safeModel)
        {
            _WPwd = wPwd;
            _UserModel = userModel;
            _SafeModel = safeModel;

            InitializeComponent();
        }

        public void Init(DataModel dataModel, ViewModel viewModel)
        {
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
        }

        #region 接口实现
        public string Model { get; set; }

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

            ShowHead();
        }

        public bool UpdateKey()
        {
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

            if (_LastView.Name == "body")
            {
                if (DialogResult.Yes == Main.ShowConfirm("确认要保存数据吗？"))
                {
                    _WPwd.SaveKey();
                }
                return;
            }
            if (_LastView.Name == "head")
            {
                ShowBody();
                return;
            }

            ShowHead();
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            _WPwd.ShowInfo();
            _SafeModel.Key = null;
            _SafeModel.Modified = false;
        }
        #endregion

        #region 私有函数
        private void ShowGuid()
        {
            if (_KeyGuid == null)
            {
                _KeyGuid = new KeyGuid(this, _UserModel, _SafeModel);
                _KeyGuid.Init(_DataModel, _ViewModel);
                _KeyGuid.Name = "guid";
                _KeyGuid.InitView(PlMain);
            }

            if (_LastView != null && _LastView != _KeyGuid)
            {
                _LastView.HideView(PlMain);
                _KeyGuid.InitView(PlMain);

                BtPrevStep.Enabled = false;
                BtNextStep.Enabled = true;
                BtNextStep.Text = "下一步(&N)";
            }

            _LastView = _KeyGuid;
            _LastView.ShowData();
        }

        private void ShowHead()
        {
            if (_KeyHead == null)
            {
                _KeyHead = new KeyHead(this, _UserModel, _SafeModel);
                _KeyHead.Init(_DataModel, _ViewModel);
                _KeyHead.Name = "head";
                _KeyHead.InitView(PlMain);
            }

            if (_LastView != null && _LastView != _KeyHead)
            {
                _LastView.HideView(PlMain);
                _KeyHead.InitView(PlMain);

                BtPrevStep.Enabled = true;
                BtNextStep.Text = "下一步(&N)";
            }

            _LastView = _KeyHead;
            _LastView.ShowData();
        }

        private void ShowBody()
        {
            if (_KeyBody == null)
            {
                _KeyBody = new KeyBody(this, _UserModel, _SafeModel);
                _KeyBody.Init(_DataModel, _ViewModel);
                _KeyBody.Name = "body";
                _KeyBody.InitView(PlMain);
            }

            if (_LastView != null && _LastView != _KeyBody)
            {
                _LastView.HideView(PlMain);
                _KeyBody.InitView(PlMain);

                BtPrevStep.Enabled = true;
                BtNextStep.Text = "保存(&S)";
            }

            _LastView = _KeyBody;
            _LastView.ShowData();
        }
        #endregion
        #endregion
    }
}
