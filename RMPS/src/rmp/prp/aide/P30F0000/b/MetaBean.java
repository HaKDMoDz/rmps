/*
 * FileName:       MetaBean.java
 * CreateDate:     2008-4-4 上午08:57:47
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
import rmp.util.MesgUtil;
import rmp.util.StringUtil;
import cons.db.PrpCons;
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
 * 日期： 2008-4-4 上午08:57:47
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class MetaBean extends javax.swing.JPanel implements WProp
{
    private NormPanel np_NormPanel;
    private UserData  ud_UserData;
    private PropItem  pi_PropItem;

    /**
     * @param uData
     */
    public MetaBean(NormPanel panel, UserData uData)
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
    @ Override
    public void setPropItem(PropItem pi)
    {
        pi_PropItem = pi;
        tf_KeysName.setText(ud_UserData.getKeysName());
        ta_KeysMeta.setText(ud_UserData.getKeysMeta());
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.JComponent#requestFocus()
     */
    public void requestFocus()
    {
        tf_KeysName.requestFocus();
    }

    /**
     * 
     */
    private void ica()
    {
        lb_KeysName = new javax.swing.JLabel();
        tf_KeysName = new javax.swing.JTextField();
        lb_KeysMeta = new javax.swing.JLabel();
        javax.swing.JScrollPane sp1 = new javax.swing.JScrollPane();
        ta_KeysMeta = new javax.swing.JTextArea();
        bt_UpdtData = new javax.swing.JButton();

        lb_KeysName.setLabelFor(tf_KeysName);

        tf_KeysName.setColumns(20);

        lb_KeysMeta.setLabelFor(ta_KeysMeta);

        sp1.setViewportView(ta_KeysMeta);

        bt_UpdtData.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_UpdtDataActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_KeysMeta)
                    .addComponent(lb_KeysName)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(
                    layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(tf_KeysName,
                        javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                        javax.swing.GroupLayout.PREFERRED_SIZE).addGroup(
                        layout.createSequentialGroup().addComponent(sp1, javax.swing.GroupLayout.DEFAULT_SIZE, 149,
                            Short.MAX_VALUE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                            .addComponent(bt_UpdtData)))));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            javax.swing.GroupLayout.Alignment.TRAILING,
            layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING).addComponent(bt_UpdtData)
                    .addGroup(
                        layout.createSequentialGroup().addGroup(
                            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(
                                lb_KeysName).addComponent(tf_KeysName, javax.swing.GroupLayout.PREFERRED_SIZE,
                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                            .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(
                                    lb_KeysMeta).addComponent(sp1, javax.swing.GroupLayout.DEFAULT_SIZE, 77,
                                    Short.MAX_VALUE)))).addContainerGap()));
    }

    /**
     * 
     */
    private void ita()
    {
        // 口令名称
        BeanUtil.setWText(lb_KeysName, P30F0000.getMesg(LangRes.P30F630D));
        BeanUtil.setWTips(lb_KeysName, P30F0000.getMesg(LangRes.P30F630E));

        // 关键搜索
        BeanUtil.setWText(lb_KeysMeta, P30F0000.getMesg(LangRes.P30F6313));
        BeanUtil.setWTips(lb_KeysMeta, P30F0000.getMesg(LangRes.P30F6314));

        // 更新
        ImageIcon ii;
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
    }

    /**
     * @param evt
     */
    private void bt_UpdtDataActionPerformed(java.awt.event.ActionEvent evt)
    {
        String keysName = tf_KeysName.getText();
        if (!CheckUtil.isValidate(keysName))
        {
            MesgUtil.showMessageDialog(this, P30F0000.getMesg(LangRes.P30F6A06));
            tf_KeysName.requestFocus();
            return;
        }
        if (!CheckUtil.isValidateLength(keysName, PrpCons.P30F0107_SIZE))
        {
            // 长度不能超过256个字符
            MesgUtil.showMessageDialog(this, StringUtil.format(P30F0000.getMesg(LangRes.P30F6A16), ""
                + PrpCons.P30F0107_SIZE));
            tf_KeysName.requestFocus();
            return;
        }

        String keysMeta = ta_KeysMeta.getText();
        if (!CheckUtil.isValidateLength(keysMeta, PrpCons.P30F0108_SIZE))
        {
            // 长度不能超过2048个字符
            MesgUtil.showMessageDialog(this, StringUtil.format(P30F0000.getMesg(LangRes.P30F6A17), ""
                + PrpCons.P30F0108_SIZE));
            ta_KeysMeta.requestFocus();
            return;
        }

        // 口令名称
        pi_PropItem.setName(keysName);
        ud_UserData.setKeysName(keysName);

        // 关键搜索
        pi_PropItem.setData(keysMeta);
        ud_UserData.setKeysMeta(keysMeta);
        ud_UserData.setModified(true);

        ud_UserData.fireTableDataChanged();

        np_NormPanel.selectNext();
    }

    private javax.swing.JButton    bt_UpdtData;
    private javax.swing.JLabel     lb_KeysMeta;
    private javax.swing.JLabel     lb_KeysName;
    private javax.swing.JTextArea  ta_KeysMeta;
    private javax.swing.JTextField tf_KeysName;

    /** serialVersionUID */
    private static final long      serialVersionUID = -5014811595385836066L;
}
