/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3010000.v;

import java.sql.SQLException;
import java.util.EventObject;
import java.util.List;

import javax.swing.DefaultComboBoxModel;

import rmp.bean.K2SV1S;
import rmp.face.WBackCall;
import rmp.io.db.DBAccess;
import rmp.prp.aide.P3010000.P3010000;
import rmp.prp.aide.P3010000.b.ArchBean;
import rmp.prp.aide.P3010000.b.K2SV2S;
import rmp.prp.aide.P3010000.b.PlatBean;
import rmp.prp.aide.P3010000.d.DA8000;
import rmp.prp.aide.P3010000.m.CorpUserData;
import rmp.prp.aide.P3010000.m.ExtsUserData;
import rmp.prp.aide.P3010000.m.FileUserData;
import rmp.prp.aide.P3010000.m.IdioUserData;
import rmp.prp.aide.P3010000.m.SoftUserData;
import rmp.prp.aide.P3010000.m.TypeUserData;
import rmp.util.BeanUtil;
import rmp.util.LogUtil;
import rmp.util.MesgUtil;
import rmp.util.StringUtil;
import cons.id.PrpCons;
import cons.prp.aide.P3010000.ConstUI;
import cons.prp.aide.P3010000.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 后缀解析向导模式面板
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class StepPanel extends javax.swing.JPanel implements WBackCall
{
    /** 是否新增数据 */
    private boolean isCreate = false;
    /** 当前进行的操作步骤 */
    private int currStep = 0;
    /** 下拉列表模型 */
    private DefaultComboBoxModel cm_UserComb = null;
    /** 用户交互数据 */
    private ExtsUserData userMeta = null;

    /**
     * 
     */
    public StepPanel(P3010000 soft)
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WBackCall#wAction(java.util.EventObject, java.lang.Object,
     *      java.lang.String)
     */
    @Override
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
        BeanUtil.setWText(bt_UserButn, P3010000.getMesg(LangRes.STEP_BUTN_TEXT_INSTBUTN));
        BeanUtil.setWTips(bt_UserButn, P3010000.getMesg(LangRes.STEP_BUTN_TIPS_INSTBUTN));

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
            DA8000.updateExtsMeta(dba, extsMeta);

            return true;
        }
        catch (SQLException exp)
        {
            LogUtil.exception(exp);
            String mesg;
            if (exp.getErrorCode() == -104)
            {
                mesg = P3010000.getMesg(LangRes.MESG_UPDT_0006);
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
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_ExitButn))).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                javax.swing.GroupLayout.Alignment.TRAILING,
                layout.createSequentialGroup().addContainerGap().addComponent(ta_NoteInfo,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED, 13, Short.MAX_VALUE).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(bt_ExitButn).addComponent(bt_NextButn).addComponent(bt_LastButn)).addContainerGap()));
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
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_ExitButn))).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addComponent(ta_NoteInfo,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addGap(18, 18, 18).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_UserLabl).addComponent(tf_UserFild, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED, 56, Short.MAX_VALUE).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(bt_ExitButn).addComponent(bt_NextButn).addComponent(bt_LastButn)).addContainerGap()));
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
                Short.MAX_VALUE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_UserButn, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addGroup(
                javax.swing.GroupLayout.Alignment.TRAILING,
                layout.createSequentialGroup().addComponent(bt_LastButn).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_NextButn).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_ExitButn))).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addComponent(ta_NoteInfo,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addGap(18, 18, 18).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_UserLabl).addComponent(bt_UserButn, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(
                cb_UserComb, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED, 56, Short.MAX_VALUE).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(bt_ExitButn).addComponent(bt_NextButn).addComponent(bt_LastButn)).addContainerGap()));
    }

    /**
     * 应用平台面板初始化
     */
    private void icd()
    {
        ta_NoteInfo.setRows(3);
    }

    /**
     * 系统架构面板初始化
     */
    private void ice()
    {
        ta_NoteInfo.setRows(3);
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
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_ExitButn))).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addComponent(ta_NoteInfo,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_UserLabl).addComponent(sp_IdioMark, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED, 19, Short.MAX_VALUE).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(bt_ExitButn).addComponent(bt_NextButn).addComponent(bt_LastButn)).addContainerGap()));
    }

    /**
     * 欢迎使用向导
     */
    private void ita()
    {
        this.ta_NoteInfo.setText(P3010000.getMesg(LangRes.STEP_OTHR_STEP_0001));
        BeanUtil.setWText(bt_NextButn, P3010000.getMesg(LangRes.STEP_BUTN_TEXT_STATBUTN));
        BeanUtil.setWTips(bt_NextButn, P3010000.getMesg(LangRes.STEP_BUTN_TIPS_STATBUTN));
        BeanUtil.setWText(bt_ExitButn, P3010000.getMesg(LangRes.STEP_BUTN_TEXT_STOPBUTN));
        BeanUtil.setWTips(bt_ExitButn, P3010000.getMesg(LangRes.STEP_BUTN_TIPS_STOPBUTN));
    }

    /**
     * 输入后缀名称
     */
    private void itb()
    {
        this.ta_NoteInfo.setText(P3010000.getMesg(LangRes.STEP_OTHR_STEP_0002));
        BeanUtil.setWText(lb_UserLabl, P3010000.getMesg(LangRes.EXTS_LABL_TEXT_EXTSNAME));
        BeanUtil.setWText(bt_NextButn, P3010000.getMesg(LangRes.STEP_BUTN_TEXT_NEXTBUTN));
        BeanUtil.setWTips(bt_NextButn, P3010000.getMesg(LangRes.STEP_BUTN_TIPS_NEXTBUTN));
        BeanUtil.setWText(bt_ExitButn, P3010000.getMesg(LangRes.STEP_BUTN_TEXT_STOPBUTN));
        BeanUtil.setWTips(bt_ExitButn, P3010000.getMesg(LangRes.STEP_BUTN_TIPS_STOPBUTN));
    }

    /**
     * 选择国别信息
     */
    private void itc()
    {
        this.ta_NoteInfo.setText(P3010000.getMesg(LangRes.STEP_OTHR_STEP_0003));
        BeanUtil.setWText(lb_UserLabl, P3010000.getMesg(LangRes.EXTS_LABL_TEXT_NATNINDX));
    }

    /**
     * 选择公司信息
     */
    private void itd()
    {
        this.ta_NoteInfo.setText(P3010000.getMesg(LangRes.STEP_OTHR_STEP_0004));
        BeanUtil.setWText(lb_UserLabl, P3010000.getMesg(LangRes.EXTS_LABL_TEXT_CORPLCNM));
    }

    /**
     * 选择软件信息
     */
    private void ite()
    {
        this.ta_NoteInfo.setText(P3010000.getMesg(LangRes.STEP_OTHR_STEP_0005));
        BeanUtil.setWText(lb_UserLabl, P3010000.getMesg(LangRes.EXTS_LABL_TEXT_SOFTNAME));
    }

    /**
     * 选择文件信息
     */
    private void itf()
    {
        this.ta_NoteInfo.setText(P3010000.getMesg(LangRes.STEP_OTHR_STEP_0006));
        BeanUtil.setWText(lb_UserLabl, P3010000.getMesg(LangRes.EXTS_LABL_TEXT_SIGNCHAR));
    }

    /**
     * 选择类别信息
     */
    private void itg()
    {
        this.ta_NoteInfo.setText(P3010000.getMesg(LangRes.STEP_OTHR_STEP_0007));
        BeanUtil.setWText(lb_UserLabl, P3010000.getMesg(LangRes.EXTS_LABL_TEXT_EXTSTYPE));
    }

    /**
     * 选择人员信息
     */
    private void ith()
    {
        this.ta_NoteInfo.setText(P3010000.getMesg(LangRes.STEP_OTHR_STEP_0008));
        BeanUtil.setWText(lb_UserLabl, P3010000.getMesg(LangRes.EXTS_LABL_TEXT_IDIOMAIL));
    }

    /**
     * 选择应用平台
     */
    private void iti()
    {
        this.ta_NoteInfo.setText(P3010000.getMesg(LangRes.STEP_OTHR_STEP_0009));
        BeanUtil.setWText(lb_UserLabl, P3010000.getMesg(LangRes.EXTS_LABL_TEXT_PLATFORM));
    }

    /**
     * 选择系统架构
     */
    private void itj()
    {
        this.ta_NoteInfo.setText(P3010000.getMesg(LangRes.STEP_OTHR_STEP_0010));
        BeanUtil.setWText(lb_UserLabl, P3010000.getMesg(LangRes.EXTS_LABL_TEXT_ARCHBITS));
    }

    /**
     * 输入相关说明
     */
    private void itk()
    {
        this.ta_NoteInfo.setText(P3010000.getMesg(LangRes.STEP_OTHR_STEP_0011));
        BeanUtil.setWText(lb_UserLabl, P3010000.getMesg(LangRes.EXTS_LABL_TEXT_IDIOMARK));
    }

    /**
     * 数据添加成功
     */
    private void itl()
    {
        String mesg = StringUtil.format(LangRes.STEP_OTHR_STEP_0012, userMeta.getExtsName());
        this.ta_NoteInfo.setText(mesg);
        BeanUtil.setWText(bt_ExitButn, P3010000.getMesg(LangRes.STEP_BUTN_TEXT_EXITBUTN));
        BeanUtil.setWTips(bt_ExitButn, P3010000.getMesg(LangRes.STEP_BUTN_TEXT_EXITBUTN));
        BeanUtil.setWText(bt_NextButn, P3010000.getMesg(LangRes.STEP_BUTN_TEXT_MOREBUTN));
        BeanUtil.setWTips(bt_NextButn, P3010000.getMesg(LangRes.STEP_BUTN_TEXT_MOREBUTN));
    }

    // ////////////////////////////////////////////////////////////////////////
    // 数据预备区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 后缀名称
     */
    private void ipa()
    {
        userMeta.wInit();
        this.tf_UserFild.setText("");
    }

    /**
     * 国别信息
     */
    private void ipb()
    {
        cm_UserComb.removeAllElements();

        DBAccess dba = new DBAccess();

        // 数据查寻
        List<K2SV2S> natnList = null;
        try
        {
            if (!dba.wInit())
            {
                return;
            }

            natnList = DA8000.selectNatnMetaList(dba);
        }
        catch (SQLException exp)
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
    private void ipc()
    {
        cm_UserComb.removeAllElements();

        DBAccess dba = new DBAccess();

        // 数据查寻
        List<K2SV2S> corpList = null;
        try
        {
            if (!dba.wInit())
            {
                return;
            }

            corpList = DA8000.selectCorpMetaList(dba, userMeta.getNatnIndx(), null);
        }
        catch (SQLException exp)
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
    private void ipd()
    {
        cm_UserComb.removeAllElements();

        DBAccess dba = new DBAccess();

        // 数据查寻
        List<K2SV2S> softList = null;
        try
        {
            if (!dba.wInit())
            {
                return;
            }

            softList = DA8000.selectSoftMetaList(dba, userMeta.getCorpIndx(), null);
        }
        catch (SQLException exp)
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
    private void ipe()
    {
        cm_UserComb.removeAllElements();

        DBAccess dba = new DBAccess();

        // 数据查寻
        List<K2SV2S> fileList = null;
        try
        {
            if (!dba.wInit())
            {
                return;
            }

            fileList = DA8000.selectFileMetaList(dba, userMeta.getSoftIndx(), null);
        }
        catch (SQLException exp)
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
    private void ipf()
    {
        cm_UserComb.removeAllElements();

        DBAccess dba = new DBAccess();

        // 数据查寻
        List<K2SV2S> typeList = null;
        try
        {
            if (!dba.wInit())
            {
                return;
            }

            typeList = DA8000.selectTypeMetaList(dba);
        }
        catch (SQLException exp)
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
    private void ipg()
    {
        cm_UserComb.removeAllElements();

        DBAccess dba = new DBAccess();

        // 数据查寻
        List<K2SV2S> idioList = null;
        try
        {
            if (!dba.wInit())
            {
                return;
            }

            idioList = DA8000.selectIdioMetaList(dba, "");
        }
        catch (SQLException exp)
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
    private void iph()
    {
        pb_PlatForm = new PlatBean();
        pb_PlatForm.wInit();
    }

    /**
     * 系统架构
     */
    private void ipi()
    {
        ab_ArchBits = new ArchBean();
        ab_ArchBits.wInit();
    }

    /**
     * 个人说明
     */
    private void ipj()
    {
        this.ta_IdioMark.setText("");
    }

    /**
     * 提示成功
     */
    private void ipk()
    {
    }

    // ////////////////////////////////////////////////////////////////////////
    // 事件处理区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @param evt
     */
    private void bt_ExitButn_Handler(java.awt.event.ActionEvent evt)
    {
        // Util.getStepForm().setVisible(false);
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
                ipa();
            }
            break;

            // 后缀面板，显示国别列表面板
            case ConstUI.STEP_EXTS:
            {
                // 用户交互数据
                userMeta.wInit();
                if (!userMeta.setExtsName(this.tf_UserFild.getText()))
                {
                    MesgUtil.showMessageDialog(this, userMeta.getErrMsg());
                    this.tf_UserFild.requestFocus();
                    return;
                }

                // 显示下一步面板
                this.removeAll();
                bt_LastButn.setVisible(true);
                icc();
                itc();
                ipb();
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
                ipc();
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
                ipd();
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
                ipe();
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
                ipf();
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
                ipg();
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
                iph();
            }
            break;

            // 平台面板，显示系统架构面板
            case ConstUI.STEP_PLAT:
            {
                // 用户交互数据
                userMeta.setPlatIndx(pb_PlatForm.encodePlatForm());

                // 显示下一步面板
                this.removeAll();
                ice();
                itj();
                ipi();
            }
            break;

            // 架构面板，显示个人说明面板
            case ConstUI.STEP_ARCH:
            {
                // 用户交互数据
                userMeta.setArchBits(ab_ArchBits.encodeArchBits());

                // 显示下一步面板
                this.removeAll();
                bt_NextButn.setVisible(true);
                icf();
                itk();
                ipj();
            }
            break;

            // 说明面板，显示添加成功面板
            case ConstUI.STEP_MARK:
            {
                // 用户交互数据
                if (!userMeta.setIdioMark(this.ta_IdioMark.getText()))
                {
                    MesgUtil.showMessageDialog(this, userMeta.getErrMsg());
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
                ipk();
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
                ipa();
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
                ipb();
                break;

            // 直属软件，显示所属公司面板
            case ConstUI.STEP_SOFT:
                itd();
                ipc();
                break;

            // 文档格式，显示直属软件面板
            case ConstUI.STEP_FILE:
                ite();
                ipd();
                break;

            // 所属类别，显示文档格式面板
            case ConstUI.STEP_TYPE:
                itf();
                ipe();
                break;

            // 特别致谢，显示所属类别面板
            case ConstUI.STEP_IDIO:
                this.removeAll();
                itg();
                ipf();
                break;

            // 应用平台，显示特别致谢面板
            case ConstUI.STEP_PLAT:
                this.removeAll();
                icc();
                ith();
                ipg();
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
     * 国别信息处理
     * 
     * @return
     */
    private boolean newNatn()
    {
        // 用户交互数据
        if (!isCreate)
        {
            K2SV1S kv = (K2SV1S) this.cb_UserComb.getSelectedItem();
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
            K2SV1S kv = (K2SV1S) this.cb_UserComb.getSelectedItem();
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
            String corpLcNm = (String) this.cb_UserComb.getEditor().getItem();
            if (!corpMeta.setCorpLcNm(corpLcNm))
            {
                MesgUtil.showMessageDialog(this, corpMeta.getErrMsg());
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

                DA8000.updateCorpMeta(dba, corpMeta);
                userMeta.setCorpIndx(corpMeta.getCorpIndx());
            }
            catch (SQLException exp)
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
            K2SV1S kv = (K2SV1S) this.cb_UserComb.getSelectedItem();
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
            String softName = (String) this.cb_UserComb.getEditor().getItem();
            if (!softMeta.setSoftName(softName))
            {
                MesgUtil.showMessageDialog(this, softMeta.getErrMsg());
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

                DA8000.updateSoftMeta(dba, softMeta);
                userMeta.setSoftIndx(softMeta.getSoftIndx());
            }
            catch (SQLException exp)
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
            K2SV1S kv = (K2SV1S) this.cb_UserComb.getSelectedItem();
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
            String idioMail = (String) this.cb_UserComb.getEditor().getItem();
            if (!fileMeta.setSignChar(idioMail))
            {
                MesgUtil.showMessageDialog(this, fileMeta.getErrMsg());
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

                DA8000.updateFileMeta(dba, fileMeta);
                userMeta.setFileIndx(fileMeta.getFileIndx());
            }
            catch (SQLException exp)
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
            K2SV2S kv = (K2SV2S) this.cb_UserComb.getSelectedItem();
            if (kv == null)
            {
                return false;
            }
            userMeta.setTypeIndx(kv.getK1());
        }
        else
        {
            // 新增类别数据
            TypeUserData typeMeta = new TypeUserData();
            typeMeta.wInit();
            String typeName = (String) this.cb_UserComb.getEditor().getItem();
            typeMeta.setSystemId(PrpCons.P3010000_I);
            if (!typeMeta.setTypeName(typeName))
            {
                MesgUtil.showMessageDialog(this, typeMeta.getErrMsg());
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

                DA8000.updateTypeMeta(dba, typeMeta);
                userMeta.setTypeIndx(typeMeta.getTypeIndx());
            }
            catch (SQLException exp)
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
            K2SV1S kv = (K2SV1S) this.cb_UserComb.getSelectedItem();
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
            String idioMail = (String) this.cb_UserComb.getEditor().getItem();
            if (!idioMeta.setIdioMail(idioMail))
            {
                MesgUtil.showMessageDialog(this, idioMeta.getErrMsg());
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

                DA8000.updateIdioMeta(dba, idioMeta);
                userMeta.setIdioIndx(idioMeta.getIdioIndx());
            }
            catch (SQLException exp)
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
    private javax.swing.JButton bt_ExitButn;
    private javax.swing.JButton bt_LastButn;
    private javax.swing.JButton bt_NextButn;
    private javax.swing.JButton bt_UserButn;
    private javax.swing.JComboBox cb_UserComb;
    private javax.swing.JLabel lb_UserLabl;
    private javax.swing.JTextArea ta_NoteInfo;
    private javax.swing.JTextField tf_UserFild;
    private PlatBean pb_PlatForm;
    private ArchBean ab_ArchBits;
    private javax.swing.JTextArea ta_IdioMark;
    /**  */
    private static final long serialVersionUID = -8785621459283570960L;
}
