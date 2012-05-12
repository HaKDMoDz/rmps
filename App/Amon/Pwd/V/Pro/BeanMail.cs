using System;
using System.Windows.Forms;
using Me.Amon.Model;
using Me.Amon.Model.Pwd;
using Me.Amon.Pwd.Bean;
using Me.Amon.Util;

namespace Me.Amon.Pwd.V.Pro
{
    public partial class BeanMail : AMail, IAttEdit
    {
        private TextBox _Ctl;

        #region 构造函数
        public BeanMail()
        {
            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void InitOnce(DataModel dataModel, ViewModel viewModel)
        {
            TbName.GotFocus += new EventHandler(TbName_GotFocus);
            TbData.GotFocus += new EventHandler(TbData_GotFocus);

            BtSend.Image = viewModel.GetImage("att-mail-send");

            InitSpec(TbData);
        }

        public Control Control { get { return this; } }

        public string Title { get { return "邮件"; } }

        public bool ShowData(Att att)
        {
            _Att = att;

            if (_Att != null)
            {
                TbName.Text = _Att.Text;
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

        public void Cut()
        {
            if (_Ctl != null)
            {
                _Ctl.Cut();
            }
        }

        public void Copy()
        {
            if (_Ctl != null)
            {
                _Ctl.Copy();
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
                MessageBox.Show("无效的邮件地址！");
                TbData.Focus();
                return false;
            }

            if (TbName.Text != _Att.Text)
            {
                _Att.Text = TbName.Text;
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
        private void TbName_GotFocus(object sender, EventArgs e)
        {
            _Ctl = TbName;
            TbName.SelectAll();
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
