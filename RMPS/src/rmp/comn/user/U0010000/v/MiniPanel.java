/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.comn.user.U0010000.v;

import com.amonsoft.rmps.prp.v.IView;
import javax.swing.JPanel;

import rmp.Rmps;
import rmp.bean.K1SV1S;
import rmp.comn.user.U0010000.U0010000;
import rmp.util.BeanUtil;
import rmp.util.MesgUtil;
import cons.CfgCons;
import cons.comn.user.U0010000.LangRes;

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
public class MiniPanel extends JPanel implements IView
{
    private U0010000 ms_MainSoft;

    /**
     * @param soft
     */
    public MiniPanel(U0010000 soft)
    {
        this.ms_MainSoft = soft;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#wInit()
     */
    @Override
    public boolean wInit()
    {
        ica();
        ita();

        return true;
    }

    /**
     * 
     */
    private void ica()
    {
        lb_UserName = new javax.swing.JLabel();
        tf_UserName = new javax.swing.JTextField();
        lb_RenewPwd = new javax.swing.JLabel();
        pf_RenewPwd = new javax.swing.JPasswordField();
        lb_ReputPwd = new javax.swing.JLabel();
        pf_ReputPwd = new javax.swing.JPasswordField();
        bt_Cancel = new javax.swing.JButton();
        bt_Create = new javax.swing.JButton();

        lb_UserName.setLabelFor(tf_UserName);

        lb_RenewPwd.setLabelFor(pf_RenewPwd);

        lb_ReputPwd.setLabelFor(pf_ReputPwd);

        bt_Cancel.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_CancelActionPerformed(evt);
            }
        });

        bt_Create.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_CreateActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(
                lb_UserName).addComponent(lb_RenewPwd).addComponent(lb_ReputPwd)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(
                tf_UserName, javax.swing.GroupLayout.DEFAULT_SIZE, 194, Short.MAX_VALUE).addComponent(
                pf_RenewPwd, javax.swing.GroupLayout.DEFAULT_SIZE, 194, Short.MAX_VALUE).addComponent(
                pf_ReputPwd, javax.swing.GroupLayout.DEFAULT_SIZE, 194, Short.MAX_VALUE))).addGroup(
                javax.swing.GroupLayout.Alignment.TRAILING,
                layout.createSequentialGroup().addComponent(bt_Create).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_Cancel))).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_UserName).addComponent(tf_UserName, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_RenewPwd).addComponent(pf_RenewPwd, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_ReputPwd).addComponent(pf_ReputPwd, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE,
                Short.MAX_VALUE).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(bt_Cancel).addComponent(bt_Create)).addContainerGap()));
    }

    /**
     * 
     */
    private void ita()
    {
        BeanUtil.setWText(lb_UserName, U0010000.getMesg(LangRes.U0015301));
        BeanUtil.setWTips(lb_UserName, U0010000.getMesg(LangRes.U0015302));

        BeanUtil.setWText(lb_RenewPwd, U0010000.getMesg(LangRes.U0015303));
        BeanUtil.setWTips(lb_RenewPwd, U0010000.getMesg(LangRes.U0015304));

        BeanUtil.setWText(lb_ReputPwd, U0010000.getMesg(LangRes.U0015305));
        BeanUtil.setWTips(lb_ReputPwd, U0010000.getMesg(LangRes.U0015306));

        BeanUtil.setWText(bt_Cancel, U0010000.getMesg(LangRes.U0015501));
        BeanUtil.setWTips(bt_Cancel, U0010000.getMesg(LangRes.U0015502));

        BeanUtil.setWText(bt_Create, U0010000.getMesg(LangRes.U0015503));
        BeanUtil.setWTips(bt_Create, U0010000.getMesg(LangRes.U0015504));
    }

    /**
     * @param evt
     */
    private void bt_CancelActionPerformed(java.awt.event.ActionEvent evt)
    {
        ms_MainSoft.firePropertyChanged(CfgCons.SIGN_UP, null, CfgCons.SIGN_OUT);
        Rmps.exit(0, false, false);
    }

    /**
     * @param evt
     */
    private void bt_CreateActionPerformed(java.awt.event.ActionEvent evt)
    {
        // 登录名称检测
        String un = tf_UserName.getText();
        if (un == null)
        {
            MesgUtil.showMessageDialog(this, U0010000.getMesg(LangRes.U0015A01));
            tf_UserName.requestFocus();
            return;
        }
        un = un.trim();
        if (un.length() < 1)
        {
            MesgUtil.showMessageDialog(this, U0010000.getMesg(LangRes.U0015A01));
            tf_UserName.requestFocus();
            return;
        }

        // 口令为空检测
        String p1 = new String(pf_RenewPwd.getPassword());
        if (p1.length() < 1)
        {
            MesgUtil.showMessageDialog(this, U0010000.getMesg(LangRes.U0015A02));
            pf_RenewPwd.requestFocus();
            return;
        }

        // 口令不一致检测
        String p2 = new String(pf_ReputPwd.getPassword());
        if (!p1.equals(p2))
        {
            MesgUtil.showMessageDialog(this, U0010000.getMesg(LangRes.U0015A03));
            pf_RenewPwd.setText("");
            pf_ReputPwd.setText("");
            pf_RenewPwd.requestFocus();
            return;
        }

        ms_MainSoft.firePropertyChanged(CfgCons.SIGN_UP, new K1SV1S(un, p1), CfgCons.SIGN_UP);
        ms_MainSoft.wClosing();
    }
    private javax.swing.JButton bt_Cancel;
    private javax.swing.JButton bt_Create;
    private javax.swing.JLabel lb_RenewPwd;
    private javax.swing.JLabel lb_ReputPwd;
    private javax.swing.JLabel lb_UserName;
    private javax.swing.JPasswordField pf_RenewPwd;
    private javax.swing.JPasswordField pf_ReputPwd;
    private javax.swing.JTextField tf_UserName;
}
