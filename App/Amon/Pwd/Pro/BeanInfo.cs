using System.Windows.Forms;
using Me.Amon.Bean;
using Me.Amon.Model;

namespace Me.Amon.Pwd.Pro
{
    public partial class BeanInfo : UserControl, IAttEdit
    {
        #region 构造函数
        public BeanInfo()
        {
            InitializeComponent();
        }

        public void InitOnce(DataModel dataModel, ViewModel viewModel)
        {
        }
        #endregion

        #region 接口实现
        public Control Control { get { return this; } }

        public string Title { get { return "提示"; } }

        public bool ShowData(AAtt att)
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
