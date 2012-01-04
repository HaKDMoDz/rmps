/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.comn.user.U0000000.v;

import rmp.Rmps;
import rmp.bean.K1SV1S;
import rmp.comn.user.U0000000.U0000000;
import rmp.util.BeanUtil;
import rmp.util.MesgUtil;
import cons.CfgCons;
import cons.comn.user.U0000000.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br />
 * TODO: 使用说明
 * </ul>
 * 
 * @author Amon
 */
public class MiniPanel extends javax.swing.JPanel
{
    private U0000000 ms_MainSoft;

    /**
     * @param soft
     */
    public MiniPanel(U0000000 soft)
    {
        this.ms_MainSoft = soft;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.ui.frm.FViewPanel#wInit()
     */
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
        lb_UserPwds = new javax.swing.JLabel();
        pf_UserPwds = new javax.swing.JPasswordField();
        bt_Cancel = new javax.swing.JButton();
        bt_SingIn = new javax.swing.JButton();

        lb_UserName.setLabelFor(tf_UserName);

        lb_UserPwds.setLabelFor(pf_UserPwds);

        tf_UserName.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                signIn();
            }
        });

        pf_UserPwds.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                signIn();
            }
        });

        bt_Cancel.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_CancelActionPerformed(evt);
            }
        });

        bt_SingIn.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                signIn();
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout
                .setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                        layout.createSequentialGroup().addContainerGap().addGroup(
                                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                                        layout.createSequentialGroup().addGroup(
                                                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_UserPwds).addComponent(lb_UserName)).addPreferredGap(
                                                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                                                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(tf_UserName, javax.swing.GroupLayout.DEFAULT_SIZE, 179,
                                                        Short.MAX_VALUE).addComponent(pf_UserPwds, javax.swing.GroupLayout.DEFAULT_SIZE, 179, Short.MAX_VALUE))).addGroup(
                                        javax.swing.GroupLayout.Alignment.TRAILING,
                                        layout.createSequentialGroup().addComponent(bt_SingIn).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_Cancel)))
                                .addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_UserName).addComponent(tf_UserName, javax.swing.GroupLayout.PREFERRED_SIZE,
                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_UserPwds).addComponent(pf_UserPwds, javax.swing.GroupLayout.PREFERRED_SIZE,
                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED,
                        javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(bt_Cancel).addComponent(bt_SingIn)).addContainerGap()));
    }

    /**
     * 
     */
    private void ita()
    {
        // 登录用户
        BeanUtil.setWText(lb_UserName, U0000000.getMesg(LangRes.U0005301));
        BeanUtil.setWTips(lb_UserName, U0000000.getMesg(LangRes.U0005302));

        // 登录口令
        BeanUtil.setWText(lb_UserPwds, U0000000.getMesg(LangRes.U0005303));
        BeanUtil.setWTips(lb_UserPwds, U0000000.getMesg(LangRes.U0005304));

        // 取消登录
        BeanUtil.setWText(bt_Cancel, U0000000.getMesg(LangRes.U0005501));
        BeanUtil.setWTips(bt_Cancel, U0000000.getMesg(LangRes.U0005502));

        // 用户登录
        BeanUtil.setWText(bt_SingIn, U0000000.getMesg(LangRes.U0005503));
        BeanUtil.setWTips(bt_SingIn, U0000000.getMesg(LangRes.U0005504));
    }

    /**
     * @param evt
     */
    private void bt_CancelActionPerformed(java.awt.event.ActionEvent evt)
    {
        // ms_MainSoft.firePropertyChanged(CfgCons.SIGN_IN, null,
        // CfgCons.SIGN_OUT);
        Rmps.exit(0, false, false);
    }

    /**
     * 用户登录
     */
    private void signIn()
    {
        String un = tf_UserName.getText().trim();
        if (un.length() < 1)
        {
            MesgUtil.showMessageDialog(this, U0000000.getMesg(LangRes.U0005A01));
            tf_UserName.requestFocus();
            return;
        }

        String pw = new String(pf_UserPwds.getPassword());
        if (pw.length() < 1)
        {
            MesgUtil.showMessageDialog(this, U0000000.getMesg(LangRes.U0005A02));
            pf_UserPwds.requestFocus();
            return;
        }
        ms_MainSoft.firePropertyChanged(CfgCons.SIGN_IN, new K1SV1S(un, pw), CfgCons.SIGN_IN);
        ms_MainSoft.wClosing();
    }

    private javax.swing.JButton bt_Cancel;
    private javax.swing.JButton bt_SingIn;
    private javax.swing.JLabel lb_UserName;
    private javax.swing.JLabel lb_UserPwds;
    private javax.swing.JPasswordField pf_UserPwds;
    private javax.swing.JTextField tf_UserName;
    /** serialVersionUID */
    private static final long serialVersionUID = 8855051492106062974L;
}
