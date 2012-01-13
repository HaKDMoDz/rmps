using System.Windows.Forms;

namespace Me.Amon.Pwd.Pro
{
    public partial class BeanInfo : UserControl, IAttEdit
    {
        public BeanInfo()
        {
            InitializeComponent();
        }

        #region 接口实现
        public Control Control { get { return this; } }

        public bool ShowData(Model.AAtt att)
        {
            return true;
        }

        public void Copy()
        {
        }

        public void Save()
        {
        }
        #endregion
    }
}
