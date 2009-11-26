/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.user.U0020000.v;

import com.amonsoft.rmps.prp.v.IView;
import javax.swing.JPanel;

import rmp.bean.K1SV1S;
import rmp.user.U0020000.U0020000;
import rmp.util.BeanUtil;
import rmp.util.MesgUtil;
import cons.CfgCons;
import cons.user.U0020000.LangRes;

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
    private U0020000 ms_MainSoft;

    /**
     * @param soft
     */
    public MiniPanel(U0020000 soft)
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
        lb_ExistPwd = new javax.swing.JLabel();
        pf_ExistPwd = new javax.swing.JPasswordField();
        lb_RenewPwd = new javax.swing.JLabel();
        pf_RenewPwd = new javax.swing.JPasswordField();
        lb_ReputPwd = new javax.swing.JLabel();
        pf_ReputPwd = new javax.swing.JPasswordField();
        bt_Cancel = new javax.swing.JButton();
        bt_Change = new javax.swing.JButton();

        lb_ExistPwd.setLabelFor(pf_ExistPwd);

        lb_RenewPwd.setLabelFor(pf_RenewPwd);

        lb_ReputPwd.setLabelFor(pf_ReputPwd);

        bt_Cancel.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_CancelActionPerformed(evt);
            }
        });

        bt_Change.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ChangeActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_ExistPwd).addComponent(lb_RenewPwd).addComponent(lb_ReputPwd)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(pf_ExistPwd,
                javax.swing.GroupLayout.DEFAULT_SIZE, 209, Short.MAX_VALUE).addComponent(pf_RenewPwd,
                javax.swing.GroupLayout.DEFAULT_SIZE, 209, Short.MAX_VALUE).addComponent(pf_ReputPwd,
                javax.swing.GroupLayout.DEFAULT_SIZE, 209, Short.MAX_VALUE)).addContainerGap()).addGroup(
                javax.swing.GroupLayout.Alignment.TRAILING,
                layout.createSequentialGroup().addContainerGap(97, Short.MAX_VALUE).addComponent(bt_Change).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_Cancel).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_ExistPwd).addComponent(pf_ExistPwd, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_RenewPwd).addComponent(pf_RenewPwd, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_ReputPwd).addComponent(pf_ReputPwd, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE,
                Short.MAX_VALUE).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(bt_Cancel).addComponent(bt_Change)).addContainerGap()));
    }

    /**
     * 
     */
    private void ita()
    {
        BeanUtil.setWText(lb_ExistPwd, U0020000.getMesg(LangRes.U0025301));
        BeanUtil.setWTips(lb_ExistPwd, U0020000.getMesg(LangRes.U0025302));

        BeanUtil.setWText(lb_RenewPwd, U0020000.getMesg(LangRes.U0025303));
        BeanUtil.setWTips(lb_RenewPwd, U0020000.getMesg(LangRes.U0025304));

        BeanUtil.setWText(lb_ReputPwd, U0020000.getMesg(LangRes.U0025305));
        BeanUtil.setWTips(lb_ReputPwd, U0020000.getMesg(LangRes.U0025306));

        BeanUtil.setWText(bt_Change, U0020000.getMesg(LangRes.U0025501));
        BeanUtil.setWTips(bt_Change, U0020000.getMesg(LangRes.U0025502));

        BeanUtil.setWText(bt_Cancel, U0020000.getMesg(LangRes.U0025503));
        BeanUtil.setWTips(bt_Cancel, U0020000.getMesg(LangRes.U0025504));
    }

    /**
     * @param evt
     */
    private void bt_CancelActionPerformed(java.awt.event.ActionEvent evt)
    {
        ms_MainSoft.firePropertyChanged(CfgCons.SIGN_PWD, null, CfgCons.SIGN_OUT);
        ms_MainSoft.wClosing();
    }

    /**
     * @param evt
     */
    private void bt_ChangeActionPerformed(java.awt.event.ActionEvent evt)
    {
        String p0 = new String(pf_ExistPwd.getPassword());
        if (p0.length() < 1)
        {
            MesgUtil.showMessageDialog(this, U0020000.getMesg(LangRes.U0025A01));
            pf_ExistPwd.requestFocus();
            return;
        }
        String p1 = new String(pf_RenewPwd.getPassword());
        if (p1.length() < 1)
        {
            MesgUtil.showMessageDialog(this, U0020000.getMesg(LangRes.U0025A02));
            pf_RenewPwd.requestFocus();
            return;
        }
        String p2 = new String(pf_ReputPwd.getPassword());
        if (!p1.equals(p2))
        {
            MesgUtil.showMessageDialog(this, U0020000.getMesg(LangRes.U0025A03));
            pf_RenewPwd.setText("");
            pf_ReputPwd.setText("");
            pf_RenewPwd.requestFocus();
            return;
        }
        ms_MainSoft.firePropertyChanged(CfgCons.SIGN_PWD, new K1SV1S(p0, p1), CfgCons.SIGN_PWD);
        ms_MainSoft.wClosing();
    }
    private javax.swing.JButton bt_Cancel;
    private javax.swing.JButton bt_Change;
    private javax.swing.JLabel lb_ExistPwd;
    private javax.swing.JLabel lb_RenewPwd;
    private javax.swing.JLabel lb_ReputPwd;
    private javax.swing.JPasswordField pf_ExistPwd;
    private javax.swing.JPasswordField pf_RenewPwd;
    private javax.swing.JPasswordField pf_ReputPwd;
    /**  */
    private static final long serialVersionUID = -3668534924715086636L;
}
