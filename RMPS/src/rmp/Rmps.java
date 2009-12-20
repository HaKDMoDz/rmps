/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp;

import com.amonsoft.cons.ConsSys;
import java.io.File;
import java.io.IOException;

import javax.swing.JFrame;
import javax.swing.UIManager;
import javax.swing.plaf.synth.SynthLookAndFeel;

import rmp.comn.user.UserInfo;
import rmp.util.EnvUtil;
import com.amonsoft.util.LogUtil;
import rmp.util.MesgUtil;
import rmp.util.StringUtil;
import cons.CfgCons;
import cons.EnvCons;
import cons.ui.LangRes;
import com.amonsoft.skin.ISkin;
import com.amonsoft.util.DeskUtil;
import com.amonsoft.util.LangUtil;
import cons.SysCons;
import java.util.HashMap;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * RMPS系统入口
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public final class Rmps
{
    /** 当前登录用户信息 */
    private static UserInfo user;
    private static LangUtil lang;
    private static HashMap<Integer, java.awt.image.BufferedImage> logo;

    /**
     * @param args
     */
    public static void main(String[] args)
    {
        // 1、 启动系统日志
        LogUtil.wInit();

        // 2、 运行环境检测
        if (!checkJre())
        {
            System.exit(0);
            return;
        }

        // 3、运行环境加载
        if (!initEnv())
        {
            System.exit(0);
            return;
        }

        // 4、 用户配置加载
        if (!initCfg())
        {
            System.exit(0);
            return;
        }

        // 5、 应用界面风格
        if (!initLnF())
        {
            System.exit(0);
            return;
        }

        // 5、显示主窗口 启动应用程序
        if (!startApp())
        {
            System.exit(0);
            return;
        }
    }

    /**
     * 
     * @param size
     * @return
     */
    public static java.awt.image.BufferedImage getLogo(int size)
    {
        if (Rmps.logo == null)
        {
            Rmps.logo = new HashMap<Integer, java.awt.image.BufferedImage>();
        }

        java.awt.image.BufferedImage img = new java.awt.image.BufferedImage(size, size, java.awt.image.BufferedImage.TYPE_INT_ARGB);
        return img;
    }

    public static void setLogo(java.awt.image.BufferedImage logo)
    {
        if (Rmps.logo == null)
        {
            Rmps.logo = new HashMap<Integer, java.awt.image.BufferedImage>();
        }
        Rmps.logo.put(logo.getWidth(), logo);
    }

    /**
     * @return the userInfo
     */
    public static UserInfo getUser()
    {
        return user;
    }

    public static void setUser(UserInfo user)
    {
        Rmps.user = user;
    }

    /**
     * 系统退出
     * 
     * @param status
     */
    public static void exit(int status, boolean saveCfg, boolean backup)
    {
        LogUtil.log("系统退出：开始..");

        if (saveCfg)
        {
            LogUtil.log("系统退出：保存用户配置");
            user.saveCfg();
        }

        LogUtil.log("系统退出：关闭数据连接");
//        EnvUtil.shutdownDataBase();

        if (backup)
        {
            try
            {
                EnvUtil.backupDatabase();
            }
            catch (Exception exp)
            {
                LogUtil.exception(exp);
            }
        }

        LogUtil.log("系统退出：完毕！\r\n--------------------------------------------------\r\n\r\n");
        LogUtil.wExit();

        System.exit(status);
    }

    /**
     * 检测JRE版本是否满足最低运行需求
     * 
     * @return 是否为合适的运行环境，true为满足最低运行需求
     */
    public static boolean checkJre()
    {
        // JRE环境符合运行需求的情况
        String jreVer = System.getProperty(EnvCons.JAVA_RE_VERSION);
        if (EnvCons.COMN_JREVERSION.compareTo(jreVer) < 0)
        {
            // 当前运行环境JRE版本不低于指定的需要版本
            LogUtil.log("系统启动：当前可用JRE版本 － " + jreVer);
            return true;
        }

        // JRE环境不符合运行需求的情况
        MesgUtil.showMessageDialog(null, LangRes.MESG_INIT_0001);
        return false;
    }

    /**
     * 环境初始化
     * @return
     */
    public static boolean initEnv()
    {
        try
        {
            java.io.File file = new java.io.File(EnvCons.FOLDER0_LANG, "rmps.properties");
            if (file.exists())
            {
                lang = LangUtil.initLang(file.getPath());
                return true;
            }
            return false;
        }
        catch (IOException exp)
        {
            LogUtil.exception(exp);
            return false;
        }
    }

    /**
     * 加载用户配置数据信息
     * 
     * @return 用户配置是否加载成功：true加载成功
     */
    public static boolean initCfg()
    {
        LogUtil.log("系统启动：用户配置数据信息加载！");

        user = new UserInfo("Amon", "amon");
        user.wInit();
        user.loadCfg(EnvCons.COMN_PATH_HOME, ConsSys.MODE_APPLICATION);

        return true;
    }

    /**
     * 加载用户当前界面方案
     * @return 界面方案是否加载成功：true加载成功
     */
    public static boolean initLnF()
    {
        String type = user.getCfg(CfgCons.CFG_LNF_TYPE);//界面风格类别
        String name = user.getCfg(CfgCons.CFG_LNF_NAME);//界面风格名称
        if (type == null)
        {
            type = ISkin.LF_TYPE_SYSTEM;
        }
        type = type.trim();

        // 使用当前系统界面样式
        if (type.length() < 1 || ISkin.LF_TYPE_SYSTEM.equalsIgnoreCase(type))
        {
            name = UIManager.getSystemLookAndFeelClassName();
        }

        LogUtil.log("系统启动：当前使用界面风格信息 (" + type + ", " + name + ")");
        user.setUserSkin(type, name);

        try
        {
            // ISkin 样式
            if (ISkin.LF_TYPE_SYNTH.equalsIgnoreCase(type))
            {
                JFrame.setDefaultLookAndFeelDecorated(true);

                SynthLookAndFeel slaf = new SynthLookAndFeel();
                String lfPath = EnvCons.FOLDER0_SKIN + EnvCons.COMN_SP_FILE + name + EnvCons.COMN_SP_FILE + "skin.xml";
                slaf.load(new File(lfPath).toURI().toURL());
                UIManager.setLookAndFeel(slaf);
            }
            // Metal 样式
            else if (ISkin.LF_NAME_METAL.equalsIgnoreCase(name))
            {
                JFrame.setDefaultLookAndFeelDecorated(true);

                UIManager.setLookAndFeel(ISkin.LF_NAME_METAL);
            }
            // 其它界面风格
            else
            {
                if (System.getProperty(EnvCons.OS_NAME).toLowerCase().indexOf("linux") >= 0)
                {
                    UIManager.installLookAndFeel("GTK+", ISkin.LF_NAME_GTK);
                }
                JFrame.setDefaultLookAndFeelDecorated(false);

                UIManager.setLookAndFeel(name);
            }

            return true;
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            String msg = StringUtil.format(LangRes.MESG_INIT_0006, LangRes.MESG_INIT_0000);
            MesgUtil.showMessageDialog(null, msg);
        }
        return true;
    }

    /**
     * 启动应用程序
     * 
     * @return
     */
    public static boolean startApp()
    {
        LogUtil.log("系统启动：应用程序启动！");

        Tray tray = new Tray();
        tray.initView();
        tray.initLang();
        tray.initData();

        //Irps.main(null);
        return true;
    }

    /**
     * 
     */
    static class Tray
    {
        /** 托盘图标对象 */
        private java.awt.TrayIcon ti_TrayIcon;
        /** 托盘弹出菜单 */
        private java.awt.PopupMenu pm_PopsMenu;
        /** PRPS菜单 */
        private java.awt.Menu mi_PrpsForm;
        /** ERPS菜单 */
        private java.awt.Menu mi_ErpsForm;
        /** WRPS菜单 */
        private java.awt.Menu mi_WrpsForm;
        /** MRPS菜单 */
        private java.awt.Menu mi_MrpsForm;
        /** IRPS菜单 */
        private java.awt.Menu mi_IrpsForm;
        /** 系统退出 */
        private java.awt.MenuItem mi_RmpsExit;
        /** 帮助菜单 */
        private java.awt.MenuItem mi_HelpTops;
        /** 软件首页 */
        private java.awt.MenuItem mi_HomePage;
        /** 显示窗口 */
        private java.awt.MenuItem mi_Seperator;

        public Tray()
        {
        }

        public void initView()
        {
            // 系统菜单
            pm_PopsMenu = new java.awt.PopupMenu();

            // 系统帮助菜单
            mi_HelpTops = new java.awt.MenuItem();
            mi_HelpTops.addActionListener(new java.awt.event.ActionListener()
            {
                @Override
                public void actionPerformed(java.awt.event.ActionEvent evt)
                {
                    mi_HelpTops_Handler(evt);
                }
            });
            pm_PopsMenu.add(mi_HelpTops);

            // 软件首页
            mi_HomePage = new java.awt.MenuItem();
            mi_HomePage.addActionListener(new java.awt.event.ActionListener()
            {
                @Override
                public void actionPerformed(java.awt.event.ActionEvent evt)
                {
                    mi_HomePage_Handle(evt);
                }
            });
            pm_PopsMenu.add(mi_HomePage);

            // 分隔符
            pm_PopsMenu.addSeparator();

            // PRPS菜单
            mi_PrpsForm = new java.awt.Menu();
            pm_PopsMenu.add(mi_PrpsForm);

            // ERPS菜单
            mi_ErpsForm = new java.awt.Menu();
            pm_PopsMenu.add(mi_ErpsForm);

            // WRPS菜单
            mi_WrpsForm = new java.awt.Menu();
            pm_PopsMenu.add(mi_WrpsForm);

            // MRPS菜单
            mi_MrpsForm = new java.awt.Menu();
            pm_PopsMenu.add(mi_MrpsForm);

            // IRPS菜单
            mi_IrpsForm = new java.awt.Menu();
            pm_PopsMenu.add(mi_IrpsForm);

            // 分隔符
            mi_Seperator = new java.awt.MenuItem("-");
            pm_PopsMenu.add(mi_Seperator);

            // 系统退出菜单
            mi_RmpsExit = new java.awt.MenuItem();
            mi_RmpsExit.addActionListener(new java.awt.event.ActionListener()
            {
                @Override
                public void actionPerformed(java.awt.event.ActionEvent evt)
                {
                    mi_RmpsExit_Handle(evt);
                }
            });
            pm_PopsMenu.add(mi_RmpsExit);

            if (java.awt.SystemTray.isSupported())
            {
                // 获取系统托盘的引用
                java.awt.SystemTray iconTray = java.awt.SystemTray.getSystemTray();

                ti_TrayIcon = new java.awt.TrayIcon(getLogo(16), "Test", pm_PopsMenu);
                ti_TrayIcon.addMouseListener(new java.awt.event.MouseAdapter()
                {
                    @Override
                    public void mouseClicked(java.awt.event.MouseEvent evt)
                    {
                        ti_TrayIcon_Handler(evt);
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
                    return;
                }
            }
            else
            {
            }
        }

        public void initLang()
        {
            try
            {
                java.io.File file = new java.io.File(EnvCons.FOLDER0_LANG, "rmps.properties");
                if (file.exists())
                {
                    LangUtil.initLang(EnvCons.FOLDER0_LANG + "rmps.properties");
                }
            }
            catch (IOException exp)
            {
                LogUtil.exception(exp);
            }
        }

        public void initData()
        {
        }

        /**
         * 窗口显示隐藏事件处理
         *
         * @param evt
         */
        private void ti_TrayIcon_Handler(java.awt.event.MouseEvent evt)
        {
        }

        /**
         * 使用帮助事件处理
         */
        private void mi_HelpTops_Handler(java.awt.event.ActionEvent evt)
        {
            try
            {
                DeskUtil.open(EnvCons.FOLDER0_HELP + EnvCons.COMN_SP_FILE + "index.html");
            }
            catch (Exception exp)
            {
                LogUtil.exception(exp);
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
            catch (Exception exp)
            {
                LogUtil.exception(exp);
            }
        }

        /**
         * 系统退出事件处理
         */
        private void mi_RmpsExit_Handle(java.awt.event.ActionEvent evt)
        {
            exit(0, true, true);
        }
    }
}
