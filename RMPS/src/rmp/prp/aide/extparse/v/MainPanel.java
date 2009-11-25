/*
 * FileName:       MainPanel.java
 * CreateDate:     Jul 9, 2007 9:18:34 AM
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.extparse.v;

import java.io.File;
import java.sql.SQLException;
import java.util.EventObject;
import java.util.List;

import javax.swing.DefaultComboBoxModel;
import javax.swing.DefaultListModel;

import rmp.bean.K1SV2S;
import rmp.bean.K2SV1S;
import rmp.face.WBackCall;
import rmp.io.db.DBAccess;
import rmp.prp.aide.DC0008;
import rmp.prp.aide.extparse.Extparse;
import rmp.prp.aide.extparse.d.DA0008;
import rmp.prp.aide.extparse.m.AsocBaseData;
import rmp.prp.aide.extparse.m.BaseData;
import rmp.prp.aide.extparse.m.CorpBaseData;
import rmp.prp.aide.extparse.m.DespBaseData;
import rmp.prp.aide.extparse.m.ExtsBaseData;
import rmp.prp.aide.extparse.m.FileBaseData;
import rmp.prp.aide.extparse.m.IdioBaseData;
import rmp.prp.aide.extparse.m.SoftBaseData;
import rmp.prp.aide.extparse.m.UserData;
import rmp.util.BeanUtil;
import rmp.util.CheckUtil;
import rmp.util.FileUtil;
import rmp.util.LogUtil;
import rmp.util.MesgUtil;
import rmp.util.RmpsUtil;
import rmp.util.StringUtil;
import cons.CfgCons;
import cons.id.PrpCons;
import cons.prp.aide.extparse.ConstUI;
import cons.prp.aide.extparse.DB0008;
import cons.prp.aide.extparse.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br>
 * 后缀解析数据查询界面
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
 * 日期： Jul 9, 2007 9:18:34 AM
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class MainPanel extends javax.swing.JPanel implements WBackCall
{
    // ////////////////////////////////////////////////////////////////////////
    // 界面控制变量区域
    // ////////////////////////////////////////////////////////////////////////
    /**  */
    private static final long    serialVersionUID = -8570728044416692662L;
    /** 用户查询对象 */
    private BaseData             bd_BaseMeta;
    /** 语言选择对象 */
    private K1SV2S               kv_LangMeta;
    /** 备选软件列表数据模型 */
    private DefaultListModel     lm_AsocSoft;
    /** MIME类型列表数据模型 */
    private DefaultListModel     lm_MimeType;
    /** 语言下拉列表数据模型 */
    private DefaultComboBoxModel cm_LangList;
    /** 软件下拉列表数据模型 */
    private DefaultComboBoxModel cm_SoftList;
    /** 父应用引用 */
    private Extparse             me_MainSoft;

    /**
     * @param soft
     */
    public MainPanel(Extparse soft)
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
        // 界面初始化
        ica();

        // 界面语言显示
        ita();

        // 数据模型设置
        lm_AsocSoft = new DefaultListModel();
        wp_DespPanl.ls_AsocSoft.setModel(lm_AsocSoft);

        lm_MimeType = new DefaultListModel();
        wp_DespPanl.ls_MimeType.setModel(lm_MimeType);

        cm_LangList = new DefaultComboBoxModel();
        wp_DespPanl.cb_LangList.setModel(cm_LangList);

        cm_SoftList = new DefaultComboBoxModel();
        wp_UserPanl.cb_SoftList.setModel(cm_SoftList);

        wp_UserPanl.tf_ExtsName.addActionListener(new java.awt.event.ActionListener()
        {
            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                tf_ExtsName_Handler(evt);
            }
        });
        wp_UserPanl.cb_SoftList.addItemListener(new java.awt.event.ItemListener()
        {
            @ Override
            public void itemStateChanged(java.awt.event.ItemEvent evt)
            {
                cb_SoftList_Handler(evt);
            }
        });
        wp_UserPanl.bt_ExtsName.addActionListener(new java.awt.event.ActionListener()
        {
            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ExtsName_Handler(evt);
            }
        });
        bt_MainMenu.addActionListener(new java.awt.event.ActionListener()
        {
            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_MainMenu_Handler(evt);
            }
        });
        bt_FileView.addActionListener(new java.awt.event.ActionListener()
        {
            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_FileView_Handler(evt);
            }
        });
        wp_DespPanl.cb_LangList.addItemListener(new java.awt.event.ItemListener()
        {
            @ Override
            public void itemStateChanged(java.awt.event.ItemEvent evt)
            {
                cb_LangList_Handler(evt);
            }
        });
        wp_DespPanl.ls_AsocSoft.addMouseListener(new java.awt.event.MouseAdapter()
        {
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                ls_AsocSoft_Handler(evt);
            }
        });
        wp_DespPanl.ls_MimeType.addMouseListener(new java.awt.event.MouseAdapter()
        {
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                ls_MimeType_Handler(evt);
            }
        });
        wp_DespPanl.ta_ExtsDesp.addMouseListener(new java.awt.event.MouseAdapter()
        {
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                ta_ExtsDesp_Handler(evt);
            }
        });

        // 语言列表初始化
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
        }
        finally
        {
            dba.closeConnection();
        }

        // kv_LangMeta = RmpsUtil.getUserInfo().getLangName();
        cm_LangList.setSelectedItem(kv_LangMeta);

        // 焦点设置
        wp_UserPanl.tf_ExtsName.requestFocusInWindow();
        wp_UserPanl.tf_ExtsName.requestFocus();

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
     * @param extsName
     * @return
     */
    public static List<ExtsBaseData> query(String extsName)
    {
        DBAccess dba = new DBAccess();

        try
        {
            if (!dba.wInit())
            {
                return null;
            }

            return query(dba, extsName);
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
     * @param dba
     * @param extsName
     * @return
     * @throws SQLException
     */
    public static List<ExtsBaseData> query(DBAccess dba, String extsName) throws SQLException
    {
        return DA0008.selectExtsMeta(dba, extsName);
    }

    /**
     * @param extsName
     * @param softHash
     * @return
     */
    public static ExtsBaseData query(BaseData baseMeta)
    {
        DBAccess dba = new DBAccess();

        try
        {
            if (!dba.wInit())
            {
                return null;
            }

            return query(dba, baseMeta);
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
     * @param dba
     * @param extsName
     * @param softHash
     * @return
     * @throws SQLException
     */
    public static ExtsBaseData query(DBAccess dba, BaseData baseMeta) throws SQLException
    {
        return DA0008.selectExtsMeta(dba, baseMeta);
    }

    /**
     * 获得用户输入数据信息，存在错误的情况下，返回值为NULL。
     * 
     * @param softInc 是否包含软件的相关信息：true包含。
     * @return
     */
    public UserData getUserData(boolean softInc)
    {
        UserData userMeta = new UserData();
        userMeta.wInit();

        // 后缀名称
        if (!userMeta.setExtsName(wp_UserPanl.tf_ExtsName.getText()))
        {
            MesgUtil.showMessageDialog(Extparse.getForm(), userMeta.getErrMsg());
            return null;
        }
        wp_UserPanl.tf_ExtsName.setText(userMeta.getExtsName());

        // 不包含软件信息的情况
        if (!softInc)
        {
            return userMeta;
        }

        // 用户选择为空
        K2SV1S kvItem = (K2SV1S)wp_UserPanl.cb_SoftList.getSelectedItem();
        if (kvItem == null)
        {
            MesgUtil.showMessageDialog(Extparse.getForm(), Extparse.getMesg(LangRes.MAIN_MESG_CHCK_0002));
            return null;
        }

        // 软件索引
        if (!userMeta.setSoftHash(kvItem.getK1()))
        {
            MesgUtil.showMessageDialog(Extparse.getForm(), userMeta.getErrMsg());
            return null;
        }
        return userMeta;
    }

    /**
     * 后缀数据信息查询
     * 
     * @param extsName 形如“.abc”格式的后缀名称
     * @return
     */
    public boolean metaSelect(String extsName)
    {
        LogUtil.log("数据查询：后缀数据查询 － " + extsName);

        // 数据库操作对象
        DBAccess dba = new DBAccess();

        List<BaseData> metaList;
        try
        {
            // 建立连接
            if (!dba.wInit())
            {
                return false;
            }

            // 后缀数据查询
            metaList = DA0008.selectBaseMeta(dba, extsName);

            if (metaList != null && metaList.size() > 0)
            {
                // 状态栏结果显示
                String arg1 = Extparse.getMesg(LangRes.MAIN_LABL_TEXT_NOTEINFO);
                String arg2 = Integer.toString(metaList.size());
                String note = StringUtil.format(LangRes.NOTE_STAT_0002, arg1, arg2);

                // 软件列表添加软件对象
                bd_BaseMeta = metaList.get(0);
                this.cm_SoftList.addElement(new K2SV1S(bd_BaseMeta.getSoftIndx(), "", bd_BaseMeta.getSoftName()));

                // 首个结果数据显示
                setBaseData(dba, bd_BaseMeta);

                // 其它软件数据读取
                BaseData tempData;
                for (int i = 1, j = metaList.size(); i < j; i += 1)
                {
                    tempData = metaList.get(i);
                    K2SV1S kv = new K2SV1S(tempData.getSoftIndx(), "", tempData.getSoftName());
                    this.cm_SoftList.addElement(kv);
                }
                return true;
            }
        }
        catch(SQLException exp)
        {
            LogUtil.exception(exp);
            String mesg = StringUtil.format(LangRes.MESG_SELT_0007, LangRes.TITLE_EXTSFORM, LangRes.MESG_INIT_0010);
            MesgUtil.showMessageDialog(Extparse.getForm(), mesg);
            return false;
        }
        finally
        {
            dba.closeConnection();
        }

        // 查询结果为空时的处理
        if (metaList == null)
        {
        }
        // 数据不存在时，提示用户添加数据
        else if (metaList.size() == 0)
        {
            String arg1 = Extparse.getMesg(LangRes.MAIN_COMN_TEXT_EXTSNAME);
            String arg2 = Extparse.getMesg(LangRes.TITLE_EXTSFORM);
            String mesg = StringUtil.format(LangRes.MESG_SELT_0008, arg1, extsName, arg2);
            if (0 == MesgUtil.showConfirmDialog(Extparse.getForm(), mesg))
            {
                // 显示数据新增面板
                LogUtil.log("数据不存在的情况下，显示数据新增界面！");
                me_MainSoft.showStepForm();
            }

            // 状态栏结果显示
            String note = StringUtil.format(LangRes.NOTE_STAT_0003, LangRes.MAIN_LABL_TEXT_NOTEINFO);
        }
        return true;
    }

    /**
     * @param extsHash 形如“.abc”格式的后缀名称
     * @param softHash
     */
    public boolean metaSelect(BaseData baseMeta)
    {
        DBAccess dba = new DBAccess();

        try
        {
            if (!dba.wInit())
            {
                return false;
            }

            return setBaseData(dba, baseMeta);
        }
        catch(SQLException exp)
        {
            LogUtil.exception(exp);
            String mesg = StringUtil.format(LangRes.MESG_SELT_0007, LangRes.TITLE_EXTSFORM, LangRes.MESG_INIT_0010);
            MesgUtil.showMessageDialog(Extparse.getForm(), mesg);
            return false;
        }
        finally
        {
            dba.closeConnection();
        }
    }

    /**
     * @param userData
     * @return
     */
    public boolean metaUpdate(UserData userData)
    {
        return true;
    }

    /**
     * 指定后缀数据信息删除
     * 
     * @param extsName 形如“.abc”格式的后缀名称
     * @param softHash
     * @return
     */
    public boolean metaDelete(String extsName, String softHash)
    {
        LogUtil.log("数据查询：后缀数据删除 － " + extsName + "、" + softHash);

        String arg1 = Extparse.getMesg(LangRes.MAIN_COMN_TEXT_EXTSNAME);
        String mesg = StringUtil.format(LangRes.MESG_DELT_0007, arg1, extsName, "");
        if (MesgUtil.showConfirmDialog(Extparse.getForm(), mesg) != 0)
        {
            return true;
        }

        // 数据库操作对象
        DBAccess dba = new DBAccess();

        try
        {
            // 建立连接
            if (!dba.wInit())
            {
                return false;
            }

            DA0008.deleteMainMeta(dba, extsName, softHash);

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
     * @return the baseMeta
     */
    public BaseData getBaseMeta()
    {
        return bd_BaseMeta;
    }

    /**
     * @param baseMeta the baseMeta to set
     */
    public void setBaseMeta(BaseData baseMeta)
    {
        this.bd_BaseMeta = baseMeta;
    }

    /**
     * 
     */
    private void ica()
    {
        wp_UserPanl = new WUserPanel();
        wp_UserPanl.wInit();
        wp_PropPanl = new WPropPanel(me_MainSoft);
        wp_PropPanl.wInit();
        wp_DespPanl = new WDespPanel();
        wp_DespPanl.wInit();
        rl_NoteInfo = new rmp.comn.rmps.C4010000.C4010000();
        rl_NoteInfo.wInit();
        rl_NoteInfo.wShowView(Extparse.VIEW_NORM);

        bt_MainMenu = new javax.swing.JButton();
        bt_FileView = new javax.swing.JButton();

        wp_PropPanl.setBorder(new javax.swing.border.LineBorder(new java.awt.Color(204, 204, 204), 1, true));

        wp_DespPanl.setBorder(new javax.swing.border.LineBorder(new java.awt.Color(204, 204, 204), 1, true));

        bt_MainMenu.setMnemonic('A');
        bt_MainMenu.setText("\u7cfb\u7edf(A)");
        bt_MainMenu.setToolTipText("\u7cfb\u7edf\u9009\u5355");
        bt_MainMenu.setMargin(new java.awt.Insets(1, 7, 1, 7));

        bt_FileView.setMnemonic('V');
        bt_FileView.setText("\u67e5\u770b(V)");
        bt_FileView.setToolTipText("\u67e5\u770b\u7cfb\u7edf\u6587\u4ef6\u7684\u540e\u7f00\u4fe1\u606f");
        bt_FileView.setMargin(new java.awt.Insets(1, 7, 1, 7));

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false).addGroup(
                    layout.createSequentialGroup().addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(wp_UserPanl,
                            javax.swing.GroupLayout.DEFAULT_SIZE, 270, Short.MAX_VALUE).addComponent(wp_PropPanl,
                            javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.DEFAULT_SIZE,
                            javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addComponent(wp_DespPanl,
                        javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                        javax.swing.GroupLayout.PREFERRED_SIZE)).addGroup(
                    layout.createSequentialGroup().addComponent(bt_MainMenu).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addComponent(rl_NoteInfo.getAd(),
                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addComponent(bt_FileView))).addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE,
                Short.MAX_VALUE)));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                    layout.createSequentialGroup().addComponent(wp_UserPanl, javax.swing.GroupLayout.PREFERRED_SIZE,
                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(wp_PropPanl,
                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
                    .addComponent(wp_DespPanl, javax.swing.GroupLayout.DEFAULT_SIZE, 304, Short.MAX_VALUE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                    layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(bt_MainMenu)
                        .addComponent(bt_FileView).addComponent(rl_NoteInfo.getAd())).addContainerGap()));
    }

    /**
     * @param isHash
     */
    private void ita()
    {
        // 系统菜单
        BeanUtil.setWText(bt_MainMenu, Extparse.getMesg(LangRes.MAIN_BUTN_TEXT_MAINMENU));
        BeanUtil.setWTips(bt_MainMenu, Extparse.getMesg(LangRes.MAIN_BUTN_TIPS_MAINMENU));

        // 查看按钮
        BeanUtil.setWText(bt_FileView, Extparse.getMesg(LangRes.MAIN_BUTN_TEXT_FILEVIEW));
        BeanUtil.setWTips(bt_FileView, Extparse.getMesg(LangRes.MAIN_BUTN_TIPS_FILEVIEW));

        // 公益广告
        // BeanUtil.setWText(rl_NoteInfo,
        // Extparse.getMesg(LangRes.MAIN_ROLL_TEXT_PUBLICAD));
        // BeanUtil.setWTips(rl_NoteInfo,
        // Extparse.getMesg(LangRes.MAIN_ROLL_TIPS_PUBLICAD));
    }

    /**
     * 语言资源列表初始化
     * 
     * @param dba
     * @throws SQLException
     */
    private void initLangList(DBAccess dba) throws SQLException
    {
        cm_LangList.removeAllElements();

        List<K1SV2S> langList = DA0008.initLanguageList(dba, DB0008.DBCD_LANG_REST);
        kv_LangMeta = langList.get(0);
        for (int i = 0, j = langList.size(); i < j; i += 1)
        {
            cm_LangList.addElement(langList.get(i));
        }
    }

    // ////////////////////////////////////////////////////////////////////////
    // 事件处理区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 查询按钮事件处理
     */
    private void bt_ExtsName_Handler(java.awt.event.ActionEvent evt)
    {
        // 恢复初始状态
        setDefault("");

        // 用户输入数据合法性检测
        UserData userMeta = new UserData();
        userMeta.wInit();

        // 数据检测
        if (!userMeta.setExtsName(wp_UserPanl.getExtsName()))
        {
            MesgUtil.showMessageDialog(Extparse.getForm(), userMeta.getErrMsg());
            wp_UserPanl.tf_ExtsName.requestFocus();
            return;
        }
        wp_UserPanl.tf_ExtsName.setText(userMeta.getExtsName());

        // 数据查询
        metaSelect(userMeta.getExtsName());
    }

    /**
     * 查看按钮事件处理
     */
    private void bt_FileView_Handler(java.awt.event.ActionEvent ent)
    {
        LogUtil.log("文件操作：文件后缀信息查看……");

        File viewFile = FileUtil.showSingleFileOpen(this, false, null);
        // 文件合法性判断
        if (viewFile == null || !viewFile.exists() || !viewFile.isFile())
        {
            return;
        }

        // 文件后缀信息存在检测
        String extsName = FileUtil.getFileExt(viewFile);
        if (!CheckUtil.isValidate(extsName))
        {
            String mesg = StringUtil.format(LangRes.MESG_OTHR_0003, viewFile.getPath());
            MesgUtil.showMessageDialog(Extparse.getForm(), mesg);
            return;
        }

        // 设置文件后缀信息
        wp_UserPanl.tf_ExtsName.setText(extsName);
        metaSelect(wp_UserPanl.getExtsName());
    }

    /**
     * 菜单按钮事件处理
     * 
     * @param evt
     */
    private void bt_MainMenu_Handler(java.awt.event.ActionEvent evt)
    {
        me_MainSoft.showMainMenu(bt_MainMenu);
    }

    /**
     * 语言下拉列表事件处理
     */
    private void cb_LangList_Handler(java.awt.event.ItemEvent evt)
    {
        K1SV2S kvItem = (K1SV2S)wp_DespPanl.cb_LangList.getSelectedItem();
        if (kvItem.equals(kv_LangMeta))
        {
            return;
        }
        kv_LangMeta = kvItem;

        // 默认数据检测
        if (ConstUI.DEF_DESPHASH == me_MainSoft.getBaseData().getDespIndx())
        {
            return;
        }

        // 数据库操作对象实例化
        DBAccess dba = new DBAccess();
        DespBaseData baseMeta = null;

        try
        {
            // 连接数据库
            if (!dba.wInit())
            {
                return;
            }

            // 数据查询
            baseMeta = DA0008.selectDespMetaInfo(dba, me_MainSoft.getBaseData().getDespIndx(), kv_LangMeta.getK());
        }
        catch(SQLException exp)
        {
            LogUtil.exception(exp);
            String mesg = StringUtil.format(LangRes.MESG_SELT_0007, LangRes.TITLE_DESPFORM, LangRes.MESG_INIT_0010);
            MesgUtil.showMessageDialog(Extparse.getForm(), mesg);
            return;
        }
        finally
        {
            dba.closeConnection();
        }

        // 描述信息显示
        wp_DespPanl.ta_ExtsDesp.setText(baseMeta.isMetaExist() ? baseMeta.getExtsDesp() : "");
    }

    /**
     * 软件列表选择对象改变事件处理
     */
    private void cb_SoftList_Handler(java.awt.event.ItemEvent evt)
    {
        // 事件源判断
        Object obj = wp_UserPanl.cb_SoftList.getSelectedItem();
        if (obj == null)
        {
            return;
        }

        // 查询条件相同时的处理
        K2SV1S kvItem = (K2SV1S)obj;
        if (bd_BaseMeta.getSoftIndx().equals(kvItem.getK1()))
        {
            return;
        }

        // 查询条件读取
        bd_BaseMeta.setSoftIndx(kvItem.getK1());
        wp_UserPanl.tf_ExtsName.setText(bd_BaseMeta.getExtsName());

        // 详细数据查询
        metaSelect(bd_BaseMeta);
    }

    /**
     * @param evt
     */
    private void ls_AsocSoft_Handler(java.awt.event.MouseEvent evt)
    {
        if (evt.getClickCount() > 1)
        {
            me_MainSoft.showAsocForm();
            me_MainSoft.getAsocPanel().hashSelect(me_MainSoft.getBaseData().getAsocIndx());
        }
    }

    /**
     * @param evt
     */
    private void ls_MimeType_Handler(java.awt.event.MouseEvent evt)
    {
        if (evt.getClickCount() > 1)
        {
            me_MainSoft.showMimeForm();
            me_MainSoft.getMimePanel().hashSelect(me_MainSoft.getBaseData().getMimeIndx());
        }
    }

    /**
     * @param evt
     */
    private void ta_ExtsDesp_Handler(java.awt.event.MouseEvent evt)
    {
        if (evt.getClickCount() < 2)
        {
            return;
        }

        // 语言检测
        K1SV2S kvItem = (K1SV2S)wp_DespPanl.cb_LangList.getSelectedItem();
        if (kvItem == null)
        {
            return;
        }

        // 默认值检测
        if (ConstUI.DEF_DESPHASH == me_MainSoft.getBaseData().getDespIndx())
        {
            return;
        }

        // 后缀描述信息显示
        me_MainSoft.showDespForm();
        me_MainSoft.getDespPanel().metaSelect(kvItem);
    }

    /**
     * 后缀名称文本框事件处理
     */
    private void tf_ExtsName_Handler(java.awt.event.ActionEvent evt)
    {
        // 恢复初始状态
        setDefault("");

        // 用户输入数据合法性检测
        UserData userMeta = new UserData();
        userMeta.wInit();

        // 数据检测
        if (!userMeta.setExtsName(wp_UserPanl.getExtsName()))
        {
            MesgUtil.showMessageDialog(Extparse.getForm(), userMeta.getErrMsg());
            wp_UserPanl.tf_ExtsName.requestFocus();
            return;
        }
        wp_UserPanl.tf_ExtsName.setText(userMeta.getExtsName());

        // 数据查询
        metaSelect(userMeta.getExtsName());
    }

    // ////////////////////////////////////////////////////////////////////////
    // 公共接口区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 显示默认界面
     */
    private void setDefault(String value)
    {
        // 软件列表
        this.cm_SoftList.removeAllElements();

        // 描述信息
        wp_DespPanl.ta_ExtsDesp.setText(value);

        // 备选软件
        this.lm_AsocSoft.clear();

        // MIME类型
        this.lm_MimeType.clear();

        // 图标信息
        wp_PropPanl.ib_FileIcon.setBackgroundImage(null);
        wp_PropPanl.ib_SoftIcon.setBackgroundImage(null);
        wp_PropPanl.ib_CorpIcon.setBackgroundImage(null);
        wp_PropPanl.ib_IdioIcon.setBackgroundImage(null);
    }

    /**
     * 详细数据显示
     * 
     * @param baseMeta
     * @throws SQLException
     */
    private boolean setBaseData(DBAccess dba, BaseData baseMeta) throws SQLException
    {
        ExtsBaseData extsData = DA0008.selectExtsMeta(dba, baseMeta);
        // 数据保存
        me_MainSoft.setBaseData(extsData);

        // 使用平台信息显示
        wp_PropPanl.setPlatForm(extsData.getPlatIndx());

        // 系统架构
        wp_PropPanl.setArchBits(extsData.getArchBits());

        // 所属类别
        wp_PropPanl.tf_ExtsType.setText(DC0008.selectTypeName(dba, PrpCons.P3010000_I, extsData.getTypeIndx()));

        // 描述信息读取
        readDespMeta(dba, extsData.getDespIndx());

        // 备选软件读取
        readAsocMeta(dba, extsData.getAsocIndx());

        // MIME类型读取
        readMimeMeta(dba, extsData.getMimeIndx());

        // 图标信息读取
        // 文件图标
        FileBaseData fileData = DA0008.selectFileMetaInfo(dba, extsData.getFileIndx());
        wp_PropPanl.ib_FileIcon.setIconHash(fileData.getFileIcon());
        // 软件图标
        SoftBaseData softData = DA0008.selectSoftMetaInfo(dba, extsData.getSoftIndx());
        wp_PropPanl.ib_SoftIcon.setIconHash(softData.getSoftIcon());
        // 公司图标
        CorpBaseData corpData = DA0008.selectCorpMetaInfo(dba, extsData.getCorpIndx());
        wp_PropPanl.ib_CorpIcon.setIconHash(corpData.getCorpLogo());
        // 个人图标
        IdioBaseData idioData = DA0008.selectIdioMetaInfo(dba, extsData.getIdioIndx());
        wp_PropPanl.ib_IdioIcon.setIconHash(idioData.getIdioLogo());

        return true;
    }

    /**
     * 备选软件查询并显示
     * 
     * @param dba
     * @param asocHash
     * @throws SQLException
     */
    private void readAsocMeta(DBAccess dba, String asocHash) throws SQLException
    {
        this.lm_AsocSoft.clear();

        // 备选软件数据列表查询
        AsocBaseData asocMeta = DA0008.selectAsocMetaInfo(dba, asocHash, "");

        List<K1SV2S> asocList = asocMeta.getAsocList();

        // 结果数据显示
        for (int i = 0, j = asocList.size(); i < j; i += 1)
        {
            this.lm_AsocSoft.addElement(asocList.get(i));
        }
    }

    /**
     * 描述数据查询并显示
     * 
     * @param dba
     * @param despHash
     * @throws SQLException
     */
    private void readDespMeta(DBAccess dba, String despHash) throws SQLException
    {
        K1SV2S kv = (K1SV2S)wp_DespPanl.cb_LangList.getSelectedItem();

        String langHash = (kv != null) ? kv.getK() : RmpsUtil.getUserInfo().getCfg(CfgCons.CFG_LANG_ID);

        // 描述数据查询
        DespBaseData despMeta = DA0008.selectDespMetaInfo(dba, despHash, langHash);

        // 描述信息显示
        wp_DespPanl.ta_ExtsDesp.setText(despMeta.isMetaExist() ? despMeta.getExtsDesp() : "");
    }

    /**
     * MIME类型查询并显示
     * 
     * @param dba
     * @param mimeHash
     * @throws SQLException
     */
    private void readMimeMeta(DBAccess dba, String mimeHash) throws SQLException
    {
        lm_MimeType.clear();

        if (!CheckUtil.isValidate(mimeHash))
        {
            mimeHash = ConstUI.DEF_MIMEHASH;
        }

        // 描述数据查询
        List<K2SV1S> mimeList = DA0008.selectMimeMetaName(dba, mimeHash, "");

        // 描述信息显示
        for (int i = 0, j = mimeList.size(); i < j; i += 1)
        {
            lm_MimeType.addElement(mimeList.get(i));
        }
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面组件变量区域
    // ////////////////////////////////////////////////////////////////////////
    private javax.swing.JButton             bt_FileView;
    private javax.swing.JButton             bt_MainMenu;
    private rmp.comn.rmps.C4010000.C4010000 rl_NoteInfo;
    private WDespPanel                      wp_DespPanl;
    private WPropPanel                      wp_PropPanl;
    private WUserPanel                      wp_UserPanl;
}
