using System.Windows.Forms;
using Me.Amon.Gtd.M;

namespace Me.Amon.Gtd.V
{
    public partial class UhMail : UserControl, IHint
    {
        public UhMail()
        {
            InitializeComponent();
        }

        #region 接口实现
        public Control Control { get { return this; } }

        public void ShowData(MGtd mgtd)
        {
        }

        public bool SaveData(MGtd mgtd)
        {
            return true;
        }
        #endregion
    }
}
