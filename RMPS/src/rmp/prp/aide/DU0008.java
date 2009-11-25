/*
 * FileName:       DU0008.java
 * CreateDate:     2007-7-15 下午02:39:02
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

import cons.prp.aide.extparse.DB0008;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br>
 * 以数据库A为参照，将数据结构升级到数据库B。
 * <li>使用说明：</li>
 * <br>
 * 需要修改参数如下：<br>
 * 1）、<br>
 * 数据库A的连接参数及路径：{@link DU0008#DRV_A}、{@link DU0008#CON_A}；<br>
 * 数据库B的连接参数及路径：{@link DU0008#DRV_B}、{@link DU0008#CON_B}；<br>
 * 2）、<br>
 * 确认DB000*为来源数据库常量，DB000*为目标数据库常量。<br>
 * 3）、<br>
 * upgrade_Aide_***方法中，修正A数据库字段与B数据库字段的对应关系。<br>
 * </ul>
 * <p>
 * 版本： RMPS V1.0.0.0
 * </p>
 * <p>
 * 作者： Amon
 * </p>
 * <p>
 * 日期： 2007-7-15 下午02:39:02
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public final class DU0008
{
    private static final String      DRV_A = "org.hsqldb.jdbcDriver";
    private static final String      CON_A = "jdbc:hsqldb:file:D:\\test\\amon";
    private static final String      DRV_B = "sun.jdbc.odbc.JdbcOdbcDriver";
    private static final String      CON_B = "jdbc:odbc:amon";

    private static Connection        conA;
    private static Statement         staA;
    private static Connection        conB;
    private static PreparedStatement staB;

    public static void upgrade()
    {
        try
        {
            createConnectionA(DRV_A, CON_A, "", "");
            createConnectionB(DRV_B, CON_B, "", "");

            upgrade_Aide_TDA();
            upgrade_Aide_TDB();
            upgrade_Aide_TDC();
            upgrade_Aide_TDD();
            upgrade_Aide_TDE();
            upgrade_Aide_TDF();
            upgrade_Aide_TDG();
            upgrade_Aide_TDH();
            upgrade_Aide_TDI();
            upgrade_Aide_TDJ();

            upgrade_Aide_TGA();
            upgrade_Aide_TGB();

            upgrade_Aide_TUA();

            upgrade_Aide_TXA();
            upgrade_Aide_TXB();
            upgrade_Aide_TXC();
            upgrade_Aide_TXD();

            staA.execute("SHUTDOWN");
            closeConnectionA();

            // staB.execute("SHUTDOWN");
            closeConnectionB();
        }
        catch(Exception exp)
        {
            exp.printStackTrace();
        }
    }

    public static void createConnectionA(String drv, String con, String user, String password)
    {
        try
        {
            Class.forName(drv);
            conA = DriverManager.getConnection(con);// , user, password);
            staA = conA.createStatement();
        }
        catch(Exception exp)
        {
            exp.printStackTrace();
        }
    }

    public static void createConnectionB(String drv, String con, String user, String password)
    {
        try
        {
            Class.forName(drv);
            conB = DriverManager.getConnection(con);// , user, password);
        }
        catch(Exception exp)
        {
            exp.printStackTrace();
        }
    }

    public static void closeConnectionA()
    {
        try
        {
            if (staA != null)
            {
                staA.close();
            }
        }
        catch(Exception exp)
        {
            exp.printStackTrace();
        }

        try
        {
            if (conA != null)
            {
                conA.close();
            }
        }
        catch(Exception exp)
        {
            exp.printStackTrace();
        }
    }

    public static void closeConnectionB()
    {
        try
        {
            if (staB != null)
            {
                staB.close();
            }
        }
        catch(Exception exp)
        {
            exp.printStackTrace();
        }

        try
        {
            if (conB != null)
            {
                conB.close();
            }
        }
        catch(Exception exp)
        {
            exp.printStackTrace();
        }
    }

    private static void upgrade_Aide_TDA() throws SQLException
    {
        int i = 0;

        staB = conB.prepareStatement("INSERT INTO AIDE_TDA VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)");
        ResultSet rstA = staA.executeQuery("SELECT * FROM " + DB0008.TABLE_EXTSDATA);
        while (rstA.next())
        // if (rstA.next())
        {
            staB.clearParameters();

            int idx = 1;
            staB.setInt(idx++, rstA.getInt(DB0008.EXTSDATA_ACSTIMES));
            staB.setInt(idx++, rstA.getInt(DB0008.EXTSDATA_PLATINDX));
            staB.setInt(idx++, rstA.getInt(DB0008.EXTSDATA_XCPUBITS));
            staB.setString(idx++, rstA.getString(DB0008.EXTSDATA_EXTSINDX));
            staB.setString(idx++, rstA.getString(DB0008.EXTSDATA_CORPINDX));
            staB.setString(idx++, rstA.getString(DB0008.EXTSDATA_SOFTINDX));
            staB.setString(idx++, rstA.getString(DB0008.EXTSDATA_FILEINDX));
            staB.setString(idx++, rstA.getString(DB0008.EXTSDATA_DESPINDX));
            staB.setString(idx++, rstA.getString(DB0008.EXTSDATA_ASOCINDX));
            staB.setString(idx++, rstA.getString(DB0008.EXTSDATA_MIMEINDX));
            staB.setString(idx++, rstA.getString(DB0008.EXTSDATA_TYPEINDX));
            staB.setString(idx++, rstA.getString(DB0008.EXTSDATA_IDIOINDX));
            staB.setDate(idx++, rstA.getDate(DB0008.EXTSDATA_UPDTDATE));
            staB.setDate(idx++, rstA.getDate(DB0008.EXTSDATA_MAKEDATE));
            staB.setString(idx++, rstA.getString(DB0008.EXTSDATA_EXTSNAME));
            staB.setString(idx++, rstA.getString(DB0008.EXTSDATA_IDIOMARK));

            staB.executeUpdate();
            i += 1;
        }
        rstA.close();

        System.out.println("SIZE: " + i);
    }

    private static void upgrade_Aide_TDB() throws SQLException
    {
        int i = 0;

        staB = conB.prepareStatement("INSERT INTO AIDE_TDB VALUES (?,?,?,?,?,?)");
        ResultSet rstA = staA.executeQuery("SELECT * FROM " + DB0008.TABLE_DESPDATA);
        while (rstA.next())
        // if (rstA.next())
        {
            staB.clearParameters();

            int idx = 1;
            staB.setString(idx++, rstA.getString(DB0008.DESPDATA_DESPINDX));
            staB.setString(idx++, rstA.getString(DB0008.DESPDATA_LANGINDX));
            staB.setString(idx++, rstA.getString(DB0008.DESPDATA_EXTSDESP));
            staB.setString(idx++, rstA.getString(DB0008.DESPDATA_IDIOMARK));
            staB.setDate(idx++, rstA.getDate(DB0008.DESPDATA_UPDTDATE));
            staB.setDate(idx++, rstA.getDate(DB0008.DESPDATA_MAKEDATE));

            staB.executeUpdate();
            i += 1;
        }
        rstA.close();

        System.out.println("SIZE: " + i);
    }

    /**
     * @param stat
     * @param dba
     * @throws SQLException
     */
    private static void upgrade_Aide_TDC() throws SQLException
    {
        int i = 0;

        staB = conB.prepareStatement("INSERT INTO AIDE_TDC VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?)");
        ResultSet rstA = staA.executeQuery("SELECT * FROM " + DB0008.TABLE_FILEDATA);
        while (rstA.next())
        // if (rstA.next())
        {
            staB.clearParameters();

            int idx = 1;
            staB.setInt(idx++, rstA.getInt(DB0008.FILEDATA_DISPORDR));
            staB.setString(idx++, rstA.getString(DB0008.FILEDATA_FILEINDX));
            staB.setString(idx++, rstA.getString(DB0008.FILEDATA_SOFTINDX));
            staB.setString(idx++, rstA.getString(DB0008.FILEDATA_FILEICON));
            staB.setString(idx++, rstA.getString(DB0008.FILEDATA_SIGNCHAR));
            staB.setString(idx++, rstA.getString(DB0008.FILEDATA_SIGNCODE));
            // staB.setLong(idx++, rstA.getLong(DB0008.FILEDATA_MSOFFSET));
            staB.setInt(idx++, (int)rstA.getLong(DB0008.FILEDATA_MSOFFSET));
            staB.setString(idx++, rstA.getString(DB0008.FILEDATA_CIPHERSN));
            staB.setString(idx++, rstA.getString(DB0008.FILEDATA_HEADDATA));
            staB.setString(idx++, rstA.getString(DB0008.FILEDATA_FOOTDATA));
            staB.setString(idx++, rstA.getString(DB0008.FILEDATA_FORMATDT));
            staB.setString(idx++, rstA.getString(DB0008.FILEDATA_FILEDESP));
            staB.setDate(idx++, rstA.getDate(DB0008.FILEDATA_UPDTDATE));
            staB.setDate(idx++, rstA.getDate(DB0008.FILEDATA_MAKEDATE));

            staB.executeUpdate();
            i += 1;
        }
        rstA.close();

        System.out.println("SIZE: " + i);
    }

    private static void upgrade_Aide_TDD() throws SQLException
    {
        int i = 0;

        staB = conB.prepareStatement("INSERT INTO AIDE_TDD VALUES (?,?,?,?,?,?,?,?,?,?,?)");
        ResultSet rstA = staA.executeQuery("SELECT * FROM " + DB0008.TABLE_SOFTDATA);
        while (rstA.next())
        // if (rstA.next())
        {
            staB.clearParameters();

            int idx = 1;
            staB.setInt(idx++, rstA.getInt(DB0008.SOFTDATA_DISPORDR));
            staB.setString(idx++, rstA.getString(DB0008.SOFTDATA_SOFTINDX));
            staB.setString(idx++, rstA.getString(DB0008.SOFTDATA_CORPINDX));
            staB.setString(idx++, rstA.getString(DB0008.SOFTDATA_SOFTICON));
            staB.setString(idx++, rstA.getString(DB0008.SOFTDATA_SOFTNAME));
            staB.setString(idx++, rstA.getString(DB0008.SOFTDATA_SOFTMAIL));
            staB.setString(idx++, rstA.getString(DB0008.SOFTDATA_SOFTSITE));
            staB.setString(idx++, rstA.getString(DB0008.SOFTDATA_EXTSLIST));
            staB.setString(idx++, rstA.getString(DB0008.SOFTDATA_SOFTDESP));
            staB.setDate(idx++, rstA.getDate(DB0008.SOFTDATA_UPDTDATE));
            staB.setDate(idx++, rstA.getDate(DB0008.SOFTDATA_MAKEDATE));

            staB.executeUpdate();
            i += 1;
        }
        rstA.close();

        System.out.println("SIZE: " + i);
    }

    private static void upgrade_Aide_TDE() throws SQLException
    {
        int i = 0;

        staB = conB.prepareStatement("INSERT INTO AIDE_TDE VALUES (?,?,?,?,?,?,?,?,?,?)");
        ResultSet rstA = staA.executeQuery("SELECT * FROM " + DB0008.TABLE_CORPDATA);
        while (rstA.next())
        // if (rstA.next())
        {
            staB.clearParameters();

            int idx = 1;
            staB.setInt(idx++, rstA.getInt(DB0008.CORPDATA_DISPORDR));
            staB.setString(idx++, rstA.getString(DB0008.CORPDATA_CORPINDX));
            staB.setString(idx++, rstA.getString(DB0008.CORPDATA_NATNINDX));
            staB.setString(idx++, rstA.getString(DB0008.CORPDATA_CORPLOGO));
            staB.setString(idx++, rstA.getString(DB0008.CORPDATA_CORPLCNM));
            staB.setString(idx++, rstA.getString(DB0008.CORPDATA_CORPENNM));
            staB.setString(idx++, rstA.getString(DB0008.CORPDATA_CORPSITE));
            staB.setString(idx++, rstA.getString(DB0008.CORPDATA_CORPDESP));
            staB.setDate(idx++, rstA.getDate(DB0008.CORPDATA_UPDTDATE));
            staB.setDate(idx++, rstA.getDate(DB0008.CORPDATA_MAKEDATE));

            staB.executeUpdate();
            i += 1;
        }
        rstA.close();

        System.out.println("SIZE: " + i);
    }

    private static void upgrade_Aide_TDF() throws SQLException
    {
        int i = 0;

        staB = conB.prepareStatement("INSERT INTO AIDE_TDF VALUES (?,?,?,?,?,?)");
        ResultSet rstA = staA.executeQuery("SELECT * FROM " + DB0008.TABLE_ASOCDATA);
        while (rstA.next())
        // if (rstA.next())
        {
            staB.clearParameters();

            int idx = 1;
            staB.setInt(idx++, rstA.getInt(DB0008.ASOCDATA_DISPORDR));
            staB.setString(idx++, rstA.getString(DB0008.ASOCDATA_ASOCINDX));
            staB.setString(idx++, rstA.getString(DB0008.ASOCDATA_SOFTINDX));
            staB.setString(idx++, rstA.getString(DB0008.ASOCDATA_ASOCDESP));
            staB.setDate(idx++, rstA.getDate(DB0008.ASOCDATA_UPDTDATE));
            staB.setDate(idx++, rstA.getDate(DB0008.ASOCDATA_MAKEDATE));

            staB.executeUpdate();
            i += 1;
        }
        rstA.close();

        System.out.println("SIZE: " + i);
    }

    private static void upgrade_Aide_TDG() throws SQLException
    {
        int i = 0;

        staB = conB.prepareStatement("INSERT INTO AIDE_TDG VALUES (?,?,?,?,?,?,?)");
        ResultSet rstA = staA.executeQuery("SELECT * FROM " + DB0008.TABLE_MIMEDATA);
        while (rstA.next())
        // if (rstA.next())
        {
            staB.clearParameters();

            int idx = 1;
            staB.setInt(idx++, rstA.getInt(DB0008.MIMEDATA_DISPORDR));
            staB.setString(idx++, rstA.getString(DB0008.MIMEDATA_MIMEINDX));
            staB.setString(idx++, rstA.getString(DB0008.MIMEDATA_MIMETYPE));
            staB.setString(idx++, rstA.getString(DB0008.MIMEDATA_MIMENAME));
            staB.setString(idx++, rstA.getString(DB0008.MIMEDATA_MIMEDESP));
            staB.setDate(idx++, rstA.getDate(DB0008.MIMEDATA_UPDTDATE));
            staB.setDate(idx++, rstA.getDate(DB0008.MIMEDATA_MAKEDATE));

            staB.executeUpdate();
            i += 1;
        }
        rstA.close();

        System.out.println("SIZE: " + i);
    }

    private static void upgrade_Aide_TDH() throws SQLException
    {
        int i = 0;

        staB = conB.prepareStatement("INSERT INTO AIDE_TDH VALUES (?,?,?,?,?,?,?,?,?,?)");
        ResultSet rstA = staA.executeQuery("SELECT * FROM " + DB0008.TABLE_LINKDATA);
        while (rstA.next())
        // if (rstA.next())
        {
            staB.clearParameters();

            int idx = 1;
            staB.setInt(idx++, rstA.getInt(DB0008.LINKDATA_DISPORDR));
            staB.setString(idx++, rstA.getString(DB0008.LINKDATA_LINKINDX));
            staB.setString(idx++, rstA.getString(DB0008.LINKDATA_TYPEINDX));
            staB.setString(idx++, rstA.getString(DB0008.LINKDATA_LINKNAME));
            staB.setString(idx++, rstA.getString(DB0008.LINKDATA_LINKURLS));
            staB.setString(idx++, rstA.getString(DB0008.LINKDATA_METAKEYS));
            staB.setString(idx++, rstA.getString(DB0008.LINKDATA_METADESP));
            staB.setString(idx++, rstA.getString(DB0008.LINKDATA_LINKDESP));
            staB.setDate(idx++, rstA.getDate(DB0008.LINKDATA_UPDTDATE));
            staB.setDate(idx++, rstA.getDate(DB0008.LINKDATA_MAKEDATE));

            staB.executeUpdate();
            i += 1;
        }
        rstA.close();

        System.out.println("SIZE: " + i);
    }

    private static void upgrade_Aide_TDI() throws SQLException
    {

    }

    private static void upgrade_Aide_TDJ() throws SQLException
    {
        int i = 0;

        staB = conB.prepareStatement("INSERT INTO AIDE_TDJ VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)");
        ResultSet rstA = staA.executeQuery("SELECT * FROM " + DB0008.TABLE_NOTEDATA);
        while (rstA.next())
        // if (rstA.next())
        {
            staB.clearParameters();

            int idx = 1;
            staB.setInt(idx++, rstA.getInt(DB0008.NOTEDATA_DISPORDR));
            staB.setString(idx++, rstA.getString(DB0008.NOTEDATA_NOTEINDX));
            staB.setString(idx++, rstA.getString(DB0008.NOTEDATA_LANGINDX));
            staB.setString(idx++, rstA.getString(DB0008.NOTEDATA_NOTETYPE));
            staB.setInt(idx++, rstA.getInt(DB0008.NOTEDATA_MINDMODE));
            staB.setInt(idx++, rstA.getInt(DB0008.NOTEDATA_DATESTTY));
            staB.setInt(idx++, rstA.getInt(DB0008.NOTEDATA_DATESTTM));
            staB.setInt(idx++, rstA.getInt(DB0008.NOTEDATA_DATESTTD));
            staB.setDate(idx++, rstA.getDate(DB0008.NOTEDATA_DATESTTT));
            staB.setInt(idx++, rstA.getInt(DB0008.NOTEDATA_DATEENDY));
            staB.setInt(idx++, rstA.getInt(DB0008.NOTEDATA_DATEENDM));
            staB.setInt(idx++, rstA.getInt(DB0008.NOTEDATA_DATEENDD));
            staB.setDate(idx++, rstA.getDate(DB0008.NOTEDATA_DATEENDT));
            staB.setString(idx++, rstA.getString(DB0008.NOTEDATA_NOTEHEAD));
            staB.setString(idx++, rstA.getString(DB0008.NOTEDATA_NOTEBODY));
            staB.setString(idx++, rstA.getString(DB0008.NOTEDATA_ORIGINDT));
            staB.setString(idx++, rstA.getString(DB0008.NOTEDATA_ORIGINNT));
            staB.setString(idx++, rstA.getString(DB0008.NOTEDATA_NOTELINK));
            staB.setString(idx++, rstA.getString(DB0008.NOTEDATA_NOTEDESP));

            staB.executeUpdate();
            i += 1;
        }
        rstA.close();

        System.out.println("SIZE: " + i);
    }

    private static void upgrade_Aide_TGA() throws SQLException
    {
        int i = 0;

        staB = conB.prepareStatement("INSERT INTO AIDE_TGA VALUES (?,?,?,?,?)");
        ResultSet rstA = staA.executeQuery("SELECT * FROM " + DB0008.TABLE_TYPEDATA);
        while (rstA.next())
        // if (rstA.next())
        {
            staB.clearParameters();

            int idx = 1;
            staB.setInt(idx++, rstA.getInt(DB0008.TYPEDATA_DISPORDR));
            staB.setInt(idx++, rstA.getInt(DB0008.TYPEDATA_SYSTEMID));
            staB.setString(idx++, rstA.getString(DB0008.TYPEDATA_TYPEINDX));
            staB.setString(idx++, rstA.getString(DB0008.TYPEDATA_TYPENAME));
            staB.setString(idx++, rstA.getString(DB0008.TYPEDATA_TYPEDESP));

            staB.executeUpdate();
            i += 1;
        }
        rstA.close();

        System.out.println("SIZE: " + i);
    }

    private static void upgrade_Aide_TGB() throws SQLException
    {
        int i = 0;

        staB = conB.prepareStatement("INSERT INTO AIDE_TGB VALUES (?,?,?,?,?,?,?)");
        ResultSet rstA = staA.executeQuery("SELECT * FROM " + DB0008.TABLE_PBADDATA);
        while (rstA.next())
        // if (rstA.next())
        {
            staB.clearParameters();

            int idx = 1;
            staB.setInt(idx++, rstA.getInt(DB0008.PBADDATA_DISPORDR));
            staB.setString(idx++, rstA.getString(DB0008.PBADDATA_PBADINDX));
            staB.setString(idx++, rstA.getString(DB0008.PBADDATA_TYPEINDX));
            staB.setString(idx++, rstA.getString(DB0008.PBADDATA_PBADTEXT));
            staB.setString(idx++, rstA.getString(DB0008.PBADDATA_PBADDESP));
            staB.setDate(idx++, rstA.getDate(DB0008.PBADDATA_UPDTDATE));
            staB.setDate(idx++, rstA.getDate(DB0008.PBADDATA_MAKEDATE));

            staB.executeUpdate();
            i += 1;
        }
        rstA.close();

        System.out.println("SIZE: " + i);
    }

    private static void upgrade_Aide_TUA() throws SQLException
    {
        int i = 0;

        staB = conB.prepareStatement("INSERT INTO Aide_TUA VALUES (?,?,?,?,?,?,?,?,?,?)");
        ResultSet rstA = staA.executeQuery("SELECT * FROM " + DB0008.TABLE_IDIODATA);
        while (rstA.next())
        // if (rstA.next())
        {
            staB.clearParameters();

            int idx = 1;
            staB.setInt(idx++, rstA.getInt(DB0008.IDIODATA_DISPORDR));
            staB.setString(idx++, rstA.getString(DB0008.IDIODATA_IDIOINDX));
            staB.setString(idx++, rstA.getString(DB0008.IDIODATA_IDIOLOGO));
            staB.setString(idx++, rstA.getString(DB0008.IDIODATA_IDIOMAIL));
            staB.setString(idx++, rstA.getString(DB0008.IDIODATA_NICKNAME));
            staB.setString(idx++, rstA.getString(DB0008.IDIODATA_IDIOSIGN));
            staB.setString(idx++, rstA.getString(DB0008.IDIODATA_HOMEPAGE));
            staB.setString(idx++, rstA.getString(DB0008.IDIODATA_IDIODESP));
            staB.setDate(idx++, rstA.getDate(DB0008.IDIODATA_UPDTDATE));
            staB.setDate(idx++, rstA.getDate(DB0008.IDIODATA_MAKEDATE));

            staB.executeUpdate();
            i += 1;
        }
        rstA.close();

        System.out.println("SIZE: " + i);
    }

    private static void upgrade_Aide_TXA() throws SQLException
    {
        int i = 0;

        staB = conB.prepareStatement("INSERT INTO Aide_TXA VALUES (?,?,?,?,?)");
        ResultSet rstA = staA.executeQuery("SELECT * FROM " + DB0008.TABLE_BASEDATA);
        while (rstA.next())
        // if (rstA.next())
        {
            staB.clearParameters();

            int idx = 1;
            staB.setInt(idx++, rstA.getInt(DB0008.BASEDATA_SYSTEMID));
            staB.setInt(idx++, rstA.getInt(DB0008.BASEDATA_APARTKEY));
            staB.setString(idx++, rstA.getString(DB0008.BASEDATA_CFGVALUE));
            staB.setDate(idx++, rstA.getDate(DB0008.BASEDATA_PUBSTIME));
            staB.setString(idx++, rstA.getString(DB0008.BASEDATA_IDIOMARK));

            staB.executeUpdate();
            i += 1;
        }
        rstA.close();

        System.out.println("SIZE: " + i);
    }

    private static void upgrade_Aide_TXB() throws SQLException
    {
        int i = 0;

        staB = conB.prepareStatement("INSERT INTO Aide_TXB VALUES (?,?,?,?,?,?,?)");
        ResultSet rstA = staA.executeQuery("SELECT * FROM " + DB0008.TABLE_MESGDATA);
        while (rstA.next())
        // if (rstA.next())
        {
            staB.clearParameters();

            int idx = 1;
            staB.setInt(idx++, rstA.getInt(DB0008.MESGDATA_SYSTEMID));
            staB.setString(idx++, rstA.getString(DB0008.MESGDATA_LANGINDX));
            staB.setString(idx++, rstA.getString(DB0008.MESGDATA_MESGINDX));
            staB.setString(idx++, rstA.getString(DB0008.MESGDATA_MESGTEXT));
            staB.setString(idx++, rstA.getString(DB0008.MESGDATA_MESGDESP));
            staB.setDate(idx++, rstA.getDate(DB0008.MESGDATA_UPDTDATE));
            staB.setDate(idx++, rstA.getDate(DB0008.MESGDATA_MAKEDATE));

            staB.executeUpdate();
            i += 1;
        }
        rstA.close();

        System.out.println("SIZE: " + i);
    }

    private static void upgrade_Aide_TXC() throws SQLException
    {
        int i = 0;

        staB = conB.prepareStatement("INSERT INTO AIDE_TXC VALUES (?,?,?,?,?,?,?,?,?,?,?,?)");
        ResultSet rstA = staA.executeQuery("SELECT * FROM " + DB0008.TABLE_NATNDATA);
        while (rstA.next())
        // if (rstA.next())
        {
            staB.clearParameters();

            int idx = 1;
            staB.setInt(idx++, rstA.getInt(DB0008.NATNDATA_DISPORDR));
            staB.setString(idx++, rstA.getString(DB0008.NATNDATA_NATNINDX));
            staB.setString(idx++, rstA.getString(DB0008.NATNDATA_LANGINDX));
            staB.setString(idx++, rstA.getString(DB0008.NATNDATA_NATNSLNM));
            staB.setString(idx++, rstA.getString(DB0008.NATNDATA_NATNFLNM));
            staB.setString(idx++, rstA.getString(DB0008.NATNDATA_LCAPITAL));
            staB.setString(idx++, rstA.getString(DB0008.NATNDATA_NATNLNG1));
            staB.setString(idx++, rstA.getString(DB0008.NATNDATA_NATNLNG2));
            staB.setString(idx++, rstA.getString(DB0008.NATNDATA_COINUNIT));
            staB.setString(idx++, rstA.getString(DB0008.NATNDATA_COINPLUS));
            staB.setDate(idx++, rstA.getDate(DB0008.NATNDATA_UPDTDATE));
            staB.setDate(idx++, rstA.getDate(DB0008.NATNDATA_MAKEDATE));

            staB.executeUpdate();
            i += 1;
        }
        rstA.close();

        System.out.println("SIZE: " + i);
    }

    private static void upgrade_Aide_TXD() throws SQLException
    {
    }
}
