using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Text;
using Me.Amon.Util;
using MySql.Data.MySqlClient;

namespace Me.Amon.DB
{
    /// <summary>
    /// DBAccess 的摘要说明
    /// </summary>
    public class DBAccess
    {
        /// <summary>
        /// 当前要操作的字段名称（列表（以逗号“,”分隔符区分））
        /// </summary>
        private readonly StringBuilder columList;

        /// <summary>
        /// 数据库查寻时的排序依据（列表（以逗号“,”分隔符区分））
        /// </summary>
        private readonly StringBuilder orderList;

        /// <summary>
        /// 数据KEY-VALUE对持有变量
        /// </summary>
        private readonly ArrayList paramList;

        /// <summary>
        /// 符号持有变量
        /// </summary>
        private readonly ArrayList signList;

        /// <summary>
        /// 当前要操作的表格名称（列表（以逗号“,”分隔符区分））
        /// </summary>
        private readonly StringBuilder tableList;

        /// <summary>
        /// 数据插入时数据列表（以逗号“,”分隔符区分）
        /// </summary>
        private readonly ArrayList valueList;

        /// <summary>
        /// 数据库操作时的关联条件列表（以逗号“,”分隔符区分）
        /// </summary>
        private readonly StringBuilder whereList;

        private int minLimit;
        private int maxLimit;

        public DBAccess()
        {
            // 参数列表
            paramList = new ArrayList();
            // 关联符号
            signList = new ArrayList();
            // 数据列表
            valueList = new ArrayList();
            // 字段缓冲
            columList = new StringBuilder();
            // 表格缓冲
            tableList = new StringBuilder();
            // 关联每件缓冲
            whereList = new StringBuilder();
            // 排序依据缓冲
            orderList = new StringBuilder();
        }

        /// <summary>
        /// 连接指定的数据库
        /// </summary>
        /// <returns></returns>
        public MySqlConnection getConnection()
        {
            MySqlConnection mySqlConn = new MySqlConnection(ConfigurationManager.ConnectionStrings["dev"].ConnectionString);
            mySqlConn.Open();

            return mySqlConn;
        }

        /// <summary>
        /// 添加要使用的表格
        /// </summary>
        /// <param name="table"></param>
        public void addTable(String table)
        {
            if (CharUtil.isValidate(table))
            {
                tableList.Append(", ").Append(table);
            }
        }

        /// <summary>
        /// 添加要使用的表格
        /// </summary>
        /// <param name="table"></param>
        /// <param name="alies"></param>
        public void addTable(String table, String alies)
        {
            if (CharUtil.isValidate(table))
            {
                tableList.Append(", ").Append(table).Append(" AS ").Append(alies);
            }
        }

        /// <summary>
        /// 添加带连接的表格
        /// </summary>
        /// <param name="tableLeft"></param>
        /// <param name="tableRight"></param>
        /// <param name="joinStyle"></param>
        public void addTable(String tableLeft, String tableRight, String joinStyle)
        {
            tableList.Append(", ").Append(tableLeft).Append(' ').Append(joinStyle).Append(' ').Append(tableRight);
        }

        /// <summary>
        /// 添加带连接的表格
        /// </summary>
        /// <param name="tableLeft"></param>
        /// <param name="tableRight"></param>
        /// <param name="joinStyle"></param>
        /// <param name="columnLeft"></param>
        /// <param name="columnRight"></param>
        public void addTable(String tableLeft,
                             String tableRight,
                             String joinStyle,
                             String columnLeft,
                             String columnRight)
        {
            tableList.Append(", ").Append(tableLeft).Append(' ').Append(joinStyle).Append(' ').Append(tableRight);
            tableList.Append(" ON ").Append(columnLeft).Append(" = ").Append(columnRight);
        }

        /// <summary>
        /// 添加查寻字段<br></br>
        /// SELECT colname1, colname2, ... FROM tablename
        /// </summary>
        /// <param name="colname">对于于要查寻的表格的相关字段</param>
        public void addColumn(String colname)
        {
            if (CharUtil.isValidate(colname))
            {
                columList.Append(", ").Append(colname);
            }
        }

        /// <summary>
        /// 添加查寻字段<br></br>
        /// SELECT colname1 AS col1, colname2 AS col2, ... FROM tablename
        /// </summary>
        /// <param name="colname">对于于要查寻的表格的相关字段</param>
        /// <param name="alies">字段别名</param>
        public void addColumn(String colname, String alies)
        {
            if (CharUtil.isValidate(colname))
            {
                columList.Append(", ").Append(colname).Append(" AS ").Append(alies);
            }
        }

        /// <summary>
        /// 数据更新：添加数据库操作的KEY-VALUE对。<br>
        /// UPDATE SET key1=value1, key2=value2 ... 
        /// </summary>
        /// <param name="key">数据库字段名</param>
        /// <param name="value">对应字段的值</param>
        public void addParam(String key, String value)
        {
            addParam(key, value, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void addParam(String key, long value)
        {
            addParam(key, "=", value);
        }

        /// <summary>
        /// 数据更新：添加数据库操作的KEY-VALUE对。
        /// UPDATE SET key1=value1, key2=value2 ... 
        /// </summary>
        /// <param name="key">数据库字段名</param>
        /// <param name="value">对应字段的值</param>
        /// <param name="isLiteral">当前字段是否为纯文本，true为纯文本，false为其它格式。</param>
        public void addParam(String key, String value, bool isLiteral)
        {
            addParam(key, "=", value, isLiteral);
        }

        /// <summary>
        /// 数据更新：添加数据库操作的KEY-VALUE对。
        /// </summary>
        /// <param name="param">数据库字段名</param>
        /// <param name="sign">运算操作符</param>
        /// <param name="value">对应字段的值</param>
        /// <param name="isLiteral">当前字段是否为纯文本，true为纯文本，false为其它格式。</param>
        public void addParam(String param, String sign, String value, bool isLiteral)
        {
            if (CharUtil.isValidate(param))
            {
                paramList.Add(param);
                signList.Add(sign);

                // 值信息处理
                if (value == null)
                {
                    valueList.Add("NULL");
                }
                else if (isLiteral)
                {
                    valueList.Add(" '" + value + "'");
                }
                else
                {
                    valueList.Add(value);
                }
            }
        }

        /// <summary>
        /// 数据更新：添加数据库操作的KEY-VALUE对。
        /// </summary>
        /// <param name="param">数据库字段名</param>
        /// <param name="sign">运算操作符</param>
        /// <param name="value">对应字段的值</param>
        public void addParam(String param, String sign, long value)
        {
            paramList.Add(param);
            signList.Add(sign);
            valueList.Add(value.ToString());
        }

        /// <summary>
        /// 用户自定义关联条件
        /// </summary>
        /// <param name="where"></param>
        public void addWhere(String where)
        {
            whereList.Append(" AND (").Append(where).Append(") ");
        }

        /// <summary>
        /// 添加WHERE查寻条件，默认运算符为等号“=”，默认值为纯文本<br>
        /// UPDATE tablename SET ... WHERE key1=value1 AND key2=value2 ...
        /// </summary>
        /// <param name="key">参照数据库表格字段名</param>
        /// <param name="value">参照值</param>
        public void addWhere(String key, String value)
        {
            addWhere(key, value, true);
        }

        /// <summary>
        /// 添加WHERE查寻条件，默认运算符为等号“=”<br>
        /// UPDATE tablename SET ... WHERE key1=value1 AND key2=value2 ...
        /// </summary>
        /// <param name="key">参照数据库表格字段名</param>
        /// <param name="value">参照值</param>
        /// <param name="isLiteral">是否为纯文本字符串，true为纯文本，false为非文本</param>
        public void addWhere(String key, String value, bool isLiteral)
        {
            addWhere(key, "=", value, isLiteral);
        }

        /// <summary>
        /// 添加WHERE查寻条件<br>
        /// UPDATE tablename SET ... WHERE key1=value1 AND key2=value2 ...
        /// </summary>
        /// <param name="key">参照数据库表格字段名</param>
        /// <param name="sign">参照运算符，如+、-、=、!=等</param>
        /// <param name="value">参照值</param>
        /// <param name="isLiteral">是否为纯文本字符串，true为纯文本，false为非文本</param>
        public void addWhere(String key, String sign, String value, bool isLiteral)
        {
            if (CharUtil.isValidate(key) && value != null && CharUtil.isValidate(sign))
            {
                whereList.Append(" AND ").Append(key);
                whereList.Append(" ").Append(sign);

                // 值信息处理
                if (isLiteral)
                {
                    whereList.Append(" '").Append(value).Append("'");
                }
                else
                {
                    whereList.Append(" ").Append(value);
                }
            }
        }

        /// <summary>
        /// 默认升序排序
        /// </summary>
        /// <param name="key"></param>
        public void addSort(String key)
        {
            addSort(key, true);
        }

        /// <summary>
        /// 添加排序依据<br>
        /// SELECT * FROM tablename WHERE ... ORDER BY key1 value1, key2 value2, ...
        /// </summary>
        /// <param name="key">参照数据库表格字段</param>
        /// <param name="asc">排序方法:true:ASC表示升序;false:DESC表示降序</param>
        public void addSort(String key, bool asc)
        {
            if (CharUtil.isValidate(key))
            {
                orderList.Append(", ").Append(key);
                orderList.Append(" ").Append(asc ? "ASC" : "DESC");
            }
        }

        public void addLimit(int limit)
        {
            addLimit(0, limit);
        }

        public void addLimit(int min, int max)
        {
            if (min < 0 || max < min)
            {
                return;
            }

            minLimit = min;
            maxLimit = max;
        }

        /// <summary>
        /// 其它相关的数据库操作，如COMMIT、HSQL专有的SHUTDOWN等。
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <returns>当前操作是否成功</returns>
        public bool execute(String sql)
        {
            return false;
        }

        /// <summary>
        /// 数据库查寻
        /// </summary>
        /// <returns>查寻结果集</returns>
        public DataTable executeSelect()
        {
            return executeSelect(getSelectSQL());
        }

        /// <summary>
        /// 数据库查寻
        /// </summary>
        /// <param name="sqlSelect">查寻语句</param>
        /// <returns>查寻结果集</returns>
        public DataTable executeSelect(String sqlSelect)
        {
            DataTable dataList = new DataTable();

            // MySQL
            MySqlConnection mySqlConn = getConnection();
            MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(sqlSelect, mySqlConn);
            mySqlAdapter.Fill(dataList);
            mySqlAdapter.Dispose();
            mySqlConn.Close();

            return dataList;
        }

        /// <summary>
        /// 数据库更新
        /// </summary>
        /// <returns>当前操作所影响的行数</returns>
        public int executeUpdate()
        {
            return executeUpdate(getUpdateSQL());
        }

        /// <summary>
        /// 数据库更新
        /// </summary>
        /// <param name="sqlUpdate">更新语句</param>
        /// <returns>当前操作所影响的行数</returns>
        public int executeUpdate(String sqlUpdate)
        {
            // MySQL
            MySqlConnection mySqlConn = getConnection();
            MySqlCommand mySqlComm = new MySqlCommand();
            mySqlComm.Connection = mySqlConn;
            mySqlComm.CommandType = CommandType.Text;
            mySqlComm.CommandText = sqlUpdate;

            int n = mySqlComm.ExecuteNonQuery();

            mySqlComm.Dispose();
            mySqlConn.Close();

            return n;
        }

        /// <summary>
        /// 数据库插入
        /// </summary>
        /// <returns>当前操作所影响的行数</returns>
        public int executeInsert()
        {
            return executeInsert(getInsertSQL());
        }

        /// <summary>
        /// 数据库插入
        /// </summary>
        /// <param name="sqlInsert">插入语句</param>
        /// <returns>当前操作所影响的行数</returns>
        public int executeInsert(String sqlInsert)
        {
            // MySQL
            MySqlConnection mySqlConn = getConnection();
            MySqlCommand mySqlComm = new MySqlCommand();
            mySqlComm.Connection = mySqlConn;
            mySqlComm.CommandType = CommandType.Text;
            mySqlComm.CommandText = sqlInsert;

            int n = mySqlComm.ExecuteNonQuery();

            mySqlComm.Dispose();
            mySqlConn.Close();

            return n;
        }

        /// <summary>
        /// 数据库删除
        /// </summary>
        /// <returns>当前操作所影响的行数</returns>
        public int executeDelete()
        {
            return executeDelete(getDeleteSQL());
        }

        /// <summary>
        /// 数据库删除
        /// </summary>
        /// <param name="sqlDelete">删除语句</param>
        /// <returns>当前操作所影响的行数</returns>
        public int executeDelete(String sqlDelete)
        {
            // MySQL
            MySqlConnection mySqlConn = getConnection();
            MySqlCommand mySqlComm = new MySqlCommand();
            mySqlComm.Connection = mySqlConn;
            mySqlComm.CommandType = CommandType.Text;
            mySqlComm.CommandText = sqlDelete;

            int n = mySqlComm.ExecuteNonQuery();

            mySqlComm.Dispose();
            mySqlConn.Close();

            return n;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int executeBackup(String t, String f)
        {
            return executeBackup(getBackupSQL(t, f));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlBackup"></param>
        /// <returns></returns>
        public int executeBackup(String sqlBackup)
        {
            // MySQL
            MySqlConnection mySqlConn = getConnection();
            MySqlCommand mySqlComm = new MySqlCommand();
            mySqlComm.Connection = mySqlConn;
            mySqlComm.CommandType = CommandType.Text;
            mySqlComm.CommandText = sqlBackup;

            int n = mySqlComm.ExecuteNonQuery();

            mySqlComm.Dispose();
            mySqlConn.Close();

            return n;
        }

        /// <summary>
        /// 在保持同一个连接的基础上，重新设置查寻SQL语句，以进行新的数据库操作
        /// </summary>
        public void reset()
        {
            paramList.Clear();
            signList.Clear();
            valueList.Clear();
            minLimit = 0;
            maxLimit = 0;

            columList.Remove(0, columList.Length);
            tableList.Remove(0, tableList.Length);
            whereList.Remove(0, whereList.Length);
            orderList.Remove(0, orderList.Length);
        }

        /// <summary>
        /// 获取数据库查寻SQL语句
        /// </summary>
        /// <returns>SQL语句，若操作表格为空，则返回空语句</returns>
        private String getSelectSQL()
        {
            // 数据合法性判断
            if (tableList.Length < 1)
            {
                return "";
            }

            StringBuilder sqlBuf = new StringBuilder();

            // 查寻字段拼接
            sqlBuf.Append("SELECT ");
            if (columList.Length > 0)
            {
                sqlBuf.Append(columList.ToString().Substring(2));
            }
            else
            {
                sqlBuf.Append("*");
            }

            // 查寻表格拼接
            sqlBuf.Append(" FROM ").Append(tableList.ToString().Substring(2));

            // 查寻关联条件拼接
            if (whereList.Length > 0)
            {
                sqlBuf.Append(" WHERE ").Append(whereList.ToString().Substring(5));
            }

            // 排序依据拼接
            if (orderList.Length > 0)
            {
                sqlBuf.Append(" ORDER BY ").Append(orderList.ToString().Substring(2));
            }

            if (maxLimit > 0)
            {
                sqlBuf.Append(" LIMIT ").Append(minLimit).Append(',').Append(maxLimit);
            }

            return sqlBuf.ToString();
        }

        /// <summary>
        /// 获取数据库更新SQL语句
        /// </summary>
        /// <returns>SQL语句，若操作表格为空，则返回空语句</returns>
        private String getUpdateSQL()
        {
            // 数据合法性判断
            if (tableList.Length < 1 || paramList.Count < 1)
            {
                return "";
            }

            StringBuilder sqlBuf = new StringBuilder();

            // 更新表格拼接
            sqlBuf.Append("UPDATE ").Append(tableList.ToString().Substring(2)).Append(" SET ");

            // 更新字段及值拼接
            int idx = 0;
            for (int j = paramList.Count - 1; idx < j; idx += 1)
            {
                sqlBuf.Append(paramList[idx]);
                sqlBuf.Append(signList[idx]);
                sqlBuf.Append(valueList[idx]);
                sqlBuf.Append(", ");
            }
            sqlBuf.Append(paramList[idx]);
            sqlBuf.Append(signList[idx]);
            sqlBuf.Append(valueList[idx]);

            // 参照条件拼接
            if (whereList.Length > 0)
            {
                sqlBuf.Append(" WHERE ").Append(whereList.ToString().Substring(5));
            }
            return sqlBuf.ToString();
        }

        /// <summary>
        /// 获取数据库插入SQL语句
        /// </summary>
        /// <returns>SQL语句，若操作表格为空，则返回空语句</returns>
        private String getInsertSQL()
        {
            // 数据合法性判断
            if (tableList.Length < 1)
            {
                return "";
            }

            StringBuilder sqlBuf = new StringBuilder();

            // 数据库表格拼接
            sqlBuf.Append(" INSERT INTO ").Append(tableList.ToString().Substring(2));

            // 要插入字段拼接
            sqlBuf.Append(" (");
            int idx = 0;
            for (int j = paramList.Count - 1; idx < j; idx += 1)
            {
                sqlBuf.Append(paramList[idx]);
                sqlBuf.Append(", ");
            }
            sqlBuf.Append(paramList[idx]);
            sqlBuf.Append(")");

            // 插入数据拼接
            sqlBuf.Append(" VALUES (");
            idx = 0;
            for (int j = valueList.Count - 1; idx < j; idx += 1)
            {
                sqlBuf.Append(valueList[idx]);
                sqlBuf.Append(", ");
            }
            sqlBuf.Append(valueList[idx]);
            sqlBuf.Append(")");

            return sqlBuf.ToString();
        }

        /// <summary>
        /// 获取数据库删除SQL语句
        /// </summary>
        /// <returns>SQL语句，若操作表格为空，则返回空语句</returns>
        private String getDeleteSQL()
        {
            // 数据合法性判断
            if (tableList.Length < 1)
            {
                return "";
            }

            StringBuilder sqlBuf = new StringBuilder();

            // 数据库表格拼接
            sqlBuf.Append("DELETE FROM ").Append(tableList.ToString().Substring(2));

            // 关联条件拼接
            sqlBuf.Append(" WHERE ").Append(whereList.ToString().Substring(5));

            return sqlBuf.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        private String getBackupSQL(String t, String f)
        {
            StringBuilder sqlBuf = new StringBuilder();

            // 插入目标
            sqlBuf.Append("INSERT INTO ").Append(t).Append(" (");
            int j = paramList.Count - 1;
            for (int i = 0; i < j; i += 1)
            {
                sqlBuf.Append(paramList[i]).Append(", ");
            }
            sqlBuf.Append(paramList[j]).Append(") ");

            // 复制来源
            sqlBuf.Append(" SELECT ");
            j = valueList.Count - 1;
            for (int i = 0; i < j; i += 1)
            {
                sqlBuf.Append(valueList[i]).Append(", ");
            }
            sqlBuf.Append(valueList[j]);

            sqlBuf.Append(" FROM ").Append(f);
            // 查寻关联条件拼接
            if (whereList.Length > 0)
            {
                sqlBuf.Append(" WHERE ").Append(whereList.ToString(5, whereList.Length - 5));
            }

            return sqlBuf.ToString();
        }

        #region Old Methods
        /// <summary>
        /// 数据查询，返回所有符合条件的数据
        /// </summary>
        /// <param name="sqlTable">待进行数据查询的表格名称</param>
        /// <param name="sqlSelect">查询SQL语句</param>
        /// <returns></returns>
        public DataView CreateView(String sqlTable, String sqlSelect)
        {
            return CreateSet(sqlTable, sqlSelect).Tables[sqlTable].DefaultView;
        }

        public DataView CreateView(String sqlSelect)
        {
            return CreateSet(sqlSelect).Tables[0].DefaultView;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlTable"></param>
        /// <param name="sqlSelect"></param>
        /// <returns></returns>
        public DataSet CreateSet(String sqlTable, String sqlSelect)
        {
            DataSet dataSet = new DataSet();

            // MySQL
            MySqlConnection mySqlConn = getConnection();
            MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(sqlSelect, mySqlConn);
            mySqlAdapter.Fill(dataSet, sqlTable);
            mySqlAdapter.Dispose();
            mySqlConn.Close();

            return dataSet;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlSelect"></param>
        /// <returns></returns>
        public DataSet CreateSet(String sqlSelect)
        {
            DataSet dataSet = new DataSet();

            // MySQL
            MySqlConnection mySqlConn = getConnection();
            MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(sqlSelect, mySqlConn);
            mySqlAdapter.Fill(dataSet);
            mySqlAdapter.Dispose();
            mySqlConn.Close();

            return dataSet;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet CreateSet()
        {
            return CreateSet(getSelectSQL());
        }

        /// <summary>
        /// 分页数据查询，返回指定页所有符合条件的数据
        /// </summary>
        /// <param name="sqlTable">待进行数据查询的表格名称</param>
        /// <param name="sqlSelect">查询SQL语句</param>
        /// <param name="pageIndx">当前页索引，从数值0开始</param>
        /// <param name="pageSize">每页显示记录个数</param>
        /// <returns></returns>
        public DataView CreateView(String sqlTable, String sqlSelect, int pageIndx, int pageSize)
        {
            return CreateSet(sqlTable, sqlSelect, pageIndx, pageSize).Tables[sqlTable].DefaultView;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlTable"></param>
        /// <param name="sqlSelect"></param>
        /// <param name="pageIndx"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public DataSet CreateSet(String sqlTable, String sqlSelect, int pageIndx, int pageSize)
        {
            DataSet dataSet = new DataSet();

            // MySQL
            MySqlConnection mySqlConn = getConnection();
            MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(sqlSelect, mySqlConn);
            mySqlAdapter.Fill(dataSet, pageIndx, pageSize, sqlTable);
            mySqlAdapter.Dispose();
            mySqlConn.Close();

            return dataSet;
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="sqlUpdate"></param>
        /// <returns></returns>
        public int UpdateData(String sqlUpdate)
        {
            // MySQL
            MySqlConnection mySqlConn = getConnection();
            MySqlCommand mySqlComm = new MySqlCommand();
            mySqlComm.Connection = mySqlConn;
            mySqlComm.CommandType = CommandType.Text;
            mySqlComm.CommandText = sqlUpdate;

            int n = mySqlComm.ExecuteNonQuery();

            mySqlComm.Dispose();
            mySqlConn.Close();

            return n;
        }

        /// <summary>
        /// 更新指定键值记录的显示排序信息
        /// </summary>
        /// <param name="table">表格名称</param>
        /// <param name="colName">关联条件</param>
        /// <param name="keyValue">关联键值</param>
        /// <param name="name">更新字段</param>
        /// <param name="step">步增大小</param>
        /// <returns></returns>
        public int UpdateStep(String table, String colName, String keyValue, String name, int step)
        {
            return UpdateData(String.Format("UPDATE {0} SET {1} = {1} + {2} WHERE {3}='{4}'",
                                             table,
                                             name,
                                             step,
                                             colName,
                                             keyValue));
        }

        public int UpdateStep(String table, String[] cols, String[] keys, String name, int step)
        {
            String sqlUpdate = String.Format("UPDATE {0} SET {1} = {1} + {2}",
                                             table,
                                             name,
                                             step);
            if (cols.Length > 0)
            {
                String where = "  WHERE";
                for (int i = 0; i < cols.Length; i += 1)
                {
                    where += String.Format(" {0} = '{1}' AND", cols[i], keys[i]);
                }
                if (where.Length > 6)
                {
                    where = where.Substring(0, where.Length - 4);
                }
                sqlUpdate += where;
            }

            return UpdateData(sqlUpdate);
        }
        #endregion
    }
}