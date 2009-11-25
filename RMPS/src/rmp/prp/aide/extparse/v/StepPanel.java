/*
 * FileName:       StepPanel.java
 * CreateDate:     2007-9-19 下午02:42:17
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.extparse.v;

import java.sql.SQLException;
import java.util.EventObject;
import java.util.List;

import javax.swing.DefaultComboBoxModel;

import rmp.bean.K1SV2S;
import rmp.bean.K2SV1S;
import rmp.face.WBackCall;
import rmp.io.db.DBAccess;
import rmp.prp.aide.DC0008;
import rmp.prp.aide.extparse.Extparse;
import rmp.prp.aide.extparse.d.DA0008;
import rmp.prp.aide.extparse.m.CorpUserData;
import rmp.prp.aide.extparse.m.ExtsUserData;
import rmp.prp.aide.extparse.m.FileUserData;
import rmp.prp.aide.extparse.m.IdioUserData;
import rmp.prp.aide.extparse.m.SoftUserData;
import rmp.prp.aide.extparse.m.TypeUserData;
import rmp.util.BeanUtil;
import rmp.util.LogUtil;
import rmp.util.MesgUtil;
import rmp.util.StringUtil;
import cons.SysCons;
import cons.id.PrpCons;
import cons.prp.aide.extparse.ConstUI;
import cons.prp.aide.extparse.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br>
 * 向导面板
 * <li>使用说明：</li>
 * <br>
 * </ul>
 * <p>
 * 版本： RMPS V1.0.0.0
 * </p>
 * <p>
 * 作者： Amon
 * </p>
 * <p>
 * 日期： 2007-9-19 下午02:42:17
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class StepPanel extends javax.swing.JPanel implements WBackCall
{
    /**  */
    private static final long    serialVersionUID = 164607321461023654L;
    /** 是否新增数据 */
    private boolean              isCreate         = false;
    /** 当前进行的操作步骤 */
    private int                  currStep         = 0;
    /** 下拉列表模型 */
    private DefaultComboBoxModel cm_UserComb      = null;
    /** 用户交互数据 */
    private ExtsUserData         userMeta         = null;

    /** 父应用引用 */
    private Extparse             me_MainSoft;

    /**
     * 
     */
    public StepPanel(Extparse soft)
    {
        me_MainSoft = soft;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WBackCall#wAction(java.awt.Event, java.lang.Object)
     */
    @ Override
    public void wAction(EventObject event, Object object, String property)
    {

    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    public boolean wInit()
    {
        // 提示信息文本区域
        ta_NoteInfo = new javax.swing.JTextArea();
        ta_NoteInfo.setEditable(false);
        ta_NoteInfo.setEnabled(false);
        ta_NoteInfo.setLineWrap(true);
        ta_NoteInfo.setTabSize(4);
        ta_NoteInfo.setForeground(java.awt.Color.BLACK);

        // 标签
        lb_UserLabl = new javax.swing.JLabel();
        // 文本区域
        tf_UserFild = new javax.swing.JTextField();
        // 下拉列表
        cb_UserComb = new javax.swing.JComboBox();
        cm_UserComb = new DefaultComboBoxModel();
        cb_UserComb.setModel(cm_UserComb);

        // 新增按钮
        bt_UserButn = new javax.swing.JButton();
        bt_UserButn.setMargin(new java.awt.Insets(0, 0, 0, 0));
        bt_UserButn.setMaximumSize(new java.awt.Dimension(20, 20));
        bt_UserButn.setMinimumSize(new java.awt.Dimension(16, 16));
        bt_UserButn.setPreferredSize(new java.awt.Dimension(18, 18));
        bt_UserButn.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_UserButn_Handler(evt);
            }
        });
        BeanUtil.setWText(bt_UserButn, Extparse.getMesg(LangRes.STEP_BUTN_TEXT_INSTBUTN));
        BeanUtil.setWTips(bt_UserButn, Extparse.getMesg(LangRes.STEP_BUTN_TIPS_INSTBUTN));

        // 取消按钮
        bt_ExitButn = new javax.swing.JButton();
        bt_ExitButn.setMnemonic('C');
        bt_ExitButn.setText("\u53d6\u6d88(C)");
        bt_ExitButn.setToolTipText("\u53d6\u6d88\u64cd\u4f5c\u5e76\u9000\u51fa");
        bt_ExitButn.setMargin(new java.awt.Insets(1, 7, 1, 7));
        bt_ExitButn.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ExitButn_Handler(evt);
            }
        });

        // 下一步按钮
        bt_NextButn = new javax.swing.JButton();
        bt_NextButn.setMnemonic('N');
        bt_NextButn.setText("\u4e0b\u4e00\u6b65(N)");
        bt_NextButn.setToolTipText("\u4fdd\u5b58\u64cd\u4f5c\uff0c\u8fdb\u884c\u4e0b\u4e00\u6b65");
        bt_NextButn.setMargin(new java.awt.Insets(1, 7, 1, 7));
        bt_NextButn.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_NextButn_Handler(evt);
            }
        });

        // 上一步按钮
        bt_LastButn = new javax.swing.JButton();
        bt_LastButn.setMnemonic('P');
        bt_LastButn.setText("\u4e0a\u4e00\u6b65(P)");
        bt_LastButn.setToolTipText("\u53d6\u6d88\u64cd\u4f5c\uff0c\u8fd4\u56de\u4e0a\u4e00\u6b65");
        bt_LastButn.setMargin(new java.awt.Insets(1, 7, 1, 7));
        bt_LastButn.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_LastButn_Handler(evt);
            }
        });

        // 用户交互数据
        userMeta = new ExtsUserData();

        // 开始使用
        startWizard();

        return true;
    }

    /**
     * 数据更新
     * 
     * @param extsMeta
     * @return
     */
    public boolean metaUpdate(ExtsUserData extsMeta)
    {
        DBAccess dba = new DBAccess();

        try
        {
            // 连接初始化
            if (!dba.wInit())
            {
                return false;
            }

            // 数据更新
            DA0008.updateExtsMeta(dba, extsMeta);

            return true;
        }
        catch(SQLException exp)
        {
            LogUtil.exception(exp);
            String mesg;
            if (exp.getErrorCode() == -104)
            {
                mesg = Extparse.getMesg(LangRes.MESG_UPDT_0006);
            }
            else
            {
                mesg = StringUtil.format(LangRes.MESG_UPDT_0005, LangRes.TITLE_EXTSFORM, LangRes.MESG_INIT_0010);
            }
            MesgUtil.showMessageDialog(this, mesg);
            return false;
        }
        finally
        {
            dba.closeConnection();
        }
    }

    /**
     * 开始使用
     */
    public void startWizard()
    {
        // 显示向导提示
        currStep = ConstUI.STEP_STT;
        this.removeAll();
        bt_LastButn.setVisible(false);
        ica();
        ita();
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面初始化区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 欢迎面板初始化
     */
    private void ica()
    {
        ta_NoteInfo.setRows(7);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            javax.swing.GroupLayout.Alignment.TRAILING,
            layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING).addComponent(ta_NoteInfo,
                    javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 300,
                    Short.MAX_VALUE).addGroup(
                    layout.createSequentialGroup().addComponent(bt_LastButn).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_NextButn).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_ExitButn)))
                .addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            javax.swing.GroupLayout.Alignment.TRAILING,
            layout.createSequentialGroup().addContainerGap().addComponent(ta_NoteInfo,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED, 13, Short.MAX_VALUE).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(bt_ExitButn)
                    .addComponent(bt_NextButn).addComponent(bt_LastButn)).addContainerGap()));
    }

    /**
     * 文本条面板初始化
     */
    private void icb()
    {
        ta_NoteInfo.setRows(3);
        lb_UserLabl.setLabelFor(tf_UserFild);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(ta_NoteInfo,
                    javax.swing.GroupLayout.DEFAULT_SIZE, 300, Short.MAX_VALUE).addGroup(
                    layout.createSequentialGroup().addComponent(lb_UserLabl).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(tf_UserFild,
                        javax.swing.GroupLayout.DEFAULT_SIZE, 230, Short.MAX_VALUE)).addGroup(
                    javax.swing.GroupLayout.Alignment.TRAILING,
                    layout.createSequentialGroup().addComponent(bt_LastButn).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_NextButn).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_ExitButn)))
                .addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addComponent(ta_NoteInfo,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addGap(18, 18, 18).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_UserLabl)
                    .addComponent(tf_UserFild, javax.swing.GroupLayout.PREFERRED_SIZE,
                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED, 56, Short.MAX_VALUE).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(bt_ExitButn)
                    .addComponent(bt_NextButn).addComponent(bt_LastButn)).addContainerGap()));
    }

    /**
     * 下拉框面板初始化
     */
    private void icc()
    {
        ta_NoteInfo.setRows(3);

        lb_UserLabl.setLabelFor(cb_UserComb);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(ta_NoteInfo,
                    javax.swing.GroupLayout.DEFAULT_SIZE, 300, Short.MAX_VALUE).addGroup(
                    layout.createSequentialGroup().addComponent(lb_UserLabl).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(cb_UserComb, 0, 206,
                        Short.MAX_VALUE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(bt_UserButn, javax.swing.GroupLayout.PREFERRED_SIZE,
                            javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addGroup(
                    javax.swing.GroupLayout.Alignment.TRAILING,
                    layout.createSequentialGroup().addComponent(bt_LastButn).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_NextButn).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_ExitButn)))
                .addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addComponent(ta_NoteInfo,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addGap(18, 18, 18).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_UserLabl)
                    .addComponent(bt_UserButn, javax.swing.GroupLayout.PREFERRED_SIZE,
                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(
                        cb_UserComb, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                        javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED, 56, Short.MAX_VALUE).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(bt_ExitButn)
                    .addComponent(bt_NextButn).addComponent(bt_LastButn)).addContainerGap()));
    }

    /**
     * 应用平台面板初始化
     */
    private void icd()
    {
        ck_PfAll = new javax.swing.JCheckBox();
        ck_PfWin = new javax.swing.JCheckBox();
        ck_PfMac = new javax.swing.JCheckBox();
        ck_PfUnx = new javax.swing.JCheckBox();
        ck_PfLnx = new javax.swing.JCheckBox();
        ck_PfMbl = new javax.swing.JCheckBox();
        ck_PfSpc = new javax.swing.JCheckBox();

        ta_NoteInfo.setRows(3);

        ck_PfAll.setMnemonic('G');
        ck_PfAll.setSelected(true);
        ck_PfAll.setText("\u5e73\u53f0\u901a\u7528(G)");
        ck_PfAll.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_PfAll.setMargin(new java.awt.Insets(0, 0, 0, 0));
        ck_PfAll.addChangeListener(new javax.swing.event.ChangeListener()
        {
            public void stateChanged(javax.swing.event.ChangeEvent evt)
            {
                ck_PfAll_Handler(evt);
            }
        });

        ck_PfWin.setMnemonic('W');
        ck_PfWin.setText("Windows(W)");
        ck_PfWin.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_PfWin.setDisplayedMnemonicIndex(8);
        ck_PfWin.setEnabled(false);
        ck_PfWin.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_PfMac.setMnemonic('M');
        ck_PfMac.setText("Macintosh(M)");
        ck_PfMac.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_PfMac.setDisplayedMnemonicIndex(10);
        ck_PfMac.setEnabled(false);
        ck_PfMac.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_PfUnx.setMnemonic('U');
        ck_PfUnx.setText("Unix(U)");
        ck_PfUnx.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_PfUnx.setDisplayedMnemonicIndex(5);
        ck_PfUnx.setEnabled(false);
        ck_PfUnx.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_PfLnx.setMnemonic('L');
        ck_PfLnx.setText("Linux(L)");
        ck_PfLnx.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_PfLnx.setDisplayedMnemonicIndex(6);
        ck_PfLnx.setEnabled(false);
        ck_PfLnx.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_PfMbl.setMnemonic('B');
        ck_PfMbl.setText("\u79fb\u52a8\u5e73\u53f0(B)");
        ck_PfMbl.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_PfMbl.setEnabled(false);
        ck_PfMbl.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_PfSpc.setMnemonic('O');
        ck_PfSpc.setText("\u5176\u5b83\u5e73\u53f0(O)");
        ck_PfSpc.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_PfSpc.setEnabled(false);
        ck_PfSpc.setMargin(new java.awt.Insets(0, 0, 0, 0));

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(ta_NoteInfo,
                    javax.swing.GroupLayout.DEFAULT_SIZE, 300, Short.MAX_VALUE).addGroup(
                    layout.createSequentialGroup().addComponent(lb_UserLabl).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(ck_PfAll)
                            .addComponent(ck_PfWin).addComponent(ck_PfUnx).addComponent(ck_PfMbl)).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(ck_PfMac)
                            .addComponent(ck_PfLnx).addComponent(ck_PfSpc))).addGroup(
                    javax.swing.GroupLayout.Alignment.TRAILING,
                    layout.createSequentialGroup().addComponent(bt_LastButn).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_NextButn).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_ExitButn)))
                .addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addComponent(ta_NoteInfo,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_UserLabl)
                    .addComponent(ck_PfAll)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(
                    layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(ck_PfWin)
                        .addComponent(ck_PfMac)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(
                    layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(ck_PfUnx)
                        .addComponent(ck_PfLnx)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(
                    layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(ck_PfMbl)
                        .addComponent(ck_PfSpc)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 7,
                    Short.MAX_VALUE).addGroup(
                    layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(bt_ExitButn)
                        .addComponent(bt_NextButn).addComponent(bt_LastButn)).addContainerGap()));
    }

    /**
     * 系统架构面板初始化
     */
    private void ice()
    {
        ck_Ab64 = new javax.swing.JCheckBox();
        ck_Ab32 = new javax.swing.JCheckBox();
        ck_Ab16 = new javax.swing.JCheckBox();
        ck_Ab00 = new javax.swing.JCheckBox();

        ta_NoteInfo.setRows(3);

        ck_Ab64.setMnemonic('3');
        ck_Ab64.setText("64\u4f4d(3)");
        ck_Ab64.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_Ab64.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_Ab32.setMnemonic('2');
        ck_Ab32.setSelected(true);
        ck_Ab32.setText("32\u4f4d(2)");
        ck_Ab32.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_Ab32.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_Ab16.setMnemonic('1');
        ck_Ab16.setText("16\u4f4d(1)");
        ck_Ab16.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_Ab16.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_Ab00.setMnemonic('0');
        ck_Ab00.setText("\u5176\u5b83(0)");
        ck_Ab00.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_Ab00.setMargin(new java.awt.Insets(0, 0, 0, 0));

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(ta_NoteInfo,
                    javax.swing.GroupLayout.DEFAULT_SIZE, 300, Short.MAX_VALUE).addGroup(
                    layout.createSequentialGroup().addComponent(lb_UserLabl).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(ck_Ab64)
                            .addComponent(ck_Ab16)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addGroup(
                            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(ck_Ab00)
                                .addComponent(ck_Ab32))).addGroup(
                    javax.swing.GroupLayout.Alignment.TRAILING,
                    layout.createSequentialGroup().addComponent(bt_LastButn).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_NextButn).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_ExitButn)))
                .addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addComponent(ta_NoteInfo,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addGap(18, 18, 18).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_UserLabl)
                    .addComponent(ck_Ab64).addComponent(ck_Ab32)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(ck_Ab16)
                    .addComponent(ck_Ab00)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 41,
                Short.MAX_VALUE).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(bt_ExitButn)
                    .addComponent(bt_NextButn).addComponent(bt_LastButn)).addContainerGap()));
    }

    /**
     * 个人说明面板初始化
     */
    private void icf()
    {
        ta_NoteInfo.setRows(3);
        lb_UserLabl.setLabelFor(ta_IdioMark);

        javax.swing.JScrollPane sp_IdioMark = new javax.swing.JScrollPane();
        ta_IdioMark = new javax.swing.JTextArea();
        ta_IdioMark.setRows(3);
        sp_IdioMark.setViewportView(ta_IdioMark);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(ta_NoteInfo,
                    javax.swing.GroupLayout.DEFAULT_SIZE, 300, Short.MAX_VALUE).addGroup(
                    layout.createSequentialGroup().addComponent(lb_UserLabl).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(sp_IdioMark,
                        javax.swing.GroupLayout.DEFAULT_SIZE, 230, Short.MAX_VALUE)).addGroup(
                    javax.swing.GroupLayout.Alignment.TRAILING,
                    layout.createSequentialGroup().addComponent(bt_LastButn).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_NextButn).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_ExitButn)))
                .addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addComponent(ta_NoteInfo,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_UserLabl)
                    .addComponent(sp_IdioMark, javax.swing.GroupLayout.PREFERRED_SIZE,
                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED, 19, Short.MAX_VALUE).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(bt_ExitButn)
                    .addComponent(bt_NextButn).addComponent(bt_LastButn)).addContainerGap()));
    }

    /**
     * 欢迎使用向导
     */
    private void ita()
    {
        this.ta_NoteInfo.setText(Extparse.getMesg(LangRes.STEP_OTHR_STEP_0001));
        BeanUtil.setWText(bt_NextButn, Extparse.getMesg(LangRes.STEP_BUTN_TEXT_STATBUTN));
        BeanUtil.setWTips(bt_NextButn, Extparse.getMesg(LangRes.STEP_BUTN_TIPS_STATBUTN));
        BeanUtil.setWText(bt_ExitButn, Extparse.getMesg(LangRes.STEP_BUTN_TEXT_STOPBUTN));
        BeanUtil.setWTips(bt_ExitButn, Extparse.getMesg(LangRes.STEP_BUTN_TIPS_STOPBUTN));
    }

    /**
     * 输入后缀名称
     */
    private void itb()
    {
        this.ta_NoteInfo.setText(Extparse.getMesg(LangRes.STEP_OTHR_STEP_0002));
        BeanUtil.setWText(lb_UserLabl, Extparse.getMesg(LangRes.EXTS_LABL_TEXT_EXTSNAME));
        BeanUtil.setWText(bt_NextButn, Extparse.getMesg(LangRes.STEP_BUTN_TEXT_NEXTBUTN));
        BeanUtil.setWTips(bt_NextButn, Extparse.getMesg(LangRes.STEP_BUTN_TIPS_NEXTBUTN));
        BeanUtil.setWText(bt_ExitButn, Extparse.getMesg(LangRes.STEP_BUTN_TEXT_STOPBUTN));
        BeanUtil.setWTips(bt_ExitButn, Extparse.getMesg(LangRes.STEP_BUTN_TIPS_STOPBUTN));
    }

    /**
     * 选择国别信息
     */
    private void itc()
    {
        this.ta_NoteInfo.setText(Extparse.getMesg(LangRes.STEP_OTHR_STEP_0003));
        BeanUtil.setWText(lb_UserLabl, Extparse.getMesg(LangRes.EXTS_LABL_TEXT_NATNINDX));
    }

    /**
     * 选择公司信息
     */
    private void itd()
    {
        this.ta_NoteInfo.setText(Extparse.getMesg(LangRes.STEP_OTHR_STEP_0004));
        BeanUtil.setWText(lb_UserLabl, Extparse.getMesg(LangRes.EXTS_LABL_TEXT_CORPLCNM));
    }

    /**
     * 选择软件信息
     */
    private void ite()
    {
        this.ta_NoteInfo.setText(Extparse.getMesg(LangRes.STEP_OTHR_STEP_0005));
        BeanUtil.setWText(lb_UserLabl, Extparse.getMesg(LangRes.EXTS_LABL_TEXT_SOFTNAME));
    }

    /**
     * 选择文件信息
     */
    private void itf()
    {
        this.ta_NoteInfo.setText(Extparse.getMesg(LangRes.STEP_OTHR_STEP_0006));
        BeanUtil.setWText(lb_UserLabl, Extparse.getMesg(LangRes.EXTS_LABL_TEXT_SIGNCHAR));
    }

    /**
     * 选择类别信息
     */
    private void itg()
    {
        this.ta_NoteInfo.setText(Extparse.getMesg(LangRes.STEP_OTHR_STEP_0007));
        BeanUtil.setWText(lb_UserLabl, Extparse.getMesg(LangRes.EXTS_LABL_TEXT_EXTSTYPE));
    }

    /**
     * 选择人员信息
     */
    private void ith()
    {
        this.ta_NoteInfo.setText(Extparse.getMesg(LangRes.STEP_OTHR_STEP_0008));
        BeanUtil.setWText(lb_UserLabl, Extparse.getMesg(LangRes.EXTS_LABL_TEXT_IDIOMAIL));
    }

    /**
     * 选择应用平台
     */
    private void iti()
    {
        this.ta_NoteInfo.setText(Extparse.getMesg(LangRes.STEP_OTHR_STEP_0009));
        BeanUtil.setWText(lb_UserLabl, Extparse.getMesg(LangRes.EXTS_LABL_TEXT_PLATFORM));
    }

    /**
     * 选择系统架构
     */
    private void itj()
    {
        this.ta_NoteInfo.setText(Extparse.getMesg(LangRes.STEP_OTHR_STEP_0010));
        BeanUtil.setWText(lb_UserLabl, Extparse.getMesg(LangRes.EXTS_LABL_TEXT_ARCHBITS));
    }

    /**
     * 输入相关说明
     */
    private void itk()
    {
        this.ta_NoteInfo.setText(Extparse.getMesg(LangRes.STEP_OTHR_STEP_0011));
        BeanUtil.setWText(lb_UserLabl, Extparse.getMesg(LangRes.EXTS_LABL_TEXT_IDIOMARK));
    }

    /**
     * 数据添加成功
     */
    private void itl()
    {
        String mesg = StringUtil.format(LangRes.STEP_OTHR_STEP_0012, userMeta.getExtsName());
        this.ta_NoteInfo.setText(mesg);
        BeanUtil.setWText(bt_ExitButn, Extparse.getMesg(LangRes.STEP_BUTN_TEXT_EXITBUTN));
        BeanUtil.setWTips(bt_ExitButn, Extparse.getMesg(LangRes.STEP_BUTN_TEXT_EXITBUTN));
        BeanUtil.setWText(bt_NextButn, Extparse.getMesg(LangRes.STEP_BUTN_TEXT_MOREBUTN));
        BeanUtil.setWTips(bt_NextButn, Extparse.getMesg(LangRes.STEP_BUTN_TEXT_MOREBUTN));
    }

    // ////////////////////////////////////////////////////////////////////////
    // 事件处理区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @param evt
     */
    private void bt_ExitButn_Handler(java.awt.event.ActionEvent evt)
    {
        me_MainSoft.getStepForm().setVisible(false);
    }

    /**
     * @param evt
     */
    private void bt_NextButn_Handler(java.awt.event.ActionEvent evt)
    {
        switch (currStep)
        {
            // 欢迎界面，显示后缀名称面板
            case ConstUI.STEP_STT:
            {
                // 显示下一步面板
                this.removeAll();
                icb();
                itb();
                prepA();
            }
                break;

            // 后缀面板，显示国别列表面板
            case ConstUI.STEP_EXTS:
            {
                // 用户交互数据
                userMeta.wInit();
                if (!userMeta.setExtsName(this.tf_UserFild.getText()))
                {
                    MesgUtil.showMessageDialog(me_MainSoft.getStepForm(), userMeta.getErrMsg());
                    this.tf_UserFild.requestFocus();
                    return;
                }

                // 显示下一步面板
                this.removeAll();
                bt_LastButn.setVisible(true);
                icc();
                itc();
                prepB();
            }
                break;

            // 国别面板，显示公司信息面板
            case ConstUI.STEP_NATN:
            {
                if (!newNatn())
                {
                    return;
                }

                // 显示下一步面板
                itd();
                prepC();
            }
                break;

            // 公司面板，显示软件信息面板
            case ConstUI.STEP_CORP:
            {
                if (!newCorp())
                {
                    return;
                }

                // 显示下一步面板
                ite();
                prepD();
            }
                break;

            // 软件面板，显示文件信息面板
            case ConstUI.STEP_SOFT:
            {
                // 用户交互数据
                if (!newSoft())
                {
                    return;
                }

                // 显示下一步面板
                itf();
                prepE();
            }
                break;

            // 文件面板，显示类别信息面板
            case ConstUI.STEP_FILE:
            {
                // 用户交互数据
                if (!newFile())
                {
                    return;
                }

                // 显示下一步面板
                itg();
                prepF();
            }
                break;

            // 类别面板，显示特别致谢面板
            case ConstUI.STEP_TYPE:
            {
                if (!newType())
                {
                    return;
                }

                // 显示下一步面板
                this.removeAll();
                icc();
                ith();
                prepG();
            }
                break;

            // 致谢面板，显示应用平台面板
            case ConstUI.STEP_IDIO:
            {
                if (!newIdio())
                {
                    return;
                }

                // 显示下一步面板
                this.removeAll();
                icd();
                iti();
                prepH();
            }
                break;

            // 平台面板，显示系统架构面板
            case ConstUI.STEP_PLAT:
            {
                // 用户交互数据
                userMeta.setPlatIndx(encodePlatForm());

                // 显示下一步面板
                this.removeAll();
                ice();
                itj();
                prepI();
            }
                break;

            // 架构面板，显示个人说明面板
            case ConstUI.STEP_ARCH:
            {
                // 用户交互数据
                userMeta.setArchBits(encodeArchBits());

                // 显示下一步面板
                this.removeAll();
                bt_NextButn.setVisible(true);
                icf();
                itk();
                prepJ();
            }
                break;

            // 说明面板，显示添加成功面板
            case ConstUI.STEP_MARK:
            {
                // 用户交互数据
                if (!userMeta.setIdioMark(this.ta_IdioMark.getText()))
                {
                    MesgUtil.showMessageDialog(me_MainSoft.getStepForm(), userMeta.getErrMsg());
                    this.ta_IdioMark.requestFocus();
                    return;
                }
                if (!metaUpdate(userMeta))
                {
                    return;
                }

                // 显示下一步面板
                this.removeAll();
                bt_LastButn.setVisible(false);
                ica();
                itl();
                prepK();
            }
                break;

            // 成功面板，显示后缀名称面板
            case ConstUI.STEP_END:
            {
                this.removeAll();
                bt_LastButn.setVisible(true);
                icb();
                itb();
                currStep = ConstUI.STEP_STT;
                prepA();
            }
                break;

            default:
        }

        currStep += 1;
    }

    /**
     * @param evt
     */
    private void bt_LastButn_Handler(java.awt.event.ActionEvent evt)
    {
        switch (currStep)
        {
            // 欢迎面板
            case ConstUI.STEP_STT:
                break;

            // 后缀面板
            case ConstUI.STEP_EXTS:
                break;

            // 国别面板，显示后缀名称面板
            case ConstUI.STEP_NATN:
                this.removeAll();
                this.bt_LastButn.setVisible(false);
                icb();
                itb();
                break;

            // 公司面板，显示国别信息面板
            case ConstUI.STEP_CORP:
                itc();
                prepB();
                break;

            // 直属软件，显示所属公司面板
            case ConstUI.STEP_SOFT:
                itd();
                prepC();
                break;

            // 文档格式，显示直属软件面板
            case ConstUI.STEP_FILE:
                ite();
                prepD();
                break;

            // 所属类别，显示文档格式面板
            case ConstUI.STEP_TYPE:
                itf();
                prepE();
                break;

            // 特别致谢，显示所属类别面板
            case ConstUI.STEP_IDIO:
                this.removeAll();
                itg();
                prepF();
                break;

            // 应用平台，显示特别致谢面板
            case ConstUI.STEP_PLAT:
                this.removeAll();
                icc();
                ith();
                prepG();
                break;

            // 系统架构，显示应用平台面板
            case ConstUI.STEP_ARCH:
                this.removeAll();
                icd();
                iti();
                break;

            // 个人说明，显示系统架构面板
            case ConstUI.STEP_MARK:
                this.removeAll();
                bt_NextButn.setVisible(true);
                ice();
                itj();
                break;

            // 成功提示，
            case ConstUI.STEP_END:
                break;

            default:
        }

        currStep -= 1;
    }

    /**
     * @param evt
     */
    private void bt_UserButn_Handler(java.awt.event.ActionEvent evt)
    {
        isCreate = true;
        cb_UserComb.setEditable(isCreate);
        cb_UserComb.getEditor().setItem("");
        cb_UserComb.requestFocus();
    }

    /**
     * @param evt
     */
    private void ck_PfAll_Handler(javax.swing.event.ChangeEvent evt)
    {
        boolean b = !this.ck_PfAll.isSelected();

        this.ck_PfWin.setEnabled(b);
        this.ck_PfMac.setEnabled(b);
        this.ck_PfUnx.setEnabled(b);
        this.ck_PfLnx.setEnabled(b);
        this.ck_PfMbl.setEnabled(b);
        this.ck_PfSpc.setEnabled(b);
    }

    // ////////////////////////////////////////////////////////////////////////
    // 数据预备区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 后缀名称
     */
    private void prepA()
    {
        userMeta.wInit();
        this.tf_UserFild.setText("");
    }

    /**
     * 国别信息
     */
    private void prepB()
    {
        cm_UserComb.removeAllElements();

        DBAccess dba = new DBAccess();

        // 数据查寻
        List<K2SV1S> natnList = null;
        try
        {
            if (!dba.wInit())
            {
                return;
            }

            natnList = DA0008.selectNatnMetaName(dba);
        }
        catch(SQLException exp)
        {
            LogUtil.exception(exp);
        }
        finally
        {
            dba.closeConnection();
        }

        // 数据显示
        for (int i = 0, j = natnList.size(); i < j; i += 1)
        {
            cm_UserComb.addElement(natnList.get(i));
        }
    }

    /**
     * 公司信息
     */
    private void prepC()
    {
        cm_UserComb.removeAllElements();

        DBAccess dba = new DBAccess();

        // 数据查寻
        List<K2SV1S> corpList = null;
        try
        {
            if (!dba.wInit())
            {
                return;
            }

            corpList = DA0008.selectCorpMetaName(dba, userMeta.getNatnIndx(), null);
        }
        catch(SQLException exp)
        {
            LogUtil.exception(exp);
        }
        finally
        {
            dba.closeConnection();
        }

        // 数据显示
        for (int i = 0, j = corpList.size(); i < j; i += 1)
        {
            cm_UserComb.addElement(corpList.get(i));
        }
    }

    /**
     * 软件信息
     */
    private void prepD()
    {
        cm_UserComb.removeAllElements();

        DBAccess dba = new DBAccess();

        // 数据查寻
        List<K2SV1S> softList = null;
        try
        {
            if (!dba.wInit())
            {
                return;
            }

            softList = DA0008.selectSoftMetaName(dba, userMeta.getCorpIndx(), null);
        }
        catch(SQLException exp)
        {
            LogUtil.exception(exp);
        }
        finally
        {
            dba.closeConnection();
        }

        // 数据显示
        for (int i = 0, j = softList.size(); i < j; i += 1)
        {
            cm_UserComb.addElement(softList.get(i));
        }
    }

    /**
     * 文件信息
     */
    private void prepE()
    {
        cm_UserComb.removeAllElements();

        DBAccess dba = new DBAccess();

        // 数据查寻
        List<K2SV1S> fileList = null;
        try
        {
            if (!dba.wInit())
            {
                return;
            }

            fileList = DA0008.selectFileMetaName(dba, userMeta.getSoftIndx(), null);
        }
        catch(SQLException exp)
        {
            LogUtil.exception(exp);
        }
        finally
        {
            dba.closeConnection();
        }

        // 数据显示
        for (int i = 0, j = fileList.size(); i < j; i += 1)
        {
            cm_UserComb.addElement(fileList.get(i));
        }
    }

    /**
     * 类别信息
     */
    private void prepF()
    {
        cm_UserComb.removeAllElements();

        DBAccess dba = new DBAccess();

        // 数据查寻
        List<K1SV2S> typeList = null;
        try
        {
            if (!dba.wInit())
            {
                return;
            }

            typeList = DA0008.selectTypeMetaName(dba);
        }
        catch(SQLException exp)
        {
            LogUtil.exception(exp);
        }
        finally
        {
            dba.closeConnection();
        }

        // 数据显示
        for (int i = 0, j = typeList.size(); i < j; i += 1)
        {
            cm_UserComb.addElement(typeList.get(i));
        }
    }

    /**
     * 人员信息
     */
    private void prepG()
    {
        cm_UserComb.removeAllElements();

        DBAccess dba = new DBAccess();

        // 数据查寻
        List<K2SV1S> idioList = null;
        try
        {
            if (!dba.wInit())
            {
                return;
            }

            idioList = DA0008.selectIdioMetaName(dba, "");
        }
        catch(SQLException exp)
        {
            LogUtil.exception(exp);
        }
        finally
        {
            dba.closeConnection();
        }

        // 数据显示
        for (int i = 0, j = idioList.size(); i < j; i += 1)
        {
            cm_UserComb.addElement(idioList.get(i));
        }
    }

    /**
     * 应用平台
     */
    private void prepH()
    {
        this.ck_PfAll.setSelected(true);
        this.ck_PfWin.setEnabled(false);
        this.ck_PfMac.setEnabled(false);
        this.ck_PfUnx.setEnabled(false);
        this.ck_PfLnx.setEnabled(false);
        this.ck_PfMbl.setEnabled(false);
        this.ck_PfSpc.setEnabled(false);
    }

    /**
     * 系统架构
     */
    private void prepI()
    {
        this.ck_Ab64.setSelected(false);
        this.ck_Ab32.setSelected(true);
        this.ck_Ab16.setSelected(false);
        this.ck_Ab00.setSelected(false);
    }

    /**
     * 个人说明
     */
    private void prepJ()
    {
        this.ta_IdioMark.setText("");
    }

    /**
     * 提示成功
     */
    private void prepK()
    {
    }

    /**
     * @return
     */
    private int encodePlatForm()
    {
        // 平台通用
        if (this.ck_PfAll.isSelected())
        {
            return SysCons.OS_IDX_ALL;
        }

        int platForm = 0;

        // Windows
        if (this.ck_PfWin.isSelected())
        {
            platForm |= SysCons.OS_IDX_WINDOWS;
        }

        // Macintosh
        if (this.ck_PfMac.isSelected())
        {
            platForm |= SysCons.OS_IDX_MACINTOSH;
        }

        // Unix
        if (this.ck_PfUnx.isSelected())
        {
            platForm |= SysCons.OS_IDX_UNIX;
        }

        // Linux
        if (this.ck_PfLnx.isSelected())
        {
            platForm |= SysCons.OS_IDX_LINUX;
        }

        // 移动平台
        if (this.ck_PfMbl.isSelected())
        {
            platForm |= SysCons.OS_IDX_MOBILE;
        }

        // 其它平台
        if (this.ck_PfSpc.isSelected())
        {
            platForm |= SysCons.OS_IDX_UNKNOWN;
        }

        return platForm;
    }

    /**
     * 系统架构
     */
    private int encodeArchBits()
    {
        int archBits = 0;

        // 64位
        if (this.ck_Ab64.isSelected())
        {
            archBits |= SysCons.BITS_IDX_64;
        }

        // 32位
        if (this.ck_Ab32.isSelected())
        {
            archBits |= SysCons.BITS_IDX_32;
        }

        // 16位
        if (this.ck_Ab16.isSelected())
        {
            archBits |= SysCons.BITS_IDX_16;
        }

        // 其它
        if (this.ck_Ab00.isSelected())
        {
            archBits |= SysCons.BITS_IDX_00;
        }

        return archBits;
    }

    /**
     * 国别信息处理
     * 
     * @return
     */
    private boolean newNatn()
    {
        // 用户交互数据
        if (!isCreate)
        {
            K2SV1S kv = (K2SV1S)this.cb_UserComb.getSelectedItem();
            if (kv == null)
            {
                return false;
            }
            userMeta.setNatnIndx(kv.getK1());
        }
        else
        {
            isCreate = false;
            this.cb_UserComb.setEditable(isCreate);
        }
        return true;
    }

    /**
     * 公司数据处理
     * 
     * @return
     */
    private boolean newCorp()
    {
        // 用户交互数据
        if (!isCreate)
        {
            K2SV1S kv = (K2SV1S)this.cb_UserComb.getSelectedItem();
            if (kv == null)
            {
                return false;
            }
            userMeta.setCorpIndx(kv.getK1());
        }
        else
        {
            // 新增人员数据
            CorpUserData corpMeta = new CorpUserData();
            corpMeta.wInit();
            String corpLcNm = (String)this.cb_UserComb.getEditor().getItem();
            if (!corpMeta.setCorpLcNm(corpLcNm))
            {
                MesgUtil.showMessageDialog(me_MainSoft.getStepForm(), corpMeta.getErrMsg());
                this.cb_UserComb.requestFocus();
                return false;
            }
            corpMeta.setNatnIndx(userMeta.getNatnIndx());

            DBAccess dba = new DBAccess();
            try
            {
                if (!dba.wInit())
                {
                    return false;
                }

                DA0008.updateCorpMeta(dba, corpMeta);
                userMeta.setCorpIndx(corpMeta.getCorpIndx());
            }
            catch(SQLException exp)
            {
                LogUtil.exception(exp);
                return false;
            }
            finally
            {
                dba.closeConnection();
            }

            isCreate = false;
            this.cb_UserComb.setEditable(isCreate);
        }
        return true;
    }

    /**
     * 软件数据处理
     * 
     * @return
     */
    private boolean newSoft()
    {
        if (!isCreate)
        {
            K2SV1S kv = (K2SV1S)this.cb_UserComb.getSelectedItem();
            if (kv == null)
            {
                return false;
            }
            userMeta.setSoftIndx(kv.getK1());
        }
        else
        {
            // 新增人员数据
            SoftUserData softMeta = new SoftUserData();
            softMeta.wInit();
            String softName = (String)this.cb_UserComb.getEditor().getItem();
            if (!softMeta.setSoftName(softName))
            {
                MesgUtil.showMessageDialog(me_MainSoft.getStepForm(), softMeta.getErrMsg());
                this.cb_UserComb.requestFocus();
                return false;
            }
            softMeta.setCorpIndx(userMeta.getCorpIndx());

            DBAccess dba = new DBAccess();
            try
            {
                if (!dba.wInit())
                {
                    return false;
                }

                DA0008.updateSoftMeta(dba, softMeta);
                userMeta.setSoftIndx(softMeta.getSoftIndx());
            }
            catch(SQLException exp)
            {
                LogUtil.exception(exp);
                return false;
            }
            finally
            {
                dba.closeConnection();
            }

            isCreate = false;
            this.cb_UserComb.setEditable(isCreate);
        }
        return true;
    }

    /**
     * 文件数据处理
     * 
     * @return
     */
    private boolean newFile()
    {
        if (!isCreate)
        {
            K2SV1S kv = (K2SV1S)this.cb_UserComb.getSelectedItem();
            if (kv == null)
            {
                return false;
            }
            userMeta.setFileIndx(kv.getK1());
        }
        else
        {
            // 新增人员数据
            FileUserData fileMeta = new FileUserData();
            fileMeta.wInit();
            String idioMail = (String)this.cb_UserComb.getEditor().getItem();
            if (!fileMeta.setSignChar(idioMail))
            {
                MesgUtil.showMessageDialog(me_MainSoft.getStepForm(), fileMeta.getErrMsg());
                this.cb_UserComb.requestFocus();
                return false;
            }
            fileMeta.setSoftIndx(userMeta.getSoftIndx());

            DBAccess dba = new DBAccess();
            try
            {
                if (!dba.wInit())
                {
                    return false;
                }

                DA0008.updateFileMeta(dba, fileMeta);
                userMeta.setFileIndx(fileMeta.getFileIndx());
            }
            catch(SQLException exp)
            {
                LogUtil.exception(exp);
                return false;
            }
            finally
            {
                dba.closeConnection();
            }

            isCreate = false;
            this.cb_UserComb.setEditable(isCreate);
        }
        return true;
    }

    /**
     * 类别数据处理
     * 
     * @return
     */
    private boolean newType()
    {
        // 用户交互数据
        if (!isCreate)
        {
            K1SV2S kv = (K1SV2S)this.cb_UserComb.getSelectedItem();
            if (kv == null)
            {
                return false;
            }
            userMeta.setTypeIndx(kv.getK());
        }
        else
        {
            // 新增类别数据
            TypeUserData typeMeta = new TypeUserData();
            typeMeta.wInit();
            String typeName = (String)this.cb_UserComb.getEditor().getItem();
            typeMeta.setSystemId(PrpCons.P3010000_I);
            if (!typeMeta.setTypeName(typeName))
            {
                MesgUtil.showMessageDialog(me_MainSoft.getStepForm(), typeMeta.getErrMsg());
                this.cb_UserComb.requestFocus();
                return false;
            }

            DBAccess dba = new DBAccess();
            try
            {
                if (!dba.wInit())
                {
                    return false;
                }

                DC0008.updateTypeMeta(dba, typeMeta);
                userMeta.setTypeIndx(typeMeta.getTypeIndx());
            }
            catch(SQLException exp)
            {
                LogUtil.exception(exp);
                return false;
            }
            finally
            {
                dba.closeConnection();
            }

            isCreate = false;
            this.cb_UserComb.setEditable(isCreate);
        }
        return true;
    }

    /**
     * 人员信息处理
     * 
     * @return
     */
    private boolean newIdio()
    {
        // 用户交互数据
        if (!isCreate)
        {
            K2SV1S kv = (K2SV1S)this.cb_UserComb.getSelectedItem();
            if (kv == null)
            {
                return false;
            }
            userMeta.setIdioIndx(kv.getK1());
        }
        else
        {
            // 新增人员数据
            IdioUserData idioMeta = new IdioUserData();
            idioMeta.wInit();
            String idioMail = (String)this.cb_UserComb.getEditor().getItem();
            if (!idioMeta.setIdioMail(idioMail))
            {
                MesgUtil.showMessageDialog(me_MainSoft.getStepForm(), idioMeta.getErrMsg());
                this.cb_UserComb.requestFocus();
                return false;
            }

            DBAccess dba = new DBAccess();
            try
            {
                if (!dba.wInit())
                {
                    return false;
                }

                DA0008.updateIdioMeta(dba, idioMeta);
                userMeta.setIdioIndx(idioMeta.getIdioIndx());
            }
            catch(SQLException exp)
            {
                LogUtil.exception(exp);
                return false;
            }
            finally
            {
                dba.closeConnection();
            }

            isCreate = false;
            this.cb_UserComb.setEditable(isCreate);
        }

        return true;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 变量定义区域
    // ////////////////////////////////////////////////////////////////////////
    private javax.swing.JButton    bt_ExitButn;
    private javax.swing.JButton    bt_LastButn;
    private javax.swing.JButton    bt_NextButn;
    private javax.swing.JButton    bt_UserButn;
    private javax.swing.JComboBox  cb_UserComb;
    private javax.swing.JLabel     lb_UserLabl;
    private javax.swing.JTextArea  ta_NoteInfo;
    private javax.swing.JTextField tf_UserFild;
    private javax.swing.JCheckBox  ck_PfAll;
    private javax.swing.JCheckBox  ck_PfLnx;
    private javax.swing.JCheckBox  ck_PfMac;
    private javax.swing.JCheckBox  ck_PfMbl;
    private javax.swing.JCheckBox  ck_PfSpc;
    private javax.swing.JCheckBox  ck_PfUnx;
    private javax.swing.JCheckBox  ck_PfWin;
    private javax.swing.JCheckBox  ck_Ab00;
    private javax.swing.JCheckBox  ck_Ab16;
    private javax.swing.JCheckBox  ck_Ab32;
    private javax.swing.JCheckBox  ck_Ab64;
    private javax.swing.JTextArea  ta_IdioMark;
}
