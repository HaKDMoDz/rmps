/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.comn.tray.C3010000;

import java.awt.image.BufferedImage;
import java.util.Properties;

import javax.swing.JFrame;
import javax.swing.JMenu;
import javax.swing.JPanel;

import rmp.Rmps;
import rmp.comn.info.C1010000.C1010000;
import rmp.comn.tray.C3010000.t.Util;
import rmp.comn.tray.C3010000.v.MainPanel;
import rmp.comn.tray.C3010000.v.MiniPanel;
import rmp.comn.tray.C3010000.v.NormPanel;
import rmp.comn.tray.C3010000.v.SubMenu;
import rmp.comn.tray.C3010000.v.TailPanel;
import com.amonsoft.rmps.prp.IPrpPlus;
import rmp.prp.Prps;
import rmp.user.UserInfo;
import rmp.util.BeanUtil;
import rmp.util.EnvUtil;
import rmp.util.FileUtil;
import rmp.util.LogUtil;
import rmp.util.MesgUtil;
import rmp.util.RmpsUtil;
import cons.CfgCons;
import cons.EnvCons;
import cons.SysCons;
import cons.comn.tray.C3010000.ConstUI;
import cons.comn.tray.C3010000.LangRes;
import cons.id.ComnCons;
import com.amonsoft.util.LangUtil;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 系统托盘
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class C3010000 implements IPrpPlus
{
    // ////////////////////////////////////////////////////////////////////////
    // 控制变量区域
    // ////////////////////////////////////////////////////////////////////////
    // ----------------------------------------------------
    // 逻辑控制区域
    // ----------------------------------------------------
    /** 窗口列表管理对象 */
    private static java.util.HashMap<String, JFrame> hm_FormList;
    /** 系统唯一全局变量 */
    private static C3010000 rt_RmpsTray;
    /** 托盘图标对象 */
    private java.awt.TrayIcon ti_TrayIcon;
    /** 托盘弹出菜单 */
    private java.awt.PopupMenu pm_PopsMenu;
    /** 语言资源 */
    private static Properties langRes;
    /** RMPS系统运行目录 */
    private static String baseFolder = "";
    /** 插件程序运行目录 */
    private static String plusFolder = "";
    // ----------------------------------------------------
    // 界面显示区域
    // ----------------------------------------------------
    /** 高级面板 */
    private MainPanel mp_MainPanel;
    /** 迷你面板 */
    private MiniPanel mp_MiniPanel;
    /** 正常面板 */
    private NormPanel np_NormPanel;
    /** 内嵌面板 */
    private TailPanel tp_TailPanel;
    /** 级联菜单 */
    private SubMenu sm_SubMenu;
    private LangUtil langUtil;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 默认构造函数
     */
    private C3010000()
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#wInit()
     */
    @Override
    public boolean wInit()
    {
        // 系统不支持托盘图标时，直接返回
        if (!Util.isTraySupport())
        {
            return true;
        }

        // 获取系统托盘的引用
        java.awt.SystemTray iconTray = java.awt.SystemTray.getSystemTray();

        pm_PopsMenu = new java.awt.PopupMenu();

        // 创建托盘图标对象
        String mesg = RmpsUtil.getUserInfo().getCfg(ConstUI.CFG_USERMESG, LangRes.TRAY_TIPS_ICONTRAY);
        ti_TrayIcon = new java.awt.TrayIcon(wGetIconImage(IPrpPlus.ICON_LOGO0016), mesg, pm_PopsMenu);
        ti_TrayIcon.addMouseListener(new java.awt.event.MouseAdapter()
        {
            @Override
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                if (evt.getClickCount() > 1)
                {
                    ti_TrayIcon_Handler(evt);
                }
            }
        });

        // 添加图标到系统托盘
        try
        {
            iconTray.add(ti_TrayIcon);
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            return false;
        }

        showNorm();

        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wClosing()
     */
    @Override
    public boolean wClosing()
    {
        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wGetBaseFolder()
     */
    @Override
    public String wGetBaseFolder()
    {
        return baseFolder;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wGetDescription()
     */
    @Override
    public String wGetDescription()
    {
        return langUtil.getMesg(ConstUI.RES_DESCRIPTION, "");
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wGetHomepage()
     */
    @Override
    public String wGetHomepage()
    {
        return ConstUI.URL_SOFT;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wCode()
     */
    @Override
    public int wCode()
    {
        return ComnCons.C0010000_I;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wGetIcon()
     */
    @Override
    public BufferedImage wGetIconImage(int type)
    {
        return BeanUtil.getLogoImage();
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wGetName()
     */
    @Override
    public String wGetName()
    {
        return langUtil.getMesg(ConstUI.RES_NAME, "");
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wGetPlusFolder()
     */
    @Override
    public String wGetPlusFolder()
    {
        return plusFolder;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wGetTitle()
     */
    @Override
    public String wGetTitle()
    {
        return langUtil.getMesg(ConstUI.RES_TITLE, "");
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wGetVersion()
     */
    @Override
    public String wGetVersion()
    {
        return ConstUI.VER_CODE;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wShowMenu(javax.swing.JMenu)
     */
    @Override
    public boolean wShowMenu(JMenu menu)
    {
        if (sm_SubMenu == null)
        {
            sm_SubMenu = new SubMenu(this, menu);
            sm_SubMenu.wInit();
        }
        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wShowTail(javax.swing.JPanel)
     */
    @Override
    public boolean wShowTail(JPanel view)
    {
        if (tp_TailPanel == null)
        {
            tp_TailPanel = new TailPanel(this, view);
            tp_TailPanel.wInit();
        }
        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wSetBaseFolder(java.lang.String)
     */
    @Override
    public void wSetBaseFolder(String folder)
    {
        baseFolder = folder;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wSetPlusFolder(java.lang.String)
     */
    @Override
    public void wSetPlusFolder(String folder)
    {
        plusFolder = folder;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wShowHelp()
     */
    @Override
    public void wShowHelp()
    {
        EnvUtil.open(EnvCons.FOLDER0_HELP + EnvCons.COMN_SP_FILE + "index.html");
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wShowInfo()
     */
    @Override
    public void wShowInfo()
    {
        C1010000.setInfo(getInfoPath());
        Prps.getSoftInfo().wShowView(VIEW_NORM);
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wShowView(int)
     */
    @Override
    public javax.swing.JPanel wShowView(int modelIdx)
    {
        switch (modelIdx)
        {
            // 显示内嵌模式
            case VIEW_TAIL:
                return showTail();

            // 显示迷你模式
            case VIEW_MINI:
                return showMini();

            // 显示正常模式
            case VIEW_NORM:
                return showNorm();

            // 显示高级模式
            case VIEW_MAIN:
                return showMain();

            // 显示向导模式
            case VIEW_STEP:
                return showStep();

            default:
                return null;
        }
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wIconified()
     */
    @Override
    public boolean wIconified()
    {
        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wDeiconified()
     */
    @Override
    public boolean wDeiconified()
    {
        return true;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 模块接口区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 注册JFrame对象的引用
     * 
     * @return
     */
    public static void regester(String name, javax.swing.JFrame form)
    {
        if (hm_FormList == null)
        {
            hm_FormList = new java.util.HashMap<String, javax.swing.JFrame>();
        }
        hm_FormList.put(name, form);
    }

    /**
     * 获取指定名称的JFrame对象的引用
     * 
     * @param name
     * @return
     */
    public static javax.swing.JFrame queryRef(String name)
    {
        if (hm_FormList == null)
        {
            return null;
        }
        return hm_FormList.get(name);
    }

    /**
     * 使所有Frame对象窗口不可见
     */
    public static void hideAllFrame()
    {
        if (hm_FormList != null)
        {
            for (String s : hm_FormList.keySet())
            {
                hm_FormList.get(s).setVisible(false);
            }
        }
    }

    /**
     * 使指定名称的Frame对象窗口不可见
     * 
     * @param name
     */
    public static void hideFrame(String name)
    {
        if (hm_FormList != null)
        {
            hm_FormList.get(name).setVisible(false);
        }
    }

    /**
     * 使所有Frame对象窗口可见
     */
    public static void showAllFrame()
    {
        if (hm_FormList != null)
        {
            for (String s : hm_FormList.keySet())
            {
                hm_FormList.get(s).setVisible(true);
            }
        }
    }

    /**
     * 使指定名称的Frame对象窗口可见
     * 
     * @param name
     */
    public static void showFrame(String name)
    {
        if (hm_FormList != null)
        {
            hm_FormList.get(name).setVisible(true);
        }
    }

    /**
     * 显示系统托盘消息提示
     * 
     * @param caption 消息标题
     * @param text 消息内容
     * @param messageType 消息类型：错误、警告、消息、默认等
     */
    public void displayMessage(String caption, String text, java.awt.TrayIcon.MessageType messageType)
    {
        ti_TrayIcon.displayMessage(caption, text, messageType);
    }

    /**
     * 系统托盘快捷提示变更
     * 
     * @param tooltip
     */
    public void changeTooltips(String tooltip)
    {
        ti_TrayIcon.setToolTip(tooltip);
    }

    /**
     * 软件主窗口获取
     * 
     * @return 软件主窗口
     */
    public static C3010000 getInstance()
    {
        if (rt_RmpsTray == null)
        {
            rt_RmpsTray = new C3010000();
            rt_RmpsTray.wInit();
        }
        return rt_RmpsTray;
    }

    /**
     * 语言资源查询
     * 
     * @param mesgId 语言资源索引
     * @return 语言资源内容
     */
    public static String getMesg(String mesgId)
    {
        if (langRes == null)
        {
            langRes = new Properties();

            // 语言资源信息读取
            try
            {
                FileUtil.readLangRes(langRes, EnvCons.PATH_C3010000, EnvCons.COMN_SOFT_LANG);
            }
            catch (Exception exp)
            {
                LogUtil.exception(exp);
                MesgUtil.showMessageDialog(null, exp.getMessage());
            }
        }
        return langRes.getProperty(mesgId);
    }

    /**
     * 语言资源查询
     * 
     * @param mesgId 语言资源索引
     * @param defMesg 默认语言资源
     * @return 语言资源内容
     */
    public static String getMesg(String mesgId, String defMesg)
    {
        String v = getMesg(mesgId);
        return v != null ? v : defMesg;
    }

    /**
     * 获取关于信息语言资源路径
     * 
     * @return
     */
    private static String getInfoPath()
    {
        StringBuffer sb = new StringBuffer();
        sb.append(EnvCons.PATH_CF010000).append(EnvCons.COMN_SP_FILE);
        sb.append(EnvCons.COMN_SOFT_INFO).append(RmpsUtil.getUserInfo().getCfg(CfgCons.CFG_LANG_ID));
        sb.append(SysCons.EXTS_INFO);
        return sb.toString();
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面显示区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 显示高级面板
     */
    private javax.swing.JPanel showMain()
    {
        // 面板实例化
        if (mp_MainPanel == null)
        {
            mp_MainPanel = new MainPanel(this, pm_PopsMenu);
        }
        mp_MainPanel.wInit();
        return null;
    }

    /**
     * 显示迷你面板
     */
    private javax.swing.JPanel showMini()
    {
        // 面板实例化
        if (mp_MiniPanel == null)
        {
            mp_MiniPanel = new MiniPanel(this, pm_PopsMenu);
        }
        mp_MiniPanel.wInit();
        return null;
    }

    /**
     * 显示正常面板
     */
    private javax.swing.JPanel showNorm()
    {
        // 面板实例化
        if (np_NormPanel == null)
        {
            np_NormPanel = new NormPanel(this, pm_PopsMenu);
        }
        np_NormPanel.wInit();
        return null;
    }

    /**
     * @return
     */
    private javax.swing.JPanel showStep()
    {
        return null;
    }

    /**
     * @return
     */
    private javax.swing.JPanel showTail()
    {
        return null;
    }

    /**
     * 窗口显示隐藏事件处理
     * 
     * @param evt
     */
    private void ti_TrayIcon_Handler(java.awt.event.MouseEvent evt)
    {
        javax.swing.JFrame prps = queryRef("prp");
        if (prps != null)
        {
            prps.setVisible(!prps.isVisible());
        }
    }

    // ////////////////////////////////////////////////////////////////////////
    // 系统启动区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 主程序启动入口
     * 
     * @param args
     */
    public static void main(String[] args)
    {
        // 运行目录标记
        baseFolder = EnvCons.COMN_PATH_HOME;

        UserInfo ui = new UserInfo("Amon", "amon");
        ui.wInit();
        RmpsUtil.setUserInfo(ui);

        // 2、 运行环境检测
        if (!Rmps.checkJre())
        {
            System.exit(0);
            return;
        }

        // 3、 用户配置加载
        if (!ui.loadCfg(baseFolder, MODE_APPLICATION))
        {
            System.exit(0);
            return;
        }

        // 4、 应用界面风格
        if (!Rmps.initLnF(ui.getCfg(CfgCons.CFG_LNF_TYPE), ui.getCfg(CfgCons.CFG_LNF_NAME)))
        {
            System.exit(0);
            return;
        }

        // 5、引用应用对象
        C3010000 soft = new C3010000();
        soft.wInit();

        // 6、显示主窗口 启动应用程序
        soft.wShowView(VIEW_NORM);
    }
}
