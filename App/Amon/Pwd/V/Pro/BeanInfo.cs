using System.Windows.Forms;
using Me.Amon.Pwd;
using Me.Amon.Model;
using Me.Amon.Model.Pwd;

namespace Me.Amon.Pwd.V.Pro
{
    public partial class BeanInfo : UserControl, IAttEdit
    {
        #region 构造函数
        public BeanInfo()
        {
            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void InitOnce(DataModel dataModel, ViewModel viewModel)
        {
        }

        public Control Control { get { return this; } }

        public string Title { get { return "提示"; } }

        public bool ShowData(Att att)
        {
            return true;
        }

        public void Copy()
        {
        }

        public bool Save()
        {
            return true;
        }
        #endregion
    }
}
