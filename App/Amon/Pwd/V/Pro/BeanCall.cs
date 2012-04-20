using System;
using System.Windows.Forms;
using Me.Amon.Model;
using Me.Amon.Model.Pwd;
using Me.Amon.Pwd.Bean;

namespace Me.Amon.Pwd.V.Pro
{
    public partial class BeanCall : ACall, IAttEdit
    {
        private TextBox _Ctl;
        private DataModel _DataModel;

        #region 构造函数
        public BeanCall()
        {
            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void InitOnce(DataModel dataModel, ViewModel viewModel)
        {
            _DataModel = dataModel;

            BtOpen.Visible = false;
            BtView.Visible = false;

            TbData.GotFocus += new EventHandler(TbData_GotFocus);
        }

        public Control Control
        {
            get { return this; }
        }

        public string Title
        {
            get { return "电话"; }
        }

        public bool ShowData(Pwd.Att att)
        {
            _Att = att;

            if (_Att != null)
            {
                TbName.Text = _Att.Name;
                TbData.Text = _Att.Data;
            }

            if (string.IsNullOrEmpty(TbName.Text))
            {
                TbName.Focus();
            }
            else
            {
                TbData.Focus();
            }
            return true;
        }

        public void Copy()
        {
            if (_Ctl != null)
            {
                Clipboard.SetText(_Ctl.Text);
            }
        }

        public bool Save()
        {
            if (_Att == null)
            {
                return false;
            }

            if (TbName.Text != _Att.Name)
            {
                _Att.Name = TbName.Text;
                _Att.Modified = true;
            }
            if (TbData.Text != _Att.Data)
            {
                _Att.Data = TbData.Text;
                _Att.Modified = true;
            }

            return true;
        }
        #endregion

        #region 事件处理
        private void TbData_GotFocus(object sender, EventArgs e)
        {
            _Ctl = TbData;
        }

        private void BtOpen_Click(object sender, EventArgs e)
        {

        }

        private void BtView_Click(object sender, EventArgs e)
        {
            CmMenu.Show(BtView, 0, BtView.Height);
        }
        #endregion
    }
}
