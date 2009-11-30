/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.v;

import rmp.prp.Prps;
import rmp.util.RmpsUtil;
import cons.CfgCons;

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
public class SubMenu
{
    // ////////////////////////////////////////////////////////////////////////
    // 控制变量区域
    // ////////////////////////////////////////////////////////////////////////
    /** PRPS主窗口 */
    private Prps prps;
    /** 子级联菜单 */
    private javax.swing.JMenu mm_MainMenu;
    /** 弹出式菜单 */
    private javax.swing.JPopupMenu pm_MainMenu;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @param menu 级联菜单对象
     */
    public SubMenu(Prps prps, javax.swing.JMenu menu)
    {
        this.prps = prps;
        this.mm_MainMenu = menu;
    }

    /**
     * @param menu 级联菜单对象
     */
    public SubMenu(Prps prps, javax.swing.JPopupMenu menu)
    {
        this.prps = prps;
        this.pm_MainMenu = menu;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面布局区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @return
     */
    public boolean wInit()
    {
        if (mm_MainMenu != null)
        {
            ica();
            ita();
        }
        if (pm_MainMenu != null)
        {
            icb();
            itb();
        }
        return true;
    }

    // ----------------------------------------------------
    // 界面布局初始化
    // ----------------------------------------------------
    /**
     * 子级联菜单布局初始化
     */
    private void ica()
    {
        // 总在最上
        mi_EverTop = new javax.swing.JCheckBoxMenuItem();
        mi_EverTop.setText("总在最上");
        mi_EverTop.setSelected("true".equalsIgnoreCase(RmpsUtil.getUserInfo().getCfg(CfgCons.CFG_WND_EVERTOP)));
        mi_EverTop.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_EverTop_Handler(evt);
            }
        });
        mm_MainMenu.add(mi_EverTop);
    }

    /**
     * 弹出式菜单布局初始化
     */
    private void icb()
    {
        // 总在最上
        mi_EverTop = new javax.swing.JCheckBoxMenuItem();
        mi_EverTop.setText("总在最上");
        mi_EverTop.setSelected("true".equalsIgnoreCase(RmpsUtil.getUserInfo().getCfg(CfgCons.CFG_WND_EVERTOP)));
        mi_EverTop.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_EverTop_Handler(evt);
            }
        });
        pm_MainMenu.add(mi_EverTop);

        // 禁止移动
        mi_LockPos = new javax.swing.JCheckBoxMenuItem();
        mi_LockPos.setText("禁止移动");
        mm_MainMenu.add(mi_LockPos);
    }

    // ----------------------------------------------------
    // 界面语言初始化
    // ----------------------------------------------------
    /**
     * 子级联菜单语言初始化
     */
    private void ita()
    {
    }

    /**
     * 弹出式菜单语言初始化
     */
    private void itb()
    {
    }

    // ////////////////////////////////////////////////////////////////////////
    // 事件处理区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 总在最上事件处理
     * 
     * @param evt
     */
    private void mi_EverTop_Handler(java.awt.event.ActionEvent evt)
    {
        boolean b = mi_EverTop.isSelected();
        prps.setAlwaysOnTop(b);
        RmpsUtil.getUserInfo().setCfg(CfgCons.CFG_WND_EVERTOP, Boolean.toString(b));
    }
    /** 总在最上 */
    private javax.swing.JCheckBoxMenuItem mi_EverTop;
    /** 禁止移动 */
    private javax.swing.JCheckBoxMenuItem mi_LockPos;
}
