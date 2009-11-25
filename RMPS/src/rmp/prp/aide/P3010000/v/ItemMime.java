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
import rmp.prp.aide.extparse.m.MimeBaseData;
import rmp.prp.aide.extparse.m.MimeUserData;
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
 * MIME类型数据管理面板
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class ItemMime extends javax.swing.JPanel implements WItem, WBackCall
{
    // ////////////////////////////////////////////////////////////////////////
    // 逻辑控制变量区域
    // ////////////////////////////////////////////////////////////////////////
    /**  */
    private static final long serialVersionUID = -2861849203853640176L;
    /** 当前状态是否为可交互状态 */
    private boolean isEditable;
    /** 当前操作是否为数据更新操作 */
    private boolean isDataUpdt;
    /** MIME类型索引 */
    private String mimeType;
    /** MIME列表数据模型 */
    private DefaultListModel lm_MimeType;
    /** 父应用引用 */
    private Extparse me_MainSoft;

    /**
     * @param soft
     */
    public ItemMime()
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.ui.dlg.DViewPanel#init()
     */
    public boolean wInit()
    {
        // 界面初始化
        ica();

        // 界面语言显示
        ita();

        lm_MimeType = new DefaultListModel();
        ls_MimeType.setModel(lm_MimeType);

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
            this.tf_MimeName.setText(kvItem.getV());
            mimeType = kvItem.getK2();

            // 设置数据操作状态为新增状态
            isDataUpdt = false;
        }
    }

    /**
     * @return
     */
    public static MimeBaseData queryByHash(String mimeHash)
    {
        DBAccess dba = new DBAccess();

        try
        {
            MimeBaseData baseMeta = null;
            if (dba.wInit())
            {
                baseMeta = queryByHash(dba, mimeHash);
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
     * @param mimeHash
     * @return
     * @throws SQLException
     */
    public static MimeBaseData queryByHash(DBAccess dba, String mimeHash) throws SQLException
    {
        return DA0008.selectMimeMetaInfo(dba, mimeHash, "");
    }

    /**
     * @return
     */
    public static List<K2SV1S> queryByName(String mimeName)
    {
        DBAccess dba = new DBAccess();

        try
        {
            List<K2SV1S> corpList = null;
            if (dba.wInit())
            {
                corpList = queryByName(dba, mimeName);
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
     * @param mimeType
     * @return
     * @throws SQLException
     */
    public static List<K2SV1S> queryByName(DBAccess dba, String mimeName) throws SQLException
    {
        return DA0008.selectMimeMetaName(dba, "", mimeName);
    }

    /**
     * @param userMeta
     * @return
     */
    public boolean metaDelete(MimeUserData userMeta)
    {
        // 用户删除确认
        String arg1 = Extparse.getMesg(LangRes.MIME_COMN_TEXT_MIMENAME);
        String arg2 = Extparse.getMesg(LangRes.TITLE_MIMEFORM);
        String errMsg = StringUtil.format(LangRes.MESG_DELT_0007, arg1, tf_MimeName.getText(), arg2);
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
            DA0008.deleteMimeMeta(dba, userMeta);
            return true;
        }
        catch (SQLException exp)
        {
            LogUtil.exception(exp);
            String mesg = StringUtil.format(LangRes.MESG_DELT_0006, LangRes.TITLE_MIMEFORM, LangRes.MESG_INIT_0010);
            MesgUtil.showMessageDialog(Extparse.getForm(), mesg);
            return false;
        }
        finally
        {
            dba.closeConnection();
        }
    }

    /**
     * @param mimeType
     * @return
     */
    public boolean hashSelect(String mimeType)
    {
        return setBaseData(queryByHash(mimeType));
    }

    /**
     * @param mimeName
     * @return
     */
    public boolean nameSelect(String mimeName)
    {
        List<K2SV1S> mimeList = queryByName(mimeName);

        if (mimeList == null)
        {
            return false;
        }

        switch (mimeList.size())
        {
            case 0:
                String msg0 = StringUtil.format(LangRes.MESG_SELT_0004, LangRes.MESG_INIT_0010);
                MesgUtil.showMessageDialog(null, msg0);
                return false;
            case 1:
                this.tf_MimeName.setText(mimeList.get(0).getV());
                this.mimeType = mimeList.get(0).getK2();
                isDataUpdt = false;
                return true;
            default:
                String mesg = Extparse.getMesg(LangRes.TITLE_MIMEFORM);
                WListForm.showDialog(null, mesg, mimeList, this);
        }

        return true;
    }

    /**
     * @param userMeta
     * @return
     */
    public boolean metaUpdate(MimeUserData userMeta)
    {
        LogUtil.log("数据更新：MIME类型数据更新！");

        // 连接数据库
        DBAccess dba = new DBAccess();

        try
        {
            if (!dba.wInit())
            {
                return false;
            }

            // 数据更新
            DA0008.updateMimeMeta(dba, userMeta);
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
        javax.swing.JScrollPane sp_MimeType = new javax.swing.JScrollPane();
        ls_MimeType = new javax.swing.JList();
        lb_MimeName = new javax.swing.JLabel();
        tf_MimeName = new javax.swing.JTextField();
        bt_MimeView = new javax.swing.JButton();
        lb_MimeDesp = new javax.swing.JLabel();
        javax.swing.JScrollPane sp_MimeDesp = new javax.swing.JScrollPane();
        ta_MimeDesp = new javax.swing.JTextArea();
        bt_Delete = new javax.swing.JButton();
        bt_Update = new javax.swing.JButton();
        bt_Create = new javax.swing.JButton();

        sp_MimeType.setPreferredSize(new java.awt.Dimension(100, 138));

        ls_MimeType.addListSelectionListener(new javax.swing.event.ListSelectionListener()
        {
            public void valueChanged(javax.swing.event.ListSelectionEvent evt)
            {
                ls_MimeType_Handler(evt);
            }
        });
        sp_MimeType.setViewportView(ls_MimeType);

        lb_MimeName.setDisplayedMnemonic('M');
        lb_MimeName.setLabelFor(tf_MimeName);
        lb_MimeName.setText("MIME\u540d\u79f0(M)");

        tf_MimeName.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                tf_MimeName_Handler(evt);
            }
        });

        bt_MimeView.setMnemonic('V');
        bt_MimeView.setText("V");
        bt_MimeView.setToolTipText("\u53c2\u7167\u5df2\u6709MIME\u7c7b\u578b");
        bt_MimeView.setMargin(new java.awt.Insets(0, 0, 0, 0));
        bt_MimeView.setMaximumSize(new java.awt.Dimension(20, 20));
        bt_MimeView.setMinimumSize(new java.awt.Dimension(16, 16));
        bt_MimeView.setPreferredSize(new java.awt.Dimension(18, 18));
        bt_MimeView.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_MimeView_Handler(evt);
            }
        });

        lb_MimeDesp.setDisplayedMnemonic('P');
        lb_MimeDesp.setLabelFor(ta_MimeDesp);
        lb_MimeDesp.setText("\u76f8\u5173\u8bf4\u660e(P)");

        ta_MimeDesp.setColumns(30);
        ta_MimeDesp.setEditable(false);
        ta_MimeDesp.setLineWrap(true);
        ta_MimeDesp.setRows(5);
        sp_MimeDesp.setViewportView(ta_MimeDesp);

        bt_Delete.setMnemonic('D');
        bt_Delete.setText("\u5220\u9664(D)");
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
                layout.createSequentialGroup().addContainerGap().addComponent(sp_MimeType,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_MimeName).addComponent(lb_MimeDesp).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING, false).addGroup(
                layout.createSequentialGroup().addComponent(tf_MimeName).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_MimeView,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE)).addComponent(sp_MimeDesp,
                javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))).addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)).addGroup(
                javax.swing.GroupLayout.Alignment.TRAILING,
                layout.createSequentialGroup().addContainerGap(137, Short.MAX_VALUE).addComponent(bt_Create).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_Update).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_Delete).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING, false).addComponent(sp_MimeType,
                javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE).addGroup(
                javax.swing.GroupLayout.Alignment.LEADING,
                layout.createSequentialGroup().addComponent(lb_MimeName).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(
                bt_MimeView, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(tf_MimeName,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addComponent(lb_MimeDesp).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(sp_MimeDesp,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE))).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE,
                Short.MAX_VALUE).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(bt_Delete).addComponent(bt_Update).addComponent(bt_Create)).addContainerGap()));
    }

    /**
     * @param isHash
     */
    private void ita()
    {
        // MIME列表
        BeanUtil.setWTips(ls_MimeType, Extparse.getMesg(LangRes.MIME_LIST_TIPS_MIMETYPE));

        // MIME名称
        BeanUtil.setWText(lb_MimeName, Extparse.getMesg(LangRes.MIME_LABL_TEXT_MIMENAME));
        BeanUtil.setWTips(lb_MimeName, Extparse.getMesg(LangRes.MIME_LABL_TIPS_MIMENAME));

        BeanUtil.setWText(tf_MimeName, Extparse.getMesg(LangRes.MIME_FILD_TEXT_MIMENAME));
        BeanUtil.setWTips(tf_MimeName, Extparse.getMesg(LangRes.MIME_FILD_TIPS_MIMENAME));

        // 相关说明
        BeanUtil.setWText(lb_MimeDesp, Extparse.getMesg(LangRes.MIME_LABL_TEXT_MIMEDESP));
        BeanUtil.setWTips(lb_MimeDesp, Extparse.getMesg(LangRes.MIME_LABL_TIPS_MIMEDESP));

        BeanUtil.setWText(ta_MimeDesp, Extparse.getMesg(LangRes.MIME_AREA_TEXT_MIMEDESP));
        BeanUtil.setWTips(ta_MimeDesp, Extparse.getMesg(LangRes.MIME_AREA_TIPS_MIMEDESP));

        // 新增按钮
        BeanUtil.setWText(bt_Create, Extparse.getMesg(LangRes.MIME_BUTN_TEXT_CREATE));
        BeanUtil.setWTips(bt_Create, Extparse.getMesg(LangRes.MIME_BUTN_TIPS_CREATE));

        // 更新按钮
        BeanUtil.setWText(bt_Update, Extparse.getMesg(LangRes.MIME_BUTN_TEXT_UPDATE));
        BeanUtil.setWTips(bt_Update, Extparse.getMesg(LangRes.MIME_BUTN_TIPS_UPDATE));

        // 删除按钮
        BeanUtil.setWText(bt_Delete, Extparse.getMesg(LangRes.MIME_BUTN_TEXT_DELETE));
        BeanUtil.setWTips(bt_Delete, Extparse.getMesg(LangRes.MIME_BUTN_TIPS_DELETE));

        // 参照
        BeanUtil.setWTips(bt_MimeView, Extparse.getMesg(LangRes.MIME_BUTN_TIPS_MIMEVIEW));
    }

    // ////////////////////////////////////////////////////////////////////////
    // 事件处理区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 更新按钮事件处理
     * 
     * @param evt
     */
    private void bt_Create_Handler(java.awt.event.ActionEvent evt)
    {
        // 不可交互状态时的处理：显示交互界面
        if (!isEditable)
        {
            setEditable(true);
            me_MainSoft.getSoftForm().setTitle(Extparse.getMesg(LangRes.TITLE_MIMEFORM) + LangRes.TITLE_INSERT);
        }

        // 清除界面已有数据
        setDefault("");

        // 焦点设置
        this.tf_MimeName.requestFocus();

        // 状态标记设置为新增状态
        isDataUpdt = false;
        mimeType = ConstUI.DEF_MIMEHASH;
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
            MimeUserData userMeta = new MimeUserData();
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
                setBaseData(queryByHash(userMeta.getMimeIndx()));

                // 焦点设置
                this.tf_MimeName.requestFocus();

                isDataUpdt = false;
            }
        }
        // 可交互状态时的处理：显示不可交互状态
        else
        {
            setEditable(false);
            me_MainSoft.getSoftForm().setTitle(Extparse.getMesg(LangRes.TITLE_MIMEFORM));
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
            me_MainSoft.getSoftForm().setTitle(Extparse.getMesg(LangRes.TITLE_MIMEFORM) + LangRes.TITLE_UPDATE);

            // 焦点设置
            this.tf_MimeName.requestFocus();

            // 状态标记设置为更新状态
            isDataUpdt = true;
        }
        // 可交互状态时的处理：进行数据的新增更新
        else
        {
            // 默认数据不执行任何操作
            if ("0".equals(me_MainSoft.getBaseData().getMimeIndx()))
            {
                return;
            }

            // 用户数据对象
            MimeUserData userMeta = new MimeUserData();
            userMeta.wInit();

            if (!getUserData(userMeta, false))
            {
                return;
            }

            LogUtil.log("数据更新：MIME类型数据更新 － " + userMeta.getMimeName());

            // 数据新增状态下检测数据是否已存在
            if (!isDataUpdt)
            {
                K1SV2S kvItem;
                // 数据存在性检测
                for (int i = 0, j = lm_MimeType.size(); i < j; i += 1)
                {
                    kvItem = (K1SV2S) lm_MimeType.elementAt(i);
                    if (userMeta.getMimeName().equals(kvItem.getV1()))
                    {
                        // 提示用户是否覆盖已有数据。
                        String msg = StringUtil.format(LangRes.MIME_MESG_UPDT_0001, userMeta.getMimeName());
                        if (0 != MesgUtil.showConfirmDialog(null, msg))
                        {
                            return;
                        }
                    }
                }
            }

            // 数据更新
            if (metaUpdate(userMeta))
            {
                // 清空界面显示数据
                setDefault("");

                // 数据列表更新显示
                setBaseData(queryByHash(userMeta.getMimeIndx()));

                // 焦点设置
                this.tf_MimeName.requestFocus();

                // 状态标记设置为新增状态
                isDataUpdt = false;
            }
        }
    }

    /**
     * @param evt
     */
    private void bt_MimeView_Handler(java.awt.event.ActionEvent evt)
    {
        nameSelect("");
    }

    /**
     * MIME类型列表事件处理
     * 
     * @param evt
     */
    private void ls_MimeType_Handler(javax.swing.event.ListSelectionEvent evt)
    {
        K1SV2S kvItem = (K1SV2S) this.ls_MimeType.getSelectedValue();
        if (kvItem == null)
        {
            return;
        }

        this.mimeType = kvItem.getK();
        this.tf_MimeName.setText(kvItem.getV1());
        this.ta_MimeDesp.setText(kvItem.getV2());

        isDataUpdt = true;
    }

    /**
     * @param evt
     */
    private void tf_MimeName_Handler(java.awt.event.ActionEvent evt)
    {
        nameSelect(this.tf_MimeName.getText());
    }

    // ////////////////////////////////////////////////////////////////////////
    // 公共接口区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @param userMeta
     * @return
     */
    private boolean getUserData(MimeUserData userMeta)
    {
        return getUserData(userMeta, true);
    }

    /**
     * @param userMeta
     * @param keysOnly
     * @return
     */
    private boolean getUserData(MimeUserData userMeta, boolean keysOnly)
    {
        // 数据操作状态
        userMeta.setUpdate(isDataUpdt);

        // MIME索引
        userMeta.setMimeIndx(me_MainSoft.getBaseData().getMimeIndx());

        // 类型索引
        if (!userMeta.setMimeType(mimeType))
        {
            MesgUtil.showMessageDialog(Extparse.getForm(), userMeta.getErrMsg());
            return false;
        }

        if (keysOnly)
        {
            return true;
        }

        // 类型名称
        if (!userMeta.setMimeName(this.tf_MimeName.getText()))
        {
            MesgUtil.showMessageDialog(Extparse.getForm(), userMeta.getErrMsg());
            return false;
        }

        // 类型说明
        if (!userMeta.setMimeDesp(this.ta_MimeDesp.getText()))
        {
            MesgUtil.showMessageDialog(Extparse.getForm(), userMeta.getErrMsg());
            return false;
        }

        return true;
    }

    /**
     * @param baseMeta
     * @return
     */
    private boolean setBaseData(MimeBaseData baseMeta)
    {
        lm_MimeType.clear();

        List<K1SV2S> mimeList = baseMeta.getMimeList();
        for (int i = 0, j = mimeList.size(); i < j; i += 1)
        {
            lm_MimeType.addElement(mimeList.get(i));
        }
        return false;
    }

    /**
     * @param value
     */
    public void setDefault(String value)
    {
        // 类型名称
        this.tf_MimeName.setText(value);
        // 类型说明
        this.ta_MimeDesp.setText(value);
    }

    /**
     * @param editable
     */
    public void setEditable(boolean editable)
    {
        isEditable = editable;

        // 相关说明
        this.ta_MimeDesp.setEditable(editable);

        // 可交互
        if (editable)
        {
            // 更新按钮
            BeanUtil.setWText(bt_Update, Extparse.getMesg(LangRes.MIME_BUTN_TEXT_INSERT));
            BeanUtil.setWTips(bt_Update, Extparse.getMesg(LangRes.MIME_BUTN_TIPS_INSERT));
            // 删除按钮
            BeanUtil.setWText(bt_Delete, Extparse.getMesg(LangRes.MIME_BUTN_TEXT_CANCEL));
            BeanUtil.setWTips(bt_Delete, Extparse.getMesg(LangRes.MIME_BUTN_TIPS_CANCEL));
        }
        // 不可交互
        else
        {
            // 更新按钮
            BeanUtil.setWText(bt_Update, Extparse.getMesg(LangRes.MIME_BUTN_TEXT_UPDATE));
            BeanUtil.setWTips(bt_Update, Extparse.getMesg(LangRes.MIME_BUTN_TIPS_UPDATE));
            // 删除按钮
            BeanUtil.setWText(bt_Delete, Extparse.getMesg(LangRes.MIME_BUTN_TEXT_DELETE));
            BeanUtil.setWTips(bt_Delete, Extparse.getMesg(LangRes.MIME_BUTN_TIPS_DELETE));
        }
    }
    // ////////////////////////////////////////////////////////////////////////
    // 界面组件变量区域
    // ////////////////////////////////////////////////////////////////////////
    /** 数据删除按钮 */
    private javax.swing.JButton bt_Create;
    /** 数据新增按钮 */
    private javax.swing.JButton bt_Delete;
    /** 数据更新按钮 */
    private javax.swing.JButton bt_Update;
    /** 参照按钮 */
    private javax.swing.JButton bt_MimeView;
    /** MIME类型列表 */
    private javax.swing.JList ls_MimeType;
    /** MIME类型描述 */
    private javax.swing.JTextArea ta_MimeDesp;
    /** MIME类型名称 */
    private javax.swing.JTextField tf_MimeName;
    private javax.swing.JLabel lb_MimeDesp;
    private javax.swing.JLabel lb_MimeName;
}
