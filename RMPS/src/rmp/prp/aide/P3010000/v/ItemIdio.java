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

import rmp.bean.K2SV1S;
import rmp.face.WBackCall;
import rmp.io.db.DBAccess;
import rmp.prp.aide.P3010000.b.WListForm;
import rmp.prp.aide.P3010000.i.WItem;
import rmp.prp.aide.extparse.Extparse;
import rmp.prp.aide.extparse.b.WIconBox;
import rmp.prp.aide.extparse.d.DA0008;
import rmp.prp.aide.extparse.m.IdioBaseData;
import rmp.prp.aide.extparse.m.IdioUserData;
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
 * 个人信息数据管理面板
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class ItemIdio extends javax.swing.JPanel implements WItem, WBackCall
{
    // ////////////////////////////////////////////////////////////////////////
    // 界面控制变量区域
    // ////////////////////////////////////////////////////////////////////////
    /**  */
    private static final long serialVersionUID = 3016375149280823025L;
    /** 当前状态是否为可交互状态 */
    private boolean isEditable;
    /** 当前操作是否为数据更新操作 */
    private boolean isDataUpdt;
    /** 数据是否存在 */
    private boolean isMetaExist;
    /** 父应用引用 */
    private Extparse me_MainSoft;

    /**
     * @param soft
     */
    public ItemIdio()
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

        ib_IdioIcon.setIconPath(EnvUtil.getIconIdioDir());

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
            IdioBaseData baseMeta = queryByHash(kvItem.getK1());
            setBaseData(baseMeta);
        }
    }

    /**
     * @param idioMail
     * @return
     */
    public static List<K2SV1S> queryByName(String idioMail)
    {
        DBAccess dba = new DBAccess();

        List<K2SV1S> idioList = null;
        try
        {
            if (dba.wInit())
            {
                idioList = queryByName(dba, idioMail);
            }
        }
        catch (SQLException exp)
        {
            LogUtil.exception(exp);
        }
        finally
        {
            dba.closeConnection();
        }
        return idioList;
    }

    /**
     * @param dba
     * @param idioMail
     * @return
     * @throws SQLException
     */
    public static List<K2SV1S> queryByName(DBAccess dba, String idioMail) throws SQLException
    {
        return DA0008.selectIdioMetaName(dba, idioMail);
    }

    /**
     * @param idioHash
     * @return
     */
    public static IdioBaseData queryByHash(String idioHash)
    {
        DBAccess dba = new DBAccess();

        IdioBaseData idioMeta = null;
        try
        {
            if (dba.wInit())
            {
                idioMeta = queryByHash(dba, idioHash);
            }
        }
        catch (SQLException exp)
        {
            LogUtil.exception(exp);
        }
        finally
        {
            dba.closeConnection();
        }
        return idioMeta;
    }

    /**
     * @param dba
     * @param idioHash
     * @return
     * @throws SQLException
     */
    public static IdioBaseData queryByHash(DBAccess dba, String idioHash) throws SQLException
    {
        return DA0008.selectIdioMetaInfo(dba, idioHash);
    }

    // ////////////////////////////////////////////////////////////////////////
    // 公共接口区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 个人数据删除
     */
    public boolean metaDelete(IdioUserData userMeta)
    {
        // 用户删除确认
        String arg1 = Extparse.getMesg(LangRes.IDIO_COMN_TEXT_IDIOMAIL);
        String arg2 = Extparse.getMesg(LangRes.TITLE_IDIOFORM);
        String errMsg = StringUtil.format(LangRes.MESG_DELT_0007, arg1, userMeta.getIdioMail(), arg2);
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
            DA0008.deleteIdioMeta(dba, userMeta);

            return true;
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            String mesg = StringUtil.format(LangRes.MESG_DELT_0006, LangRes.TITLE_IDIOFORM, LangRes.MESG_INIT_0010);
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
     * @param idioHash
     * @return
     */
    public boolean hashSelect(String idioHash)
    {
        return setBaseData(queryByHash(idioHash));
    }

    /**
     * @return
     */
    public boolean nameSelect(String idioMail)
    {
        DBAccess dba = new DBAccess();

        List<K2SV1S> idioList = null;
        try
        {
            if (!dba.wInit())
            {
                return false;
            }

            // 数据查询
            idioList = queryByName(dba, idioMail);

            if (idioList != null && idioList.size() == 1)
            {
                return setBaseData(queryByHash(dba, idioList.get(0).getK1()));
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
        if (idioList == null)
        {
            String mesg = StringUtil.format(LangRes.MESG_SELT_0004, LangRes.MESG_INIT_0010);
            MesgUtil.showMessageDialog(null, mesg);
            return false;
        }
        // 数据为空
        else if (idioList.size() == 0)
        {
            MesgUtil.showMessageDialog(null, Extparse.getMesg(LangRes.MESG_SELT_0003));
        }
        // 多个结果
        else
        {
            String mesg = Extparse.getMesg(LangRes.TITLE_IDIOFORM);
            WListForm.showDialog(null, mesg, idioList, this);
        }
        return true;
    }

    /**
     * 个人数据更新
     */
    public boolean metaUpdate(IdioUserData userMeta)
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
            DA0008.updateIdioMeta(dba, userMeta);
        }
        catch (SQLException exp)
        {
            LogUtil.exception(exp);
            String mesg = StringUtil.format(LangRes.MESG_UPDT_0005, LangRes.TITLE_IDIOFORM, LangRes.MESG_INIT_0010);
            MesgUtil.showMessageDialog(Extparse.getForm(), mesg);
            return false;
        }
        finally
        {
            // 数据提交
            dba.closeConnection();
        }

        // idioPath = null;

        return true;
    }

    /**
     * 
     */
    private void ica()
    {
        ib_IdioIcon = new WIconBox(me_MainSoft);
        ib_IdioIcon.wInit();
        lb_NickName = new javax.swing.JLabel();
        lb_IdioMail = new javax.swing.JLabel();
        tf_NickName = new javax.swing.JTextField();
        tf_IdioMail = new javax.swing.JTextField();
        bt_Refers = new javax.swing.JButton();
        lb_IdioSign = new javax.swing.JLabel();
        tf_IdioSign = new javax.swing.JTextField();
        lb_HomePage = new javax.swing.JLabel();
        tf_HomePage = new javax.swing.JTextField();
        bt_Browse = new javax.swing.JButton();
        lb_IdioDesp = new javax.swing.JLabel();
        javax.swing.JScrollPane sp_TextArea = new javax.swing.JScrollPane();
        ta_IdioDesp = new javax.swing.JTextArea();
        bt_Delete = new javax.swing.JButton();
        bt_Update = new javax.swing.JButton();
        bt_Create = new javax.swing.JButton();

        ib_IdioIcon.setToolTipText("\u516c\u53f8\u5fb5\u6807");

        lb_NickName.setText("\u56fd\u522b\u4fe1\u606f(A)");
        lb_NickName.setToolTipText("\u56fd\u522b\u4fe1\u606f");
        lb_NickName.setLabelFor(tf_NickName);

        lb_IdioMail.setText("\u672c\u8bed\u540d\u79f0(L)");
        lb_IdioMail.setToolTipText("\u672c\u8bed\u540d\u79f0");
        lb_IdioMail.setLabelFor(tf_IdioMail);

        tf_NickName.setToolTipText("\u56fd\u522b\u4fe1\u606f");

        tf_IdioMail.setToolTipText("\u672c\u8bed\u540d\u79f0");
        tf_IdioMail.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                tf_IdioMail_Handler(evt);
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

        lb_IdioSign.setText("\u82f1\u8bed\u540d\u79f0(E)");
        lb_IdioSign.setToolTipText("\u82f1\u8bed\u540d\u79f0");
        lb_IdioSign.setLabelFor(tf_IdioSign);

        tf_IdioSign.setEditable(false);
        tf_IdioSign.setToolTipText("\u82f1\u8bed\u540d\u79f0");

        lb_HomePage.setText("\u516c\u53f8\u9996\u9875(W)");
        lb_HomePage.setToolTipText("\u516c\u53f8\u9996\u9875");
        lb_HomePage.setLabelFor(tf_HomePage);

        tf_HomePage.setEditable(false);
        tf_HomePage.setToolTipText("\u516c\u53f8\u9996\u9875");

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

        lb_IdioDesp.setText("\u76f8\u5173\u8bf4\u660e(P)");
        lb_IdioDesp.setToolTipText("\u76f8\u5173\u8bf4\u660e");
        lb_IdioDesp.setLabelFor(ta_IdioDesp);

        ta_IdioDesp.setEditable(false);
        ta_IdioDesp.setLineWrap(true);
        ta_IdioDesp.setRows(4);
        ta_IdioDesp.setToolTipText("\u76f8\u5173\u8bf4\u660e");
        sp_TextArea.setViewportView(ta_IdioDesp);

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
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_IdioSign).addComponent(lb_HomePage).addComponent(lb_IdioDesp)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(tf_IdioSign,
                javax.swing.GroupLayout.DEFAULT_SIZE, 235, Short.MAX_VALUE).addGroup(
                javax.swing.GroupLayout.Alignment.TRAILING,
                layout.createSequentialGroup().addComponent(tf_HomePage, javax.swing.GroupLayout.DEFAULT_SIZE, 213,
                Short.MAX_VALUE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_Browse, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addComponent(sp_TextArea, javax.swing.GroupLayout.DEFAULT_SIZE, 235, Short.MAX_VALUE)).addContainerGap()).addGroup(
                javax.swing.GroupLayout.Alignment.TRAILING,
                layout.createSequentialGroup().addContainerGap(134, Short.MAX_VALUE).addComponent(bt_Create).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_Update).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_Delete).addGap(10,
                10, 10)).addGroup(
                layout.createSequentialGroup().addGap(10, 10, 10).addComponent(ib_IdioIcon,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_NickName).addComponent(lb_IdioMail)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addComponent(tf_IdioMail, javax.swing.GroupLayout.DEFAULT_SIZE,
                162, Short.MAX_VALUE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_Refers, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addGap(
                10, 10, 10)).addGroup(
                layout.createSequentialGroup().addComponent(tf_NickName, 0, 184, Short.MAX_VALUE).addContainerGap()))));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false).addGroup(
                layout.createSequentialGroup().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_NickName).addComponent(tf_NickName,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE,
                Short.MAX_VALUE).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_IdioMail).addComponent(bt_Refers, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(tf_IdioMail, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))).addComponent(ib_IdioIcon, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_IdioSign).addComponent(tf_IdioSign, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_HomePage).addComponent(bt_Browse, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(
                tf_HomePage, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_IdioDesp).addComponent(sp_TextArea, javax.swing.GroupLayout.PREFERRED_SIZE,
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
        // 昵称
        BeanUtil.setWText(lb_NickName, Extparse.getMesg(LangRes.IDIO_LABL_TEXT_NICKNAME));
        BeanUtil.setWTips(lb_NickName, Extparse.getMesg(LangRes.IDIO_LABL_TIPS_NICKNAME));

        BeanUtil.setWText(tf_NickName, Extparse.getMesg(LangRes.IDIO_FILD_TEXT_NICKNAME));
        BeanUtil.setWTips(tf_NickName, Extparse.getMesg(LangRes.IDIO_FILD_TIPS_NICKNAME));

        // 邮件
        BeanUtil.setWText(lb_IdioMail, Extparse.getMesg(LangRes.IDIO_LABL_TEXT_IDIOMAIL));
        BeanUtil.setWTips(lb_IdioMail, Extparse.getMesg(LangRes.IDIO_LABL_TIPS_IDIOMAIL));

        BeanUtil.setWText(tf_IdioMail, Extparse.getMesg(LangRes.IDIO_FILD_TEXT_IDIOMAIL));
        BeanUtil.setWTips(tf_IdioMail, Extparse.getMesg(LangRes.IDIO_FILD_TIPS_IDIOMAIL));

        // 个人首页
        BeanUtil.setWText(lb_HomePage, Extparse.getMesg(LangRes.IDIO_LABL_TEXT_HOMEPAGE));
        BeanUtil.setWTips(lb_HomePage, Extparse.getMesg(LangRes.IDIO_LABL_TIPS_HOMEPAGE));

        BeanUtil.setWText(tf_HomePage, Extparse.getMesg(LangRes.IDIO_FILD_TEXT_HOMEPAGE));
        BeanUtil.setWTips(tf_HomePage, Extparse.getMesg(LangRes.IDIO_FILD_TIPS_HOMEPAGE));

        // 签名
        BeanUtil.setWText(lb_IdioSign, Extparse.getMesg(LangRes.IDIO_LABL_TEXT_IDIOSIGN));
        BeanUtil.setWTips(lb_IdioSign, Extparse.getMesg(LangRes.IDIO_LABL_TIPS_IDIOSIGN));

        BeanUtil.setWText(tf_IdioSign, Extparse.getMesg(LangRes.IDIO_FILD_TEXT_IDIOSIGN));
        BeanUtil.setWTips(tf_IdioSign, Extparse.getMesg(LangRes.IDIO_FILD_TIPS_IDIOSIGN));

        // 相关说明
        BeanUtil.setWText(lb_IdioDesp, Extparse.getMesg(LangRes.IDIO_LABL_TEXT_IDIODESP));
        BeanUtil.setWTips(lb_IdioDesp, Extparse.getMesg(LangRes.IDIO_LABL_TIPS_IDIODESP));

        BeanUtil.setWText(ta_IdioDesp, Extparse.getMesg(LangRes.IDIO_AREA_TEXT_IDIODESP));
        BeanUtil.setWTips(ta_IdioDesp, Extparse.getMesg(LangRes.IDIO_AREA_TIPS_IDIODESP));

        // 新增按钮
        BeanUtil.setWText(bt_Create, Extparse.getMesg(LangRes.IDIO_BUTN_TEXT_CREATE));
        BeanUtil.setWTips(bt_Create, Extparse.getMesg(LangRes.IDIO_BUTN_TIPS_CREATE));

        // 更新按钮
        BeanUtil.setWText(bt_Update, Extparse.getMesg(LangRes.IDIO_BUTN_TEXT_UPDATE));
        BeanUtil.setWTips(bt_Update, Extparse.getMesg(LangRes.IDIO_BUTN_TIPS_UPDATE));

        // 删除按钮
        BeanUtil.setWText(bt_Delete, Extparse.getMesg(LangRes.IDIO_BUTN_TEXT_DELETE));
        BeanUtil.setWTips(bt_Delete, Extparse.getMesg(LangRes.IDIO_BUTN_TIPS_DELETE));

        // 参照
        BeanUtil.setWText(bt_Refers, Extparse.getMesg(LangRes.IDIO_BUTN_TEXT_IDIOVIEW));
        BeanUtil.setWTips(bt_Refers, Extparse.getMesg(LangRes.IDIO_BUTN_TIPS_IDIOVIEW));

        // 图标
        BeanUtil.setWTips(ib_IdioIcon, Extparse.getMesg(LangRes.IDIO_IMLB_TIPS_IDIOICON));
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
            me_MainSoft.getSoftForm().setTitle(Extparse.getMesg(LangRes.TITLE_IDIOFORM) + LangRes.TITLE_INSERT);
        }

        // 清除界面已有数据
        setDefault("");

        ib_IdioIcon.setIconHash(ConstUI.DEF_IDIOICON);
        me_MainSoft.getBaseData().setIdioIndx(ConstUI.DEF_IDIOHASH);

        // 焦点设置
        this.tf_IdioMail.requestFocus();

        // 状态更新标记设置为新增状态
        isDataUpdt = false;
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
            IdioUserData userMeta = new IdioUserData();
            userMeta.wInit();

            if (!getUserData(userMeta))
            {
                return;
            }

            if (metaDelete(userMeta))
            {
                // 清空界面显示数据
                setDefault("");

                // 焦点设置
                this.tf_IdioMail.requestFocus();

                // 状态标记设置为新增状态
                isDataUpdt = false;
            }
        }
        // 可交互状态时的处理：显示不可交互状态
        else
        {
            // 显示不可交互界面
            setEditable(false);
            me_MainSoft.getSoftForm().setTitle(Extparse.getMesg(LangRes.TITLE_IDIOFORM));
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
            me_MainSoft.getSoftForm().setTitle(Extparse.getMesg(LangRes.TITLE_IDIOFORM) + LangRes.TITLE_UPDATE);

            // 焦点设置
            this.tf_IdioMail.requestFocus();

            // 状态标记设置为更新状态
            isDataUpdt = true;
        }
        // 可交互状态时的处理：进行数据的新增更新
        else
        {
            LogUtil.log("数据更新：个人信息数据更新 － " + this.tf_IdioMail.getText());

            // 用户数据对象
            IdioUserData userMeta = new IdioUserData();
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

                // 焦点设置
                this.tf_IdioMail.requestFocus();

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
        String url = this.tf_HomePage.getText();
        if (CheckUtil.isValidate(url))
        {
            EnvUtil.browse(url);
        }
    }

    /**
     * 参照链接标签事件处理
     */
    private void bt_Refers_Handler(java.awt.event.ActionEvent evt)
    {
        nameSelect(this.tf_IdioMail.getText());
    }

    /**
     * 邮件查询事件处理
     */
    private void tf_IdioMail_Handler(java.awt.event.ActionEvent evt)
    {
        nameSelect(this.tf_IdioMail.getText());
    }

    /**
     * @param userMeta
     * @return
     */
    private boolean getUserData(IdioUserData userMeta)
    {
        return getUserData(userMeta, true);
    }

    /**
     * @param userMeta
     * @param keysOnly
     * @return
     */
    private boolean getUserData(IdioUserData userMeta, boolean keysOnly)
    {
        // 数据操作状态
        userMeta.setUpdate(isDataUpdt && isMetaExist);
        // 个人索引
        userMeta.setIdioIndx(me_MainSoft.getBaseData().getIdioIndx());

        // 邮件
        if (!userMeta.setIdioMail(this.tf_IdioMail.getText()))
        {
            MesgUtil.showMessageDialog(Extparse.getForm(), userMeta.getErrMsg());
            this.tf_IdioMail.requestFocus();
            return false;
        }

        if (keysOnly)
        {
            return true;
        }

        // 昵称
        if (!userMeta.setNickName(this.tf_NickName.getText()))
        {
            MesgUtil.showMessageDialog(Extparse.getForm(), userMeta.getErrMsg());
            this.tf_NickName.requestFocus();
            return false;
        }

        // 首页
        if (!userMeta.setHomePage(this.tf_HomePage.getText()))
        {
            MesgUtil.showMessageDialog(Extparse.getForm(), userMeta.getErrMsg());
            this.tf_HomePage.requestFocus();
            return false;
        }

        // 签名
        if (!userMeta.setIdioSign(this.tf_IdioSign.getText()))
        {
            MesgUtil.showMessageDialog(Extparse.getForm(), userMeta.getErrMsg());
            this.tf_IdioSign.requestFocus();
            return false;
        }

        // 保存外部图像
        ib_IdioIcon.saveExtImage();
        // 个性图标
        userMeta.setIdioLogo(ib_IdioIcon.getIconHash());
        ib_IdioIcon.setIconHash(ConstUI.DEF_IDIOICON);

        return true;
    }

    /**
     * 界面数据显示
     * 
     * @param baseMeta
     */
    private boolean setBaseData(IdioBaseData baseMeta)
    {
        // 昵称
        this.tf_NickName.setText(baseMeta.getNickName());

        // 邮件
        this.tf_IdioMail.setText(baseMeta.getIdioMail());

        // 个人首页
        this.tf_HomePage.setText(baseMeta.getHomePage());

        // 个性签名
        this.tf_IdioSign.setText(baseMeta.getIdioSign());

        // 相关说明
        this.ta_IdioDesp.setText(baseMeta.getIdioDesp());

        // 图标
        ib_IdioIcon.setIconHash(baseMeta.getIdioLogo());

        // 状态标记
        isDataUpdt = true;
        isMetaExist = baseMeta.isMetaExist();
        // 数据维持
        if (isMetaExist)
        {
            me_MainSoft.getBaseData().setIdioIndx(baseMeta.getIdioIndx());
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
        // 邮件
        this.tf_IdioMail.setText(value);
        // 昵称
        this.tf_NickName.setText(value);
        // 首页
        this.tf_HomePage.setText(value);
        // 签名
        this.tf_IdioSign.setText(value);
        // 软件图标
        this.ib_IdioIcon.setBackgroundImage(null);
    }

    /**
     * 设置构件的可交互性
     * 
     * @param editable 构件是否可交互：true可交互；false不可交互
     */
    public void setEditable(boolean editable)
    {
        isEditable = editable;

        // 昵称
        this.tf_NickName.setEditable(editable);
        // 个人首页
        this.tf_HomePage.setEditable(editable);
        // 签名
        this.tf_IdioSign.setEditable(editable);
        // 相关说明
        this.ta_IdioDesp.setEditable(editable);
        // 个性图标
        this.ib_IdioIcon.setUserEditable(editable);

        // 可交互
        if (editable)
        {
            // 更新按钮
            BeanUtil.setWText(bt_Update, Extparse.getMesg(LangRes.IDIO_BUTN_TEXT_INSERT));
            BeanUtil.setWTips(bt_Update, Extparse.getMesg(LangRes.IDIO_BUTN_TIPS_INSERT));
            // 删除按钮
            BeanUtil.setWText(bt_Delete, Extparse.getMesg(LangRes.IDIO_BUTN_TEXT_CANCEL));
            BeanUtil.setWTips(bt_Delete, Extparse.getMesg(LangRes.IDIO_BUTN_TIPS_CANCEL));
        }
        // 不可交互
        else
        {
            // 更新按钮
            BeanUtil.setWText(bt_Update, Extparse.getMesg(LangRes.IDIO_BUTN_TEXT_UPDATE));
            BeanUtil.setWTips(bt_Update, Extparse.getMesg(LangRes.IDIO_BUTN_TIPS_UPDATE));
            // 删除按钮
            BeanUtil.setWText(bt_Delete, Extparse.getMesg(LangRes.IDIO_BUTN_TEXT_DELETE));
            BeanUtil.setWTips(bt_Delete, Extparse.getMesg(LangRes.IDIO_BUTN_TIPS_DELETE));
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
    /** 参照标签 */
    private javax.swing.JButton bt_Refers;
    /** 相关说明 */
    private javax.swing.JTextArea ta_IdioDesp;
    /** 个人主页 */
    private javax.swing.JTextField tf_HomePage;
    /** 邮件 */
    private javax.swing.JTextField tf_IdioMail;
    /** 签名 */
    private javax.swing.JTextField tf_IdioSign;
    /** 昵称 */
    private javax.swing.JTextField tf_NickName;
    /** 个性图标 */
    private WIconBox ib_IdioIcon;
    private javax.swing.JLabel lb_HomePage;
    private javax.swing.JLabel lb_IdioDesp;
    private javax.swing.JLabel lb_IdioMail;
    private javax.swing.JLabel lb_IdioSign;
    private javax.swing.JLabel lb_NickName;
}
