/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.comn.amon.data.A2010000.t;

import java.io.BufferedWriter;
import java.io.File;
import java.io.IOException;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.ResultSetMetaData;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;

import rmp.comn.amon.data.A2010000.b.KVItem;
import rmp.comn.amon.data.A2010000.b.WDataBase;
import rmp.util.CheckUtil;
import rmp.util.FileUtil;
import rmp.util.StringUtil;

import com.amonsoft.util.LogUtil;

import cons.SysCons;
import cons.comn.amon.data.A2010000.ConstUI;
import cons.db.AmonCons;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public class Util
{
    /**
     * Microsoft SQL Server 支持以下几种类型数据：<br>
     * 二进制数据：binary、varbinary、image<br>
     * 字符数据：char、varchar、text<br>
     * Unicode数据：nchar、nvarchar、ntext<br>
     * 日期时间：datetime、smalldatetime<br>
     * 数值数据：decimal、numeric、float、real、int、bigint、smallint、tinyint<br>
     * 货币数据：money、smallmoney<br>
     * 特殊数据：bit、timestamp、uniqueidentifier<br>
     * 用户数据：<br>
     * 
     * @param conn
     *            数据库连接
     * @param sid
     *            系统标记
     * @param key
     *            数据库类型
     * @return
     */
    public static String exportDBM(Connection conn, String sid, String key)
    {
        String sqlSelect = "SELECT * FROM " + AmonCons.A2010100;
        if (CheckUtil.isValidate(sid))
        {
            if (sid.length() > 6)
            {
                sid = sid.substring(0, 6);
            }
            sid += '%';
            sqlSelect += StringUtil.format(" WHERE {0} LIKE '{1}'", AmonCons.A2010101, sid);
        }
        sqlSelect += StringUtil.format(" ORDER BY {0} ASC", AmonCons.A2010101);

        Statement stat = null;
        ResultSet rest = null;

        try
        {
            stat = conn.createStatement();
            rest = stat.executeQuery(sqlSelect);
            return exportAsHSQLDB(rest);
        }
        catch (SQLException e)
        {
            e.printStackTrace();
            return "";
        }
        finally
        {
            try
            {
                if (rest != null)
                {
                    rest.close();
                }
            }
            catch (SQLException exp)
            {
                exp.printStackTrace();
            }

            try
            {
                if (stat != null)
                {
                    stat.close();
                }
            }
            catch (SQLException exp)
            {
                exp.printStackTrace();
            }
        }
    }

    /**
     * @param rest
     * @return
     * @throws SQLException
     */
    private static String exportAsHSQLDB(ResultSet rest) throws SQLException
    {
        final String[] TYPE =
        { "VARCHAR", "CHAR", "NUMBERIC", "INTEGER", "DATA", "TIMESTAMP" };
        StringBuffer sbTbl = new StringBuffer();
        StringBuffer sbKey = new StringBuffer();

        // CRATE TABLE
        sbTbl.append("CREATE TABLE ");

        // TABLE NAME
        if (rest.next())
        {
            sbTbl.append(rest.getString(AmonCons.A2010101));
        }

        sbTbl.append("(");
        // COLUMN DEFINE
        String tmp1;
        int tmp2;
        while (rest.next())
        {
            // 字段名称
            tmp1 = rest.getString(AmonCons.A2010101);
            sbTbl.append(tmp1).append(' ');
            // 数据类型
            tmp2 = rest.getInt(AmonCons.A2010103);
            sbTbl.append(TYPE[tmp2]);
            if (tmp2 < 3)
            {
                // 数据长度
                sbTbl.append("(").append(rest.getString(AmonCons.A2010104)).append(")");
            }
            // 是否主键
            if (ConstUI.DBCD_IS_PRIMARY_KEY.equals(rest.getString(AmonCons.A2010105)))
            {
                sbKey.append(",").append(tmp1);
            }
            // 是否为空
            else if (ConstUI.DBCD_IS_NOT_NULL.equals(rest.getString(AmonCons.A2010106)))
            {
                sbTbl.append(" NOT NULL");
            }
            // 是否唯一
            else if (ConstUI.DBCD_IS_UNIQUE.equals(rest.getString(AmonCons.A2010107)))
            {
                sbTbl.append(" UNIQUE");
            }
            // 默认数据
            tmp1 = rest.getString(AmonCons.A2010108);
            if (CheckUtil.isValidate(tmp1))
            {
                sbTbl.append(" DEFAULT " + tmp1);
            }
            sbTbl.append(",");
        }
        if (sbKey.length() > 1)
        {
            sbKey.deleteCharAt(0);
            sbTbl.append("PRIMARY KEY (").append(sbKey.toString()).append("),");
        }
        sbTbl.deleteCharAt(sbTbl.length() - 1).append(");");

        return sbTbl.toString();
    }

    /**
     * 导出数据到文档
     * 
     * @param tid
     * @param outFile
     * @return
     */
    public static boolean exportDBA(Connection conn, String tid, File outFile)
    {
        Statement stat = null;
        ResultSet rest = null;
        BufferedWriter bufWriter = null;

        try
        {
            stat = conn.createStatement();
            rest = stat.executeQuery("SELECT * FROM " + tid);

            // 获取数据列数
            ResultSetMetaData meta = rest.getMetaData();
            int colSize = meta.getColumnCount();
            ArrayList<KVItem> nameList = new ArrayList<KVItem>(colSize);
            for (int i = 1; i <= colSize; i += 1)
            {
                nameList.add(new KVItem(meta.getColumnName(i), meta.getColumnTypeName(i)));
            }

            // 拼接INSERT字段名称
            colSize -= 1;
            StringBuffer strBuf = new StringBuffer();
            strBuf.append("INSERT INTO ").append(tid).append(" (");
            KVItem item;
            for (int i = 0; i < colSize; i += 1)
            {
                item = nameList.get(i);
                strBuf.append(item.getK()).append(',');
            }
            item = nameList.get(colSize);
            strBuf.append(item.getK()).append(") VALUES (");
            String strInsert = strBuf.toString();

            // 创建UTF-8缓冲数据输出流
            bufWriter = FileUtil.getWriter(outFile, SysCons.FILE_ENCODING);

            // 循环输出每一条记录数据
            String cData;
            while (rest.next())
            {
                strBuf.delete(0, strBuf.length());

                for (KVItem kvItem : nameList)
                {
                    // 数值对分隔符
                    strBuf.append(',');

                    cData = rest.getString(kvItem.getK());
                    if (cData == null)
                    {
                        strBuf.append("NULL");
                        continue;
                    }

                    // 是否为数字输出
                    if (kvItem.isS())
                    {
                        strBuf.append('\'');
                    }

                    // 输出字段内容
                    strBuf.append(cData.replace("'", "''"));

                    // 是否为数字输出
                    if (kvItem.isS())
                    {
                        strBuf.append('\'');
                    }
                }
                strBuf.deleteCharAt(0);
                strBuf.append(");\n");

                bufWriter.write(strInsert);
                bufWriter.write(strBuf.toString());
            }
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
        finally
        {
            // 关闭文档输出流
            try
            {
                if (bufWriter != null)
                {
                    bufWriter.flush();
                    bufWriter.close();
                }
            }
            catch (IOException exp)
            {
                LogUtil.exception(exp);
            }

            // 关闭结果集
            try
            {
                if (rest != null)
                {
                    rest.close();
                }
            }
            catch (SQLException exp)
            {
                LogUtil.exception(exp);
            }

            // 关闭会话
            try
            {
                if (stat != null)
                {
                    stat.close();
                }
            }
            catch (SQLException exp)
            {
                LogUtil.exception(exp);
            }
        }

        return true;
    }

    /**
     * 获取与指定数据库数据源的连接
     * 
     * @param wdb
     *            数据库连接对象信息
     * @return
     */
    public static Connection getConnection(WDataBase wdb)
    {
        // 连接信息对象为空判断
        if (wdb == null || !CheckUtil.isValidate(wdb.getUrl()))
        {
            return null;
        }

        Connection conn = null;
        try
        {
            // 驱动加载
            if (CheckUtil.isValidate(wdb.getDriver()))
            {
                Class.forName(wdb.getDriver());
            }

            // 创建会话
            if (CheckUtil.isValidate(wdb.getUser()))
            {
                conn = DriverManager.getConnection(wdb.getUrl(), wdb.getUser(), wdb.getPassword());
            }
            else
            {
                conn = DriverManager.getConnection(wdb.getUrl());
            }
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
        return conn;
    }

    /**
     * @param wdb
     * @return
     */
    public static boolean closeConnection(WDataBase wdb, Connection conn)
    {
        try
        {
            conn.createStatement().execute("SHUTDOWN");
            conn.close();
            return true;
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            return false;
        }
    }

    public static void main(String[] args)
    {
        WDataBase wdb = new WDataBase();
        wdb.setDriver(ConstUI.HSQLDB_DRV);
        wdb.setUrl(ConstUI.HSQLDB_URL + "E:\\rmps\\rmp\\1000000\\dat\\amon");
        Connection conn = getConnection(wdb);
        System.out.println(exportDBM(conn, "A2010100", ""));
        try
        {
            conn.createStatement().execute("SHUTDOWN");
            conn.close();
        }
        catch (Exception exp)
        {
            exp.printStackTrace();
        }
    }
}
