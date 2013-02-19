using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using Me.Amon.Bean;
using Me.Amon.Util;
using MySql.Data.MySqlClient;

namespace Me.Amon.Da
{
    /// <summary>
    /// 数据库
    /// </summary>
    public class DBAccess
    {
        private MySqlConnection _Connection;
        /// <summary>
        /// 当前要操作的字段名称（列表（以逗号“,”分隔符区分））
        /// </summary>
        private readonly StringBuilder _ColumList;

        /// <summary>
        /// 数据库查寻时的排序依据（列表（以逗号“,”分隔符区分））
        /// </summary>
        private readonly StringBuilder _OrderList;

        /// <summary>
        /// 数据KEY-VALUE对持有变量
        /// </summary>
        private readonly List<string> _ParamList;

        /// <summary>
        /// 符号持有变量
        /// </summary>
        private readonly List<string> _SignList;

        /// <summary>
        /// 当前要操作的表格名称（列表（以逗号“,”分隔符区分））
        /// </summary>
        private readonly StringBuilder _TableList;

        /// <summary>
        /// 数据插入时数据列表（以逗号“,”分隔符区分）
        /// </summary>
        private readonly List<string> _ValueList;

        /// <summary>
        /// 数据库操作时的关联条件列表（以逗号“,”分隔符区分）
        /// </summary>
        private readonly StringBuilder _WhereList;
        private readonly List<string> _BatchList;

        private int _MinLimit;
        private int _MaxLimit;

        public DBAccess()
        {
            // 参数列表
            _ParamList = new List<string>();
            // 关联符号
            _SignList = new List<string>();
            // 数据列表
            _ValueList = new List<string>();
            // 字段缓冲
            _ColumList = new StringBuilder();
            // 表格缓冲
            _TableList = new StringBuilder();
            // 关联每件缓冲
            _WhereList = new StringBuilder();
            // 排序依据缓冲
            _OrderList = new StringBuilder();
            _BatchList = new List<string>();

            _Connection = new MySqlConnection(string.Format(ConfigurationManager.ConnectionStrings["SQLServer"].ConnectionString, "amonyao", "amonyao", "amonyao123"));
            _Connection.Open();
        }

        /// <summary>
        /// 添加要使用的表格
        /// </summary>
        /// <param name="table"></param>
        public void AddTable(string table)
        {
            if (CharUtil.IsValidate(table))
            {
                _TableList.Append(", ").Append(table);
            }
        }

        /// <summary>
        /// 添加要使用的表格
        /// </summary>
        /// <param name="table"></param>
        /// <param name="alies"></param>
        public void AddTable(string table, string alies)
        {
            if (CharUtil.IsValidate(table))
            {
                _TableList.Append(", ").Append(table).Append(" AS ").Append(alies);
            }
        }

        /// <summary>
        /// 添加带连接的表格
        /// </summary>
        /// <param name="tableLeft"></param>
        /// <param name="tableRight"></param>
        /// <param name="joinStyle"></param>
        public void AddTable(string tableLeft, string tableRight, string joinStyle)
        {
            _TableList.Append(", ").Append(tableLeft).Append(' ').Append(joinStyle).Append(' ').Append(tableRight);
        }

        /// <summary>
        /// 添加带连接的表格
        /// </summary>
        /// <param name="tableLeft"></param>
        /// <param name="tableRight"></param>
        /// <param name="joinStyle"></param>
        /// <param name="columnLeft"></param>
        /// <param name="columnRight"></param>
        public void AddTable(string tableLeft,
                             string tableRight,
                             string joinStyle,
                             string columnLeft,
                             string columnRight)
        {
            _TableList.Append(", ").Append(tableLeft).Append(' ').Append(joinStyle).Append(' ').Append(tableRight);
            _TableList.Append(" ON ").Append(columnLeft).Append(" = ").Append(columnRight);
        }

        /// <summary>
        /// 添加查寻字段<br></br>
        /// SELECT colname1, colname2, ... FROM tablename
        /// </summary>
        /// <param name="colname">对于于要查寻的表格的相关字段</param>
        public void AddColumn(string colname)
        {
            if (CharUtil.IsValidate(colname))
            {
                _ColumList.Append(", ").Append(colname);
            }
        }

        /// <summary>
        /// 添加查寻字段<br></br>
        /// SELECT colname1 AS col1, colname2 AS col2, ... FROM tablename
        /// </summary>
        /// <param name="colname">对于于要查寻的表格的相关字段</param>
        /// <param name="alies">字段别名</param>
        public void AddColumn(string colname, string alies)
        {
            if (CharUtil.IsValidate(colname))
            {
                _ColumList.Append(", ").Append(colname).Append(" AS ").Append(alies);
            }
        }

        /// <summary>
        /// 数据更新：添加数据库操作的KEY-VALUE对。<br>
        /// UPDATE SET key1=value1, key2=value2 ... 
        /// </summary>
        /// <param name="key">数据库字段名</param>
        /// <param name="value">对应字段的值</param>
        public void AddParam(string key, string value)
        {
            AddParam(key, value, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AddParam(string key, long value)
        {
            AddParam(key, "=", value);
        }

        /// <summary>
        /// 数据更新：添加数据库操作的KEY-VALUE对。
        /// UPDATE SET key1=value1, key2=value2 ... 
        /// </summary>
        /// <param name="key">数据库字段名</param>
        /// <param name="value">对应字段的值</param>
        /// <param name="isLiteral">当前字段是否为纯文本，true为纯文本，false为其它格式。</param>
        public void AddParam(string key, string value, bool isLiteral)
        {
            AddParam(key, "=", value, isLiteral);
        }

        /// <summary>
        /// 数据更新：添加数据库操作的KEY-VALUE对。
        /// </summary>
        /// <param name="param">数据库字段名</param>
        /// <param name="sign">运算操作符</param>
        /// <param name="value">对应字段的值</param>
        /// <param name="isLiteral">当前字段是否为纯文本，true为纯文本，false为其它格式。</param>
        public void AddParam(string param, string sign, string value, bool isLiteral)
        {
            if (CharUtil.IsValidate(param))
            {
                _ParamList.Add(param);
                _SignList.Add(sign);

                // 值信息处理
                if (value == null)
                {
                    _ValueList.Add("NULL");
                }
                else if (isLiteral)
                {
                    _ValueList.Add(" '" + value + "'");
                }
                else
                {
                    _ValueList.Add(value);
                }
            }
        }

        /// <summary>
        /// 数据更新：添加数据库操作的KEY-VALUE对。
        /// </summary>
        /// <param name="param">数据库字段名</param>
        /// <param name="sign">运算操作符</param>
        /// <param name="value">对应字段的值</param>
        public void AddParam(string param, string sign, long value)
        {
            _ParamList.Add(param);
            _SignList.Add(sign);
            _ValueList.Add(value.ToString());
        }

        public void AddVcs(string optCol, string vcsCol)
        {
            _ParamList.Add(optCol);
            _SignList.Add("=");
            _ValueList.Add(Vcs.OPT_INSERT.ToString());

            _ParamList.Add(vcsCol);
            _SignList.Add("=");
            _ValueList.Add("1");
        }

        public void AddVcs(string vcsCol, string optCol, int lastOpt, int nextOpt)
        {
            if (lastOpt > Vcs.OPT_INSERT || nextOpt == Vcs.OPT_DELETE)
            {
                _ParamList.Add(optCol);
                _SignList.Add("=");
                _ValueList.Add(nextOpt.ToString());
            }

            if (lastOpt == Vcs.OPT_DEFAULT)
            {
                _ParamList.Add(vcsCol);
                _SignList.Add("=");
                _ValueList.Add(vcsCol + "+1");
            }
        }

        /// <summary>
        /// 用户自定义关联条件
        /// </summary>
        /// <param name="where"></param>
        public void AddWhere(string where)
        {
            _WhereList.Append(" AND (").Append(where).Append(") ");
        }

        /// <summary>
        /// 添加WHERE查寻条件，默认运算符为等号“=”，默认值为纯文本<br>
        /// UPDATE tablename SET ... WHERE key1=value1 AND key2=value2 ...
        /// </summary>
        /// <param name="key">参照数据库表格字段名</param>
        /// <param name="value">参照值</param>
        public void AddWhere(string key, string value)
        {
            AddWhere(key, value, true);
        }

        /// <summary>
        /// 添加WHERE查寻条件，默认运算符为等号“=”<br>
        /// UPDATE tablename SET ... WHERE key1=value1 AND key2=value2 ...
        /// </summary>
        /// <param name="key">参照数据库表格字段名</param>
        /// <param name="value">参照值</param>
        /// <param name="isLiteral">是否为纯文本字符串，true为纯文本，false为非文本</param>
        public void AddWhere(string key, string value, bool isLiteral)
        {
            AddWhere(key, "=", value, isLiteral);
        }

        /// <summary>
        /// 添加WHERE查寻条件<br>
        /// UPDATE tablename SET ... WHERE key1=value1 AND key2=value2 ...
        /// </summary>
        /// <param name="key">参照数据库表格字段名</param>
        /// <param name="sign">参照运算符，如+、-、=、!=等</param>
        /// <param name="value">参照值</param>
        /// <param name="isLiteral">是否为纯文本字符串，true为纯文本，false为非文本</param>
        public void AddWhere(string key, string sign, string value, bool isLiteral)
        {
            if (CharUtil.IsValidate(key) && value != null && CharUtil.IsValidate(sign))
            {
                _WhereList.Append(" AND ").Append(key);
                _WhereList.Append(" ").Append(sign);

                // 值信息处理
                if (isLiteral)
                {
                    _WhereList.Append(" '").Append(value).Append("'");
                }
                else
                {
                    _WhereList.Append(" ").Append(value);
                }
            }
        }

        /// <summary>
        /// 默认升序排序
        /// </summary>
        /// <param name="key"></param>
        public void AddSort(string key)
        {
            AddSort(key, true);
        }

        /// <summary>
        /// 添加排序依据<br>
        /// SELECT * FROM tablename WHERE ... ORDER BY key1 value1, key2 value2, ...
        /// </summary>
        /// <param name="key">参照数据库表格字段</param>
        /// <param name="asc">排序方法:true:ASC表示升序;false:DESC表示降序</param>
        public void AddSort(string key, bool asc)
        {
            if (CharUtil.IsValidate(key))
            {
                _OrderList.Append(", ").Append(key);
                _OrderList.Append(" ").Append(asc ? "ASC" : "DESC");
            }
        }

        public void AddLimit(int limit)
        {
            AddLimit(0, limit);
        }

        public void AddLimit(int min, int max)
        {
            if (min < 0 || max < min)
            {
                return;
            }

            _MinLimit = min;
            _MaxLimit = max;
        }

        public void ReInit()
        {
            _ParamList.Clear();
            _SignList.Clear();
            _ValueList.Clear();
            _ColumList.Clear();
            _TableList.Clear();
            _WhereList.Clear();
            _OrderList.Clear();
        }

        public void AddBatch(string sql)
        {
            _BatchList.Add(sql);
        }

        /// <summary>
        /// 数据库查寻
        /// </summary>
        /// <param name="sql">查寻语句</param>
        /// <returns>查寻结果集</returns>
        public int Execute(string sql)
        {
            int n = 0;
            using (MySqlTransaction mytransaction = _Connection.BeginTransaction())
            {
                using (MySqlCommand mycommand = new MySqlCommand())
                {
                    mycommand.Connection = _Connection;
                    mycommand.CommandText = sql;
                    n = mycommand.ExecuteNonQuery();
                }
                mytransaction.Commit();
            }
            return n;
        }

        public object ExecuteScalar()
        {
            return ExecuteScalar(GenSelectSQL());
        }

        public object ExecuteScalar(string sql)
        {
            using (MySqlCommand mycommand = new MySqlCommand())
            {
                mycommand.Connection = _Connection;
                mycommand.CommandText = sql;
                return mycommand.ExecuteScalar();
            }
        }

        public int ExecuteBatch()
        {
            int n = ExecuteBatch(_BatchList);
            _BatchList.Clear();
            return n;
        }

        public int ExecuteBatch(List<string> sqls)
        {
            int n = 0;
            using (MySqlTransaction mytransaction = _Connection.BeginTransaction())
            {
                using (MySqlCommand mycommand = new MySqlCommand())
                {
                    mycommand.Connection = _Connection;
                    foreach (string sql in sqls)
                    {
                        mycommand.CommandText = sql;
                        n += mycommand.ExecuteNonQuery();
                    }
                }
                mytransaction.Commit();
            }
            return n;
        }

        public DataTable ExecuteSelect()
        {
            return ExecuteSelect(GenSelectSQL());
        }

        /// <summary>
        /// 数据库查寻
        /// </summary>
        /// <param name="sqlSelect">查寻语句</param>
        /// <returns>查寻结果集</returns>
        public DataTable ExecuteSelect(string sqlSelect)
        {
            DataTable dataList = new DataTable();

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(sqlSelect, _Connection))
            {
                adapter.Fill(dataList);
            }

            return dataList;
        }

        public int ExecuteUpdate()
        {
            return ExecuteUpdate(GenUpdateSQL());
        }

        /// <summary>
        /// 数据库更新
        /// </summary>
        /// <param name="sqlUpdate">更新语句</param>
        /// <returns>当前操作所影响的行数</returns>
        public int ExecuteUpdate(string sqlUpdate)
        {
            int n = 0;
            using (MySqlTransaction mytransaction = _Connection.BeginTransaction())
            {
                using (MySqlCommand mycommand = new MySqlCommand())
                {
                    mycommand.Connection = _Connection;
                    mycommand.CommandText = sqlUpdate;
                    n = mycommand.ExecuteNonQuery();
                }
                mytransaction.Commit();
            }
            return n;
        }

        public void AddUpdateBatch()
        {
            _BatchList.Add(GenUpdateSQL());
        }

        public int ExecuteInsert()
        {
            return ExecuteInsert(GenInsertSQL());
        }

        /// <summary>
        /// 数据库插入
        /// </summary>
        /// <param name="sqlInsert">插入语句</param>
        /// <returns>当前操作所影响的行数</returns>
        public int ExecuteInsert(string sqlInsert)
        {
            int n = 0;
            using (MySqlTransaction mytransaction = _Connection.BeginTransaction())
            {
                using (MySqlCommand mycommand = new MySqlCommand())
                {
                    mycommand.Connection = _Connection;
                    mycommand.CommandText = sqlInsert;
                    n = mycommand.ExecuteNonQuery();
                }
                mytransaction.Commit();
            }

            return n;
        }

        public void AddInsertBatch()
        {
            _BatchList.Add(GenInsertSQL());
        }

        public int ExecuteDelete()
        {
            return ExecuteDelete(GenDeleteSQL());
        }

        /// <summary>
        /// 数据库删除
        /// </summary>
        /// <param name="sqlDelete">删除语句</param>
        /// <returns>当前操作所影响的行数</returns>
        public int ExecuteDelete(string sqlDelete)
        {
            int n = 0;
            using (MySqlTransaction mytransaction = _Connection.BeginTransaction())
            {
                using (MySqlCommand mycommand = new MySqlCommand())
                {
                    mycommand.Connection = _Connection;
                    mycommand.CommandText = sqlDelete;
                    n = mycommand.ExecuteNonQuery();
                }
                mytransaction.Commit();
            }

            return n;
        }

        public void AddDeleteBatch()
        {
            _BatchList.Add(GenDeleteSQL());
        }

        public int ExecuteBackup(string t, string f)
        {
            return ExecuteBackup(GenBackupSQL(t, f));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlBackup"></param>
        /// <returns></returns>
        public int ExecuteBackup(string sqlBackup)
        {
            int n = 0;
            using (MySqlTransaction mytransaction = _Connection.BeginTransaction())
            {
                using (MySqlCommand mycommand = new MySqlCommand())
                {
                    mycommand.Connection = _Connection;
                    mycommand.CommandText = sqlBackup;
                    n = mycommand.ExecuteNonQuery();
                }
                mytransaction.Commit();
            }

            return n;
        }

        public void AddBackupBatch(string t, string f)
        {
            _BatchList.Add(GenBackupSQL(t, f));
        }

        /// <summary>
        /// 获取数据库查寻SQL语句
        /// </summary>
        /// <returns>SQL语句，若操作表格为空，则返回空语句</returns>
        private string GenSelectSQL()
        {
            // 数据合法性判断
            if (_TableList.Length < 1)
            {
                return "";
            }

            StringBuilder sqlBuf = new StringBuilder();

            // 查寻字段拼接
            sqlBuf.Append("SELECT ");
            if (_ColumList.Length > 0)
            {
                sqlBuf.Append(_ColumList.ToString().Substring(2));
            }
            else
            {
                sqlBuf.Append("*");
            }

            // 查寻表格拼接
            sqlBuf.Append(" FROM ").Append(_TableList.ToString().Substring(2));

            // 查寻关联条件拼接
            if (_WhereList.Length > 0)
            {
                sqlBuf.Append(" WHERE ").Append(_WhereList.ToString().Substring(5));
            }

            // 排序依据拼接
            if (_OrderList.Length > 0)
            {
                sqlBuf.Append(" ORDER BY ").Append(_OrderList.ToString().Substring(2));
            }

            if (_MaxLimit > 0)
            {
                sqlBuf.Append(" LIMIT ").Append(_MinLimit).Append(',').Append(_MaxLimit);
            }

            return sqlBuf.ToString();
        }

        /// <summary>
        /// 获取数据库更新SQL语句
        /// </summary>
        /// <returns>SQL语句，若操作表格为空，则返回空语句</returns>
        private string GenUpdateSQL()
        {
            // 数据合法性判断
            if (_TableList.Length < 1 || _ParamList.Count < 1)
            {
                return "";
            }

            StringBuilder sqlBuf = new StringBuilder();

            // 更新表格拼接
            sqlBuf.Append("UPDATE ").Append(_TableList.ToString().Substring(2)).Append(" SET ");

            // 更新字段及值拼接
            int idx = 0;
            for (int j = _ParamList.Count - 1; idx < j; idx += 1)
            {
                sqlBuf.Append(_ParamList[idx]);
                sqlBuf.Append(_SignList[idx]);
                sqlBuf.Append(_ValueList[idx]);
                sqlBuf.Append(", ");
            }
            sqlBuf.Append(_ParamList[idx]);
            sqlBuf.Append(_SignList[idx]);
            sqlBuf.Append(_ValueList[idx]);

            // 参照条件拼接
            if (_WhereList.Length > 0)
            {
                sqlBuf.Append(" WHERE ").Append(_WhereList.ToString().Substring(5));
            }
            return sqlBuf.ToString();
        }

        /// <summary>
        /// 获取数据库插入SQL语句
        /// </summary>
        /// <returns>SQL语句，若操作表格为空，则返回空语句</returns>
        private string GenInsertSQL()
        {
            // 数据合法性判断
            if (_TableList.Length < 1)
            {
                return "";
            }

            StringBuilder sqlBuf = new StringBuilder();

            // 数据库表格拼接
            sqlBuf.Append(" INSERT INTO ").Append(_TableList.ToString().Substring(2));

            // 要插入字段拼接
            sqlBuf.Append(" (");
            int idx = 0;
            for (int j = _ParamList.Count - 1; idx < j; idx += 1)
            {
                sqlBuf.Append(_ParamList[idx]);
                sqlBuf.Append(", ");
            }
            sqlBuf.Append(_ParamList[idx]);
            sqlBuf.Append(")");

            // 插入数据拼接
            sqlBuf.Append(" VALUES (");
            idx = 0;
            for (int j = _ValueList.Count - 1; idx < j; idx += 1)
            {
                sqlBuf.Append(_ValueList[idx]);
                sqlBuf.Append(", ");
            }
            sqlBuf.Append(_ValueList[idx]);
            sqlBuf.Append(")");

            return sqlBuf.ToString();
        }

        /// <summary>
        /// 获取数据库删除SQL语句
        /// </summary>
        /// <returns>SQL语句，若操作表格为空，则返回空语句</returns>
        private string GenDeleteSQL()
        {
            // 数据合法性判断
            if (_TableList.Length < 1)
            {
                return "";
            }

            StringBuilder sqlBuf = new StringBuilder();

            // 数据库表格拼接
            sqlBuf.Append("DELETE FROM ").Append(_TableList.ToString().Substring(2));

            // 关联条件拼接
            sqlBuf.Append(" WHERE ").Append(_WhereList.ToString().Substring(5));

            return sqlBuf.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        private string GenBackupSQL(string t, string f)
        {
            StringBuilder sqlBuf = new StringBuilder();

            // 插入目标
            sqlBuf.Append("INSERT INTO ").Append(t).Append(" (");
            int j = _ParamList.Count - 1;
            for (int i = 0; i < j; i += 1)
            {
                sqlBuf.Append(_ParamList[i]).Append(", ");
            }
            sqlBuf.Append(_ParamList[j]).Append(") ");

            // 复制来源
            sqlBuf.Append(" SELECT ");
            j = _ValueList.Count - 1;
            for (int i = 0; i < j; i += 1)
            {
                sqlBuf.Append(_ValueList[i]).Append(", ");
            }
            sqlBuf.Append(_ValueList[j]);

            sqlBuf.Append(" FROM ").Append(f);
            // 查寻关联条件拼接
            if (_WhereList.Length > 0)
            {
                sqlBuf.Append(" WHERE ").Append(_WhereList.ToString(5, _WhereList.Length - 5));
            }

            return sqlBuf.ToString();
        }
    }
}
