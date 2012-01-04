/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P30C0000.v;

import rmp.prp.aide.P30C0000.P30C0000;
import rmp.prp.aide.P30C0000.t.Util;

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
    private P30C0000          ms_MainSoft;
    private javax.swing.JMenu mm_MainMenu;

    /**
     * @param soft
     * @param menu
     */
    public SubMenu(P30C0000 soft, javax.swing.JMenu menu)
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
        mi_INetAddr = new javax.swing.JMenuItem();
        mi_INetAddr.setText("我的地址");
        mi_INetAddr.addActionListener(new java.awt.event.ActionListener()
        {
            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_INetAddr_Handler(evt);
            }
        });
        mm_MainMenu.add(mi_INetAddr);
    }

    /**
     * 
     */
    private void ita()
    {
    }

    /**
     * @param evt
     */
    private void mi_INetAddr_Handler(java.awt.event.ActionEvent evt)
    {
        Util.firePropertyChanged("tailPanel");
    }

    private javax.swing.JMenuItem mi_INetAddr;
}
