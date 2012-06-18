using System.Windows.Forms;

namespace Me.Amon.Sql.Editor
{
    public partial class SqlEditor : UserControl, IEditor
    {
        private string _Buffer;

        #region 构造函数
        public SqlEditor()
        {
            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public bool Check()
        {
            string sql = TbSql.Text.Trim();
            if (string.IsNullOrEmpty(sql))
            {
                MessageBox.Show("请输入您的查询条件！");
                TbSql.Focus();
                return false;
            }

            _Buffer = TbSql.SelectedText;
            if (!string.IsNullOrWhiteSpace(_Buffer))
            {
                return true;
            }

            int s = TbSql.SelectionStart;
            if (s < 0)
            {
                _Buffer = sql;
                return true;
            }

            int e = sql.IndexOf(';', s);
            if (e < 0)
            {
                e = sql.Length;
            }
            s = sql.LastIndexOf(';', s);
            if (s < 0)
            {
                s = 0;
            }
            _Buffer = sql.Substring(s, e - s);
            return !string.IsNullOrWhiteSpace(_Buffer);
        }

        public string GetSQL()
        {
            return _Buffer;
        }
        #endregion
    }
}
