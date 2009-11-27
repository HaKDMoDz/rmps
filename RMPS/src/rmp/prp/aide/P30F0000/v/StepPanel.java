/*
 * FileName:       StepPanel.java
 * CreateDate:     2008-4-6 下午06:42:45
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.P30F0000.v;

import java.util.EventObject;

import rmp.bean.K1SV1S;
import rmp.face.WBackCall;
import com.amonsoft.rmps.prp.IPrpPlus;
import rmp.prp.aide.P30F0000.P30F0000;
import rmp.prp.aide.P30F0000.t.Util;
import rmp.ui.text.WTextArea;
import rmp.user.U0000000.U0000000;
import rmp.util.BeanUtil;
import rmp.util.MesgUtil;
import cons.CfgCons;

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
 * 日期： 2008-4-6 下午06:42:45
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class StepPanel extends javax.swing.JPanel implements WBackCall
{
    private P30F0000 ms_MainSoft;

    /**
     * 
     */
    public StepPanel(P30F0000 soft)
    {
        this.ms_MainSoft = soft;
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
     * @see rmp.face.WBackCall#wAction(java.util.EventObject, java.lang.Object,
     *      java.lang.String)
     */
    @ Override
    public void wAction(EventObject event, Object object, String property)
    {
        if (!(object instanceof K1SV1S))
        {
            return;
        }
        K1SV1S kv = (K1SV1S)object;

        try
        {
            Util.getUserData().signIn(kv.getK(), kv.getV());
            ms_MainSoft.wShowView(IPrpPlus.VIEW_NORM);
        }
        catch(Exception exp)
        {
            MesgUtil.showMessageDialog(null, exp.getMessage());
        }
    }

    /**
     * 
     */
    private void ica()
    {

        bt_Login = new javax.swing.JButton();
        javax.swing.JScrollPane sp1 = new javax.swing.JScrollPane();
        ta_Login = new WTextArea();

        bt_Login.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_LoginActionPerformed(evt);
            }
        });

        ta_Login.wInit();
        sp1.setViewportView(ta_Login);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            javax.swing.GroupLayout.Alignment.TRAILING,
            layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING).addComponent(sp1,
                    javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 300,
                    Short.MAX_VALUE).addComponent(bt_Login)).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            javax.swing.GroupLayout.Alignment.TRAILING,
            layout.createSequentialGroup().addContainerGap().addComponent(sp1, javax.swing.GroupLayout.DEFAULT_SIZE,
                161, Short.MAX_VALUE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(
                bt_Login).addContainerGap()));
    }

    /**
     * 
     */
    private void ita()
    {
        BeanUtil.setWText(bt_Login, "保存(&S)");
        BeanUtil.setWTips(bt_Login, "保存文本");
    }

    /**
     * @param evt
     */
    private void bt_LoginActionPerformed(java.awt.event.ActionEvent evt)
    {
        U0000000 u000 = new U0000000();
        u000.wInitView();
        u000.register(CfgCons.SIGN_IN, this);
        u000.wShowView(IPrpPlus.VIEW_MINI);
    }

    private javax.swing.JButton bt_Login;
    private WTextArea           ta_Login;

    /** serialVersionUID */
    private static final long   serialVersionUID = -5241115210175322014L;
}
