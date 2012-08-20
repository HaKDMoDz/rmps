using System.Windows.Forms;

namespace Me.Amon.Gtd.V.Uc
{
    public partial class UcNone : UserControl, ITime
    {
        public UcNone()
        {
            InitializeComponent();
        }

        #region 接口实现
        public Control Control { get { return this; } }

        public void ShowData(MGtdDates mgtd)
        {
        }

        public bool SaveData(MGtdDates mgtd)
        {
            return true;
        }
        #endregion
    }
}
