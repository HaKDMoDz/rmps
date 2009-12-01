/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.amon.code.A1010000.v;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.List;

import javax.crypto.Cipher;
import javax.swing.DefaultComboBoxModel;
import javax.swing.JFileChooser;

import rmp.amon.code.A1010000.A1010000;
import rmp.amon.code.A1010000.b.WComment;
import rmp.amon.code.A1010000.m.Util;
import rmp.bean.K1IV3S;
import rmp.bean.K1SV2S;
import rmp.face.WBean;
import rmp.prp.aide.P3050000.m.SecureKey;
import rmp.util.CheckUtil;
import rmp.util.FileUtil;
import rmp.util.HashUtil;
import com.amonsoft.util.LogUtil;
import rmp.util.MesgUtil;
import rmp.util.StringUtil;
import cons.SysCons;
import cons.amon.code.A1010000.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 代码安全高级窗口
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class MainPanel extends javax.swing.JPanel implements WBean
{
    // ////////////////////////////////////////////////////////////////////////
    // 控制变量区域
    // ////////////////////////////////////////////////////////////////////////
    /** 软件主程序入口 */
    // private ICodesec ms_MainSoft;
    /** 转换方式数据模型 */
    private DefaultComboBoxModel cm_CipherTp;
    /** 密码算法数据模型 */
    private DefaultComboBoxModel cm_CipherNm;
    /** 来源文件对象 */
    private File srcFilePath;
    /** 输出文件对象 */
    private File dstFilePath;
    /** 界面布局管理器 */
    private java.awt.CardLayout cl_CardLayout;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @param soft
     */
    public MainPanel(A1010000 soft)
    {
        // ms_MainSoft = soft;
        // ms_MainSoft.getSoftID();
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#wInit()
     */
    public boolean wInit()
    {
        ica();
        icb();
        icc();

        ita();
        itb();
        itc();

        return true;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面显示区域
    // ////////////////////////////////////////////////////////////////////////
    // ----------------------------------------------------
    // 界面布局区域
    // ----------------------------------------------------
    /**
     * 清除注释面板初始化
     */
    private void ica()
    {
        pl_CmtPanel = new javax.swing.JPanel();

        lb_CSrcFile = new javax.swing.JLabel();
        tf_CSrcFile = new javax.swing.JTextField();
        bt_CSrcFile = new javax.swing.JButton();
        lb_CDstFile = new javax.swing.JLabel();
        tf_CDstFile = new javax.swing.JTextField();
        bt_CDstFile = new javax.swing.JButton();
        lb_Log = new javax.swing.JLabel();
        ck_LogMultiLine = new javax.swing.JCheckBox();
        ck_LogSingleLine = new javax.swing.JCheckBox();
        ck_LogExceptions = new javax.swing.JCheckBox();
        lb_Cmt = new javax.swing.JLabel();
        ck_CmtDocument = new javax.swing.JCheckBox();
        ck_CmtMultiLine = new javax.swing.JCheckBox();
        ck_CmtSingleLine = new javax.swing.JCheckBox();
        lb_Fmt = new javax.swing.JLabel();
        ck_FmtSpaceChar = new javax.swing.JCheckBox();
        ck_FmtBlankLine = new javax.swing.JCheckBox();
        ck_FmtReturnTrip = new javax.swing.JCheckBox();
        javax.swing.JScrollPane sp_InfoArea = new javax.swing.JScrollPane();
        ta_InfoArea = new javax.swing.JTextArea();

        lb_CSrcFile.setText("\u6765\u6e90\u6587\u4ef6");

        tf_CSrcFile.setEditable(false);

        bt_CSrcFile.setMnemonic('S');
        bt_CSrcFile.setText("\u9009\u62e9(S)");
        bt_CSrcFile.setMargin(new java.awt.Insets(1, 7, 1, 7));
        bt_CSrcFile.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_CSrcFile_Handler(evt);
            }
        });

        lb_CDstFile.setText("\u76ee\u7684\u6587\u4ef6");

        tf_CDstFile.setEditable(false);

        bt_CDstFile.setMnemonic('D');
        bt_CDstFile.setText("\u9009\u62e9(D)");
        bt_CDstFile.setMargin(new java.awt.Insets(1, 7, 1, 7));
        bt_CDstFile.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_CDstFile_Handler(evt);
            }
        });

        lb_Log.setText("\u65e5\u5fd7");

        ck_LogMultiLine.setText("\u8c03\u8bd5\u65e5\u5fd7");
        ck_LogMultiLine.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_LogMultiLine.setMargin(new java.awt.Insets(0, 0, 0, 0));
        ck_LogMultiLine.setSelected(true);

        ck_LogSingleLine.setText("\u6d88\u606f\u65e5\u5fd7");
        ck_LogSingleLine.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_LogSingleLine.setMargin(new java.awt.Insets(0, 0, 0, 0));
        ck_LogSingleLine.setSelected(true);

        ck_LogExceptions.setText("\u5f02\u5e38\u65e5\u5fd7");
        ck_LogExceptions.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_LogExceptions.setMargin(new java.awt.Insets(0, 0, 0, 0));

        lb_Cmt.setText("\u6ce8\u91ca");

        ck_CmtDocument.setText("\u6587\u6863\u6ce8\u91ca");
        ck_CmtDocument.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_CmtDocument.setMargin(new java.awt.Insets(0, 0, 0, 0));
        ck_CmtDocument.setSelected(true);

        ck_CmtMultiLine.setText("\u591a\u884c\u6ce8\u91ca");
        ck_CmtMultiLine.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_CmtMultiLine.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_CmtSingleLine.setText("\u5355\u884c\u6ce8\u91ca");
        ck_CmtSingleLine.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_CmtSingleLine.setMargin(new java.awt.Insets(0, 0, 0, 0));
        ck_CmtSingleLine.setSelected(true);

        lb_Fmt.setText("\u683c\u5f0f");

        ck_FmtSpaceChar.setText("\u7a7a\u683c");
        ck_FmtSpaceChar.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_FmtSpaceChar.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_FmtBlankLine.setText("\u7a7a\u884c");
        ck_FmtBlankLine.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_FmtBlankLine.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_FmtReturnTrip.setText("\u56de\u884c");
        ck_FmtReturnTrip.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_FmtReturnTrip.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ta_InfoArea.setEditable(false);
        ta_InfoArea.setTabSize(2);
        sp_InfoArea.setViewportView(ta_InfoArea);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(pl_CmtPanel);
        pl_CmtPanel.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addGap(62, 62, 62).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(
                ck_LogMultiLine).addComponent(ck_CmtDocument).addComponent(ck_FmtSpaceChar)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(
                ck_LogSingleLine).addComponent(ck_CmtMultiLine).addComponent(ck_FmtBlankLine)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(
                ck_LogExceptions).addComponent(ck_CmtSingleLine).addComponent(ck_FmtReturnTrip))).addGroup(
                javax.swing.GroupLayout.Alignment.TRAILING,
                layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(
                lb_CSrcFile).addComponent(lb_CDstFile).addComponent(lb_Log).addComponent(lb_Cmt).addComponent(lb_Fmt)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(
                tf_CDstFile, javax.swing.GroupLayout.DEFAULT_SIZE, 161, Short.MAX_VALUE).addComponent(
                tf_CSrcFile, javax.swing.GroupLayout.DEFAULT_SIZE, 161, Short.MAX_VALUE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(
                bt_CSrcFile, javax.swing.GroupLayout.Alignment.TRAILING).addComponent(bt_CDstFile,
                javax.swing.GroupLayout.Alignment.TRAILING))).addGroup(
                layout.createSequentialGroup().addContainerGap().addComponent(sp_InfoArea,
                javax.swing.GroupLayout.DEFAULT_SIZE, 280, Short.MAX_VALUE))).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_CSrcFile).addComponent(bt_CSrcFile).addComponent(tf_CSrcFile, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_CDstFile).addComponent(bt_CDstFile).addComponent(tf_CDstFile, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_Log).addComponent(ck_LogMultiLine).addComponent(ck_LogSingleLine).addComponent(ck_LogExceptions)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_Cmt).addComponent(ck_CmtDocument).addComponent(ck_CmtMultiLine).addComponent(ck_CmtSingleLine)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_Fmt).addComponent(ck_FmtSpaceChar).addComponent(ck_FmtBlankLine).addComponent(ck_FmtReturnTrip)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addComponent(sp_InfoArea,
                javax.swing.GroupLayout.PREFERRED_SIZE, 80, javax.swing.GroupLayout.PREFERRED_SIZE).addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)));
    }

    /**
     * 密码转换面板初始化
     */
    private void icb()
    {
        pl_SecPanel = new javax.swing.JPanel();

        lb_CipherTp = new javax.swing.JLabel();
        cb_CipherTp = new javax.swing.JComboBox();
        tf_CharSize = new javax.swing.JTextField();
        lb_CipherNm = new javax.swing.JLabel();
        cb_CipherNm = new javax.swing.JComboBox();
        lb_UserPwds = new javax.swing.JLabel();
        tf_UserPwds = new javax.swing.JTextField();
        ck_RandomKey = new javax.swing.JCheckBox();
        lb_SSrcFile = new javax.swing.JLabel();
        tf_SSrcFile = new javax.swing.JTextField();
        bt_SSrcFile = new javax.swing.JButton();

        lb_CipherTp.setDisplayedMnemonic('M');
        lb_CipherTp.setText("\u8f6c\u6362\u65b9\u5f0f(M)");

        cb_CipherTp.addItemListener(new java.awt.event.ItemListener()
        {
            public void itemStateChanged(java.awt.event.ItemEvent evt)
            {
                cb_CipherTp_Handler(evt);
            }
        });

        tf_CharSize.setColumns(5);
        tf_CharSize.setToolTipText("\u52a0\u5bc6\u5904\u7406\u540e\u5206\u5757\u5927\u5c0f");

        lb_CipherNm.setDisplayedMnemonic('C');
        lb_CipherNm.setText("\u5bc6\u7801\u7b97\u6cd5(C)");

        lb_UserPwds.setDisplayedMnemonic('P');
        lb_UserPwds.setText("\u7528\u6237\u53e3\u4ee4(P)");

        ck_RandomKey.setMnemonic('R');
        ck_RandomKey.setText("\u968f\u673a(R)");
        ck_RandomKey.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_RandomKey.setMargin(new java.awt.Insets(0, 0, 0, 0));
        ck_RandomKey.addItemListener(new java.awt.event.ItemListener()
        {
            public void itemStateChanged(java.awt.event.ItemEvent evt)
            {
                ck_RandomKey_Handler(evt);
            }
        });

        lb_SSrcFile.setDisplayedMnemonic('F');
        lb_SSrcFile.setText("\u6587\u4ef6\u8def\u5f84(F)");

        tf_SSrcFile.setEditable(false);

        bt_SSrcFile.setMnemonic('S');
        bt_SSrcFile.setText("\u9009\u62e9(S)");
        bt_SSrcFile.setMargin(new java.awt.Insets(1, 7, 1, 7));
        bt_SSrcFile.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_SSrcFile_Handler(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(pl_SecPanel);
        pl_SecPanel.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_CipherTp).addComponent(lb_CipherNm).addComponent(lb_UserPwds).addComponent(lb_SSrcFile)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addComponent(cb_CipherTp, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(tf_CharSize,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE)).addComponent(cb_CipherNm,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addGroup(
                javax.swing.GroupLayout.Alignment.TRAILING,
                layout.createSequentialGroup().addComponent(tf_UserPwds, javax.swing.GroupLayout.DEFAULT_SIZE, 145,
                Short.MAX_VALUE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(ck_RandomKey)).addGroup(
                javax.swing.GroupLayout.Alignment.TRAILING,
                layout.createSequentialGroup().addComponent(tf_SSrcFile, javax.swing.GroupLayout.DEFAULT_SIZE, 143,
                Short.MAX_VALUE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_SSrcFile))).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_CipherTp).addComponent(cb_CipherTp, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(
                tf_CharSize, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_CipherNm).addComponent(cb_CipherNm, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_UserPwds).addComponent(ck_RandomKey).addComponent(tf_UserPwds, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_SSrcFile).addComponent(bt_SSrcFile).addComponent(tf_SSrcFile, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addContainerGap(
                javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)));
    }

    /**
     * 高级面板初始化
     */
    private void icc()
    {
        javax.swing.ButtonGroup bg = new javax.swing.ButtonGroup();
        pl_UserPanel = new javax.swing.JPanel();
        rb_Comment = new javax.swing.JRadioButton();
        rb_CodeSec = new javax.swing.JRadioButton();
        pl_CardPanel = new javax.swing.JPanel();
        bt_DoCipher = new javax.swing.JButton();

        pl_UserPanel.setLayout(new java.awt.FlowLayout(java.awt.FlowLayout.CENTER, 5, 0));

        bg.add(rb_Comment);
        rb_Comment.setMnemonic('C');
        rb_Comment.setSelected(true);
        rb_Comment.setText("\u4ee3\u7801\u6e05\u7406(C)");
        rb_Comment.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        rb_Comment.setMargin(new java.awt.Insets(0, 0, 0, 0));
        rb_Comment.addItemListener(new java.awt.event.ItemListener()
        {
            public void itemStateChanged(java.awt.event.ItemEvent evt)
            {
                rb_Comment_Handler(evt);
            }
        });
        pl_UserPanel.add(rb_Comment);

        bg.add(rb_CodeSec);
        rb_CodeSec.setMnemonic('S');
        rb_CodeSec.setText("\u4ee3\u7801\u5b89\u5168(S)");
        rb_CodeSec.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        rb_CodeSec.setMargin(new java.awt.Insets(0, 0, 0, 0));
        rb_CodeSec.addItemListener(new java.awt.event.ItemListener()
        {
            public void itemStateChanged(java.awt.event.ItemEvent evt)
            {
                rb_CodeSec_Handler(evt);
            }
        });
        pl_UserPanel.add(rb_CodeSec);

        pl_CardPanel.setBorder(javax.swing.BorderFactory.createEtchedBorder());
        cl_CardLayout = new java.awt.CardLayout();
        pl_CardPanel.setLayout(cl_CardLayout);
        pl_CardPanel.add("cmtpanel", pl_CmtPanel);
        pl_CardPanel.add("secpanel", pl_SecPanel);

        bt_DoCipher.setMnemonic('O');
        bt_DoCipher.setText("\u6e05\u9664(O)");
        bt_DoCipher.setMargin(new java.awt.Insets(1, 7, 1, 7));
        bt_DoCipher.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_DoCipher_Handler(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                javax.swing.GroupLayout.Alignment.TRAILING,
                layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING).addComponent(pl_CardPanel,
                javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 300,
                Short.MAX_VALUE).addComponent(pl_UserPanel, javax.swing.GroupLayout.Alignment.LEADING,
                javax.swing.GroupLayout.DEFAULT_SIZE, 279, Short.MAX_VALUE).addComponent(bt_DoCipher)).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addComponent(pl_UserPanel,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(pl_CardPanel,
                javax.swing.GroupLayout.DEFAULT_SIZE, 200, Short.MAX_VALUE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addComponent(bt_DoCipher).addContainerGap()));
    }

    // ----------------------------------------------------
    // 语言显示区域
    // ----------------------------------------------------
    /**
     * 清除注释面板语言显示
     */
    private void ita()
    {
        // 来源文件
        A1010000.getLangUtil().setWText(lb_CSrcFile, LangRes.LABL_TEXT_SRCFILE, "");
        A1010000.getLangUtil().setWTips(lb_CSrcFile, LangRes.LABL_TIPS_SRCFILE, "");

        A1010000.getLangUtil().setWText(tf_CSrcFile, LangRes.FILD_TEXT_CSRCFILE, "");
        A1010000.getLangUtil().setWTips(tf_CSrcFile, LangRes.FILD_TIPS_CSRCFILE, "");

        A1010000.getLangUtil().setWText(bt_CSrcFile, LangRes.BUTN_TEXT_SRCFILE, "");
        A1010000.getLangUtil().setWTips(bt_CSrcFile, LangRes.BUTN_TIPS_SRCFILE, "");

        // 输出文件
        A1010000.getLangUtil().setWText(lb_CDstFile, LangRes.LABL_TEXT_DSTFILE, "");
        A1010000.getLangUtil().setWTips(lb_CDstFile, LangRes.LABL_TIPS_DSTFILE, "");

        A1010000.getLangUtil().setWText(tf_CDstFile, LangRes.FILD_TEXT_DSTFILE, "");
        A1010000.getLangUtil().setWTips(tf_CDstFile, LangRes.FILD_TIPS_DSTFILE, "");

        A1010000.getLangUtil().setWText(bt_CDstFile, LangRes.BUTN_TEXT_DSTFILE, "");
        A1010000.getLangUtil().setWTips(bt_CDstFile, LangRes.BUTN_TIPS_DSTFILE, "");

        // 日志
        A1010000.getLangUtil().setWText(lb_Log, LangRes.LABL_TEXT_LOG, "");
        A1010000.getLangUtil().setWTips(lb_Log, LangRes.LABL_TIPS_LOG, "");

        A1010000.getLangUtil().setWText(ck_LogMultiLine, LangRes.CHCK_TEXT_LOG1, "");
        A1010000.getLangUtil().setWTips(ck_LogMultiLine, LangRes.CHCK_TIPS_LOG1, "");

        A1010000.getLangUtil().setWText(ck_LogSingleLine, LangRes.CHCK_TEXT_LOG2, "");
        A1010000.getLangUtil().setWTips(ck_LogSingleLine, LangRes.CHCK_TIPS_LOG2, "");

        A1010000.getLangUtil().setWText(ck_LogExceptions, LangRes.CHCK_TEXT_LOG3, "");
        A1010000.getLangUtil().setWTips(ck_LogExceptions, LangRes.CHCK_TIPS_LOG3, "");

        // 注释
        A1010000.getLangUtil().setWText(lb_Cmt, LangRes.LABL_TEXT_CMT, "");
        A1010000.getLangUtil().setWTips(lb_Cmt, LangRes.LABL_TIPS_CMT, "");

        A1010000.getLangUtil().setWText(ck_CmtDocument, LangRes.CHCK_TEXT_CMT1, "");
        A1010000.getLangUtil().setWTips(ck_CmtDocument, LangRes.CHCK_TIPS_CMT1, "");

        A1010000.getLangUtil().setWText(ck_CmtMultiLine, LangRes.CHCK_TEXT_CMT2, "");
        A1010000.getLangUtil().setWTips(ck_CmtMultiLine, LangRes.CHCK_TIPS_CMT2, "");

        A1010000.getLangUtil().setWText(ck_CmtSingleLine, LangRes.CHCK_TEXT_CMT3, "");
        A1010000.getLangUtil().setWTips(ck_CmtSingleLine, LangRes.CHCK_TIPS_CMT3, "");

        // 格式
        A1010000.getLangUtil().setWText(lb_Fmt, LangRes.LABL_TEXT_FMT, "");
        A1010000.getLangUtil().setWTips(lb_Fmt, LangRes.LABL_TIPS_FMT, "");

        A1010000.getLangUtil().setWText(ck_FmtSpaceChar, LangRes.CHCK_TEXT_FMT1, "");
        A1010000.getLangUtil().setWTips(ck_FmtSpaceChar, LangRes.CHCK_TIPS_FMT1, "");

        A1010000.getLangUtil().setWText(ck_FmtBlankLine, LangRes.CHCK_TEXT_FMT2, "");
        A1010000.getLangUtil().setWTips(ck_FmtBlankLine, LangRes.CHCK_TIPS_FMT2, "");

        A1010000.getLangUtil().setWText(ck_FmtReturnTrip, LangRes.CHCK_TEXT_FMT3, "");
        A1010000.getLangUtil().setWTips(ck_FmtReturnTrip, LangRes.CHCK_TIPS_FMT3, "");

        // 结果信息
        A1010000.getLangUtil().setWTips(ta_InfoArea, LangRes.AREA_TIPS_INFOAREA, "");

        tf_CSrcFile.setText("D:\\rmps\\rmp\\src");
        tf_CDstFile.setText("D:\\rmps\\pub\\src");
    }

    /**
     * 密码转换面板语言显示
     */
    private void itb()
    {
        // 转换方式
        A1010000.getLangUtil().setWText(lb_CipherTp, LangRes.LABL_TEXT_CIPHERTP, "");
        A1010000.getLangUtil().setWTips(lb_CipherTp, LangRes.LABL_TIPS_CIPHERTP, "");

        cm_CipherTp = new DefaultComboBoxModel();
        cm_CipherTp.addElement(new K1SV2S("0", LangRes.COMB_TEXT_ENCIPHER, LangRes.COMB_TIPS_ENCIPHER));
        cm_CipherTp.addElement(new K1SV2S("1", LangRes.COMB_TEXT_DECIPHER, LangRes.COMB_TIPS_DECIPHER));
        cb_CipherTp.setModel(cm_CipherTp);

        // 分块大小
        A1010000.getLangUtil().setWText(tf_CharSize, LangRes.FILD_TEXT_CHARSIZE, "");
        A1010000.getLangUtil().setWTips(tf_CharSize, LangRes.FILD_TIPS_CHARSIZE, "");

        // 密码算法
        A1010000.getLangUtil().setWText(lb_CipherNm, LangRes.LABL_TEXT_CIPHERNM, "");
        A1010000.getLangUtil().setWTips(lb_CipherNm, LangRes.LABL_TIPS_CIPHERNM, "");

        cm_CipherNm = new DefaultComboBoxModel();
        cm_CipherNm.addElement(new K1IV3S(16, "AES", "AES", "AES"));
        cb_CipherNm.setModel(cm_CipherNm);

        // 用户口令
        A1010000.getLangUtil().setWText(lb_UserPwds, LangRes.LABL_TEXT_USERPWDS, "");
        A1010000.getLangUtil().setWTips(lb_UserPwds, LangRes.LABL_TIPS_USERPWDS, "");

        A1010000.getLangUtil().setWText(tf_UserPwds, LangRes.FILD_TEXT_USERPWDS, "");
        A1010000.getLangUtil().setWTips(tf_UserPwds, LangRes.FILD_TIPS_USERPWDS, "");

        // 随机口令
        A1010000.getLangUtil().setWText(ck_RandomKey, LangRes.CHCK_TEXT_RANDOMKEY, "");
        A1010000.getLangUtil().setWTips(ck_RandomKey, LangRes.CHCK_TIPS_RANDOMKEY, "");

        // 来源文件
        A1010000.getLangUtil().setWText(lb_SSrcFile, LangRes.LABL_TEXT_SRCFILE, "");
        A1010000.getLangUtil().setWTips(lb_SSrcFile, LangRes.LABL_TIPS_SRCFILE, "");

        A1010000.getLangUtil().setWText(tf_SSrcFile, LangRes.FILD_TEXT_SSRCFILE, "");
        A1010000.getLangUtil().setWTips(tf_SSrcFile, LangRes.FILD_TIPS_SSRCFILE, "");

        A1010000.getLangUtil().setWText(bt_SSrcFile, LangRes.BUTN_TEXT_SRCFILE, "");
        A1010000.getLangUtil().setWTips(bt_SSrcFile, LangRes.BUTN_TIPS_SRCFILE, "");
    }

    /**
     * 高级面板语言显示
     */
    private void itc()
    {
        // 注释清理
        A1010000.getLangUtil().setWText(rb_Comment, LangRes.RBTN_TEXT_COMMENT, "");
        A1010000.getLangUtil().setWTips(rb_Comment, LangRes.RBTN_TIPS_COMMENT, "");

        // 代码安全
        A1010000.getLangUtil().setWText(rb_CodeSec, LangRes.RBTN_TEXT_CODESEC, "");
        A1010000.getLangUtil().setWTips(rb_CodeSec, LangRes.RBTN_TIPS_CODESEC, "");

        // 按钮
        A1010000.getLangUtil().setWText(bt_DoCipher, LangRes.BUTN_TEXT_COMMENT, "");
        A1010000.getLangUtil().setWTips(bt_DoCipher, LangRes.BUTN_TIPS_COMMENT, "");
    }

    // ////////////////////////////////////////////////////////////////////////
    // 事件处理区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @param evt
     */
    private void bt_CSrcFile_Handler(java.awt.event.ActionEvent evt)
    {
        JFileChooser fc = new JFileChooser();
        fc.setFileSelectionMode(JFileChooser.FILES_AND_DIRECTORIES);
        fc.setMultiSelectionEnabled(false);
        fc.setSelectedFile(srcFilePath);
        int status = fc.showOpenDialog(this);

        // 确认打开文件
        if (JFileChooser.APPROVE_OPTION == status)
        {
            srcFilePath = fc.getSelectedFile();
            this.tf_CSrcFile.setText(srcFilePath.getAbsolutePath());
            return;
        }

        // 文件打开出错
        if (JFileChooser.ERROR_OPTION == status)
        {
            MesgUtil.showMessageDialog(this, LangRes.MESG_0008);
            return;
        }

        // 用户取消打开文件操作
        if (JFileChooser.CANCEL_OPTION == status)
        {
        }
    }

    /**
     * @param evt
     */
    private void bt_CDstFile_Handler(java.awt.event.ActionEvent evt)
    {
        JFileChooser fc = new JFileChooser();
        fc.setFileSelectionMode(JFileChooser.FILES_AND_DIRECTORIES);
        fc.setMultiSelectionEnabled(false);
        fc.setSelectedFile(dstFilePath);
        int status = fc.showOpenDialog(this);

        // 确认打开文件
        if (JFileChooser.APPROVE_OPTION == status)
        {
            dstFilePath = fc.getSelectedFile();
            this.tf_CDstFile.setText(dstFilePath.getAbsolutePath());
            return;
        }

        // 文件打开出错
        if (JFileChooser.ERROR_OPTION == status)
        {
            MesgUtil.showMessageDialog(this, LangRes.MESG_0008);
            return;
        }

        // 用户取消打开文件操作
        if (JFileChooser.CANCEL_OPTION == status)
        {
        }
    }

    /**
     * 运算按钮事件处理
     * 
     * @param evt
     */
    private void bt_DoCipher_Handler(java.awt.event.ActionEvent evt)
    {
        // 注释管理
        if (rb_Comment.isSelected())
        {
            delComment();
            return;
        }

        // 代码安全
        if (rb_CodeSec.isSelected())
        {
            codeSafe();
        }
    }

    /**
     * 选择文件按钮事件处理
     * 
     * @param evt
     */
    private void bt_SSrcFile_Handler(java.awt.event.ActionEvent evt)
    {
        JFileChooser fc = new JFileChooser();
        fc.setMultiSelectionEnabled(false);
        fc.setSelectedFile(srcFilePath);
        int status = fc.showOpenDialog(this);

        // 确认打开文件
        if (JFileChooser.APPROVE_OPTION == status)
        {
            srcFilePath = fc.getSelectedFile();
            this.tf_SSrcFile.setText(srcFilePath.getAbsolutePath());
            return;
        }

        // 文件打开出错
        if (JFileChooser.ERROR_OPTION == status)
        {
            MesgUtil.showMessageDialog(this, LangRes.MESG_0008);
            return;
        }

        // 用户取消打开文件操作
        if (JFileChooser.CANCEL_OPTION == status)
        {
        }
    }

    /**
     * @param evt
     */
    private void cb_CipherTp_Handler(java.awt.event.ItemEvent evt)
    {
        if (cb_CipherTp.getSelectedIndex() == 1)
        {
            ck_RandomKey.setVisible(false);
        }
        else
        {
            ck_RandomKey.setVisible(true);
        }
    }

    /**
     * 使用随机口令复选框事件处理
     * 
     * @param evt
     */
    private void ck_RandomKey_Handler(java.awt.event.ItemEvent evt)
    {
        if (ck_RandomKey.isSelected())
        {
            tf_UserPwds.setText("");
            tf_UserPwds.setEditable(false);
        }
        else
        {
            tf_UserPwds.setEditable(true);
        }
    }

    /**
     * @param evt
     */
    private void rb_CodeSec_Handler(java.awt.event.ItemEvent evt)
    {
        if (rb_CodeSec.isSelected())
        {
            cl_CardLayout.show(pl_CardPanel, "secpanel");

            // 运算
            A1010000.getLangUtil().setWText(bt_DoCipher, LangRes.BUTN_TEXT_CODESEC, "");
            A1010000.getLangUtil().setWTips(bt_DoCipher, LangRes.BUTN_TIPS_CODESEC, "");
        }
    }

    /**
     * @param evt
     */
    private void rb_Comment_Handler(java.awt.event.ItemEvent evt)
    {
        if (rb_Comment.isSelected())
        {
            cl_CardLayout.show(pl_CardPanel, "cmtpanel");

            // 按钮
            A1010000.getLangUtil().setWText(bt_DoCipher, LangRes.BUTN_TEXT_COMMENT, "");
            A1010000.getLangUtil().setWTips(bt_DoCipher, LangRes.BUTN_TIPS_COMMENT, "");
        }
    }

    // ////////////////////////////////////////////////////////////////////////
    // 公共方法区域
    // ////////////////////////////////////////////////////////////////////////
    // ----------------------------------------------------
    // 注释清除区域
    // ----------------------------------------------------
    /**
     * 注释清除
     */
    private void delComment()
    {
        // 来源文件路径为空检测
        if (!CheckUtil.isValidate(tf_CSrcFile.getText()))
        {
            MesgUtil.showMessageDialog(this, LangRes.MESG_0001);
            this.bt_CSrcFile.requestFocus();
            return;
        }

        // 来源文件不存在
        srcFilePath = new File(tf_CSrcFile.getText());
        if (!srcFilePath.exists())
        {
            MesgUtil.showMessageDialog(this, LangRes.MESG_0001);
            this.bt_CSrcFile.requestFocus();
            return;
        }

        // 目标文件路径为空检测
        if (!CheckUtil.isValidate(tf_CDstFile.getText()))
        {
            MesgUtil.showMessageDialog(this, LangRes.MESG_0003);
            this.bt_CDstFile.requestFocus();
            return;
        }

        // 创建目标文件
        dstFilePath = new File(tf_CDstFile.getText());
        if (!dstFilePath.exists())
        {
            MesgUtil.showMessageDialog(this, LangRes.MESG_0004);
            this.bt_CDstFile.requestFocus();
            return;
        }

        WComment comment = new WComment();

        // ------------------------------------------------
        // 日志
        // ------------------------------------------------
        // 调试日志
        comment.setDelLogMultiLine(ck_LogMultiLine.isSelected());
        // 消息日志
        comment.setDelLogSingleLine(ck_LogSingleLine.isSelected());
        // 异常日志
        comment.setDelLogExceptions(ck_LogExceptions.isSelected());

        // ------------------------------------------------
        // 注释
        // ------------------------------------------------
        // 文档注释
        comment.setDelCmtDocument(ck_CmtDocument.isSelected());
        // 多行注释
        comment.setDelCmtMultiLine(ck_CmtMultiLine.isSelected());
        // 单行注释
        comment.setDelCmtSingleLine(ck_CmtSingleLine.isSelected());

        // ------------------------------------------------
        // 空格
        // ------------------------------------------------
        // 空格
        comment.setTrimSpaceChar(ck_FmtSpaceChar.isSelected());
        // 空行
        comment.setTrimBlankLine(ck_FmtBlankLine.isSelected());
        // 回行
        comment.setTrimReturnTrip(ck_FmtReturnTrip.isSelected());

        // 注释管理选项检测
        boolean b = false;
        b |= comment.isDelLogMultiLine();
        b |= comment.isDelLogSingleLine();
        b |= comment.isDelLogExceptions();
        b |= comment.isDelCmtDocument();
        b |= comment.isDelCmtMultiLine();
        b |= comment.isDelCmtSingleLine();
        b |= comment.isTrimSpaceChar();
        b |= comment.isTrimBlankLine();
        b |= comment.isTrimReturnTrip();
        if (!b)
        {
            MesgUtil.showMessageDialog(this, LangRes.MESG_0005);
            return;
        }

        // 获取文件列表
        List<File> fileList = Util.listFiles(srcFilePath);
        if (fileList == null || fileList.size() < 1)
        {
            MesgUtil.showMessageDialog(this, LangRes.MESG_0006);
            return;
        }

        // 日期格式
        DateFormat dateFormat = SimpleDateFormat.getDateTimeInstance();
        Calendar calendar = Calendar.getInstance();

        String date = dateFormat.format(calendar.getTime());
        ta_InfoArea.setText(date + " 注释清除开始...");

        // 注释清除处理
        String src = tf_CSrcFile.getText();
        String dst = tf_CDstFile.getText();
        int sec = 0;
        int fail = 0;
        for (File file : fileList)
        {
            b = fileProc(file, new File(file.getAbsolutePath().replace(src, dst)), comment);
            if (b)
            {
                sec += 1;
            }
            else
            {
                fail += 1;
            }
        }

        date = dateFormat.format(calendar.getTime());
        date = A1010000.getLangUtil().getMesg(LangRes.AREA_TEXT_INFOAREA, "").replace("{now}", date);
        date = date.replace("{sum}", Integer.toString(fileList.size()));
        date = date.replace("{sec}", Integer.toString(sec));
        date = date.replace("{fail}", Integer.toString(fail));
        ta_InfoArea.append('\n' + date);

        // 提示处理成功
        MesgUtil.showMessageDialog(this, LangRes.MESG_0009);
    }

    /**
     * 代码清除事件处理
     * 
     * @param srcFile
     * @param dstFile
     * @param comment
     * @return
     */
    private boolean fileProc(File srcFile, File dstFile, WComment comment)
    {
        try
        {
            // 创建目标文件
            File parent = dstFile.getParentFile();
            if (!parent.exists())
            {
                parent.mkdirs();
            }
            dstFile.createNewFile();

            // 缓冲字符输入流
            BufferedReader srcReader = FileUtil.getReader(srcFile, SysCons.FILE_ENCODING);
            // 缓冲字符输出流
            BufferedWriter dstWriter = FileUtil.getWriter(dstFile, SysCons.FILE_ENCODING);

            boolean inMultiLineLog = false;
            boolean inJavaDocComment = false;
            boolean inMultiLineComment = false;
            int currLine = 0;
            String readLine;
            String trimLine;

            while (true)
            {
                // 读取一行记录数据
                readLine = srcReader.readLine();
                currLine += 1;

                // 文件结束判断
                if (readLine == null)
                {
                    ta_InfoArea.append("\n\t文档结束");
                    ta_InfoArea.append("\n\t\t行" + currLine);
                    break;
                }

                trimLine = readLine.trim();

                // 调试日志
                if (comment.isDelLogMultiLine())
                {
                    if (trimLine.startsWith("// -->"))
                    {
                        if (!trimLine.startsWith("// <--"))
                        {
                            ta_InfoArea.append("\n\t调试日志");
                            inMultiLineLog = true;
                        }
                        ta_InfoArea.append("\n\t\t行" + currLine + "：" + trimLine);
                        continue;
                    }
                    if (inMultiLineLog)
                    {
                        if (trimLine.startsWith("// <--"))
                        {
                            inMultiLineLog = false;
                        }
                        ta_InfoArea.append("\n\t\t行" + currLine + "：" + trimLine);
                        continue;
                    }
                }

                // 消息日志
                if (comment.isDelLogSingleLine())
                {
                    if (trimLine.startsWith("LogUtil.log("))
                    {
                        ta_InfoArea.append("\n\t消息日志");
                        ta_InfoArea.append("\n\t\t行" + currLine + "：" + trimLine);
                        continue;
                    }
                }

                // 异常日志
                if (comment.isDelLogExceptions())
                {
                    if (trimLine.startsWith("LogUtil.exception("))
                    {
                        ta_InfoArea.append("\n\t异常日志");
                        ta_InfoArea.append("\n\t\t行" + currLine + "：" + trimLine);
                        continue;
                    }
                }

                // 删除文档注释
                if (comment.isDelCmtDocument())
                {
                    if (trimLine.startsWith("/**"))
                    {
                        if (!trimLine.endsWith("*/"))
                        {
                            ta_InfoArea.append("\n\t文档注释");
                            inJavaDocComment = true;
                        }
                        ta_InfoArea.append("\n\t\t行" + currLine + "：" + trimLine);
                        continue;
                    }
                    if (inJavaDocComment)
                    {
                        if (trimLine.endsWith("*/"))
                        {
                            inJavaDocComment = false;
                        }
                        ta_InfoArea.append("\n\t\t行" + currLine + "：" + trimLine);
                        continue;
                    }
                }

                // 删除多行注释
                if (comment.isDelCmtMultiLine())
                {
                    if (trimLine.startsWith("/*"))
                    {
                        if (!trimLine.endsWith("*/"))
                        {
                            ta_InfoArea.append("\n\t多行注释");
                            inMultiLineComment = true;
                        }
                        ta_InfoArea.append("\n\t\t行" + currLine + "：" + trimLine);
                        continue;
                    }
                    if (inMultiLineComment)
                    {
                        if (trimLine.endsWith("*/"))
                        {
                            inMultiLineComment = false;
                        }
                        ta_InfoArea.append("\n\t\t行" + currLine + "：" + trimLine);
                        continue;
                    }
                }

                // 删除单行注释
                if (comment.isDelCmtSingleLine())
                {
                    if (trimLine.startsWith("//"))
                    {
                        ta_InfoArea.append("\n\t单行注释");
                        ta_InfoArea.append("\n\t\t行" + currLine + "：" + trimLine);
                        continue;
                    }
                }

                // 清除空格
                if (comment.isTrimSpaceChar())
                {
                    readLine = trimLine;
                }

                // 清除空行
                if (comment.isTrimBlankLine())
                {
                    if (trimLine.length() < 1)
                    {
                        continue;
                    }
                }

                dstWriter.write(readLine);

                // 清除回行
                if (comment.isTrimReturnTrip())
                {
                    continue;
                }

                dstWriter.newLine();
            }

            dstWriter.close();
            srcReader.close();

            return true;
        }
        catch (Exception exp)
        {
            MesgUtil.showMessageDialog(this, LangRes.MESG_0007);
            LogUtil.exception(exp);
            return false;
        }
    }

    // ----------------------------------------------------
    // 代码转换区域
    // ----------------------------------------------------
    /**
     * 
     */
    private void codeSafe()
    {
        // 输入合法性检测
        if (!checkInput())
        {
            return;
        }

        // 取得用户口令
        byte[] pwds = tf_UserPwds.getText().getBytes();

        K1IV3S kv = (K1IV3S) cb_CipherNm.getSelectedItem();

        // ------------------------------------------------
        // 解密处理
        // ------------------------------------------------
        if (cb_CipherTp.getSelectedIndex() == 1)
        {
            // 创建加密算法实例
            Cipher cipher = null;
            try
            {
                cipher = createCipher(kv.getV3(), pwds, Cipher.DECRYPT_MODE, kv.getK());
            }
            catch (Exception exp)
            {
                LogUtil.exception(exp);
                MesgUtil.showMessageDialog(this, "加密失败：加密算法创建错误！");
                return;
            }

            text2File(cipher, srcFilePath);

            return;
        }

        // ------------------------------------------------
        // 加密处理
        // ------------------------------------------------
        // 加密结果分块大小
        int size;
        try
        {
            size = Integer.parseInt(tf_CharSize.getText());
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            MesgUtil.showMessageDialog(this, "代码分块大小输入信息出错，请输入一个合适的数值！");
            return;
        }
        // 创建加密算法实例
        Cipher cipher = null;
        try
        {
            cipher = createCipher(kv.getV3(), pwds, Cipher.ENCRYPT_MODE, kv.getK());
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            MesgUtil.showMessageDialog(this, "加密失败：加密算法创建错误！");
            return;
        }

        file2Text(cipher, srcFilePath, size);
    }

    /**
     * 用户输入数据合法性检测
     * 
     * @return
     */
    private boolean checkInput()
    {
        // 转换方式检测
        Object obj = cm_CipherTp.getSelectedItem();
        if (obj == null)
        {
            MesgUtil.showMessageDialog(this, "请选择您要进行的密码转换方式！");
            this.cb_CipherTp.requestFocus();
            return false;
        }

        // 分块大小检测
        if (!CheckUtil.isValidate(tf_CharSize.getText()))
        {
            tf_CharSize.setText("8192");
        }

        // 密码算法检测
        obj = cm_CipherNm.getSelectedItem();
        if (obj == null)
        {
            MesgUtil.showMessageDialog(this, "请选择您要进行密码运算的密码算法！");
            this.cb_CipherNm.requestFocus();
            return false;
        }

        // 用户口令检测
        if (ck_RandomKey.isVisible() && ck_RandomKey.isSelected())
        {
            // 使用随机口令
            tf_UserPwds.setText(createPwds());
        }
        // 用户输入口令校验
        else if (!CheckUtil.isValidate(tf_UserPwds.getText()))
        {
            MesgUtil.showMessageDialog(this, "请输入您要进行密码算法的口令，或者选择使用随机口令!");
            this.tf_UserPwds.requestFocus();
            return false;
        }

        // 文件路径检测
        if (!CheckUtil.isValidate(tf_SSrcFile.getText()))
        {
            MesgUtil.showMessageDialog(this, "请选择您进行密码转换处理的文件！");
            this.bt_SSrcFile.requestFocus();
            return false;
        }

        // 文件存在性判断
        if (!srcFilePath.exists() || !srcFilePath.isFile() || !srcFilePath.canRead())
        {
            MesgUtil.showMessageDialog(this, "文件 " + srcFilePath.getAbsolutePath() + " 不存在，请重新选择！");
            this.bt_SSrcFile.requestFocus();
            return false;
        }

        return true;
    }

    /**
     * 创建随机口令
     */
    private String createPwds()
    {
        char[] c = new char[94];
        for (char i = 0; i < 94; i += 1)
        {
            c[i] = (char) (33 + i);
        }

        try
        {
            return new String(HashUtil.nextRandomKey(c, 48, true));
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            return null;
        }
    }

    /**
     * 创建密文空间
     * 
     * @return
     */
    private char[] createKeys()
    {
        char[] c = new char[94];
        for (char i = 0; i < 94; i += 1)
        {
            c[i] = (char) (33 + i);
        }

        try
        {
            return HashUtil.nextRandomKey(c, 16, true);
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            return null;
        }
    }

    /**
     * 创建加密算法
     * 
     * @param algorithm 加密算法
     * @param userPwd 用户口令
     * @param mode 加密模式
     * @param keySize 密钥大小
     * @return
     * @throws Exception
     */
    private Cipher createCipher(String algorithm, byte[] userPwd, int mode, int keySize) throws Exception
    {
        Cipher cipher = Cipher.getInstance(algorithm);
        SecureKey sKey = new SecureKey(algorithm, userPwd, keySize);
        cipher.init(mode, sKey);
        return cipher;
    }

    /**
     * 由文件到文本加密
     * 
     * @param cipher 加密算法对象
     * @param srcFile 来源数据文档
     * @param blockSize 加密结果分块大小
     */
    private void file2Text(Cipher cipher, File srcFile, int blockSize)
    {
        // 创建加密结果文档
        File dstFile = new File(srcFile.getParent(), srcFile.getName() + SysCons.EXTS_TEXT);
        if (dstFile.exists())
        {
            if (0 != MesgUtil.showConfirmDialog(this, "已存在同名文档 " + dstFile.getPath() + "，是否要覆盖此文档？"))
            {
                return;
            }
        }
        else
        {
            try
            {
                dstFile.createNewFile();
            }
            catch (Exception exp)
            {
                LogUtil.exception(exp);
                MesgUtil.showMessageDialog(this, "无法创建文档 " + dstFile.getPath() + "，请确认您对此目录是否有足够的访问权限！");
                return;
            }
        }

        // 加密结果文档可访问性判断
        if (!dstFile.isFile() || !dstFile.canWrite())
        {
            MesgUtil.showMessageDialog(this, "无法访问文档 " + dstFile.getPath() + "，请确认您对此文档是否有足够的访问权限！");
            return;
        }

        // 创建文档输出流
        BufferedWriter bufWriter = null;
        try
        {
            bufWriter = new BufferedWriter(new OutputStreamWriter(new FileOutputStream(dstFile)));
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            MesgUtil.showMessageDialog(this, "无法访问文档 " + dstFile.getPath() + "，请确认您对此文档是否有足够的访问权限！");
            return;
        }

        // 创建文档输入流
        FileInputStream fis = null;
        try
        {
            fis = new FileInputStream(srcFile);
        }
        catch (FileNotFoundException exp)
        {
            LogUtil.exception(exp);
            MesgUtil.showMessageDialog(this, "无法访问文档 " + srcFile.getPath() + "，请确认您对此文档是否有足够的访问权限！");
            return;
        }

        try
        {
            // 密文字符空间
            char[] keys = createKeys();
            // 缓冲字节数组
            byte[] readBytes = new byte[blockSize >> 1];
            // 分块索引
            int partIndx = 1;

            // 写入密文字符空间
            bufWriter.write(keys);

            // 读取文档数据
            int len = fis.read(readBytes);
            while (len >= 0)
            {
                // 分块标记
                bufWriter.newLine();
                bufWriter.write("//part:" + (partIndx++));

                // 加密结果
                bufWriter.newLine();
                bufWriter.write(StringUtil.bytesToString(keys, cipher.update(readBytes, 0, len)));

                // 读取文档数据
                len = fis.read(readBytes);
            }

            // 分块标记
            bufWriter.newLine();
            bufWriter.write("//part:" + (partIndx++));

            // 加密结果
            bufWriter.newLine();
            bufWriter.write(StringUtil.bytesToString(keys, cipher.doFinal()));
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            MesgUtil.showMessageDialog(this, "加密转换运算出现未知错误！");
            return;
        }
        finally
        {
            if (fis != null)
            {
                try
                {
                    fis.close();
                }
                catch (IOException e)
                {
                    e.printStackTrace();
                }
            }
            if (bufWriter != null)
            {
                try
                {
                    bufWriter.flush();
                    bufWriter.close();
                }
                catch (IOException e)
                {
                    e.printStackTrace();
                }
            }
        }

        // 提示处理成功
        MesgUtil.showMessageDialog(this, LangRes.MESG_0010);
    }

    /**
     * 由文本到文件加密
     * 
     * @param cipher 加密算法对象
     * @param srcFile 来源数据文档
     */
    private void text2File(Cipher cipher, File srcFile)
    {
        // 创建加密结果文档
        String fileName = srcFile.getName();
        fileName = fileName.substring(0, fileName.length() - SysCons.EXTS_TEXT.length());
        File dstFile = new File(srcFile.getParent(), fileName);
        if (dstFile.exists())
        {
            if (0 != MesgUtil.showConfirmDialog(this, "已存在同名文档 " + dstFile.getPath() + "，是否要覆盖此文档？"))
            {
                return;
            }
        }
        else
        {
            try
            {
                dstFile.createNewFile();
            }
            catch (Exception exp)
            {
                LogUtil.exception(exp);
                MesgUtil.showMessageDialog(this, "无法创建文档 " + dstFile.getPath() + "，请确认您对此目录是否有足够的访问权限！");
                return;
            }
        }

        // 加密结果文档可访问性判断
        if (!dstFile.isFile() || !dstFile.canWrite())
        {
            MesgUtil.showMessageDialog(this, "无法访问文档 " + dstFile.getPath() + "，请确认您对此文档是否有足够的访问权限！");
            return;
        }

        // 创建文档输出流
        FileOutputStream fos;
        try
        {
            fos = new FileOutputStream(dstFile);
        }
        catch (FileNotFoundException exp)
        {
            LogUtil.exception(exp);
            MesgUtil.showMessageDialog(this, "无法访问文档 " + dstFile.getPath() + "，请确认您对此文档是否有足够的访问权限！");
            return;
        }

        // 创建文档数据输入流
        BufferedReader bufReader = null;
        try
        {
            bufReader = new BufferedReader(new InputStreamReader(new FileInputStream(srcFile)));
        }
        catch (FileNotFoundException exp)
        {
            LogUtil.exception(exp);
            MesgUtil.showMessageDialog(this, "无法访问文档 " + srcFile.getPath() + "，请确认您对此文档是否有足够的访问权限！");
            return;
        }

        try
        {
            // 字符空间
            String text = bufReader.readLine();
            if (!CheckUtil.isValidate(text))
            {
                return;
            }
            char[] keys = text.toCharArray();

            // 块标记
            bufReader.readLine();
            text = bufReader.readLine();

            byte[] temp;
            while (text != null)
            {
                // 解密结果
                temp = StringUtil.stringToBytes(text, keys);
                temp = cipher.update(temp);
                if (temp != null)
                {
                    fos.write(temp);
                }

                // 块标记
                bufReader.readLine();

                text = bufReader.readLine();
            }

            fos.write(cipher.doFinal());
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            MesgUtil.showMessageDialog(this, "加密转换运算出现未知错误！");
            return;
        }
        finally
        {
            if (bufReader != null)
            {
                try
                {
                    bufReader.close();
                }
                catch (IOException e)
                {
                    e.printStackTrace();
                }
            }

            if (fos != null)
            {
                try
                {
                    fos.close();
                }
                catch (IOException e)
                {
                    e.printStackTrace();
                }
            }
        }

        // 提示处理成功
        MesgUtil.showMessageDialog(this, LangRes.MESG_0011);
    }
    // ////////////////////////////////////////////////////////////////////////
    // 界面变量区域
    // ////////////////////////////////////////////////////////////////////////
    // 注释清除
    private javax.swing.JPanel pl_CmtPanel;
    private javax.swing.JButton bt_CDstFile;
    private javax.swing.JButton bt_CSrcFile;
    private javax.swing.JCheckBox ck_CmtDocument;
    private javax.swing.JCheckBox ck_CmtMultiLine;
    private javax.swing.JCheckBox ck_CmtSingleLine;
    private javax.swing.JCheckBox ck_FmtBlankLine;
    private javax.swing.JCheckBox ck_FmtReturnTrip;
    private javax.swing.JCheckBox ck_FmtSpaceChar;
    private javax.swing.JCheckBox ck_LogExceptions;
    private javax.swing.JCheckBox ck_LogMultiLine;
    private javax.swing.JCheckBox ck_LogSingleLine;
    private javax.swing.JLabel lb_Cmt;
    private javax.swing.JLabel lb_CDstFile;
    private javax.swing.JLabel lb_CSrcFile;
    private javax.swing.JLabel lb_Fmt;
    private javax.swing.JLabel lb_Log;
    private javax.swing.JTextField tf_CDstFile;
    private javax.swing.JTextField tf_CSrcFile;
    private javax.swing.JTextArea ta_InfoArea;
    // 密码处理
    private javax.swing.JPanel pl_SecPanel;
    private javax.swing.JButton bt_SSrcFile;
    private javax.swing.JCheckBox ck_RandomKey;
    private javax.swing.JComboBox cb_CipherTp;
    private javax.swing.JComboBox cb_CipherNm;
    private javax.swing.JLabel lb_CipherTp;
    private javax.swing.JLabel lb_CipherNm;
    private javax.swing.JLabel lb_SSrcFile;
    private javax.swing.JLabel lb_UserPwds;
    private javax.swing.JTextField tf_CharSize;
    private javax.swing.JTextField tf_SSrcFile;
    private javax.swing.JTextField tf_UserPwds;
    private javax.swing.JPanel pl_CardPanel;
    private javax.swing.JPanel pl_UserPanel;
    private javax.swing.JRadioButton rb_CodeSec;
    private javax.swing.JRadioButton rb_Comment;
    private javax.swing.JButton bt_DoCipher;
    /** serialVersionUID */
    private static final long serialVersionUID = -6956622260525395178L;
}
