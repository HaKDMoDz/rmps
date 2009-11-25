/*
 * FileName:       WUserPanel.java
 * CreateDate:     2007-8-29 下午08:28:03
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.extparse.v;

import rmp.face.WBean;
import rmp.prp.aide.extparse.Extparse;
import rmp.util.BeanUtil;
import cons.prp.aide.extparse.LangRes;

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
 * 日期： 2007-8-29 下午08:28:03
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class WUserPanel extends javax.swing.JPanel implements WBean
{
    /**
     * 
     */
    public WUserPanel()
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
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
        javax.swing.ButtonGroup bg_CaseButn = new javax.swing.ButtonGroup();
        javax.swing.JPanel pl_CasePanl = new javax.swing.JPanel();
        rb_CaseSens = new javax.swing.JRadioButton();
        rb_CaseUprs = new javax.swing.JRadioButton();
        rb_CaseLows = new javax.swing.JRadioButton();
        lb_ExtsName = new javax.swing.JLabel();
        bt_ExtsName = new javax.swing.JButton();
        tf_ExtsName = new javax.swing.JTextField();
        lb_SoftList = new javax.swing.JLabel();
        cb_SoftList = new javax.swing.JComboBox();

        pl_CasePanl.setLayout(new java.awt.FlowLayout(java.awt.FlowLayout.CENTER, 5, 0));

        bg_CaseButn.add(rb_CaseSens);
        rb_CaseSens.setMnemonic('S');
        rb_CaseSens.setSelected(true);
        rb_CaseSens.setText("\u5927\u5c0f\u654f\u611f(S)");
        rb_CaseSens.setToolTipText("\u5927\u5c0f\u654f\u611f");
        rb_CaseSens.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        rb_CaseSens.setMargin(new java.awt.Insets(0, 0, 0, 0));
        pl_CasePanl.add(rb_CaseSens);

        bg_CaseButn.add(rb_CaseUprs);
        rb_CaseUprs.setMnemonic('B');
        rb_CaseUprs.setText("\u5927\u5199(B)");
        rb_CaseUprs.setToolTipText("\u5927\u5199");
        rb_CaseUprs.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        rb_CaseUprs.setMargin(new java.awt.Insets(0, 0, 0, 0));
        pl_CasePanl.add(rb_CaseUprs);

        bg_CaseButn.add(rb_CaseLows);
        rb_CaseLows.setMnemonic('L');
        rb_CaseLows.setText("\u5c0f\u5199(L)");
        rb_CaseLows.setToolTipText("\u5c0f\u5199");
        rb_CaseLows.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        rb_CaseLows.setMargin(new java.awt.Insets(0, 0, 0, 0));
        pl_CasePanl.add(rb_CaseLows);

        lb_ExtsName.setLabelFor(tf_ExtsName);
        lb_ExtsName.setText("\u540e\u7f00\u540d\u79f0(E)");
        lb_ExtsName.setToolTipText("\u540e\u7f00\u540d\u79f0");

        bt_ExtsName.setMnemonic('Q');
        bt_ExtsName.setText("\u67e5\u8be2(Q)");
        bt_ExtsName.setToolTipText("\u67e5\u8be2\u540e\u7f00\u7684\u8be6\u7ec6\u4fe1\u606f");
        bt_ExtsName.setMargin(new java.awt.Insets(1, 7, 1, 7));

        tf_ExtsName
            .setToolTipText("\u540e\u7f00\u540d\u79f0\uff0c\u6ce8\u610f\u7cfb\u7edf\u4e25\u683c\u533a\u5206\u5927\u5c0f\u5199");

        lb_SoftList.setDisplayedMnemonic('S');
        lb_SoftList.setLabelFor(cb_SoftList);
        lb_SoftList.setText("\u8f6f\u4ef6\u5217\u8868(S)");
        lb_SoftList.setToolTipText("\u8f6f\u4ef6\u5217\u8868");

        cb_SoftList.setToolTipText("\u5177\u6709\u540c\u4e00\u540e\u7f00\u540d\u79f0\u7684\u8f6f\u4ef6\u5217\u8868");

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(pl_CasePanl,
                    javax.swing.GroupLayout.DEFAULT_SIZE, 240, Short.MAX_VALUE).addGroup(
                    layout.createSequentialGroup().addComponent(lb_ExtsName).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(tf_ExtsName,
                        javax.swing.GroupLayout.DEFAULT_SIZE, 103, Short.MAX_VALUE).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_ExtsName)).addGroup(
                    layout.createSequentialGroup().addComponent(lb_SoftList).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(cb_SoftList, 0, 170,
                        Short.MAX_VALUE))).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addComponent(pl_CasePanl, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_ExtsName)
                    .addComponent(bt_ExtsName).addComponent(tf_ExtsName, javax.swing.GroupLayout.PREFERRED_SIZE,
                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_SoftList)
                    .addComponent(cb_SoftList, javax.swing.GroupLayout.PREFERRED_SIZE,
                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))));
    }

    /**
     * 
     */
    private void ita()
    {
        // 大小敏感
        BeanUtil.setWText(rb_CaseSens, Extparse.getMesg(LangRes.MAIN_RBTN_TEXT_CASESENS));
        BeanUtil.setWTips(rb_CaseSens, Extparse.getMesg(LangRes.MAIN_RBTN_TIPS_CASESENS));

        // 大写
        BeanUtil.setWText(rb_CaseUprs, Extparse.getMesg(LangRes.MAIN_RBTN_TEXT_CASEUPRS));
        BeanUtil.setWTips(rb_CaseUprs, Extparse.getMesg(LangRes.MAIN_RBTN_TIPS_CASEUPRS));

        // 小写
        BeanUtil.setWText(rb_CaseLows, Extparse.getMesg(LangRes.MAIN_RBTN_TEXT_CASELOWS));
        BeanUtil.setWTips(rb_CaseLows, Extparse.getMesg(LangRes.MAIN_RBTN_TIPS_CASELOWS));

        // 后缀名称
        BeanUtil.setWText(lb_ExtsName, Extparse.getMesg(LangRes.MAIN_LABL_TEXT_EXTSNAME));
        BeanUtil.setWTips(lb_ExtsName, Extparse.getMesg(LangRes.MAIN_LABL_TIPS_EXTSNAME));

        BeanUtil.setWText(tf_ExtsName, Extparse.getMesg(LangRes.MAIN_FILD_TEXT_EXTSNAME));
        BeanUtil.setWTips(tf_ExtsName, Extparse.getMesg(LangRes.MAIN_FILD_TIPS_EXTSNAME));

        // 查询按钮
        BeanUtil.setWText(bt_ExtsName, Extparse.getMesg(LangRes.MAIN_BUTN_TEXT_EXTSNAME));
        BeanUtil.setWTips(bt_ExtsName, Extparse.getMesg(LangRes.MAIN_BUTN_TIPS_EXTSNAME));

        // 所属软件
        BeanUtil.setWText(lb_SoftList, Extparse.getMesg(LangRes.MAIN_LABL_TEXT_SOFTNAME));
        BeanUtil.setWTips(lb_SoftList, Extparse.getMesg(LangRes.MAIN_LABL_TIPS_SOFTNAME));

        BeanUtil.setWTips(cb_SoftList, Extparse.getMesg(LangRes.MAIN_COMB_TIPS_SOFTNAME));
    }

    /**
     * @return
     */
    public String getExtsName()
    {
        // 大写转换
        if (this.rb_CaseUprs.isSelected())
        {
            return tf_ExtsName.getText().toUpperCase();
        }

        // 小写转换
        if (this.rb_CaseLows.isSelected())
        {
            return tf_ExtsName.getText().toLowerCase();
        }

        // 大小写敏感
        return tf_ExtsName.getText();
    }

    protected javax.swing.JButton      bt_ExtsName;
    protected javax.swing.JComboBox    cb_SoftList;
    protected javax.swing.JLabel       lb_ExtsName;
    protected javax.swing.JLabel       lb_SoftList;
    protected javax.swing.JRadioButton rb_CaseLows;
    protected javax.swing.JRadioButton rb_CaseSens;
    protected javax.swing.JRadioButton rb_CaseUprs;
    protected javax.swing.JTextField   tf_ExtsName;
}
