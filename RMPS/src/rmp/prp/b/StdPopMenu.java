/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.b;

import java.awt.event.ActionEvent;

import rmp.comn.tray.C3010000.C3010000;
import com.amonsoft.rmps.prp.ISoft;
import rmp.prp.Prps;
import rmp.util.BeanUtil;
import rmp.util.EnvUtil;
import rmp.util.LogUtil;
import rmp.util.MesgUtil;
import rmp.util.RmpsUtil;
import cons.EnvCons;
import cons.prp.ConstUI;
import cons.prp.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 标准插件快捷菜单
 * <li>使用说明：</li>
 * <br />
 * 系统会根据TrayIcon持有Frame对象列表取得当前使用窗口对象，<br />
 * 因此在构造此对象时不需要传入主窗口的引用<br />
 * </ul>
 * @author Amon
 */
public class StdPopMenu extends javax.swing.JPopupMenu
{
    // ////////////////////////////////////////////////////////////////////////
    // 逻辑控制区域
    // ////////////////////////////////////////////////////////////////////////
    /** 标准插件扩展级联菜单 */
    private javax.swing.JMenu mu_SoftMenu;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 默认构造函数
     */
    public StdPopMenu()
    {
    }

    /**
     * @return
     */
    public boolean wInit()
    {
        ica();

        ita();

        return true;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面显示区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 界面布局初始化
     */
    private void ica()
    {
        // 帮助菜单
        mi_HelpItem = new javax.swing.JMenuItem();
        mi_HelpItem.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent evt)
            {
                mi_HelpItem_Handler(evt);
            }
        });
        add(mi_HelpItem);

        // 分隔符
        addSeparator();

        // 迷你界面
        mi_MiniView = new javax.swing.JMenuItem();
        mi_MiniView.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent evt)
            {
                mi_MiniView_Handler(evt);
            }
        });
        add(mi_MiniView);

        // 正常界面
        mi_NormView = new javax.swing.JMenuItem();
        mi_NormView.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent evt)
            {
                mi_NormView_Handler(evt);
            }
        });
        add(mi_NormView);

        // 高级界面
        mi_MainView = new javax.swing.JMenuItem();
        mi_MainView.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent evt)
            {
                mi_MainView_Handler(evt);
            }
        });
        add(mi_MainView);

        // 分隔符
        sp_SoftPart = new Separator();
        add(sp_SoftPart);

        // 软件菜单
        mu_SoftMenu = new javax.swing.JMenu();
        add(mu_SoftMenu);

        // 分隔符
        addSeparator();

        // 检测更新
        mi_ChckUpdt = new javax.swing.JMenuItem();
        mi_ChckUpdt.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent evt)
            {
                mi_ChckUpdt_Handler(evt);
            }
        });
        add(mi_ChckUpdt);

        // 软件首页
        mi_HomePage = new javax.swing.JMenuItem();
        mi_HomePage.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent evt)
            {
                mi_HomePage_Handler(evt);
            }
        });
        add(mi_HomePage);

        // 关于菜单
        mi_InfoItem = new javax.swing.JMenuItem();
        mi_InfoItem.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent evt)
            {
                mi_InfoItem_Handler(evt);
            }
        });
        add(mi_InfoItem);
    }

    /**
     * 界面语言初始化
     */
    private void ita()
    {
        // 帮助菜单
        BeanUtil.setWText(mi_HelpItem, Prps.getMesg(LangRes.MENU_TEXT_HELPITEM));
        BeanUtil.setWTips(mi_HelpItem, Prps.getMesg(LangRes.MENU_TIPS_HELPITEM));

        // 软件首页
        BeanUtil.setWText(mi_HomePage, Prps.getMesg(LangRes.MENU_TEXT_HOMEPAGE));
        BeanUtil.setWTips(mi_HomePage, Prps.getMesg(LangRes.MENU_TIPS_HOMEPAGE));

        // 关于菜单
        BeanUtil.setWText(mi_InfoItem, Prps.getMesg(LangRes.MENU_TEXT_INFOITEM));
        BeanUtil.setWTips(mi_InfoItem, Prps.getMesg(LangRes.MENU_TIPS_INFOITEM));

        // 检测更新
        BeanUtil.setWText(mi_ChckUpdt, Prps.getMesg(LangRes.MENU_TEXT_CHCKUPDT));
        BeanUtil.setWTips(mi_ChckUpdt, Prps.getMesg(LangRes.MENU_TIPS_CHCKUPDT));

        // 迷你模式
        BeanUtil.setWText(mi_MiniView, Prps.getMesg(LangRes.MENU_TEXT_MINIVIEW));
        BeanUtil.setWTips(mi_MiniView, Prps.getMesg(LangRes.MENU_TIPS_MINIVIEW));

        // 正常模式
        BeanUtil.setWText(mi_NormView, Prps.getMesg(LangRes.MENU_TEXT_NORMVIEW));
        BeanUtil.setWTips(mi_NormView, Prps.getMesg(LangRes.MENU_TIPS_NORMVIEW));

        // 高级模式
        BeanUtil.setWText(mi_MainView, Prps.getMesg(LangRes.MENU_TEXT_MAINVIEW));
        BeanUtil.setWTips(mi_MainView, Prps.getMesg(LangRes.MENU_TIPS_MAINVIEW));
    }

    // ////////////////////////////////////////////////////////////////////////
    // 对外接口区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 获取对软件菜单的引用
     * 
     * @return
     */
    public javax.swing.JMenu getSoftMenu()
    {
        return mu_SoftMenu;
    }

    /**
     * 设置软件菜单的可见性
     * 
     * @param aFlag
     */
    public void setSoftMenuVisible(boolean aFlag)
    {
        sp_SoftPart.setVisible(aFlag);
        mu_SoftMenu.setVisible(aFlag);
    }

    // ////////////////////////////////////////////////////////////////////////
    // 菜单事件处理区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 帮助菜单事件处理
     * 
     * @param evt
     */
    private void mi_HelpItem_Handler(java.awt.event.ActionEvent evt)
    {
        Prps.getCurrSoft().wShowHelp();
    }

    /**
     * 检测更新事件处理
     * 
     * @param evt
     */
    private void mi_ChckUpdt_Handler(java.awt.event.ActionEvent evt)
    {
        Thread t = new Thread()
        {
            public void run()
            {
                checkUpdate();
            }
        };
        t.start();
    }

    /**
     * 软件首页事件处理
     * 
     * @param evt
     */
    private void mi_HomePage_Handler(java.awt.event.ActionEvent evt)
    {
        EnvUtil.browse(Prps.getCurrSoft().wGetHomepage());
    }

    /**
     * 关于菜单事件处理
     * 
     * @param evt
     */
    private void mi_InfoItem_Handler(java.awt.event.ActionEvent evt)
    {
        LogUtil.log("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Prps.getCurrSoft().wShowInfo();
    }

    /**
     * 迷你窗口事件处理
     * 
     * @param evt
     */
    private void mi_MiniView_Handler(java.awt.event.ActionEvent evt)
    {
        LogUtil.log("标准插件启动：" + Prps.getCurrSoft().wGetName());
        Prps.getCurrSoft().wShowView(ISoft.VIEW_MINI);
    }

    /**
     * 正常窗口事件处理
     * 
     * @param evt
     */
    private void mi_NormView_Handler(java.awt.event.ActionEvent evt)
    {
        LogUtil.log("标准插件启动：" + Prps.getCurrSoft().wGetName());
        Prps.getCurrSoft().wShowView(ISoft.VIEW_NORM);
    }

    /**
     * 高级窗口事件处理
     * 
     * @param evt
     */
    private void mi_MainView_Handler(java.awt.event.ActionEvent evt)
    {
        LogUtil.log("标准插件启动：" + Prps.getCurrSoft().wGetName());
        Prps.getCurrSoft().wShowView(ISoft.VIEW_MAIN);
    }

    /**
     * 检测更新
     */
    private void checkUpdate()
    {
        javax.swing.JFrame frm = (javax.swing.JFrame) C3010000.queryRef("prp");
        try
        {
            boolean isNew = RmpsUtil.checkUpdate(EnvCons.PRPS_SOFTEDIT, ConstUI.VER_SOFT);
            MesgUtil.showMessageDialog(frm, Prps.getMesg(isNew ? LangRes.MESG_OTHR_0008 : LangRes.MESG_OTHR_0007));
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            MesgUtil.showMessageDialog(frm, Prps.getMesg(LangRes.MESG_OTHR_0006));
        }
    }
    // ////////////////////////////////////////////////////////////////////////
    // 界面构件区域
    // ////////////////////////////////////////////////////////////////////////
    private javax.swing.JMenuItem mi_ChckUpdt;
    private javax.swing.JMenuItem mi_HelpItem;
    private javax.swing.JMenuItem mi_HomePage;
    private javax.swing.JMenuItem mi_InfoItem;
    private javax.swing.JMenuItem mi_MiniView;
    private javax.swing.JMenuItem mi_NormView;
    private javax.swing.JMenuItem mi_MainView;
    private Separator sp_SoftPart;
    /** serialVersionUID */
    private static final long serialVersionUID = 1783456486113583573L;
}
