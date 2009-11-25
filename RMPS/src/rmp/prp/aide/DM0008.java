/*
 * FileName:       DM0008.java
 * CreateDate:     2007-7-15 下午01:33:04
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide;

import cons.prp.aide.extparse.DB0008;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br>
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br>
 * TODO: 使用说明
 * </ul>
 * <p>
 * 版本： RMPS V1.0.0.0
 * </p>
 * <p>
 * 作者： Amon
 * </p>
 * <p>
 * 日期： 2007-7-15 下午01:33:04
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class DM0008
{
    public static void createTable()
    {
        createTable_Aide_TDA();
        createTable_Aide_TDB();
        createTable_Aide_TDC();
        createTable_Aide_TDD();
        createTable_Aide_TDE();
        createTable_Aide_TDF();
        createTable_Aide_TDG();
        createTable_Aide_TDH();
        createTable_Aide_TDI();
        createTable_Aide_TDJ();

        createTable_Aide_TGA();
        createTable_Aide_TGB();

        createTable_Aide_TUA();

        createTable_Aide_TXA();
        createTable_Aide_TXB();
        createTable_Aide_TXC();
    }

    private static void createTable_Aide_TDA()
    {
        StringBuffer sb = new StringBuffer();

        sb.append("CREATE TABLE ").append(DB0008.TABLE_EXTSDATA);

        sb.append("(");
        sb.append(DB0008.EXTSDATA_ACSTIMES).append(" INTEGER, ");
        sb.append(DB0008.EXTSDATA_PLATINDX).append(" INTEGER, ");
        sb.append(DB0008.EXTSDATA_XCPUBITS).append(" INTEGER, ");
        sb.append(DB0008.EXTSDATA_EXTSINDX).append(" VARCHAR(").append(DB0008.EXTSDATA_EXTSINDX_SIZE).append("), ");
        sb.append(DB0008.EXTSDATA_CORPINDX).append(" VARCHAR(").append(DB0008.EXTSDATA_CORPINDX_SIZE).append("), ");
        sb.append(DB0008.EXTSDATA_SOFTINDX).append(" VARCHAR(").append(DB0008.EXTSDATA_SOFTINDX_SIZE).append("), ");
        sb.append(DB0008.EXTSDATA_FILEINDX).append(" VARCHAR(").append(DB0008.EXTSDATA_FILEINDX_SIZE).append("), ");
        sb.append(DB0008.EXTSDATA_DESPINDX).append(" VARCHAR(").append(DB0008.EXTSDATA_DESPINDX_SIZE).append("), ");
        sb.append(DB0008.EXTSDATA_ASOCINDX).append(" VARCHAR(").append(DB0008.EXTSDATA_ASOCINDX_SIZE).append("), ");
        sb.append(DB0008.EXTSDATA_MIMEINDX).append(" VARCHAR(").append(DB0008.EXTSDATA_MIMEINDX_SIZE).append("), ");
        sb.append(DB0008.EXTSDATA_TYPEINDX).append(" VARCHAR(").append(DB0008.EXTSDATA_TYPEINDX_SIZE).append("), ");
        sb.append(DB0008.EXTSDATA_IDIOINDX).append(" VARCHAR(").append(DB0008.EXTSDATA_IDIOINDX_SIZE).append("), ");
        sb.append(DB0008.EXTSDATA_UPDTDATE).append(" TIMESTAMP, ");
        sb.append(DB0008.EXTSDATA_MAKEDATE).append(" TIMESTAMP, ");
        sb.append(DB0008.EXTSDATA_EXTSNAME).append(" VARCHAR(").append(DB0008.EXTSDATA_EXTSNAME_SIZE).append("), ");

        sb.append("PRIMARY KEY (").append(DB0008.EXTSDATA_EXTSINDX).append(", ");
        sb.append(DB0008.EXTSDATA_SOFTINDX).append(")");
        sb.append(")");

        System.out.println(sb);
    }

    private static void createTable_Aide_TDB()
    {
        StringBuffer sb = new StringBuffer();

        sb.append("CREATE TABLE ").append(DB0008.TABLE_DESPDATA);

        sb.append("(");
        sb.append(DB0008.DESPDATA_DESPINDX).append(" VARCHAR(").append(DB0008.DESPDATA_DESPINDX_SIZE).append("), ");
        sb.append(DB0008.DESPDATA_LANGINDX).append(" VARCHAR(").append(DB0008.DESPDATA_LANGINDX_SIZE).append("), ");
        sb.append(DB0008.DESPDATA_EXTSDESP).append(" VARCHAR(").append(DB0008.DESPDATA_EXTSDESP_SIZE).append("), ");
        sb.append(DB0008.DESPDATA_IDIOMARK).append(" VARCHAR(").append(DB0008.DESPDATA_IDIOMARK_SIZE).append("), ");
        sb.append(DB0008.DESPDATA_UPDTDATE).append(" TIMESTAMP, ");
        sb.append(DB0008.DESPDATA_MAKEDATE).append(" TIMESTAMP, ");

        sb.append("PRIMARY KEY (").append(DB0008.DESPDATA_DESPINDX).append(", ");
        sb.append(DB0008.DESPDATA_LANGINDX).append(")");
        sb.append(")");

        System.out.println(sb);
    }

    private static void createTable_Aide_TDC()
    {
        StringBuffer sb = new StringBuffer();

        sb.append("CREATE TABLE ").append(DB0008.TABLE_FILEDATA);

        sb.append("(");
        sb.append(DB0008.FILEDATA_DISPORDR).append(" INTEGER, ");
        sb.append(DB0008.FILEDATA_FILEINDX).append(" VARCHAR(").append(DB0008.FILEDATA_FILEINDX_SIZE).append("), ");
        sb.append(DB0008.FILEDATA_SOFTINDX).append(" VARCHAR(").append(DB0008.FILEDATA_SOFTINDX_SIZE).append("), ");
        sb.append(DB0008.FILEDATA_FILEICON).append(" VARCHAR(").append(DB0008.FILEDATA_FILEICON_SIZE).append("), ");
        sb.append(DB0008.FILEDATA_SIGNCHAR).append(" VARCHAR(").append(DB0008.FILEDATA_SIGNCHAR_SIZE).append("), ");
        sb.append(DB0008.FILEDATA_SIGNCODE).append(" VARCHAR(").append(DB0008.FILEDATA_SIGNCODE_SIZE).append("), ");
        sb.append(DB0008.FILEDATA_MSOFFSET).append(" BIGINT, ");
        sb.append(DB0008.FILEDATA_CIPHERSN).append(" VARCHAR(").append(DB0008.FILEDATA_CIPHERSN_SIZE).append("), ");
        sb.append(DB0008.FILEDATA_HEADDATA).append(" VARCHAR(").append(DB0008.FILEDATA_HEADDATA_SIZE).append("), ");
        sb.append(DB0008.FILEDATA_FOOTDATA).append(" VARCHAR(").append(DB0008.FILEDATA_FOOTDATA_SIZE).append("), ");
        sb.append(DB0008.FILEDATA_FORMATDT).append(" VARCHAR(").append(DB0008.FILEDATA_FORMATDT_SIZE).append("), ");
        sb.append(DB0008.FILEDATA_FILEDESP).append(" VARCHAR(").append(DB0008.FILEDATA_FILEDESP_SIZE).append("), ");
        sb.append(DB0008.FILEDATA_UPDTDATE).append(" TIMESTAMP, ");
        sb.append(DB0008.FILEDATA_MAKEDATE).append(" TIMESTAMP, ");

        sb.append("PRIMARY KEY (").append(DB0008.FILEDATA_FILEINDX).append(")");
        sb.append(")");

        System.out.println(sb);
    }

    private static void createTable_Aide_TDD()
    {
        StringBuffer sb = new StringBuffer();

        sb.append("CREATE TABLE ").append(DB0008.TABLE_SOFTDATA);

        sb.append("(");
        sb.append(DB0008.SOFTDATA_DISPORDR).append(" INTEGER, ");
        sb.append(DB0008.SOFTDATA_SOFTINDX).append(" VARCHAR(").append(DB0008.SOFTDATA_SOFTINDX_SIZE).append("), ");
        sb.append(DB0008.SOFTDATA_CORPINDX).append(" VARCHAR(").append(DB0008.SOFTDATA_CORPINDX_SIZE).append("), ");
        sb.append(DB0008.SOFTDATA_SOFTICON).append(" VARCHAR(").append(DB0008.SOFTDATA_SOFTICON_SIZE).append("), ");
        sb.append(DB0008.SOFTDATA_SOFTNAME).append(" VARCHAR(").append(DB0008.SOFTDATA_SOFTNAME_SIZE).append("), ");
        sb.append(DB0008.SOFTDATA_SOFTMAIL).append(" VARCHAR(").append(DB0008.SOFTDATA_SOFTMAIL_SIZE).append("), ");
        sb.append(DB0008.SOFTDATA_SOFTSITE).append(" VARCHAR(").append(DB0008.SOFTDATA_SOFTSITE_SIZE).append("), ");
        sb.append(DB0008.SOFTDATA_EXTSLIST).append(" VARCHAR(").append(DB0008.SOFTDATA_EXTSLIST_SIZE).append("), ");
        sb.append(DB0008.SOFTDATA_SOFTDESP).append(" VARCHAR(").append(DB0008.SOFTDATA_SOFTDESP_SIZE).append("), ");
        sb.append(DB0008.SOFTDATA_UPDTDATE).append(" TIMESTAMP, ");
        sb.append(DB0008.SOFTDATA_MAKEDATE).append(" TIMESTAMP, ");

        sb.append("PRIMARY KEY (").append(DB0008.SOFTDATA_SOFTINDX).append(")");
        sb.append(")");

        System.out.println(sb);
    }

    private static void createTable_Aide_TDE()
    {
        StringBuffer sb = new StringBuffer();

        sb.append("CREATE TABLE ").append(DB0008.TABLE_CORPDATA);

        sb.append("(");
        sb.append(DB0008.CORPDATA_DISPORDR).append(" INTEGER, ");
        sb.append(DB0008.CORPDATA_CORPINDX).append(" VARCHAR(").append(DB0008.CORPDATA_CORPINDX_SIZE).append("), ");
        sb.append(DB0008.CORPDATA_NATNINDX).append(" VARCHAR(").append(DB0008.CORPDATA_NATNINDX_SIZE).append("), ");
        sb.append(DB0008.CORPDATA_CORPLOGO).append(" VARCHAR(").append(DB0008.CORPDATA_CORPLOGO_SIZE).append("), ");
        sb.append(DB0008.CORPDATA_CORPLCNM).append(" VARCHAR(").append(DB0008.CORPDATA_CORPLCNM_SIZE).append("), ");
        sb.append(DB0008.CORPDATA_CORPENNM).append(" VARCHAR(").append(DB0008.CORPDATA_CORPENNM_SIZE).append("), ");
        sb.append(DB0008.CORPDATA_CORPSITE).append(" VARCHAR(").append(DB0008.CORPDATA_CORPSITE_SIZE).append("), ");
        sb.append(DB0008.CORPDATA_CORPDESP).append(" VARCHAR(").append(DB0008.CORPDATA_CORPDESP_SIZE).append("), ");
        sb.append(DB0008.CORPDATA_UPDTDATE).append(" TIMESTAMP, ");
        sb.append(DB0008.CORPDATA_MAKEDATE).append(" TIMESTAMP, ");

        sb.append("PRIMARY KEY (").append(DB0008.CORPDATA_CORPINDX).append(")");
        sb.append(")");

        System.out.println(sb);
    }

    private static void createTable_Aide_TDF()
    {
        StringBuffer sb = new StringBuffer();

        sb.append("CREATE TABLE ").append(DB0008.TABLE_ASOCDATA);

        sb.append("(");
        sb.append(DB0008.ASOCDATA_DISPORDR).append(" INTEGER, ");
        sb.append(DB0008.ASOCDATA_ASOCINDX).append(" VARCHAR(").append(DB0008.ASOCDATA_ASOCINDX_SIZE).append("), ");
        sb.append(DB0008.ASOCDATA_SOFTINDX).append(" VARCHAR(").append(DB0008.ASOCDATA_SOFTINDX_SIZE).append("), ");
        sb.append(DB0008.ASOCDATA_ASOCDESP).append(" VARCHAR(").append(DB0008.ASOCDATA_ASOCDESP_SIZE).append("), ");
        sb.append(DB0008.ASOCDATA_UPDTDATE).append(" TIMESTAMP, ");
        sb.append(DB0008.ASOCDATA_MAKEDATE).append(" TIMESTAMP, ");

        sb.append("PRIMARY KEY (").append(DB0008.ASOCDATA_ASOCINDX).append(", ");
        sb.append(DB0008.ASOCDATA_SOFTINDX).append(")");
        sb.append(")");

        System.out.println(sb);
    }

    private static void createTable_Aide_TDG()
    {
        StringBuffer sb = new StringBuffer();

        sb.append("CREATE TABLE ").append(DB0008.TABLE_MIMEDATA);

        sb.append("(");
        sb.append(DB0008.MIMEDATA_DISPORDR).append(" INTEGER, ");
        sb.append(DB0008.MIMEDATA_MIMEINDX).append(" VARCHAR(").append(DB0008.MIMEDATA_MIMEINDX_SIZE).append("), ");
        sb.append(DB0008.MIMEDATA_MIMETYPE).append(" VARCHAR(").append(DB0008.MIMEDATA_MIMETYPE_SIZE).append("), ");
        sb.append(DB0008.MIMEDATA_MIMENAME).append(" VARCHAR(").append(DB0008.MIMEDATA_MIMENAME_SIZE).append("), ");
        sb.append(DB0008.MIMEDATA_MIMEDESP).append(" VARCHAR(").append(DB0008.MIMEDATA_MIMEDESP_SIZE).append("), ");
        sb.append(DB0008.MIMEDATA_UPDTDATE).append(" TIMESTAMP, ");
        sb.append(DB0008.MIMEDATA_MAKEDATE).append(" TIMESTAMP, ");

        sb.append("PRIMARY KEY (").append(DB0008.MIMEDATA_MIMEINDX).append(", ");
        sb.append(DB0008.MIMEDATA_MIMETYPE).append(")");
        sb.append(")");

        System.out.println(sb);
    }

    private static void createTable_Aide_TDH()
    {
        StringBuffer sb = new StringBuffer();

        sb.append("CREATE TABLE ").append(DB0008.TABLE_LINKDATA);

        sb.append("(");
        sb.append(DB0008.LINKDATA_DISPORDR).append(" INTEGER, ");
        sb.append(DB0008.LINKDATA_LINKINDX).append(" VARCHAR(").append(DB0008.LINKDATA_LINKINDX_SIZE).append("), ");
        sb.append(DB0008.LINKDATA_TYPEINDX).append(" VARCHAR(").append(DB0008.LINKDATA_TYPEINDX_SIZE).append("), ");
        sb.append(DB0008.LINKDATA_LINKNAME).append(" VARCHAR(").append(DB0008.LINKDATA_LINKNAME_SIZE).append("), ");
        sb.append(DB0008.LINKDATA_LINKURLS).append(" VARCHAR(").append(DB0008.LINKDATA_LINKURLS_SIZE).append("), ");
        sb.append(DB0008.LINKDATA_METAKEYS).append(" VARCHAR(").append(DB0008.LINKDATA_METAKEYS_SIZE).append("), ");
        sb.append(DB0008.LINKDATA_METADESP).append(" VARCHAR(").append(DB0008.LINKDATA_METADESP_SIZE).append("), ");
        sb.append(DB0008.LINKDATA_LINKDESP).append(" VARCHAR(").append(DB0008.LINKDATA_LINKDESP_SIZE).append("), ");
        sb.append(DB0008.LINKDATA_UPDTDATE).append(" TIMESTAMP, ");
        sb.append(DB0008.LINKDATA_MAKEDATE).append(" TIMESTAMP, ");

        sb.append("PRIMARY KEY (").append(DB0008.LINKDATA_LINKINDX).append(")");
        sb.append(")");

        System.out.println(sb);
    }

    private static void createTable_Aide_TDI()
    {
        StringBuffer sb = new StringBuffer();

        sb.append("CREATE TABLE Aide_TDI");

        sb.append("(");
        sb.append("DIA INTEGER");
        sb.append(")");

        System.out.println(sb);
    }

    private static void createTable_Aide_TDJ()
    {
        StringBuffer sb = new StringBuffer();

        sb.append("CREATE TABLE ").append(DB0008.TABLE_NOTEDATA);

        sb.append("(");
        sb.append(DB0008.NOTEDATA_DISPORDR).append(" INTEGER, ");
        sb.append(DB0008.NOTEDATA_NOTEINDX).append(" VARCHAR(").append(DB0008.NOTEDATA_NOTEINDX_SIZE).append("), ");
        sb.append(DB0008.NOTEDATA_LANGINDX).append(" VARCHAR(").append(DB0008.NOTEDATA_LANGINDX_SIZE).append("), ");
        sb.append(DB0008.NOTEDATA_NOTETYPE).append(" VARCHAR(").append(DB0008.NOTEDATA_NOTETYPE_SIZE).append("), ");
        sb.append(DB0008.NOTEDATA_MINDMODE).append(" INTEGER, ");
        sb.append(DB0008.NOTEDATA_DATESTTY).append(" INTEGER, ");
        sb.append(DB0008.NOTEDATA_DATESTTM).append(" INTEGER, ");
        sb.append(DB0008.NOTEDATA_DATESTTD).append(" INTEGER, ");
        sb.append(DB0008.NOTEDATA_DATESTTT).append(" TIMESTAMP, ");
        sb.append(DB0008.NOTEDATA_DATEENDY).append(" INTEGER, ");
        sb.append(DB0008.NOTEDATA_DATEENDM).append(" INTEGER, ");
        sb.append(DB0008.NOTEDATA_DATEENDD).append(" INTEGER, ");
        sb.append(DB0008.NOTEDATA_DATEENDT).append(" TIMESTAMP, ");
        sb.append(DB0008.NOTEDATA_NOTEHEAD).append(" VARCHAR(").append(DB0008.NOTEDATA_NOTEHEAD_SIZE).append("), ");
        sb.append(DB0008.NOTEDATA_NOTEBODY).append(" VARCHAR(").append(DB0008.NOTEDATA_NOTEBODY_SIZE).append("), ");
        sb.append(DB0008.NOTEDATA_ORIGINDT).append(" VARCHAR(").append(DB0008.NOTEDATA_ORIGINDT_SIZE).append("), ");
        sb.append(DB0008.NOTEDATA_ORIGINNT).append(" VARCHAR(").append(DB0008.NOTEDATA_ORIGINNT_SIZE).append("), ");
        sb.append(DB0008.NOTEDATA_NOTELINK).append(" VARCHAR(").append(DB0008.NOTEDATA_NOTELINK_SIZE).append("), ");
        sb.append(DB0008.NOTEDATA_NOTEDESP).append(" VARCHAR(").append(DB0008.NOTEDATA_NOTEDESP_SIZE).append("), ");

        sb.append("PRIMARY KEY (").append(DB0008.NOTEDATA_NOTEINDX).append(", ");
        sb.append(DB0008.NOTEDATA_LANGINDX).append(")");
        sb.append(")");

        System.out.println(sb);
    }

    private static void createTable_Aide_TGA()
    {
        StringBuffer sb = new StringBuffer();

        sb.append("CREATE TABLE ").append(DB0008.TABLE_TYPEDATA);

        sb.append("(");
        sb.append(DB0008.TYPEDATA_DISPORDR).append(" INTEGER, ");
        sb.append(DB0008.TYPEDATA_SYSTEMID).append(" INTEGER, ");
        sb.append(DB0008.TYPEDATA_TYPEINDX).append(" VARCHAR(").append(DB0008.TYPEDATA_TYPEINDX_SIZE).append("), ");
        sb.append(DB0008.TYPEDATA_TYPENAME).append(" VARCHAR(").append(DB0008.TYPEDATA_TYPENAME_SIZE).append("), ");
        sb.append(DB0008.TYPEDATA_TYPEDESP).append(" VARCHAR(").append(DB0008.TYPEDATA_TYPEDESP_SIZE).append("), ");

        sb.append("PRIMARY KEY (").append(DB0008.TYPEDATA_SYSTEMID).append(", ");
        sb.append(DB0008.TYPEDATA_TYPEINDX).append(")");
        sb.append(")");

        System.out.println(sb);
    }

    private static void createTable_Aide_TGB()
    {
        StringBuffer sb = new StringBuffer();

        sb.append("CREATE TABLE ").append(DB0008.TABLE_PBADDATA);

        sb.append("(");
        sb.append(DB0008.PBADDATA_DISPORDR).append(" INTEGER, ");
        sb.append(DB0008.PBADDATA_PBADINDX).append(" VARCHAR(").append(DB0008.PBADDATA_PBADINDX_SIZE).append("), ");
        sb.append(DB0008.PBADDATA_TYPEINDX).append(" VARCHAR(").append(DB0008.PBADDATA_TYPEINDX_SIZE).append("), ");
        sb.append(DB0008.PBADDATA_PBADTEXT).append(" VARCHAR(").append(DB0008.PBADDATA_PBADTEXT_SIZE).append("), ");
        sb.append(DB0008.PBADDATA_PBADDESP).append(" VARCHAR(").append(DB0008.PBADDATA_PBADDESP_SIZE).append("), ");
        sb.append(DB0008.PBADDATA_UPDTDATE).append(" TIMESTAMP, ");
        sb.append(DB0008.PBADDATA_MAKEDATE).append(" TIMESTAMP, ");

        sb.append("PRIMARY KEY (").append(DB0008.PBADDATA_PBADINDX).append(")");
        sb.append(")");

        System.out.println(sb);
    }

    private static void createTable_Aide_TUA()
    {
        StringBuffer sb = new StringBuffer();

        sb.append("CREATE TABLE ").append(DB0008.TABLE_IDIODATA);

        sb.append("(");
        sb.append(DB0008.IDIODATA_DISPORDR).append(" INTEGER, ");
        sb.append(DB0008.IDIODATA_IDIOINDX).append(" VARCHAR(").append(DB0008.IDIODATA_IDIOINDX_SIZE).append("), ");
        sb.append(DB0008.IDIODATA_IDIOLOGO).append(" VARCHAR(").append(DB0008.IDIODATA_IDIOLOGO_SIZE).append("), ");
        sb.append(DB0008.IDIODATA_IDIOMAIL).append(" VARCHAR(").append(DB0008.IDIODATA_IDIOMAIL_SIZE).append("), ");
        sb.append(DB0008.IDIODATA_NICKNAME).append(" VARCHAR(").append(DB0008.IDIODATA_NICKNAME_SIZE).append("), ");
        sb.append(DB0008.IDIODATA_IDIOSIGN).append(" VARCHAR(").append(DB0008.IDIODATA_IDIOSIGN_SIZE).append("), ");
        sb.append(DB0008.IDIODATA_HOMEPAGE).append(" VARCHAR(").append(DB0008.IDIODATA_HOMEPAGE_SIZE).append("), ");
        sb.append(DB0008.IDIODATA_IDIODESP).append(" VARCHAR(").append(DB0008.IDIODATA_IDIODESP_SIZE).append("), ");
        sb.append(DB0008.IDIODATA_UPDTDATE).append(" TIMESTAMP, ");
        sb.append(DB0008.IDIODATA_MAKEDATE).append(" TIMESTAMP, ");

        sb.append("PRIMARY KEY (").append(DB0008.IDIODATA_IDIOINDX).append(")");
        sb.append(")");

        System.out.println(sb);
    }

    private static void createTable_Aide_TXA()
    {
        StringBuffer sb = new StringBuffer();

        sb.append("CREATE TABLE ").append(DB0008.TABLE_BASEDATA);

        sb.append("(");
        sb.append(DB0008.BASEDATA_SYSTEMID).append(" INTEGER, ");
        sb.append(DB0008.BASEDATA_APARTKEY).append(" INTEGER, ");
        sb.append(DB0008.BASEDATA_CFGVALUE).append(" VARCHAR(").append(DB0008.BASEDATA_CFGVALUE_SIZE).append("), ");
        sb.append(DB0008.BASEDATA_PUBSTIME).append(" TIMESTAMP, ");
        sb.append(DB0008.BASEDATA_IDIOMARK).append(" VARCHAR(").append(DB0008.BASEDATA_IDIOMARK_SIZE).append("), ");

        sb.append("PRIMARY KEY (").append(DB0008.BASEDATA_SYSTEMID).append(", ");
        sb.append(DB0008.BASEDATA_APARTKEY).append(")");
        sb.append(")");

        System.out.println(sb);
    }

    private static void createTable_Aide_TXB()
    {
        StringBuffer sb = new StringBuffer();

        sb.append("CREATE TABLE ").append(DB0008.TABLE_MESGDATA);

        sb.append("(");
        sb.append(DB0008.MESGDATA_SYSTEMID).append(" INTEGER, ");
        sb.append(DB0008.MESGDATA_LANGINDX).append(" VARCHAR(").append(DB0008.MESGDATA_LANGINDX_SIZE).append("), ");
        sb.append(DB0008.MESGDATA_MESGINDX).append(" VARCHAR(").append(DB0008.MESGDATA_MESGINDX_SIZE).append("), ");
        sb.append(DB0008.MESGDATA_MESGTEXT).append(" VARCHAR(").append(DB0008.MESGDATA_MESGTEXT_SIZE).append("), ");
        sb.append(DB0008.MESGDATA_MESGDESP).append(" VARCHAR(").append(DB0008.MESGDATA_MESGDESP_SIZE).append("), ");
        sb.append(DB0008.MESGDATA_UPDTDATE).append(" TIMESTAMP, ");
        sb.append(DB0008.MESGDATA_MAKEDATE).append(" TIMESTAMP, ");

        sb.append("PRIMARY KEY (").append(DB0008.MESGDATA_SYSTEMID).append(", ");
        sb.append(DB0008.MESGDATA_LANGINDX).append(", ");
        sb.append(DB0008.MESGDATA_MESGINDX).append(")");
        sb.append(")");

        System.out.println(sb);
    }

    private static void createTable_Aide_TXC()
    {
        StringBuffer sb = new StringBuffer();

        sb.append("CREATE TABLE ").append(DB0008.TABLE_NATNDATA);

        sb.append("(");
        sb.append(DB0008.NATNDATA_DISPORDR).append(" INTEGER, ");
        sb.append(DB0008.NATNDATA_NATNINDX).append(" VARCHAR(").append(DB0008.NATNDATA_NATNINDX_SIZE).append("), ");
        sb.append(DB0008.NATNDATA_LANGINDX).append(" VARCHAR(").append(DB0008.NATNDATA_LANGINDX_SIZE).append("), ");
        sb.append(DB0008.NATNDATA_NATNSLNM).append(" VARCHAR(").append(DB0008.NATNDATA_NATNSLNM_SIZE).append("), ");
        sb.append(DB0008.NATNDATA_NATNFLNM).append(" VARCHAR(").append(DB0008.NATNDATA_NATNFLNM_SIZE).append("), ");
        sb.append(DB0008.NATNDATA_LCAPITAL).append(" VARCHAR(").append(DB0008.NATNDATA_LCAPITAL_SIZE).append("), ");
        sb.append(DB0008.NATNDATA_NATNLNG1).append(" VARCHAR(").append(DB0008.NATNDATA_NATNLNG1_SIZE).append("), ");
        sb.append(DB0008.NATNDATA_NATNLNG2).append(" VARCHAR(").append(DB0008.NATNDATA_NATNLNG2_SIZE).append("), ");
        sb.append(DB0008.NATNDATA_COINUNIT).append(" VARCHAR(").append(DB0008.NATNDATA_COINUNIT_SIZE).append("), ");
        sb.append(DB0008.NATNDATA_COINPLUS).append(" VARCHAR(").append(DB0008.NATNDATA_COINPLUS_SIZE).append("), ");
        sb.append(DB0008.NATNDATA_UPDTDATE).append(" TIMESTAMP, ");
        sb.append(DB0008.NATNDATA_MAKEDATE).append(" TIMESTAMP, ");

        sb.append("PRIMARY KEY (").append(DB0008.NATNDATA_NATNINDX).append(",");
        sb.append(DB0008.NATNDATA_LANGINDX).append(")");
        sb.append(")");

        System.out.println(sb);
    }
}
