using System.Windows.Forms;

namespace Me.Amon.Sql.V
{
    public partial class DbImport : Form
    {
        private ASql _ASql;

        #region 构造函数
        public DbImport()
        {
            InitializeComponent();
        }

        public DbImport(ASql asql)
        {
            _ASql = asql;

            InitializeComponent();
        }
        #endregion

        private void ImportCsv(string file, char sep)
        {
        }

        private void ImportSql(string file)
        {
        }
    }
}
