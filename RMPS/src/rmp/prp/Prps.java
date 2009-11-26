/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp;

import com.amonsoft.bean.WForm;
import java.awt.Dimension;
import java.awt.Toolkit;
import java.awt.event.ActionEvent;
import java.io.File;
import java.net.URL;
import java.net.URLClassLoader;
import java.util.HashMap;
import java.util.Properties;

import javax.swing.ButtonGroup;
import javax.swing.ImageIcon;
import javax.swing.JScrollPane;
import javax.swing.SwingUtilities;

import rmp.Rmps;
import rmp.bean.FilesFilter;
import rmp.comn.info.C1010000.C1010000;
import rmp.comn.tray.C3010000.C3010000;
import com.amonsoft.rmps.prp.ISoft;
import rmp.prp.m.WExeItem;
import rmp.prp.m.WNetItem;
import rmp.prp.t.Util;
import rmp.prp.v.ExePanel;
import rmp.prp.v.NetPanel;
import rmp.prp.v.StdPanel;
import rmp.prp.v.SubMenu;
import rmp.util.BeanUtil;
import rmp.util.CheckUtil;
import rmp.util.EnvUtil;
import rmp.util.LogUtil;
import rmp.util.MesgUtil;
import rmp.util.RmpsUtil;
import cons.CfgCons;
import cons.EnvCons;
import cons.SysCons;
import cons.prp.ConstUI;
import cons.prp.LangRes;
import cons.prp.Plugins;
import com.amonsoft.skin.ISkin;
import javax.swing.WindowConstants;
import com.amonsoft.util.LangUtil;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * PRPS
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class Prps extends WForm
{
    /** 软件 */
    private static ISoft currSoft;
    /** 软件语言资源 */
    private static Properties langRes;
    /** 关于软件 */
    private static C1010000 softInfo;
    /**
     * 语言资源
     */
    private LangUtil langUtil;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 
     */
    public Prps()
    {
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面初始化区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 界面布局初始化
     */
    public void initView()
    {
        mb_RmpsMenu = new javax.swing.JMenuBar();
        pl_HeadPane = new javax.swing.JPanel();
        pl_FootPane = new javax.swing.JPanel();
        tp_BodyPane = new javax.swing.JTabbedPane();

        initFileView();
        initToolView();
        initHelpView();

        setJMenuBar(mb_RmpsMenu);

        tp_BodyPane.setTabPlacement(javax.swing.JTabbedPane.LEFT);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        javax.swing.GroupLayout.ParallelGroup hpg = layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING);
        hpg.addComponent(pl_HeadPane, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE);
        hpg.addComponent(pl_FootPane, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE);
        hpg.addComponent(tp_BodyPane, javax.swing.GroupLayout.DEFAULT_SIZE, 230, Short.MAX_VALUE);
        layout.setHorizontalGroup(hpg);

        javax.swing.GroupLayout.SequentialGroup vsg = layout.createSequentialGroup();
        vsg.addComponent(pl_HeadPane, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE);
        vsg.addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED);
        vsg.addComponent(tp_BodyPane, javax.swing.GroupLayout.DEFAULT_SIZE, 237, Short.MAX_VALUE);
        vsg.addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED);
        vsg.addComponent(pl_FootPane, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE);
        layout.setVerticalGroup(vsg);
    }

    /**
     * 界面语言初始化
     */
    public void initLang()
    {
        langUtil = LangUtil.initLang("10000000");
        initFileLang();
        initToolLang();
        initHelpLang();
    }

    /**
     * 界面数据初始化
     */
    public void initData()
    {
        // 窗口属性设置
        setAlwaysOnTop(CfgCons.DEF_TRUE.equalsIgnoreCase(RmpsUtil.getUserInfo().getCfg(CfgCons.CFG_WND_EVERTOP)));
        Dimension f = getSize();
        Dimension s = Toolkit.getDefaultToolkit().getScreenSize();
        setLocation(s.width - f.width - 30, 30);
        setIconImage(BeanUtil.getLogoImage());
        setTitle(langUtil.getMesg(LangRes.TITLE_FRAME, "Amon个人助理"));
        setDefaultCloseOperation(WindowConstants.HIDE_ON_CLOSE);
        setVisible(true);

        Thread t = new Thread()
        {
            @Override
            public void run()
            {
                initPlug_Ins();
            }
        };
        t.start();
    }

    /**
     * 文件菜单初始化
     */
    private void initFileView()
    {
        mu_FileMenu = new javax.swing.JMenu();
        mb_RmpsMenu.add(mu_FileMenu);

        // 窗口隐藏
        mi_HideItem = new javax.swing.JMenuItem();
        mi_HideItem.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent evt)
            {
                mi_HideItem_Handler(evt);
            }
        });
        mi_HideItem.setAccelerator(javax.swing.KeyStroke.getKeyStroke(java.awt.event.KeyEvent.VK_E, java.awt.event.InputEvent.CTRL_MASK));
        mu_FileMenu.add(mi_HideItem);

        // 系统退出
        mi_ExitItem = new javax.swing.JMenuItem();
        mi_ExitItem.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent evt)
            {
                mi_ExitItem_Handler(evt);
            }
        });
        mi_ExitItem.setAccelerator(javax.swing.KeyStroke.getKeyStroke(java.awt.event.KeyEvent.VK_Q, java.awt.event.InputEvent.CTRL_MASK));
        mu_FileMenu.add(mi_ExitItem);
    }

    /**
     * 工具菜单初始化
     */
    private void initToolView()
    {
        mu_ToolMenu = new javax.swing.JMenu();
        mb_RmpsMenu.add(mu_ToolMenu);

        // 窗口属性
        SubMenu sm = new SubMenu(this, mu_ToolMenu);
        sm.wInit();

        // 分隔符
        mu_ToolMenu.addSeparator();

        // 系统风格
        mi_LfSystem = new javax.swing.JCheckBoxMenuItem();
        mi_LfSystem.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_LfSystem_Handler(evt);
            }
        });
        if (ISkin.LF_TYPE_SYSTEM.equals(RmpsUtil.getUserInfo().getCfg(CfgCons.CFG_LNF_TYPE)))
        {
            mi_LfSystem.setSelected(true);
        }
        mu_ToolMenu.add(mi_LfSystem);

        // 界面风格
        mu_BasicGui = new javax.swing.JMenu();
        mu_ToolMenu.add(mu_BasicGui);

        // Synth风格
        mu_SynthGui = new javax.swing.JMenu();
        mu_ToolMenu.add(mu_SynthGui);

        mu_ToolMenu.addSeparator();

        mi_LgSystem = new javax.swing.JCheckBoxMenuItem();
        mi_LgSystem.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_LgSystem_Handler(evt);
            }
        });
        if (ISkin.LF_TYPE_SYSTEM.equals(RmpsUtil.getUserInfo().getCfg(CfgCons.CFG_LNF_TYPE)))
        {
            mi_LfSystem.setSelected(true);
        }
        mu_ToolMenu.add(mi_LgSystem);

        // 界面语言
        mu_LangMenu = new javax.swing.JMenu();
        mu_ToolMenu.add(mu_LangMenu);

        // 界面风格
        initAbleSkin();

        // 界面语言
        initAbleLang();
    }

    /**
     * 帮助菜单初始化
     */
    private void initHelpView()
    {
        mu_HelpMenu = new javax.swing.JMenu();
        mu_HelpMenu.setText("帮助(H)");
        mu_HelpMenu.setMnemonic('H');
        mb_RmpsMenu.add(mu_HelpMenu);

        // 帮助菜单
        mi_HelpItem = new javax.swing.JMenuItem();
        mi_HelpItem.setText("帮助(H)");
        mi_HelpItem.setMnemonic('H');
        mi_HelpItem.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent evt)
            {
                mi_HelpItem_Handler(evt);
            }
        });
        mi_HelpItem.setAccelerator(javax.swing.KeyStroke.getKeyStroke(java.awt.event.KeyEvent.VK_F1, 0));
        mu_HelpMenu.add(mi_HelpItem);

        // 分隔符
        mu_HelpMenu.addSeparator();

        // 软件首页
        mi_HomePage = new javax.swing.JMenuItem();
        mi_HomePage.setText("网站首页(W)");
        mi_HomePage.setMnemonic('W');
        mi_HomePage.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_HomePage_Handler(evt);
            }
        });
        mi_HomePage.setAccelerator(javax.swing.KeyStroke.getKeyStroke(java.awt.event.KeyEvent.VK_HOME,
                java.awt.event.InputEvent.CTRL_MASK));
        mu_HelpMenu.add(mi_HomePage);

        // 我有建议
        mi_IdeaItem = new javax.swing.JMenuItem();
        mi_IdeaItem.setText("我有建议(B)");
        mi_IdeaItem.setMnemonic('B');
        mi_IdeaItem.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_IdeaItem_Handler(evt);
            }
        });
        mi_IdeaItem.setAccelerator(javax.swing.KeyStroke.getKeyStroke(java.awt.event.KeyEvent.VK_F12, 0));
        mu_HelpMenu.add(mi_IdeaItem);

        // 检测更新
        mi_ChckUpdt = new javax.swing.JMenuItem();
        mi_ChckUpdt.setText("检测更新(U)");
        mi_ChckUpdt.setMnemonic('U');
        mi_ChckUpdt.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_ChckUpdt_Handler(evt);
            }
        });
        mi_ChckUpdt.setAccelerator(javax.swing.KeyStroke.getKeyStroke(java.awt.event.KeyEvent.VK_F5, 0));
        mu_HelpMenu.add(mi_ChckUpdt);

        // 分隔符
        mu_HelpMenu.addSeparator();

        // 关于菜单
        mi_InfoItem = new javax.swing.JMenuItem();
        mi_InfoItem.setText("关于软件(A)");
        mi_InfoItem.setMnemonic('A');
        mi_InfoItem.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent evt)
            {
                mi_InfoItem_Handler(evt);
            }
        });
        mi_InfoItem.setAccelerator(javax.swing.KeyStroke.getKeyStroke(java.awt.event.KeyEvent.VK_F2, 0));
        mu_HelpMenu.add(mi_InfoItem);
    }
    // ////////////////////////////////////////////////////////////////////////
    // 多语言显示区域
    // ////////////////////////////////////////////////////////////////////////

    /**
     * 文件菜单
     */
    private void initFileLang()
    {
        // 文件菜单
        BeanUtil.setWText(mu_FileMenu, langUtil.getMesg(LangRes.MENU_TEXT_FILEMENU, ""));
        BeanUtil.setWTips(mu_FileMenu, langUtil.getMesg(LangRes.MENU_TIPS_FILEMENU, ""));

        // 系统退出
        BeanUtil.setWText(mi_HideItem, langUtil.getMesg(LangRes.MENU_TEXT_HIDEITEM, ""));
        BeanUtil.setWTips(mi_HideItem, langUtil.getMesg(LangRes.MENU_TIPS_HIDEITEM, ""));

        // 系统退出
        BeanUtil.setWText(mi_ExitItem, langUtil.getMesg(LangRes.MENU_TEXT_EXITITEM, ""));
        BeanUtil.setWTips(mi_ExitItem, langUtil.getMesg(LangRes.MENU_TIPS_EXITITEM, ""));
    }

    /**
     * 工具菜单
     */
    private void initToolLang()
    {
        // 工具菜单
        BeanUtil.setWText(mu_ToolMenu, langUtil.getMesg(LangRes.MENU_TEXT_TOOLMENU, ""));
        BeanUtil.setWTips(mu_ToolMenu, langUtil.getMesg(LangRes.MENU_TIPS_TOOLMENU, ""));

        // 系统风格
        BeanUtil.setWText(mi_LfSystem, langUtil.getMesg(LangRes.MENU_TEXT_LFSYSTEM, ""));
        BeanUtil.setWTips(mi_LfSystem, langUtil.getMesg(LangRes.MENU_TIPS_LFSYSTEM, ""));

        // 界面风格
        BeanUtil.setWText(mu_BasicGui, langUtil.getMesg(LangRes.MENU_TEXT_BASICGUI, ""));
        BeanUtil.setWTips(mu_BasicGui, langUtil.getMesg(LangRes.MENU_TIPS_BASICGUI, ""));

        // 界面风格
        BeanUtil.setWText(mu_SynthGui, langUtil.getMesg(LangRes.MENU_TEXT_SYNTHGUI, ""));
        BeanUtil.setWTips(mu_SynthGui, langUtil.getMesg(LangRes.MENU_TIPS_SYNTHGUI, ""));

        // 系统语言
        BeanUtil.setWText(mi_LgSystem, langUtil.getMesg(LangRes.MENU_TEXT_LGSYSTEM, ""));
        BeanUtil.setWTips(mi_LgSystem, langUtil.getMesg(LangRes.MENU_TIPS_LGSYSTEM, ""));

        // 界面语言
        BeanUtil.setWText(mu_LangMenu, langUtil.getMesg(LangRes.MENU_TEXT_LANGMENU, ""));
        BeanUtil.setWTips(mu_LangMenu, langUtil.getMesg(LangRes.MENU_TIPS_LANGMENU, ""));
    }

    /**
     * 帮助菜单
     */
    private void initHelpLang()
    {
        // 帮助菜单
        BeanUtil.setWText(mu_HelpMenu, langUtil.getMesg(LangRes.MENU_TEXT_HELPMENU, ""));
        BeanUtil.setWTips(mu_HelpMenu, langUtil.getMesg(LangRes.MENU_TIPS_HELPMENU, ""));

        // 使用帮助
        BeanUtil.setWText(mi_HelpItem, langUtil.getMesg(LangRes.MENU_TEXT_HELPITEM, ""));
        BeanUtil.setWTips(mi_HelpItem, langUtil.getMesg(LangRes.MENU_TIPS_HELPITEM, ""));

        // 软件首页
        BeanUtil.setWText(mi_HomePage, langUtil.getMesg(LangRes.MENU_TEXT_HOMEPAGE, ""));
        BeanUtil.setWTips(mi_HomePage, langUtil.getMesg(LangRes.MENU_TIPS_HOMEPAGE, ""));

        // 检测更新
        BeanUtil.setWText(mi_ChckUpdt, langUtil.getMesg(LangRes.MENU_TEXT_CHCKUPDT, ""));
        BeanUtil.setWTips(mi_ChckUpdt, langUtil.getMesg(LangRes.MENU_TIPS_CHCKUPDT, ""));

        // 关于软件
        BeanUtil.setWText(mi_InfoItem, langUtil.getMesg(LangRes.MENU_TEXT_INFOITEM, ""));
        BeanUtil.setWTips(mi_InfoItem, langUtil.getMesg(LangRes.MENU_TIPS_INFOITEM, ""));
    }

    /**
     * 界面语言菜单初始化
     */
    private void initAbleLang()
    {
        ButtonGroup bg = new ButtonGroup();
        bg.add(mi_LgSystem);

        // 语言资源菜单数量
        int num = 0;
        String t = langUtil.getMesg(ConstUI.LANGUAGE_NUM, "");
        if (CheckUtil.isValidate(t))
        {
            try
            {
                num = Integer.parseInt(t);
            }
            catch (NumberFormatException exp)
            {
                LogUtil.exception(exp);
                MesgUtil.showMessageDialog(this, langUtil.getMesg(LangRes.MESG_OTHR_0003, ""));
            }
        }

        // 事件侦听器
        java.awt.event.ActionListener al = new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_LangItem_Handler(evt);
            }
        };

        // 语言资源菜单
        javax.swing.JCheckBoxMenuItem cbItem;
        String langId;
        for (int i = 1; i <= num; i++)
        {
            cbItem = new javax.swing.JCheckBoxMenuItem();
            cbItem.addActionListener(al);
            BeanUtil.setWText(cbItem, langUtil.getMesg(ConstUI.LANGUAGE_TXT + i, ""));
            BeanUtil.setWTips(cbItem, langUtil.getMesg(ConstUI.LANGUAGE_TIP + i, ""));
            langId = langUtil.getMesg(ConstUI.LANGUAGE_KEY + i, "");
            if (RmpsUtil.getUserInfo().getCfg(CfgCons.CFG_LANG_ID).equals(langId))
            {
                cbItem.setSelected(true);
            }
            cbItem.putClientProperty(ConstUI.PROP_LANGNAME, langId);
            mu_LangMenu.add(cbItem);
            bg.add(cbItem);
        }
    }

    /**
     * 界面风格菜单初始化
     */
    private void initAbleSkin()
    {
        // 基本界面风格菜单初始化
        ButtonGroup bg = new ButtonGroup();
        bg.add(mi_LfSystem);

        // 子菜单项目数量
        int num = 0;
        String t = langUtil.getMesg(ConstUI.SKIN_BASIC_NUM, "");
        if (CheckUtil.isValidate(t))
        {
            try
            {
                num = Integer.parseInt(t);
            }
            catch (NumberFormatException exp)
            {
                LogUtil.exception(exp);
                MesgUtil.showMessageDialog(this, langUtil.getMesg(LangRes.MESG_OTHR_0001, ""));
            }
        }

        // 事件侦听器
        java.awt.event.ActionListener al1 = new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_BasicGui_Handler(evt);
            }
        };

        // 基本界面风格菜单初始化
        javax.swing.JCheckBoxMenuItem cbItem;
        String skinName;
        for (int i = 1; i <= num; i++)
        {
            cbItem = new javax.swing.JCheckBoxMenuItem();
            cbItem.addActionListener(al1);
            BeanUtil.setWText(cbItem, langUtil.getMesg(ConstUI.SKIN_BASIC_TXT + i, ""));
            BeanUtil.setWTips(cbItem, langUtil.getMesg(ConstUI.SKIN_BASIC_TIP + i, ""));
            skinName = langUtil.getMesg(ConstUI.SKIN_BASIC_KEY + i, "");
            if (RmpsUtil.getUserInfo().getCfg(CfgCons.CFG_LNF_NAME, "default").equals(skinName))
            {
                cbItem.setSelected(true);
            }
            cbItem.putClientProperty(ConstUI.PROP_SKINNAME, skinName);
            mu_BasicGui.add(cbItem);
            bg.add(cbItem);
        }

        // 定制界面风格菜单初始化
        t = langUtil.getMesg(ConstUI.SKIN_SYNTH_NUM, "");
        if (CheckUtil.isValidate(t))
        {
            try
            {
                num = Integer.parseInt(t);
            }
            catch (NumberFormatException exp)
            {
                LogUtil.exception(exp);
                MesgUtil.showMessageDialog(this, langUtil.getMesg(LangRes.MESG_OTHR_0002, ""));
            }
        }
        java.awt.event.ActionListener al2 = new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_SynthGui_Handler(evt);
            }
        };
        for (int i = 1; i <= num; i += 1)
        {
            cbItem = new javax.swing.JCheckBoxMenuItem();
            cbItem.addActionListener(al2);
            BeanUtil.setWText(cbItem, langUtil.getMesg(ConstUI.SKIN_SYNTH_TXT + i, ""));
            BeanUtil.setWTips(cbItem, langUtil.getMesg(ConstUI.SKIN_SYNTH_TIP + i, ""));
            skinName = langUtil.getMesg(ConstUI.SKIN_SYNTH_KEY + i, "");
            if (RmpsUtil.getUserInfo().getCfg(CfgCons.CFG_LNF_NAME, "default").equals(skinName))
            {
                cbItem.setSelected(true);
            }
            cbItem.putClientProperty(ConstUI.PROP_SKINNAME, skinName);
            mu_SynthGui.add(cbItem);
            bg.add(cbItem);
        }
    }

    /**
     * 插件初始化
     */
    private void initPlug_Ins()
    {
        LogUtil.log("插件加载：开始...");

        // 标准插件面板
        StdPanel std = new StdPanel();
        std.wInit();
        tp_BodyPane.add(new JScrollPane(std));
        tp_BodyPane.setIconAt(0, new ImageIcon(BeanUtil.getLogoImage()));
        tp_BodyPane.setToolTipTextAt(0, langUtil.getMesg(LangRes.TABS_00, ""));

        // 独立插件面板
        ExePanel exe = new ExePanel();
        exe.wInit();
        tp_BodyPane.add(new JScrollPane(exe));
        tp_BodyPane.setIconAt(1, new ImageIcon(BeanUtil.getLogoImage()));
        tp_BodyPane.setToolTipTextAt(1, langUtil.getMesg(LangRes.TABS_01, ""));

        // 网络插件面板
        NetPanel net = new NetPanel();
        net.wInit();
        tp_BodyPane.add(new JScrollPane(net));
        tp_BodyPane.setIconAt(2, new ImageIcon(BeanUtil.getLogoImage()));
        tp_BodyPane.setToolTipTextAt(2, langUtil.getMesg(LangRes.TABS_02, ""));

        // 插件目录对象获取
        File plugin = new File(EnvCons.FOLDER0_PLUS);
        if (plugin == null || !plugin.exists() || !plugin.isDirectory() || !plugin.canRead())
        {
            std.addPlugin(softInfo);
            LogUtil.log("插件加载：插件目录不可访问！");
            return;
        }

        // 获取插件目录列表
        FilesFilter ff = new FilesFilter();
        ff.setFilesModel(FilesFilter.FOLDER_ONLY);
        File[] softList = plugin.listFiles(ff);
        if (softList == null || softList.length < 1)
        {
            std.addPlugin(softInfo);
            LogUtil.log("插件加载：无可用插件！");
            return;
        }

        ff.setFilesModel(FilesFilter.FILE_ONLY);
        ff.setTextInclude(new String[]
                {
                    ".jar"
                });

        try
        {
            LogUtil.log("插件加载：可用插件个数 － " + softList.length);

            File[] fileList;
            LogUtil.log("//////////////////////////////////////////////////////////////////////////////////////");
            for (File currFile : softList)
            {
                LogUtil.log("插件加载：文件路径 － " + currFile.getPath());

                // 创建配置文件对象
                plugin = new File(currFile, EnvCons.COMN_PLUG_FILE);
                // 独立程序
                if (plugin == null || !plugin.exists() || !plugin.isFile() || !plugin.canRead())
                {
                    LogUtil.log("插件加载：配置文件不可访问！");
                    continue;
                }

                HashMap<String, String> plusMap = Util.readPlus(plugin);
                if (plusMap.size() < 1)
                {
                    LogUtil.log("插件加载：配置文件解析失败！");
                    continue;
                }

                // 标准插件
                if (plusMap.get(Plugins.NODE_PLUS) != null)
                {
                    // JAR文件存在性判断
                    fileList = currFile.listFiles(ff);
                    if (fileList == null || fileList.length < 1)
                    {
                        LogUtil.log("插件加载：标准插件加载出错 － 没有合适的.jar文档存在！");
                        continue;
                    }
                    LogUtil.log("插件加载：标准插件.jar文档个数 － " + fileList.length);

                    if ("rmp.prp.aide".equals(plusMap.get(Plugins.NODE_PLUS_PART)) && "rmp.face.WSoft".equals(plusMap.get(Plugins.NODE_PLUS_IMPLEMENTATION)))
                    {
                        // 引用第一个JAR文件
                        File softFile = fileList[0];
                        LogUtil.log("插件加载：标准插件路径 － " + softFile.getPath());

                        LogUtil.log("\t文档路径：" + softFile.toURI().toURL().toString());
                        URLClassLoader urlCl = new URLClassLoader(new URL[]
                                {
                                    softFile.toURI().toURL()
                                });
                        LogUtil.log("\t程序入口：" + plusMap.get(Plugins.NODE_PLUS_PATH));
                        Object obj = urlCl.loadClass(plusMap.get(Plugins.NODE_PLUS_PATH)).newInstance();
                        LogUtil.log("插件加载：插件启动程序初始化成功！");

                        if (obj instanceof ISoft)
                        {
                            ISoft soft = (ISoft) obj;
                            soft.wInit();
                            soft.wSetPlusFolder(currFile.getPath());
                            std.addPlugin(soft);
                            LogUtil.log("插件加载：标准插件加载成功 － " + soft.wGetTitle());
                        }
                    }
                }
                // 独立插件
                if (plusMap.get(Plugins.NODE_EXEC) != null)
                {
                    LogUtil.log("------------------------------------------------------------");
                    LogUtil.log("插件加载：独立插件加载！");

                    WExeItem item = new WExeItem();
                    File itemFile = new File(currFile, plusMap.get(Plugins.NODE_EXEC_ICON));
                    if (itemFile.exists() && itemFile.isFile() && itemFile.canRead())
                    {
                        item.setSoftIcon(new ImageIcon(itemFile.getPath()));
                    }
                    item.setSoftName(plusMap.get(Plugins.NODE_EXEC_NAME));
                    item.setSoftDesp(plusMap.get(Plugins.NODE_EXEC_DESCRIPTION));
                    String exec = currFile.getPath() + EnvCons.COMN_SP_FILE + plusMap.get(Plugins.NODE_EXEC_EXECUTION);
                    item.setSoftPath(exec);
                    item.setSoftArgs(plusMap.get(Plugins.NODE_EXEC_PARAMETER));

                    exe.addPlugin(item);

                    LogUtil.log("插件加载：独立插件加载成功 － " + exec);
                }
                // 网络插件
                if (plusMap.get(Plugins.NODE_JNLP) != null)
                {
                    LogUtil.log("------------------------------------------------------------");
                    LogUtil.log("插件加载：网络插件加载！");

                    WNetItem item = new WNetItem();
                    File itemFile = new File(currFile, plusMap.get(Plugins.NODE_JNLP_ICON));
                    if (itemFile.exists() && itemFile.isFile() && itemFile.canRead())
                    {
                        item.setIcon(new ImageIcon(itemFile.getPath()));
                    }
                    item.setHref(plusMap.get(Plugins.NODE_JNLP_HREF));
                    item.setName(plusMap.get(Plugins.NODE_JNLP_NAME));
                    item.setTitle(plusMap.get(Plugins.NODE_JNLP_TITLE));
                    item.setVendor(plusMap.get(Plugins.NODE_JNLP_VENDOR));
                    item.setDescription(plusMap.get(Plugins.NODE_JNLP_DESCRIPTION));

                    net.addPlugin(item);

                    LogUtil.log("插件加载：独立插件加载成功 － " + item.getHref());
                }
                LogUtil.log("//////////////////////////////////////////////////////////////////////////////////////");
            }
            std.revalidate();
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }

        std.addPlugin(C3010000.getInstance());
        std.addPlugin(softInfo);
    }

    // ////////////////////////////////////////////////////////////////////////
    // 类接口区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @return the currSoft
     */
    public static ISoft getCurrSoft()
    {
        return currSoft;
    }

    /**
     * @param currSoft the currSoft to set
     */
    public static void setCurrSoft(ISoft currSoft)
    {
        Prps.currSoft = currSoft;
    }

    /**
     * 获取关于软件的引用
     * 
     * @return
     */
    public static C1010000 getSoftInfo()
    {
        return softInfo;
    }

    /**
     * 获取关于信息语言资源路径
     * 
     * @return
     */
    private static String getInfoPath()
    {
        StringBuffer sb = new StringBuffer();
        sb.append(EnvCons.PATH_PRP).append(EnvCons.COMN_SP_FILE);
        sb.append(EnvCons.COMN_SOFT_INFO).append(RmpsUtil.getUserInfo().getCfg(CfgCons.CFG_LANG_ID));
        sb.append(SysCons.EXTS_INFO);
        return sb.toString();
    }

    // ////////////////////////////////////////////////////////////////////////
    // 事件处理区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 基本界面风格事件处理
     * 
     * @param evt
     */
    private void mi_BasicGui_Handler(java.awt.event.ActionEvent evt)
    {
        Object obj = evt.getSource();
        if (obj instanceof javax.swing.JCheckBoxMenuItem)
        {
            javax.swing.JCheckBoxMenuItem jbi = (javax.swing.JCheckBoxMenuItem) obj;
            Rmps.initLnF(ISkin.LF_TYPE_BASIC, (String) jbi.getClientProperty(ConstUI.PROP_SKINNAME));
            SwingUtilities.updateComponentTreeUI(this);
        }
    }

    /**
     * 检测更新
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
     * 系统退出菜单
     * 
     * @param evt
     */
    private void mi_ExitItem_Handler(java.awt.event.ActionEvent evt)
    {
        Rmps.exit(0, true, true);
    }

    /**
     * 帮助菜单
     * 
     * @param evt
     */
    private void mi_HelpItem_Handler(java.awt.event.ActionEvent evt)
    {
        boolean opened = EnvUtil.open(EnvCons.FOLDER0_HELP + EnvCons.COMN_SP_FILE + "index.html");

        if (!opened)
        {
            String mesg = "";
            MesgUtil.showMessageDialog(this, mesg);
        }
    }

    /**
     * 窗口隐藏事件处理
     * 
     * @param evt
     */
    private void mi_HideItem_Handler(java.awt.event.ActionEvent evt)
    {
        setVisible(false);
    }

    /**
     * @param evt
     */
    private void mi_HomePage_Handler(java.awt.event.ActionEvent evt)
    {
        Thread t = new Thread()
        {
            public void run()
            {
                homePage();
            }
        };
        t.start();
    }

    /**
     * 我有意见
     * 
     * @param evt
     */
    private void mi_IdeaItem_Handler(java.awt.event.ActionEvent evt)
    {
        boolean b = EnvUtil.mail("mailto:Amon.CT@163.com");
        if (!b)
        {
            MesgUtil.showMessageDialog(this, "系统错误：无法启动您的电子邮件客户端，请您手动启动！");
        }
    }

    /**
     * 关于菜单
     * 
     * @param evt
     */
    private void mi_InfoItem_Handler(java.awt.event.ActionEvent evt)
    {
        C1010000.setInfo(getInfoPath());
        softInfo.wShowView(ISoft.VIEW_MAIN);
    }

    /**
     * 语言菜单项事件处理
     * 
     * @param evt
     */
    private void mi_LangItem_Handler(java.awt.event.ActionEvent evt)
    {
        Object obj = evt.getSource();
        if (obj instanceof javax.swing.JCheckBoxMenuItem)
        {
            javax.swing.JCheckBoxMenuItem jcb = (javax.swing.JCheckBoxMenuItem) obj;
            RmpsUtil.getUserInfo().setCfg(CfgCons.CFG_LANG_ID, (String) jcb.getClientProperty(ConstUI.PROP_LANGNAME));
            langRes = null;
            initFileLang();
        }
    }

    /**
     * 系统风格菜单事件处理
     * 
     * @param evt
     */
    private void mi_LfSystem_Handler(java.awt.event.ActionEvent evt)
    {
        Rmps.initLnF(ISkin.LF_TYPE_SYSTEM, "");
        SwingUtilities.updateComponentTreeUI(this);
    }

    /**
     * 系统语言菜单事件处理
     * 
     * @param evt
     */
    private void mi_LgSystem_Handler(java.awt.event.ActionEvent evt)
    {
        RmpsUtil.getUserInfo().setCfg(CfgCons.CFG_LANG_NAME, "system");
        langRes = null;
        initFileLang();
    }

    /**
     * 定制界面风格事件处理
     * 
     * @param evt
     */
    private void mi_SynthGui_Handler(java.awt.event.ActionEvent evt)
    {
        Object obj = evt.getSource();
        if (obj instanceof javax.swing.JCheckBoxMenuItem)
        {
            javax.swing.JCheckBoxMenuItem jbi = (javax.swing.JCheckBoxMenuItem) obj;
            Rmps.initLnF(ISkin.LF_TYPE_SYNTH, (String) jbi.getClientProperty(ConstUI.PROP_SKINNAME));
            SwingUtilities.updateComponentTreeUI(this);
        }
    }

    /**
     * 检测更新
     */
    private void checkUpdate()
    {
        try
        {
            // pa_PublicAd.wShowModel(AppCons.MODE_MINI + pa_PublicAd.wCode());
            boolean isNew = RmpsUtil.checkUpdate(EnvCons.PRPS_SOFTEDIT, ConstUI.VER_SOFT);
            // pa_PublicAd.wShowModel(AppCons.MODE_NORM + pa_PublicAd.wCode());
            MesgUtil.showMessageDialog(this, langUtil.getMesg(isNew ? LangRes.MESG_OTHR_0008 : LangRes.MESG_OTHR_0007, ""));
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            // pa_PublicAd.wShowModel(AppCons.MODE_NORM + pa_PublicAd.wCode());
            MesgUtil.showMessageDialog(this, langUtil.getMesg(LangRes.MESG_OTHR_0006, ""));
        }
    }

    /**
     * 访问首页
     */
    private void homePage()
    {
        boolean ok = EnvUtil.browse(ConstUI.URL_SOFT);
        if (!ok)
        {
            String mesg = "";
            MesgUtil.showMessageDialog(null, mesg);
        }
    }
    // ////////////////////////////////////////////////////////////////////////
    // 界面变量区域
    // ////////////////////////////////////////////////////////////////////////
    private javax.swing.JMenuBar mb_RmpsMenu;
    private javax.swing.JMenu mu_FileMenu;
    private javax.swing.JMenu mu_HelpMenu;
    private javax.swing.JMenu mu_ToolMenu;
    private javax.swing.JMenu mu_LangMenu;
    private javax.swing.JMenu mu_BasicGui;
    private javax.swing.JMenu mu_SynthGui;
    private javax.swing.JPanel pl_FootPane;
    private javax.swing.JPanel pl_HeadPane;
    private javax.swing.JTabbedPane tp_BodyPane;
    private javax.swing.JMenuItem mi_ExitItem;
    private javax.swing.JMenuItem mi_HelpItem;
    private javax.swing.JMenuItem mi_HideItem;
    private javax.swing.JMenuItem mi_IdeaItem;
    private javax.swing.JMenuItem mi_InfoItem;
    private javax.swing.JMenuItem mi_HomePage;
    private javax.swing.JMenuItem mi_ChckUpdt;
    private javax.swing.JCheckBoxMenuItem mi_LfSystem;
    private javax.swing.JCheckBoxMenuItem mi_LgSystem;
}
