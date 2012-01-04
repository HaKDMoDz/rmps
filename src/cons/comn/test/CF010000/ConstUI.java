/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package cons.comn.test.CF010000;

import cons.SysCons;
import cons.id.ComnCons;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 测试软件界面控制常量
 * <li>使用说明：</li>
 * <br />
 * </ul>
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
    String URL_SOFT = SysCons.HOMEPAGE + "soft/soft0001.aspx?sid=" + ComnCons.C0FF0000_S;
    /** 电子邮件 */
    String URL_MAIL = SysCons.MAILADDR;
    // ////////////////////////////////////////////////////////////////////////
    // 语言配置标记
    // ////////////////////////////////////////////////////////////////////////
    /** 软件语言资源标记 */
    String RES_NAME = "C0FF0000";
    /** 软件标题语言资源标记 */
    String RES_TITLE = "C0FF0000.title";
    /** 软件描述信息语言资源标记 */
    String RES_DESCRIPTION = "C0FF0000.description";
    // ////////////////////////////////////////////////////////////////////////
    // 用户配置标记
    // ////////////////////////////////////////////////////////////////////////
    /** 软件配置数据 */
    String CFG_SOFT = "C0FF0000.soft";
}
