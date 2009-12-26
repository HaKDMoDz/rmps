/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.util;

import java.io.IOException;
import java.io.InputStream;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.Properties;

import javax.swing.JMenu;
import javax.swing.JMenuBar;
import javax.swing.JPopupMenu;

import org.dom4j.Document;
import org.dom4j.DocumentException;
import org.dom4j.Element;
import org.dom4j.Node;
import org.dom4j.io.SAXReader;

import cons.SysCons;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * RMPS系统共用方法
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public final class RmpsUtil
{
    /**
     * 
     */
    private RmpsUtil()
    {
    }

    /**
     * 检测指定软件的版本更新信息
     * 
     * @param sid
     *            软件标记ID
     * @param ver
     *            当前软件版本信息
     * @return
     * @throws IOException
     * @throws MalformedURLException
     */
    public static boolean checkUpdate(String sid, String ver) throws MalformedURLException, IOException
    {
        if (sid == null)
        {
            throw new IOException("未知软件标记信息！");
        }
        if (ver == null)
        {
            throw new IOException("未知软件版本信息！");
        }

        ver = ver.toUpperCase();
        if (ver.charAt(0) != 'V')
        {
            ver = 'V' + ver;
        }

        Properties updtProp = new Properties();

        // 属性读取
        java.io.InputStream is = new URL(SysCons.UPDTFILE).openStream();
        updtProp.loadFromXML(is);
        is.close();

        // 版本比较
        String nVer = updtProp.getProperty(sid, "");

        return sid.compareToIgnoreCase(nVer) < 0;
    }

    /**
     * @param p
     * @throws DocumentException
     */
    public static void loadMenu(JPopupMenu p, InputStream is) throws DocumentException
    {
        SAXReader saxReader = new SAXReader();
        Document doc = saxReader.read(is);
        Element ele = doc.getRootElement();
        Node node;
        for (int i = 0, j = ele.nodeCount(); i < j; i += 1)
        {
            node = ele.node(i);
        }
    }

    /**
     * @param m
     */
    public static void loadMenu(JMenu m)
    {
    }

    /**
     * @param b
     */
    public static void loadMenu(JMenuBar b)
    {
    }

    private static void loadMenu(JMenu menu, Element node)
    {
    }
}
