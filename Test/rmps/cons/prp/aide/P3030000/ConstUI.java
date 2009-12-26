/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package cons.prp.aide.P3030000;

import cons.SysCons;
import cons.id.PrpCons;

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
public interface ConstUI
{
    // ////////////////////////////////////////////////////////////////////////
    // 系统唯一标记
    // ////////////////////////////////////////////////////////////////////////
    /** 软件版本 */
    String VER_CODE = "1.2.0.0";
    /** 软件首页 */
    String URL_SOFT = SysCons.HOMEPAGE + "soft/soft0001.aspx?sid=" + PrpCons.P3030000_S;
    /** 电子邮件 */
    String URL_MAIL = SysCons.MAILADDR;
    // ////////////////////////////////////////////////////////////////////////
    // 语言配置标记
    // ////////////////////////////////////////////////////////////////////////
    /** 软件语言资源标记 */
    String RES_NAME = "P3030000";
    /** 软件标题语言资源标记 */
    String RES_TITLE = "P3030000.title";
    /** 软件描述信息语言资源标记 */
    String RES_DESCRIPTION = "P3030000.description";
    int COMN_SIZE_MODECH = 1;
    int COMN_SIZE_MODE16 = 4;
    int COMN_SIZE_MODE10 = 5;
    int COMN_SIZE_MODE08 = 6;
    int COMN_SIZE_MODE02 = 16;
    String QUERY_CHAR = "c:";
    String QUERY_NUM = "n:";
    String QUERY_SP = "~";
}
