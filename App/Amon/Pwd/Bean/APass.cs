using System.Windows.Forms;
using Me.Amon.Pwd.M;

namespace Me.Amon.Pwd.Bean
{
    public partial class APass : UserControl
    {
        protected Att _Att;
        protected UserModel _UserModel;
        protected DataModel _DataModel;
        protected ViewModel _ViewModel;

        #region 构造函数
        public APass()
        {
            InitializeComponent();
        }
        #endregion
    }
}
