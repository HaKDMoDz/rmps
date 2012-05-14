using System;
using System.Windows.Forms;
using Me.Amon.Model;
using Me.Amon.Model.Pwd;
using Me.Amon.Pwd.Bean;
using Me.Amon.Uc;

namespace Me.Amon.Pwd.V.Pro
{
    public partial class BeanList : AList, IAttEdit
    {
        private APro _APro;
        private Item _Item;
        private Control _Ctl;

        #region 构造函数
        public BeanList()
        {
            InitializeComponent();
        }

        public BeanList(APro apro)
        {
            _APro = apro;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void InitOnce(DataModel dataModel, ViewModel viewModel)
        {
            this.TbText.GotFocus += new EventHandler(TbText_GotFocus);
            this.CbData.GotFocus += new EventHandler(CbData_GotFocus);
        }

        public Control Control { get { return this; } }

        public string Title { get { return "列表"; } }

        public bool ShowData(Att att)
        {
            _Att = att;

            if (_Att != null)
            {
                TbText.Text = _Att.Text;
                _Item = new Item { K = _Att.Data };
                CbData.SelectedItem = _Item;
            }

            if (string.IsNullOrEmpty(TbText.Text))
            {
                TbText.Focus();
            }
            else
            {
                CbData.Focus();
            }
            return true;
        }

        public void Cut()
        {
            if (_Ctl == TbText)
            {
                TbText.Cut();
            }
        }

        public void Copy()
        {
            if (_Ctl == TbText)
            {
                TbText.Copy();
            }
        }

        public void Paste()
        {
            if (_Ctl == TbText)
            {
                TbText.Paste();
            }
        }

        public void Clear()
        {
            if (_Ctl == TbText)
            {
                TbText.Clear();
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
            if (_Item != null && _Item.K != _Att.Data)
            {
                _Att.Data = _Item.K;
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

        private void CbData_GotFocus(object sender, EventArgs e)
        {
            _Ctl = CbData;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void CbData_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Item = CbData.SelectedItem as Item;
        }
        #endregion
    }
}
