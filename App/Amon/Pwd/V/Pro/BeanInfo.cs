using System.Windows.Forms;
using Me.Amon.Model;
using Me.Amon.Model.Pwd;

namespace Me.Amon.Pwd.V.Pro
{
    public partial class BeanInfo : UserControl, IAttEdit
    {
        private APro _APro;

        #region 构造函数
        public BeanInfo()
        {
            InitializeComponent();
        }

        public BeanInfo(APro apro)
        {
            _APro = apro;

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

        public void Cut()
        {
        }

        public void Copy()
        {
        }

        public void Paste()
        {
        }

        public void Clear()
        {
        }

        public bool Save()
        {
            return true;
        }
        #endregion
    }
}
