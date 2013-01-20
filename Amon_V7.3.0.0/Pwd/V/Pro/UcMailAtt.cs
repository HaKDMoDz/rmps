using System;
using System.Windows.Forms;
using Me.Amon.Pwd.Bean;
using Me.Amon.Pwd.M;
using Me.Amon.Util;

namespace Me.Amon.Pwd.V.Pro
{
    public partial class UcMailAtt : AMail, IAttEditer
    {
        private WPro _APro;
        private TextBox _Ctl;

        #region 构造函数
        public UcMailAtt()
        {
            InitializeComponent();
        }

        public UcMailAtt(WPro aPro)
        {
            _APro = aPro;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void InitOnce(DataModel dataModel, ViewModel viewModel)
        {
            TbText.GotFocus += new EventHandler(TbText_GotFocus);
            TbData.GotFocus += new EventHandler(TbData_GotFocus);

            BtSend.Image = viewModel.GetImage("att-mail-send");
            _APro.ShowTips(BtSend, "撰写邮件");

            InitSpec(TbData);
        }

        public Control Control { get { return this; } }

        public string Title { get { return "邮件"; } }

        public bool ShowData(Att att)
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

        public void Copy(CopyType type)
        {
            if (type == CopyType.Data)
            {
                if (!string.IsNullOrEmpty(TbData.Text))
                {
                    Clipboard.SetText(TbData.Text);
                }
                return;
            }
            if (type == CopyType.Name)
            {
                if (!string.IsNullOrEmpty(TbText.Text))
                {
                    Clipboard.SetText(TbText.Text);
                }
                return;
            }

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

            string mail = TbData.Text.Trim();
            if (!string.IsNullOrEmpty(mail) && !CharUtil.IsValidateMail(mail))
            {
                Main.ShowAlert("请输入一个形如 someone@host.com 的邮件地址！");
                TbData.Focus();
                return false;
            }

            if (TbText.Text != _Att.Text)
            {
                _Att.Text = TbText.Text;
                _Att.Modified = true;
            }
            if (mail != _Att.Data)
            {
                _Att.Data = mail;
                _Att.Modified = true;
            }

            return true;
        }
        #endregion

        #region 事件处理
        private void TbText_GotFocus(object sender, EventArgs e)
        {
            _Ctl = TbText;
            TbText.SelectAll();
        }

        private void TbData_GotFocus(object sender, EventArgs e)
        {
            _Ctl = TbData;
            TbData.SelectAll();
        }

        private void BtSend_Click(object sender, EventArgs e)
        {
            OpenMail();
        }
        #endregion
    }
}
