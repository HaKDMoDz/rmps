/*
 * FileName:       LinkBean.java
 * CreateDate:     2008-2-28 下午08:26:04
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
 * 日期： 2008-2-28 下午08:26:04
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class LinkBean extends javax.swing.JPanel implements WProp
{
    private NormPanel np_NormPanel;
    private UserData  ud_UserData;
    private PropItem  pi_PropItem;

    /**
     * 
     */
    public LinkBean(NormPanel panel, UserData uData)
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
        this.pi_PropItem = pi;
        String name = pi.getName();
        if (!CheckUtil.isValidate(pi.getData()) && (name.startsWith(ConstUI.SP_LS) && name.endsWith(ConstUI.SP_RS)))
        {
            name = name.substring(1, name.length() - 1);
        }
        tf_LinkName.setText(name);
        tf_LinkData.setText(pi.getData());
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.JComponent#requestFocus()
     */
    public void requestFocus()
    {
        tf_LinkData.requestFocus();
    }

    /**
     * 
     */
    private void ica()
    {
        lb_LinkData = new javax.swing.JLabel();
        lb_LinkName = new javax.swing.JLabel();
        tf_LinkData = new javax.swing.JTextField();
        tf_LinkName = new javax.swing.JTextField();
        bt_ViewLink = new javax.swing.JButton();
        bt_DeltData = new javax.swing.JButton();
        bt_UpdtData = new javax.swing.JButton();
        bt_CopyData = new javax.swing.JButton();

        lb_LinkName.setLabelFor(tf_LinkName);

        tf_LinkName.setColumns(20);

        lb_LinkData.setLabelFor(tf_LinkData);

        bt_ViewLink.setBorderPainted(false);
        bt_ViewLink.setContentAreaFilled(false);
        bt_ViewLink.setMargin(new java.awt.Insets(0, 0, 0, 0));
        bt_ViewLink.setCursor(Cursor.getPredefinedCursor(Cursor.HAND_CURSOR));
        bt_ViewLink.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ViewLinkActionPerformed(evt);
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
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_LinkData)
                            .addComponent(lb_LinkName)).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(tf_LinkName,
                            javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                            javax.swing.GroupLayout.PREFERRED_SIZE).addGroup(
                            layout.createSequentialGroup().addComponent(tf_LinkData,
                                javax.swing.GroupLayout.DEFAULT_SIZE, 166, Short.MAX_VALUE).addPreferredGap(
                                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_ViewLink))))
                    .addGroup(
                        javax.swing.GroupLayout.Alignment.TRAILING,
                        layout.createSequentialGroup().addComponent(bt_CopyData).addPreferredGap(
                            javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_UpdtData)
                            .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(
                                bt_DeltData)))));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_LinkName)
                    .addComponent(tf_LinkName, javax.swing.GroupLayout.PREFERRED_SIZE,
                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_LinkData)
                    .addComponent(bt_ViewLink).addComponent(tf_LinkData, javax.swing.GroupLayout.PREFERRED_SIZE,
                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
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
        BeanUtil.setWText(lb_LinkName, P30F0000.getMesg(LangRes.P30F6303));
        BeanUtil.setWTips(lb_LinkName, P30F0000.getMesg(LangRes.P30F6304));

        // 属性内容
        BeanUtil.setWText(lb_LinkData, P30F0000.getMesg(LangRes.P30F6305));
        BeanUtil.setWTips(lb_LinkData, P30F0000.getMesg(LangRes.P30F6306));

        // 打开链接
        ImageIcon ii;
        ii = Util.getIcon(ConstUI.ICON_P30F0031);
        if (ii != null)
        {
            bt_ViewLink.setIcon(ii);
            bt_ViewLink.setMnemonic(ConstUI.CHAR_P30F0031);
        }
        else
        {
            BeanUtil.setWText(bt_ViewLink, P30F0000.getMesg(LangRes.P30F6511));
        }
        BeanUtil.setWTips(bt_ViewLink, P30F0000.getMesg(LangRes.P30F6512));

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
        EnvUtil.setClipboardContents(tf_LinkData.getText());
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
    private void bt_UpdtDataActionPerformed(java.awt.event.ActionEvent evt)
    {
        String name = tf_LinkName.getText();
        if (!CheckUtil.isValidate(name))
        {
            MesgUtil.showMessageDialog(this, P30F0000.getMesg(LangRes.P30F6A05));
            tf_LinkName.requestFocus();
            return;
        }

        pi_PropItem.setName(name);
        pi_PropItem.setData(tf_LinkData.getText());
        ud_UserData.setModified(true);

        ud_UserData.fireTableDataChanged();

        np_NormPanel.selectNext();
    }

    /**
     * @param evt
     */
    private void bt_ViewLinkActionPerformed(java.awt.event.ActionEvent evt)
    {
        String url = tf_LinkData.getText();
        if (!CheckUtil.isValidate(url))
        {
            return;
        }

        EnvUtil.browse(url);
    }

    private javax.swing.JButton    bt_CopyData;
    private javax.swing.JButton    bt_DeltData;
    private javax.swing.JButton    bt_UpdtData;
    private javax.swing.JButton    bt_ViewLink;
    private javax.swing.JLabel     lb_LinkData;
    private javax.swing.JLabel     lb_LinkName;
    private javax.swing.JTextField tf_LinkData;
    private javax.swing.JTextField tf_LinkName;

    /** serialVersionUID */
    private static final long      serialVersionUID = 1819065387062390352L;
}
