using System;
using System.Windows.Forms;
using Me.Amon.Pwd.Bean;
using Me.Amon.Pwd.M;

namespace Me.Amon.Pwd.V.Pro
{
    public partial class UcCallAtt : ACall, IAttEditer
    {
        private WPro _APro;
        private TextBox _Ctl;
        private DataModel _DataModel;

        #region 构造函数
        public UcCallAtt()
        {
            InitializeComponent();
        }

        public UcCallAtt(WPro aPro)
        {
            _APro = aPro;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void InitOnce(DataModel dataModel, ViewModel viewModel)
        {
            _DataModel = dataModel;

            BtOpt.Visible = false;

            TbText.GotFocus += new EventHandler(TbText_GotFocus);
            TbData.GotFocus += new EventHandler(TbData_GotFocus);

            BtOpt.Image = viewModel.GetImage("att-call-options");
            _APro.ShowTips(BtOpt, "选项");

            InitSpec(TbData);
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
                TbText.Text = _Att.Text;
                TbData.Text = _Att.Data;
            }

            return true;
        }

        public new bool Focus()
        {
            if (string.IsNullOrEmpty(TbText.Text))
            {
                return TbText.Focus();
            }

            return TbData.Focus();
        }

        public void Cut()
        {
            if (_Ctl != null)
            {
                _Ctl.Cut();
            }
        }

        public void Copy()
        {
            if (_Ctl == null)
            {
                return;
            }
            if (!string.IsNullOrEmpty(_Ctl.SelectedText))
            {
                _Ctl.Copy();
                return;
            }
            if (!string.IsNullOrEmpty(_Ctl.Text))
            {
                Clipboard.SetText(_Ctl.Text);
            }
        }

        public void Paste()
        {
            if (_Ctl != null)
            {
                _Ctl.Paste();
            }
        }

        public void Clear()
        {
            if (_Ctl != null)
            {
                _Ctl.Clear();
            }
        }

        public bool Save()
        {
            if (_Att == null)
            {
                return false;
            }

            if (TbText.Text != _Att.Text)
            {
                _Att.Text = TbText.Text;
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
        public void TbText_GotFocus(object sender, EventArgs e)
        {
            _Ctl = TbText;
        }

        private void TbData_GotFocus(object sender, EventArgs e)
        {
            _Ctl = TbData;
        }

        private void BtOpt_Click(object sender, EventArgs e)
        {
            ShowSpec(BtOpt);
        }
        #endregion
    }
}
