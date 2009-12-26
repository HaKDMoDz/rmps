/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P30B0000.v;

import java.awt.event.ActionEvent;

import rmp.prp.aide.P30B0000.P30B0000;
import rmp.prp.aide.P30B0000.t.Util;

import com.amonsoft.rmps.prp.v.IMenu;

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
public class SubMenu implements IMenu
{
    private P30B0000 ms_MainSoft;
    private javax.swing.JMenu mu_MainMenu;

    /**
     * @param soft
     * @param menu
     */
    public SubMenu(P30B0000 soft, javax.swing.JMenu menu)
    {
        ms_MainSoft = soft;
        mu_MainMenu = menu;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#wInit()
     */
    @Override
    public boolean wInit()
    {
        mu_MainMenu.setText(ms_MainSoft.wGetTitle());

        ica();
        ita();

        return true;
    }

    /**
     * 
     */
    private void ica()
    {
        mi_M1 = new javax.swing.JMenuItem();
        mi_M1.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent e)
            {
                Util.firePropertyChanged("", "");
            }
        });
        mu_MainMenu.add(mi_M1);

        mi_M2 = new javax.swing.JMenuItem();
        mi_M2.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent e)
            {
                Util.firePropertyChanged("", "");
            }
        });
        mu_MainMenu.add(mi_M2);

        mi_M3 = new javax.swing.JMenuItem();
        mi_M3.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent e)
            {
                Util.firePropertyChanged("", "");
            }
        });
        mu_MainMenu.add(mi_M3);

        mi_M4 = new javax.swing.JMenuItem();
        mi_M4.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent e)
            {
                Util.firePropertyChanged("", "");
            }
        });
        mu_MainMenu.add(mi_M4);

        mi_M5 = new javax.swing.JMenuItem();
        mi_M5.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent e)
            {
                Util.firePropertyChanged("", "");
            }
        });
        mu_MainMenu.add(mi_M5);
    }

    /**
     * 
     */
    private void ita()
    {
        mi_M1.setText("车次查询");
        mi_M2.setText("站站查询");
        mi_M3.setText("时刻查询");
        mi_M4.setText("站点信息");
        mi_M5.setText("数据版本");
    }

    private javax.swing.JMenuItem mi_M1;
    private javax.swing.JMenuItem mi_M2;
    private javax.swing.JMenuItem mi_M3;
    private javax.swing.JMenuItem mi_M4;
    private javax.swing.JMenuItem mi_M5;
}
