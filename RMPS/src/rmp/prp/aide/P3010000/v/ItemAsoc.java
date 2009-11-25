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

import javax.swing.DefaultListModel;

import rmp.bean.K1SV2S;
import rmp.bean.K2SV1S;
import rmp.face.WBackCall;
import rmp.io.db.DBAccess;
import rmp.prp.aide.P3010000.b.WListForm;
import rmp.prp.aide.P3010000.i.WItem;
import rmp.prp.aide.extparse.Extparse;
import rmp.prp.aide.extparse.d.DA0008;
import rmp.prp.aide.extparse.m.AsocBaseData;
import rmp.prp.aide.extparse.m.AsocUserData;
import rmp.util.BeanUtil;
import rmp.util.LogUtil;
import rmp.util.MesgUtil;
import rmp.util.StringUtil;
import cons.prp.aide.P3010000.ConstUI;
import cons.prp.aide.P3010000.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 备选软件数据管理面板
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class ItemAsoc extends javax.swing.JPanel implements WItem, WBackCall
{
    // ////////////////////////////////////////////////////////////////////////
    // 界面控制变量区域
    // ////////////////////////////////////////////////////////////////////////
    /** 当前状态是否为可交互状态 */
    private boolean isEditable;
    /** 当前操作是否为数据更新操作 */
    private boolean isDataUpdt;
    /** 软件索引 */
    private String softHash;
    /** 软件列表数据模型 */
    private DefaultListModel lm_AsocSoft;
    /** 父应用引用 */
    private Extparse me_MainSoft;

    /**
     * @param soft
     */
    public ItemAsoc()
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    public boolean wInit()
    {
        // 控制变量初始化
        isEditable = false;
        isDataUpdt = false;
        softHash = ConstUI.DEF_SOFTHASH;

        // 界面初始化
        ica();
        ita();

        lm_AsocSoft = new DefaultListModel();
        ls_AsocSoft.setModel(lm_AsocSoft);

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
            this.tf_AsocSoft.setText(kvItem.getV());
            softHash = kvItem.getK1();

            // 设置数据操作状态为新增状态
            isDataUpdt = false;
        }
    }

    /**
     * 按备选软件索引查寻备选软件详细信息
     * 
     * @param asocHash 备选软件索引
     * @return
     */
    public static AsocBaseData queryByHash(String asocHash)
    {
        DBAccess dba = new DBAccess();

        try
        {
            AsocBaseData baseMeta = null;
            if (dba.wInit())
            {
                baseMeta = queryByHash(dba, asocHash);
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
     * 按备选软件索引查寻备选软件详细信息
     * 
     * @param dba
     * @param asocHash
     * @return
     * @throws SQLException
     */
    public static AsocBaseData queryByHash(DBAccess dba, String asocHash) throws SQLException
    {
        return DA0008.selectAsocMetaInfo(dba, asocHash, "");
    }

    /**
     * 按公司及软件名称查询软件列表数据
     * 
     * @param softName
     * @return
     */
    public static List<K2SV1S> queryByName(String softName)
    {
        DBAccess dba = new DBAccess();

        try
        {
            List<K2SV1S> corpList = null;
            if (dba.wInit())
            {
                corpList = queryByName(dba, softName);
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
     * 按软件名称查询备选软件数据列表
     * 
     * @param dba
     * @param softName 软件名称
     * @return
     * @throws SQLException
     */
    public static List<K2SV1S> queryByName(DBAccess dba, String softName) throws SQLException
    {
        return DA0008.selectSoftMetaName(dba, "", softName);
    }

    /**
     * 备选软件数据删除
     * 
     * @param userMeta 用户输入数据
     * @return
     */
    public boolean metaDelete(AsocUserData userMeta)
    {
        // 用户删除确认
        String arg1 = Extparse.getMesg(LangRes.ASOC_COMN_TEXT_ASOCSOFT);
        String arg2 = Extparse.getMesg(LangRes.TITLE_ASOCFORM);
        String errMsg = StringUtil.format(LangRes.MESG_DELT_0007, arg1, tf_AsocSoft.getText(), arg2);
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
            DA0008.deleteAsocMeta(dba, userMeta);
            return true;
        }
        catch (SQLException exp)
        {
            LogUtil.exception(exp);
            String mesg = StringUtil.format(LangRes.MESG_DELT_0006, LangRes.TITLE_ASOCFORM, LangRes.MESG_INIT_0010);
            MesgUtil.showMessageDialog(Extparse.getForm(), mesg);
            return false;
        }
        finally
        {
            dba.closeConnection();
        }
    }

    /**
     * 按备选软件的索引查询详细信息
     * 
     * @param asocHash 备选软件索引
     * @return
     */
    public boolean hashSelect(String asocHash)
    {
        setBaseData(queryByHash(asocHash));

        return true;
    }

    /**
     * 按备选软件的名称查询详细信息
     * 
     * @param asocName 备选软件名称
     * @return
     */
    public boolean nameSelect(String softName)
    {
        List<K2SV1S> softList = ItemSoft.queryByName("", softName);

        if (softList == null)
        {
            return false;
        }

        switch (softList.size())
        {
            case 0:
                String msg0 = StringUtil.format(LangRes.MESG_SELT_0004, LangRes.MESG_INIT_0010);
                MesgUtil.showMessageDialog(this, msg0);
                return false;

            case 1:
                this.softHash = softList.get(0).getK1();
                this.tf_AsocSoft.setText(softList.get(0).getV());
                // 新增备选软件
                isDataUpdt = false;
                return true;

            default:
                String mesg = Extparse.getMesg(LangRes.TITLE_ASOCFORM);
                WListForm.showDialog(null, mesg, softList, this);
        }
        return true;
    }

    /**
     * 备选软件数据更新
     * 
     * @param userMeta 用户数据
     * @return
     */
    public boolean metaUpdate(AsocUserData userMeta)
    {
        LogUtil.log("数据更新：备选软件数据更新！");

        // 连接数据库
        DBAccess dba = new DBAccess();

        try
        {
            if (!dba.wInit())
            {
                return false;
            }

            // 数据更新
            DA0008.updateAsocMeta(dba, userMeta);
            return true;
        }
        catch (SQLException exp)
        {
            LogUtil.exception(exp);
            String mesg = StringUtil.format(LangRes.MESG_UPDT_0005, LangRes.TITLE_ASOCFORM, LangRes.MESG_INIT_0010);
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
     * 
     */
    private void ica()
    {
        javax.swing.JScrollPane sp_AsocSoft = new javax.swing.JScrollPane();
        ls_AsocSoft = new javax.swing.JList();
        lb_AsocSoft = new javax.swing.JLabel();
        tf_AsocSoft = new javax.swing.JTextField();
        bt_AsocView = new javax.swing.JButton();
        bt_AsocInfo = new javax.swing.JButton();
        lb_AsocDesp = new javax.swing.JLabel();
        javax.swing.JScrollPane sp_AsocDesp = new javax.swing.JScrollPane();
        ta_AsocDesp = new javax.swing.JTextArea();
        bt_Delete = new javax.swing.JButton();
        bt_Update = new javax.swing.JButton();
        bt_Create = new javax.swing.JButton();

        sp_AsocSoft.setPreferredSize(new java.awt.Dimension(100, 138));

        ls_AsocSoft.setSelectionMode(javax.swing.ListSelectionModel.SINGLE_SELECTION);
        ls_AsocSoft.setToolTipText("\u5df2\u6709\u5907\u9009\u8f6f\u4ef6\u5217\u8868");
        ls_AsocSoft.addListSelectionListener(new javax.swing.event.ListSelectionListener()
        {
            public void valueChanged(javax.swing.event.ListSelectionEvent evt)
            {
                ls_AsocSoft_Handler(evt);
            }
        });
        sp_AsocSoft.setViewportView(ls_AsocSoft);

        lb_AsocSoft.setDisplayedMnemonic('A');
        lb_AsocSoft.setLabelFor(tf_AsocSoft);
        lb_AsocSoft.setText("\u5907\u9009\u8f6f\u4ef6(A)");

        tf_AsocSoft.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                tf_AsocSoft_Handler(evt);
            }
        });

        bt_AsocView.setMnemonic('V');
        bt_AsocView.setText("V");
        bt_AsocView.setToolTipText("\u53c2\u7167\u5df2\u6709\u8f6f\u4ef6");
        bt_AsocView.setMargin(new java.awt.Insets(0, 0, 0, 0));
        bt_AsocView.setMaximumSize(new java.awt.Dimension(20, 20));
        bt_AsocView.setMinimumSize(new java.awt.Dimension(16, 16));
        bt_AsocView.setPreferredSize(new java.awt.Dimension(18, 18));
        bt_AsocView.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_AsocView_Handler(evt);
            }
        });

        bt_AsocInfo.setMnemonic('I');
        bt_AsocInfo.setText("I");
        bt_AsocInfo.setToolTipText("\u67e5\u770b\u8f6f\u4ef6\u7684\u8be6\u7ec6\u4fe1\u606f");
        bt_AsocInfo.setMargin(new java.awt.Insets(0, 0, 0, 0));
        bt_AsocInfo.setMaximumSize(new java.awt.Dimension(20, 20));
        bt_AsocInfo.setMinimumSize(new java.awt.Dimension(16, 16));
        bt_AsocInfo.setPreferredSize(new java.awt.Dimension(18, 18));
        bt_AsocInfo.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_AsocInfo_Handler(evt);
            }
        });

        lb_AsocDesp.setDisplayedMnemonic('P');
        lb_AsocDesp.setLabelFor(ta_AsocDesp);
        lb_AsocDesp.setText("\u76f8\u5173\u8bf4\u660e(P)");

        ta_AsocDesp.setColumns(30);
        ta_AsocDesp.setEditable(false);
        ta_AsocDesp.setLineWrap(true);
        ta_AsocDesp.setRows(5);
        ta_AsocDesp.setToolTipText("\u76f8\u5173\u8bf4\u660e");
        sp_AsocDesp.setViewportView(ta_AsocDesp);

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
        bt_Update.setToolTipText("\u6dfb\u52a0\u65b0\u6570\u636e\u6216\u66f4\u65b0\u5df2\u6709\u6570\u636e");
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
        bt_Create.setToolTipText("\u663e\u793a\u65b0\u589e\u754c\u9762");
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
                layout.createSequentialGroup().addContainerGap().addComponent(sp_AsocSoft,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_AsocSoft).addComponent(lb_AsocDesp).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING, false).addGroup(
                layout.createSequentialGroup().addComponent(tf_AsocSoft).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_AsocView,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_AsocInfo,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE)).addComponent(sp_AsocDesp,
                javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))).addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)).addGroup(
                javax.swing.GroupLayout.Alignment.TRAILING,
                layout.createSequentialGroup().addContainerGap(137, Short.MAX_VALUE).addComponent(bt_Create).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_Update).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_Delete).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING, false).addComponent(sp_AsocSoft,
                javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE).addGroup(
                javax.swing.GroupLayout.Alignment.LEADING,
                layout.createSequentialGroup().addComponent(lb_AsocSoft).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(
                bt_AsocInfo, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(bt_AsocView,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(tf_AsocSoft,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addComponent(lb_AsocDesp).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(sp_AsocDesp,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE))).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE,
                Short.MAX_VALUE).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(bt_Delete).addComponent(bt_Update).addComponent(bt_Create)).addContainerGap()));
    }

    /**
     * 界面语言初始化
     * 
     * @param isHash
     */
    private void ita()
    {
        // 软件列表
        BeanUtil.setWTips(ls_AsocSoft, Extparse.getMesg(LangRes.ASOC_LIST_TIPS_ASOCSOFT));

        // 备选软件
        BeanUtil.setWText(lb_AsocSoft, Extparse.getMesg(LangRes.ASOC_LABL_TEXT_ASOCSOFT));
        BeanUtil.setWTips(lb_AsocSoft, Extparse.getMesg(LangRes.ASOC_LABL_TIPS_ASOCSOFT));

        BeanUtil.setWText(tf_AsocSoft, Extparse.getMesg(LangRes.ASOC_FILD_TEXT_ASOCSOFT));
        BeanUtil.setWTips(tf_AsocSoft, Extparse.getMesg(LangRes.ASOC_FILD_TIPS_ASOCSOFT));

        // 相关说明
        BeanUtil.setWText(lb_AsocDesp, Extparse.getMesg(LangRes.ASOC_LABL_TEXT_ASOCDESP));
        BeanUtil.setWTips(lb_AsocDesp, Extparse.getMesg(LangRes.ASOC_LABL_TIPS_ASOCDESP));

        BeanUtil.setWText(ta_AsocDesp, Extparse.getMesg(LangRes.ASOC_AREA_TEXT_ASOCDESP));
        BeanUtil.setWTips(ta_AsocDesp, Extparse.getMesg(LangRes.ASOC_AREA_TIPS_ASOCDESP));

        // 新增按钮
        BeanUtil.setWText(bt_Create, Extparse.getMesg(LangRes.ASOC_BUTN_TEXT_CREATE));
        BeanUtil.setWTips(bt_Create, Extparse.getMesg(LangRes.ASOC_BUTN_TIPS_CREATE));

        // 更新按钮
        BeanUtil.setWText(bt_Update, Extparse.getMesg(LangRes.ASOC_BUTN_TEXT_UPDATE));
        BeanUtil.setWTips(bt_Update, Extparse.getMesg(LangRes.ASOC_BUTN_TIPS_UPDATE));

        // 删除按钮
        BeanUtil.setWText(bt_Delete, Extparse.getMesg(LangRes.ASOC_BUTN_TEXT_DELETE));
        BeanUtil.setWTips(bt_Delete, Extparse.getMesg(LangRes.ASOC_BUTN_TIPS_DELETE));

        // 参照
        BeanUtil.setWText(bt_AsocView, Extparse.getMesg(LangRes.ASOC_BUTN_TEXT_ASOCVIEW));
        BeanUtil.setWTips(bt_AsocView, Extparse.getMesg(LangRes.ASOC_BUTN_TIPS_ASOCVIEW));

        // 详细
        BeanUtil.setWText(bt_AsocInfo, Extparse.getMesg(LangRes.ASOC_BUTN_TEXT_ASOCINFO));
        BeanUtil.setWTips(bt_AsocInfo, Extparse.getMesg(LangRes.ASOC_BUTN_TIPS_ASOCINFO));
    }

    // ////////////////////////////////////////////////////////////////////////
    // 事件处理区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 新增按钮事件处理
     */
    private void bt_Create_Handler(java.awt.event.ActionEvent evt)
    {
        // 不可交互状态时的处理：显示交互界面
        if (!isEditable)
        {
            setEditable(true);
            me_MainSoft.getSoftForm().setTitle(Extparse.getMesg(LangRes.TITLE_ASOCFORM) + LangRes.TITLE_INSERT);
        }

        // 清除界面已有数据
        setDefault("");

        // 焦点设置
        this.tf_AsocSoft.requestFocus();

        // 状态标记设置为新增状态
        isDataUpdt = false;
        softHash = ConstUI.DEF_SOFTHASH;
    }

    /**
     * 删除按钮事件处理
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
            AsocUserData userMeta = new AsocUserData();
            userMeta.wInit();

            // 用户输入关键信息读取
            if (!getUserData(userMeta))
            {
                return;
            }

            // 数据删除
            if (metaDelete(userMeta))
            {
                // 清空界面显示数据
                setDefault("");

                // 数据列表更新显示
                setBaseData(queryByHash(userMeta.getAsocIndx()));

                // 焦点设置
                this.tf_AsocSoft.requestFocus();

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
     */
    private void bt_Update_Handler(java.awt.event.ActionEvent evt)
    {
        // 不可交互状态时的处理：显示交互界面
        if (!isEditable)
        {
            LogUtil.log("状态切换：显示数据更新状态！");

            // 显示可交互界面
            setEditable(true);
            me_MainSoft.getSoftForm().setTitle(Extparse.getMesg(LangRes.TITLE_ASOCFORM) + LangRes.TITLE_UPDATE);

            // 焦点设置
            this.tf_AsocSoft.requestFocus();

            // 状态标记设置为更新状态
            isDataUpdt = true;
        }
        // 可交互状态时的处理：进行数据的新增更新
        else
        {
            // 默认数据不执行任何操作
            if ("0".equals(me_MainSoft.getBaseData().getAsocIndx()))
            {
                return;
            }

            LogUtil.log("数据更新：备选软件数据更新 － " + this.tf_AsocSoft.getText());

            // 数据新新增状态下检测数据是否已存在
            if (!isDataUpdt)
            {
                K1SV2S kvItem;
                // 数据存在性检测
                for (int i = 0, j = lm_AsocSoft.size(); i < j; i += 1)
                {
                    kvItem = (K1SV2S) lm_AsocSoft.elementAt(i);
                    if (softHash == kvItem.getK())
                    {
                        // 提示用户是否覆盖已有数据。
                        String msg = StringUtil.format(LangRes.ASOC_MESG_UPDT_0003, kvItem.getV1());
                        if (0 != MesgUtil.showConfirmDialog(null, msg))
                        {
                            return;
                        }

                        // 设置操作状态为数据更新
                        isDataUpdt = true;
                    }
                }
            }

            // 用户数据对象
            AsocUserData userMeta = new AsocUserData();
            userMeta.wInit();

            if (!getUserData(userMeta, false))
            {
                return;
            }

            // 数据更新
            if (metaUpdate(userMeta))
            {
                // 清空界面显示数据
                setDefault("");

                // 数据列表更新显示
                setBaseData(queryByHash(userMeta.getAsocIndx()));

                // 焦点设置
                this.tf_AsocSoft.requestFocus();

                // 状态标记设置为新增状态
                isDataUpdt = false;
            }
        }
    }

    /**
     * 参照链接标签事件处理
     */
    private void bt_AsocView_Handler(java.awt.event.ActionEvent evt)
    {
        nameSelect("");
    }

    /**
     * @param evt
     */
    private void ls_AsocSoft_Handler(javax.swing.event.ListSelectionEvent evt)
    {
        K1SV2S kvItem = (K1SV2S) this.ls_AsocSoft.getSelectedValue();
        if (kvItem == null)
        {
            return;
        }

        this.softHash = kvItem.getK();
        this.tf_AsocSoft.setText(kvItem.getV1());
        this.ta_AsocDesp.setText(kvItem.getV2());

        isDataUpdt = true;
    }

    /**
     * @param evt
     */
    private void bt_AsocInfo_Handler(java.awt.event.ActionEvent evt)
    {
        if (!ConstUI.DEF_SOFTHASH.equals(softHash))
        {
            me_MainSoft.showSoftForm();
            me_MainSoft.getSoftPanel().hashSelect(softHash);
        }
    }

    /**
     * @param evt
     */
    private void tf_AsocSoft_Handler(java.awt.event.ActionEvent evt)
    {
        nameSelect(this.tf_AsocSoft.getText());
    }

    // ////////////////////////////////////////////////////////////////////////
    // 公共接口区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 用户输入关键信息读取
     * 
     * @param userMeta
     * @return
     */
    private boolean getUserData(AsocUserData userMeta)
    {
        return getUserData(userMeta, true);
    }

    /**
     * @param userMeta
     * @return
     */
    private boolean getUserData(AsocUserData userMeta, boolean keysOnly)
    {
        // 数据操作状态
        userMeta.setUpdate(isDataUpdt);

        // 后缀索引
        userMeta.setAsocIndx(me_MainSoft.getBaseData().getAsocIndx());

        // 软件索引
        if (!userMeta.setSoftIndx(softHash))
        {
            MesgUtil.showMessageDialog(Extparse.getForm(), userMeta.getErrMsg());
            return false;
        }

        if (keysOnly)
        {
            return true;
        }

        // 相关说明
        if (!userMeta.setAsocDesp(this.ta_AsocDesp.getText()))
        {
            MesgUtil.showMessageDialog(Extparse.getForm(), userMeta.getErrMsg());
            return false;
        }
        return true;
    }

    /**
     * @param baseMeta
     */
    private boolean setBaseData(AsocBaseData baseMeta)
    {
        // 清除已有显示数据
        lm_AsocSoft.clear();

        // 数据结果
        List<K1SV2S> asocList = baseMeta.getAsocList();

        // 数据显示
        for (int i = 0, j = asocList.size(); i < j; i += 1)
        {
            lm_AsocSoft.addElement(asocList.get(i));
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
        this.tf_AsocSoft.setText(value);
        // 相关说明
        this.ta_AsocDesp.setText(value);
    }

    /**
     * 设置构件的可交互性
     * 
     * @param editable 构件是否可交互：true可交互；false不可交互
     */
    public void setEditable(boolean editable)
    {
        isEditable = editable;

        // 相关说明
        this.ta_AsocDesp.setEditable(editable);

        // 可交互
        if (editable)
        {
            // 更新按钮
            BeanUtil.setWText(bt_Update, Extparse.getMesg(LangRes.ASOC_BUTN_TEXT_INSERT));
            BeanUtil.setWTips(bt_Update, Extparse.getMesg(LangRes.ASOC_BUTN_TIPS_INSERT));
            // 删除按钮
            BeanUtil.setWText(bt_Delete, Extparse.getMesg(LangRes.ASOC_BUTN_TEXT_CANCEL));
            BeanUtil.setWTips(bt_Delete, Extparse.getMesg(LangRes.ASOC_BUTN_TIPS_CANCEL));
        }
        // 不可交互
        else
        {
            // 更新按钮
            BeanUtil.setWText(bt_Update, Extparse.getMesg(LangRes.ASOC_BUTN_TEXT_UPDATE));
            BeanUtil.setWTips(bt_Update, Extparse.getMesg(LangRes.ASOC_BUTN_TIPS_UPDATE));
            // 删除按钮
            BeanUtil.setWText(bt_Delete, Extparse.getMesg(LangRes.ASOC_BUTN_TEXT_DELETE));
            BeanUtil.setWTips(bt_Delete, Extparse.getMesg(LangRes.ASOC_BUTN_TIPS_DELETE));
        }
    }
    // ////////////////////////////////////////////////////////////////////////
    // 界面组件变量区域
    // ////////////////////////////////////////////////////////////////////////
    /** 按钮：新增按钮 */
    private javax.swing.JButton bt_Create;
    /** 按钮：取消按钮 */
    private javax.swing.JButton bt_Delete;
    /** 按钮：更新按钮 */
    private javax.swing.JButton bt_Update;
    /** 按钮：软件参照 */
    private javax.swing.JButton bt_AsocView;
    /** 按钮：软件信息 */
    private javax.swing.JButton bt_AsocInfo;
    /** 列表：备选软件 */
    private javax.swing.JList ls_AsocSoft;
    /** 文本：相关说明 */
    private javax.swing.JTextArea ta_AsocDesp;
    /** 文本：软件名称 */
    private javax.swing.JTextField tf_AsocSoft;
    /** 标签：相关说明 */
    private javax.swing.JLabel lb_AsocDesp;
    /** 标签：备选软件 */
    private javax.swing.JLabel lb_AsocSoft;
}
