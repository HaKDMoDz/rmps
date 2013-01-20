using System;
using System.Windows.Forms;
using Me.Amon.Pwd.Bean;
using Me.Amon.Pwd.M;

namespace Me.Amon.Pwd.V.Pro
{
    public partial class UcFileAtt : AFile, IAttEditer
    {
        private WPro _APro;
        private TextBox _Ctl;

        #region 构造函数
        public UcFileAtt()
        {
            InitializeComponent();
        }

        public UcFileAtt(WPro aPro)
        {
            _APro = aPro;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void InitOnce(DataModel dataModel, ViewModel viewModel)
        {
            _DataModel = dataModel;

            TbText.GotFocus += new EventHandler(TbName_GotFocus);
            TbData.GotFocus += new EventHandler(TbData_GotFocus);

            BtView.Image = viewModel.GetImage("att-file-preview");
            _APro.ShowTips(BtView, "查看文件");
            BtOpen.Image = viewModel.GetImage("att-file-append");
            _APro.ShowTips(BtOpen, "添加文件");

            InitSpec(TbData);
        }

        public Control Control { get { return this; } }

        public string Title { get { return "文件"; } }

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
        private void TbName_GotFocus(object sender, EventArgs e)
        {
            _Ctl = TbText;
            TbText.SelectAll();
        }

        private void TbData_GotFocus(object sender, EventArgs e)
        {
            _Ctl = TbData;
            TbData.SelectAll();
        }

        private void BtView_Click(object sender, EventArgs e)
        {
            ShowSpec(BtView);
        }

        private void BtOpen_Click(object sender, EventArgs e)
        {
            OpenFile();
        }
        #endregion
    }
}
