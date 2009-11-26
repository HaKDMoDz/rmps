/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.b;

import com.amonsoft.rmps.prp.ISoft;
import cons.EnvCons;
import cons.prp.ConstUI;
import rmp.prp.Prps;
import cons.prp.LangRes;
import rmp.comn.tray.C3010000.C3010000;
import rmp.util.EnvUtil;
import com.amonsoft.util.LangUtil;
import rmp.util.LogUtil;
import rmp.util.MesgUtil;
import rmp.util.RmpsUtil;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 标准插件对象
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class StdPlug_In extends javax.swing.JPanel
{
    /**Tail面板是否处于展开状态*/
    private boolean expanded;
    /** 语言资源对象 */
    private LangUtil langUtil;
    /** 标准插件对象 */
    private ISoft soft;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    static
    {
    }

    /**
     * 默认构造函数
     */
    public StdPlug_In()
    {
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面显示区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 界面布局初始化
     */
    public void wInitView()
    {
        pl_Info = new javax.swing.JPanel();
        lb_Soft = new javax.swing.JLabel();
        lb_Tree = new javax.swing.JLabel();
        lb_Menu = new javax.swing.JLabel();
        pl_Soft = new javax.swing.JPanel();

        pl_Info.setLayout(new java.awt.BorderLayout());

        lb_Tree.addMouseListener(new java.awt.event.MouseAdapter()
        {
            @Override
            public void mouseReleased(java.awt.event.MouseEvent evt)
            {
                lt_TreeLabl_Handler(null);
            }
        });
        pl_Info.add(lb_Tree, java.awt.BorderLayout.WEST);

        lb_Soft.addMouseListener(new java.awt.event.MouseAdapter()
        {
            @Override
            public void mouseReleased(java.awt.event.MouseEvent evt)
            {
                bt_SoftButn_Handler(null);
            }
        });
        pl_Info.add(lb_Soft, java.awt.BorderLayout.CENTER);

        lb_Menu.addMouseListener(new java.awt.event.MouseAdapter()
        {
            @Override
            public void mouseReleased(java.awt.event.MouseEvent evt)
            {
                bt_MenuButn_Handler(null);
            }
        });
        pl_Info.add(lb_Menu, java.awt.BorderLayout.EAST);

        pl_Soft.setLayout(new java.awt.BorderLayout());
        pl_Soft.setBorder(javax.swing.BorderFactory.createEtchedBorder());

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        javax.swing.GroupLayout.SequentialGroup hsg = layout.createSequentialGroup();
        hsg.addContainerGap();
        hsg.addComponent(pl_Soft, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE);
        hsg.addContainerGap();
        javax.swing.GroupLayout.ParallelGroup hpg = layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING);
        hpg.addComponent(pl_Info, javax.swing.GroupLayout.DEFAULT_SIZE, 200, Short.MAX_VALUE);
        hpg.addGroup(hsg);
        layout.setHorizontalGroup(hpg);

        javax.swing.GroupLayout.SequentialGroup vsg = layout.createSequentialGroup();
        vsg.addComponent(pl_Info, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE);
        //vsg.addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED);
        vsg.addComponent(pl_Soft, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE);
        vsg.addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE);
        layout.setVerticalGroup(vsg);

        // 帮助菜单
        mi_HelpItem = new javax.swing.JMenuItem();
        mi_HelpItem.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_HelpItem_Handler(evt);
            }
        });
        add(mi_HelpItem);

        // 分隔符
        pm_Menu.addSeparator();

        // 迷你界面
        mi_MiniView = new javax.swing.JMenuItem();
        mi_MiniView.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
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
            public void actionPerformed(java.awt.event.ActionEvent evt)
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
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_MainView_Handler(evt);
            }
        });
        add(mi_MainView);

        // 分隔符
        sp_SoftPart = new javax.swing.JPopupMenu.Separator();
        add(sp_SoftPart);

        // 软件菜单
        mu_SoftMenu = new javax.swing.JMenu();
        add(mu_SoftMenu);

        // 分隔符
        pm_Menu.addSeparator();

        // 检测更新
        mi_ChckUpdt = new javax.swing.JMenuItem();
        mi_ChckUpdt.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
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
            public void actionPerformed(java.awt.event.ActionEvent evt)
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
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_InfoItem_Handler(evt);
            }
        });
        add(mi_InfoItem);
    }

    /**
     * 界面语言初始化
     */
    public void wInitLang()
    {
        // 扩展
        langUtil.setWText(lb_Tree, LangRes.BUTN_TEXT_PANEBUTN, "");
        langUtil.setWTips(lb_Tree, LangRes.BUTN_TIPS_PANEBUTN_C, "");

        // 菜单
        langUtil.setWText(lb_Menu, LangRes.BUTN_TEXT_MENUBUTN, "");
        langUtil.setWTips(lb_Menu, LangRes.BUTN_TIPS_MENUBUTN, "");

        // 帮助菜单
        langUtil.setWText(mi_HelpItem, LangRes.MENU_TEXT_HELPITEM, "");
        langUtil.setWTips(mi_HelpItem, LangRes.MENU_TIPS_HELPITEM, "");

        // 软件首页
        langUtil.setWText(mi_HomePage, LangRes.MENU_TEXT_HOMEPAGE, "");
        langUtil.setWTips(mi_HomePage, LangRes.MENU_TIPS_HOMEPAGE, "");

        // 关于菜单
        langUtil.setWText(mi_InfoItem, LangRes.MENU_TEXT_INFOITEM, "");
        langUtil.setWTips(mi_InfoItem, LangRes.MENU_TIPS_INFOITEM, "");

        // 检测更新
        langUtil.setWText(mi_ChckUpdt, LangRes.MENU_TEXT_CHCKUPDT, "");
        langUtil.setWTips(mi_ChckUpdt, LangRes.MENU_TIPS_CHCKUPDT, "");

        // 迷你模式
        langUtil.setWText(mi_MiniView, LangRes.MENU_TEXT_MINIVIEW, "");
        langUtil.setWTips(mi_MiniView, LangRes.MENU_TIPS_MINIVIEW, "");

        // 正常模式
        langUtil.setWText(mi_NormView, LangRes.MENU_TEXT_NORMVIEW, "");
        langUtil.setWTips(mi_NormView, LangRes.MENU_TIPS_NORMVIEW, "");

        // 高级模式
        langUtil.setWText(mi_MainView, LangRes.MENU_TEXT_MAINVIEW, "");
        langUtil.setWTips(mi_MainView, LangRes.MENU_TIPS_MAINVIEW, "");
    }

    public void wInitData()
    {
    }

    // ////////////////////////////////////////////////////////////////////////
    // 公共接口区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 设置构件对应的软件对象
     * 
     * @return
     */
    public boolean setSoft(ISoft soft)
    {
        this.soft = soft;
        lb_Soft.setIcon(new javax.swing.ImageIcon(soft.wGetIconImage(ISoft.ICON_LOGO0016)));
//        setSoftMenuVisible(soft.wShowMenu(m));
        langUtil.setWText(lb_Soft, "", soft.wGetTitle());
        langUtil.setWTips(lb_Soft, "", soft.wGetDescription());
        return true;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 事件处理区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 级联按钮事件处理，用于打开或关闭内嵌面板
     * 
     * @param evt
     */
    private void lt_TreeLabl_Handler(java.awt.event.MouseEvent evt)
    {
        // 显示状态判断
        expanded = !expanded;
        pl_Soft.setVisible(expanded);
//        tl_TreeLabl.setToolTipText(selected ? langUtil.getMesg(LangRes.BUTN_TIPS_PANEBUTN_X, "") : langUtil.getMesg(LangRes.BUTN_TIPS_PANEBUTN_C, ""));

        // 构件显示
        expanded = soft.wShowTail(pl_Soft);
        if (!expanded)
        {
            if (lb_Tree == null)
            {
                lb_Tree = new javax.swing.JLabel(langUtil.getMesg(LangRes.LABL_TEXT_INFOLABL, ""));
                pl_Soft.setLayout(new java.awt.FlowLayout());
            }
            pl_Soft.removeAll();
            pl_Soft.add(lb_Tree);
        }

        // 记录当前软件
        Prps.setCurrSoft(soft);
    }

    /**
     * 软件标签按钮事件处理，用于打开或关闭内嵌面板
     * 
     * @param evt
     */
    private void bt_SoftButn_Handler(java.awt.event.ActionEvent evt)
    {
        // 显示状态判断
//        boolean b = !tl_TreeLabl.isSelected();
//        tl_TreeLabl.setSelected(b);
//        pl_Soft.setVisible(b);
//        tl_TreeLabl.setToolTipText(b ? langUtil.getMesg(LangRes.BUTN_TIPS_PANEBUTN_X, "") : langUtil.getMesg(LangRes.BUTN_TIPS_PANEBUTN_C, ""));

        // 构件显示
//        b = soft.wShowTail(pl_Soft);
//        if (!b)
//        {
//            if (lb_Tree == null)
//            {
//                lb_Tree = new javax.swing.JLabel(langUtil.getMesg(LangRes.LABL_TEXT_INFOLABL, ""));
//                pl_Soft.setLayout(new java.awt.FlowLayout());
//            }
//            pl_Soft.removeAll();
//            pl_Soft.add(lb_Tree);
//        }

        // 记录当前软件
        Prps.setCurrSoft(soft);
    }

    /**
     * @param evt
     */
    private void bt_MenuButn_Handler(java.awt.event.ActionEvent evt)
    {
        // 显示弹出式菜单
        pm_Menu.show(lb_Menu, 0, lb_Menu.getSize().height);

        // 记录当前软件
        Prps.setCurrSoft(soft);
    }

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
            @Override
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
            MesgUtil.showMessageDialog(frm, langUtil.getMesg(isNew ? LangRes.MESG_OTHR_0008 : LangRes.MESG_OTHR_0007, ""));
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            MesgUtil.showMessageDialog(frm, langUtil.getMesg(LangRes.MESG_OTHR_0006, ""));
        }
    }
    // ////////////////////////////////////////////////////////////////////////
    // 界面变量区域
    // ////////////////////////////////////////////////////////////////////////
    private javax.swing.JLabel lb_Tree;
    private javax.swing.JLabel lb_Soft;
    private javax.swing.JLabel lb_Menu;
    private javax.swing.JPanel pl_Info;
    private javax.swing.JPanel pl_Soft;
    private javax.swing.JPopupMenu pm_Menu;
    private javax.swing.JMenu mu_SoftMenu;
    private javax.swing.JMenuItem mi_ChckUpdt;
    private javax.swing.JMenuItem mi_HelpItem;
    private javax.swing.JMenuItem mi_HomePage;
    private javax.swing.JMenuItem mi_InfoItem;
    private javax.swing.JMenuItem mi_MiniView;
    private javax.swing.JMenuItem mi_NormView;
    private javax.swing.JMenuItem mi_MainView;
    private javax.swing.JPopupMenu.Separator sp_SoftPart;
}
