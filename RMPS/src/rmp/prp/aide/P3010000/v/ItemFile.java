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
import rmp.prp.aide.P3010000.b.WListForm;
import rmp.prp.aide.P3010000.i.WItem;
import rmp.prp.aide.extparse.Extparse;
import rmp.prp.aide.extparse.b.WIconBox;
import rmp.prp.aide.extparse.d.DA0008;
import rmp.prp.aide.extparse.m.FileBaseData;
import rmp.prp.aide.extparse.m.FileUserData;
import rmp.util.BeanUtil;
import rmp.util.EnvUtil;
import rmp.util.LogUtil;
import rmp.util.MesgUtil;
import rmp.util.StringUtil;
import cons.prp.aide.P3010000.ConstUI;
import cons.prp.aide.P3010000.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 文件信息数据管理面板
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class ItemFile extends javax.swing.JPanel implements WItem, WBackCall
{
    // ////////////////////////////////////////////////////////////////////////
    // 界面控制变量区域
    // ////////////////////////////////////////////////////////////////////////
    /**  */
    private static final long serialVersionUID = -9123768368126793271L;
    /** 当前状态是否为可交互状态 */
    private boolean isEditable;
    /** 当前操作是否为数据更新操作 */
    private boolean isDataUpdt;
    /** 数据是否存在 */
    private boolean isMetaExist;
    /** 软件列表数据模型 */
    private DefaultComboBoxModel cm_SoftList;
    /** 父应用引用 */
    private Extparse me_MainSoft;
    /** 用户选择文件对象 */
    private K2SV1S kv_FileItem;

    /**
     * @param soft
     */
    public ItemFile()
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    public boolean wInit()
    {
        isEditable = false;
        isDataUpdt = false;

        // 界面初始化
        ica();

        // 界面语言显示
        ita();

        cm_SoftList = new DefaultComboBoxModel();
        cb_FileSoft.setModel(cm_SoftList);

        ib_FileIcon.setIconPath(EnvUtil.getIconFileDir());

        // 软件列表初始化
        DBAccess dba = new DBAccess();
        try
        {
            if (!dba.wInit())
            {
                return false;
            }

            initSoftList(dba);
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

        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.prp.aide.P3010000.i.WItem#wViewData(java.lang.String)
     */
    @Override
    public void wViewData(String hash)
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
        if (object instanceof K2SV1S)
        {
            K2SV1S kvItem = (K2SV1S) object;

            // 数据查询
            FileBaseData baseMeta = queryByHash(kvItem.getK1());
            setBaseData(baseMeta);
        }
    }

    /**
     * @param fileHash
     * @return
     */
    public static FileBaseData queryByHash(String fileHash)
    {
        DBAccess dba = new DBAccess();

        try
        {
            FileBaseData baseMeta = null;
            if (dba.wInit())
            {
                baseMeta = queryByHash(dba, fileHash);
            }
            return baseMeta;
        }
        catch (SQLException exp)
        {
            LogUtil.exception(exp);
            return null;
        }
        finally
        {
            dba.closeConnection();
        }
    }

    /**
     * @param dba
     * @param fileHash
     * @return
     * @throws SQLException
     */
    public static FileBaseData queryByHash(DBAccess dba, String fileHash) throws SQLException
    {
        return DA0008.selectFileMetaInfo(dba, fileHash);
    }

    /**
     * @param softHash
     * @param fileSign
     * @return
     */
    public static List<K2SV1S> queryByName(String softHash, String fileSign)
    {
        DBAccess dba = new DBAccess();

        try
        {
            List<K2SV1S> fileList = null;
            if (dba.wInit())
            {
                fileList = queryByName(dba, softHash, fileSign);
            }
            return fileList;
        }
        catch (SQLException exp)
        {
            LogUtil.exception(exp);
            return null;
        }
        finally
        {
            dba.closeConnection();
        }
    }

    /**
     * @param dba
     * @param softHash
     * @param fileSign
     * @return
     * @throws SQLException
     */
    public static List<K2SV1S> queryByName(DBAccess dba, String softHash, String fileSign) throws SQLException
    {
        return DA0008.selectFileMetaName(dba, softHash, fileSign);
    }

    // ////////////////////////////////////////////////////////////////////////
    // 公共接口区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 文件信息删除事件处理
     */
    public boolean metaDelete(FileUserData userMeta)
    {
        // 用户删除确认
        String arg1 = Extparse.getMesg(LangRes.FILE_COMN_TEXT_SIGNCHAR);
        String arg2 = Extparse.getMesg(LangRes.TITLE_FILEFORM);
        String errMsg = StringUtil.format(LangRes.MESG_DELT_0007, arg1, userMeta.getSignChar(), arg2);
        if (MesgUtil.showConfirmDialog(Extparse.getForm(), errMsg) != 0)
        {
            return false;
        }

        // 连接数据库
        DBAccess dba = new DBAccess();

        try
        {
            if (!dba.wInit())
            {
                return false;
            }

            // 执行数据删除
            DA0008.deleteFileMeta(dba, userMeta);
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            String mesg = StringUtil.format(LangRes.MESG_DELT_0006, LangRes.TITLE_FILEFORM, LangRes.MESG_INIT_0010);
            MesgUtil.showMessageDialog(Extparse.getForm(), mesg);
            return false;
        }
        finally
        {
            // 数据提交
            dba.closeConnection();
        }

        return true;
    }

    /**
     * @param fileHash
     * @return
     */
    public boolean hashSelect(String fileHash)
    {
        return setBaseData(queryByHash(fileHash));
    }

    /**
     * 按魔术签名查询文件详细信息
     * 
     * @return
     */
    public boolean nameSelect(String softHash, String fileSign)
    {
        DBAccess dba = new DBAccess();

        List<K2SV1S> softList = null;
        try
        {
            if (!dba.wInit())
            {
                return false;
            }

            // 数据查询
            softList = queryByName(dba, softHash, fileSign);

            if (softList != null && softList.size() == 1)
            {
                return setBaseData(queryByHash(softList.get(0).getK1()));
            }
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

        // 错误处理
        if (softList == null)
        {
            String mesg = StringUtil.format(LangRes.MESG_SELT_0004, LangRes.MESG_INIT_0010);
            MesgUtil.showMessageDialog(null, mesg);
            return false;
        }
        // 数据为空
        else if (softList.size() == 0)
        {
            MesgUtil.showMessageDialog(null, Extparse.getMesg(LangRes.MESG_SELT_0003));
        }
        // 多个结果
        else
        {
            String mesg = Extparse.getMesg(LangRes.TITLE_FILEFORM);
            WListForm.showDialog(null, mesg, softList, this);
        }
        return true;
    }

    /**
     * 文件信息更新处理
     */
    public boolean metaUpdate(FileUserData userMeta)
    {
        // 连接数据库
        DBAccess dba = new DBAccess();

        try
        {
            if (!dba.wInit())
            {
                return false;
            }

            // 数据更新
            DA0008.updateFileMeta(dba, userMeta);
        }
        catch (SQLException exp)
        {
            LogUtil.exception(exp);
            String mesg = StringUtil.format(LangRes.MESG_UPDT_0005, LangRes.TITLE_FILEFORM, LangRes.MESG_INIT_0010);
            MesgUtil.showMessageDialog(Extparse.getForm(), mesg);
            return false;
        }
        finally
        {
            dba.closeConnection();
        }

        // filePath = null;

        return true;
    }

    /**
     * 软件列表数据初始化
     * 
     * @throws SQLException
     */
    public void initSoftList(final DBAccess dba) throws SQLException
    {
        // 数据查询
        List<K2SV1S> softList = DA0008.selectSoftMetaName(dba, null, null);

        // 数据显示
        cm_SoftList.removeAllElements();
        kv_FileItem = softList.get(0);
        kv_FileItem.setK2("");
        K2SV1S kvItem;
        for (int i = 0, j = softList.size(); i < j; i += 1)
        {
            kvItem = softList.get(i);
            kvItem.setK2("");
            cm_SoftList.addElement(kvItem);
        }
    }

    /**
     * 
     */
    private void ica()
    {
        ib_FileIcon = new WIconBox(me_MainSoft);
        ib_FileIcon.wInit();
        lb_FileSoft = new javax.swing.JLabel();
        lb_SignChar = new javax.swing.JLabel();
        cb_FileSoft = new javax.swing.JComboBox();
        tf_SignChar = new javax.swing.JTextField();
        bt_Refers = new javax.swing.JButton();
        lb_SignCode = new javax.swing.JLabel();
        tf_SignCode = new javax.swing.JTextField();
        lb_CipherSn = new javax.swing.JLabel();
        tf_CipherSn = new javax.swing.JTextField();
        bt_Browse = new javax.swing.JButton();
        lb_FileDesp = new javax.swing.JLabel();
        javax.swing.JScrollPane sp_TextArea = new javax.swing.JScrollPane();
        ta_FileDesp = new javax.swing.JTextArea();
        bt_Delete = new javax.swing.JButton();
        bt_Update = new javax.swing.JButton();
        bt_Create = new javax.swing.JButton();

        ib_FileIcon.setToolTipText("\u516c\u53f8\u5fb5\u6807");

        lb_FileSoft.setText("\u56fd\u522b\u4fe1\u606f(A)");
        lb_FileSoft.setToolTipText("\u56fd\u522b\u4fe1\u606f");
        lb_FileSoft.setLabelFor(cb_FileSoft);

        lb_SignChar.setText("\u672c\u8bed\u540d\u79f0(L)");
        lb_SignChar.setToolTipText("\u672c\u8bed\u540d\u79f0");
        lb_SignChar.setLabelFor(tf_SignChar);

        cb_FileSoft.setToolTipText("\u56fd\u522b\u4fe1\u606f");
        cb_FileSoft.addItemListener(new java.awt.event.ItemListener()
        {
            public void itemStateChanged(java.awt.event.ItemEvent evt)
            {
                cb_FileSoft_Handler(evt);
            }
        });

        tf_SignChar.setToolTipText("\u672c\u8bed\u540d\u79f0");
        tf_SignChar.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                tf_SignChar_Handler(evt);
            }
        });

        bt_Refers.setMnemonic('V');
        bt_Refers.setText("V");
        bt_Refers.setToolTipText("\u53c2\u7167\u56fd\u522b\u4e0b\u7684\u6240\u6709\u516c\u53f8");
        bt_Refers.setMargin(new java.awt.Insets(0, 0, 0, 0));
        bt_Refers.setMaximumSize(new java.awt.Dimension(18, 18));
        bt_Refers.setMinimumSize(new java.awt.Dimension(14, 14));
        bt_Refers.setPreferredSize(new java.awt.Dimension(16, 16));
        bt_Refers.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_Refers_Handler(evt);
            }
        });

        lb_SignCode.setText("\u82f1\u8bed\u540d\u79f0(E)");
        lb_SignCode.setToolTipText("\u82f1\u8bed\u540d\u79f0");
        lb_SignCode.setLabelFor(tf_SignCode);

        tf_SignCode.setEditable(false);
        tf_SignCode.setToolTipText("\u82f1\u8bed\u540d\u79f0");

        lb_CipherSn.setText("\u516c\u53f8\u9996\u9875(W)");
        lb_CipherSn.setToolTipText("\u516c\u53f8\u9996\u9875");
        lb_CipherSn.setLabelFor(tf_CipherSn);

        tf_CipherSn.setEditable(false);
        tf_CipherSn.setToolTipText("\u516c\u53f8\u9996\u9875");

        bt_Browse.setMnemonic('B');
        bt_Browse.setText("B");
        bt_Browse.setToolTipText("\u5728\u6d4f\u89c8\u5668\u4e2d\u6253\u5f00\u6b64\u94fe\u63a5");
        bt_Browse.setMargin(new java.awt.Insets(0, 0, 0, 0));
        bt_Browse.setMaximumSize(new java.awt.Dimension(18, 18));
        bt_Browse.setMinimumSize(new java.awt.Dimension(14, 14));
        bt_Browse.setPreferredSize(new java.awt.Dimension(16, 16));
        bt_Browse.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_Browse_Handler(evt);
            }
        });

        lb_FileDesp.setText("\u76f8\u5173\u8bf4\u660e(P)");
        lb_FileDesp.setToolTipText("\u76f8\u5173\u8bf4\u660e");
        lb_FileDesp.setLabelFor(ta_FileDesp);

        ta_FileDesp.setEditable(false);
        ta_FileDesp.setLineWrap(true);
        ta_FileDesp.setRows(4);
        ta_FileDesp.setToolTipText("\u76f8\u5173\u8bf4\u660e");
        sp_TextArea.setViewportView(ta_FileDesp);

        bt_Delete.setMnemonic('D');
        bt_Delete.setText("\u5220\u9664(D)");
        bt_Delete.setToolTipText("\u5220\u9664");
        bt_Delete.setMargin(new java.awt.Insets(1, 7, 1, 7));
        bt_Delete.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_Delete_Handler(evt);
            }
        });

        bt_Update.setMnemonic('U');
        bt_Update.setText("\u66f4\u65b0(U)");
        bt_Update.setToolTipText("\u66f4\u65b0");
        bt_Update.setMargin(new java.awt.Insets(1, 7, 1, 7));
        bt_Update.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_Update_Handler(evt);
            }
        });

        bt_Create.setMnemonic('N');
        bt_Create.setText("\u65b0\u589e(N)");
        bt_Create.setToolTipText("\u65b0\u589e");
        bt_Create.setMargin(new java.awt.Insets(1, 7, 1, 7));
        bt_Create.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_Create_Handler(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_SignCode).addComponent(lb_CipherSn).addComponent(lb_FileDesp)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(tf_SignCode,
                javax.swing.GroupLayout.DEFAULT_SIZE, 235, Short.MAX_VALUE).addGroup(
                javax.swing.GroupLayout.Alignment.TRAILING,
                layout.createSequentialGroup().addComponent(tf_CipherSn, javax.swing.GroupLayout.DEFAULT_SIZE, 213,
                Short.MAX_VALUE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_Browse, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addComponent(sp_TextArea, javax.swing.GroupLayout.DEFAULT_SIZE, 235, Short.MAX_VALUE)).addContainerGap()).addGroup(
                javax.swing.GroupLayout.Alignment.TRAILING,
                layout.createSequentialGroup().addContainerGap(134, Short.MAX_VALUE).addComponent(bt_Create).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_Update).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_Delete).addGap(10,
                10, 10)).addGroup(
                layout.createSequentialGroup().addGap(10, 10, 10).addComponent(ib_FileIcon,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_FileSoft).addComponent(lb_SignChar)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addComponent(tf_SignChar, javax.swing.GroupLayout.DEFAULT_SIZE,
                162, Short.MAX_VALUE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_Refers, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addGap(
                10, 10, 10)).addGroup(
                layout.createSequentialGroup().addComponent(cb_FileSoft, 0, 184, Short.MAX_VALUE).addContainerGap()))));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false).addGroup(
                layout.createSequentialGroup().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_FileSoft).addComponent(cb_FileSoft,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE,
                Short.MAX_VALUE).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_SignChar).addComponent(bt_Refers, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(tf_SignChar, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))).addComponent(ib_FileIcon, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_SignCode).addComponent(tf_SignCode, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_CipherSn).addComponent(bt_Browse, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(
                tf_CipherSn, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_FileDesp).addComponent(sp_TextArea, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE,
                Short.MAX_VALUE).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(bt_Delete).addComponent(bt_Update).addComponent(bt_Create)).addContainerGap()));
    }

    /**
     * @param isHash
     */
    private void ita()
    {
        // 直属软件
        BeanUtil.setWText(lb_FileSoft, Extparse.getMesg(LangRes.FILE_LABL_TEXT_FILESOFT));
        BeanUtil.setWTips(lb_FileSoft, Extparse.getMesg(LangRes.FILE_LABL_TIPS_FILESOFT));

        BeanUtil.setWTips(cb_FileSoft, Extparse.getMesg(LangRes.FILE_COMB_TIPS_FILESOFT));

        // 字符签名
        BeanUtil.setWText(lb_SignChar, Extparse.getMesg(LangRes.FILE_LABL_TEXT_SIGNCHAR));
        BeanUtil.setWTips(lb_SignChar, Extparse.getMesg(LangRes.FILE_LABL_TIPS_SIGNCHAR));

        BeanUtil.setWText(tf_SignChar, Extparse.getMesg(LangRes.FILE_FILD_TEXT_SIGNCHAR));
        BeanUtil.setWTips(tf_SignChar, Extparse.getMesg(LangRes.FILE_FILD_TIPS_SIGNCHAR));

        // 数值签名
        BeanUtil.setWText(lb_SignCode, Extparse.getMesg(LangRes.FILE_LABL_TEXT_SIGNCODE));
        BeanUtil.setWTips(lb_SignCode, Extparse.getMesg(LangRes.FILE_LABL_TIPS_SIGNCODE));

        BeanUtil.setWText(tf_SignCode, Extparse.getMesg(LangRes.FILE_FILD_TEXT_SIGNCODE));
        BeanUtil.setWTips(tf_SignCode, Extparse.getMesg(LangRes.FILE_FILD_TIPS_SIGNCODE));

        // 加密算法
        BeanUtil.setWText(lb_CipherSn, Extparse.getMesg(LangRes.FILE_LABL_TEXT_CIPHERSN));
        BeanUtil.setWTips(lb_CipherSn, Extparse.getMesg(LangRes.FILE_LABL_TIPS_CIPHERSN));

        BeanUtil.setWText(tf_CipherSn, Extparse.getMesg(LangRes.FILE_FILD_TEXT_CIPHERSN));
        BeanUtil.setWTips(tf_CipherSn, Extparse.getMesg(LangRes.FILE_FILD_TIPS_CIPHERSN));

        // 相关说明
        BeanUtil.setWText(lb_FileDesp, Extparse.getMesg(LangRes.FILE_LABL_TEXT_FILEDESP));
        BeanUtil.setWTips(lb_FileDesp, Extparse.getMesg(LangRes.FILE_LABL_TIPS_FILEDESP));

        BeanUtil.setWText(ta_FileDesp, Extparse.getMesg(LangRes.FILE_AREA_TEXT_FILEDESP));
        BeanUtil.setWTips(ta_FileDesp, Extparse.getMesg(LangRes.FILE_AREA_TIPS_FILEDESP));

        // 新增按钮
        BeanUtil.setWText(bt_Create, Extparse.getMesg(LangRes.FILE_BUTN_TEXT_CREATE));
        BeanUtil.setWTips(bt_Create, Extparse.getMesg(LangRes.FILE_BUTN_TIPS_CREATE));

        // 更新按钮
        BeanUtil.setWText(bt_Update, Extparse.getMesg(LangRes.FILE_BUTN_TEXT_UPDATE));
        BeanUtil.setWTips(bt_Update, Extparse.getMesg(LangRes.FILE_BUTN_TIPS_UPDATE));

        // 删除按钮
        BeanUtil.setWText(bt_Delete, Extparse.getMesg(LangRes.FILE_BUTN_TEXT_DELETE));
        BeanUtil.setWTips(bt_Delete, Extparse.getMesg(LangRes.FILE_BUTN_TIPS_DELETE));

        // 图标
        BeanUtil.setWText(bt_Refers, Extparse.getMesg(LangRes.FILE_BUTN_TEXT_FILEVIEW));
        BeanUtil.setWTips(bt_Refers, Extparse.getMesg(LangRes.FILE_BUTN_TIPS_FILEVIEW));

        // 图标
        BeanUtil.setWTips(ib_FileIcon, Extparse.getMesg(LangRes.FILE_IMLB_TIPS_FILEICON));
    }

    // ////////////////////////////////////////////////////////////////////////
    // 事件处理区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @param evt
     */
    private void bt_Create_Handler(java.awt.event.ActionEvent evt)
    {
        // 不可交互状态时的处理：显示交互界面
        if (!isEditable)
        {
            setEditable(true);
            me_MainSoft.getSoftForm().setTitle(Extparse.getMesg(LangRes.TITLE_FILEFORM) + LangRes.TITLE_INSERT);
        }

        // 清除界面已有数据
        setDefault("");

        ib_FileIcon.setIconHash(ConstUI.DEF_FILEICON);
        me_MainSoft.getBaseData().setFileIndx(ConstUI.DEF_FILEHASH);

        // 焦点设置
        this.tf_SignChar.requestFocus();

        // 状态更新标记设置为新增状态
        isDataUpdt = false;
    }

    /**
     * @param evt
     */
    private void bt_Delete_Handler(java.awt.event.ActionEvent evt)
    {
        // 不可交互状态时的处理：删除当前用户数据
        if (!isEditable)
        {
            // 提示选择要删除的数据
            if (!isDataUpdt)
            {
                MesgUtil.showMessageDialog(Extparse.getForm(), Extparse.getMesg(LangRes.MESG_DELT_0004));
                return;
            }

            // 用户数据对象
            FileUserData userMeta = new FileUserData();
            userMeta.wInit();

            // 用户数据读取
            if (!getUserData(userMeta))
            {
                return;
            }

            // 数据删除
            if (metaDelete(userMeta))
            {
                // 清空界面显示数据
                setDefault("");

                // 状态标记设置为新增状态
                isDataUpdt = false;
            }
        }
        // 可交互状态时的处理：显示不可交互状态
        else
        {
            setEditable(false);
            me_MainSoft.getSoftForm().setTitle(Extparse.getMesg(LangRes.TITLE_FILEFORM));
        }
    }

    /**
     * @param evt
     */
    private void bt_Update_Handler(java.awt.event.ActionEvent evt)
    {
        // 不可交互状态时的处理：显示交互界面
        if (!isEditable)
        {
            setEditable(true);
            me_MainSoft.getSoftForm().setTitle(Extparse.getMesg(LangRes.TITLE_FILEFORM) + LangRes.TITLE_UPDATE);

            // 状态标记设置为更新状态
            isDataUpdt = true;
        }
        // 可交互状态时的处理：进行数据的新增更新
        else
        {
            // 用户数据对象
            FileUserData userMeta = new FileUserData();
            userMeta.wInit();

            // 用户数据读取
            if (!getUserData(userMeta, false))
            {
                return;
            }

            // 数据更新
            if (metaUpdate(userMeta))
            {
                // 清空界面显示数据
                setDefault("");

                // 状态标记设置为新增状态
                isDataUpdt = false;
            }
        }
    }

    /**
     * @param evt
     */
    private void bt_Browse_Handler(java.awt.event.ActionEvent evt)
    {
    }

    /**
     * 参照按钮事件处理
     * 
     * @param evt
     */
    private void bt_Refers_Handler(java.awt.event.ActionEvent evt)
    {
        nameSelect(ConstUI.DEF_SOFTHASH, "");
    }

    /**
     * 直属软件组合框事件处理
     * 
     * @param evt
     */
    private void cb_FileSoft_Handler(java.awt.event.ItemEvent evt)
    {
    }

    /**
     * 字符签名文本框事件处理
     * 
     * @param evt
     */
    private void tf_SignChar_Handler(java.awt.event.ActionEvent evt)
    {
        // 公司索引
        String softHash = ConstUI.DEF_SOFTHASH;
        K2SV1S kvItem = (K2SV1S) this.cb_FileSoft.getSelectedItem();
        if (kvItem != null)
        {
            softHash = kvItem.getK1();
        }

        // 软件名称
        String fileSign = this.tf_SignChar.getText();

        nameSelect(softHash, fileSign);
    }

    /**
     * 用户输入数据信息读取（仅读取关键数据信息）
     * 
     * @param userMeta
     * @return
     */
    private boolean getUserData(FileUserData userMeta)
    {
        return getUserData(userMeta, true);
    }

    /**
     * 用户输入数据信息读取
     * 
     * @param userMeta
     * @param keysOnly
     * @return
     */
    private boolean getUserData(FileUserData userMeta, boolean keysOnly)
    {
        // 数据操作状态
        userMeta.setUpdate(isDataUpdt && isMetaExist);
        // 文件索引
        userMeta.setFileIndx(me_MainSoft.getBaseData().getFileIndx());

        // 直属软件
        K2SV1S kvItem = (K2SV1S) this.cb_FileSoft.getSelectedItem();
        if (!userMeta.setSoftIndx(kvItem.getK1()))
        {
            MesgUtil.showMessageDialog(Extparse.getForm(), userMeta.getErrMsg());
            this.cb_FileSoft.requestFocus();
            return false;
        }

        // 字符签名
        if (!userMeta.setSignChar(this.tf_SignChar.getText()))
        {
            MesgUtil.showMessageDialog(Extparse.getForm(), userMeta.getErrMsg());
            this.tf_SignChar.requestFocus();
            return false;
        }

        // 仅读取关键值部分
        if (keysOnly)
        {
            return true;
        }

        // 数值签名
        if (!userMeta.setSignCode(this.tf_SignCode.getText()))
        {
            MesgUtil.showMessageDialog(Extparse.getForm(), userMeta.getErrMsg());
            this.tf_SignCode.requestFocus();
            return false;
        }

        // 加密算法
        if (!userMeta.setCipherSn(this.tf_CipherSn.getText()))
        {
            MesgUtil.showMessageDialog(Extparse.getForm(), userMeta.getErrMsg());
            this.tf_CipherSn.requestFocus();
            return false;
        }

        // 相关说明
        if (!userMeta.setFileDesp(this.ta_FileDesp.getText()))
        {
            MesgUtil.showMessageDialog(Extparse.getForm(), userMeta.getErrMsg());
            this.ta_FileDesp.requestFocus();
            return false;
        }

        // 外部图像保存
        ib_FileIcon.saveExtImage();

        // 文件图标
        userMeta.setFileIcon(ib_FileIcon.getIconHash());
        ib_FileIcon.setIconHash(ConstUI.DEF_FILEICON);

        return true;
    }

    /**
     * @param baseMeta
     * @return
     */
    private boolean setBaseData(FileBaseData baseMeta)
    {
        // 文本框数据显示
        this.tf_SignChar.setText(baseMeta.getSignChar());
        this.tf_SignCode.setText(baseMeta.getSignCode());
        this.tf_CipherSn.setText(baseMeta.getCipherSn());
        this.ta_FileDesp.setText(baseMeta.getFileDesp());

        // 组合框数据显示
        this.kv_FileItem = new K2SV1S(baseMeta.getSoftIndx(), "", baseMeta.getSoftName());
        this.cb_FileSoft.setSelectedItem(kv_FileItem);

        // 图像标签数据显示
        this.ib_FileIcon.setIconHash(baseMeta.getFileIcon());

        // 状态标记
        isDataUpdt = true;
        isMetaExist = baseMeta.isMetaExist();
        // 数据维持
        if (isMetaExist)
        {
            me_MainSoft.getBaseData().setFileIndx(baseMeta.getFileIndx());
        }
        return true;
    }

    /**
     * 设置界面交互构件的默认初始值
     * 
     * @param value 文本区域的默认值
     */
    public void setDefault(String value)
    {
        // 魔术签名
        this.tf_SignChar.setText(value);
        // 偏移位置
        this.tf_SignCode.setText(value);
        // 加密算法
        this.tf_CipherSn.setText(value);
        // 相关说明
        this.ta_FileDesp.setText(value);
        // 文件图标
        this.ib_FileIcon.setBackgroundImage(null);
    }

    /**
     * 设置构件的可交互性
     * 
     * @param editable 构件是否可交互：true可交互；false不可交互
     */
    public void setEditable(boolean editable)
    {
        this.isEditable = editable;

        // 偏移位置
        this.tf_SignCode.setEditable(editable);
        // 加密算法
        this.tf_CipherSn.setEditable(editable);
        // 相关描述
        this.ta_FileDesp.setEditable(editable);
        // 文件图标
        this.ib_FileIcon.setUserEditable(editable);

        // 可交互状态
        if (editable)
        {
            // 更新按钮
            BeanUtil.setWText(bt_Update, Extparse.getMesg(LangRes.FILE_BUTN_TEXT_INSERT));
            BeanUtil.setWTips(bt_Update, Extparse.getMesg(LangRes.FILE_BUTN_TIPS_INSERT));
            // 删除按钮
            BeanUtil.setWText(bt_Delete, Extparse.getMesg(LangRes.FILE_BUTN_TEXT_CANCEL));
            BeanUtil.setWTips(bt_Delete, Extparse.getMesg(LangRes.FILE_BUTN_TIPS_CANCEL));
        }
        // 不可交互状态
        else
        {
            // 更新按钮
            BeanUtil.setWText(bt_Update, Extparse.getMesg(LangRes.FILE_BUTN_TEXT_UPDATE));
            BeanUtil.setWTips(bt_Update, Extparse.getMesg(LangRes.FILE_BUTN_TIPS_UPDATE));
            // 删除按钮
            BeanUtil.setWText(bt_Delete, Extparse.getMesg(LangRes.FILE_BUTN_TEXT_DELETE));
            BeanUtil.setWTips(bt_Delete, Extparse.getMesg(LangRes.FILE_BUTN_TIPS_DELETE));
        }
    }
    // ////////////////////////////////////////////////////////////////////////
    // 界面组件变量区域
    // ////////////////////////////////////////////////////////////////////////
    private javax.swing.JButton bt_Browse;
    /** 新增按钮 */
    private javax.swing.JButton bt_Create;
    /** 取消按钮 */
    private javax.swing.JButton bt_Delete;
    /** 更新按钮 */
    private javax.swing.JButton bt_Update;
    /** 文件列表参照 */
    private javax.swing.JButton bt_Refers;
    /** 软件信息 */
    private javax.swing.JComboBox cb_FileSoft;
    /** 相关说明 */
    private javax.swing.JTextArea ta_FileDesp;
    /** 加密算法 */
    private javax.swing.JTextField tf_CipherSn;
    /** 魔术签名 */
    private javax.swing.JTextField tf_SignChar;
    /** 偏移位置 */
    private javax.swing.JTextField tf_SignCode;
    /** 文件图标 */
    private WIconBox ib_FileIcon;
    private javax.swing.JLabel lb_CipherSn;
    private javax.swing.JLabel lb_FileDesp;
    private javax.swing.JLabel lb_FileSoft;
    private javax.swing.JLabel lb_SignChar;
    private javax.swing.JLabel lb_SignCode;
}
