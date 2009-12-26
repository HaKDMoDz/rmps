/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3040000.v;

import javax.swing.ButtonGroup;

import rmp.prp.aide.P3040000.P3040000;
import rmp.prp.aide.P3040000.t.Util;
import rmp.util.BeanUtil;
import cons.prp.aide.P3040000.ConstUI;
import cons.prp.aide.P3040000.LangRes;

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
    private P3040000 ms_MainSoft;
    private javax.swing.JMenu mm_MainMenu;

    /**
     * @param soft
     * @param menu
     */
    public SubMenu(P3040000 soft, javax.swing.JMenu menu)
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
        ButtonGroup bg = new ButtonGroup();

        mi_DateView = new javax.swing.JCheckBoxMenuItem();
        mi_DateView.setSelected(true);
        bg.add(mi_DateView);
        mm_MainMenu.add(mi_DateView);
        mi_DateView.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent e)
            {
                Util.firePropertyChanged(ConstUI.BACK_K_TAILPANEL, ConstUI.BACK_V_DATEVIEW);
            }
        });

        mi_MnthView = new javax.swing.JCheckBoxMenuItem();
        bg.add(mi_MnthView);
        mm_MainMenu.add(mi_MnthView);
        mi_MnthView.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent e)
            {
                Util.firePropertyChanged(ConstUI.BACK_K_TAILPANEL, ConstUI.BACK_V_MONTHVIEW);
            }
        });

        mm_MainMenu.addSeparator();

        mi_Today = new javax.swing.JMenuItem();
        mm_MainMenu.add(mi_Today);
        mi_Today.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent e)
            {
                Util.setDate();
                Util.firePropertyChanged(ConstUI.BACK_K_TAILPANEL, ConstUI.BACK_V_UPDATE);
            }
        });

        mi_PrevYear = new javax.swing.JMenuItem();
        mm_MainMenu.add(mi_PrevYear);
        mi_PrevYear.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent e)
            {
                Util.addYear(-1);
                Util.firePropertyChanged(ConstUI.BACK_K_TAILPANEL, ConstUI.BACK_V_UPDATE);
            }
        });

        mi_PrevMonth = new javax.swing.JMenuItem();
        mm_MainMenu.add(mi_PrevMonth);
        mi_PrevMonth.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent e)
            {
                Util.addMonth(-1);
                Util.firePropertyChanged(ConstUI.BACK_K_TAILPANEL, ConstUI.BACK_V_UPDATE);
            }
        });

        mi_NextMonth = new javax.swing.JMenuItem();
        mm_MainMenu.add(mi_NextMonth);
        mi_NextMonth.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent e)
            {
                Util.addMonth(1);
                Util.firePropertyChanged(ConstUI.BACK_K_TAILPANEL, ConstUI.BACK_V_UPDATE);
            }
        });

        mi_NextYear = new javax.swing.JMenuItem();
        mm_MainMenu.add(mi_NextYear);
        mi_NextYear.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent e)
            {
                Util.addYear(1);
                Util.firePropertyChanged(ConstUI.BACK_K_TAILPANEL, ConstUI.BACK_V_UPDATE);
            }
        });
    }

    /**
     * 
     */
    private void ita()
    {
        BeanUtil.setWText(mi_DateView, P3040000.getMesg(LangRes.P3044601));
        BeanUtil.setWTips(mi_DateView, P3040000.getMesg(LangRes.P3044602));

        BeanUtil.setWText(mi_MnthView, P3040000.getMesg(LangRes.P3044603));
        BeanUtil.setWTips(mi_MnthView, P3040000.getMesg(LangRes.P3044604));

        BeanUtil.setWText(mi_Today, P3040000.getMesg(LangRes.P3044605));
        BeanUtil.setWTips(mi_Today, P3040000.getMesg(LangRes.P3044606));

        BeanUtil.setWText(mi_PrevYear, P3040000.getMesg(LangRes.P3044607));
        BeanUtil.setWTips(mi_PrevYear, P3040000.getMesg(LangRes.P3044608));

        BeanUtil.setWText(mi_PrevMonth, P3040000.getMesg(LangRes.P3044609));
        BeanUtil.setWTips(mi_PrevMonth, P3040000.getMesg(LangRes.P304460A));

        BeanUtil.setWText(mi_NextMonth, P3040000.getMesg(LangRes.P304460B));
        BeanUtil.setWTips(mi_NextMonth, P3040000.getMesg(LangRes.P304460C));

        BeanUtil.setWText(mi_NextYear, P3040000.getMesg(LangRes.P304460D));
        BeanUtil.setWTips(mi_NextYear, P3040000.getMesg(LangRes.P304460E));
    }
    private javax.swing.JMenuItem mi_NextMonth;
    private javax.swing.JMenuItem mi_NextYear;
    private javax.swing.JMenuItem mi_PrevMonth;
    private javax.swing.JMenuItem mi_PrevYear;
    private javax.swing.JMenuItem mi_Today;
    private javax.swing.JCheckBoxMenuItem mi_DateView;
    private javax.swing.JCheckBoxMenuItem mi_MnthView;
}
