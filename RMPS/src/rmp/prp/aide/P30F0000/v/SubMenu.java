/*
 * FileName:       SubMenu.java
 * CreateDate:     2008-2-28 下午08:12:50
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.P30F0000.v;

import rmp.prp.aide.P30F0000.P30F0000;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br>
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br>
 * TODO: 使用说明
 * </ul>
 * <p>
 * 版本： RMPS V1.0.0.0
 * </p>
 * <p>
 * 作者： Amon
 * </p>
 * <p>
 * 日期： 2008-2-28 下午08:12:50
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class SubMenu
{
    private P30F0000          ms_MainSoft;
    private javax.swing.JMenu mm_MainMenu;

    /**
     * @param soft
     * @param menu
     */
    public SubMenu(P30F0000 soft, javax.swing.JMenu menu)
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

        return true;
    }
}
