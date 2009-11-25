/*
 * FileName:       DespPanel.java
 * CreateDate:     Jul 9, 2007 9:18:18 AM
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
import rmp.face.WBackCall;
import rmp.io.db.DBAccess;
import rmp.prp.aide.extparse.Extparse;
import rmp.prp.aide.extparse.d.DA0008;
import rmp.prp.aide.extparse.m.DespBaseData;
import rmp.prp.aide.extparse.m.DespUserData;
import rmp.util.BeanUtil;
import rmp.util.LogUtil;
import rmp.util.MesgUtil;
import rmp.util.StringUtil;
import cons.prp.aide.extparse.ConstUI;
import cons.prp.aide.extparse.DB0008;
import cons.prp.aide.extparse.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br>
 * 描述信息面板
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
 * 日期： Jul 9, 2007 9:18:18 AM
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class DespPanel extends javax.swing.JPanel implements WBackCall
{
    // ////////////////////////////////////////////////////////////////////////
    // 界面控制变量区域
    // ////////////////////////////////////////////////////////////////////////
    /**  */
    private static final long    serialVersionUID = -6222804127707071418L;
    /** 当前操作是否为数据更新操作 */
    private boolean              isDataUpdt;
    /** 列表数据模型 */
    private DefaultComboBoxModel cm_LangList;
    /** 当前选择语言 */
    private K1SV2S               kv_LangItem;
    /** 父应用引用 */
    private Extparse             me_MainSoft;

    /**
     * @param soft
     */
    public DespPanel(Extparse soft)
    {
        me_MainSoft = soft;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    public boolean wInit()
    {
        isDataUpdt = true;

        // 界面初始化
        ica();

        // 界面语言显示
        ita();

        cm_LangList = new DefaultComboBoxModel();
        cb_DespLang.setModel(cm_LangList);

        DBAccess dba = new DBAccess();
        try
        {
            if (!dba.wInit())
            {
                return false;
            }

            initLangList(dba);
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

        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WBackCall#wAction(java.awt.Event, java.lang.Object)
     */
    public void wAction(EventObject event, Object object, String property)
    {
    }

    /**
     * 按钮描述索引及语言类别查询指定后缀的描述信息
     * 
     * @param despHash 描述索引
     * @param langHash 语言索引
     * @return
     */
    public static DespBaseData queryByHash(String despHash, String langHash)
    {
        DBAccess dba = new DBAccess();

        try
        {
            DespBaseData baseMeta = null;
            if (dba.wInit())
            {
                baseMeta = queryByHash(dba, despHash, langHash);
            }
            return baseMeta;
        }
        catch(SQLException exp)
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
     * 按钮描述索引及语言类别查询指定后缀的描述信息
     * 
     * @param dba 数据库操作对象
     * @param despHash 描述索引
     * @param langHash 语言索引
     * @return
     * @throws SQLException
     */
    public static DespBaseData queryByHash(DBAccess dba, String despHash, String langHash) throws SQLException
    {
        return DA0008.selectDespMetaInfo(dba, despHash, langHash);
    }

    // ////////////////////////////////////////////////////////////////////////
    // 公共接口区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 数据删除
     * 
     * @return
     */
    public boolean metaDelete(DespUserData userMeta)
    {
        // 用户删除确认
        if (MesgUtil.showConfirmDialog(Extparse.getForm(), Extparse.getMesg(LangRes.DESP_MESG_DELT_0001)) != 0)
        {
            return false;
        }

        // 数据库操作对象
        DBAccess dba = new DBAccess();

        try
        {
            if (!dba.wInit())
            {
                return false;
            }

            // 指定语言的描述信息删除
            DA0008.deleteDespMeta(dba, userMeta);

            return true;
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
    }

    /**
     * 描述信息数据查询
     * 
     * @param langHash
     * @return
     */
    public boolean metaSelect(K1SV2S langItem)
    {
        kv_LangItem = langItem;
        this.cm_LangList.setSelectedItem(kv_LangItem);

        // 描述数据查询
        DespBaseData baseMeta = queryByHash(me_MainSoft.getBaseData().getDespIndx(), langItem.getK());
        if (baseMeta.isMetaExist())
        {
            // 数据显示
            setBaseData(baseMeta);

            // 数据存在的情况下，操作状态为数据更新
            isDataUpdt = true;
        }
        else
        {
            // 恢复默认显示
            setDefault("");

            // 数据不存在的情况下，操作状态为数据新增
            isDataUpdt = false;
        }
        return true;
    }

    /**
     * 描述信息数据更新
     * 
     * @param userMeta
     * @return
     */
    public boolean metaUpdate(DespUserData userMeta)
    {
        // 实例化数据库操作对象
        DBAccess dba = new DBAccess();

        try
        {
            // 连接数据库
            if (!dba.wInit())
            {
                return false;
            }

            // 执行数据更新
            DA0008.updateDespMeta(dba, userMeta);

            return true;
        }
        catch(SQLException exp)
        {
            LogUtil.exception(exp);
            String mesg = StringUtil.format(LangRes.MESG_UPDT_0005, LangRes.TITLE_DESPFORM, LangRes.MESG_INIT_0010);
            MesgUtil.showMessageDialog(Extparse.getForm(), mesg);
            return false;
        }
        finally
        {
            dba.closeConnection();
        }
    }

    /**
     * 
     */
    private void ica()
    {
        lb_DespLang = new javax.swing.JLabel();
        cb_DespLang = new javax.swing.JComboBox();
        lb_ExtsDesp = new javax.swing.JLabel();
        javax.swing.JScrollPane sp_ExtsDesp = new javax.swing.JScrollPane();
        ta_ExtsDesp = new javax.swing.JTextArea();
        bt_Delete = new javax.swing.JButton();
        bt_Update = new javax.swing.JButton();

        lb_DespLang.setDisplayedMnemonic('L');
        lb_DespLang.setLabelFor(cb_DespLang);
        lb_DespLang.setText("\u8bed\u8a00\u5217\u8868(L)");

        cb_DespLang.setToolTipText("\u8bed\u8a00\u5217\u8868");
        cb_DespLang.addItemListener(new java.awt.event.ItemListener()
        {
            public void itemStateChanged(java.awt.event.ItemEvent evt)
            {
                cb_DespLang_Handler(evt);
            }
        });

        lb_ExtsDesp.setDisplayedMnemonic('P');
        lb_ExtsDesp.setLabelFor(ta_ExtsDesp);
        lb_ExtsDesp.setText("\u540e\u7f00\u8bf4\u660e(P)");

        ta_ExtsDesp.setColumns(30);
        ta_ExtsDesp.setLineWrap(true);
        ta_ExtsDesp.setRows(5);
        ta_ExtsDesp.setToolTipText("\u540e\u7f00\u63cf\u8ff0");
        sp_ExtsDesp.setViewportView(ta_ExtsDesp);

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

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_ExtsDesp)
                    .addComponent(lb_DespLang)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(
                    layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false).addComponent(
                        cb_DespLang, 0, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                        .addComponent(sp_ExtsDesp)).addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE,
                    Short.MAX_VALUE)).addGroup(
            javax.swing.GroupLayout.Alignment.TRAILING,
            layout.createSequentialGroup().addContainerGap(168, Short.MAX_VALUE).addComponent(bt_Update)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_Delete)
                .addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_DespLang)
                    .addComponent(cb_DespLang, javax.swing.GroupLayout.PREFERRED_SIZE,
                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_ExtsDesp)
                    .addComponent(sp_ExtsDesp, javax.swing.GroupLayout.PREFERRED_SIZE,
                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE,
                Short.MAX_VALUE).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(bt_Delete)
                    .addComponent(bt_Update)).addContainerGap()));
    }

    /**
     * @param isHash
     */
    private void ita()
    {
        // 描述语言
        BeanUtil.setWText(lb_DespLang, Extparse.getMesg(LangRes.DESP_LABL_TEXT_DESPLANG));
        BeanUtil.setWTips(lb_DespLang, Extparse.getMesg(LangRes.DESP_LABL_TIPS_DESPLANG));

        BeanUtil.setWTips(cb_DespLang, Extparse.getMesg(LangRes.DESP_COMB_TIPS_DESPLANG));

        // 后缀描述
        BeanUtil.setWText(lb_ExtsDesp, Extparse.getMesg(LangRes.DESP_LABL_TEXT_EXTSDESP));
        BeanUtil.setWTips(lb_ExtsDesp, Extparse.getMesg(LangRes.DESP_LABL_TIPS_EXTSDESP));

        BeanUtil.setWText(ta_ExtsDesp, Extparse.getMesg(LangRes.DESP_AREA_TEXT_EXTSDESP));
        BeanUtil.setWTips(ta_ExtsDesp, Extparse.getMesg(LangRes.DESP_AREA_TIPS_EXTSDESP));

        // 更新按钮
        BeanUtil.setWText(bt_Update, Extparse.getMesg(LangRes.DESP_BUTN_TEXT_UPDATE));
        BeanUtil.setWTips(bt_Update, Extparse.getMesg(LangRes.DESP_BUTN_TIPS_UPDATE));

        // 删除按钮
        BeanUtil.setWText(bt_Delete, Extparse.getMesg(LangRes.DESP_BUTN_TEXT_DELETE));
        BeanUtil.setWTips(bt_Delete, Extparse.getMesg(LangRes.DESP_BUTN_TIPS_DELETE));
    }

    /**
     * @param dba
     * @throws SQLException
     */
    private void initLangList(DBAccess dba) throws SQLException
    {
        cm_LangList.removeAllElements();

        List<K1SV2S> langList = DA0008.initLanguageList(dba, DB0008.DBCD_LANG_REST);
        kv_LangItem = langList.get(0);
        for (int i = 0, j = langList.size(); i < j; i += 1)
        {
            cm_LangList.addElement(langList.get(i));
        }
    }

    // ////////////////////////////////////////////////////////////////////////
    // 事件处理区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 新增按钮事件处理
     */
    private void cb_DespLang_Handler(java.awt.event.ItemEvent evt)
    {
        // 重复事件控制
        K1SV2S kvItem = (K1SV2S)this.cb_DespLang.getSelectedItem();
        if (kvItem == null || kvItem.equals(kv_LangItem))
        {
            return;
        }
        kv_LangItem = kvItem;

        // 描述数据查询
        DespBaseData baseMeta = queryByHash(me_MainSoft.getBaseData().getDespIndx(), kvItem.getK());
        if (baseMeta.isMetaExist())
        {
            // 数据显示
            setBaseData(baseMeta);

            // 数据存在的情况下，操作状态为数据更新
            isDataUpdt = true;
        }
        else
        {
            // 恢复默认显示
            setDefault("");

            // 数据不存在的情况下，操作状态为数据新增
            isDataUpdt = false;
        }
    }

    /**
     * 删除按钮事件处理
     */
    private void bt_Delete_Handler(java.awt.event.ActionEvent evt)
    {
        if (ConstUI.DEF_DESPHASH.equals(me_MainSoft.getBaseData().getDespIndx()))
        {
            return;
        }

        // 用户数据对象
        DespUserData userMeta = new DespUserData();
        userMeta.wInit();

        // 用户输入关键信息读取
        if (!getUserData(userMeta))
        {
            return;
        }

        // 描述数据删除
        if (metaDelete(userMeta))
        {
            // 清除界面显示数据
            setDefault("");

            // 描述信息删除后，需要设置isDataUpdt为新增状态：用户需要可以新增相关的描述信息。
            isDataUpdt = false;
        }
    }

    /**
     * 更新按钮事件处理
     */
    private void bt_Update_Handler(java.awt.event.ActionEvent evt)
    {
        if (ConstUI.DEF_DESPHASH.equals(me_MainSoft.getBaseData().getDespIndx()))
        {
            return;
        }

        // 用户数据对象
        DespUserData userMeta = new DespUserData();
        userMeta.wInit();

        // 用户输入全部信息读取
        if (!getUserData(userMeta, false))
        {
            return;
        }

        // 描述数据更新
        if (metaUpdate(userMeta))
        {
            // 清除界面显示数据
            setDefault("");

            // 描述信息更新后，不需要设置isDataUpdt为新增状态：用户可以继续更新当前描述信息。
        }
    }

    // ////////////////////////////////////////////////////////////////////////
    // 公共接口区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 用户输入信息读取（仅关键信息部分）
     * 
     * @param userMeta
     * @return
     */
    private boolean getUserData(DespUserData userMeta)
    {
        return getUserData(userMeta, true);
    }

    /**
     * 用户输入信息读取
     * 
     * @param userMeta
     * @param keysOnly
     * @return
     */
    private boolean getUserData(DespUserData userMeta, boolean keysOnly)
    {
        // 操作状态
        userMeta.setUpdate(isDataUpdt);

        // 描述索引
        if (!userMeta.setDespIndx(me_MainSoft.getBaseData().getDespIndx()))
        {
            MesgUtil.showMessageDialog(Extparse.getForm(), userMeta.getErrMsg());
            return false;
        }

        // 描述语言
        K1SV2S kvItem = (K1SV2S)this.cb_DespLang.getSelectedItem();
        if (kvItem == null)
        {
            MesgUtil.showMessageDialog(Extparse.getForm(), Extparse.getMesg(LangRes.DESP_MESG_CHCK_0001));
            return false;
        }
        if (!userMeta.setLangIndx(kvItem.getK()))
        {
            MesgUtil.showMessageDialog(Extparse.getForm(), userMeta.getErrMsg());
            this.cb_DespLang.requestFocus();
            return false;
        }

        // 仅读取关键信息部分
        if (keysOnly)
        {
            return true;
        }

        // 描述信息
        if (!userMeta.setExtsDesp(this.ta_ExtsDesp.getText()))
        {
            MesgUtil.showMessageDialog(Extparse.getForm(), userMeta.getErrMsg());
            this.ta_ExtsDesp.requestFocus();
            return false;
        }

        // 附注信息

        return true;
    }

    /**
     * 后缀数据显示
     * 
     * @param baseMeta
     * @return
     */
    private boolean setBaseData(DespBaseData baseMeta)
    {
        this.ta_ExtsDesp.setText(baseMeta.getExtsDesp());

        return true;
    }

    /**
     * 设置初始状态
     */
    public void setDefault(String value)
    {
        this.ta_ExtsDesp.setText(value);
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面组件变量区域
    // ////////////////////////////////////////////////////////////////////////
    /** 取消按钮 */
    private javax.swing.JButton   bt_Delete;
    /** 更新按钮 */
    private javax.swing.JButton   bt_Update;
    /** 描述语言 */
    private javax.swing.JComboBox cb_DespLang;
    /** 后缀描述 */
    private javax.swing.JTextArea ta_ExtsDesp;

    private javax.swing.JLabel    lb_DespLang;
    private javax.swing.JLabel    lb_ExtsDesp;
}
