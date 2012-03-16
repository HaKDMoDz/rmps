using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Me.Amon.Bean;
using Me.Amon.Model;

namespace Me.Amon.Pwd.Pro
{
    public partial class BeanLink : UserControl, IAttEdit
    {
        private AAtt _Att;
        private TextBox _Ctl;

        #region 构造函数
        public BeanLink()
        {
            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void InitOnce(DataModel dataModel, ViewModel viewModel)
        {
            this.TbName.GotFocus += new EventHandler(TbName_GotFocus);
            this.TbData.GotFocus += new EventHandler(TbData_GotFocus);

            BtOpen.Image = viewModel.GetImage("att-link-open");
        }

        public Control Control { get { return this; } }

        public string Title { get { return "链接"; } }

        public bool ShowData(AAtt att)
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
            Clipboard.SetText(_Ctl.Text);
        }

        public void Save()
        {
            if (_Att == null)
            {
                return;
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

        private void BtOpen_Click(object sender, EventArgs e)
        {
            string link = TbData.Text.Trim();
            if (string.IsNullOrEmpty(link))
            {
                return;
            }

            if (!Regex.IsMatch(link, "^\\w+://.+", RegexOptions.IgnoreCase))
            {
                link = "http://" + link;
            }

            try
            {
                Process.Start(link);
            }
            catch (Exception exp)
            {
                Main.ShowError(exp);
            }
        }
        #endregion
    }
}
