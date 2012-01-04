/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package cons.prp.aide.P3080000;

import cons.SysCons;
import cons.id.PrpCons;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br />
 * TODO: 使用说明
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
    String VER_CODE = "1.0.0.0";
    /** 软件首页 */
    String URL_SOFT = SysCons.HOMEPAGE + "soft/soft0001.aspx?sid=" + PrpCons.P3080000_S;
    /** 电子邮件 */
    String URL_MAIL = SysCons.MAILADDR;
    // ////////////////////////////////////////////////////////////////////////
    // 语言配置标记
    // ////////////////////////////////////////////////////////////////////////
    /** 软件语言资源标记 */
    String RES_NAME = "P3080000";
    /** 软件标题语言资源标记 */
    String RES_TITLE = "P3080000.title";
    /** 软件描述信息语言资源标记 */
    String RES_DESCRIPTION = "P3080000.description";
    // ////////////////////////////////////////////////////////////////////////
    // 用户配置标记
    // ////////////////////////////////////////////////////////////////////////
    /** 用户配置时区 */
    String CFG_TIME_ZONE = "P3080000.time_zone";
    /** 图标路径 */
    String PATH_PICT = "/prp/aide/P3080000/default/{0}.png";
}
