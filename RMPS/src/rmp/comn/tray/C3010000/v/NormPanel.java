/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.comn.tray.C3010000.v;

import java.util.logging.Level;
import java.util.logging.Logger;
import rmp.Rmps;
import rmp.comn.tray.C3010000.C3010000;
import rmp.util.EnvUtil;
import rmp.util.MesgUtil;
import cons.EnvCons;
import cons.SysCons;
import cons.comn.tray.C3010000.LangRes;
import com.amonsoft.util.DeskUtil;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br />
 * TODO: 使用说明
 * </ul>
 * @author Amon
 */
public class NormPanel
{
    // ////////////////////////////////////////////////////////////////////////
    // 控制变量区域
    // ////////////////////////////////////////////////////////////////////////
    /**  */
    private C3010000 ms_MainSoft;
    /**  */
    private java.awt.PopupMenu pm_PopsMenu;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 默认构造函数
     * 
     * @param soft
     */
    public NormPanel(C3010000 soft, java.awt.PopupMenu popMenu)
    {
        this.ms_MainSoft = soft;
        this.pm_PopsMenu = popMenu;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.ui.frm.FViewPanel#init()
     */
    public boolean wInit()
    {
        pm_PopsMenu.removeAll();

        // 布局初始化
        ica();

        // 语言初始化
        ita();

        return true;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 对外接口区域
    // ////////////////////////////////////////////////////////////////////////
    // ////////////////////////////////////////////////////////////////////////
    // 布局显示区域
    // ////////////////////////////////////////////////////////////////////////
    // ----------------------------------------------------
    // 界面布局区域
    // ----------------------------------------------------
    /**
     * 界面布局初始化<br>
     * 其它布局初始化方法命名：icb、icc、icd...以此类推。
     */
    private void ica()
    {
        // 系统帮助菜单
        mi_HelpTops = new java.awt.MenuItem(LangRes.MENU_TEXT_HELPTOPS);
        mi_HelpTops.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_HelpTops_Handler(evt);
            }
        });
        pm_PopsMenu.add(mi_HelpTops);

        // 软件首页
        mi_HomePage = new java.awt.MenuItem(LangRes.MENU_TEXT_HOMEPAGE);
        mi_HomePage.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_HomePage_Handle(evt);
            }
        });
        pm_PopsMenu.add(mi_HomePage);

        // 分隔符
        pm_PopsMenu.addSeparator();

        // 隐藏窗口
        mi_HideForm = new java.awt.MenuItem(LangRes.MENU_TEXT_RMPSHIDE);
        mi_HideForm.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_HideForm_Handle(evt);
            }
        });
        pm_PopsMenu.add(mi_HideForm);

        // 显示窗口
        mi_ShowForm = new java.awt.MenuItem(LangRes.MENU_TEXT_RMPSSHOW);
        mi_ShowForm.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_ShowForm_Handle(evt);
            }
        });
        pm_PopsMenu.add(mi_ShowForm);

        // 分隔符
        pm_PopsMenu.addSeparator();

        // 系统退出菜单
        mi_RmpsExit = new java.awt.MenuItem(LangRes.MENU_TEXT_RMPSEXIT);
        mi_RmpsExit.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_RmpsExit_Handle(evt);
            }
        });
        pm_PopsMenu.add(mi_RmpsExit);
    }

    // ----------------------------------------------------
    // 语言显示区域
    // ----------------------------------------------------
    /**
     * 界面语言初始化<br>
     * 其它语言初始化方法命名：itb、itc、itd...以此类推。
     */
    private void ita()
    {
    }

    // ////////////////////////////////////////////////////////////////////////
    // 事件处理区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 使用帮助事件处理
     */
    private void mi_HelpTops_Handler(java.awt.event.ActionEvent evt)
    {
        try
        {
            DeskUtil.open(EnvCons.FOLDER0_HELP + EnvCons.COMN_SP_FILE + "index.html");
        }
        catch (Exception ex)
        {
            Logger.getLogger(NormPanel.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    /**
     * 软件首页事件处理
     */
    private void mi_HomePage_Handle(java.awt.event.ActionEvent evt)
    {
        try
        {
            DeskUtil.browse(SysCons.HOMEPAGE);
        }
        catch (Exception ex)
        {
            Logger.getLogger(NormPanel.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    /**
     * 隐藏窗口事件处理
     */
    private void mi_HideForm_Handle(java.awt.event.ActionEvent evt)
    {
        C3010000.hideAllFrame();
    }

    /**
     * 显示窗口事件处理
     * 
     * @param evt
     */
    private void mi_ShowForm_Handle(java.awt.event.ActionEvent evt)
    {
        C3010000.showAllFrame();
    }

    /**
     * 系统退出事件处理
     */
    private void mi_RmpsExit_Handle(java.awt.event.ActionEvent evt)
    {
        Rmps.exit(0, true, true);
    }
    // ////////////////////////////////////////////////////////////////////////
    // 公共方法区域
    // ////////////////////////////////////////////////////////////////////////
    // ////////////////////////////////////////////////////////////////////////
    // 界面组件区域
    // ////////////////////////////////////////////////////////////////////////
    /** 系统退出 */
    private java.awt.MenuItem mi_RmpsExit;
    /** 帮助菜单 */
    private java.awt.MenuItem mi_HelpTops;
    /** 软件首页 */
    private java.awt.MenuItem mi_HomePage;
    /** 隐藏窗口 */
    private java.awt.MenuItem mi_HideForm;
    /** 显示窗口 */
    private java.awt.MenuItem mi_ShowForm;
    /** 显示窗口 */
    private java.awt.MenuItem mi_Seperator;
    /** serialVersionUID */
    private static final long serialVersionUID = 1773860656392217122L;
}
