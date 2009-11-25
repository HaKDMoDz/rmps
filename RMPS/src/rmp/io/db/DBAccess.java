/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.io.db;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

import rmp.util.CheckUtil;
import rmp.util.EnvUtil;
import rmp.util.LogUtil;
import cons.EnvCons;
import cons.SqlCons;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 数据库存取封装类
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class DBAccess
{
    // ////////////////////////////////////////////////////////////////////////
    // 内部成员变量
    // ////////////////////////////////////////////////////////////////////////
    /** 数据源连接 */
    private Connection conn;
    /** 数据库操作 */
    private Statement stat;
    /** 数据KEY-VALUE对持有变量 */
    private List<String> paramList;
    /** 符号持有变量 */
    private List<String> signList;
    /** 数据插入时数据列表（以逗号“,”分隔符区分） */
    private List<String> valueList;
    /** 当前要操作的字段名称（列表（以逗号“,”分隔符区分）） */
    private StringBuffer columList;
    /** 当前要操作的表格名称（列表（以逗号“,”分隔符区分）） */
    private StringBuffer tableList;
    /** 数据库操作时的关联条件列表（以逗号“,”分隔符区分） */
    private StringBuffer whereList;
    /** 数据库查寻时的排序依据（列表（以逗号“,”分隔符区分）） */
    private StringBuffer orderList;
    /** 数据源路径 */
    private final static String dbPath;

    /**
     * 一次性数据库驱动加载
     */
    static
    {
        dbPath = EnvUtil.getUserDir() + EnvCons.PATH_DAT + EnvCons.COMN_SP_FILE + EnvCons.COMN_DATA_BASE;

        try
        {
            // 加载数据库驱动
            Class.forName(SqlCons.DBCS_JDBC_DRV);
        }
        catch (ClassNotFoundException exp)
        {
            LogUtil.exception(exp);
        }
    }

    /**
     * 默认构造函数，事务默认自动提交
     * 
     * @param dbPath 数据库或者数据源路径，绝对或相对路径，系统不作详细区分
     */
    public DBAccess()
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    public boolean wInit()
    {
        LogUtil.log("数据源操作：连接数据源 － " + dbPath);

        // 参数列表
        paramList = new ArrayList<String>();
        // 关联符号
        signList = new ArrayList<String>();
        // 数据列表
        valueList = new ArrayList<String>();
        // 字段缓冲
        columList = new StringBuffer();
        // 表格缓冲
        tableList = new StringBuffer();
        // 关联每件缓冲
        whereList = new StringBuffer();
        // 排序依据缓冲
        orderList = new StringBuffer();

        try
        {
            // 连接数据源
            conn = DriverManager.getConnection(SqlCons.DBCS_CONN_STR + dbPath);
            // 操作状态
            stat = conn.createStatement();
            LogUtil.log("数据源操作：数据源连接成功。");

            opened = true;
            return true;
        }
        catch (Exception sqle)
        {
            LogUtil.exception(sqle);
            conn = null;
            stat = null;
            return false;
        }
    }

    /**
     * 关闭数据库
     * 
     * @throws SQLException
     */
    public void closeConnection()
    {
        // Statement 关闭
        if (stat != null)
        {
            try
            {
                stat.close();
            }
            catch (SQLException exp)
            {
                LogUtil.exception(exp);
            }
            finally
            {
                stat = null;
                LogUtil.log("数据源操作：关闭Statement...");
            }
        }

        // Connection 关闭
        if (conn != null)
        {
            try
            {
                conn.close();
            }
            catch (SQLException exp)
            {
                LogUtil.exception(exp);
            }
            finally
            {
                conn = null;
                LogUtil.log("数据源操作：关闭Connection...");
            }
        }

        LogUtil.log("数据源操作：数据源关闭成功。");
    }

    /**
     * 添加要使用的表格
     * 
     * @param table
     */
    public void addTable(String table)
    {
        if (CheckUtil.isValidate(table))
        {
            tableList.append(", ").append(table);
        }
    }

    /**
     * 添加带连接的表格
     * 
     * @param tableLeft
     * @param tableRight
     * @param joinStyle 详细参见：<br />
     *        cons.SysCons.DB0008.DBCS_JOIN_CROSS<br />
     *        cons.SysCons.DB0008.DBCS_JOIN_FULL<br />
     *        cons.SysCons.DB0008.DBCS_JOIN_LEFT<br />
     *        cons.SysCons.DB0008.DBCS_JOIN_RIGHT<br />
     */
    public void addTable(String tableLeft, String tableRight, String joinStyle)
    {
        tableList.append(", ").append(tableLeft).append(' ').append(joinStyle).append(' ').append(tableRight);
    }

    /**
     * 添加带连接的表格
     * 
     * @param tableLeft
     * @param tableRight
     * @param joinStyle 详细参见：<br />
     *        cons.SysCons.DB0008.DBCS_JOIN_CROSS<br />
     *        cons.SysCons.DB0008.DBCS_JOIN_FULL<br />
     *        cons.SysCons.DB0008.DBCS_JOIN_LEFT<br />
     *        cons.SysCons.DB0008.DBCS_JOIN_RIGHT<br />
     * @param columnLeft
     * @param columnRight
     */
    public void addTable(String tableLeft, String tableRight, String joinStyle, String columnLeft, String columnRight)
    {
        tableList.append(", ").append(tableLeft).append(' ').append(joinStyle).append(' ').append(tableRight);
        tableList.append(" ON ").append(columnLeft).append(" = ").append(columnRight);
    }

    /**
     * 添加查寻字段
     * 
     * <pre>
     * SELECT colname1, colname2, ... FROM tablename
     * </pre>
     * 
     * @param colname 对于于要查寻的表格的相关字段
     */
    public void addColumn(String colname)
    {
        if (CheckUtil.isValidate(colname))
        {
            columList.append(", ").append(colname);
        }
    }

    /**
     * 数据更新：添加数据库操作的KEY-VALUE对。
     * 
     * <pre>
     * UPDATE SET key1=value1, key2=value2 ... 
     * </pre>
     * 
     * @param key 数据库字段名
     * @param value 对应字段的值
     */
    public void addParam(String key, String value)
    {
        addParam(key, value, true);
    }

    /**
     * 数据更新：添加数据库操作的KEY-VALUE对。
     * 
     * <pre>
     * UPDATE SET key1=value1, key2=value2 ... 
     * </pre>
     * 
     * @param key 数据库字段名
     * @param value 对应字段的值
     * @param isLiteral 当前字段是否为纯文本，true为纯文本，false为其它格式。
     */
    public void addParam(String key, String value, boolean isLiteral)
    {
        addParam(key, "=", value, isLiteral);
    }

    /**
     * 数据更新：添加数据库操作的KEY-VALUE对。
     * 
     * @param param 数据库字段名
     * @param sign 运算操作符
     * @param value 对应字段的值
     * @param isLiteral 当前字段是否为纯文本，true为纯文本，false为其它格式。
     */
    public void addParam(String param, String sign, String value, boolean isLiteral)
    {
        if (CheckUtil.isValidate(param))
        {
            paramList.add(param);
            signList.add(sign);

            // 特殊字符替换
            if (value != null)
            {
                value = value.replace("'", "''");
            }

            // 值信息处理
            if (isLiteral)
            {
                valueList.add(" '" + value + "'");
            }
            else
            {
                valueList.add(value);
            }
        }
    }

    /**
     * 用户自定义关联条件
     * 
     * @param where
     */
    public void addWhere(String where)
    {
        whereList.append(" AND (").append(where).append(") ");
    }

    /**
     * 添加WHERE查寻条件，默认运算符为等号“=”，默认值为纯文本
     * 
     * <pre>
     * UPDATE tablename SET ... WHERE key1=value1 AND key2=value2 ...
     * </pre>
     * 
     * @param key 参照数据库表格字段名
     * @param value 参照值
     */
    public void addWhere(String key, String value)
    {
        addWhere(key, value, true);
    }

    /**
     * 添加WHERE查寻条件，默认运算符为等号“=”
     * 
     * <pre>
     * UPDATE tablename SET ... WHERE key1=value1 AND key2=value2 ...
     * </pre>
     * 
     * @param key 参照数据库表格字段名
     * @param value 参照值
     * @param isLiteral 是否为纯文本字符串，true为纯文本，false为非文本
     */
    public void addWhere(String key, String value, boolean isLiteral)
    {
        addWhere(key, "=", value, isLiteral);
    }

    /**
     * 添加WHERE查寻条件
     * 
     * <pre>
     * UPDATE tablename SET ... WHERE key1=value1 AND key2=value2 ...
     * </pre>
     * 
     * @param key 参照数据库表格字段名
     * @param sign 参照运算符，如+、-、=、!=等
     * @param value 参照值
     * @param isLiteral 是否为纯文本字符串，true为纯文本，false为非文本
     */
    public void addWhere(String key, String sign, String value, boolean isLiteral)
    {
        if (CheckUtil.isValidate(key) && value != null && CheckUtil.isValidate(sign))
        {
            whereList.append(" AND ").append(key);
            whereList.append(" ").append(sign);

            // 值信息处理
            if (isLiteral)
            {
                whereList.append(" '").append(value).append("'");
            }
            else
            {
                whereList.append(" ").append(value);
            }
        }
    }

    /**
     * 默认升序排序
     * 
     * @param key
     */
    public void addSort(String key)
    {
        addSort(key, "ASC");
    }

    /**
     * 添加排序依据
     * 
     * <pre>
     * SELECT * FROM tablename WHERE ... ORDER BY key1 value1, key2 value2, ...
     * </pre>
     * 
     * @param key 参照数据库表格字段
     * @param value 排序方法:ASC表示升序;DESC表示降序
     */
    public void addSort(String key, String value)
    {
        if (CheckUtil.isValidate(key) && CheckUtil.isValidate(value))
        {
            orderList.append(", ").append(key);
            orderList.append(" ").append(value);
        }
    }

    /**
     * 其它相关的数据库操作，如COMMIT、HSQL专有的SHUTDOWN等。
     * 
     * @param sql 要执行的SQL语句
     * @return 当前操作是否成功
     * @throws SQLException
     */
    public boolean execute(String sql) throws SQLException
    {
        boolean success = false;
        if (stat != null)
        {
            LogUtil.log("数据库操作：其它操作 - " + sql);
            success = stat.execute(sql);
        }
        return success;
    }

    /**
     * 数据库查寻
     * 
     * @return 查寻结果集
     * @throws SQLException
     */
    public ResultSet executeSelect() throws SQLException
    {
        return executeSelect(getSelectSQL());
    }

    /**
     * 数据库查寻
     * 
     * @param sql 查寻语句
     * @return 查寻结果集
     * @throws SQLException
     */
    public ResultSet executeSelect(String sql) throws SQLException
    {
        ResultSet rest = null;
        if (stat != null)
        {
            LogUtil.log("数据库操作：数据查寻 - " + sql);
            rest = stat.executeQuery(sql);
        }
        return rest;
    }

    /**
     * 数据库更新
     * 
     * @return 当前操作所影响的行数
     * @throws SQLException
     */
    public int executeUpdate() throws SQLException
    {
        return executeUpdate(getUpdateSQL());
    }

    /**
     * 数据库更新
     * 
     * @param sql 更新语句
     * @return 当前操作所影响的行数
     * @throws SQLException
     */
    public int executeUpdate(String sql) throws SQLException
    {
        int recSize = -1;
        if (stat != null && CheckUtil.isValidate(sql))
        {
            LogUtil.log("数据库操作：数据更新 - " + sql);
            recSize = stat.executeUpdate(sql);
        }
        return recSize;
    }

    /**
     * 数据库插入
     * 
     * @return 当前操作所影响的行数
     * @throws SQLException
     */
    public int executeInsert() throws SQLException
    {
        return executeInsert(getInsertSQL());
    }

    /**
     * @param sql
     * @return
     * @throws SQLException
     */
    public int executeInsert(String sql) throws SQLException
    {
        int recSize = -1;
        if (stat != null && CheckUtil.isValidate(sql))
        {
            LogUtil.log("数据库操作：数据插入 - " + sql);
            recSize = stat.executeUpdate(sql);
        }
        return recSize;
    }

    /**
     * 数据库删除
     * 
     * @return
     * @throws SQLException
     */
    public int executeDelete() throws SQLException
    {
        return executeDelete(getDeleteSQL());
    }

    /**
     * @param sql
     * @return
     * @throws SQLException
     */
    public int executeDelete(String sql) throws SQLException
    {
        int recSize = -1;
        if (stat != null && CheckUtil.isValidate(sql))
        {
            LogUtil.log("数据库操作：数据删除 - " + sql);
            recSize = stat.executeUpdate(sql);
        }
        return recSize;
    }

    /**
     * 在保持同一个连接的基础上，重新设置查寻SQL语句，以进行新的数据库操作
     */
    public void reset()
    {
        this.paramList.clear();
        this.signList.clear();
        this.valueList.clear();

        this.columList.delete(0, columList.length());
        this.tableList.delete(0, tableList.length());
        this.whereList.delete(0, whereList.length());
        this.orderList.delete(0, orderList.length());
    }

    /**
     * 获取数据库查寻SQL语句
     * 
     * @return SQL语句，若操作表格为空，则返回空语句
     */
    private String getSelectSQL()
    {
        // 数据合法性判断
        if (tableList.length() < 1)
        {
            return "";
        }

        StringBuffer sqlBuf = new StringBuffer();

        // 查寻字段拼接
        sqlBuf.append("SELECT ");
        if (columList.length() > 0)
        {
            sqlBuf.append(columList.substring(2));
        }
        else
        {
            sqlBuf.append("*");
        }

        // 查寻表格拼接
        sqlBuf.append(" FROM ").append(tableList.substring(2));

        // 查寻关联条件拼接
        if (whereList.length() > 0)
        {
            sqlBuf.append(" WHERE ").append(whereList.substring(5));
        }

        // 排序依据拼接
        if (orderList.length() > 0)
        {
            sqlBuf.append(" ORDER BY ").append(orderList.substring(2));
        }

        return sqlBuf.toString();
    }

    /**
     * 获取数据库更新SQL语句
     * 
     * @return SQL语句，若操作表格为空，则返回空语句
     */
    private String getUpdateSQL()
    {
        // 数据合法性判断
        if (tableList.length() < 1 || paramList.size() < 1)
        {
            return "";
        }

        StringBuilder sqlBuf = new StringBuilder();

        // 更新表格拼接
        sqlBuf.append("UPDATE ").append(tableList.substring(2)).append(" SET ");

        // 更新字段及值拼接
        int idx = 0;
        for (int j = paramList.size() - 1; idx < j; idx += 1)
        {
            sqlBuf.append(paramList.get(idx));
            sqlBuf.append(signList.get(idx));
            sqlBuf.append(valueList.get(idx));
            sqlBuf.append(", ");
        }
        sqlBuf.append(paramList.get(idx));
        sqlBuf.append(signList.get(idx));
        sqlBuf.append(valueList.get(idx));

        // 参照条件拼接
        if (whereList.length() > 0)
        {
            sqlBuf.append(" WHERE ").append(whereList.substring(5));
        }
        return sqlBuf.toString();
    }

    /**
     * 获取数据库插入SQL语句
     * 
     * @return SQL语句，若操作表格为空，则返回空语句
     */
    private String getInsertSQL()
    {
        // 数据合法性判断
        if (tableList.length() < 1)
        {
            return "";
        }

        StringBuffer sqlBuf = new StringBuffer();

        // 数据库表格拼接
        sqlBuf.append(" INSERT INTO ").append(tableList.substring(2));

        // 要插入字段拼接
        sqlBuf.append(" (");
        int idx = 0;
        for (int j = paramList.size() - 1; idx < j; idx += 1)
        {
            sqlBuf.append(paramList.get(idx));
            sqlBuf.append(", ");
        }
        sqlBuf.append(paramList.get(idx));
        sqlBuf.append(")");

        // 插入数据拼接
        sqlBuf.append(" VALUES (");
        idx = 0;
        for (int j = valueList.size() - 1; idx < j; idx += 1)
        {
            sqlBuf.append(valueList.get(idx));
            sqlBuf.append(", ");
        }
        sqlBuf.append(valueList.get(idx));
        sqlBuf.append(")");

        return sqlBuf.toString();
    }

    /**
     * 获取数据库删除SQL语句
     * 
     * @return SQL语句，若操作表格为空，则返回空语句
     */
    private String getDeleteSQL()
    {
        // 数据合法性判断
        if (tableList.length() < 1)
        {
            return "";
        }

        StringBuffer sqlBuf = new StringBuffer();

        // 数据库表格拼接
        sqlBuf.append("DELETE FROM ").append(tableList.substring(2));

        // 关联条件拼接
        sqlBuf.append(" WHERE ").append(whereList.substring(5));

        return sqlBuf.toString();
    }

    /**
     * 数据源是否已经打开
     * 
     * @return
     */
    public static boolean isOpened()
    {
        return opened;
    }
    /** 数据源是否已经打开 */
    private static boolean opened;
}
