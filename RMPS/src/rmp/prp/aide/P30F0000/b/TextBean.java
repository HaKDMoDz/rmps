/*
 * FileName:       TextBean.java
 * CreateDate:     2008-2-28 下午08:26:15
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.P30F0000.b;

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
 * 日期： 2008-2-28 下午08:26:15
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class TextBean extends javax.swing.JPanel implements WProp
{
    private NormPanel np_NormPanel;
    private UserData  ud_UserData;
    private PropItem  pi_PropItem;

    /**
     * 
     */
    public TextBean(NormPanel panel, UserData uData)
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
        tf_PropName.setText(name);
        tf_PropData.setText(pi.getData());
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.JComponent#requestFocus()
     */
    public void requestFocus()
    {
        tf_PropData.requestFocus();
    }

    /**
     * 
     */
    private void ica()
    {
        lb_PropName = new javax.swing.JLabel();
        tf_PropName = new javax.swing.JTextField();
        lb_PropData = new javax.swing.JLabel();
        tf_PropData = new javax.swing.JTextField();
        bt_DeltData = new javax.swing.JButton();
        bt_UpdtData = new javax.swing.JButton();
        bt_CopyData = new javax.swing.JButton();

        lb_PropName.setLabelFor(tf_PropName);

        tf_PropName.setColumns(20);

        lb_PropData.setLabelFor(tf_PropData);

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
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_PropData)
                            .addComponent(lb_PropName)).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(tf_PropName,
                            javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                            javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(tf_PropData,
                            javax.swing.GroupLayout.DEFAULT_SIZE, 270, Short.MAX_VALUE))).addGroup(
                    javax.swing.GroupLayout.Alignment.TRAILING,
                    layout.createSequentialGroup().addComponent(bt_CopyData).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_UpdtData).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_DeltData)))));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_PropName)
                    .addComponent(tf_PropName, javax.swing.GroupLayout.PREFERRED_SIZE,
                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_PropData)
                    .addComponent(tf_PropData, javax.swing.GroupLayout.PREFERRED_SIZE,
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
        BeanUtil.setWText(lb_PropName, P30F0000.getMesg(LangRes.P30F6303));
        BeanUtil.setWTips(lb_PropName, P30F0000.getMesg(LangRes.P30F6304));

        // 属性内容
        BeanUtil.setWText(lb_PropData, P30F0000.getMesg(LangRes.P30F6305));
        BeanUtil.setWTips(lb_PropData, P30F0000.getMesg(LangRes.P30F6306));

        // 删除
        ImageIcon ii;
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
        EnvUtil.setClipboardContents(tf_PropData.getText());
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
        String name = tf_PropName.getText();
        if (!CheckUtil.isValidate(name))
        {
            MesgUtil.showMessageDialog(this, P30F0000.getMesg(LangRes.P30F6A05));
            tf_PropName.requestFocus();
            return;
        }

        pi_PropItem.setName(name);
        pi_PropItem.setData(tf_PropData.getText());
        ud_UserData.setModified(true);

        ud_UserData.fireTableDataChanged();

        np_NormPanel.selectNext();
    }

    private javax.swing.JButton    bt_CopyData;
    private javax.swing.JButton    bt_DeltData;
    private javax.swing.JButton    bt_UpdtData;
    private javax.swing.JLabel     lb_PropData;
    private javax.swing.JLabel     lb_PropName;
    private javax.swing.JTextField tf_PropData;
    private javax.swing.JTextField tf_PropName;

    /** serialVersionUID */
    private static final long      serialVersionUID = -5799805190309568707L;
}
