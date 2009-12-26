/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package cons.prp;

import cons.SysCons;

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
    /** 后缀解析系统当前软件版本 */
    String VER_SOFT = "1.0.0.0";
    /** 软件首页 */
    String URL_SOFT = SysCons.HOMEPAGE;
    /** 电子邮件 */
    String URL_MAIL = SysCons.MAILADDR;
    // ////////////////////////////////////////////////////////////////////////
    // 界面语言资源区域
    // ////////////////////////////////////////////////////////////////////////
    // ----------------------------------------------------
    // 界面风格
    // ----------------------------------------------------
    String PROP_SKINNAME = "skinname";
    /** 基本界面风格 */
    String SKIN_BASIC_NUM = "basic_num";     // 风格数量
    String SKIN_BASIC_TXT = "basic_txt";     // 显示名称
    String SKIN_BASIC_TIP = "basic_tip";     // 快捷提示
    String SKIN_BASIC_KEY = "basic_key";     // 类路径
    /** 定制界面风格 */
    String SKIN_SYNTH_NUM = "synth_num";
    String SKIN_SYNTH_TXT = "synth_txt";
    String SKIN_SYNTH_TIP = "synth_tip";
    String SKIN_SYNTH_KEY = "synth_key";
    // ----------------------------------------------------
    // 界面语言
    // ----------------------------------------------------
    String PROP_LANGNAME = "langname";
    /** 界面语言 */
    String LANGUAGE_NUM = "lang_num";
    String LANGUAGE_TXT = "lang_txt";
    String LANGUAGE_TIP = "lang_tip";
    String LANGUAGE_KEY = "lang_key";
    String LANG_SYSTEM = "system";
}
