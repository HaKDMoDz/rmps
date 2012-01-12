using System.Windows.Forms;
using Me.Amon.Model;

namespace Me.Amon.Pwd.Wiz
{
    public partial class BeanInfo : UserControl, IWizView
    {
        private SafeModel _SafeModel;

        public BeanInfo()
        {
            InitializeComponent();
        }

        public BeanInfo(SafeModel safeModel)
        {
            _SafeModel = safeModel;

            InitializeComponent();
        }

        public void Init(DataModel dataModel)
        {
        }

        public void InitView(TableLayoutPanel grid)
        {
            grid.Controls.Add(this, 0, 0);
            Dock = DockStyle.Fill;
            grid.RowStyles[1].Height = 0;
        }

        public void HideView(TableLayoutPanel grid)
        {
            grid.Controls.Remove(this);
        }

        public void ShowData()
        {
        }

        public bool SaveData()
        {
            return false;
        }

        public void CopyData()
        {
        }
    }
}
