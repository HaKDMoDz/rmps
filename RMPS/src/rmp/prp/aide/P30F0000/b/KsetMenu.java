/*
 * FileName:       KsetMenu.java
 * CreateDate:     2008-5-13 上午09:55:24
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amon.CT@hotmail.com / http://www.winshine.net.cn/ ).
 * Description:    
 */

package rmp.prp.aide.P30F0000.b;

import java.awt.Component;
import java.awt.event.ActionEvent;

import com.amonsoft.rmps.IRmps;
import rmp.prp.aide.P30F0000.P30F0000;
import rmp.prp.aide.P30F0000.t.Util;
import rmp.util.BeanUtil;
import rmp.util.CheckUtil;
import rmp.util.LogUtil;
import rmp.util.MesgUtil;
import cons.prp.aide.P30F0000.ConstUI;
import cons.prp.aide.P30F0000.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * 用户快捷设置生成随机口令的参数信息组件 <br>
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br>
 * TODO: 使用说明
 * </ul>
 * <p>
 * 版本： RMPS V1.0.0.0
 * </p>
 * <p>
 * 作者： shangwen.yao
 * </p>
 * <p>
 * 日期： 2008-5-13 上午09:55:24
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class KsetMenu
{
    private boolean noRepeat = false;
    private int     keySize  = 8;
    private String  keySets  = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

    /**
     * 
     */
    public KsetMenu()
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IRmps#wInit()
     */
    public boolean wInit()
    {
        return true;
    }

    /**
     * @return the keySize
     */
    public int getKeySize()
    {
        return keySize;
    }

    /**
     * @return the keySets
     */
    public String getKeySets()
    {
        return keySets;
    }

    /**
     * @return the noRepeat
     */
    public boolean isNoRepeat()
    {
        return noRepeat;
    }

    public void showPopupMenu(Component invoker, int x, int y)
    {
        if (pm_PopsMenu == null)
        {
            pm_PopsMenu = new javax.swing.JPopupMenu();

            ica();
            ita();
        }

        pm_PopsMenu.show(invoker, x, y);
    }

    private void ica()
    {
        // ------------------------------------------------
        // 口令长度
        // ------------------------------------------------
        mu_SizeMenu = new javax.swing.JMenu();
        pm_PopsMenu.add(mu_SizeMenu);

        javax.swing.JCheckBoxMenuItem mi;
        javax.swing.ButtonGroup bg;
        java.awt.event.ActionListener al;

        al = new java.awt.event.ActionListener()
        {
            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_SizeMenuActionPerformed(evt);
            }
        };

        String t = P30F0000.getMesg(LangRes.P30F662C);
        String[] text;
        String[] keys = {"6", "8", "12", "16", "24", "32"};
        bg = new javax.swing.ButtonGroup();

        // 默认
        mi_SizeDeft = new javax.swing.JCheckBoxMenuItem();
        mi_SizeDeft.putClientProperty("prop_size", "8");
        mi_SizeDeft.addActionListener(al);
        mi_SizeDeft.setSelected(true);
        mu_SizeMenu.add(mi_SizeDeft);
        bg.add(mi_SizeDeft);

        mu_SizeMenu.addSeparator();

        for (int i = 0, j = keys.length; i < j; i += 1)
        {
            mi = new javax.swing.JCheckBoxMenuItem();
            mi.setText(keys[i] + t);
            mi.putClientProperty("prop_size", keys[i]);
            mi.addActionListener(al);
            mu_SizeMenu.add(mi);
            bg.add(mi);
        }

        mu_SizeMenu.addSeparator();

        // 其它...
        mi_SizeMore = new javax.swing.JCheckBoxMenuItem();
        mi_SizeMore.addActionListener(new java.awt.event.ActionListener()
        {
            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_SizeMoreActionPerformed(evt);
            }
        });
        bg.add(mi_SizeMore);
        mu_SizeMenu.add(mi_SizeMore);

        // ------------------------------------------------
        // 口令空间
        // ------------------------------------------------
        mu_SetsMenu = new javax.swing.JMenu();
        pm_PopsMenu.add(mu_SetsMenu);

        al = new java.awt.event.ActionListener()
        {
            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_SetsMenuActionPerformed(evt);
            }
        };
        text = new String[]{P30F0000.getMesg(LangRes.P30F6624), P30F0000.getMesg(LangRes.P30F6625),
            P30F0000.getMesg(LangRes.P30F6626), P30F0000.getMesg(LangRes.P30F6627), P30F0000.getMesg(LangRes.P30F6628),
            P30F0000.getMesg(LangRes.P30F6629), P30F0000.getMesg(LangRes.P30F662A)};
        keys = new String[]{ConstUI.SETS_NUMBER, ConstUI.SETS_LOWER, ConstUI.SETS_UPPER, ConstUI.SETS_SPECIAL,
            ConstUI.SETS_LETTER, ConstUI.SETS_NUMBER_LETTER, ConstUI.SETS_ASCII_CHARACTER};
        bg = new javax.swing.ButtonGroup();

        mi_SetsDeft = new javax.swing.JCheckBoxMenuItem();
        mi_SetsDeft.putClientProperty("prop_hash", ConstUI.SETS_LETTER);
        mi_SetsDeft.addActionListener(al);
        mi_SetsDeft.setSelected(true);
        mu_SetsMenu.add(mi_SetsDeft);
        bg.add(mi_SetsDeft);

        mu_SetsMenu.addSeparator();

        for (int i = 0, j = text.length; i < j; i += 1)
        {
            mi = new javax.swing.JCheckBoxMenuItem();
            mi.setText(text[i]);
            mi.putClientProperty("prop_hash", keys[i]);
            mi.addActionListener(al);
            mu_SetsMenu.add(mi);
            bg.add(mi);
        }

        // mu_SetsMenu.addSeparator();

        // 设置...
        mi_SetsMore = new javax.swing.JCheckBoxMenuItem();
        mi_SetsMore.addActionListener(new java.awt.event.ActionListener()
        {
            @ Override
            public void actionPerformed(ActionEvent e)
            {
            }
        });
        bg.add(mi_SetsMore);
        mi_SetsMore.setVisible(false);
        mu_SetsMenu.add(mi_SetsMore);

        // ------------------------------------------------
        // 是否重复
        // ------------------------------------------------
        mi_NoptMenu = new javax.swing.JCheckBoxMenuItem();
        mi_NoptMenu.addActionListener(new java.awt.event.ActionListener()
        {
            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_NoptMenuActionPerformed(evt);
            }
        });
        pm_PopsMenu.add(mi_NoptMenu);
    }

    /**
     * 
     */
    private void ita()
    {
        // 口令长度
        BeanUtil.setWText(mu_SizeMenu, P30F0000.getMesg(LangRes.P30F661A));
        BeanUtil.setWTips(mu_SizeMenu, P30F0000.getMesg(LangRes.P30F661B));

        BeanUtil.setWText(mi_SizeDeft, P30F0000.getMesg(LangRes.P30F6620));
        BeanUtil.setWTips(mi_SizeDeft, P30F0000.getMesg(LangRes.P30F6621));

        BeanUtil.setWText(mi_SizeMore, P30F0000.getMesg(LangRes.P30F6622));
        BeanUtil.setWTips(mi_SizeMore, P30F0000.getMesg(LangRes.P30F6623));

        // 口令空间
        BeanUtil.setWText(mu_SetsMenu, P30F0000.getMesg(LangRes.P30F661C));
        BeanUtil.setWTips(mu_SetsMenu, P30F0000.getMesg(LangRes.P30F661D));

        BeanUtil.setWText(mi_SetsDeft, P30F0000.getMesg(LangRes.P30F6620));
        BeanUtil.setWTips(mi_SetsDeft, P30F0000.getMesg(LangRes.P30F6621));

        // 不可重复
        BeanUtil.setWText(mi_NoptMenu, P30F0000.getMesg(LangRes.P30F661E));
        BeanUtil.setWTips(mi_NoptMenu, P30F0000.getMesg(LangRes.P30F661F));
    }

    /**
     * @param evt
     */
    private void mi_SizeMenuActionPerformed(java.awt.event.ActionEvent evt)
    {
        Object obj = evt.getSource();
        if (obj == null)
        {
            return;
        }
        if (!(obj instanceof javax.swing.JCheckBoxMenuItem))
        {
            return;
        }

        javax.swing.JCheckBoxMenuItem mi = (javax.swing.JCheckBoxMenuItem)obj;
        String t = (String)mi.getClientProperty("prop_size");
        if (!CheckUtil.isValidate(t))
        {
            return;
        }
        try
        {
            keySize = Integer.parseInt(t);
        }
        catch(NumberFormatException exp)
        {
            LogUtil.exception(exp);
            keySize = 8;
            mi_SizeDeft.setSelected(true);
        }
    }

    private void mi_SizeMoreActionPerformed(java.awt.event.ActionEvent evt)
    {
        String s = MesgUtil.showInputDialog(P30F0000.getForm(), LangRes.P30F6A1D, "" + keySize);
        if (s == null)
        {
            return;
        }
        s = s.trim();
        if (s.length() < 1)
        {
            MesgUtil.showMessageDialog(P30F0000.getForm(), LangRes.P30F6A1F);
            return;
        }

        try
        {
            keySize = Integer.parseInt(s);
        }
        catch(NumberFormatException exp)
        {
            LogUtil.exception(exp);
            MesgUtil.showMessageDialog(P30F0000.getForm(), LangRes.P30F6A1E);
            keySize = 8;
            mi_SizeDeft.setSelected(true);
        }
    }

    /**
     * @param evt
     */
    private void mi_SetsMenuActionPerformed(java.awt.event.ActionEvent evt)
    {
        Object obj = evt.getSource();
        if (obj == null)
        {
            return;
        }
        if (!(obj instanceof javax.swing.JCheckBoxMenuItem))
        {
            return;
        }

        javax.swing.JCheckBoxMenuItem mi = (javax.swing.JCheckBoxMenuItem)obj;
        String t = (String)mi.getClientProperty("prop_hash");
        if (!CheckUtil.isValidate(t))
        {
            return;
        }

        keySets = Util.readSetsByID(t);
    }

    /**
     * @param evt
     */
    private void mi_NoptMenuActionPerformed(java.awt.event.ActionEvent evt)
    {
        noRepeat = mi_NoptMenu.isSelected();
    }

    private javax.swing.JPopupMenu        pm_PopsMenu;
    private javax.swing.JMenu             mu_SizeMenu;
    private javax.swing.JCheckBoxMenuItem mi_SizeDeft;
    private javax.swing.JCheckBoxMenuItem mi_SizeMore;
    private javax.swing.JMenu             mu_SetsMenu;
    private javax.swing.JCheckBoxMenuItem mi_SetsDeft;
    private javax.swing.JCheckBoxMenuItem mi_SetsMore;
    private javax.swing.JCheckBoxMenuItem mi_NoptMenu;
}
