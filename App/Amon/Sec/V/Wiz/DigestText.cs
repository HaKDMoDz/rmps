using System.Windows.Forms;

namespace Me.Amon.Sec.V.Wiz
{
    public partial class DigestText : UserControl, IView
    {
        public DigestText()
        {
            InitializeComponent();
        }

        #region 接口实现
        public Control Control
        {
            get { return this; }
        }
        #endregion
    }
}
