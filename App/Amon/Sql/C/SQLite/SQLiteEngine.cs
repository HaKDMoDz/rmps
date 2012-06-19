using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Me.Amon.Sql.C.SQLite
{
    public class SQLiteEngine : IEngine
    {
        private SQLiteConnection _Connect;
        private SQLiteCommand _Command;
        private SQLiteDataAdapter _Adapter;

        public void Begin()
        {
            _Connect = new SQLiteConnection("Data Source=KeyStone.db3");
            _Connect.Open();

            _Command = new SQLiteCommand();
            _Command.Connection = _Connect;
            _Command.CommandType = CommandType.Text;

            _Adapter = new SQLiteDataAdapter(_Command);
        }

        public void Close()
        {
            if (_Command != null)
            {
                _Command.Dispose();
                _Command = null;
            }
            if (_Connect != null)
            {
                _Connect.Close();
                _Connect = null;
            }
        }

        public List<string> TableList
        {
            get
            {
                _Command.CommandText = @"SELECT name
                                           FROM sqlite_master
                                          WHERE type ='table'
                                            AND name NOT LIKE 'sqlite_%'
                                          UNION ALL
                                         SELECT name FROM sqlite_temp_master
                                          WHERE type ='table'
                                          ORDER BY 1";
                List<string> tables = new List<string>();
                SQLiteDataReader reader = _Command.ExecuteReader();
                while (reader.Read())
                {
                    tables.Add(reader.GetString(0));
                }
                reader.Close();
                return tables;
            }
        }

        public List<string> ViewList
        {
            get
            {
                _Command.CommandText = @"SELECT name
                                           FROM sqlite_master
                                          WHERE type ='view'
                                            AND name NOT LIKE 'sqlite_%'
                                          UNION ALL
                                         SELECT name FROM sqlite_temp_master
                                          WHERE type ='view'
                                          ORDER BY 1";
                List<string> tables = new List<string>();
                SQLiteDataReader reader = _Command.ExecuteReader();
                while (reader.Read())
                {
                    tables.Add(reader.GetString(0));
                }
                reader.Close();
                return tables;
            }
        }

        public List<string> ProcedureList
        {
            get
            {
                return null;
            }
        }

        public List<string> FunctionList
        {
            get
            {
                return null;
            }
        }

        public bool DropTable(string table)
        {
            return true;
        }

        public DataSet DoSelect(string sql)
        {
            DataSet dataSet = new DataSet();
            _Command.CommandText = sql;
            _Adapter.Fill(dataSet);
            return dataSet;
        }

        public int DoExecute(string sql)
        {
            _Command.CommandText = sql;
            return _Command.ExecuteNonQuery();
        }

        public int ImportSql(string sqlFile, SqlConfig sqlCfg)
        {
            return 0;
        }

        public int ImportCsv(string csvFile, CsvConfig csvCfg)
        {
            string name = Path.GetFileNameWithoutExtension(csvFile);
            _Command.CommandText = string.Format("drop table if exists {0}", name);
            _Command.ExecuteNonQuery();

            int cnt = 0;
            using (StreamReader reader = new StreamReader(csvFile))
            {
                string line = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    return -1;
                }
                string[] header = line.Split(csvCfg.Seperator);
                StringBuilder create = new StringBuilder();
                StringBuilder insert = new StringBuilder();
                create.Append(string.Format("CREATE TABLE {0} (", name));
                insert.Append(string.Format("INSERT INTO {0} (", name));
                for (int i = 0; i < header.Length; i += 1)
                {
                    line = (header[i] ?? "").Trim();
                    if (!Regex.IsMatch(line, "^[\\w]+$"))
                    {
                        return -1;
                    }
                    create.Append(string.Format("{0} VARCHAR(8),", line));
                    insert.Append(string.Format("{0},", line));
                }
                create.Remove(create.Length - 1, 1).Append(')');
                _Command.CommandText = create.ToString();
                _Command.ExecuteNonQuery();
                create.Clear();

                insert.Remove(insert.Length - 1, 1).Append(") VALUES ");
                string sql = insert.ToString();
                insert.Clear();

                IDbTransaction trans = _Connect.BeginTransaction();
                string[] detail;
                int idx;
                int max;
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
                    detail = line.Split(csvCfg.Seperator);
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
                    _Command.CommandText = insert.ToString();
                    _Command.ExecuteNonQuery();
                    insert.Clear();
                    cnt += 1;

                    line = reader.ReadLine();
                }
                trans.Commit();

                //Main.ShowAlert(string.Format("成功导入 {0} 条记录！", cnt));
            }
            return cnt;
        }

        public int ImportXml(string xmlFile, XmlConfig xmlCfg)
        {
            return 0;
        }

        public int ExportSql(string sqlFile, SqlConfig sqlCfg)
        {
            return 0;
        }

        public int ExportCsv(string csvFile, CsvConfig csvCfg)
        {
            return 0;
        }

        public int ExportXml(string xmlFile, XmlConfig xmlCfg)
        {
            return 0;
        }
    }
}
