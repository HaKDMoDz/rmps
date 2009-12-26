/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.ui.pop;

import java.awt.Dimension;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import rmp.util.BeanUtil;

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
public class WPopupMenu
{
    /** 窗口快捷菜单 */
    private javax.swing.JPopupMenu pm_PopMenu;
    /**  */
    private static WPopupMenu pm_QckMenu;

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    public boolean wInit()
    {
        pm_PopMenu = new javax.swing.JPopupMenu();

        initSkinList();

        initViewForm();

        return false;
    }

    /**
     * @return
     */
    public static javax.swing.JPopupMenu getInstance()
    {
        if (pm_QckMenu == null)
        {
            pm_QckMenu = new WPopupMenu();
            pm_QckMenu.wInit();
        }
        return pm_QckMenu.getPopMenu();
    }

    /**
     * @return
     */
    public javax.swing.JPopupMenu getPopMenu()
    {
        return pm_PopMenu;
    }

    /**
     * 
     */
    private void initSkinList()
    {
        mu_SkinList = createMenu("界面主题", "界面主题", false);
        pm_PopMenu.add(mu_SkinList);

        javax.swing.ButtonGroup bg = new javax.swing.ButtonGroup();

        javax.swing.JCheckBoxMenuItem skinItem = createCheckBoxMenuItem("默认风格", "默认风格", false);
        skinItem.setSelected(true);
        bg.add(skinItem);
        mu_SkinList.add(skinItem);
    }

    /**
     * 
     */
    private void initViewForm()
    {
        mu_ViewForm = createMenu("视图模式", "视图模式", false);
        pm_PopMenu.add(mu_ViewForm);

        javax.swing.ButtonGroup bg = new javax.swing.ButtonGroup();

        javax.swing.JCheckBoxMenuItem miniView = createCheckBoxMenuItem("迷你模式", "迷你模式", false);
        miniView.addActionListener(new ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent e)
            {
                // BeanUtil.getCurrSoft().showModel(0);
            }
        });
        miniView.setSelected(true);
        bg.add(miniView);
        mu_ViewForm.add(miniView);

        javax.swing.JCheckBoxMenuItem mainView = createCheckBoxMenuItem("高级模式", "高级模式", false);
        mainView.addActionListener(new ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent e)
            {
                // BeanUtil.getCurrSoft().showModel(1);
            }
        });
        bg.add(mainView);
        mu_ViewForm.add(mainView);
    }

    /**
     * @param menuText
     * @param menuTips
     * @return
     */
    private javax.swing.JCheckBoxMenuItem createCheckBoxMenuItem(String menuText, String menuTips, boolean isHash)
    {
        javax.swing.JCheckBoxMenuItem item = new javax.swing.JCheckBoxMenuItem();
        BeanUtil.setWText(item, menuText);
        BeanUtil.setWTips(item, menuTips);

        Dimension size = item.getPreferredSize();
        size.width = 120;
        item.setPreferredSize(size);

        return item;
    }

    /**
     * @param menuText
     * @param menuTips
     * @return
     */
    private javax.swing.JMenu createMenu(String menuText, String menuTips, boolean isHash)
    {
        javax.swing.JMenu menu = new javax.swing.JMenu();
        BeanUtil.setWText(menu, menuText);
        BeanUtil.setWTips(menu, menuTips);
        return menu;
    }

    /** 皮肤列表 */
    private javax.swing.JMenu mu_SkinList;
    /** 视图模式 */
    private javax.swing.JMenu mu_ViewForm;
}
