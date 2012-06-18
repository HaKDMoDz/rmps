using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
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
            string name = Path.GetFileNameWithoutExtension(file);
            IDbConnection con = _ASql.GetConnection();
            IDbCommand cmd = _ASql.GetCommand();

            DropTable(cmd, name);

            using (StreamReader reader = new StreamReader(file))
            {
                string line = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    return;
                }
                string[] header = line.Split(sep);
                StringBuilder create = new StringBuilder();
                StringBuilder insert = new StringBuilder();
                create.Append(string.Format("CREATE TABLE {0} (", name));
                insert.Append(string.Format("INSERT INTO {0} (", name));
                for (int i = 0; i < header.Length; i += 1)
                {
                    line = (header[i] ?? "").Trim();
                    if (!Regex.IsMatch(line, "^[\\w]+$"))
                    {
                        return;
                    }
                    create.Append(string.Format("{0} VARCHAR(8),", line));
                    insert.Append(string.Format("{0},", line));
                }
                create.Remove(create.Length - 1, 1).Append(')');
                cmd.CommandText = create.ToString();
                cmd.ExecuteNonQuery();
                create.Clear();

                insert.Remove(insert.Length - 1, 1).Append(") VALUES ");
                string sql = insert.ToString();
                insert.Clear();

                IDbTransaction trans = con.BeginTransaction();
                string[] detail;
                int idx;
                int max;
                int cnt = 0;
                line = reader.ReadLine();
                while (line != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        line = reader.ReadLine();
                        continue;
                    }
                    idx = 0;

                    insert.Append(sql).Append('(');
                    detail = line.Split(sep);
                    max = detail.Length <= header.Length ? detail.Length : header.Length;
                    while (idx < max)
                    {
                        insert.Append(string.Format("'{0}',", detail[idx]));
                        idx += 1;
                    }
                    while (idx < header.Length)
                    {
                        insert.Append("null,");
                        idx += 1;
                    }
                    insert.Remove(insert.Length - 1, 1).Append(')');
                    cmd.CommandText = insert.ToString();
                    cmd.ExecuteNonQuery();
                    insert.Clear();
                    cnt += 1;

                    line = reader.ReadLine();
                }
                trans.Commit();

                Main.ShowAlert(string.Format("成功导入 {0} 条记录！", cnt));
            }
        }

        private void ImportSql(string file)
        {
        }

        private void DropTable(IDbCommand command, string table)
        {
            command.CommandText = string.Format("drop table if exists {0}", table);
            command.ExecuteNonQuery();
        }
    }
}
