/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package cons;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * RMPS登录用户配置信息常量类<br>
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public interface CfgCons
{
    // ////////////////////////////////////////////////////////////////////////
    // 语言配置
    // ////////////////////////////////////////////////////////////////////////
    /** 界面语言 */
    String CFG_LANG = "lang";
    /** 语言索引ID */
    String CFG_LANG_ID = "lang.id";
    /** 语言名称 */
    String CFG_LANG_NAME = "lang.name";
    /** 语言英语名称 */
    String CFG_LANG_NAME_EN = "lang.name.en";
    /** 语言本语名称 */
    String CFG_LANG_NAME_LC = "lang.name.lc";
    // ////////////////////////////////////////////////////////////////////////
    // 界面配置
    // ////////////////////////////////////////////////////////////////////////
    /** 界面风格 */
    String CFG_LNF = "lnf";
    /** 界面风格类型 */
    String CFG_LNF_TYPE = "lnf.type";
    /** 界面风格名称 */
    String CFG_LNF_NAME = "lnf.name";
    /** 窗口配置 */
    String CFG_WND = "wnd";
    /** 窗口总在最上 */
    String CFG_WND_EVERTOP = "wnd.ever_top";
    /** 窗口禁止移动 */
    String CFG_WND_LOCKPOS = "wnd.lock_pos";
    // ////////////////////////////////////////////////////////////////////////
    // 用户登录
    // ////////////////////////////////////////////////////////////////////////
    /** 登录 */
    String SIGN_IN = "singIn";
    /** 注册 */
    String SIGN_UP = "signUp";
    /** 登出 */
    String SIGN_OUT = "signOut";
    /** 登录错误 */
    String SIGN_ERR = "signErr";
    /** 修改口令 */
    String SIGN_PWD = "signPwd";
    String DEF_TRUE = "true";
    String DEF_FALSE = "false";
}
