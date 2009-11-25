/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3010000.b;

import javax.swing.DefaultComboBoxModel;

import rmp.bean.K1SV2S;
import rmp.face.WBackCall;
import rmp.prp.aide.P3010000.P3010000;
import rmp.prp.aide.P3010000.m.UserData;
import rmp.util.BeanUtil;
import rmp.util.MesgUtil;
import cons.prp.aide.P3010000.LangRes;

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
public class UserBean extends javax.swing.JPanel
{
    /**  */
    private static final long serialVersionUID = 1L;
    /** 回调事件对象 */
    private WBackCall bc_BackCall;
    /** 用户查询数据对象 */
    private UserData ud_UserData;
    /** 用户上一次选择软件对象 */
    private K1SV2S kv_LastItem;
    /** 软件下拉列表数据模型 */
    private DefaultComboBoxModel bm_SoftList;

    /**
     * 
     */
    public UserBean()
    {
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
        rb_CaseSens.setSelected(true);
        pl_CasePanl.add(rb_CaseSens);

        bg_CaseButn.add(rb_CaseUprs);
        pl_CasePanl.add(rb_CaseUprs);

        bg_CaseButn.add(rb_CaseLows);
        pl_CasePanl.add(rb_CaseLows);

        lb_ExtsName.setLabelFor(tf_ExtsName);

        bt_ExtsName.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ExtsNameActionPerformed(evt);
            }
        });

        tf_ExtsName.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                tf_ExtsNameActionPerformed(evt);
            }
        });

        lb_SoftList.setLabelFor(cb_SoftList);

        cb_SoftList.addItemListener(new java.awt.event.ItemListener()
        {
            @Override
            public void itemStateChanged(java.awt.event.ItemEvent evt)
            {
                cb_SoftListItemStateChanged(evt);
            }
        });

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
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_ExtsName).addComponent(bt_ExtsName).addComponent(tf_ExtsName, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_SoftList).addComponent(cb_SoftList, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))));
    }

    /**
     * 
     */
    private void ita()
    {
        // 大小敏感
        BeanUtil.setWText(rb_CaseSens, P3010000.getMesg(LangRes.MAIN_RBTN_TEXT_CASESENS));
        BeanUtil.setWTips(rb_CaseSens, P3010000.getMesg(LangRes.MAIN_RBTN_TIPS_CASESENS));

        // 大写
        BeanUtil.setWText(rb_CaseUprs, P3010000.getMesg(LangRes.MAIN_RBTN_TEXT_CASEUPRS));
        BeanUtil.setWTips(rb_CaseUprs, P3010000.getMesg(LangRes.MAIN_RBTN_TIPS_CASEUPRS));

        // 小写
        BeanUtil.setWText(rb_CaseLows, P3010000.getMesg(LangRes.MAIN_RBTN_TEXT_CASELOWS));
        BeanUtil.setWTips(rb_CaseLows, P3010000.getMesg(LangRes.MAIN_RBTN_TIPS_CASELOWS));

        // 后缀名称
        BeanUtil.setWText(lb_ExtsName, P3010000.getMesg(LangRes.MAIN_LABL_TEXT_EXTSNAME));
        BeanUtil.setWTips(lb_ExtsName, P3010000.getMesg(LangRes.MAIN_LABL_TIPS_EXTSNAME));

        BeanUtil.setWText(tf_ExtsName, P3010000.getMesg(LangRes.MAIN_FILD_TEXT_EXTSNAME));
        BeanUtil.setWTips(tf_ExtsName, P3010000.getMesg(LangRes.MAIN_FILD_TIPS_EXTSNAME));

        // 查询按钮
        BeanUtil.setWText(bt_ExtsName, P3010000.getMesg(LangRes.MAIN_BUTN_TEXT_EXTSNAME));
        BeanUtil.setWTips(bt_ExtsName, P3010000.getMesg(LangRes.MAIN_BUTN_TIPS_EXTSNAME));

        // 所属软件
        BeanUtil.setWText(lb_SoftList, P3010000.getMesg(LangRes.MAIN_LABL_TEXT_SOFTNAME));
        BeanUtil.setWTips(lb_SoftList, P3010000.getMesg(LangRes.MAIN_LABL_TIPS_SOFTNAME));

        BeanUtil.setWTips(cb_SoftList, P3010000.getMesg(LangRes.MAIN_COMB_TIPS_SOFTNAME));
    }

    /**
     * @param kvItem
     */
    public void add(UserData v)
    {
        bm_SoftList.addElement(new K1SV2S(v.getSoftHash(), v.getSoftName(), v.getSoftName()));
    }

    /**
     * 
     */
    public void clear()
    {
        bm_SoftList.removeAllElements();
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

    /**
     * 获得用户输入数据信息，存在错误的情况下，返回值为NULL。
     * 
     * @param softInc 是否包含软件的相关信息：true包含。
     * @return
     */
    public UserData getUserData(boolean softInc)
    {
        // 用户数据为空判断
        if (ud_UserData == null)
        {
            ud_UserData = new UserData();
            ud_UserData.wInit();
        }

        // 后缀名称
        if (!ud_UserData.setExtsName(getExtsName()))
        {
            MesgUtil.showMessageDialog(P3010000.getForm(), ud_UserData.getErrMsg());
            tf_ExtsName.requestFocus();
            return null;
        }
        tf_ExtsName.setText(ud_UserData.getExtsName());

        ud_UserData.setSoftHash(null);
        ud_UserData.setSoftName(null);

        // 回调事件
        bc_BackCall.wAction(null, ud_UserData, null);

        // 包含软件信息的情况
        String softHash = null;
        String softName = null;
        if (softInc)
        {
            // 事件源判断
            Object obj = cb_SoftList.getSelectedItem();
            if (obj == null || !(obj instanceof K1SV2S))
            {
                MesgUtil.showMessageDialog(null, P3010000.getMesg(LangRes.MAIN_MESG_CHCK_0002));
                return null;
            }

            // 避免多次提交
            K1SV2S kvItem = (K1SV2S) obj;
            if (kvItem == kv_LastItem)
            {
                return null;
            }

            softHash = kvItem.getK();
            softName = kvItem.getV1();
        }

        ud_UserData.setSoftHash(softHash);
        ud_UserData.setSoftName(softName);

        return ud_UserData;
    }

    /**
     * @param backCall
     */
    public void setBackCall(WBackCall backCall)
    {
        this.bc_BackCall = backCall;
    }

    /**
     * @param extsName
     */
    public void setExtsName(String extsName)
    {
        tf_ExtsName.setText(extsName);
    }

    /**
     * @param evt
     */
    private void bt_ExtsNameActionPerformed(java.awt.event.ActionEvent evt)
    {
        getUserData(false);
        bc_BackCall.wAction(null, ud_UserData, null);
    }

    /**
     * @param evt
     */
    private void tf_ExtsNameActionPerformed(java.awt.event.ActionEvent evt)
    {
        getUserData(false);
        bc_BackCall.wAction(null, ud_UserData, null);
    }

    /**
     * @param evt
     */
    private void cb_SoftListItemStateChanged(java.awt.event.ItemEvent evt)
    {
        // 事件源判断
        Object obj = cb_SoftList.getSelectedItem();
        if (obj == null || !(obj instanceof K1SV2S))
        {
            return;
        }

        // 避免多次提交
        K1SV2S kvItem = (K1SV2S) obj;
        if (kvItem == kv_LastItem)
        {
            return;
        }

        // 用户数据为空判断
        if (ud_UserData == null)
        {
            ud_UserData = new UserData();
            ud_UserData.wInit();
        }

        // 数据检测
        if (!ud_UserData.setExtsName(getExtsName()))
        {
            MesgUtil.showMessageDialog(P3010000.getForm(), ud_UserData.getErrMsg());
            tf_ExtsName.requestFocus();
            return;
        }
        tf_ExtsName.setText(ud_UserData.getExtsName());

        ud_UserData.setSoftHash(kvItem.getK());
        ud_UserData.setSoftName(kvItem.getV1());

        // 回调事件
        bc_BackCall.wAction(null, ud_UserData, null);
    }
    protected javax.swing.JButton bt_ExtsName;
    protected javax.swing.JComboBox cb_SoftList;
    protected javax.swing.JLabel lb_ExtsName;
    protected javax.swing.JLabel lb_SoftList;
    protected javax.swing.JRadioButton rb_CaseLows;
    protected javax.swing.JRadioButton rb_CaseSens;
    protected javax.swing.JRadioButton rb_CaseUprs;
    protected javax.swing.JTextField tf_ExtsName;
}
