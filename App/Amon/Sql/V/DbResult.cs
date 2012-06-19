 using System.Windows.Forms;

namespace Me.Amon.Sql.V
{
    public partial class DbResult : UserControl, IResult
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
