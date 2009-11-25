/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3080000.v;

import javax.swing.ButtonGroup;

import rmp.prp.aide.P3080000.P3080000;
import rmp.prp.aide.P3080000.t.Util;
import rmp.util.LogUtil;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 快捷菜单
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class SubMenu
{
    /** 主应用程序 */
    private P3080000 ms_MainSoft;
    /** 主级联菜单 */
    private javax.swing.JMenu mm_MainMenu;

    /**
     * @param soft
     * @param menu
     */
    public SubMenu(P3080000 soft, javax.swing.JMenu menu)
    {
        this.ms_MainSoft = soft;
        this.mm_MainMenu = menu;
    }

    /**
     * @return
     */
    public boolean wInit()
    {
        mm_MainMenu.setText(ms_MainSoft.wGetTitle());

        ica();

        ita();

        return true;
    }

    /**
     * 
     */
    private void ica()
    {
        javax.swing.JCheckBoxMenuItem item;
        javax.swing.ButtonGroup bg = new ButtonGroup();

        // 默认时区
        item = new javax.swing.JCheckBoxMenuItem();
        item.setText("默认时区");
        item.setSelected(true);
        item.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_Default_Handler(evt);
            }
        });
        bg.add(item);
        mm_MainMenu.add(item);

        mm_MainMenu.addSeparator();

        // 指定时区
        java.awt.event.ActionListener al = new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_TimeZone_Handler(evt);
            }
        };
        for (int i = 1; i < 26; i += 1)
        {
            item = new javax.swing.JCheckBoxMenuItem();
            item.setText("GMT " + (i - 13));
            item.addActionListener(al);
            item.putClientProperty("gmt", Integer.toString(i));
            bg.add(item);
            mm_MainMenu.add(item);
        }
    }

    /**
     * 
     */
    private void ita()
    {
    }

    /**
     * 默认时区事件处理
     * 
     * @param evt
     */
    private void mi_Default_Handler(java.awt.event.ActionEvent evt)
    {
        Util.firePropertyChanged("tailPanel", "default");
    }

    /**
     * 指定时区事件处理
     * 
     * @param evt
     */
    private void mi_TimeZone_Handler(java.awt.event.ActionEvent evt)
    {
        javax.swing.JCheckBoxMenuItem m = (javax.swing.JCheckBoxMenuItem) evt.getSource();
        String k = (String) m.getClientProperty("gmt");
        if (k == null)
        {
            return;
        }

        try
        {
            int i = Integer.parseInt(k) - 13;
            Util.setZoneOffset(i);
            Util.firePropertyChanged("tailPanel", "");
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
    }
}
