/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *    
 */
package com.amonsoft.util;

import java.awt.Desktop;
import java.awt.Desktop.Action;
import java.io.File;
import java.net.URI;

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
public class DeskUtil
{
    /**
     * 网络浏览
     * 
     * @param url
     * @return
     */
    public static boolean browse(String url) throws Exception
    {
        // 桌面支持性判断
        if (!Desktop.isDesktopSupported())
        {
            return false;
        }

        // 指定事件可用性判断
        Desktop desktop = Desktop.getDesktop();
        if (!desktop.isSupported(Action.BROWSE))
        {
            return false;
        }

        // 浏览指定地址
        desktop.browse(new URI(url));
        return true;
    }

    /**
     * 打开指定的程序
     * 
     * @param fileName
     */
    public static boolean open(String fileName) throws Exception
    {
        // 文件存在性检测
        File readme = new File(fileName);
        if (!readme.exists())
        {
            return false;
        }

        // 桌面支持性判断
        if (!Desktop.isDesktopSupported())
        {
            return false;
        }

        // 指定事件可用性判断
        Desktop desktop = Desktop.getDesktop();
        if (!desktop.isSupported(Action.OPEN))
        {
            return false;
        }

        // 打开文件
        desktop.open(readme);
        return true;
    }

    /**
     * 发送电子邮件
     * 
     * @param mailto
     * @return
     */
    public static boolean mail(String mailto) throws Exception
    {
        // 桌面支持性判断
        if (!Desktop.isDesktopSupported())
        {
            return false;
        }

        // 指定事件可用性判断
        Desktop desktop = Desktop.getDesktop();
        if (!desktop.isSupported(Action.MAIL))
        {
            return false;
        }

        // 发送邮件
        if (!mailto.toLowerCase().startsWith("mailto:"))
        {
            mailto = "mailto:" + mailto;
        }
        desktop.mail(new URI(mailto));
        return true;
    }
}
