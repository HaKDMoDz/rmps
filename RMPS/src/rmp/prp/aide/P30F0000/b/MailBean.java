/*
 * FileName:       MailBean.java
 * CreateDate:     2008-4-14 下午09:17:08
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_03
 * CopyRight:      Amon (C) 2008 & Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn/ ).
 * Description:    
 */

package rmp.prp.aide.P30F0000.b;

import java.awt.Cursor;

import java.util.logging.Level;
import java.util.logging.Logger;
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
import com.amonsoft.util.DeskUtil;

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
 * 日期： 2008-4-14 下午09:17:08
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class MailBean extends javax.swing.JPanel implements WProp
{
    private NormPanel np_NormPanel;
    private UserData  ud_UserData;
    private PropItem  pi_PropItem;

    /**
     * 
     */
    public MailBean(NormPanel panel, UserData uData)
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
        tf_MailName.setText(name);
        tf_MailData.setText(pi.getData());
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.JComponent#requestFocus()
     */
    public void requestFocus()
    {
        tf_MailData.requestFocus();
    }

    /**
     * 
     */
    private void ica()
    {
        lb_MailData = new javax.swing.JLabel();
        lb_MailName = new javax.swing.JLabel();
        tf_MailData = new javax.swing.JTextField();
        tf_MailName = new javax.swing.JTextField();
        bt_ViewLink = new javax.swing.JButton();
        bt_DeltData = new javax.swing.JButton();
        bt_UpdtData = new javax.swing.JButton();
        bt_CopyData = new javax.swing.JButton();

        lb_MailName.setLabelFor(tf_MailName);

        tf_MailName.setColumns(20);

        lb_MailData.setLabelFor(tf_MailData);

        bt_ViewLink.setBorderPainted(false);
        bt_ViewLink.setContentAreaFilled(false);
        bt_ViewLink.setMargin(new java.awt.Insets(0, 0, 0, 0));
        bt_ViewLink.setCursor(Cursor.getPredefinedCursor(Cursor.HAND_CURSOR));
        bt_ViewLink.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_SendMailActionPerformed(evt);
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
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_MailData)
                            .addComponent(lb_MailName)).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(tf_MailName,
                            javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                            javax.swing.GroupLayout.PREFERRED_SIZE).addGroup(
                            layout.createSequentialGroup().addComponent(tf_MailData,
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
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_MailName)
                    .addComponent(tf_MailName, javax.swing.GroupLayout.PREFERRED_SIZE,
                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_MailData)
                    .addComponent(bt_ViewLink).addComponent(tf_MailData, javax.swing.GroupLayout.PREFERRED_SIZE,
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
        BeanUtil.setWText(lb_MailName, P30F0000.getMesg(LangRes.P30F6307));
        BeanUtil.setWTips(lb_MailName, P30F0000.getMesg(LangRes.P30F6308));

        // 属性内容
        BeanUtil.setWText(lb_MailData, P30F0000.getMesg(LangRes.P30F6309));
        BeanUtil.setWTips(lb_MailData, P30F0000.getMesg(LangRes.P30F630A));

        // 打开链接
        ImageIcon ii;
        ii = Util.getIcon(ConstUI.ICON_P30F0041);
        if (ii != null)
        {
            bt_ViewLink.setIcon(ii);
            bt_ViewLink.setMnemonic(ConstUI.CHAR_P30F0041);
        }
        else
        {
            BeanUtil.setWText(bt_ViewLink, P30F0000.getMesg(LangRes.P30F6515));
        }
        BeanUtil.setWTips(bt_ViewLink, P30F0000.getMesg(LangRes.P30F6516));

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
        EnvUtil.setClipboardContents(tf_MailData.getText());
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
        String name = tf_MailName.getText();
        if (!CheckUtil.isValidate(name))
        {
            MesgUtil.showMessageDialog(this, P30F0000.getMesg(LangRes.P30F6A05));
            tf_MailName.requestFocus();
            return;
        }

        pi_PropItem.setName(name);
        pi_PropItem.setData(tf_MailData.getText());
        ud_UserData.setModified(true);

        ud_UserData.fireTableDataChanged();

        np_NormPanel.selectNext();
    }

    /**
     * @param evt
     */
    private void bt_SendMailActionPerformed(java.awt.event.ActionEvent evt)
    {
        String url = tf_MailData.getText();
        if (!CheckUtil.isValidate(url))
        {
            return;
        }
        try
        {
            DeskUtil.mail("mailto:" + url);
        }
        catch (Exception ex)
        {
            Logger.getLogger(MailBean.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    private javax.swing.JButton    bt_CopyData;
    private javax.swing.JButton    bt_DeltData;
    private javax.swing.JButton    bt_UpdtData;
    private javax.swing.JButton    bt_ViewLink;
    private javax.swing.JLabel     lb_MailData;
    private javax.swing.JLabel     lb_MailName;
    private javax.swing.JTextField tf_MailData;
    private javax.swing.JTextField tf_MailName;

    /**  */
    private static final long      serialVersionUID = 7425786030285565373L;
}
