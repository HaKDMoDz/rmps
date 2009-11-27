/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.amon.rmps.AF010000.v;

import javax.swing.WindowConstants;
import rmp.amon.rmps.AF010000.AF010000;

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
    private AF010000 ms_MainSoft;
    private javax.swing.JMenu mm_MainMenu;

    /**
     * @param soft
     * @param menu
     */
    public SubMenu(AF010000 soft, javax.swing.JMenu menu)
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
     * 菜单界面布局初始化
     */
    private void ica()
    {
        mi_Config = new javax.swing.JMenuItem();
        mi_Config.setText("配置机器人");
        mi_Config.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_Config_Handler(evt);
            }
        });
        mm_MainMenu.add(mi_Config);
    }

    /**
     * 机器人配置界面布局初始化
     */
    private void icb()
    {
        javax.swing.JPanel viewPanel = new javax.swing.JPanel();
    }

    /**
     * 菜单界面语言初始化
     */
    private void ita()
    {
    }

    /**
     * 机器人配置界面语言初始化
     */
    private void itb()
    {
    }

    /**
     * 机器人配置菜单事件处理
     * 
     * @param evt
     */
    private void mi_Config_Handler(java.awt.event.ActionEvent evt)
    {
        icb();
        itb();
    }
    private javax.swing.JMenuItem mi_Config;
}
