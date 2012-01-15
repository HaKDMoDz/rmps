using System;
using System.Windows.Forms;
using Me.Amon.Model;

namespace Me.Amon.Pwd.Wiz
{
    public partial class AWiz : UserControl, IPwd
    {
        private APwd _APwd;
        private IWizView _LastView;
        private BeanInfo _InfoBean;
        private BeanHead _HeadBean;
        private BeanBody _BodyBean;
        private SafeModel _SafeModel;
        private DataModel _DataModel;

        public AWiz()
        {
            InitializeComponent();
        }

        public void Init(APwd apwd, SafeModel safeModel, DataModel dataModel)
        {
            _APwd = apwd;
            _SafeModel = safeModel;
            _DataModel = dataModel;
        }

        #region 接口实现
        public void InitView(TableLayoutPanel grid)
        {
            _InfoBean = new BeanInfo();
            _InfoBean.Init(_DataModel);
            _InfoBean.InitView(TpGrid);
            _InfoBean.ShowData();

            grid.Controls.Add(this, 0, 1);
            Dock = DockStyle.Fill;

            _LastView = _InfoBean;
        }

        public void HideView(TableLayoutPanel grid)
        {
            grid.Controls.Remove(this);
        }

        public void ShowData()
        {
            ShowInfo();
        }

        public void ShowData(Key key)
        {
            ShowHead();
        }

        public void AppendKey()
        {
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

        public void UpdateAtt(int type)
        {
        }

        public void CopyAtt()
        {
            if (_LastView != null)
            {
                _LastView.CopyData();
            }
        }

        public void SaveAtt()
        {
        }

        public void DropAtt()
        {
        }
        #endregion

        public void ShowTips(Control control, string caption)
        {
            _APwd.ShowTips(control, caption);
        }

        private void BtPrev_Click(object sender, EventArgs e)
        {
            if (_LastView != null && !_LastView.SaveData())
            {
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
            ShowBody();
        }

        private void BtCopy_Click(object sender, EventArgs e)
        {
            if (_LastView != null)
            {
                _LastView.CopyData();
            }
        }

        private void ShowInfo()
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

        private void ShowHead()
        {
            if (_HeadBean == null)
            {
                _HeadBean = new BeanHead(_SafeModel);
                _HeadBean.Init(_DataModel);
            }
            if (_LastView != null && _LastView != _HeadBean)
            {
                _LastView.HideView(TpGrid);
                _HeadBean.InitView(TpGrid);

                BtPrev.Visible = false;
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
                _BodyBean.Init(_DataModel);
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
    }
}
