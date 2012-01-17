using System;
using System.Windows.Forms;
using Me.Amon.Model;
using Me.Amon.Uc;

namespace Me.Amon.Pwd.Pro
{
    public partial class BeanList : UserControl, IAttEdit
    {
        private AAtt _Att;
        private Item _Item;
        private Control _Ctl;

        public BeanList()
        {
            InitializeComponent();

            this.TbName.GotFocus += new EventHandler(TbName_GotFocus);
            this.CbData.GotFocus += new EventHandler(CbData_GotFocus);
        }

        #region 接口实现
        public Control Control { get { return this; } }

        public string Title { get { return "列表"; } }

        public bool ShowData(DataModel dataModel, AAtt att)
        {
            _Att = att;

            if (_Att != null)
            {
                TbName.Text = _Att.Name;
                _Item = new Item { K = _Att.Data };
                CbData.SelectedItem = _Item;
            }
            return true;
        }

        public void Copy()
        {
            if (_Ctl == TbName)
            {
                Clipboard.SetText(TbName.Text);
            }
            else if (_Item != null)
            {
                Clipboard.SetText(_Item.K);
            }
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
            if (_Item != null && _Item.K != _Att.Data)
            {
                _Att.Data = _Item.K;
                _Att.Modified = true;
            }
        }
        #endregion

        private void TbName_GotFocus(object sender, EventArgs e)
        {
            _Ctl = TbName;
            TbName.SelectAll();
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
    }
}
