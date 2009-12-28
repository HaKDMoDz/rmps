/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3050000.v;

import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.security.MessageDigest;
import java.security.SecureRandom;
import java.util.zip.CRC32;
import java.util.zip.Checksum;

import javax.crypto.Cipher;
import javax.swing.DefaultComboBoxModel;
import javax.swing.DefaultListModel;

import rmp.bean.CellRender;
import rmp.bean.K1SV2S;
import rmp.prp.aide.P3050000.P3050000;
import rmp.prp.aide.P3050000.b.ItemBean;
import rmp.prp.aide.P3050000.m.CRC64;
import rmp.prp.aide.P3050000.m.SecureKey;
import rmp.util.BeanUtil;
import rmp.util.MesgUtil;
import rmp.util.StringUtil;

import com.amonsoft.rmps.prp.v.IView;
import com.amonsoft.util.CharUtil;
import com.amonsoft.util.LogUtil;

import cons.prp.aide.P3050000.ConstUI;
import cons.prp.aide.P3050000.LangRes;

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
public class NormPanel extends javax.swing.JPanel implements IView
{
    /** 密码类别 */
    private DefaultComboBoxModel cm_CipherTp;
    /** 密码名称 */
    private DefaultComboBoxModel cm_CipherNm;
    /** 明文文件列表 */
    private DefaultListModel lm_SrcfList;
    /** 密文文件列表 */
    private DefaultListModel lm_DstfList;
    /** 用户当前选择对象 */
    private K1SV2S kv_currItem;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @param soft
     */
    public NormPanel(P3050000 soft)
    {
    }

    // ////////////////////////////////////////////////////////////////////////
    // 接口实现区域
    // ////////////////////////////////////////////////////////////////////////
    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#wInit()
     */
    @Override
    public boolean wInit()
    {
        // 组合框数据模型
        cm_CipherNm = new DefaultComboBoxModel();
        cm_CipherTp = new DefaultComboBoxModel();

        // 列表数据模型
        lm_SrcfList = new DefaultListModel();
        lm_DstfList = new DefaultListModel();

        ica();
        icb();
        icc();
        icd();
        ice();
        ita();
        itb();

        return true;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面初始化区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 操作模式初始化
     */
    private void ica()
    {
        pl_ModePanel = new javax.swing.JPanel();
        javax.swing.ButtonGroup bg_UserMode = new javax.swing.ButtonGroup();
        rb_FileMode = new javax.swing.JRadioButton();
        rb_TextMode = new javax.swing.JRadioButton();

        pl_ModePanel.setLayout(new java.awt.FlowLayout(java.awt.FlowLayout.CENTER, 5, 0));

        bg_UserMode.add(rb_FileMode);
        rb_FileMode.setMnemonic('F');
        rb_FileMode.setSelected(true);
        rb_FileMode.setText("文件模式(F)");
        rb_FileMode.setToolTipText("文件模式");
        rb_FileMode.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        rb_FileMode.setMargin(new java.awt.Insets(0, 0, 0, 0));
        pl_ModePanel.add(rb_FileMode);
        rb_FileMode.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                rb_FileMode_Handler(evt);
            }
        });

        bg_UserMode.add(rb_TextMode);
        rb_TextMode.setMnemonic('C');
        rb_TextMode.setText("文本模式(C)");
        rb_TextMode.setToolTipText("文本模式");
        rb_TextMode.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        rb_TextMode.setMargin(new java.awt.Insets(0, 0, 0, 0));
        pl_ModePanel.add(rb_TextMode);
        rb_TextMode.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                rb_TextMode_Handler(evt);
            }
        });
    }

    /**
     * 用户口令初始化
     */
    private void icb()
    {
        pl_UserPanel = new javax.swing.JPanel();
        pl_UserPanel.setLayout(new java.awt.GridBagLayout());

        lb_UserPwds = new javax.swing.JLabel();
        lb_UserPwds.setText("口令(P)");
        lb_UserPwds.setDisplayedMnemonic('P');
        pl_UserPanel.add(lb_UserPwds, new java.awt.GridBagConstraints());

        tf_UserPwds = new javax.swing.JTextField();
        tf_UserPwds.setEnabled(false);
        lb_UserPwds.setLabelFor(tf_UserPwds);
        java.awt.GridBagConstraints gbc = new java.awt.GridBagConstraints();
        gbc.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gbc.weightx = 1.0;
        pl_UserPanel.add(tf_UserPwds, gbc);

        ck_NoRepeat = new javax.swing.JCheckBox();
        ck_NoRepeat.setMnemonic('R');
        ck_NoRepeat.setText("不可重复(R)");
        ck_NoRepeat.setVisible(false);
        pl_UserPanel.add(ck_NoRepeat, new java.awt.GridBagConstraints());
    }

    /**
     * 文件面板初始化
     */
    private void icc()
    {
        pl_FilePanel = new javax.swing.JPanel();
        lb_SrcfList = new javax.swing.JLabel();
        bt_DelFiles = new javax.swing.JButton();
        bt_AddFiles = new javax.swing.JButton();
        javax.swing.JScrollPane sp_SrcfList = new javax.swing.JScrollPane();
        ls_SrcfList = new javax.swing.JList();
        lb_DstfList = new javax.swing.JLabel();
        javax.swing.JScrollPane sp_DstfList = new javax.swing.JScrollPane();
        ls_DstfList = new javax.swing.JList();

        lb_SrcfList.setText("\u660e\u6587(S)");

        bt_DelFiles.setMnemonic('D');
        bt_DelFiles.setText("-");
        bt_DelFiles.setToolTipText("\u4ece\u5217\u8868\u4e2d\u79fb\u9664\u9009\u62e9\u7684\u6587\u4ef6");
        bt_DelFiles.setFocusable(false);
        bt_DelFiles.setMargin(new java.awt.Insets(1, 1, 1, 1));
        bt_DelFiles.setPreferredSize(new java.awt.Dimension(18, 18));
        bt_DelFiles.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_DelFiles_Handler(evt);
            }
        });

        bt_AddFiles.setMnemonic('A');
        bt_AddFiles.setText("+");
        bt_AddFiles.setToolTipText("\u6dfb\u52a0\u66f4\u591a\u7684\u6587\u4ef6\u5230\u5217\u8868");
        bt_AddFiles.setFocusable(false);
        bt_AddFiles.setMargin(new java.awt.Insets(1, 1, 1, 1));
        bt_AddFiles.setPreferredSize(new java.awt.Dimension(18, 18));
        bt_AddFiles.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_AddFiles_Handler(evt);
            }
        });

        CellRender cr = new CellRender();
        ls_SrcfList.setCellRenderer(cr);
        ls_SrcfList.setModel(lm_SrcfList);
        ls_SrcfList.setSelectionMode(javax.swing.ListSelectionModel.SINGLE_SELECTION);
        ls_SrcfList.setVisibleRowCount(5);
        sp_SrcfList.setViewportView(ls_SrcfList);

        lb_DstfList.setText("\u5bc6\u6587(D)");

        ls_DstfList.setCellRenderer(cr);
        ls_DstfList.setModel(lm_DstfList);
        ls_DstfList.setSelectionMode(javax.swing.ListSelectionModel.SINGLE_SELECTION);
        ls_DstfList.setVisibleRowCount(5);
        sp_DstfList.setViewportView(ls_DstfList);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(pl_FilePanel);
        pl_FilePanel.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addComponent(lb_SrcfList).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 116, Short.MAX_VALUE).addComponent(bt_AddFiles,
                        javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_DelFiles, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                        javax.swing.GroupLayout.PREFERRED_SIZE)).addComponent(sp_SrcfList, javax.swing.GroupLayout.DEFAULT_SIZE, 200, Short.MAX_VALUE).addGroup(
                layout.createSequentialGroup().addComponent(lb_DstfList).addContainerGap()).addComponent(sp_DstfList, javax.swing.GroupLayout.DEFAULT_SIZE, 200, Short.MAX_VALUE));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_SrcfList).addComponent(bt_DelFiles, javax.swing.GroupLayout.PREFERRED_SIZE,
                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(bt_AddFiles, javax.swing.GroupLayout.PREFERRED_SIZE,
                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(
                        sp_SrcfList, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addComponent(lb_DstfList).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(sp_DstfList,
                        javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)));
    }

    /**
     * 文本面板初始化
     */
    private void icd()
    {
        pl_TextPanel = new javax.swing.JPanel();
        lb_SrctArea = new javax.swing.JLabel();
        javax.swing.JScrollPane sp_SrctArea = new javax.swing.JScrollPane();
        ta_SrctArea = new javax.swing.JTextArea();
        lb_DsttArea = new javax.swing.JLabel();
        javax.swing.JScrollPane sp_DsttArea = new javax.swing.JScrollPane();
        ta_DsttArea = new javax.swing.JTextArea();

        lb_SrctArea.setDisplayedMnemonic('S');
        lb_SrctArea.setLabelFor(ta_SrctArea);
        lb_SrctArea.setText("\u660e\u6587(S)");

        ta_SrctArea.setColumns(20);
        ta_SrctArea.setLineWrap(true);
        ta_SrctArea.setRows(4);
        ta_SrctArea.setWrapStyleWord(true);
        sp_SrctArea.setViewportView(ta_SrctArea);

        lb_DsttArea.setDisplayedMnemonic('D');
        lb_DsttArea.setLabelFor(ta_DsttArea);
        lb_DsttArea.setText("\u5bc6\u6587(D)");
        lb_DsttArea.setToolTipText("\u52a0\u5bc6\u89e3\u5bc6\u7ed3\u679c\u6570\u636e");

        ta_DsttArea.setColumns(20);
        ta_DsttArea.setLineWrap(true);
        ta_DsttArea.setRows(4);
        ta_DsttArea.setWrapStyleWord(true);
        ta_DsttArea.setEditable(false);
        sp_DsttArea.setViewportView(ta_DsttArea);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(pl_TextPanel);
        pl_TextPanel.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addComponent(lb_SrctArea).addContainerGap(158, Short.MAX_VALUE)).addComponent(sp_SrctArea, javax.swing.GroupLayout.DEFAULT_SIZE, 200, Short.MAX_VALUE)
                .addGroup(layout.createSequentialGroup().addComponent(lb_DsttArea).addContainerGap()).addComponent(sp_DsttArea, javax.swing.GroupLayout.DEFAULT_SIZE, 200, Short.MAX_VALUE));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addComponent(lb_SrctArea).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(sp_SrctArea,
                        javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addComponent(lb_DsttArea).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(sp_DsttArea,
                        javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)));
    }

    /**
     * 正常面板初始化
     */
    private void ice()
    {
        cb_CipherTp = new javax.swing.JComboBox();
        cb_CipherNm = new javax.swing.JComboBox();
        javax.swing.JSeparator sp01 = new javax.swing.JSeparator();
        bt_DeCipher = new javax.swing.JButton();
        bt_EnCipher = new javax.swing.JButton();
        pb_ProcStat = new javax.swing.JProgressBar(0, 1 << ConstUI.DEF_STEP);
        pb_ProcStat.setVisible(false);
        cl_CardPanel = new java.awt.CardLayout();
        pl_CardPanel = new javax.swing.JPanel();
        pl_CardPanel.setLayout(cl_CardPanel);
        pl_CardPanel.add(ConstUI.NAME_FILE_PANEL, pl_FilePanel);
        pl_CardPanel.add(ConstUI.NAME_TEXT_PANEL, pl_TextPanel);
        CellRender cr = new CellRender();

        cb_CipherTp.setModel(cm_CipherTp);
        cb_CipherTp.setRenderer(cr);
        cb_CipherTp.setToolTipText("\u5bc6\u7801\u7b97\u6cd5\u7c7b\u578b");
        cb_CipherTp.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                cb_CipherTp_Handler(evt);
            }
        });

        cb_CipherNm.setModel(cm_CipherNm);
        cb_CipherNm.setRenderer(cr);
        cb_CipherNm.setToolTipText("\u5bc6\u7801\u7b97\u6cd5\u540d\u79f0");
        cb_CipherNm.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                cb_CipherNm_Handler(evt);
            }
        });

        bt_DeCipher.setMnemonic('D');
        bt_DeCipher.setText("\u89e3\u5bc6(D)");
        bt_DeCipher.setMargin(new java.awt.Insets(1, 7, 1, 7));
        bt_DeCipher.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_DeCipher_Handler(evt);
            }
        });

        bt_EnCipher.setMnemonic('E');
        bt_EnCipher.setText("\u52a0\u5bc6(E)");
        bt_EnCipher.setMargin(new java.awt.Insets(1, 7, 1, 7));
        bt_EnCipher.setVisible(false);
        bt_EnCipher.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_EnCipher_Handler(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(sp01, javax.swing.GroupLayout.DEFAULT_SIZE, 230, Short.MAX_VALUE).addComponent(pl_ModePanel,
                                javax.swing.GroupLayout.DEFAULT_SIZE, 230, Short.MAX_VALUE).addGroup(
                                layout.createSequentialGroup().addComponent(cb_CipherTp, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                                        javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(cb_CipherNm, 0, 100, Short.MAX_VALUE))
                                .addComponent(pl_UserPanel, javax.swing.GroupLayout.DEFAULT_SIZE, 230, Short.MAX_VALUE).addComponent(pl_CardPanel, javax.swing.GroupLayout.DEFAULT_SIZE, 230,
                                        Short.MAX_VALUE).addGroup(
                                        javax.swing.GroupLayout.Alignment.TRAILING,
                                        layout.createSequentialGroup().addComponent(pb_ProcStat, javax.swing.GroupLayout.DEFAULT_SIZE, 96, Short.MAX_VALUE).addPreferredGap(
                                                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_EnCipher).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                                .addComponent(bt_DeCipher))).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addComponent(pl_ModePanel, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                        javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(cb_CipherTp, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                                javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(cb_CipherNm, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                                javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(sp01, javax.swing.GroupLayout.PREFERRED_SIZE,
                        10, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(pl_UserPanel,
                        javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(pl_CardPanel, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                        javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING).addGroup(
                                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(bt_DeCipher).addComponent(bt_EnCipher)).addComponent(pb_ProcStat,
                                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addContainerGap()));
    }

    /**
     * 语言初始化
     */
    private void ita()
    {
        // 文件模式
        BeanUtil.setWText(rb_FileMode, P3050000.getMesg(LangRes.RBTN_TEXT_FILEMODE));
        BeanUtil.setWTips(rb_FileMode, P3050000.getMesg(LangRes.RBTN_TIPS_FILEMODE));

        // 文本模式
        BeanUtil.setWText(rb_TextMode, P3050000.getMesg(LangRes.RBTN_TEXT_TEXTMODE));
        BeanUtil.setWTips(rb_TextMode, P3050000.getMesg(LangRes.RBTN_TIPS_TEXTMODE));

        // 密码类别
        BeanUtil.setWTips(cb_CipherTp, P3050000.getMesg(LangRes.COMB_TIPS_CIPHERTP));

        // 密码名称
        BeanUtil.setWTips(cb_CipherNm, P3050000.getMesg(LangRes.COMB_TIPS_CIPHERNM));

        // 口令
        BeanUtil.setWText(lb_UserPwds, P3050000.getMesg(LangRes.LABL_TEXT_USERPWDS));
        BeanUtil.setWTips(lb_UserPwds, P3050000.getMesg(LangRes.LABL_TIPS_USERPWDS));

        BeanUtil.setWText(tf_UserPwds, P3050000.getMesg(LangRes.FILD_TEXT_USERPWDS));
        BeanUtil.setWTips(tf_UserPwds, P3050000.getMesg(LangRes.FILD_TIPS_USERPWDS));

        // 明文
        BeanUtil.setWText(lb_SrcfList, P3050000.getMesg(LangRes.LABL_TEXT_SRCFLIST));
        BeanUtil.setWTips(lb_SrcfList, P3050000.getMesg(LangRes.LABL_TIPS_SRCFLIST));

        BeanUtil.setWText(lb_SrctArea, P3050000.getMesg(LangRes.LABL_TEXT_SRCTAREA));
        BeanUtil.setWTips(lb_SrctArea, P3050000.getMesg(LangRes.LABL_TIPS_SRCTAREA));

        BeanUtil.setWTips(ls_SrcfList, P3050000.getMesg(LangRes.LIST_TIPS_SRCFLIST));
        BeanUtil.setWTips(ta_SrctArea, P3050000.getMesg(LangRes.AREA_TIPS_SRCTAREA));

        // 密文
        BeanUtil.setWText(lb_DstfList, P3050000.getMesg(LangRes.LABL_TEXT_DSTTLIST));
        BeanUtil.setWTips(lb_DstfList, P3050000.getMesg(LangRes.LABL_TIPS_DSTTLIST));

        BeanUtil.setWText(lb_DsttArea, P3050000.getMesg(LangRes.LABL_TEXT_DSTTAREA));
        BeanUtil.setWTips(lb_DsttArea, P3050000.getMesg(LangRes.LABL_TIPS_DSTTAREA));

        BeanUtil.setWTips(ls_DstfList, P3050000.getMesg(LangRes.LIST_TIPS_DSTFLIST));
        BeanUtil.setWTips(ta_DsttArea, P3050000.getMesg(LangRes.AREA_TIPS_DSTTAREA));

        // 加密
        BeanUtil.setWText(bt_EnCipher, P3050000.getMesg(LangRes.BUTN_TEXT_ENCIPHER));
        BeanUtil.setWTips(bt_EnCipher, P3050000.getMesg(LangRes.BUTN_TIPS_ENCIPHER));
    }

    /**
     * 数据初始化
     */
    private void itb()
    {
        // 密码类别
        cm_CipherTp.addElement(new K1SV2S(ConstUI.CIPHERTP_MD, P3050000.getMesg(LangRes.CIPHERTP_MD), ""));
        cm_CipherTp.addElement(new K1SV2S(ConstUI.CIPHERTP_CS, P3050000.getMesg(LangRes.CIPHERTP_CS), ""));
        cm_CipherTp.addElement(new K1SV2S(ConstUI.CIPHERTP_BC, P3050000.getMesg(LangRes.CIPHERTP_BC), ""));
        cm_CipherTp.addElement(new K1SV2S(ConstUI.CIPHERTP_SC, P3050000.getMesg(LangRes.CIPHERTP_SC), ""));
    }

    /**
     * 散列摘要算法初始化
     */
    private void itc()
    {
        cm_CipherNm.removeAllElements();

        String v1;
        String v2;
        String v3;

        v1 = P3050000.getMesg(LangRes.CIPHERNM_MD_TEXT_MD2);
        v2 = P3050000.getMesg(LangRes.CIPHERNM_MD_TIPS_MD2);
        v3 = ConstUI.CIPHERNM_MD_MD2;
        cm_CipherNm.addElement(new ItemBean(0, v1, v2, v3));

        v1 = P3050000.getMesg(LangRes.CIPHERNM_MD_TEXT_MD4);
        v2 = P3050000.getMesg(LangRes.CIPHERNM_MD_TIPS_MD4);
        v3 = ConstUI.CIPHERNM_MD_MD4;
        cm_CipherNm.addElement(new ItemBean(0, v1, v2, v3));

        v1 = P3050000.getMesg(LangRes.CIPHERNM_MD_TEXT_MD5);
        v2 = P3050000.getMesg(LangRes.CIPHERNM_MD_TIPS_MD5);
        v3 = ConstUI.CIPHERNM_MD_MD5;
        cm_CipherNm.addElement(new ItemBean(0, v1, v2, v3));

        v1 = P3050000.getMesg(LangRes.CIPHERNM_MD_TEXT_SHA1);
        v2 = P3050000.getMesg(LangRes.CIPHERNM_MD_TIPS_SHA1);
        v3 = ConstUI.CIPHERNM_MD_SHA1;
        cm_CipherNm.addElement(new ItemBean(0, v1, v2, v3));

        v1 = P3050000.getMesg(LangRes.CIPHERNM_MD_TEXT_SHA256);
        v2 = P3050000.getMesg(LangRes.CIPHERNM_MD_TIPS_SHA256);
        v3 = ConstUI.CIPHERNM_MD_SHA256;
        cm_CipherNm.addElement(new ItemBean(0, v1, v2, v3));

        v1 = P3050000.getMesg(LangRes.CIPHERNM_MD_TEXT_SHA384);
        v2 = P3050000.getMesg(LangRes.CIPHERNM_MD_TIPS_SHA384);
        v3 = ConstUI.CIPHERNM_MD_SHA384;
        cm_CipherNm.addElement(new ItemBean(0, v1, v2, v3));

        v1 = P3050000.getMesg(LangRes.CIPHERNM_MD_TEXT_SHA512);
        v2 = P3050000.getMesg(LangRes.CIPHERNM_MD_TIPS_SHA512);
        v3 = ConstUI.CIPHERNM_MD_SHA512;
        cm_CipherNm.addElement(new ItemBean(0, v1, v2, v3));

        v1 = P3050000.getMesg(LangRes.CIPHERNM_MD_TEXT_RIPEMD);
        v2 = P3050000.getMesg(LangRes.CIPHERNM_MD_TIPS_RIPEMD);
        v3 = ConstUI.CIPHERNM_MD_RIPEMD;
        cm_CipherNm.addElement(new ItemBean(0, v1, v2, v3));

        v1 = P3050000.getMesg(LangRes.CIPHERNM_MD_TEXT_RIPEMD128);
        v2 = P3050000.getMesg(LangRes.CIPHERNM_MD_TIPS_RIPEMD128);
        v3 = ConstUI.CIPHERNM_MD_RIPEMD128;
        cm_CipherNm.addElement(new ItemBean(0, v1, v2, v3));

        v1 = P3050000.getMesg(LangRes.CIPHERNM_MD_TEXT_RIPEMD160);
        v2 = P3050000.getMesg(LangRes.CIPHERNM_MD_TIPS_RIPEMD160);
        v3 = ConstUI.CIPHERNM_MD_RIPEMD160;
        cm_CipherNm.addElement(new ItemBean(0, v1, v2, v3));

        v1 = P3050000.getMesg(LangRes.CIPHERNM_MD_TEXT_TIGER);
        v2 = P3050000.getMesg(LangRes.CIPHERNM_MD_TIPS_TIGER);
        v3 = ConstUI.CIPHERNM_MD_TIGER;
        cm_CipherNm.addElement(new ItemBean(0, v1, v2, v3));

        // 按钮显示信息控制
        tf_UserPwds.setEnabled(false);
        bt_EnCipher.setVisible(false);
        BeanUtil.setWText(bt_DeCipher, P3050000.getMesg(LangRes.BUTN_TEXT_DODIGEST));
        BeanUtil.setWTips(bt_DeCipher, P3050000.getMesg(LangRes.BUTN_TIPS_DODIGEST));
    }

    /**
     * 奇偶校验
     */
    private void itd()
    {
        cm_CipherNm.removeAllElements();

        String v1;
        String v2;
        String v3;

        v1 = P3050000.getMesg(LangRes.CIPHERNM_CS_TEXT_CRC32);
        v2 = P3050000.getMesg(LangRes.CIPHERNM_CS_TIPS_CRC32);
        v3 = ConstUI.CIPHERNM_CRC_CRC32;
        cm_CipherNm.addElement(new ItemBean(0, v1, v2, v3));

        v1 = P3050000.getMesg(LangRes.CIPHERNM_CS_TEXT_CRC64);
        v2 = P3050000.getMesg(LangRes.CIPHERNM_CS_TIPS_CRC64);
        v3 = ConstUI.CIPHERNM_CRC_CRC64;
        cm_CipherNm.addElement(new ItemBean(0, v1, v2, v3));

        // 按钮显示信息控制
        tf_UserPwds.setEnabled(false);
        bt_EnCipher.setVisible(false);
        BeanUtil.setWText(bt_DeCipher, P3050000.getMesg(LangRes.BUTN_TEXT_DODIGEST));
        BeanUtil.setWTips(bt_DeCipher, P3050000.getMesg(LangRes.BUTN_TIPS_DODIGEST));
    }

    /**
     * 块加密算法初始化
     */
    private void ite()
    {
        cm_CipherNm.removeAllElements();

        String v1;
        String v2;
        String v3;

        v1 = P3050000.getMesg(LangRes.CIPHERNM_BC_TEXT_AES);
        v2 = P3050000.getMesg(LangRes.CIPHERNM_BC_TIPS_AES);
        v3 = ConstUI.CIPHERNM_BC_AES;
        cm_CipherNm.addElement(new ItemBean(ConstUI.KEY_SIZE_BC_AES, v1, v2, v3));

        // v1 = IDatasec.getMesg(LangRes.CIPHERNM_BC_TEXT_AESWRAP);
        // v2 = IDatasec.getMesg(LangRes.CIPHERNM_BC_TIPS_AESWRAP);
        // v3 = ConstUI.CIPHERNM_BC_AESWRAP;
        // cm_CipherNm.addElement(new ItemBean(ConstUI.KEY_SIZE_BC_AESWRAP, v1,
        // v2, v3));

        v1 = P3050000.getMesg(LangRes.CIPHERNM_BC_TEXT_BLOWFISH);
        v2 = P3050000.getMesg(LangRes.CIPHERNM_BC_TIPS_BLOWFISH);
        v3 = ConstUI.CIPHERNM_BC_BLOWFISH;
        cm_CipherNm.addElement(new ItemBean(ConstUI.KEY_SIZE_BC_BLOWFISH, v1, v2, v3));

        v1 = P3050000.getMesg(LangRes.CIPHERNM_BC_TEXT_DES);
        v2 = P3050000.getMesg(LangRes.CIPHERNM_BC_TIPS_DES);
        v3 = ConstUI.CIPHERNM_BC_DES;
        cm_CipherNm.addElement(new ItemBean(ConstUI.KEY_SIZE_BC_DES, v1, v2, v3));

        v1 = P3050000.getMesg(LangRes.CIPHERNM_BC_TEXT_DESEDE);
        v2 = P3050000.getMesg(LangRes.CIPHERNM_BC_TIPS_DESEDE);
        v3 = ConstUI.CIPHERNM_BC_DESEDE;
        cm_CipherNm.addElement(new ItemBean(ConstUI.KEY_SIZE_BC_DESEDE, v1, v2, v3));

        // v1 = IDatasec.getMesg(LangRes.CIPHERNM_BC_TEXT_DESEDEWRAP);
        // v2 = IDatasec.getMesg(LangRes.CIPHERNM_BC_TIPS_DESEDEWRAP);
        // v3 = ConstUI.CIPHERNM_BC_DESEDEWRAP;
        // cm_CipherNm.addElement(new ItemBean(ConstUI.KEY_SIZE_BC_DESEDEWRAP,
        // v1,
        // v2, v3));

        // v1 = IDatasec.getMesg(LangRes.CIPHERNM_BC_TEXT_ECIES);
        // v2 = IDatasec.getMesg(LangRes.CIPHERNM_BC_TIPS_ECIES);
        // v3 = ConstUI.CIPHERNM_BC_ECIES;
        // cm_CipherNm.addElement(new ItemBean(ConstUI.KEY_SIZE_BC_ECIES, v1,
        // v2,
        // v3));

        v1 = P3050000.getMesg(LangRes.CIPHERNM_BC_TEXT_IDEA);
        v2 = P3050000.getMesg(LangRes.CIPHERNM_BC_TIPS_IDEA);
        v3 = ConstUI.CIPHERNM_BC_IDEA;
        cm_CipherNm.addElement(new ItemBean(ConstUI.KEY_SIZE_BC_IDEA, v1, v2, v3));

        // v1 = IDatasec.getMesg(LangRes.CIPHERNM_BC_TEXT_MARS);
        // v2 = IDatasec.getMesg(LangRes.CIPHERNM_BC_TIPS_MARS);
        // v3 = ConstUI.CIPHERNM_BC_MARS;
        // cm_CipherNm.addElement(new ItemBean(ConstUI.KEY_SIZE_BC_MARS, v1, v2,
        // v3));

        // 按钮显示信息控制
        tf_UserPwds.setEnabled(true);
        bt_EnCipher.setVisible(true);
        BeanUtil.setWText(bt_DeCipher, P3050000.getMesg(LangRes.BUTN_TEXT_DECIPHER));
        BeanUtil.setWTips(bt_DeCipher, P3050000.getMesg(LangRes.BUTN_TIPS_DECIPHER));
        tf_UserPwds.requestFocus();
    }

    /**
     * 流加密算法初始化
     */
    private void itf()
    {
        cm_CipherNm.removeAllElements();

        String v1;
        String v2;
        String v3;

        v1 = P3050000.getMesg(LangRes.CIPHERNM_SC_TEXT_RC2);
        v2 = P3050000.getMesg(LangRes.CIPHERNM_SC_TIPS_RC2);
        v3 = ConstUI.CIPHERNM_SC_RC2;
        cm_CipherNm.addElement(new ItemBean(ConstUI.KEY_SIZE_SC_RC2, v1, v2, v3));

        v1 = P3050000.getMesg(LangRes.CIPHERNM_SC_TEXT_RC4);
        v2 = P3050000.getMesg(LangRes.CIPHERNM_SC_TIPS_RC4);
        v3 = ConstUI.CIPHERNM_SC_RC4;
        cm_CipherNm.addElement(new ItemBean(ConstUI.KEY_SIZE_SC_RC4, v1, v2, v3));

        // v1 = IDatasec.getMesg(LangRes.CIPHERNM_SC_TEXT_RC5);
        // v2 = IDatasec.getMesg(LangRes.CIPHERNM_SC_TIPS_RC5);
        // v3 = ConstUI.CIPHERNM_SC_RC5;
        // cm_CipherNm.addElement(new ItemBean(ConstUI.KEY_SIZE_SC_RC5, v1, v2,
        // v3));

        // v1 = IDatasec.getMesg(LangRes.CIPHERNM_SC_TEXT_RC6);
        // v2 = IDatasec.getMesg(LangRes.CIPHERNM_SC_TIPS_RC6);
        // v3 = ConstUI.CIPHERNM_SC_RC6;
        // cm_CipherNm.addElement(new ItemBean(ConstUI.KEY_SIZE_SC_RC6, v1, v2,
        // v3));

        // 按钮显示信息控制
        tf_UserPwds.setEnabled(true);
        bt_EnCipher.setVisible(true);
        BeanUtil.setWText(bt_DeCipher, P3050000.getMesg(LangRes.BUTN_TEXT_DECIPHER));
        BeanUtil.setWTips(bt_DeCipher, P3050000.getMesg(LangRes.BUTN_TIPS_DECIPHER));
        tf_UserPwds.requestFocus();
    }

    // ////////////////////////////////////////////////////////////////////////
    // 事件处理区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 密码类别事件处理
     * 
     * @param evt
     */
    private void cb_CipherTp_Handler(java.awt.event.ActionEvent evt)
    {
        K1SV2S item = (K1SV2S) cb_CipherTp.getSelectedItem();
        if (item == null || item.equals(kv_currItem))
        {
            return;
        }
        kv_currItem = item;

        // 散列算法显示
        if (ConstUI.CIPHERTP_MD.equals(item.getK()))
        {
            itc();
            return;
        }
        // 块加密
        if (ConstUI.CIPHERTP_BC.equals(item.getK()))
        {
            ite();
            return;
        }
        // 流加密
        if (ConstUI.CIPHERTP_SC.equals(item.getK()))
        {
            itf();
            return;
        }
        // 奇偶校验
        if (ConstUI.CIPHERTP_CS.equals(item.getK()))
        {
            itd();
            return;
        }
    }

    /**
     * 算法名称事件处理
     * 
     * @param evt
     */
    private void cb_CipherNm_Handler(java.awt.event.ActionEvent evt)
    {
    }

    /**
     * 添加文件事件处理
     * 
     * @param evt
     */
    private void bt_AddFiles_Handler(java.awt.event.ActionEvent evt)
    {
        // 实例化文件打开对话框
        if (fc_FileOpen == null)
        {
            fc_FileOpen = new javax.swing.JFileChooser();
            fc_FileOpen.setFileSelectionMode(javax.swing.JFileChooser.FILES_ONLY);
            fc_FileOpen.setMultiSelectionEnabled(true);
        }

        // 判断用户操作状态
        int stat = fc_FileOpen.showOpenDialog(this);
        if (stat != javax.swing.JFileChooser.APPROVE_OPTION)
        {
            return;
        }

        // 用户选择文件列表
        File[] fileList = fc_FileOpen.getSelectedFiles();
        if (fileList == null || fileList.length < 1)
        {
            return;
        }

        // 显示设定
        K1SV2S kvItem;
        for (File file : fileList)
        {
            kvItem = new K1SV2S(file.getAbsolutePath(), file.getAbsolutePath(), null);
            if (!lm_SrcfList.contains(kvItem))
            {
                lm_SrcfList.addElement(kvItem);
            }
        }
    }

    /**
     * 删除文件事件处理
     * 
     * @param evt
     */
    private void bt_DelFiles_Handler(java.awt.event.ActionEvent evt)
    {
        int indx = ls_SrcfList.getSelectedIndex();
        if (indx >= 0 && indx < lm_SrcfList.size())
        {
            lm_SrcfList.removeElementAt(ls_SrcfList.getSelectedIndex());
        }
    }

    /**
     * 解密事件处理
     * 
     * @param evt
     */
    private void bt_DeCipher_Handler(java.awt.event.ActionEvent evt)
    {
        Thread thread = new Thread()
        {
            public void run()
            {
                deCipher();
            }
        };
        thread.start();
    }

    /**
     * 加密事件处理
     * 
     * @param evt
     */
    private void bt_EnCipher_Handler(java.awt.event.ActionEvent evt)
    {
        Thread thread = new Thread()
        {
            public void run()
            {
                enCipher();
            }
        };
        thread.start();
    }

    /**
     * 文本模式事件处理
     * 
     * @param evt
     */
    private void rb_TextMode_Handler(java.awt.event.ActionEvent evt)
    {
        cl_CardPanel.show(pl_CardPanel, ConstUI.NAME_TEXT_PANEL);

        // 焦点设置
        if (tf_UserPwds.isEnabled())
        {
            tf_UserPwds.requestFocus();
        }
    }

    /**
     * 文件模式事件处理
     * 
     * @param evt
     */
    private void rb_FileMode_Handler(java.awt.event.ActionEvent evt)
    {
        cl_CardPanel.show(pl_CardPanel, ConstUI.NAME_FILE_PANEL);

        // 焦点设置
        if (tf_UserPwds.isEnabled())
        {
            tf_UserPwds.requestFocus();
        }
    }

    // ////////////////////////////////////////////////////////////////////////
    // 密码运算处理
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 数据解密
     */
    private void deCipher()
    {
        // 按钮不可交互
        bt_DeCipher.setEnabled(false);
        // 进度提示信息显示
        pb_ProcStat.setVisible(true);

        // 密码类别
        K1SV2S kvItem = (K1SV2S) cm_CipherTp.getSelectedItem();

        // 散列摘要
        if (ConstUI.CIPHERTP_MD.equals(kvItem.getK()))
        {
            cipherTp_MD();
        }
        // 奇偶校验
        else if (ConstUI.CIPHERTP_CS.equals(kvItem.getK()))
        {
            cipherTp_CS();
        }
        // 数据加密
        else if (ConstUI.CIPHERTP_BC.equals(kvItem.getK()) || ConstUI.CIPHERTP_SC.equals(kvItem.getK()))
        {
            cipherTp_DE();
        }

        // 进度提示信息隐藏
        pb_ProcStat.setVisible(false);
        // 按钮可交互
        bt_DeCipher.setEnabled(true);
    }

    /**
     * 数据加密
     */
    private void enCipher()
    {
        // 按钮不可交互
        bt_EnCipher.setEnabled(false);
        // 进度提示信息显示
        pb_ProcStat.setVisible(true);

        // 密码类别
        K1SV2S kvItem = (K1SV2S) cm_CipherTp.getSelectedItem();

        // 数据加密
        if (ConstUI.CIPHERTP_BC.equals(kvItem.getK()) || ConstUI.CIPHERTP_SC.equals(kvItem.getK()))
        {
            cipherTp_EN();
        }

        // 进度提示信息隐藏
        pb_ProcStat.setVisible(false);
        // 按钮可交互
        bt_EnCipher.setEnabled(true);
    }

    /**
     * 数据散列
     */
    private void cipherTp_MD()
    {
        ItemBean kvItem = (ItemBean) cm_CipherNm.getSelectedItem();

        // 文本模式
        if (rb_TextMode.isSelected())
        {
            // 明文为空性检测
            String srcText = this.ta_SrctArea.getText();
            if (srcText.length() < 1)
            {
                MesgUtil.showMessageDialog(this, P3050000.getMesg(LangRes.MESG_CHCK_0106));
                this.ta_SrctArea.requestFocus();
                return;
            }

            // 散列算法实例化
            MessageDigest digest = initDigest(kvItem.getV3());
            if (digest == null)
            {
                return;
            }

            byte[] b = doDigest(digest, srcText);
            ta_DsttArea.setText(StringUtil.bytesToString(b, true));
            return;
        }

        // 明文文件列表为空检测
        Object[] srcFileList = lm_SrcfList.toArray();
        if (srcFileList == null || srcFileList.length < 1)
        {
            MesgUtil.showMessageDialog(this, P3050000.getMesg(LangRes.MESG_CHCK_0105));
            return;
        }
        // 清除已有运算结果
        lm_DstfList.clear();

        // 散列算法实例化
        MessageDigest digest = initDigest(kvItem.getV3());
        if (digest == null)
        {
            return;
        }
        // 循环处理每一文件对象
        byte[] result;
        K1SV2S kvList;
        for (Object obj : srcFileList)
        {
            if (obj instanceof K1SV2S)
            {
                // 类型转换
                kvList = (K1SV2S) obj;
                try
                {
                    // 对文件进行摘要运算
                    result = doDigest(digest, kvList);
                    // 移除运算成功的选项
                    lm_SrcfList.removeElement(obj);
                    // 运算结果显示
                    lm_DstfList.addElement(new K1SV2S("", StringUtil.bytesToString(result, true), kvList.getV1()));
                }
                catch (Exception exp)
                {
                    LogUtil.exception(exp);
                    kvList.setV2(P3050000.getMesg(LangRes.MESG_UPDT_0102));
                }
            }
        }
    }

    /**
     * 流加密
     */
    private void cipherTp_CS()
    {
        ItemBean kvItem = (ItemBean) cm_CipherNm.getSelectedItem();
        // 文本模式
        if (rb_TextMode.isSelected())
        {
            // 明文为空性检测
            String srcText = this.ta_SrctArea.getText();
            if (srcText.length() < 1)
            {
                MesgUtil.showMessageDialog(this, P3050000.getMesg(LangRes.MESG_CHCK_0106));
                this.ta_SrctArea.requestFocus();
                return;
            }

            // 校验算法实例化
            Checksum checksum = initChecksum(kvItem.getV3());
            long result = doChecksum(checksum, srcText);
            // 运算结果显示
            if ((result >>> 32) == 0)
            {
                srcText = StringUtil.intToString((int) result, true);
            }
            else
            {
                srcText = StringUtil.longToString(result, true);
            }
            this.ta_DsttArea.setText(srcText);
            return;
        }

        // 明文文件列表为空检测
        Object[] srcFileList = lm_SrcfList.toArray();
        if (srcFileList == null || srcFileList.length < 1)
        {
            MesgUtil.showMessageDialog(this, P3050000.getMesg(LangRes.MESG_CHCK_0105));
            return;
        }
        // 清除已有运算结果
        lm_DstfList.clear();

        // 校验算法实例化
        Checksum checksum = initChecksum(kvItem.getV3());
        // 运算结果
        long result;
        K1SV2S kvList;
        // 循环处理每一个文件对象
        for (Object obj : srcFileList)
        {
            if (obj instanceof K1SV2S)
            {
                // 类型转换
                kvList = (K1SV2S) obj;
                try
                {
                    // 对文件进行奇偶校验
                    result = doChecksum(checksum, kvList);
                    // 移除运算成果的选项
                    lm_SrcfList.removeElement(obj);
                    // 运算结果显示
                    String t;
                    if ((result >>> 32) == 0)
                    {
                        t = StringUtil.intToString((int) result, true);
                    }
                    else
                    {
                        t = StringUtil.longToString(result, true);
                    }
                    lm_DstfList.addElement(new K1SV2S("", t, kvItem.getV1()));
                }
                catch (Exception exp)
                {
                    LogUtil.exception(exp);
                    kvItem.setV2(P3050000.getMesg(LangRes.MESG_UPDT_0202));
                }
            }
        }
    }

    /**
     * 数据解密
     */
    private void cipherTp_DE()
    {
        String pwds = this.tf_UserPwds.getText();
        if (pwds.length() < 1)
        {
            MesgUtil.showMessageDialog(this, P3050000.getMesg(LangRes.MESG_CHCK_0104));
            this.tf_UserPwds.requestFocus();
            return;
        }

        // 算法口令长度支持
        ItemBean kvItem = (ItemBean) cm_CipherNm.getSelectedItem();
        int keySize = kvItem.getK();

        // 口令长度检测
        byte[] userPwd = pwds.getBytes();
        LogUtil.log("加密算法：" + kvItem.getV3() + "、口令长度：" + kvItem.getK());
        if (userPwd.length > keySize)
        {
            String mesg = CharUtil.format(P3050000.getMesg(LangRes.MESG_UPDT_0303), kvItem.getV1(), "" + keySize);
            MesgUtil.showMessageDialog(this, mesg);
            this.tf_UserPwds.requestFocus();
            return;
        }

        // 文本模式
        if (rb_TextMode.isSelected())
        {
            // 明文为空性检测
            String srcText = this.ta_SrctArea.getText();
            if (srcText.length() < 1)
            {
                MesgUtil.showMessageDialog(this, P3050000.getMesg(LangRes.MESG_CHCK_0106));
                this.ta_SrctArea.requestFocus();
                return;
            }

            try
            {
                // 加密算法初始化
                Cipher cipher = initCipher(kvItem.getV3(), userPwd, Cipher.DECRYPT_MODE, kvItem.getK());
                if (cipher == null)
                {
                    return;
                }
                byte[] srcByte = StringUtil.stringToBytes(srcText.toUpperCase(), true);
                byte[] dstByte = doCipher(cipher, srcByte);
                this.ta_DsttArea.setText(new String(dstByte));
            }
            catch (Exception exp)
            {
                LogUtil.exception(exp);
                this.ta_DsttArea.setText(P3050000.getMesg(LangRes.MESG_UPDT_0306));
                return;
            }
            return;
        }

        // 明文文件列表为空检测
        Object[] srcFileList = lm_SrcfList.toArray();
        if (srcFileList == null || srcFileList.length < 1)
        {
            MesgUtil.showMessageDialog(this, P3050000.getMesg(LangRes.MESG_CHCK_0105));
            return;
        }
        // 清除已有运算结果
        lm_DstfList.clear();

        // 加密算法初始化
        Cipher cipher = initCipher(kvItem.getV3(), userPwd, Cipher.DECRYPT_MODE, kvItem.getK());
        if (cipher == null)
        {
            return;
        }
        // 解密结果文件
        File deFile;
        K1SV2S kvList;
        // 循环处理每一个文件对象
        for (Object obj : srcFileList)
        {
            if (obj instanceof K1SV2S)
            {
                // 类型转换
                kvList = (K1SV2S) obj;
                try
                {
                    // 生成解密文件实例
                    deFile = getDecryptFile(kvList);
                    // 对文件进行解密运算
                    deFile = doCipher(cipher, kvList, deFile);
                    // 移除运算成功的选项
                    lm_SrcfList.removeElement(obj);
                    // 运算结果显示
                    lm_DstfList.addElement(new K1SV2S("", deFile.getAbsolutePath(), kvList.getV1()));
                }
                catch (Exception exp)
                {
                    LogUtil.exception(exp);
                    kvList.setV2(P3050000.getMesg(LangRes.MESG_UPDT_0306));
                }
            }
        }
    }

    /**
     * 数据加密
     */
    private void cipherTp_EN()
    {
        // 用户口令为空检测
        String pwds = this.tf_UserPwds.getText();
        if (pwds.length() < 1)
        {
            MesgUtil.showMessageDialog(this, P3050000.getMesg(LangRes.MESG_CHCK_0104));
            this.tf_UserPwds.requestFocus();
            return;
        }

        // 算法口令长度支持
        ItemBean kvItem = (ItemBean) cm_CipherNm.getSelectedItem();
        int keySize = kvItem.getK();

        // 口令长度检测
        byte[] userPwd = pwds.getBytes();
        LogUtil.log("加密算法：" + kvItem.getV3() + "、口令长度：" + kvItem.getK());
        if (userPwd.length > keySize)
        {
            String mesg = CharUtil.format(P3050000.getMesg(LangRes.MESG_UPDT_0303), kvItem.getV1(), "" + keySize);
            MesgUtil.showMessageDialog(this, mesg);
            this.tf_UserPwds.requestFocus();
            return;
        }

        // 文本模式
        if (rb_TextMode.isSelected())
        {
            // 明文为空性检测
            String srcText = this.ta_SrctArea.getText();
            if (srcText.length() < 1)
            {
                MesgUtil.showMessageDialog(this, P3050000.getMesg(LangRes.MESG_CHCK_0106));
                this.ta_SrctArea.requestFocus();
                return;
            }

            try
            {
                // 加密算法初始化
                Cipher cipher = initCipher(kvItem.getV3(), userPwd, Cipher.ENCRYPT_MODE, kvItem.getK());
                if (cipher == null)
                {
                    return;
                }
                byte[] srcByte = srcText.getBytes();
                byte[] dstByte = doCipher(cipher, srcByte);
                this.ta_DsttArea.setText(StringUtil.bytesToString(dstByte, true));
            }
            catch (Exception exp)
            {
                LogUtil.exception(exp);
                this.ta_DsttArea.setText(P3050000.getMesg(LangRes.MESG_UPDT_0305));
                return;
            }
            return;
        }

        // 明文文件列表为空检测
        Object[] srcFileList = lm_SrcfList.toArray();
        if (srcFileList == null || srcFileList.length < 1)
        {
            MesgUtil.showMessageDialog(this, P3050000.getMesg(LangRes.MESG_CHCK_0105));
            return;
        }
        // 清除已有运算结果
        lm_DstfList.clear();

        // 加密算法初始化
        Cipher cipher = initCipher(kvItem.getV3(), userPwd, Cipher.ENCRYPT_MODE, kvItem.getK());
        if (cipher == null)
        {
            return;
        }
        // 加密结果文件
        File enFile;
        K1SV2S kvList;
        // 循环处理每一个文件对象
        for (Object obj : srcFileList)
        {
            if (obj instanceof K1SV2S)
            {
                // 类型转换
                kvList = (K1SV2S) obj;
                try
                {
                    // 生成加密文档实例
                    enFile = getEncryptFile(kvList);
                    // 对文件进行加密运算
                    enFile = doCipher(cipher, kvList, enFile);
                    // 移除运算成功的选项
                    lm_SrcfList.removeElement(obj);
                    // 运算结果显示
                    lm_DstfList.addElement(new K1SV2S("", enFile.getAbsolutePath(), kvList.getV1()));
                }
                catch (Exception exp)
                {
                    LogUtil.exception(exp);
                    kvList.setV2(P3050000.getMesg(LangRes.MESG_UPDT_0306));
                }
            }
        }
    }

    /**
     * 检测文档的可读属性
     * 
     * @return
     */
    private boolean checkFileRead(File dataFile, K1SV2S kvItem)
    {
        // 数据文件是否存在判断
        if (!dataFile.exists())
        {
            kvItem.setV2(CharUtil.format(LangRes.MESG_CHCK_0101, dataFile.getPath()));
            return false;
        }
        // 数据文件是否为文档判断
        if (!dataFile.isFile())
        {
            return false;
        }
        // 数据文件是否可读取判断
        if (!dataFile.canRead())
        {
            return false;
        }
        return true;
    }

    /**
     * 检测文档的可写属性
     * 
     * @return
     */
    private boolean checkFileWrite(File dataFile, K1SV2S kvItem)
    {
        // 数据文件是否为文档判断
        if (!dataFile.isFile())
        {
            return false;
        }
        // 数据文件是否可读取判断
        if (!dataFile.canWrite())
        {
            return false;
        }
        return true;
    }

    /**
     * 散列摘要初始化
     * 
     * @param algorithm
     * @return
     */
    private MessageDigest initDigest(String algorithm)
    {
        try
        {
            return MessageDigest.getInstance(algorithm);
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            String mesg = CharUtil.format(P3050000.getMesg(LangRes.MESG_UPDT_0101), algorithm);
            MesgUtil.showMessageDialog(this, mesg);
            return null;
        }
    }

    /**
     * 密码算法实例化
     * 
     * @param algorithm
     *            密码算法名称
     * @param userPwd
     *            用户口令
     * @param mode
     *            密码模式
     * @param keySize
     *            口令长度需求
     * @return
     */
    private Cipher initCipher(String algorithm, byte[] userPwd, int mode, int keySize)
    {
        // 密码算法实例化
        Cipher cipher = null;
        try
        {
            cipher = Cipher.getInstance(algorithm);
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            String mesg = CharUtil.format(P3050000.getMesg(LangRes.MESG_UPDT_0302), algorithm);
            MesgUtil.showMessageDialog(this, mesg);
            return null;
        }

        // 安全密钥初始化
        SecureKey sKey = new SecureKey(algorithm, userPwd, keySize);

        // 真随机数实例化
        SecureRandom sRandom = new SecureRandom();

        // 密码算法初始化
        try
        {
            cipher.init(mode, sKey, sRandom);
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            MesgUtil.showMessageDialog(this, P3050000.getMesg(LangRes.MESG_UPDT_0304));
            return null;
        }

        return cipher;
    }

    /**
     * 奇偶校验初始化
     * 
     * @param algorithm
     * @return
     */
    private Checksum initChecksum(String algorithm)
    {
        // CRC32
        if (ConstUI.CIPHERNM_CRC_CRC32.equals(algorithm))
        {
            return new CRC32();
        }
        // CRC64
        if (ConstUI.CIPHERNM_CRC_CRC64.equals(algorithm))
        {
            return new CRC64();
        }
        return null;
    }

    /**
     * 文本摘要
     * 
     * @param digest
     * @param srcText
     * @throws Exception
     */
    private byte[] doDigest(MessageDigest digest, String srcText)
    {
        if (srcText.length() < 1)
        {
            return null;
        }

        // 进度条状态初始化
        pb_ProcStat.setValue(0);
        // 字节表示
        byte[] srcByte = srcText.getBytes();
        // 单步处理字节大小
        int stepSize = srcByte.length >>> ConstUI.DEF_STEP;
        int nextStep = stepSize;
        // 当前处理量
        int currStep = 0;
        // 未处理字节量
        int leftSize = srcByte.length;

        while (leftSize > 0)
        {
            if (leftSize > ConstUI.BUF_SIZE)
            {
                leftSize = ConstUI.BUF_SIZE;
            }

            // 散列处理
            digest.update(srcByte, currStep, leftSize);

            // 统称量重新计算
            currStep += leftSize;
            if (currStep >= nextStep)
            {
                pb_ProcStat.setValue(pb_ProcStat.getValue() + 1);
                nextStep += stepSize;
            }
            // 修正剩余量
            leftSize = srcByte.length - currStep;
        }

        // 返回运算结果
        return digest.digest();
    }

    /**
     * 文件摘要
     * 
     * @param digest
     * @param srcFile
     * @throws Exception
     */
    private byte[] doDigest(MessageDigest digest, K1SV2S kvItem) throws Exception
    {
        // 创建文件对象
        File srcFile = new File(kvItem.getV1());

        // 文件可读性判断
        if (!checkFileRead(srcFile, kvItem))
        {
            return null;
        }

        // 进度条状态初始化
        pb_ProcStat.setValue(0);
        // 文件步增量计算
        long stepSize = srcFile.length() >>> ConstUI.DEF_STEP;
        long nextStep = stepSize;
        // 当前处理量
        long currStep = 0;
        // 数据缓冲区
        byte[] buf = new byte[ConstUI.BUF_SIZE];

        // 明文数据输入流
        FileInputStream fis = new FileInputStream(srcFile);
        // 循环对明文数据进行散列算法处理
        int len = fis.read(buf);
        while (len != -1)
        {
            // 对数据进行散列处理
            digest.update(buf, 0, len);

            // 设置进度条显示状态
            currStep += len;
            if (currStep >= nextStep)
            {
                pb_ProcStat.setValue(pb_ProcStat.getValue() + 1);
                nextStep += stepSize;
            }

            // 读取下一块待处理数据
            len = fis.read(buf);
        }
        // 关闭数据流
        fis.close();

        // 返回运算结果
        return digest.digest();
    }

    /**
     * 奇偶校验
     * 
     * @param checksum
     * @param srcText
     * @throws Exception
     */
    private long doChecksum(Checksum checksum, String srcText)
    {
        if (srcText.length() < 1)
        {
            return 0;
        }

        // 进度条状态初始化
        pb_ProcStat.setValue(0);
        // 字节表示
        byte[] srcByte = srcText.getBytes();
        // 单步处理字节大小
        int stepSize = srcByte.length >>> ConstUI.DEF_STEP;
        int nextStep = stepSize;
        // 当前处理量
        int currStep = 0;
        // 未处理字节大小
        int leftSize = srcByte.length;
        while (leftSize > 0)
        {
            if (leftSize > ConstUI.BUF_SIZE)
            {
                leftSize = ConstUI.BUF_SIZE;
            }

            // 散列处理
            checksum.update(srcByte, currStep, leftSize);

            // 偏移量重新计算
            currStep += leftSize;
            if (currStep >= nextStep)
            {
                pb_ProcStat.setValue(pb_ProcStat.getValue() + 1);
                nextStep += stepSize;
            }

            // 修正剩余量
            leftSize = srcByte.length - currStep;
        }

        // 返回运算结果
        return checksum.getValue();
    }

    /**
     * 奇偶校验
     * 
     * @param checksum
     * @param srcFile
     * @throws Exception
     */
    private long doChecksum(Checksum checksum, K1SV2S kvItem) throws Exception
    {
        File srcFile = new File(kvItem.getV1());

        // 文件可读取判断
        if (!checkFileRead(srcFile, kvItem))
        {
            return 0;
        }

        // 进度条状态初始化
        pb_ProcStat.setValue(0);
        // 文件步增量计算
        long stepSize = srcFile.length() >>> ConstUI.DEF_STEP;
        long nextStep = stepSize;
        // 当前处理量
        long currStep = 0;
        // 数据缓冲区
        byte[] buf = new byte[ConstUI.BUF_SIZE];

        // 明文数据输入流
        FileInputStream fis = new FileInputStream(srcFile);
        // 循环对明文数据进行散列算法处理
        int len = fis.read(buf);
        while (len != -1)
        {
            // 对数据进行校验处理
            checksum.update(buf, 0, len);

            // 设置进度条显示状态
            currStep += len;
            if (currStep >= nextStep)
            {
                pb_ProcStat.setValue(pb_ProcStat.getValue() + 1);
                nextStep += stepSize;
            }

            // 读取下一块等处理数据
            len = fis.read(buf);
        }

        // 关闭数据流
        fis.close();

        return checksum.getValue();
    }

    /**
     * @param cipher
     * @param srcText
     * @return
     * @throws Exception
     */
    private byte[] doCipher(Cipher cipher, byte[] srcByte) throws Exception
    {
        // 进度条状态初始化
        pb_ProcStat.setValue(0);
        // 单步处理字节大小
        int stepSize = srcByte.length >>> ConstUI.DEF_STEP;
        int nextStep = stepSize;
        // 当前处理量
        int currStep = 0;
        // 未处理字节大小
        int leftSize = srcByte.length;

        ByteArrayOutputStream bos = new ByteArrayOutputStream();
        while (leftSize > 0)
        {
            if (leftSize > ConstUI.BUF_SIZE)
            {
                leftSize = ConstUI.BUF_SIZE;
            }

            // 散列处理
            bos.write(cipher.update(srcByte, currStep, leftSize));

            // 偏移量重新计算
            currStep += leftSize;
            if (currStep >= nextStep)
            {
                pb_ProcStat.setValue(pb_ProcStat.getValue() + 1);
                nextStep += stepSize;
            }

            // 修正剩余量
            leftSize = srcByte.length - currStep;
        }

        bos.write(cipher.doFinal());
        srcByte = bos.toByteArray();
        bos.close();

        // 返回运算结果
        return srcByte;
    }

    /**
     * 文件密码运算
     * 
     * @param cipher
     *            算法实例
     * @param srcFile
     *            明文数据文件
     * @return 密文数据文件
     * @throws Exception
     */
    private File doCipher(Cipher cipher, K1SV2S kvItem, File dstFile) throws Exception
    {
        // 创建明文文件对象
        File srcFile = new File(kvItem.getV1());

        // 检测明文文档的可读属性
        if (!checkFileRead(srcFile, kvItem))
        {
            return null;
        }

        // 判断密文文档的可写属性
        if (!checkFileWrite(dstFile, kvItem))
        {
            return null;
        }

        // 进度条状态初始化
        pb_ProcStat.setValue(0);
        // 文件步增量
        long stepSize = srcFile.length() >>> ConstUI.DEF_STEP;
        long nextStep = stepSize;
        // 当前处理量
        long currStep = 0;
        // 数据缓冲区
        byte[] buf = new byte[ConstUI.BUF_SIZE];

        // 明文数据输入流
        FileInputStream fis = new FileInputStream(srcFile);
        // 密文数据输出流
        FileOutputStream fos = new FileOutputStream(dstFile);

        // 循环对明文数据进行密码算法处理，并输出到文件
        int len = fis.read(buf);
        while (len != -1)
        {
            // 对数据进行密码运算并输出到文件
            fos.write(cipher.update(buf, 0, len));

            // 设置进度条显示状态
            currStep += len;
            if (currStep >= nextStep)
            {
                pb_ProcStat.setValue(pb_ProcStat.getValue() + 1);
                nextStep += stepSize;
            }

            // 读取下一块数据
            len = fis.read(buf);
        }
        // 缓冲区数据写出到文件
        fos.write(cipher.doFinal());
        fos.flush();

        // 关闭数据流
        fos.close();
        fis.close();

        return dstFile;
    }

    /**
     * 由明文文件路径获得对应密文文件路径
     * 
     * @param srcFile
     *            明文文件路径
     * @return
     */
    private File getEncryptFile(K1SV2S kvItem)
    {
        File dstFile = new File(kvItem.getV1() + ConstUI.DEF_PLUS);
        if (!dstFile.exists())
        {
            try
            {
                dstFile.createNewFile();
            }
            catch (Exception exp)
            {
                LogUtil.exception(exp);
                kvItem.setV2(P3050000.getMesg(LangRes.MESG_CHCK_0102));
            }
        }
        return dstFile;
    }

    /**
     * 由密文文件路径获取对应明文文件路径
     * 
     * @param dstFile
     * @return
     */
    private File getDecryptFile(K1SV2S kvItem)
    {
        File dstFile = new File(kvItem.getV1().substring(0, kvItem.getV1().length() - 1));
        if (!dstFile.exists())
        {
            try
            {
                dstFile.createNewFile();
            }
            catch (Exception exp)
            {
                LogUtil.exception(exp);
                kvItem.setV2(P3050000.getMesg(LangRes.MESG_CHCK_0103));
            }
        }
        return dstFile;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面变量区域
    // ////////////////////////////////////////////////////////////////////////
    // 正常界面
    private javax.swing.JButton bt_DeCipher;
    private javax.swing.JButton bt_EnCipher;
    private javax.swing.JComboBox cb_CipherNm;
    private javax.swing.JComboBox cb_CipherTp;
    private javax.swing.JProgressBar pb_ProcStat;
    private javax.swing.JPanel pl_CardPanel;
    private java.awt.CardLayout cl_CardPanel;
    // 操作模式
    private javax.swing.JPanel pl_ModePanel;
    private javax.swing.JRadioButton rb_TextMode;
    private javax.swing.JRadioButton rb_FileMode;
    // 用户交互
    private javax.swing.JPanel pl_UserPanel;
    private javax.swing.JLabel lb_UserPwds;
    private javax.swing.JTextField tf_UserPwds;
    private javax.swing.JCheckBox ck_NoRepeat;
    // 字符模式
    private javax.swing.JPanel pl_TextPanel;
    private javax.swing.JLabel lb_DsttArea;
    private javax.swing.JLabel lb_SrctArea;
    private javax.swing.JTextArea ta_DsttArea;
    private javax.swing.JTextArea ta_SrctArea;
    // 文件模式
    private javax.swing.JPanel pl_FilePanel;
    private javax.swing.JButton bt_AddFiles;
    private javax.swing.JButton bt_DelFiles;
    private javax.swing.JLabel lb_DstfList;
    private javax.swing.JLabel lb_SrcfList;
    private javax.swing.JList ls_DstfList;
    private javax.swing.JList ls_SrcfList;
    private javax.swing.JFileChooser fc_FileOpen;
}
