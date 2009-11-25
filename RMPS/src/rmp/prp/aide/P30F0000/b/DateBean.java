/*
 * FileName:       TimeBean.java
 * CreateDate:     2008-3-24 下午12:42:07
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.P30F0000.b;

import java.text.SimpleDateFormat;

import javax.swing.DefaultComboBoxModel;
import javax.swing.ImageIcon;

import rmp.bean.K1SV2S;
import rmp.prp.aide.P30F0000.P30F0000;
import rmp.prp.aide.P30F0000.i.WProp;
import rmp.prp.aide.P30F0000.m.UserData;
import rmp.prp.aide.P30F0000.t.Util;
import rmp.prp.aide.P30F0000.v.NormPanel;
import rmp.util.BeanUtil;
import cons.prp.aide.P30F0000.ConstUI;
import cons.prp.aide.P30F0000.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br>
 * 日期时间组件
 * <li>使用说明：</li>
 * <br>
 * </ul>
 * <p>
 * 版本： RMPS V1.0.0.0
 * </p>
 * <p>
 * 作者： shangwen.yao
 * </p>
 * <p>
 * 日期： 2008-3-24 下午12:42:07
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class DateBean extends javax.swing.JPanel implements WProp
{
    private NormPanel            np_NormPanel;
    private UserData             ud_UserData;
    private PropItem             pi_PropItem;
    private DefaultComboBoxModel cm_TypeList;

    /**
     * 
     */
    public DateBean(NormPanel panel, UserData uData)
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
        if (tf_DateTime.getText().trim().length() < 1)
        {
            tf_DateTime.setText(new SimpleDateFormat(P30F0000.getMesg(LangRes.P30F1101)).format(ud_UserData
                .getDateTime()));
        }

        if (cm_TypeList == null)
        {
            cm_TypeList = new DefaultComboBoxModel(Util.readPropType());
            cb_TypeList.setModel(cm_TypeList);
        }
        cb_TypeList.setSelectedItem(ud_UserData.getTypeHash());
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.JComponent#requestFocus()
     */
    public void requestFocus()
    {
        cb_TypeList.requestFocus();
    }

    /**
     * 
     */
    private void ica()
    {
        lb_DateTime = new javax.swing.JLabel();
        tf_DateTime = new javax.swing.JTextField();
        lb_TypeList = new javax.swing.JLabel();
        cb_TypeList = new javax.swing.JComboBox();
        bt_UpdtData = new javax.swing.JButton();

        lb_DateTime.setLabelFor(tf_DateTime);

        tf_DateTime.setColumns(20);
        tf_DateTime.setEditable(false);

        lb_TypeList.setLabelFor(cb_TypeList);

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
            layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_TypeList)
                    .addComponent(lb_DateTime)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(
                    layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(tf_DateTime,
                        javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                        javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(cb_TypeList,
                        javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                        javax.swing.GroupLayout.PREFERRED_SIZE)).addContainerGap(74, Short.MAX_VALUE)).addGroup(
            javax.swing.GroupLayout.Alignment.TRAILING,
            layout.createSequentialGroup().addContainerGap(165, Short.MAX_VALUE).addComponent(bt_UpdtData)
                .addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_DateTime)
                    .addComponent(tf_DateTime, javax.swing.GroupLayout.PREFERRED_SIZE,
                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_TypeList)
                    .addComponent(cb_TypeList, javax.swing.GroupLayout.PREFERRED_SIZE,
                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE,
                Short.MAX_VALUE).addComponent(bt_UpdtData).addContainerGap()));
    }

    /**
     * 
     */
    private void ita()
    {
        // 当前日期
        BeanUtil.setWText(lb_DateTime, P30F0000.getMesg(LangRes.P30F630F));
        BeanUtil.setWTips(lb_DateTime, P30F0000.getMesg(LangRes.P30F6310));

        // 口令类别
        BeanUtil.setWText(lb_TypeList, P30F0000.getMesg(LangRes.P30F6311));
        BeanUtil.setWTips(lb_TypeList, P30F0000.getMesg(LangRes.P30F6312));

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
        // 用户自定义类别索引
        K1SV2S kv = (K1SV2S)cb_TypeList.getSelectedItem();
        if (kv == null)
        {
            return;
        }

        // 创建时间
        pi_PropItem.setName(tf_DateTime.getText());

        // 数据类别
        pi_PropItem.setData(kv.getK());

        // 显示默认自定义类别
        ud_UserData.reInit(kv.getK());
        ud_UserData.fireTableDataChanged();

        ud_UserData.setModified(true);

        np_NormPanel.requestName();
    }

    private javax.swing.JButton    bt_UpdtData;
    private javax.swing.JComboBox  cb_TypeList;
    private javax.swing.JLabel     lb_DateTime;
    private javax.swing.JLabel     lb_TypeList;
    private javax.swing.JTextField tf_DateTime;

    /** serialVersionUID */
    private static final long      serialVersionUID = -7675189068115636974L;
}
