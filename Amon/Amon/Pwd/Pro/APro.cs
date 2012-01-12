using System.Windows.Forms;
using Me.Amon.Model;

namespace Me.Amon.Pwd.Pro
{
    public partial class APro : UserControl, IPwd
    {
        private DataModel _DataModel;
        private SafeModel _SafeModel;

        public APro()
        {
            InitializeComponent();
        }

        public APro(SafeModel safeModel, DataModel dataModel)
        {
            _SafeModel = safeModel;
            _DataModel = dataModel;

            InitializeComponent();
        }

        #region 接口实现
        public void InitView(TableLayoutPanel grid)
        {
            grid.Controls.Add(this, 0, 1);
            Dock = DockStyle.Fill;
        }

        public void HideView(TableLayoutPanel grid)
        {
            grid.Controls.Remove(this);
        }

        public void ShowData()
        {
        }

        public void ShowData(Model.Key key)
        {
        }

        public void AppendKey()
        {
        }

        public bool UpdateKey()
        {
            return false;
        }

        public void DeleteKey()
        {
        }

        public void CopyAtt()
        {
        }

        public void SaveAtt()
        {
        }

        public void DropAtt()
        {
        }
        #endregion
    }
}
