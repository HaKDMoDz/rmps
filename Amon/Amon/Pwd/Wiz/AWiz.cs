using System;
using System.Windows.Forms;
using Me.Amon.Model;

namespace Me.Amon.Pwd.Wiz
{
    public partial class AWiz : UserControl, IPwd
    {
        private IWizView _Last;
        private BeanInfo _Info;
        private BeanHead _Head;
        private BeanBody _Body;
        private SafeModel _SafeModel;
        private DataModel _DataModel;

        public AWiz()
        {
            InitializeComponent();
        }

        public AWiz(SafeModel safeModel, DataModel dataModel)
        {
            _SafeModel = safeModel;
            _DataModel = dataModel;

            InitializeComponent();
        }

        #region 接口实现
        public void InitView(TableLayoutPanel grid)
        {
            ShowInfo();

            grid.Controls.Add(this, 0, 1);
            Dock = DockStyle.Fill;
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
            _Last.Focus();
        }

        public bool UpdateKey()
        {
            if (_Last == null)
            {
                return false;
            }
            return _Last.SaveData();
        }

        public void DeleteKey()
        {
        }

        public void CopyAtt()
        {
        }

        public void SaveAtt()
        {
        }

        public void DropAtt()
        {
        }
        #endregion

        private void BtPrev_Click(object sender, EventArgs e)
        {
            if (_Last != null && !_Last.SaveData())
            {
                return;
            }
            ShowHead();
        }

        private void BtNext_Click(object sender, EventArgs e)
        {
            if (_Last != null && !_Last.SaveData())
            {
                return;
            }
            ShowBody();
        }

        private void BtCopy_Click(object sender, EventArgs e)
        {
            if (_Last != null)
            {
                _Last.CopyData();
            }
        }

        private void ShowInfo()
        {
            if (_Info == null)
            {
                _Info = new BeanInfo();
                _Info.Init(_DataModel);
            }
            if (_Last != null && _Last != _Info)
            {
                _Last.HideView(TpGrid);
                _Info.InitView(TpGrid);
            }

            _Last = _Info;
            _Last.ShowData();
        }

        private void ShowHead()
        {
            if (_Head == null)
            {
                _Head = new BeanHead(_SafeModel);
                _Head.Init(_DataModel);
            }
            if (_Last != null && _Last != _Head)
            {
                _Last.HideView(TpGrid);
                _Head.InitView(TpGrid);

                BtPrev.Visible = false;
                BtNext.Visible = true;
            }

            _Last = _Head;
            _Last.ShowData();
        }

        private void ShowBody()
        {
            if (_Body == null)
            {
                _Body = new BeanBody(_SafeModel);
                _Body.Init(_DataModel);
            }
            if (_Last != null && _Last != _Body)
            {
                _Last.HideView(TpGrid);
                _Body.InitView(TpGrid);

                BtPrev.Visible = true;
                BtNext.Visible = false;
            }

            _Last = _Body;
            _Last.ShowData();
        }
    }
}
