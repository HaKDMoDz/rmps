using System;
using System.Windows.Forms;
using Me.Amon.Model;
using Me.Amon.Model.Pwd;
using Me.Amon.Pwd.Bean;
using Me.Amon.Util;

namespace Me.Amon.Pwd.V.Pro
{
    public partial class BeanDate : ADate, IAttEdit
    {
        private TextBox _Ctl;

        #region 构造函数
        public BeanDate()
        {
            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void InitOnce(DataModel dataModel, ViewModel viewModel)
        {
            this.TbName.GotFocus += new EventHandler(TbName_GotFocus);
            this.DtData.GotFocus += new EventHandler(DtData_GotFocus);

            BtNow.Image = viewModel.GetImage("att-date-now");
            BtOpt.Image = viewModel.GetImage("att-date-options");

            InitSpec(DtData);
        }

        public Control Control { get { return this; } }

        public string Title { get { return "日期"; } }

        public bool ShowData(Att att)
        {
            _Att = att;

            if (_Att != null)
            {
                TbName.Text = _Att.Name;
                if (CharUtil.IsValidateLong(_Att.Data))
                {
                    DtData.Value = DateTime.FromFileTimeUtc(long.Parse(_Att.Data));
                }
            }

            if (string.IsNullOrEmpty(TbName.Text))
            {
                TbName.Focus();
            }
            else
            {
                DtData.Focus();
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

            if (TbName.Text != _Att.Name)
            {
                _Att.Name = TbName.Text;
                _Att.Modified = true;
            }
            string date = DtData.Value.ToFileTimeUtc().ToString();
            if (date != _Att.Data)
            {
                _Att.Data = date;
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

        private void DtData_GotFocus(object sender, EventArgs e)
        {
        }

        private void BtNow_Click(object sender, EventArgs e)
        {
            DtData.Value = DateTime.Now;
        }

        private void BtOpt_Click(object sender, EventArgs e)
        {
            ShowSpec(BtOpt);
        }
        #endregion
    }
}
