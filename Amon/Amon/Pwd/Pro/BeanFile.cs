using System;
using System.Windows.Forms;
using Me.Amon.Model;

namespace Me.Amon.Pwd.Pro
{
    public partial class BeanFile : UserControl, IAttEdit
    {
        private AAtt _Att;
        private TextBox _Ctl;

        public BeanFile()
        {
            InitializeComponent();
        }

        #region 接口实现
        public Control Control { get { return this; } }

        public string Title { get { return "文件"; } }

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

        private void BtView_Click(object sender, EventArgs e)
        {

        }

        private void BtOpen_Click(object sender, EventArgs e)
        {

        }
    }
}
