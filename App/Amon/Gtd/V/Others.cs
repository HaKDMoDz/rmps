using System.Windows.Forms;

namespace Me.Amon.Gtd.V
{
    public partial class Others : UserControl, IEdit
    {
        public Others()
        {
            InitializeComponent();
        }

        #region 接口实现
        public MGtd MGtd { get; set; }

        public void ShowData()
        {
        }

        public bool SaveData()
        {
            return true;
        }
        #endregion
    }
}
