/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3010000.v;

import java.io.File;
import java.sql.SQLException;
import java.util.EventObject;
import java.util.List;

import javax.swing.DefaultListModel;

import rmp.bean.K1SV2S;
import rmp.bean.K2SV1S;
import rmp.face.WBackCall;
import rmp.io.db.DBAccess;
import rmp.prp.aide.DC0008;
import rmp.prp.aide.P3010000.P3010000;
import rmp.prp.aide.P3010000.b.ArchBean;
import rmp.prp.aide.P3010000.b.DespBean;
import rmp.prp.aide.P3010000.b.PlatBean;
import rmp.prp.aide.P3010000.b.UserBean;
import rmp.prp.aide.P3010000.b.WIconBox;
import rmp.prp.aide.P3010000.b.WItemForm;
import rmp.prp.aide.P3010000.d.DA8000;
import rmp.prp.aide.P3010000.m.AsocBaseData;
import rmp.prp.aide.P3010000.m.CorpBaseData;
import rmp.prp.aide.P3010000.m.ExtsBaseData;
import rmp.prp.aide.P3010000.m.FileBaseData;
import rmp.prp.aide.P3010000.m.IdioBaseData;
import rmp.prp.aide.P3010000.m.SoftBaseData;
import rmp.prp.aide.P3010000.m.UserData;
import rmp.prp.aide.P3010000.t.Util;
import rmp.prp.aide.extparse.d.DA0008;
import rmp.util.BeanUtil;
import rmp.util.CheckUtil;
import rmp.util.FileUtil;
import rmp.util.LogUtil;
import rmp.util.MesgUtil;
import rmp.util.StringUtil;
import cons.id.PrpCons;
import cons.prp.aide.P3010000.ConstUI;
import cons.prp.aide.P3010000.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 后缀解析高级模式面板
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class MainPanel extends javax.swing.JPanel implements WBackCall
{
    // ////////////////////////////////////////////////////////////////////////
    // 界面控制变量区域
    // ////////////////////////////////////////////////////////////////////////
    /** 用户查询对象 */
    private UserData bd_BaseMeta;
    /** 备选软件列表数据模型 */
    private DefaultListModel lm_AsocSoft;
    /** MIME类型列表数据模型 */
    private DefaultListModel lm_MimeType;
    /** 父应用引用 */
    private P3010000 ms_MainSoft;
    private UserBean ub_UserBean;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @param soft
     */
    public MainPanel(P3010000 soft)
    {
        ms_MainSoft = soft;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 接口实现区域
    // ////////////////////////////////////////////////////////////////////////
    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    public boolean wInit()
    {
        // 界面初始化
        ica();
        icb();
        icc();
        icd();

        // 界面语言显示
        ita();
        itb();
        itc();
        itd();

        // 数据模型设置
        lm_AsocSoft = new DefaultListModel();
        ls_AsocSoft.setModel(lm_AsocSoft);

        lm_MimeType = new DefaultListModel();
        ls_MimeType.setModel(lm_MimeType);

        ls_AsocSoft.addMouseListener(new java.awt.event.MouseAdapter()
        {
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                ls_AsocSoft_Handler(evt);
            }
        });
        ls_MimeType.addMouseListener(new java.awt.event.MouseAdapter()
        {
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                ls_MimeType_Handler(evt);
            }
        });

        return true;
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
        UserData ud = (UserData) object;
        if (ud.getSoftHash() == null)
        {
            metaSelect(ud.getExtsName());
        }
        else
        {
            metaSelect(ud.getExtsHash(), ud.getSoftHash());
        }
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

        try
        {
            // 建立连接
            if (!dba.wInit())
            {
                return false;
            }

            // 后缀数据查询
            List<UserData> metaList = DA8000.selectMeta(dba, extsName);
            if (metaList != null && metaList.size() > 0)
            {
                // 状态栏结果显示
                String arg1 = P3010000.getMesg(LangRes.MAIN_LABL_TEXT_NOTEINFO);
                String arg2 = Integer.toString(metaList.size());
                String note = StringUtil.format(LangRes.NOTE_STAT_0002, arg1, arg2);
                pb_PublicAd.showInfo(note);

                // 显示列表
                for (UserData meta : metaList)
                {
                    ub_UserBean.add(meta);
                }

                // 首个结果数据显示
                bd_BaseMeta = metaList.get(0);
                viewData(dba, bd_BaseMeta);

                return true;
            }
        }
        catch (SQLException exp)
        {
            LogUtil.exception(exp);
            String mesg = StringUtil.format(LangRes.MESG_SELT_0007, LangRes.TITLE_EXTSFORM, LangRes.MESG_INIT_0010);
            MesgUtil.showMessageDialog(P3010000.getForm(), mesg);
            return false;
        }
        finally
        {
            dba.closeConnection();
        }

        // 状态栏结果显示
        String note = StringUtil.format(LangRes.NOTE_STAT_0003, LangRes.MAIN_LABL_TEXT_NOTEINFO);
        pb_PublicAd.showInfo(note);

        // 数据不存在时，提示用户添加数据
        String arg1 = P3010000.getMesg(LangRes.MAIN_COMN_TEXT_EXTSNAME);
        String arg2 = P3010000.getMesg(LangRes.TITLE_EXTSFORM);
        String mesg = StringUtil.format(LangRes.MESG_SELT_0008, arg1, extsName, arg2);
        if (0 == MesgUtil.showConfirmDialog(P3010000.getForm(), mesg))
        {
            // 显示数据新增面板
            LogUtil.log("数据不存在的情况下，显示数据新增界面！");
            ms_MainSoft.wShowView(P3010000.VIEW_STEP);
        }

        return true;
    }

    /**
     * @param extsName 形如“.abc”格式的后缀名称
     * @param softHash
     */
    public boolean metaSelect(String extsName, String softHash)
    {
        DBAccess dba = new DBAccess();

        try
        {
            if (!dba.wInit())
            {
                return false;
            }

            bd_BaseMeta = DA8000.selectMeta(dba, extsName, softHash);
            return viewData(dba, bd_BaseMeta);
        }
        catch (SQLException exp)
        {
            LogUtil.exception(exp);
            String mesg = StringUtil.format(LangRes.MESG_SELT_0007, LangRes.TITLE_EXTSFORM, LangRes.MESG_INIT_0010);
            MesgUtil.showMessageDialog(P3010000.getForm(), mesg);
            return false;
        }
        finally
        {
            dba.closeConnection();
        }
    }

    /**
     * @param extsName
     * @return
     */
    public boolean metaDelete(String extsName)
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

        String arg1 = P3010000.getMesg(LangRes.MAIN_COMN_TEXT_EXTSNAME);
        String mesg = StringUtil.format(LangRes.MESG_DELT_0007, arg1, extsName, "");
        if (MesgUtil.showConfirmDialog(P3010000.getForm(), mesg) != 0)
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
        catch (SQLException exp)
        {
            LogUtil.exception(exp);
            return false;
        }
        finally
        {
            dba.closeConnection();
        }
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面初始化区域
    // ////////////////////////////////////////////////////////////////////////
    // ----------------------------------------------------
    // 界面布局初始化
    // ----------------------------------------------------
    /**
     * 用户交互面板布局初始化
     */
    private void ica()
    {
    }

    /**
     * 后缀属性面板布局初始化
     */
    private void icb()
    {
    }

    /**
     * 后缀描述面板布局初始化
     */
    private void icc()
    {
    }

    /**
     * 主窗口布局初始化
     */
    private void icd()
    {
        bu_UserBean = new UserBean();
        bu_UserBean.wInit();

        pb_PublicAd = new rmp.comn.rmps.C4010000.C4010000();
        pb_PublicAd.wInit();
        pb_PublicAd.wShowView(P3010000.VIEW_NORM);

        bt_MainMenu = new javax.swing.JButton();
        bt_FileView = new javax.swing.JButton();

        java.awt.Color c = new java.awt.Color(204, 204, 204);
        wp_PropPanel.setBorder(new javax.swing.border.LineBorder(c, 1, true));

        bd_DespBean = new DespBean();
        bd_DespBean.wInit();
        bd_DespBean.setBorder(new javax.swing.border.LineBorder(c, 1, true));

        bt_MainMenu.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_MainMenu_Handler(evt);
            }
        });

        bt_FileView.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_FileView_Handler(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false).addGroup(
                layout.createSequentialGroup().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(bu_UserBean,
                javax.swing.GroupLayout.DEFAULT_SIZE, 270, Short.MAX_VALUE).addComponent(wp_PropPanel,
                javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addComponent(bd_DespBean,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE)).addGroup(
                layout.createSequentialGroup().addComponent(bt_MainMenu).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addComponent(pb_PublicAd.getAd(),
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addComponent(bt_FileView))).addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE,
                Short.MAX_VALUE)));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addComponent(bu_UserBean, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(wp_PropPanel,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)).addComponent(bd_DespBean, javax.swing.GroupLayout.DEFAULT_SIZE, 304, Short.MAX_VALUE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(bt_MainMenu).addComponent(bt_FileView).addComponent(pb_PublicAd.getAd())).addContainerGap()));
    }

    // ----------------------------------------------------
    // 界面语言初始化
    // ----------------------------------------------------
    /**
     * 用户交互面板语言初始化
     * 
     * @param isHash
     */
    private void ita()
    {
    }

    /**
     * 后缀属性面板语言初始化
     */
    private void itb()
    {
        // 所属类别
        BeanUtil.setWText(lb_ExtsType, P3010000.getMesg(LangRes.MAIN_LABL_TEXT_EXTSTYPE));
        BeanUtil.setWTips(lb_ExtsType, P3010000.getMesg(LangRes.MAIN_LABL_TIPS_EXTSTYPE));

        BeanUtil.setWText(tf_ExtsType, P3010000.getMesg(LangRes.MAIN_FILD_TEXT_EXTSTYPE));
        BeanUtil.setWTips(tf_ExtsType, P3010000.getMesg(LangRes.MAIN_FILD_TIPS_EXTSTYPE));
    }

    /**
     * 后缀描述面板语言初始化
     */
    private void itc()
    {
        // 后缀描述
        BeanUtil.setWText(lb_ExtsDesp, P3010000.getMesg(LangRes.MAIN_LABL_TEXT_EXTSDESP));
        BeanUtil.setWTips(lb_ExtsDesp, P3010000.getMesg(LangRes.MAIN_LABL_TIPS_EXTSDESP));

        // 备选软件
        BeanUtil.setWText(lb_AsocSoft, P3010000.getMesg(LangRes.MAIN_LABL_TEXT_ASOCSOFT));
        BeanUtil.setWTips(lb_AsocSoft, P3010000.getMesg(LangRes.MAIN_LABL_TIPS_ASOCSOFT));

        BeanUtil.setWTips(ls_AsocSoft, P3010000.getMesg(LangRes.MAIN_LIST_TIPS_ASOCSOFT));

        // MIME类型
        BeanUtil.setWText(lb_MimeType, P3010000.getMesg(LangRes.MAIN_LABL_TEXT_MIMETYPE));
        BeanUtil.setWTips(lb_MimeType, P3010000.getMesg(LangRes.MAIN_LABL_TIPS_MIMETYPE));

        BeanUtil.setWTips(ls_MimeType, P3010000.getMesg(LangRes.MAIN_LIST_TIPS_MIMETYPE));
    }

    /**
     * 主窗口语言初始化
     */
    private void itd()
    {
        // 系统菜单
        BeanUtil.setWText(bt_MainMenu, P3010000.getMesg(LangRes.MAIN_BUTN_TEXT_MAINMENU));
        BeanUtil.setWTips(bt_MainMenu, P3010000.getMesg(LangRes.MAIN_BUTN_TIPS_MAINMENU));

        // 查看按钮
        BeanUtil.setWText(bt_FileView, P3010000.getMesg(LangRes.MAIN_BUTN_TEXT_FILEVIEW));
        BeanUtil.setWTips(bt_FileView, P3010000.getMesg(LangRes.MAIN_BUTN_TIPS_FILEVIEW));

        // 公益广告
        // BeanUtil.setWText(rl_NoteInfo,
        // P3010000.getMesg(LangRes.MAIN_ROLL_TEXT_PUBLICAD));
        // BeanUtil.setWTips(rl_NoteInfo,
        // P3010000.getMesg(LangRes.MAIN_ROLL_TIPS_PUBLICAD));
    }

    // ////////////////////////////////////////////////////////////////////////
    // 事件处理区域
    // ////////////////////////////////////////////////////////////////////////
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
            MesgUtil.showMessageDialog(P3010000.getForm(), mesg);
            return;
        }

        // 设置文件后缀信息
        bu_UserBean.setExtsName(extsName);
        metaSelect(bu_UserBean.getExtsName());
    }

    /**
     * 菜单按钮事件处理
     * 
     * @param evt
     */
    private void bt_MainMenu_Handler(java.awt.event.ActionEvent evt)
    {
        Util.showMainMenu(bt_MainMenu);
    }

    /**
     * @param evt
     */
    private void ls_AsocSoft_Handler(java.awt.event.MouseEvent evt)
    {
        if (evt.getClickCount() > 1)
        {
            K1SV2S kvItem = (K1SV2S) ls_MimeType.getSelectedValue();
            WItemForm.getInstance().wShowItem("").wViewData(kvItem.getK());
        }
    }

    /**
     * @param evt
     */
    private void ls_MimeType_Handler(java.awt.event.MouseEvent evt)
    {
        if (evt.getClickCount() > 1)
        {
            K1SV2S kvItem = (K1SV2S) ls_MimeType.getSelectedValue();
            WItemForm.getInstance().wShowItem("").wViewData(kvItem.getK());
        }
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
        bu_UserBean.clear();

        // 描述信息

        // 备选软件
        this.lm_AsocSoft.clear();

        // MIME类型
        this.lm_MimeType.clear();

        // 图标信息
        ib_FileIcon.setIconName("0");
        ib_SoftIcon.setIconName("0");
        ib_CorpIcon.setIconName("0");
        ib_IdioIcon.setIconName("0");
    }

    /**
     * 详细数据显示
     * 
     * @param baseMeta
     * @throws SQLException
     */
    private boolean viewData(DBAccess dba, UserData baseMeta) throws SQLException
    {
        // 基本数据
        ExtsBaseData extsData = DA8000.selectExtsMetaInfo(dba, bd_BaseMeta.getExtsHash(), bd_BaseMeta.getSoftHash());

        // 使用平台信息显示
        bp_PlatBean.decodePlatForm(extsData.getPlatIndx());

        // 系统架构
        ba_ArchBean.decodeArchBits(extsData.getArchBits());

        // 所属类别
        tf_ExtsType.setText(DC0008.selectTypeName(dba, PrpCons.P3010000_I, extsData.getTypeIndx()));

        // 描述信息读取
        bd_DespBean.readDespMeta(dba, extsData.getDespIndx());

        // 备选软件读取
        readAsocMeta(dba, extsData.getAsocIndx());

        // MIME类型读取
        readMimeMeta(dba, extsData.getMimeIndx());

        // 图标信息读取
        // 文件图标
        FileBaseData fileData = DA8000.selectFileMetaInfo(dba, extsData.getFileIndx());
        ib_FileIcon.setIconName(fileData.getFileIcon());
        // 软件图标
        SoftBaseData softData = DA8000.selectSoftMetaInfo(dba, extsData.getSoftIndx());
        ib_SoftIcon.setIconName(softData.getSoftIcon());
        // 公司图标
        CorpBaseData corpData = DA8000.selectCorpMetaInfo(dba, extsData.getCorpIndx());
        ib_CorpIcon.setIconName(corpData.getCorpLogo());
        // 个人图标
        IdioBaseData idioData = DA8000.selectIdioMetaInfo(dba, extsData.getIdioIndx());
        ib_IdioIcon.setIconName(idioData.getIdioLogo());

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
        AsocBaseData asocMeta = DA8000.selectAsocMetaInfo(dba, asocHash, "");

        List<K1SV2S> asocList = asocMeta.getAsocList();

        // 结果数据显示
        for (int i = 0, j = asocList.size(); i < j; i += 1)
        {
            this.lm_AsocSoft.addElement(asocList.get(i));
        }
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
    /** 后缀属性界面组件 */
    private javax.swing.JPanel wp_PropPanel;
    protected javax.swing.JLabel lb_ExtsType;
    protected javax.swing.JTextField tf_ExtsType;
    protected WIconBox ib_CorpIcon;
    protected WIconBox ib_FileIcon;
    protected WIconBox ib_IdioIcon;
    protected WIconBox ib_SoftIcon;
    /** 后缀描述界面组件 */
    private javax.swing.JPanel wp_DespPanel;
    protected javax.swing.JLabel lb_AsocSoft;
    protected javax.swing.JLabel lb_ExtsDesp;
    protected javax.swing.JLabel lb_MimeType;
    protected javax.swing.JList ls_AsocSoft;
    protected javax.swing.JList ls_MimeType;
    /** 主界面组件 */
    private ArchBean ba_ArchBean;
    private DespBean bd_DespBean;
    private PlatBean bp_PlatBean;
    private UserBean bu_UserBean;
    private javax.swing.JButton bt_FileView;
    private javax.swing.JButton bt_MainMenu;
    private rmp.comn.rmps.C4010000.C4010000 pb_PublicAd;
    /** serialVersionUID */
    private static final long serialVersionUID = 2180813461921316710L;
}
