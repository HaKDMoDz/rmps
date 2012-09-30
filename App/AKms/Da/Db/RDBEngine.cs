using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Text;
using Me.Amon.Kms.M;
using Me.Amon.M;
using Me.Amon.Util;

namespace Me.Amon.Da.Db
{
    /// <summary>
    /// 数据库
    /// </summary>
    public class RDBEngine
    {
        #region 全局常量
        public const int OPT_CONFUSE = -2;
        public const int OPT_DELETE = -1;
        public const int OPT_INSERT = 0;
        public const int OPT_DEFAULT = 1;
        public const int OPT_UPDATE = 2;
        #endregion

        #region 全局变量
        private string _DbPath;
        private SQLiteConnection _Connection;
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
        #endregion

        public RDBEngine()
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
        }

        public void Init(AUserModel userModel)
        {
            _DbPath = Path.Combine(userModel.DatHome, CApp.FILE_DB);

            if (!File.Exists(_DbPath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_DbPath));
                DbInit();
            }
        }

        public void CloseConnect()
        {
            if (_Connection != null)
            {
                _Connection.Close();
                _Connection = null;
            }
        }

        private SQLiteConnection BeginConnect
        {
            get
            {
                if (_Connection == null)
                {
                    _Connection = new SQLiteConnection("Data Source=" + _DbPath + ";Version=3;");
                    _Connection.Open();
                }
                if (_Connection.State == ConnectionState.Closed)
                {
                    _Connection.Open();
                }
                return _Connection;
            }
        }

        private void DbInit()
        {
            using (SQLiteTransaction mytransaction = BeginConnect.BeginTransaction())
            {
                using (SQLiteCommand mycommand = _Connection.CreateCommand())
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("CREATE TABLE ").Append(DataConst.C1010100).Append("(");
                    sql.Append(DataConst.C1010101).Append(" INT,");
                    sql.Append(DataConst.C1010102).Append(" INT,");
                    sql.Append(DataConst.C1010103).Append(" VARCHAR(").Append(DataConst.C1010103_SIZE).Append("),");
                    sql.Append(DataConst.C1010104).Append(" VARCHAR(").Append(DataConst.C1010104_SIZE).Append("),");
                    sql.Append(DataConst.C1010105).Append(" VARCHAR(").Append(DataConst.C1010105_SIZE).Append("),");
                    sql.Append(DataConst.C1010106).Append(" VARCHAR(").Append(DataConst.C1010106_SIZE).Append("),");
                    sql.Append(DataConst.C1010107).Append(" VARCHAR(").Append(DataConst.C1010107_SIZE).Append("),");
                    sql.Append(DataConst.C1010108).Append(" VARCHAR(").Append(DataConst.C1010108_SIZE).Append("),");
                    sql.Append(DataConst.C1010109).Append(" VARCHAR(").Append(DataConst.C1010109_SIZE).Append("),");
                    sql.Append(DataConst.C101010A).Append(" TIMESTAMP,");
                    sql.Append(DataConst.C101010B).Append(" TIMESTAMP,");
                    sql.Append("PRIMARY KEY (").Append(DataConst.C1010103).Append(")");
                    sql.Append(")");
                    mycommand.CommandText = sql.ToString();
                    mycommand.ExecuteNonQuery();

                    sql.Clear();
                    sql.Append("CREATE TABLE ").Append(DataConst.C2010100).Append("(");
                    sql.Append(DataConst.C2010101).Append(" INT,");
                    sql.Append(DataConst.C2010102).Append(" VARCHAR(").Append(DataConst.C2010102_SIZE).Append("),");
                    sql.Append(DataConst.C2010103).Append(" VARCHAR(").Append(DataConst.C2010103_SIZE).Append("),");
                    sql.Append(DataConst.C2010104).Append(" VARCHAR(").Append(DataConst.C2010104_SIZE).Append("),");
                    sql.Append(DataConst.C2010105).Append(" VARCHAR(").Append(DataConst.C2010105_SIZE).Append("),");
                    sql.Append(DataConst.C2010106).Append(" VARCHAR(").Append(DataConst.C2010106_SIZE).Append("),");
                    sql.Append(DataConst.C2010107).Append(" VARCHAR(").Append(DataConst.C2010107_SIZE).Append("),");
                    sql.Append(DataConst.C2010108).Append(" TIMESTAMP,");
                    sql.Append(DataConst.C2010109).Append(" TIMESTAMP,");
                    sql.Append("PRIMARY KEY (").Append(DataConst.C2010102).Append(",").Append(DataConst.C2010103).Append(")");
                    sql.Append(")");
                    mycommand.CommandText = sql.ToString();
                    mycommand.ExecuteNonQuery();

                    sql.Clear();
                    sql.Append("CREATE TABLE ").Append(DataConst.C2010200).Append("(");
                    sql.Append(DataConst.C2010201).Append(" INT,");
                    sql.Append(DataConst.C2010202).Append(" INT,");
                    sql.Append(DataConst.C2010203).Append(" VARCHAR(").Append(DataConst.C2010203_SIZE).Append("),");
                    sql.Append(DataConst.C2010204).Append(" VARCHAR(").Append(DataConst.C2010204_SIZE).Append("),");
                    sql.Append(DataConst.C2010205).Append(" VARCHAR(").Append(DataConst.C2010205_SIZE).Append("),");
                    sql.Append(DataConst.C2010206).Append(" VARCHAR(").Append(DataConst.C2010206_SIZE).Append("),");
                    sql.Append(DataConst.C2010207).Append(" VARCHAR(").Append(DataConst.C2010207_SIZE).Append("),");
                    sql.Append(DataConst.C2010208).Append(" VARCHAR(").Append(DataConst.C2010208_SIZE).Append("),");
                    sql.Append(DataConst.C2010209).Append(" TIMESTAMP,");
                    sql.Append(DataConst.C201020A).Append(" TIMESTAMP,");
                    sql.Append("PRIMARY KEY (").Append(DataConst.C2010203).Append(")");
                    sql.Append(")");
                    mycommand.CommandText = sql.ToString();
                    mycommand.ExecuteNonQuery();

                    sql.Clear();
                    sql.Append("CREATE TABLE ").Append(DataConst.P3100100).Append("(");
                    sql.Append(DataConst.P3100101).Append(" INT,");
                    sql.Append(DataConst.P3100102).Append(" INT,");
                    sql.Append(DataConst.P3100103).Append(" VARCHAR(").Append(DataConst.P3100103_SIZE).Append("),");
                    sql.Append(DataConst.P3100104).Append(" VARCHAR(").Append(DataConst.P3100104_SIZE).Append("),");
                    sql.Append(DataConst.P3100105).Append(" VARCHAR(").Append(DataConst.P3100105_SIZE).Append("),");
                    sql.Append(DataConst.P3100106).Append(" VARCHAR(").Append(DataConst.P3100106_SIZE).Append("),");
                    sql.Append(DataConst.P3100107).Append(" TIMESTAMP,");
                    sql.Append(DataConst.P3100108).Append(" TIMESTAMP,");
                    sql.Append("PRIMARY KEY (").Append(DataConst.P3100103).Append(")");
                    sql.Append(")");
                    mycommand.CommandText = sql.ToString();
                    mycommand.ExecuteNonQuery();

                    sql.Clear();
                    sql.Append("CREATE TABLE ").Append(DataConst.P3100200).Append("(");
                    sql.Append(DataConst.P3100201).Append(" VARCHAR(").Append(DataConst.P3100201_SIZE).Append("),");
                    sql.Append(DataConst.P3100202).Append(" VARCHAR(").Append(DataConst.P3100202_SIZE).Append("),");
                    sql.Append("PRIMARY KEY (").Append(DataConst.P3100201).Append(",").Append(DataConst.P3100202).Append(")");
                    sql.Append(")");
                    mycommand.CommandText = sql.ToString();
                    mycommand.ExecuteNonQuery();

                    sql.Clear();
                    sql.Append("CREATE TABLE ").Append(DataConst.P3100300).Append("(");
                    sql.Append(DataConst.P3100301).Append(" VARCHAR(").Append(DataConst.P3100301_SIZE).Append("),");
                    sql.Append(DataConst.P3100302).Append(" VARCHAR(").Append(DataConst.P3100302_SIZE).Append("),");
                    sql.Append("PRIMARY KEY (").Append(DataConst.P3100301).Append(",").Append(DataConst.P3100302).Append(")");
                    sql.Append(")");
                    mycommand.CommandText = sql.ToString();
                    mycommand.ExecuteNonQuery();

                    sql.Clear();
                    sql.Append("CREATE TABLE ").Append(DataConst.P3100500).Append("(");
                    sql.Append(DataConst.P3100501).Append(" INT,");
                    sql.Append(DataConst.P3100502).Append(" VARCHAR(").Append(DataConst.P3100502_SIZE).Append("),");
                    sql.Append(DataConst.P3100503).Append(" VARCHAR(").Append(DataConst.P3100503_SIZE).Append("),");
                    sql.Append(DataConst.P3100504).Append(" VARCHAR(").Append(DataConst.P3100504_SIZE).Append("),");
                    sql.Append(DataConst.P3100505).Append(" INT,");
                    sql.Append(DataConst.P3100506).Append(" INT,");
                    sql.Append(DataConst.P3100507).Append(" INT,");
                    sql.Append(DataConst.P3100508).Append(" INT,");
                    sql.Append(DataConst.P3100509).Append(" VARCHAR(").Append(DataConst.P3100509_SIZE).Append("),");
                    sql.Append(DataConst.P310050A).Append(" VARCHAR(").Append(DataConst.P310050A_SIZE).Append("),");
                    sql.Append(DataConst.P310050B).Append(" VARCHAR(").Append(DataConst.P310050B_SIZE).Append("),");
                    sql.Append(DataConst.P310050C).Append(" VARCHAR(").Append(DataConst.P310050C_SIZE).Append("),");
                    sql.Append(DataConst.P310050D).Append(" VARCHAR(").Append(DataConst.P310050D_SIZE).Append("),");
                    sql.Append(DataConst.P310050E).Append(" VARCHAR(").Append(DataConst.P310050E_SIZE).Append("),");
                    sql.Append(DataConst.P310050F).Append(" VARCHAR(").Append(DataConst.P310050F_SIZE).Append("),");
                    sql.Append("PRIMARY KEY (").Append(DataConst.P3100502).Append(")");
                    sql.Append(")");
                    mycommand.CommandText = sql.ToString();
                    mycommand.ExecuteNonQuery();

                    sql.Clear();
                    sql.Append("CREATE TABLE ").Append(DataConst.P3100600).Append("(");
                    sql.Append(DataConst.P3100601).Append(" INT,");
                    sql.Append(DataConst.P3100602).Append(" VARCHAR(").Append(DataConst.P3100602_SIZE).Append("),");
                    sql.Append(DataConst.P3100603).Append(" INT,");
                    sql.Append(DataConst.P3100604).Append(" INT,");
                    sql.Append(DataConst.P3100605).Append(" VARCHAR(").Append(DataConst.P3100605_SIZE).Append("),");
                    sql.Append(DataConst.P310050A).Append(" VARCHAR(").Append(DataConst.P310050A_SIZE).Append("),");
                    sql.Append(DataConst.P310050B).Append(" VARCHAR(").Append(DataConst.P310050B_SIZE).Append("),");
                    sql.Append("PRIMARY KEY (").Append(DataConst.P3100601).Append(",").Append(DataConst.P3100602).Append(",").Append(DataConst.P3100603).Append(")");
                    sql.Append(")");
                    mycommand.CommandText = sql.ToString();
                    mycommand.ExecuteNonQuery();

                    sql.Clear();
                    sql.Append("CREATE TABLE ").Append(DataConst.P3100700).Append("(");
                    sql.Append(DataConst.P3100701).Append(" INT,");
                    sql.Append(DataConst.P3100702).Append(" VARCHAR(").Append(DataConst.P3100702_SIZE).Append("),");
                    sql.Append(DataConst.P3100703).Append(" VARCHAR(").Append(DataConst.P3100703_SIZE).Append("),");
                    sql.Append("PRIMARY KEY (").Append(DataConst.P3100701).Append(",").Append(DataConst.P3100702).Append(",").Append(DataConst.P3100703).Append(")");
                    sql.Append(")");
                    mycommand.CommandText = sql.ToString();
                    mycommand.ExecuteNonQuery();

                    if (File.Exists(""))
                    {
                        StreamReader reader = File.OpenText("");
                        string line = reader.ReadLine();
                        while (line != null)
                        {
                            mycommand.CommandText = line;
                            mycommand.ExecuteNonQuery();
                            line = reader.ReadLine();
                        }
                    }
                }
                mytransaction.Commit();
            }
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

        public void AddVcs(string vcsCol, string optCol)
        {
            _ParamList.Add(vcsCol);
            _SignList.Add("=");
            _ValueList.Add("1");

            _ParamList.Add(optCol);
            _SignList.Add("=");
            _ValueList.Add(OPT_INSERT.ToString());
        }

        public void AddVcs(string vcsCol, string optCol, int lastOpt, int nextOpt)
        {
            if (lastOpt == OPT_DEFAULT)
            {
                _ParamList.Add(vcsCol);
                _SignList.Add("=");
                _ValueList.Add(vcsCol + "+1");
            }

            if (lastOpt > OPT_INSERT || nextOpt == OPT_DELETE)
            {
                _ParamList.Add(optCol);
                _SignList.Add("=");
                _ValueList.Add(nextOpt.ToString());
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
            using (SQLiteTransaction mytransaction = BeginConnect.BeginTransaction())
            {
                using (SQLiteCommand mycommand = _Connection.CreateCommand())
                {
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
            using (SQLiteCommand mycommand = _Connection.CreateCommand())
            {
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
            using (SQLiteTransaction mytransaction = BeginConnect.BeginTransaction())
            {
                using (SQLiteCommand mycommand = _Connection.CreateCommand())
                {
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

            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlSelect, BeginConnect))
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
            using (SQLiteTransaction mytransaction = BeginConnect.BeginTransaction())
            {
                using (SQLiteCommand mycommand = _Connection.CreateCommand())
                {
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
            using (SQLiteTransaction mytransaction = BeginConnect.BeginTransaction())
            {
                using (SQLiteCommand mycommand = _Connection.CreateCommand())
                {
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
            using (SQLiteTransaction mytransaction = BeginConnect.BeginTransaction())
            {
                using (SQLiteCommand mycommand = _Connection.CreateCommand())
                {
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
            using (SQLiteTransaction mytransaction = BeginConnect.BeginTransaction())
            {
                using (SQLiteCommand mycommand = _Connection.CreateCommand())
                {
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
