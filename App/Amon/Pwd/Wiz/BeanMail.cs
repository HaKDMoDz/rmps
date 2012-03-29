using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Bean;
using Me.Amon.Model;
using Me.Amon.Model.Pwd;
using Me.Amon.Util;

namespace Me.Amon.Pwd.Wiz
{
    public partial class BeanMail : UserControl, IAttEdit
    {
        private BeanBody _Body;
        private TableLayoutPanel _Grid;
        private RowStyle _Style;
        private Label _Label;
        private Att _Att;

        #region 构造函数
        public BeanMail()
        {
            InitializeComponent();
        }

        public BeanMail(BeanBody body)
        {
            _Body = body;

            InitializeComponent();
        }

        public void InitOnce(TableLayoutPanel grid, ViewModel viewModel)
        {
            _Grid = grid;

            _Label = new Label();
            _Label.TextAlign = ContentAlignment.MiddleRight;
            _Label.Dock = DockStyle.Fill;

            _Style = new RowStyle(SizeType.Absolute, 27F);
            Dock = DockStyle.Fill;

            TbData.GotFocus += new EventHandler(TbData_GotFocus);

            BtSend.Image = viewModel.GetImage("att-mail-send");
        }
        #endregion

        #region 接口实现
        public int InitView(int row)
        {
            TabIndex = row;

            _Grid.RowStyles.Add(_Style);

            _Grid.Controls.Add(_Label, 0, row);
            _Grid.Controls.Add(this, 1, row);

            return 27;
        }

        public bool ShowData(DataModel dataModel, Att att)
        {
            _Att = att;
            if (_Att != null)
            {
                _Label.Text = _Att.Name;
                TbData.Text = _Att.Data;
            }
            return true;
        }

        public void Copy()
        {
            if (!string.IsNullOrEmpty(TbData.Text))
            {
                Clipboard.SetText(TbData.Text);
            }
        }

        public bool Save()
        {
            if (_Att == null)
            {
                return false;
            }

            string mail = TbData.Text.Trim();
            if (mail.Length > 0 && !CharUtil.IsValidateMail(mail))
            {
                MessageBox.Show("无效的邮件地址！");
                TbData.Focus();
                return false;
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
        private void TbData_GotFocus(object sender, EventArgs e)
        {
            _Body.EditCtl = this;
        }

        #region 按钮事件
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
                Process.Start("mailto:" + TbData.Text);
            }
            catch (Exception exp)
            {
                Main.ShowError(exp);
            }
        }
        #endregion
        #endregion
    }
}
