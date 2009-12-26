/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.comn.user.U0000000.v;

import rmp.comn.user.U0000000.U0000000;

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
public class NormPanel extends javax.swing.JPanel
{
    /**
     * @param soft
     */
    public NormPanel(U0000000 soft)
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.ui.frm.FViewPanel#wInit()
     */
    public boolean wInit()
    {
        ica();
        icb();
        icc();
        ita();
        itb();

        return true;
    }

    /**
     * 
     */
    private void ica()
    {
        pl_LogoPanl = new javax.swing.JPanel();
    }

    /**
     * 
     */
    private void icb()
    {
        pl_SignPanl = new javax.swing.JPanel();
        pl_SignPanl.setBorder(javax.swing.BorderFactory.createLineBorder(new java.awt.Color(204, 204, 255)));

        lb_unm = new javax.swing.JLabel();
        unm = new javax.swing.JTextField();
        lb_pwd = new javax.swing.JLabel();
        pwd = new javax.swing.JPasswordField();
        lb_uti = new javax.swing.JLabel();
        uti = new javax.swing.JTextField();
        lc_IdCode = new javax.swing.JLabel();
        lk_Create = new javax.swing.JLabel();
        lk_Forget = new javax.swing.JLabel();

        lb_unm.setDisplayedMnemonic('I');
        lb_unm.setLabelFor(unm);
        lb_unm.setText("帐号(I)");
        lb_unm.setToolTipText("帐号");

        lb_pwd.setDisplayedMnemonic('P');
        lb_pwd.setLabelFor(pwd);
        lb_pwd.setText("口令(P)");
        lb_pwd.setToolTipText("口令");

        lb_uti.setDisplayedMnemonic('U');
        lb_uti.setLabelFor(uti);
        lb_uti.setText("防伪(U)");
        lb_uti.setToolTipText("防伪");

        uti.setColumns(20);

        lc_IdCode.setText("认证文字");
        lc_IdCode.addMouseListener(new java.awt.event.MouseAdapter()
        {
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                lc_IdCodeMouseClicked(evt);
            }
        });

        lk_Create.setText("申请帐号");
        lk_Create.addMouseListener(new java.awt.event.MouseAdapter()
        {
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                lk_CreateMouseClicked(evt);
            }
        });

        lk_Forget.setText("忘记口令");
        lk_Forget.addMouseListener(new java.awt.event.MouseAdapter()
        {
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                lk_ForgetMouseClicked(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(pl_SignPanl);
        pl_SignPanl.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_uti).addComponent(lb_pwd).addComponent(lb_unm)).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                                layout.createSequentialGroup().addComponent(uti, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lc_IdCode)).addGroup(
                                javax.swing.GroupLayout.Alignment.TRAILING,
                                layout.createSequentialGroup().addGroup(
                                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING).addComponent(pwd, javax.swing.GroupLayout.DEFAULT_SIZE, 140, Short.MAX_VALUE)
                                                .addComponent(unm, javax.swing.GroupLayout.DEFAULT_SIZE, 140, Short.MAX_VALUE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                        .addGroup(
                                                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lk_Create, javax.swing.GroupLayout.Alignment.TRAILING).addComponent(
                                                        lk_Forget, javax.swing.GroupLayout.Alignment.TRAILING)))).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_unm).addComponent(lk_Create).addComponent(unm, javax.swing.GroupLayout.PREFERRED_SIZE,
                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_pwd).addComponent(lk_Forget).addComponent(pwd, javax.swing.GroupLayout.PREFERRED_SIZE,
                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_uti).addComponent(uti, javax.swing.GroupLayout.PREFERRED_SIZE,
                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lc_IdCode)).addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE,
                        Short.MAX_VALUE)));
    }

    /**
     * 
     */
    private void icc()
    {
        bt_Cancel = new javax.swing.JButton();
        bt_SignIn = new javax.swing.JButton();
        lk_Status = new javax.swing.JLabel();

        javax.swing.GroupLayout pl_LogoPanlLayout = new javax.swing.GroupLayout(pl_LogoPanl);
        pl_LogoPanl.setLayout(pl_LogoPanlLayout);
        pl_LogoPanlLayout.setHorizontalGroup(pl_LogoPanlLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGap(0, 300, Short.MAX_VALUE));
        pl_LogoPanlLayout.setVerticalGroup(pl_LogoPanlLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGap(0, 48, Short.MAX_VALUE));

        bt_Cancel.setMnemonic('C');
        bt_Cancel.setText("取消(C)");
        bt_Cancel.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_CancelActionPerformed(evt);
            }
        });

        bt_SignIn.setMnemonic('L');
        bt_SignIn.setText("登录(L)");
        bt_SignIn.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_SignInActionPerformed(evt);
            }
        });

        lk_Status.setText("登录状态");
        lk_Status.addMouseListener(new java.awt.event.MouseAdapter()
        {
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                lk_StatusMouseClicked(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(pl_LogoPanl, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE).addGroup(
                javax.swing.GroupLayout.Alignment.TRAILING,
                layout.createSequentialGroup().addContainerGap().addComponent(lk_Status).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 133, Short.MAX_VALUE).addComponent(
                        bt_SignIn).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_Cancel).addContainerGap()).addGroup(
                layout.createSequentialGroup().addContainerGap().addComponent(pl_SignPanl, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                        .addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addComponent(pl_LogoPanl, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(pl_SignPanl, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                                Short.MAX_VALUE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(bt_Cancel).addComponent(bt_SignIn).addComponent(lk_Status)).addContainerGap()));
    }

    /**
     * 
     */
    private void ita()
    {
    }

    /**
     * 
     */
    private void itb()
    {
    }

    private void lk_CreateMouseClicked(java.awt.event.MouseEvent evt)
    {
    }

    private void lk_ForgetMouseClicked(java.awt.event.MouseEvent evt)
    {
    }

    private void lc_IdCodeMouseClicked(java.awt.event.MouseEvent evt)
    {
    }

    private void bt_CancelActionPerformed(java.awt.event.ActionEvent evt)
    {
    }

    private void bt_SignInActionPerformed(java.awt.event.ActionEvent evt)
    {
    }

    private void lk_StatusMouseClicked(java.awt.event.MouseEvent evt)
    {
    }

    private javax.swing.JLabel lb_pwd;
    private javax.swing.JLabel lb_unm;
    private javax.swing.JLabel lb_uti;
    private javax.swing.JLabel lc_IdCode;
    private javax.swing.JLabel lk_Create;
    private javax.swing.JLabel lk_Forget;
    private javax.swing.JPasswordField pwd;
    private javax.swing.JTextField unm;
    private javax.swing.JTextField uti;
    private javax.swing.JButton bt_Cancel;
    private javax.swing.JButton bt_SignIn;
    private javax.swing.JLabel lk_Status;
    private javax.swing.JPanel pl_LogoPanl;
    private javax.swing.JPanel pl_SignPanl;
    /** serialVersionUID */
    private static final long serialVersionUID = -4230405727518705689L;
}
