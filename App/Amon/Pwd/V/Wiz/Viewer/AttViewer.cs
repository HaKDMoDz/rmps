using System.Windows.Forms;

namespace Me.Amon.Pwd.V.Wiz.Viewer
{
    public partial class AttViewer : UserControl, IAttView
    {
        #region 构造函数
        public AttViewer()
        {
            InitializeComponent();
        }
        #endregion

        public Control Control { get { return this; } }
    }
}
