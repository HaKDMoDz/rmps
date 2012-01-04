/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package com.amonsoft.skin;

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
public interface ISkin
{
    // ////////////////////////////////////////////////////////////////////////
    // 已有界面风格
    // ////////////////////////////////////////////////////////////////////////
    /** 基本界面风格 */
    String LF_TYPE_BASIC = "basic";
    /** 定制界面风格 */
    String LF_TYPE_SYNTH = "synth";
    /** 系统默认风格 */
    String LF_TYPE_SYSTEM = "system";
    // ----------------------------------------------------
    // 界面风格
    // ----------------------------------------------------
    /** GTK 界面风格 */
    String LF_NAME_GTK = "com.sun.java.swing.plaf.gtk.GTKLookAndFeel";
    /** Metal 界面风格 */
    String LF_NAME_METAL = "javax.swing.plaf.metal.MetalLookAndFeel";
    /** Motif 界面风格 */
    String LF_NAME_MOTIF = "com.sun.java.swing.plaf.motif.MotifLookAndFeel";
    /** Windows XP界面风格 */
    String LF_NAME_WINDOWSXP = "com.sun.java.swing.plaf.windows.WindowsLookAndFeel";
    /** Windows 经典界面风格 */
    String LF_NAME_WINDOWSME = "com.sun.java.swing.plaf.windows.WindowsClassicLookAndFeel";
    // ----------------------------------------------------
    // 风格主题
    // ----------------------------------------------------
    /** 默认主题 */
    String TM_SYNTN_DEFAULT = "default";
    /** 海洋主题 */
    String TM_METAL_OCEAN = "ocean";
    /** 金属主题 */
    String TM_METAL_METAL = "metal";
    // ////////////////////////////////////////////////////////////////////////
    // 面板对象
    // ////////////////////////////////////////////////////////////////////////
    String PANEL_BASE = "basePanel";
    String PANEL_HEAD = "headPanel";
    String PANEL_LIST = "listPanel";
    String PANEL_TAIL = "tailPanel";
    String PANEL_TOOL = "toolPanel";
    String PANEL_VIEW = "viewPanel";
    String CONTAINER = "amonPanel";
    // ////////////////////////////////////////////////////////////////////////
    // 按钮对象
    // ////////////////////////////////////////////////////////////////////////
    String LABEL_EXIT = "exitLabel";
    String LABEL_FULL = "fullLabel";
    String LABEL_HIDE = "hideLabel";
    String LABEL_MENU = "menuLabel";
    String LABEL_TEXT = "textLabel";
}
