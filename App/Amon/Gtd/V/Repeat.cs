using System.Windows.Forms;

namespace Me.Amon.Gtd.V
{
    public partial class Repeat : UserControl, IEdit
    {
        public Repeat()
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
