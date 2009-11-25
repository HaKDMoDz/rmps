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
import rmp.prp.aide.extparse.m.CorpBaseData;
import rmp.prp.aide.extparse.m.CorpUserData;
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
 * 公司信息管理面板
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class ItemCorp extends javax.swing.JPanel implements WItem, WBackCall
{
    // ////////////////////////////////////////////////////////////////////////
    // 界面控制变量区域
    // ////////////////////////////////////////////////////////////////////////
    /**  */
    private static final long serialVersionUID = 6130675705555732826L;
    /** 当前操作是否为数据更新操作 */
    private boolean isDataUpdt;
    /** 当前状态是否为可交互状态 */
    private boolean isEditable;
    /** 当前数据是否存在 */
    private boolean isMetaExist;
    /** 国别列表数据模型 */
    private DefaultComboBoxModel cm_NatnList;
    /** 父应用引用 */
    private Extparse me_MainSoft;
    /** 用户选择国别对象 */
    private K2SV1S kv_NatnItem;

    /**
     * @param soft
     */
    public ItemCorp()
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.ui.dlg.DViewPanel#init()
     */
    public boolean wInit()
    {
        isDataUpdt = false;
        isEditable = false;

        // 界面初始化
        ica();

        // 界面语言显示
        ita();

        cm_NatnList = new DefaultComboBoxModel();
        cb_CorpNatn.setModel(cm_NatnList);

        ib_CorpIcon.setIconPath(EnvUtil.getIconCorpDir());

        // 国别列表初始化
        DBAccess dba = new DBAccess();
        try
        {
            if (!dba.wInit())
            {
                return false;
            }
            initNatnList(dba);
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
            CorpBaseData baseMeta = queryByHash(kvItem.getK1());
            setBaseData(baseMeta);
        }
    }

    /**
     * 按索引查询指定公司的详细信息
     * 
     * @param corpHash 公司索引
     * @return
     */
    public static CorpBaseData queryByHash(String corpHash)
    {
        DBAccess dba = new DBAccess();

        try
        {
            CorpBaseData baseMeta = null;
            if (dba.wInit())
            {
                baseMeta = queryByHash(dba, corpHash);
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
     * @param corpHash
     * @return
     * @throws SQLException
     */
    public static CorpBaseData queryByHash(DBAccess dba, String corpHash) throws SQLException
    {
        return DA0008.selectCorpMetaInfo(dba, corpHash);
    }

    /**
     * 按国别及公司本语名称查询公司列表数据
     * 
     * @param userMeta
     * @return
     */
    public static List<K2SV1S> queryByName(String natnHash, String corpLcNm)
    {
        DBAccess dba = new DBAccess();

        try
        {
            List<K2SV1S> corpList = null;
            if (dba.wInit())
            {
                corpList = queryByName(dba, natnHash, corpLcNm);
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
     * @param natnHash
     * @param corpLcNm
     * @return
     * @throws SQLException
     */
    public static List<K2SV1S> queryByName(DBAccess dba, String natnHash, String corpLcNm) throws SQLException
    {
        return DA0008.selectCorpMetaName(dba, natnHash, corpLcNm);
    }

    /**
     * 公司数据删除
     * 
     * @param userMeta
     * @return
     */
    public boolean metaDelete(CorpUserData userMeta)
    {
        // 用户删除确认
        String arg1 = Extparse.getMesg(LangRes.CORP_COMN_TEXT_CORPLCNM);
        String arg2 = Extparse.getMesg(LangRes.TITLE_CORPFORM);
        String msg = StringUtil.format(LangRes.MESG_DELT_0007, arg1, userMeta.getCorpLcNm(), arg2);
        if (MesgUtil.showConfirmDialog(Extparse.getForm(), msg) != 0)
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
            DA0008.deleteCorpMeta(dba, userMeta);

            // 文件信息面板数据列表数据更新
            if (me_MainSoft.getSoftPanel() != null)
            {
                me_MainSoft.getSoftPanel().initCorpList(dba);
            }

            return true;
        }
        catch (SQLException exp)
        {
            LogUtil.exception(exp);
            String mesg = StringUtil.format(LangRes.MESG_DELT_0006, LangRes.TITLE_CORPFORM, LangRes.MESG_INIT_0010);
            MesgUtil.showMessageDialog(Extparse.getForm(), mesg);
            return false;
        }
        finally
        {
            dba.closeConnection();
        }
    }

    /**
     * 按公司索引查询公司详细信息
     * 
     * @param corpHash
     * @return
     */
    public boolean hashSelect(String corpHash)
    {
        setBaseData(queryByHash(corpHash));

        return true;
    }

    /**
     * 按公司名称查询公司数据列表
     * 
     * @param corpLcNm
     * @return
     */
    public boolean nameSelect(String natnHash, String corpLcNm)
    {
        DBAccess dba = new DBAccess();

        List<K2SV1S> corpList = null;
        try
        {
            // 连接初始化
            if (!dba.wInit())
            {
                return false;
            }

            // 数据查询
            corpList = queryByName(dba, natnHash, corpLcNm);

            // 查询结果只有一个的情况下，直接显示
            if (corpList != null && corpList.size() == 1)
            {
                return setBaseData(queryByHash(dba, corpList.get(0).getK1()));
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
        if (corpList == null)
        {
            String mesg = StringUtil.format(LangRes.MESG_SELT_0004, LangRes.MESG_INIT_0010);
            MesgUtil.showMessageDialog(null, mesg);
            return false;
        }
        // 数据为空
        else if (corpList.size() == 0)
        {
            MesgUtil.showMessageDialog(null, Extparse.getMesg(LangRes.MESG_SELT_0003));
        }
        // 多个结果
        else
        {
            String mesg = Extparse.getMesg(LangRes.TITLE_CORPFORM);
            WListForm.showDialog(null, mesg, corpList, this);
        }
        return true;
    }

    /**
     * 公司数据更新
     * 
     * @param userMeta
     * @return
     */
    public boolean metaUpdate(CorpUserData userMeta)
    {
        LogUtil.log("数据更新：公司数据更新！");

        // 连接数据库
        DBAccess dba = new DBAccess();

        try
        {
            if (!dba.wInit())
            {
                return false;
            }

            // 数据更新
            DA0008.updateCorpMeta(dba, userMeta);

            // 软件信息面板公司名称列表数据更新
            if (me_MainSoft.getSoftPanel() != null)
            {
                me_MainSoft.getSoftPanel().initCorpList(dba);
            }

            return true;
        }
        catch (SQLException exp)
        {
            LogUtil.exception(exp);
            String mesg = StringUtil.format(LangRes.MESG_UPDT_0005, LangRes.TITLE_CORPFORM, LangRes.MESG_INIT_0010);
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
     * 国别列表初始化
     * 
     * @return
     * @throws SQLException
     */
    public void initNatnList(final DBAccess dba) throws SQLException
    {
        // 数据查询
        List<K2SV1S> natnList = DA0008.selectNatnMetaName(dba);

        // 数据显示
        cm_NatnList.removeAllElements();
        kv_NatnItem = natnList.get(0);
        for (int i = 0, j = natnList.size(); i < j; i += 1)
        {
            cm_NatnList.addElement(natnList.get(i));
        }
    }

    /**
     * 界面初始化
     */
    private void ica()
    {
        ib_CorpIcon = new WIconBox(me_MainSoft);
        ib_CorpIcon.wInit();
        lb_CorpNatn = new javax.swing.JLabel();
        lb_CorpLcNm = new javax.swing.JLabel();
        cb_CorpNatn = new javax.swing.JComboBox();
        tf_CorpLcNm = new javax.swing.JTextField();
        bt_Refers = new javax.swing.JButton();
        lb_CorpEnNm = new javax.swing.JLabel();
        tf_CorpEnNm = new javax.swing.JTextField();
        lb_CorpSite = new javax.swing.JLabel();
        tf_CorpSite = new javax.swing.JTextField();
        bt_Browse = new javax.swing.JButton();
        lb_CorpDesp = new javax.swing.JLabel();
        javax.swing.JScrollPane sp_TextArea = new javax.swing.JScrollPane();
        ta_CorpDesp = new javax.swing.JTextArea();
        bt_Delete = new javax.swing.JButton();
        bt_Update = new javax.swing.JButton();
        bt_Create = new javax.swing.JButton();

        ib_CorpIcon.setToolTipText("\u516c\u53f8\u5fb5\u6807");

        lb_CorpNatn.setText("\u56fd\u522b\u4fe1\u606f(A)");
        lb_CorpNatn.setToolTipText("\u56fd\u522b\u4fe1\u606f");
        lb_CorpNatn.setLabelFor(cb_CorpNatn);

        lb_CorpLcNm.setText("\u672c\u8bed\u540d\u79f0(L)");
        lb_CorpLcNm.setToolTipText("\u672c\u8bed\u540d\u79f0");
        lb_CorpLcNm.setLabelFor(tf_CorpLcNm);

        cb_CorpNatn.setToolTipText("\u56fd\u522b\u4fe1\u606f");
        cb_CorpNatn.addItemListener(new java.awt.event.ItemListener()
        {
            public void itemStateChanged(java.awt.event.ItemEvent evt)
            {
                cb_CorpNatn_Handler(evt);
            }
        });

        tf_CorpLcNm.setToolTipText("\u672c\u8bed\u540d\u79f0");
        tf_CorpLcNm.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                tf_CorpLcNm_Handler(evt);
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

        lb_CorpEnNm.setText("\u82f1\u8bed\u540d\u79f0(E)");
        lb_CorpEnNm.setToolTipText("\u82f1\u8bed\u540d\u79f0");
        lb_CorpEnNm.setLabelFor(tf_CorpEnNm);

        tf_CorpEnNm.setEditable(false);
        tf_CorpEnNm.setToolTipText("\u82f1\u8bed\u540d\u79f0");

        lb_CorpSite.setText("\u516c\u53f8\u9996\u9875(W)");
        lb_CorpSite.setToolTipText("\u516c\u53f8\u9996\u9875");
        lb_CorpSite.setLabelFor(tf_CorpSite);

        tf_CorpSite.setEditable(false);
        tf_CorpSite.setToolTipText("\u516c\u53f8\u9996\u9875");

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

        lb_CorpDesp.setText("\u76f8\u5173\u8bf4\u660e(P)");
        lb_CorpDesp.setToolTipText("\u76f8\u5173\u8bf4\u660e");
        lb_CorpDesp.setLabelFor(ta_CorpDesp);

        ta_CorpDesp.setEditable(false);
        ta_CorpDesp.setLineWrap(true);
        ta_CorpDesp.setRows(4);
        ta_CorpDesp.setToolTipText("\u76f8\u5173\u8bf4\u660e");
        sp_TextArea.setViewportView(ta_CorpDesp);

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
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_CorpEnNm).addComponent(lb_CorpSite).addComponent(lb_CorpDesp)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(tf_CorpEnNm,
                javax.swing.GroupLayout.DEFAULT_SIZE, 235, Short.MAX_VALUE).addGroup(
                javax.swing.GroupLayout.Alignment.TRAILING,
                layout.createSequentialGroup().addComponent(tf_CorpSite, javax.swing.GroupLayout.DEFAULT_SIZE, 213,
                Short.MAX_VALUE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_Browse, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addComponent(sp_TextArea, javax.swing.GroupLayout.DEFAULT_SIZE, 235, Short.MAX_VALUE)).addContainerGap()).addGroup(
                javax.swing.GroupLayout.Alignment.TRAILING,
                layout.createSequentialGroup().addContainerGap(134, Short.MAX_VALUE).addComponent(bt_Create).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_Update).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_Delete).addGap(10,
                10, 10)).addGroup(
                layout.createSequentialGroup().addGap(10, 10, 10).addComponent(ib_CorpIcon,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_CorpNatn).addComponent(lb_CorpLcNm)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addComponent(tf_CorpLcNm, javax.swing.GroupLayout.DEFAULT_SIZE,
                162, Short.MAX_VALUE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_Refers, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addGap(
                10, 10, 10)).addGroup(
                layout.createSequentialGroup().addComponent(cb_CorpNatn, 0, 184, Short.MAX_VALUE).addContainerGap()))));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false).addGroup(
                layout.createSequentialGroup().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_CorpNatn).addComponent(cb_CorpNatn,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE,
                Short.MAX_VALUE).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_CorpLcNm).addComponent(bt_Refers, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(tf_CorpLcNm, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))).addComponent(ib_CorpIcon, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_CorpEnNm).addComponent(tf_CorpEnNm, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_CorpSite).addComponent(bt_Browse, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(
                tf_CorpSite, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_CorpDesp).addComponent(sp_TextArea, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE,
                Short.MAX_VALUE).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(bt_Delete).addComponent(bt_Update).addComponent(bt_Create)).addContainerGap()));
    }

    /**
     * 界面语言显示
     * 
     * @param isHash
     */
    private void ita()
    {
        // 国别信息
        BeanUtil.setWText(lb_CorpNatn, Extparse.getMesg(LangRes.CORP_LABL_TEXT_CORPNATN));
        BeanUtil.setWTips(lb_CorpNatn, Extparse.getMesg(LangRes.CORP_LABL_TIPS_CORPNATN));

        BeanUtil.setWTips(cb_CorpNatn, Extparse.getMesg(LangRes.CORP_COMB_TIPS_CORPNATN));

        // 本语名称
        BeanUtil.setWText(lb_CorpLcNm, Extparse.getMesg(LangRes.CORP_LABL_TEXT_CORPLCNM));
        BeanUtil.setWTips(lb_CorpLcNm, Extparse.getMesg(LangRes.CORP_LABL_TIPS_CORPLCNM));

        BeanUtil.setWText(tf_CorpLcNm, Extparse.getMesg(LangRes.CORP_FILD_TEXT_CORPLCNM));
        BeanUtil.setWTips(tf_CorpLcNm, Extparse.getMesg(LangRes.CORP_FILD_TIPS_CORPLCNM));

        // 英语名称
        BeanUtil.setWText(lb_CorpEnNm, Extparse.getMesg(LangRes.CORP_LABL_TEXT_CORPENNM));
        BeanUtil.setWTips(lb_CorpEnNm, Extparse.getMesg(LangRes.CORP_LABL_TIPS_CORPENNM));

        BeanUtil.setWText(lb_CorpEnNm, Extparse.getMesg(LangRes.CORP_FILD_TEXT_CORPENNM));
        BeanUtil.setWTips(lb_CorpEnNm, Extparse.getMesg(LangRes.CORP_FILD_TIPS_CORPENNM));

        // 公司网站
        BeanUtil.setWText(lb_CorpSite, Extparse.getMesg(LangRes.CORP_LABL_TEXT_CORPSITE));
        BeanUtil.setWTips(lb_CorpSite, Extparse.getMesg(LangRes.CORP_LABL_TIPS_CORPSITE));

        BeanUtil.setWText(lb_CorpSite, Extparse.getMesg(LangRes.CORP_FILD_TEXT_CORPSITE));
        BeanUtil.setWTips(lb_CorpSite, Extparse.getMesg(LangRes.CORP_FILD_TIPS_CORPSITE));

        // 相关说明
        BeanUtil.setWText(lb_CorpDesp, Extparse.getMesg(LangRes.CORP_LABL_TEXT_CORPDESP));
        BeanUtil.setWTips(lb_CorpDesp, Extparse.getMesg(LangRes.CORP_LABL_TIPS_CORPDESP));

        BeanUtil.setWText(lb_CorpDesp, Extparse.getMesg(LangRes.CORP_AREA_TEXT_CORPDESP));
        BeanUtil.setWTips(lb_CorpDesp, Extparse.getMesg(LangRes.CORP_AREA_TIPS_CORPDESP));

        // 新增按钮
        BeanUtil.setWText(bt_Create, Extparse.getMesg(LangRes.CORP_BUTN_TEXT_CREATE));
        BeanUtil.setWTips(bt_Create, Extparse.getMesg(LangRes.CORP_BUTN_TIPS_CREATE));

        // 更新按钮
        BeanUtil.setWText(bt_Update, Extparse.getMesg(LangRes.CORP_BUTN_TEXT_UPDATE));
        BeanUtil.setWTips(bt_Update, Extparse.getMesg(LangRes.CORP_BUTN_TIPS_UPDATE));

        // 删除按钮
        BeanUtil.setWText(bt_Delete, Extparse.getMesg(LangRes.CORP_BUTN_TEXT_DELETE));
        BeanUtil.setWTips(bt_Delete, Extparse.getMesg(LangRes.CORP_BUTN_TIPS_DELETE));

        // 参照按钮
        BeanUtil.setWText(bt_Refers, Extparse.getMesg(LangRes.CORP_BUTN_TEXT_CORPVIEW));
        BeanUtil.setWTips(bt_Refers, Extparse.getMesg(LangRes.CORP_BUTN_TIPS_CORPVIEW));

        // 图标
        BeanUtil.setWTips(ib_CorpIcon, Extparse.getMesg(LangRes.CORP_IMLB_TIPS_CORPICON));
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
            me_MainSoft.getSoftForm().setTitle(Extparse.getMesg(LangRes.TITLE_CORPFORM) + LangRes.TITLE_INSERT);
        }

        // 清除界面已有数据
        setDefault("");

        ib_CorpIcon.setIconHash(ConstUI.DEF_CORPICON);
        me_MainSoft.getBaseData().setCorpIndx(ConstUI.DEF_CORPHASH);

        // 焦点设置
        this.tf_CorpLcNm.requestFocus();

        // 状态更新标记设置为新增状态
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
            CorpUserData userMeta = new CorpUserData();
            userMeta.wInit();

            // 仅读取关键用户数据信息
            if (!getUserData(userMeta))
            {
                return;
            }

            // 数据删除
            if (metaDelete(userMeta))
            {
                // 清空界面显示数据
                setDefault("");

                // 焦点设置
                this.tf_CorpLcNm.requestFocus();

                // 状态标记设置为新增状态
                isDataUpdt = false;
            }
        }
        // 可交互状态时的处理：显示不可交互状态
        else
        {
            setEditable(false);
            me_MainSoft.getSoftForm().setTitle(Extparse.getMesg(LangRes.TITLE_ASOCFORM));
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
            setEditable(true);
            me_MainSoft.getSoftForm().setTitle(Extparse.getMesg(LangRes.TITLE_ASOCFORM) + LangRes.TITLE_UPDATE);

            // 焦点设置
            this.tf_CorpLcNm.requestFocus();

            // 状态标记设置为更新状态
            isDataUpdt = true;
        }
        // 可交互状态时的处理：进行数据的新增或更新
        else
        {
            // 用户数据对象
            CorpUserData userMeta = new CorpUserData();
            userMeta.wInit();

            // 读取所有用户数据信息
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
                this.tf_CorpLcNm.requestFocus();

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
        String url = this.tf_CorpSite.getText();
        if (CheckUtil.isValidate(url))
        {
            EnvUtil.browse(url);
        }
    }

    /**
     * 本语名称参照按钮事件处理
     * 
     * @param evt
     */
    private void bt_Refers_Handler(java.awt.event.ActionEvent evt)
    {
        // 公司信息查询
        nameSelect(ConstUI.DEF_NATNHASH, "");
    }

    /**
     * @param evt
     */
    private void cb_CorpNatn_Handler(java.awt.event.ItemEvent evt)
    {
    }

    /**
     * 本语名称文本框事件处理
     * 
     * @param evt
     */
    private void tf_CorpLcNm_Handler(java.awt.event.ActionEvent evt)
    {
        // 国别索引
        String natnHash = ConstUI.DEF_NATNHASH;
        K2SV1S kvItem = (K2SV1S) this.cb_CorpNatn.getSelectedItem();
        if (kvItem != null)
        {
            natnHash = kvItem.getK1();
        }

        // 本语名称
        String corpLcNm = this.tf_CorpLcNm.getText();

        // 公司信息查询
        nameSelect(natnHash, corpLcNm);
    }

    // ////////////////////////////////////////////////////////////////////////
    // 公共接口区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 用户数据读取
     * 
     * @param userMeta
     * @return 用户数据是否读取成功
     */
    private boolean getUserData(CorpUserData userMeta)
    {
        return getUserData(userMeta, true);
    }

    /**
     * 用户数据读取
     * 
     * @param userMeta
     * @param keysOnly 是否仅读取关键值部分：true是
     * @return
     */
    private boolean getUserData(CorpUserData userMeta, boolean keysOnly)
    {
        // 数据操作状态
        userMeta.setUpdate(isDataUpdt && isMetaExist);
        // 软件索引
        userMeta.setCorpIndx(me_MainSoft.getBaseData().getCorpIndx());

        // 国别信息
        K2SV1S kvItem = (K2SV1S) this.cb_CorpNatn.getSelectedItem();
        if (!userMeta.setNatnIndx(kvItem != null ? kvItem.getK1() : ConstUI.DEF_NATNHASH))
        {
            MesgUtil.showMessageDialog(Extparse.getForm(), userMeta.getErrMsg());
            this.cb_CorpNatn.requestFocus();
            return false;
        }

        // 本语名称
        if (!userMeta.setCorpLcNm(this.tf_CorpLcNm.getText()))
        {
            MesgUtil.showMessageDialog(Extparse.getForm(), userMeta.getErrMsg());
            this.tf_CorpLcNm.requestFocus();
            return false;
        }

        // 仅读取关键值部分
        if (keysOnly)
        {
            return true;
        }

        // 英语名称
        if (!userMeta.setCorpEnNm(this.tf_CorpEnNm.getText()))
        {
            MesgUtil.showMessageDialog(Extparse.getForm(), userMeta.getErrMsg());
            this.tf_CorpEnNm.requestFocus();
            return false;
        }

        // 公司网址
        if (!userMeta.setCorpSite(this.tf_CorpSite.getText()))
        {
            MesgUtil.showMessageDialog(Extparse.getForm(), userMeta.getErrMsg());
            this.tf_CorpSite.requestFocus();
            return false;
        }

        // 相关说明
        if (!userMeta.setCorpDesp(this.ta_CorpDesp.getText()))
        {
            MesgUtil.showMessageDialog(Extparse.getForm(), userMeta.getErrMsg());
            this.ta_CorpDesp.requestFocus();
            return false;
        }

        // 外部图像保存
        ib_CorpIcon.saveExtImage();
        // 公司图标
        userMeta.setCorpLogo(ib_CorpIcon.getIconHash());
        ib_CorpIcon.setIconHash(ConstUI.DEF_CORPICON);

        return true;
    }

    /**
     * 后台数据显示
     */
    private boolean setBaseData(CorpBaseData baseMeta)
    {
        // 文本框数据显示
        this.tf_CorpLcNm.setText(baseMeta.getCorpLcNm());
        this.tf_CorpEnNm.setText(baseMeta.getCorpEnNm());
        this.tf_CorpSite.setText(baseMeta.getCorpSite());
        this.ta_CorpDesp.setText(baseMeta.getCorpDesp());

        // 组合框数据显示
        this.kv_NatnItem = new K2SV1S(baseMeta.getNatnIndx(), "", baseMeta.getNatnName());
        this.cb_CorpNatn.setSelectedItem(kv_NatnItem);

        // 图像标签数据显示
        ib_CorpIcon.setIconHash(baseMeta.getCorpLogo());

        // 状态标记
        isDataUpdt = true;
        isMetaExist = baseMeta.isMetaExist();
        // 数据维持
        if (isMetaExist)
        {
            me_MainSoft.getBaseData().setCorpIndx(baseMeta.getCorpIndx());
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
        // 本语名称
        this.tf_CorpLcNm.setText(value);
        // 英语名称
        this.tf_CorpEnNm.setText(value);
        // 公司网址
        this.tf_CorpSite.setText(value);
        // 相关说明
        this.ta_CorpDesp.setText(value);
        // 软件图标
        this.ib_CorpIcon.setBackgroundImage(null);
    }

    /**
     * 设置构件的可交互性
     * 
     * @param editable 构件是否可交互：true可交互；false不可交互
     */
    public void setEditable(boolean editable)
    {
        isEditable = editable;

        // 英语名称
        this.tf_CorpEnNm.setEditable(editable);
        // 公司网址
        this.tf_CorpSite.setEditable(editable);
        // 相关说明
        this.ta_CorpDesp.setEditable(editable);
        // 公司图标
        this.ib_CorpIcon.setUserEditable(editable);

        // 可交互
        if (editable)
        {
            // 更新按钮
            BeanUtil.setWText(bt_Update, Extparse.getMesg(LangRes.CORP_BUTN_TEXT_INSERT));
            BeanUtil.setWTips(bt_Update, Extparse.getMesg(LangRes.CORP_BUTN_TIPS_INSERT));
            // 删除按钮
            BeanUtil.setWText(bt_Delete, Extparse.getMesg(LangRes.CORP_BUTN_TEXT_CANCEL));
            BeanUtil.setWTips(bt_Delete, Extparse.getMesg(LangRes.CORP_BUTN_TIPS_CANCEL));
        }
        // 不可交互
        else
        {
            // 更新按钮
            BeanUtil.setWText(bt_Update, Extparse.getMesg(LangRes.CORP_BUTN_TEXT_UPDATE));
            BeanUtil.setWTips(bt_Update, Extparse.getMesg(LangRes.CORP_BUTN_TIPS_UPDATE));
            // 删除按钮
            BeanUtil.setWText(bt_Delete, Extparse.getMesg(LangRes.CORP_BUTN_TEXT_DELETE));
            BeanUtil.setWTips(bt_Delete, Extparse.getMesg(LangRes.CORP_BUTN_TIPS_DELETE));
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
    /** 参照按钮 */
    private javax.swing.JButton bt_Refers;
    /** 国别信息 */
    private javax.swing.JComboBox cb_CorpNatn;
    /** 相关说明 */
    private javax.swing.JTextArea ta_CorpDesp;
    /** 英语名称 */
    private javax.swing.JTextField tf_CorpEnNm;
    /** 本语名称 */
    private javax.swing.JTextField tf_CorpLcNm;
    /** 公司网址 */
    private javax.swing.JTextField tf_CorpSite;
    /** 公司图标 */
    private WIconBox ib_CorpIcon;
    /**  */
    private javax.swing.JLabel lb_CorpDesp;
    /**  */
    private javax.swing.JLabel lb_CorpEnNm;
    /**  */
    private javax.swing.JLabel lb_CorpLcNm;
    /**  */
    private javax.swing.JLabel lb_CorpNatn;
    /**  */
    private javax.swing.JLabel lb_CorpSite;
}
