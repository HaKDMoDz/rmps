using System.Windows.Forms;
using Me.Amon.Pwd.M;

namespace Me.Amon.Pwd.V.Wiz.Viewer
{
    public partial class AttViewer : UserControl, IAttView
    {
        private WWiz _AWiz;
        private SafeModel _SafeModel;
        private DataModel _DataModel;

        #region 构造函数
        public AttViewer()
        {
            InitializeComponent();
        }

        public void Init(WWiz aWiz, UserModel userModel, SafeModel safeModel, DataModel dataModel, ViewModel viewModel)
        {
            _AWiz = aWiz;
            _SafeModel = safeModel;
            _DataModel = dataModel;

            beanGuid1.Init(aWiz, userModel, safeModel, dataModel, viewModel);
            beanHead1.Init(aWiz, userModel, safeModel, dataModel, viewModel);
            beanBody1.Init(aWiz, userModel, safeModel, dataModel, viewModel);
        }
        #endregion

        public Control Control { get { return this; } }

        public void ShowData()
        {
            beanGuid1.ShowData();
            beanHead1.ShowData();
            beanBody1.ShowData();
        }
    }
}
