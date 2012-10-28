using System;
using System.Windows.Forms;
using Me.Amon.Pwd._Att;
using Me.Amon.Pwd.Bean;
using Me.Amon.Pwd.M;
using Me.Amon.Util;

namespace Me.Amon.Pwd.V.Pro
{
    public partial class UcDateAtt : ADate, IAttEditer
    {
        private WPro _APro;
        private TextBox _Ctl;

        #region 构造函数
        public UcDateAtt()
        {
            InitializeComponent();
        }

        public UcDateAtt(WPro aPro)
        {
            _APro = aPro;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void InitOnce(DataModel dataModel, ViewModel viewModel)
        {
            this.TbText.GotFocus += new EventHandler(TbName_GotFocus);
            this.DtData.GotFocus += new EventHandler(DtData_GotFocus);

            BtNow.Image = viewModel.GetImage("att-date-now");
            _APro.ShowTips(BtNow, "当前时间");
            BtOpt.Image = viewModel.GetImage("att-date-options");
            _APro.ShowTips(BtOpt, "选项");

            InitSpec(DtData);
        }

        public Control Control { get { return this; } }

        public string Title { get { return "日期"; } }

        public bool ShowData(Att att)
        {
            _Att = att;

            if (_Att != null)
            {
                TbText.Text = _Att.Text;
                string cmd = _Att.GetSpec(DateAtt.SPEC_FORMAT, DateAtt.SPEC_VALUE_NONE);
                if (string.IsNullOrWhiteSpace(cmd))
                {
                    DtData.Format = DateTimePickerFormat.Long;
                }
                else
                {
                    DtData.Format = DateTimePickerFormat.Custom;
                    DtData.CustomFormat = cmd;
                }
                if (CharUtil.IsValidateLong(_Att.Data))
                {
                    DtData.Value = DateTime.FromFileTimeUtc(long.Parse(_Att.Data));
                }
            }

            return true;
        }

        public new bool Focus()
        {
            if (string.IsNullOrEmpty(TbText.Text))
            {
                return TbText.Focus();
            }

            return DtData.Focus();
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
            _Ctl = TbText;
            TbText.SelectAll();
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
