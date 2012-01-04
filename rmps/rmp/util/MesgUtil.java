/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.util;

import java.awt.Component;

import javax.swing.JOptionPane;

import cons.ui.LangRes;

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
public final class MesgUtil
{
    /**
     * 
     */
    private MesgUtil()
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IRmps#init()
     */
    public boolean wInit()
    {
        return true;
    }

    /**
     * 显示文本输入对话框
     * 
     * @param comp
     *            父窗口对象
     * @param mesg
     *            提示信息
     * @return 用户输入数据
     */
    public static String showInputDialog(Component comp, String mesg)
    {
        mesg = "<html><body>" + mesg + "</body></html>";
        return JOptionPane.showInputDialog(comp, mesg, LangRes.TITLE_MESSAGE, JOptionPane.INFORMATION_MESSAGE);
    }

    /**
     * @param comp
     * @param mesg
     * @param init
     * @return
     */
    public static String showInputDialog(Component comp, String mesg, String init)
    {
        mesg = "<html><body>" + mesg + "</body></html>";
        return JOptionPane.showInputDialog(comp, mesg, init);
    }

    /**
     * 显示提示信息对话框
     * 
     * @param comp
     *            对话框的父窗口
     * @param mesg
     *            待显示的提示信息
     * @param isHash
     *            当前字符串是否为Hash索引：true是，false不是。
     */
    public static void showMessageDialog(Component comp, String mesg)
    {
        mesg = "<html><body>" + mesg + "</body></html>";
        JOptionPane.showMessageDialog(comp, mesg, LangRes.TITLE_MESSAGE, JOptionPane.INFORMATION_MESSAGE);
    }

    /**
     * 显示确认对话框，并返回用户选择的状态，0表示用户选择了确定，1表示用户选择了拒绝
     * 
     * @param comp
     *            对话框的父窗口
     * @param mesg
     *            待显示的提示信息
     * @param isHash
     *            当前字符串是否为Hash索引：true是，false不是。
     * @return
     */
    public static int showConfirmDialog(Component comp, String mesg)
    {
        mesg = "<html><body>" + mesg + "</body></html>";
        return JOptionPane.showConfirmDialog(comp, mesg, LangRes.TITLE_MESSAGE, JOptionPane.YES_NO_OPTION, JOptionPane.INFORMATION_MESSAGE);
    }
}
