/*
 * FileName:       PwdsBean.java
 * CreateDate:     2008-2-28 下午08:26:28
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.P30F0000.b;

import java.awt.Cursor;

import javax.swing.ImageIcon;

import rmp.prp.aide.P30F0000.P30F0000;
import rmp.prp.aide.P30F0000.i.WProp;
import rmp.prp.aide.P30F0000.m.UserData;
import rmp.prp.aide.P30F0000.t.Util;
import rmp.prp.aide.P30F0000.v.NormPanel;
import rmp.util.BeanUtil;
import rmp.util.CheckUtil;
import rmp.util.EnvUtil;
import rmp.util.HashUtil;
import rmp.util.LogUtil;
import rmp.util.MesgUtil;
import cons.prp.aide.P30F0000.ConstUI;
import cons.prp.aide.P30F0000.LangRes;

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
 * 日期： 2008-2-28 下午08:26:28
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class PwdsBean extends javax.swing.JPanel implements WProp
{
    private NormPanel np_NormPanel;
    private UserData  ud_UserData;
    private PropItem  pi_PropItem;
    private ImageIcon ii_ViewPwds;
    private ImageIcon ii_HidePwds;
    private boolean   askOverRide;
    private KsetMenu  km_KsetMenu;

    /**
     * 
     */
    public PwdsBean(NormPanel panel, UserData uData)
    {
        this.np_NormPanel = panel;
        this.ud_UserData = uData;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#wInit()
     */
    public boolean wInit()
    {
        ica();
        ita();

        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.prp.aide.P30F0000.i.WProp#setPropItem(rmp.prp.aide.P30F0000.b.PropItem)
     */
    public void setPropItem(PropItem pi)
    {
        askOverRide = true;

        this.pi_PropItem = pi;
        String name = pi.getName();
        if (!CheckUtil.isValidate(pi.getData()) && (name.startsWith(ConstUI.SP_LS) && name.endsWith(ConstUI.SP_RS)))
        {
            name = name.substring(1, name.length() - 1);
        }
        tf_PwdsName.setText(name);
        pf_PwdsData.setText(pi.getData());
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.JComponent#requestFocus()
     */
    public void requestFocus()
    {
        pf_PwdsData.requestFocus();
    }

    /**
     * 
     */
    private void ica()
    {
        lb_PwdsName = new javax.swing.JLabel();
        tf_PwdsName = new javax.swing.JTextField();
        lb_PwdsData = new javax.swing.JLabel();
        pf_PwdsData = new javax.swing.JPasswordField();
        bt_GentPwds = new javax.swing.JButton();
        bt_PwdsKset = new javax.swing.JButton();
        bt_ViewPwds = new javax.swing.JButton();
        bt_DeltData = new javax.swing.JButton();
        bt_UpdtData = new javax.swing.JButton();
        bt_CopyData = new javax.swing.JButton();

        lb_PwdsName.setLabelFor(tf_PwdsName);

        tf_PwdsName.setColumns(20);

        pf_PwdsData.setEchoChar('*');
        lb_PwdsData.setLabelFor(pf_PwdsData);

        java.awt.Insets insets = new java.awt.Insets(1, 1, 1, 1);

        bt_PwdsKset.setBorderPainted(false);
        bt_PwdsKset.setContentAreaFilled(false);
        bt_PwdsKset.setMargin(insets);
        bt_PwdsKset.setCursor(Cursor.getPredefinedCursor(Cursor.HAND_CURSOR));
        bt_PwdsKset.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_PwdsKsetActionPerformed(evt);
            }
        });

        bt_GentPwds.setBorderPainted(false);
        bt_GentPwds.setContentAreaFilled(false);
        bt_GentPwds.setMargin(insets);
        bt_GentPwds.setCursor(Cursor.getPredefinedCursor(Cursor.HAND_CURSOR));
        bt_GentPwds.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_GentPwdsActionPerformed(evt);
            }
        });

        bt_ViewPwds.setBorderPainted(false);
        bt_ViewPwds.setContentAreaFilled(false);
        bt_ViewPwds.setMargin(insets);
        bt_ViewPwds.setCursor(Cursor.getPredefinedCursor(Cursor.HAND_CURSOR));
        bt_ViewPwds.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ViewPwdsActionPerformed(evt);
            }
        });

        bt_DeltData.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_DeltDataActionPerformed(evt);
            }
        });

        bt_UpdtData.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_UpdtDataActionPerformed(evt);
            }
        });

        bt_CopyData.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_CopyDataActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                    layout.createSequentialGroup().addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_PwdsData)
                            .addComponent(lb_PwdsName)).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(tf_PwdsName,
                            javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                            javax.swing.GroupLayout.PREFERRED_SIZE).addGroup(
                            layout.createSequentialGroup().addComponent(pf_PwdsData,
                                javax.swing.GroupLayout.DEFAULT_SIZE, 120, Short.MAX_VALUE).addPreferredGap(
                                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_ViewPwds)
                                .addComponent(bt_GentPwds).addComponent(bt_PwdsKset)))).addGroup(
                    javax.swing.GroupLayout.Alignment.TRAILING,
                    layout.createSequentialGroup().addComponent(bt_CopyData).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_UpdtData).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_DeltData)))));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_PwdsName)
                    .addComponent(tf_PwdsName, javax.swing.GroupLayout.PREFERRED_SIZE,
                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_PwdsData)
                    .addComponent(bt_PwdsKset).addComponent(bt_GentPwds).addComponent(bt_ViewPwds).addComponent(
                        pf_PwdsData, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                        javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE,
                Short.MAX_VALUE).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(bt_DeltData)
                    .addComponent(bt_UpdtData).addComponent(bt_CopyData)).addContainerGap()));
    }

    /**
     * 
     */
    private void ita()
    {
        // 属性名称
        BeanUtil.setWText(lb_PwdsName, P30F0000.getMesg(LangRes.P30F6303));
        BeanUtil.setWTips(lb_PwdsName, P30F0000.getMesg(LangRes.P30F6304));

        // 属性内容
        BeanUtil.setWText(lb_PwdsData, P30F0000.getMesg(LangRes.P30F6305));
        BeanUtil.setWTips(lb_PwdsData, P30F0000.getMesg(LangRes.P30F6306));

        // 生成口令
        ImageIcon ii;
        ii = Util.getIcon(ConstUI.ICON_P30F0024);
        if (ii != null)
        {
            bt_PwdsKset.setIcon(ii);
            bt_PwdsKset.setMnemonic(ConstUI.CHAR_P30F0024);
        }
        else
        {
            BeanUtil.setWText(bt_PwdsKset, P30F0000.getMesg(LangRes.P30F6517));
        }
        BeanUtil.setWTips(bt_PwdsKset, P30F0000.getMesg(LangRes.P30F6518));

        ii = Util.getIcon(ConstUI.ICON_P30F0023);
        if (ii != null)
        {
            bt_GentPwds.setIcon(ii);
            bt_GentPwds.setMnemonic(ConstUI.CHAR_P30F0023);
        }
        else
        {
            BeanUtil.setWText(bt_GentPwds, P30F0000.getMesg(LangRes.P30F650F));
        }
        BeanUtil.setWTips(bt_GentPwds, P30F0000.getMesg(LangRes.P30F6510));

        // 显示口令
        ii = Util.getIcon(ConstUI.ICON_P30F0021);
        if (ii != null)
        {
            ii_HidePwds = ii;
            ii_ViewPwds = Util.getIcon(ConstUI.ICON_P30F0022);
            bt_ViewPwds.setIcon(ii_HidePwds);
            bt_ViewPwds.setMnemonic(ConstUI.CHAR_P30F0021);
        }
        else
        {
            BeanUtil.setWText(bt_ViewPwds, "&H");
        }
        BeanUtil.setWTips(bt_ViewPwds, P30F0000.getMesg(LangRes.P30F6513));

        // 删除
        ii = Util.getIcon(ConstUI.ICON_P30F0014);
        if (ii != null)
        {
            bt_DeltData.setIcon(ii);
            bt_DeltData.setMnemonic(ConstUI.CHAR_P30F0014);
        }
        else
        {
            BeanUtil.setWText(bt_DeltData, P30F0000.getMesg(LangRes.P30F650D));
        }
        BeanUtil.setWTips(bt_DeltData, P30F0000.getMesg(LangRes.P30F650E));

        // 更新
        ii = Util.getIcon(ConstUI.ICON_P30F0013);
        if (ii != null)
        {
            bt_UpdtData.setIcon(ii);
            bt_UpdtData.setMnemonic(ConstUI.CHAR_P30F0013);
        }
        else
        {
            BeanUtil.setWText(bt_UpdtData, P30F0000.getMesg(LangRes.P30F650B));
        }
        BeanUtil.setWTips(bt_UpdtData, P30F0000.getMesg(LangRes.P30F650C));

        // 复制
        ii = Util.getIcon(ConstUI.ICON_P30F0012);
        if (ii != null)
        {
            bt_CopyData.setIcon(ii);
            bt_CopyData.setMnemonic(ConstUI.CHAR_P30F0012);
        }
        else
        {
            BeanUtil.setWText(bt_CopyData, P30F0000.getMesg(LangRes.P30F6509));
        }
        BeanUtil.setWTips(bt_CopyData, P30F0000.getMesg(LangRes.P30F650A));
    }

    /**
     * @param evt
     */
    private void bt_CopyDataActionPerformed(java.awt.event.ActionEvent evt)
    {
        EnvUtil.setClipboardContents(new String(pf_PwdsData.getPassword()), true);
    }

    /**
     * @param evt
     */
    private void bt_DeltDataActionPerformed(java.awt.event.ActionEvent evt)
    {
        ud_UserData.remove(pi_PropItem);
        ud_UserData.setModified(true);

        ud_UserData.fireTableDataChanged();

        np_NormPanel.selectNext();
    }

    /**
     * @param evt
     */
    private void bt_GentPwdsActionPerformed(java.awt.event.ActionEvent evt)
    {
        if (askOverRide && CheckUtil.isValidate(pi_PropItem.getData()))
        {
            if (0 != MesgUtil.showConfirmDialog(this, P30F0000.getMesg(LangRes.P30F6A07)))
            {
                return;
            }
            askOverRide = false;
        }

        if (km_KsetMenu == null)
        {
            km_KsetMenu = new KsetMenu();
            km_KsetMenu.wInit();
        }

        try
        {
            char[] t = HashUtil.nextRandomKey(km_KsetMenu.getKeySets(), km_KsetMenu.getKeySize(), km_KsetMenu
                .isNoRepeat());
            pf_PwdsData.setText(new String(t));
        }
        catch(Exception exp)
        {
            LogUtil.exception(exp);
            MesgUtil.showMessageDialog(this, exp.getMessage());
        }
    }

    /**
     * @param evt
     */
    private void bt_PwdsKsetActionPerformed(java.awt.event.ActionEvent evt)
    {
        if (km_KsetMenu == null)
        {
            km_KsetMenu = new KsetMenu();
            km_KsetMenu.wInit();
        }
        km_KsetMenu.showPopupMenu(bt_PwdsKset, 0, bt_PwdsKset.getSize().height);
    }

    /**
     * @param evt
     */
    private void bt_ViewPwdsActionPerformed(java.awt.event.ActionEvent evt)
    {
        if (pf_PwdsData.getEchoChar() == 0)
        {
            bt_ViewPwds.setIcon(ii_HidePwds);
            bt_ViewPwds.setToolTipText(P30F0000.getMesg(LangRes.P30F6513));
            pf_PwdsData.setEchoChar('*');
        }
        else
        {
            if (ii_HidePwds != null)
            {
                bt_ViewPwds.setIcon(ii_ViewPwds);
            }
            pf_PwdsData.setEchoChar('\0');
            bt_ViewPwds.setToolTipText(P30F0000.getMesg(LangRes.P30F6514));
        }
    }

    /**
     * @param evt
     */
    private void bt_UpdtDataActionPerformed(java.awt.event.ActionEvent evt)
    {
        String name = tf_PwdsName.getText();
        if (!CheckUtil.isValidate(name))
        {
            MesgUtil.showMessageDialog(this, P30F0000.getMesg(LangRes.P30F6A05));
            tf_PwdsName.requestFocus();
            return;
        }

        pi_PropItem.setName(name);
        pi_PropItem.setData(new String(pf_PwdsData.getPassword()));
        ud_UserData.setModified(true);

        ud_UserData.fireTableDataChanged();

        np_NormPanel.selectNext();
    }

    private javax.swing.JButton        bt_CopyData;
    private javax.swing.JButton        bt_DeltData;
    private javax.swing.JButton        bt_GentPwds;
    private javax.swing.JButton        bt_PwdsKset;
    private javax.swing.JButton        bt_UpdtData;
    private javax.swing.JButton        bt_ViewPwds;
    private javax.swing.JLabel         lb_PwdsData;
    private javax.swing.JLabel         lb_PwdsName;
    private javax.swing.JPasswordField pf_PwdsData;
    private javax.swing.JTextField     tf_PwdsName;

    /** serialVersionUID */
    private static final long          serialVersionUID = -9023701805037762841L;
}
