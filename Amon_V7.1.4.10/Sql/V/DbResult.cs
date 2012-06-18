using System.Windows.Forms;

namespace Me.Amon.Sql.V
{
    public partial class DbResult : UserControl
    {
        public DbResult()
        {
            InitializeComponent();
        }

        public object DataSource
        {
            set
            {
                GvList.DataSource = value;
            }
        }
    }
}
