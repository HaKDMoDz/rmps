/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package cons.comn.rmps.C4010000;

import cons.SysCons;
import cons.id.ComnCons;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br />
 * TODO: 使用说明
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
    String URL_SOFT = SysCons.HOMEPAGE + "soft/soft0001.aspx?sid=" + ComnCons.C0020000_S;
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
    // ////////////////////////////////////////////////////////////////////////
    // 显示控制标记
    // ////////////////////////////////////////////////////////////////////////
    /** 从右到左滚动 */
    int SCROLL_R2L = 0;
    /** 从左到右滚动 */
    int SCROLL_L2R = 1;
    /** 从上到下滚动 */
    int SCROLL_T2B = 2;
    /** 从下到上滚动 */
    int SCROLL_B2T = 3;
}
