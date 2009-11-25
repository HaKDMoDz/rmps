/*
 * FileName:       HistPanel.java
 * CreateDate:     2008-6-14 上午10:34:42
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amon.CT@hotmail.com / http://www.winshine.net.cn/ ).
 * Description:    
 */

package rmp.prp.aide.P30F0000.v;

import java.util.List;

import javax.swing.DefaultListModel;
import javax.swing.JDialog;

import rmp.bean.CellRender;
import rmp.bean.K1SV2S;
import rmp.face.WBean;
import rmp.prp.aide.P30F0000.P30F0000;
import rmp.prp.aide.P30F0000.m.UserData;
import rmp.prp.aide.P30F0000.t.Util;
import rmp.util.BeanUtil;
import rmp.util.MesgUtil;
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
 * 日期： 2008-6-14 上午10:34:42
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class HistPanel extends JDialog implements WBean
{
    private static HistPanel hp_HistForm;
    private DefaultListModel lm_HistList;
    private UserData         ud_UserData;
    private Object           mo_LastItem;
    private String           ms_KeysHash;

    public HistPanel(UserData userData)
    {
        super(P30F0000.getForm());
        this.ud_UserData = userData;
    }

    public boolean wInit()
    {
        ica();
        ita();

        this.pack();
        this.setIconImage(BeanUtil.getLogoImage());
        this.setTitle(P30F0000.getMesg(LangRes.P30FA201));
        this.setDefaultCloseOperation(JDialog.DISPOSE_ON_CLOSE);
        return true;
    }

    public static HistPanel getInstance(UserData userData)
    {
        if (hp_HistForm == null)
        {
            hp_HistForm = new HistPanel(userData);
            hp_HistForm.wInit();
        }
        return hp_HistForm;
    }

    public void setUserKeys(String userKeys)
    {
        ms_KeysHash = userKeys;

        lm_HistList.clear();
        ta_ItemInfo.setText("");
        List<K1SV2S> list = Util.listHistoryByID(userKeys);
        for (K1SV2S kv : list)
        {
            lm_HistList.addElement(kv);
        }
    }

    private void ica()
    {
        javax.swing.JScrollPane sp1 = new javax.swing.JScrollPane();
        ls_HistList = new javax.swing.JList();
        javax.swing.JScrollPane sp2 = new javax.swing.JScrollPane();
        ta_ItemInfo = new javax.swing.JTextArea();
        bt_PickBack = new javax.swing.JButton();

        lm_HistList = new DefaultListModel();
        ls_HistList.setCellRenderer(new CellRender());
        ls_HistList.setModel(lm_HistList);
        ls_HistList.setSelectionMode(javax.swing.ListSelectionModel.SINGLE_SELECTION);
        ls_HistList.addListSelectionListener(new javax.swing.event.ListSelectionListener()
        {
            public void valueChanged(javax.swing.event.ListSelectionEvent evt)
            {
                ls_HistListValueChanged(evt);
            }
        });
        sp1.setViewportView(ls_HistList);

        ta_ItemInfo.setEditable(false);
        sp2.setViewportView(ta_ItemInfo);

        bt_PickBack.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_PickBackActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this.getContentPane());
        this.getContentPane().setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addComponent(sp1, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING).addComponent(bt_PickBack)
                    .addComponent(sp2, javax.swing.GroupLayout.DEFAULT_SIZE, 239, Short.MAX_VALUE)).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                    javax.swing.GroupLayout.Alignment.TRAILING,
                    layout.createSequentialGroup().addComponent(sp2, javax.swing.GroupLayout.DEFAULT_SIZE, 251,
                        Short.MAX_VALUE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(bt_PickBack)).addComponent(sp1, javax.swing.GroupLayout.DEFAULT_SIZE, 280,
                    Short.MAX_VALUE)).addContainerGap()));
    }

    private void ita()
    {
        BeanUtil.setWText(bt_PickBack, P30F0000.getMesg(LangRes.P30FA501));
        BeanUtil.setWTips(bt_PickBack, P30F0000.getMesg(LangRes.P30FA502));
    }

    private void bt_PickBackActionPerformed(java.awt.event.ActionEvent evt)
    {
        Object obj = ls_HistList.getSelectedValue();
        if (obj == null)
        {
            return;
        }

        if (!(obj instanceof K1SV2S))
        {
            return;
        }

        if (0 != MesgUtil.showConfirmDialog(this, P30F0000.getMesg(LangRes.P30FAA01)))
        {
            return;
        }

        K1SV2S kv = (K1SV2S)obj;
        kv = Util.pickUpHistory(ms_KeysHash, kv.getK());
        if (kv == null)
        {
            MesgUtil.showMessageDialog(this, P30F0000.getMesg(LangRes.P30FAA02));
            return;
        }

        lm_HistList.add(0, kv);
        MesgUtil.showMessageDialog(this, P30F0000.getMesg(LangRes.P30FAA03));
    }

    private void ls_HistListValueChanged(javax.swing.event.ListSelectionEvent evt)
    {
        Object item = ls_HistList.getSelectedValue();
        if (item == null || item.equals(mo_LastItem))
        {
            return;
        }
        mo_LastItem = item;

        if (item instanceof K1SV2S)
        {
            K1SV2S kv = (K1SV2S)item;
            ta_ItemInfo.setText(ud_UserData.deCrypt(ms_KeysHash, kv.getK()));
        }
    }

    private javax.swing.JButton   bt_PickBack;
    private javax.swing.JList     ls_HistList;
    private javax.swing.JTextArea ta_ItemInfo;

    /**  */
    private static final long     serialVersionUID = 4989276729852735014L;

}
