using System.Windows.Forms;
using Me.Amon.Model;

namespace Me.Amon.Pwd.Pad
{
    public partial class APad : UserControl, IPwd
    {
        private SafeModel _SafeModel;

        public APad()
        {
            InitializeComponent();
        }

        public APad(SafeModel safeModel, DataModel dataModel)
        {
            _SafeModel = safeModel;

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
