using System;
using System.Diagnostics;
using System.Windows.Forms;
using Me.Amon.Bean;
using Me.Amon.Model;
using Me.Amon.Util;

namespace Me.Amon.Pwd.Pro
{
    public partial class BeanMail : UserControl, IAttEdit
    {
        private AAtt _Att;
        private TextBox _Ctl;

        #region 构造函数
        public BeanMail()
        {
            InitializeComponent();
        }

        public void InitOnce(DataModel dataModel, ViewModel viewModel)
        {
            this.TbName.GotFocus += new EventHandler(TbName_GotFocus);
            this.TbData.GotFocus += new EventHandler(TbData_GotFocus);

            BtSend.Image = viewModel.GetImage("att-mail-send");
        }
        #endregion

        #region 接口实现
        public Control Control { get { return this; } }

        public string Title { get { return "邮件"; } }

        public bool ShowData(AAtt att)
        {
            _Att = att;

            if (_Att != null)
            {
                TbName.Text = _Att.Name;
                TbData.Text = _Att.Data;
            }
            return true;
        }

        public void Copy()
        {
            Clipboard.SetText(_Ctl.Text);
        }

        public void Save()
        {
            if (_Att == null)
            {
                return;
            }

            string mail = TbData.Text.Trim();
            if (!string.IsNullOrEmpty(mail) && !CharUtil.IsValidateMail(mail))
            {
                MessageBox.Show("无效的邮件地址！");
                TbData.Focus();
                return;
            }

            if (TbName.Text != _Att.Name)
            {
                _Att.Name = TbName.Text;
                _Att.Modified = true;
            }
            if (mail != _Att.Data)
            {
                _Att.Data = mail;
                _Att.Modified = true;
            }
        }
        #endregion

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
            string mail = TbData.Text.Trim();
            if (string.IsNullOrEmpty(mail))
            {
                return;
            }
            if (!CharUtil.IsValidateMail(mail))
            {
                MessageBox.Show("无效的邮件地址！");
                TbData.Focus();
                return;
            }

            try
            {
                Process.Start("mailto:" + mail);
            }
            catch (Exception exp)
            {
                Main.ShowError(exp);
            }
        }
    }
}
