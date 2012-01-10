using System;
using System.Collections;
using System.Data;
using System.Data.SQLite;
using System.Text;
using Me.Amon.Model;
using Me.Amon.Util;

namespace Me.Amon.DA
{
    /// <summary>
    /// 数据库
    /// </summary>
    public class DBAccess
    {
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
        private readonly ArrayList _ParamList;

        /// <summary>
        /// 符号持有变量
        /// </summary>
        private readonly ArrayList _SignList;

        /// <summary>
        /// 当前要操作的表格名称（列表（以逗号“,”分隔符区分））
        /// </summary>
        private readonly StringBuilder _TableList;

        /// <summary>
        /// 数据插入时数据列表（以逗号“,”分隔符区分）
        /// </summary>
        private readonly ArrayList _ValueList;

        /// <summary>
        /// 数据库操作时的关联条件列表（以逗号“,”分隔符区分）
        /// </summary>
        private readonly StringBuilder _WhereList;

        private int _MinLimit;
        private int _MaxLimit;


        public DBAccess(UserModel userModel)
        {
            _Connection = new SQLiteConnection("Data Source=dat\\amon.db3;Version=3;");
            _Connection.Open();

            // 参数列表
            _ParamList = new ArrayList();
            // 关联符号
            _SignList = new ArrayList();
            // 数据列表
            _ValueList = new ArrayList();
            // 字段缓冲
            _ColumList = new StringBuilder();
            // 表格缓冲
            _TableList = new StringBuilder();
            // 关联每件缓冲
            _WhereList = new StringBuilder();
            // 排序依据缓冲
            _OrderList = new StringBuilder();
        }

        /// <summary>
        /// 添加要使用的表格
        /// </summary>
        /// <param name="table"></param>
        public void AddTable(String table)
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
        public void AddTable(String table, String alies)
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
        public void AddTable(String tableLeft, String tableRight, String joinStyle)
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
        public void AddTable(String tableLeft,
                             String tableRight,
                             String joinStyle,
                             String columnLeft,
                             String columnRight)
        {
            _TableList.Append(", ").Append(tableLeft).Append(' ').Append(joinStyle).Append(' ').Append(tableRight);
            _TableList.Append(" ON ").Append(columnLeft).Append(" = ").Append(columnRight);
        }

        /// <summary>
        /// 添加查寻字段<br></br>
        /// SELECT colname1, colname2, ... FROM tablename
        /// </summary>
        /// <param name="colname">对于于要查寻的表格的相关字段</param>
        public void AddColumn(String colname)
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
        public void AddColumn(String colname, String alies)
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
        public void AddParam(String key, String value)
        {
            AddParam(key, value, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AddParam(String key, long value)
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
        public void AddParam(String key, String value, bool isLiteral)
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
        public void AddParam(String param, String sign, String value, bool isLiteral)
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
        public void AddParam(String param, String sign, long value)
        {
            _ParamList.Add(param);
            _SignList.Add(sign);
            _ValueList.Add(value.ToString());
        }

        /// <summary>
        /// 用户自定义关联条件
        /// </summary>
        /// <param name="where"></param>
        public void AddWhere(String where)
        {
            _WhereList.Append(" AND (").Append(where).Append(") ");
        }

        /// <summary>
        /// 添加WHERE查寻条件，默认运算符为等号“=”，默认值为纯文本<br>
        /// UPDATE tablename SET ... WHERE key1=value1 AND key2=value2 ...
        /// </summary>
        /// <param name="key">参照数据库表格字段名</param>
        /// <param name="value">参照值</param>
        public void AddWhere(String key, String value)
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
        public void AddWhere(String key, String value, bool isLiteral)
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
        public void AddWhere(String key, String sign, String value, bool isLiteral)
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
        public void AddSort(String key)
        {
            AddSort(key, true);
        }

        /// <summary>
        /// 添加排序依据<br>
        /// SELECT * FROM tablename WHERE ... ORDER BY key1 value1, key2 value2, ...
        /// </summary>
        /// <param name="key">参照数据库表格字段</param>
        /// <param name="asc">排序方法:true:ASC表示升序;false:DESC表示降序</param>
        public void AddSort(String key, bool asc)
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

        /// <summary>
        /// 数据库查寻
        /// </summary>
        /// <param name="sqlSelect">查寻语句</param>
        /// <returns>查寻结果集</returns>
        public DataTable ExecuteSelect(String sqlSelect)
        {
            DataTable dataList = new DataTable();

            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlSelect, _Connection))
            {
                adapter.Fill(dataList);
            }

            return dataList;
        }

        /// <summary>
        /// 数据库更新
        /// </summary>
        /// <param name="sqlUpdate">更新语句</param>
        /// <returns>当前操作所影响的行数</returns>
        public int ExecuteUpdate(String sqlUpdate)
        {
            int n = 0;
            using (SQLiteTransaction mytransaction = _Connection.BeginTransaction())
            {
                using (SQLiteCommand mycommand = new SQLiteCommand(_Connection))
                {
                    mycommand.CommandText = sqlUpdate;
                    n = mycommand.ExecuteNonQuery();
                }
                mytransaction.Commit();
            }
            return n;
        }

        /// <summary>
        /// 数据库插入
        /// </summary>
        /// <param name="sqlInsert">插入语句</param>
        /// <returns>当前操作所影响的行数</returns>
        public int ExecuteInsert(String sqlInsert)
        {
            int n = 0;
            using (SQLiteTransaction mytransaction = _Connection.BeginTransaction())
            {
                using (SQLiteCommand mycommand = new SQLiteCommand(_Connection))
                {
                    mycommand.CommandText = sqlInsert;
                    n = mycommand.ExecuteNonQuery();
                }
                mytransaction.Commit();
            }

            return n;
        }

        /// <summary>
        /// 数据库删除
        /// </summary>
        /// <param name="sqlDelete">删除语句</param>
        /// <returns>当前操作所影响的行数</returns>
        public int ExecuteDelete(String sqlDelete)
        {
            int n = 0;
            using (SQLiteTransaction mytransaction = _Connection.BeginTransaction())
            {
                using (SQLiteCommand mycommand = new SQLiteCommand(_Connection))
                {
                    mycommand.CommandText = sqlDelete;
                    n = mycommand.ExecuteNonQuery();
                }
                mytransaction.Commit();
            }

            return n;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlBackup"></param>
        /// <returns></returns>
        public int ExecuteBackup(String sqlBackup)
        {
            // MySQL
            //MySqlConnection mySqlConn = getConnection();
            //MySqlCommand mySqlComm = new MySqlCommand();
            //mySqlComm.Connection = mySqlConn;
            //mySqlComm.CommandType = CommandType.Text;
            //mySqlComm.CommandText = sqlBackup;

            //int n = mySqlComm.ExecuteNonQuery();

            //mySqlComm.Dispose();
            //mySqlConn.Close();

            //return n;
            return 0;
        }
    }
}
