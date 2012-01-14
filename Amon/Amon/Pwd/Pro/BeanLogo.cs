using System.Windows.Forms;
using Me.Amon.Model;

namespace Me.Amon.Pwd.Pro
{
    public partial class BeanLogo : UserControl, IAttEdit
    {
        private AAtt _Att;
        private TextBoxBase _Ctl;

        public BeanLogo()
        {
            InitializeComponent();
        }

        #region 接口实现
        public Control Control { get { return this; } }

        public string Title { get { return "徽标"; } }

        public bool ShowData(AAtt att)
        {
            _Att = att;

            if (_Att != null)
            {
                //TbName.Text = _Att.Name;
                //TbData.Text = _Att.Data;
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

            //if (TbData.Text != _Att.Data)
            //{
            //    _Att.Data = TbData.Text;
            //    _Att.Modified = true;
            //}
        }
        #endregion
    }
}
