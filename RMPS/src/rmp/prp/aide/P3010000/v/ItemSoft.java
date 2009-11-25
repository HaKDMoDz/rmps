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
import rmp.prp.aide.extparse.m.SoftBaseData;
import rmp.prp.aide.extparse.m.SoftUserData;
import rmp.util.BeanUtil;
import rmp.util.CheckUtil;
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
 * 软件信息数据管理面板
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class ItemSoft extends javax.swing.JPanel implements WItem, WBackCall
{
    // ////////////////////////////////////////////////////////////////////////
    // 界面控制变量区域
    // ////////////////////////////////////////////////////////////////////////
    /** 当前状态是否为可交互状态 */
    private boolean isEditable;
    /** 当前操作是否为数据更新操作 */
    private boolean isDataUpdt;
    /** 数据是否存在 */
    private boolean isMetaExist;
    /** 公司列表数据模型 */
    private DefaultComboBoxModel cm_CorpList;
    /** 父应用引用 */
    private Extparse me_MainSoft;
    /** 用户选择公司对象 */
    private K2SV1S kv_CorpItem;

    /**
     * @param soft
     */
    public ItemSoft()
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.ui.dlg.DViewPanel#init()
     */
    public boolean wInit()
    {
        isEditable = false;
        isDataUpdt = false;

        // 界面初始化
        ica();

        // 界面语言显示
        ita();

        cm_CorpList = new DefaultComboBoxModel();
        cb_SoftCorp.setModel(cm_CorpList);

        ib_SoftIcon.setIconPath(EnvUtil.getIconSoftDir());

        // 软件列表初始化
        DBAccess dba = new DBAccess();
        try
        {
            if (!dba.wInit())
            {
                return false;
            }

            initCorpList(dba);
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
            SoftBaseData baseMeta = queryByHash(kvItem.getK1());
            setBaseData(baseMeta);
        }

    }

    /**
     * 按索引查询指定软件的详细信息
     * 
     * @param softHash
     * @return
     */
    public static SoftBaseData queryByHash(String softHash)
    {
        DBAccess dba = new DBAccess();

        try
        {
            SoftBaseData baseMeta = null;
            if (dba.wInit())
            {
                baseMeta = queryByHash(dba, softHash);
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
     * @param softHash
     * @return
     * @throws SQLException
     */
    public static SoftBaseData queryByHash(DBAccess dba, String softHash) throws SQLException
    {
        return DA0008.selectSoftMetaInfo(dba, softHash);
    }

    /**
     * 按公司及软件名称查询软件列表数据
     * 
     * @param corpHash
     * @param softName
     * @return
     */
    public static List<K2SV1S> queryByName(String corpHash, String softName)
    {
        DBAccess dba = new DBAccess();

        try
        {
            List<K2SV1S> corpList = null;
            if (dba.wInit())
            {
                corpList = queryByName(dba, corpHash, softName);
            }
            return corpList;
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
     * @param corpHash
     * @param softName
     * @return
     * @throws SQLException
     */
    public static List<K2SV1S> queryByName(DBAccess dba, String corpHash, String softName) throws SQLException
    {
        return DA0008.selectSoftMetaName(dba, corpHash, softName);
    }

    // ////////////////////////////////////////////////////////////////////////
    // 公共接口区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 软件数据删除
     */
    public boolean metaDelete(SoftUserData userMeta)
    {
        // 用户删除确认
        String arg1 = Extparse.getMesg(LangRes.SOFT_COMN_TEXT_SOFTNAME);
        String arg2 = Extparse.getMesg(LangRes.TITLE_SOFTFORM);
        String errMsg = StringUtil.format(LangRes.MESG_DELT_0007, arg1, userMeta.getSoftName(), arg2);
        if (MesgUtil.showConfirmDialog(Extparse.getForm(), errMsg) != 0)
        {
            return false;
        }

        // 数据操作对象初始化
        DBAccess dba = new DBAccess();

        try
        {
            if (!dba.wInit())
            {
                return false;
            }

            // 执行数据删除
            DA0008.deleteSoftMeta(dba, userMeta);

            // 文件信息面板数据列表数据更新
            if (me_MainSoft.getFilePanel() != null)
            {
                me_MainSoft.getFilePanel().initSoftList(dba);
            }

            return true;
        }
        catch (SQLException exp)
        {
            LogUtil.exception(exp);
            String mesg = StringUtil.format(LangRes.MESG_DELT_0006, LangRes.TITLE_SOFTFORM, LangRes.MESG_INIT_0010);
            MesgUtil.showMessageDialog(Extparse.getForm(), mesg);
            return false;
        }
        finally
        {
            dba.closeConnection();
        }
    }

    /**
     * @param softHash
     * @return
     */
    public boolean hashSelect(String softHash)
    {
        return setBaseData(queryByHash(softHash));
    }

    /**
     * @return
     */
    public boolean nameSelect(String corpHash, String softName)
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
            softList = queryByName(dba, corpHash, softName);

            // 数据显示
            if (softList != null && softList.size() == 1)
            {
                return setBaseData(queryByHash(dba, softList.get(0).getK1()));
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
            String mesg = Extparse.getMesg(LangRes.TITLE_SOFTFORM);
            WListForm.showDialog(null, mesg, softList, this);
        }
        return true;
    }

    /**
     * 软件数据更新
     */
    public boolean metaUpdate(SoftUserData userMeta)
    {
        LogUtil.log("数据更新：软件数据更新！");

        // 连接数据库
        DBAccess dba = new DBAccess();

        try
        {
            if (!dba.wInit())
            {
                return false;
            }

            // 数据更新
            DA0008.updateSoftMeta(dba, userMeta);

            // 软件信息面板数据列表数据更新
            if (me_MainSoft.getFilePanel() != null)
            {
                me_MainSoft.getFilePanel().initSoftList(dba);
            }

            return true;
        }
        catch (SQLException exp)
        {
            LogUtil.exception(exp);
            String mesg = StringUtil.format(LangRes.MESG_UPDT_0005, LangRes.TITLE_SOFTFORM, LangRes.MESG_INIT_0010);
            MesgUtil.showMessageDialog(Extparse.getForm(), mesg);
            return false;
        }
        finally
        {
            // 数据提交
            dba.closeConnection();
        }
    }

    /**
     * 所属公司列表数据初始化
     * 
     * @param dba
     * @throws SQLException
     */
    public void initCorpList(final DBAccess dba) throws SQLException
    {
        // 数据查询
        List<K2SV1S> corpList = DA0008.selectCorpMetaName(dba, null, null);

        // 数据显示
        cm_CorpList.removeAllElements();
        kv_CorpItem = corpList.get(0);
        kv_CorpItem.setK2("");
        K2SV1S kvItem;
        for (int i = 0, j = corpList.size(); i < j; i += 1)
        {
            kvItem = corpList.get(i);
            kvItem.setK2("");
            cm_CorpList.addElement(kvItem);
        }
    }

    /**
     * 界面布局显示
     */
    private void ica()
    {
        ib_SoftIcon = new WIconBox(me_MainSoft);
        ib_SoftIcon.wInit();
        lb_SoftCorp = new javax.swing.JLabel();
        lb_SoftName = new javax.swing.JLabel();
        cb_SoftCorp = new javax.swing.JComboBox();
        tf_SoftName = new javax.swing.JTextField();
        bt_Refers = new javax.swing.JButton();
        lb_SoftExts = new javax.swing.JLabel();
        tf_SoftExts = new javax.swing.JTextField();
        lb_SoftSite = new javax.swing.JLabel();
        tf_SoftSite = new javax.swing.JTextField();
        bt_Browse = new javax.swing.JButton();
        lb_SoftDesp = new javax.swing.JLabel();
        javax.swing.JScrollPane sp_TextArea = new javax.swing.JScrollPane();
        ta_SoftDesp = new javax.swing.JTextArea();
        bt_Delete = new javax.swing.JButton();
        bt_Update = new javax.swing.JButton();
        bt_Create = new javax.swing.JButton();

        ib_SoftIcon.setToolTipText("\u516c\u53f8\u5fb5\u6807");

        lb_SoftCorp.setText("\u56fd\u522b\u4fe1\u606f(A)");
        lb_SoftCorp.setToolTipText("\u56fd\u522b\u4fe1\u606f");
        lb_SoftCorp.setLabelFor(cb_SoftCorp);

        lb_SoftName.setText("\u672c\u8bed\u540d\u79f0(L)");
        lb_SoftName.setToolTipText("\u672c\u8bed\u540d\u79f0");
        lb_SoftName.setLabelFor(tf_SoftName);

        cb_SoftCorp.setToolTipText("\u56fd\u522b\u4fe1\u606f");
        cb_SoftCorp.addItemListener(new java.awt.event.ItemListener()
        {
            public void itemStateChanged(java.awt.event.ItemEvent evt)
            {
                cb_SoftCorp_Handler(evt);
            }
        });

        tf_SoftName.setToolTipText("\u672c\u8bed\u540d\u79f0");
        tf_SoftName.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                tf_SoftName_Handler(evt);
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

        lb_SoftExts.setText("\u82f1\u8bed\u540d\u79f0(E)");
        lb_SoftExts.setToolTipText("\u82f1\u8bed\u540d\u79f0");
        lb_SoftExts.setLabelFor(tf_SoftExts);

        tf_SoftExts.setEditable(false);
        tf_SoftExts.setToolTipText("\u82f1\u8bed\u540d\u79f0");

        lb_SoftSite.setText("\u516c\u53f8\u9996\u9875(W)");
        lb_SoftSite.setToolTipText("\u516c\u53f8\u9996\u9875");
        lb_SoftSite.setLabelFor(tf_SoftSite);

        tf_SoftSite.setEditable(false);
        tf_SoftSite.setToolTipText("\u516c\u53f8\u9996\u9875");

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

        lb_SoftDesp.setText("\u76f8\u5173\u8bf4\u660e(P)");
        lb_SoftDesp.setToolTipText("\u76f8\u5173\u8bf4\u660e");
        lb_SoftDesp.setLabelFor(ta_SoftDesp);

        ta_SoftDesp.setEditable(false);
        ta_SoftDesp.setLineWrap(true);
        ta_SoftDesp.setRows(4);
        ta_SoftDesp.setToolTipText("\u76f8\u5173\u8bf4\u660e");
        sp_TextArea.setViewportView(ta_SoftDesp);

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
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_SoftExts).addComponent(lb_SoftSite).addComponent(lb_SoftDesp)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(tf_SoftExts,
                javax.swing.GroupLayout.DEFAULT_SIZE, 235, Short.MAX_VALUE).addGroup(
                javax.swing.GroupLayout.Alignment.TRAILING,
                layout.createSequentialGroup().addComponent(tf_SoftSite, javax.swing.GroupLayout.DEFAULT_SIZE, 213,
                Short.MAX_VALUE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_Browse, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addComponent(sp_TextArea, javax.swing.GroupLayout.DEFAULT_SIZE, 235, Short.MAX_VALUE)).addContainerGap()).addGroup(
                javax.swing.GroupLayout.Alignment.TRAILING,
                layout.createSequentialGroup().addContainerGap(134, Short.MAX_VALUE).addComponent(bt_Create).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_Update).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_Delete).addGap(10,
                10, 10)).addGroup(
                layout.createSequentialGroup().addGap(10, 10, 10).addComponent(ib_SoftIcon,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_SoftCorp).addComponent(lb_SoftName)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addComponent(tf_SoftName, javax.swing.GroupLayout.DEFAULT_SIZE,
                162, Short.MAX_VALUE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_Refers, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addGap(
                10, 10, 10)).addGroup(
                layout.createSequentialGroup().addComponent(cb_SoftCorp, 0, 184, Short.MAX_VALUE).addContainerGap()))));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false).addGroup(
                layout.createSequentialGroup().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_SoftCorp).addComponent(cb_SoftCorp,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE,
                Short.MAX_VALUE).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_SoftName).addComponent(bt_Refers, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(tf_SoftName, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))).addComponent(ib_SoftIcon, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_SoftExts).addComponent(tf_SoftExts, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_SoftSite).addComponent(bt_Browse, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(
                tf_SoftSite, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_SoftDesp).addComponent(sp_TextArea, javax.swing.GroupLayout.PREFERRED_SIZE,
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
        // 所属公司
        BeanUtil.setWText(lb_SoftCorp, Extparse.getMesg(LangRes.SOFT_LABL_TEXT_SOFTCORP));
        BeanUtil.setWTips(lb_SoftCorp, Extparse.getMesg(LangRes.SOFT_LABL_TIPS_SOFTCORP));

        BeanUtil.setWTips(cb_SoftCorp, Extparse.getMesg(LangRes.SOFT_COMB_TIPS_SOFTNAME));

        // 软件名称
        BeanUtil.setWText(lb_SoftName, Extparse.getMesg(LangRes.SOFT_LABL_TEXT_SOFTNAME));
        BeanUtil.setWTips(lb_SoftName, Extparse.getMesg(LangRes.SOFT_LABL_TIPS_SOFTNAME));

        BeanUtil.setWText(tf_SoftName, Extparse.getMesg(LangRes.SOFT_FILD_TEXT_SOFTNAME));
        BeanUtil.setWTips(tf_SoftName, Extparse.getMesg(LangRes.SOFT_FILD_TIPS_SOFTNAME));

        // 软件首页
        BeanUtil.setWText(lb_SoftSite, Extparse.getMesg(LangRes.SOFT_LABL_TEXT_SOFTSITE));
        BeanUtil.setWTips(lb_SoftSite, Extparse.getMesg(LangRes.SOFT_LABL_TIPS_SOFTSITE));

        BeanUtil.setWText(tf_SoftSite, Extparse.getMesg(LangRes.SOFT_FILD_TEXT_SOFTSITE));
        BeanUtil.setWTips(tf_SoftSite, Extparse.getMesg(LangRes.SOFT_FILD_TIPS_SOFTSITE));

        // 支持格式
        BeanUtil.setWText(lb_SoftExts, Extparse.getMesg(LangRes.SOFT_LABL_TEXT_SOFTEXTS));
        BeanUtil.setWTips(lb_SoftExts, Extparse.getMesg(LangRes.SOFT_LABL_TIPS_SOFTEXTS));

        BeanUtil.setWText(tf_SoftExts, Extparse.getMesg(LangRes.SOFT_FILD_TEXT_SOFTEXTS));
        BeanUtil.setWTips(tf_SoftExts, Extparse.getMesg(LangRes.SOFT_FILD_TIPS_SOFTEXTS));

        // 相关说明
        BeanUtil.setWText(lb_SoftDesp, Extparse.getMesg(LangRes.SOFT_LABL_TEXT_SOFTDESP));
        BeanUtil.setWTips(lb_SoftDesp, Extparse.getMesg(LangRes.SOFT_LABL_TIPS_SOFTDESP));

        BeanUtil.setWText(ta_SoftDesp, Extparse.getMesg(LangRes.SOFT_AREA_TEXT_SOFTDESP));
        BeanUtil.setWTips(ta_SoftDesp, Extparse.getMesg(LangRes.SOFT_AREA_TIPS_SOFTDESP));

        // 新增按钮
        BeanUtil.setWText(bt_Create, Extparse.getMesg(LangRes.SOFT_BUTN_TEXT_CREATE));
        BeanUtil.setWTips(bt_Create, Extparse.getMesg(LangRes.SOFT_BUTN_TIPS_CREATE));

        // 更新按钮
        BeanUtil.setWText(bt_Update, Extparse.getMesg(LangRes.SOFT_BUTN_TEXT_UPDATE));
        BeanUtil.setWTips(bt_Update, Extparse.getMesg(LangRes.SOFT_BUTN_TIPS_UPDATE));

        // 删除按钮
        BeanUtil.setWText(bt_Delete, Extparse.getMesg(LangRes.SOFT_BUTN_TEXT_DELETE));
        BeanUtil.setWTips(bt_Delete, Extparse.getMesg(LangRes.SOFT_BUTN_TIPS_DELETE));

        // 参照
        BeanUtil.setWText(bt_Refers, Extparse.getMesg(LangRes.SOFT_BUTN_TEXT_SOFTVIEW));
        BeanUtil.setWTips(bt_Refers, Extparse.getMesg(LangRes.SOFT_BUTN_TIPS_SOFTVIEW));

        // 图标
        BeanUtil.setWTips(ib_SoftIcon, Extparse.getMesg(LangRes.SOFT_IMLB_TIPS_SOFTICON));
    }

    // ////////////////////////////////////////////////////////////////////////
    // 事件处理区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 新增按钮事件处理
     * 
     * @param evt
     */
    private void bt_Create_Handler(java.awt.event.ActionEvent evt)
    {
        // 不可交互状态时的处理：显示交互界面
        if (!isEditable)
        {
            setEditable(true);
            me_MainSoft.getSoftForm().setTitle(Extparse.getMesg(LangRes.TITLE_SOFTFORM) + LangRes.TITLE_INSERT);
        }

        // 清除界面已有数据
        setDefault("");

        ib_SoftIcon.setIconHash(ConstUI.DEF_SOFTICON);
        me_MainSoft.getBaseData().setSoftIndx(ConstUI.DEF_SOFTHASH);

        // 焦点设置
        this.tf_SoftName.requestFocus();

        // 状态标记设置为新增状态
        isDataUpdt = false;
    }

    /**
     * 删除按钮事件处理
     * 
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
            SoftUserData userMeta = new SoftUserData();
            userMeta.wInit();

            // 仅读取关键值部分
            if (!getUserData(userMeta))
            {
                return;
            }

            if (metaDelete(userMeta))
            {
                // 清空界面显示数据
                setDefault("");

                // 焦点设置
                this.tf_SoftName.requestFocus();

                isDataUpdt = false;
            }
        }
        // 可交互状态时的处理：显示不可交互状态
        else
        {
            setEditable(false);
            me_MainSoft.getSoftForm().setTitle(Extparse.getMesg(LangRes.TITLE_SOFTFORM));
        }
    }

    /**
     * 更新按钮事件处理
     * 
     * @param evt
     */
    private void bt_Update_Handler(java.awt.event.ActionEvent evt)
    {
        // 不可交互状态时的处理：显示交互界面
        if (!isEditable)
        {
            LogUtil.log("状态切换：显示数据更新状态！");

            // 显示可交互界面
            setEditable(true);
            me_MainSoft.getSoftForm().setTitle(Extparse.getMesg(LangRes.TITLE_SOFTFORM) + LangRes.TITLE_UPDATE);

            // 焦点设置
            this.tf_SoftName.requestFocus();

            // 状态标记设置为更新状态
            isDataUpdt = true;
        }
        // 可交互状态时的处理：进行数据的新增更新
        else
        {
            LogUtil.log("数据更新：软件信息数据更新 － " + this.tf_SoftName.getText());

            // 用户数据对象
            SoftUserData userMeta = new SoftUserData();
            userMeta.wInit();

            // 读取所有用户数据
            if (!getUserData(userMeta, false))
            {
                return;
            }

            // 数据更新
            if (metaUpdate(userMeta))
            {
                // 清空界面显示数据
                setDefault("");

                // 焦点设置
                this.tf_SoftName.requestFocus();

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
        String url = this.tf_SoftSite.getText();
        if (CheckUtil.isValidate(url))
        {
            EnvUtil.browse(url);
        }
    }

    /**
     * 参照按钮事件处理
     * 
     * @param evt
     */
    private void bt_Refers_Handler(java.awt.event.ActionEvent evt)
    {
        nameSelect(ConstUI.DEF_CORPHASH, "");
    }

    /**
     * 所属公司组合框事件处理
     * 
     * @param evt
     */
    private void cb_SoftCorp_Handler(java.awt.event.ItemEvent evt)
    {
    }

    /**
     * 软件名称文本框事件处理
     * 
     * @param evt
     */
    private void tf_SoftName_Handler(java.awt.event.ActionEvent evt)
    {
        // 公司索引
        String corpHash = ConstUI.DEF_CORPHASH;
        K2SV1S kvItem = (K2SV1S) this.cb_SoftCorp.getSelectedItem();
        if (kvItem != null)
        {
            corpHash = kvItem.getK1();
        }

        // 软件名称
        String softName = this.tf_SoftName.getText();

        nameSelect(corpHash, softName);
    }

    /**
     * 用户输入信息读取（仅读取关键值部分）
     * 
     * @param userMeta
     * @return 用户数据是否读取成功
     */
    private boolean getUserData(SoftUserData userMeta)
    {
        return getUserData(userMeta, true);
    }

    /**
     * 用户输入信息读取
     * 
     * @param userMeta
     * @param keysOnly 是否仅读取关键值部分：true是
     * @return 用户数据是否读取成功
     */
    private boolean getUserData(SoftUserData userMeta, boolean keysOnly)
    {
        // 数据操作状态
        userMeta.setUpdate(isDataUpdt && isMetaExist);
        // 软件索引
        userMeta.setSoftIndx(me_MainSoft.getBaseData().getSoftIndx());

        // 公司信息
        K2SV1S kvItem = (K2SV1S) this.cb_SoftCorp.getSelectedItem();
        if (!userMeta.setCorpIndx(kvItem.getK1()))
        {
            MesgUtil.showMessageDialog(Extparse.getForm(), userMeta.getErrMsg());
            this.cb_SoftCorp.requestFocus();
            return false;
        }

        // 软件名称
        if (!userMeta.setSoftName(this.tf_SoftName.getText()))
        {
            MesgUtil.showMessageDialog(Extparse.getForm(), userMeta.getErrMsg());
            this.tf_SoftName.requestFocus();
            return false;
        }

        // 仅读取关键值部分
        if (keysOnly)
        {
            return true;
        }

        // 链接地址
        if (!userMeta.setSoftSite(this.tf_SoftSite.getText()))
        {
            MesgUtil.showMessageDialog(Extparse.getForm(), userMeta.getErrMsg());
            this.tf_SoftSite.requestFocus();
            return false;
        }

        // 支持格式
        if (!userMeta.setExtsList(this.tf_SoftExts.getText()))
        {
            MesgUtil.showMessageDialog(Extparse.getForm(), userMeta.getErrMsg());
            this.tf_SoftExts.requestFocus();
            return false;
        }

        // 相关说明
        if (!userMeta.setSoftDesp(this.ta_SoftDesp.getText()))
        {
            MesgUtil.showMessageDialog(Extparse.getForm(), userMeta.getErrMsg());
            this.ta_SoftDesp.requestFocus();
            return false;
        }

        // 保存外部图像
        ib_SoftIcon.saveExtImage();
        // 软件图标
        userMeta.setSoftIcon(ib_SoftIcon.getIconHash());
        ib_SoftIcon.setIconHash(ConstUI.DEF_SOFTICON);

        return true;
    }

    /**
     * 后缀数据显示
     * 
     * @param baseMeta
     * @return
     */
    private boolean setBaseData(SoftBaseData baseMeta)
    {
        // 文本框数据显示
        this.tf_SoftName.setText(baseMeta.getSoftName());
        this.tf_SoftSite.setText(baseMeta.getSoftSite());
        this.tf_SoftExts.setText(baseMeta.getExtsList());
        this.ta_SoftDesp.setText(baseMeta.getSoftDesp());

        // 组合框数据显示
        kv_CorpItem = new K2SV1S(baseMeta.getCorpIndx(), "", baseMeta.getCorpName());
        this.cb_SoftCorp.setSelectedItem(kv_CorpItem);

        // 图像标签数据显示
        ib_SoftIcon.setIconHash(baseMeta.getSoftIcon());

        // 状态标记
        isDataUpdt = true;
        isMetaExist = baseMeta.isMetaExist();
        // 数据维持
        if (isMetaExist)
        {
            me_MainSoft.getBaseData().setSoftIndx(baseMeta.getSoftIndx());
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
        // 软件名称
        this.tf_SoftName.setText(value);
        // 链接地址
        this.tf_SoftSite.setText(value);
        // 支持格式
        this.tf_SoftExts.setText(value);
        // 相关说明
        this.ta_SoftDesp.setText(value);
        // 软件图标
        this.ib_SoftIcon.setBackgroundImage(null);
    }

    /**
     * 设置构件的可交互性
     * 
     * @param editable 构件是否可交互：true可交互；false不可交互
     */
    public void setEditable(boolean editable)
    {
        this.isEditable = editable;

        // 链接地址
        this.tf_SoftSite.setEditable(editable);
        // 支持格式
        this.tf_SoftExts.setEditable(editable);
        // 相关说明
        this.ta_SoftDesp.setEditable(editable);
        // 软件图标
        this.ib_SoftIcon.setUserEditable(editable);

        // 可交互
        if (editable)
        {
            // 更新按钮
            BeanUtil.setWText(bt_Update, Extparse.getMesg(LangRes.SOFT_BUTN_TEXT_INSERT));
            BeanUtil.setWTips(bt_Update, Extparse.getMesg(LangRes.SOFT_BUTN_TIPS_INSERT));
            // 删除按钮
            BeanUtil.setWText(bt_Delete, Extparse.getMesg(LangRes.SOFT_BUTN_TEXT_CANCEL));
            BeanUtil.setWTips(bt_Delete, Extparse.getMesg(LangRes.SOFT_BUTN_TIPS_CANCEL));
        }
        // 不可交互
        else
        {
            // 更新按钮
            BeanUtil.setWText(bt_Update, Extparse.getMesg(LangRes.SOFT_BUTN_TEXT_UPDATE));
            BeanUtil.setWTips(bt_Update, Extparse.getMesg(LangRes.SOFT_BUTN_TIPS_UPDATE));
            // 删除按钮
            BeanUtil.setWText(bt_Delete, Extparse.getMesg(LangRes.SOFT_BUTN_TEXT_DELETE));
            BeanUtil.setWTips(bt_Delete, Extparse.getMesg(LangRes.SOFT_BUTN_TIPS_DELETE));
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
    /** 软件参照 */
    private javax.swing.JButton bt_Refers;
    /** 公司信息 */
    private javax.swing.JComboBox cb_SoftCorp;
    /** 相关说明 */
    private javax.swing.JTextArea ta_SoftDesp;
    /** 支持格式 */
    private javax.swing.JTextField tf_SoftExts;
    /** 软件名称 */
    private javax.swing.JTextField tf_SoftName;
    /** 链接地址 */
    private javax.swing.JTextField tf_SoftSite;
    /** 软件图标 */
    private WIconBox ib_SoftIcon;
    private javax.swing.JLabel lb_SoftCorp;
    private javax.swing.JLabel lb_SoftDesp;
    private javax.swing.JLabel lb_SoftExts;
    private javax.swing.JLabel lb_SoftName;
    private javax.swing.JLabel lb_SoftSite;
}
