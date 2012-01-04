/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *    
 */
package com.amonsoft.cons;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * TODO:
 * <li>使用说明：</li>
 * <br />
 * TODO:
 * </ul>
 * 
 * @author Amon
 */
public interface ConsSys
{
    /** 启动模式：标准插件模式 */
    int MODE_PLUGINS = 0;
    /** 启动模式：独立程序模式 */
    int MODE_APPLICATION = 1;
    /** 启动模式：网络加载模式 */
    int MODE_WEBSTART = 2;
    /** 启动模式：脚本程序模式 */
    int MODE_APPLET = 3;
}
