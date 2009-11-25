/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3010000.v;

import java.awt.Dimension;
import java.io.File;
import java.net.URL;
import java.sql.SQLException;
import java.util.EventObject;
import java.util.List;
import java.util.Properties;

import rmp.Rmps;
import rmp.amon.rmps.AF010000.AF010000;
import rmp.bean.FilesFilter;
import rmp.bean.K1SV2S;
import rmp.face.WBackCall;
import rmp.io.db.DBAccess;
import rmp.prp.aide.DC0008;
import rmp.prp.aide.P3010000.P3010000;
import rmp.prp.aide.extparse.d.DA0008;
import rmp.util.BeanUtil;
import rmp.util.EnvUtil;
import rmp.util.LogUtil;
import rmp.util.MesgUtil;
import rmp.util.RmpsUtil;
import rmp.util.StringUtil;
import cons.CfgCons;
import cons.EnvCons;
import cons.SysCons;
import cons.prp.aide.P3010000.ConstUI;
import cons.prp.aide.P3010000.LangRes;
import cons.prp.aide.extparse.DB0008;
import com.amonsoft.skin.ISkin;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 系统菜单
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class SysMenu implements WBackCall
{
    /** 父应用引用 */
    // private P3010000 me_MainSoft;
    /**
     * 
     */
    public SysMenu(P3010000 owner)
    {
        // this.me_MainSoft = owner;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    public boolean wInit()
    {
        // 弹出式菜单
        pm_MainMenu = new javax.swing.JPopupMenu();

        // 使用帮助
        mi_HelpTops = createMenuItem(LangRes.MENU_TEXT_HELPTOPS, LangRes.MENU_TIPS_HELPTOPS, true);
        mi_HelpTops.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_HelpTops_Handler(evt);
            }
        });
        pm_MainMenu.add(mi_HelpTops);

        // 软件首页
        mi_HomePage = createMenuItem(LangRes.MENU_TEXT_HOMEPAGE, LangRes.MENU_TIPS_HOMEPAGE, true);
        mi_HomePage.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_HomePage_Handler(evt);
            }
        });
        pm_MainMenu.add(mi_HomePage);

        // 分隔符
        pm_MainMenu.addSeparator();

        // 运行命令
        mi_ICommand = createMenuItem(LangRes.MENU_TEXT_ICOMMAND, LangRes.MENU_TIPS_ICOMMAND, true);
        mi_ICommand.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_ICommand_Handler(evt);
            }
        });
        pm_MainMenu.add(mi_ICommand);

        // 在线搜索级联菜单
        initOlSearch();

        // 数据编辑级联菜单
        initDataEdit();

        // 视图模式级联菜单
        initViewForm();

        // 数据导出级联菜单
        initDataExpt();

        // 数据安全级联菜单
        initDataSafe();

        // 皮肤列表级联菜单
        initSkinList();

        // 界面语言级联菜单
        initLangList();

        // 用户回馈
        initFeedBack();

        // Amon在线
        initAmonSite();

        // 分隔符
        pm_MainMenu.addSeparator();

        // 关于软件
        mi_SoftInfo = createMenuItem(LangRes.MENU_TEXT_SOFTINFO, LangRes.MENU_TIPS_SOFTINFO, true);
        mi_SoftInfo.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_SoftInfo_Handler(evt);
            }
        });
        pm_MainMenu.add(mi_SoftInfo);

        // 系统退出
        mi_HideForm = createMenuItem(LangRes.MENU_TEXT_HIDEFORM, LangRes.MENU_TIPS_HIDEFORM, true);
        mi_HideForm.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_HideForm_Handler(evt);
            }
        });
        pm_MainMenu.add(mi_HideForm);

        // 菜单大小设置
        Dimension size = mi_HelpTops.getPreferredSize();
        if (size.width <= 120)
        {
            size.width = 120;
        }
        mi_HelpTops.setPreferredSize(size);

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
        // 语言列表选择事件处理
        if (object instanceof K1SV2S)
        {
            K1SV2S kvItem = (K1SV2S) object;
            langItem_Handler(kvItem.getK(), kvItem.getV1(), true);
        }
    }

    /**
     * @return
     */
    public static SysMenu getInstance(P3010000 owner)
    {
        if (rm_RmpsMenu == null)
        {
            rm_RmpsMenu = new SysMenu(owner);
            rm_RmpsMenu.wInit();
        }
        return rm_RmpsMenu;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 对外接口区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @return
     */
    public javax.swing.JPopupMenu getPopupMenu()
    {
        return pm_MainMenu;
    }

    /**
     * @param menu
     * @return
     */
    public javax.swing.JPopupMenu add(javax.swing.JMenu menu)
    {
        pm_MainMenu.insert(menu, pm_MainMenu.getComponentIndex(sp_End));
        return pm_MainMenu;
    }

    /**
     * @param menuItem
     * @return
     */
    public javax.swing.JPopupMenu add(javax.swing.JMenuItem menuItem)
    {
        pm_MainMenu.insert(menuItem, pm_MainMenu.getComponentIndex(sp_End));
        return pm_MainMenu;
    }

    /**
     * @param menu
     * @param index
     * @return
     */
    public javax.swing.JPopupMenu insert(javax.swing.JMenu menu, int index)
    {
        pm_MainMenu.insert(menu, pm_MainMenu.getComponentIndex(sp_Stt) + index);
        return pm_MainMenu;
    }

    /**
     * @param menuItem
     * @param index
     * @return
     */
    public javax.swing.JPopupMenu insert(javax.swing.JMenuItem menuItem, int index)
    {
        pm_MainMenu.insert(menuItem, pm_MainMenu.getComponentIndex(sp_Stt) + index);
        return pm_MainMenu;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 菜单初始化区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 在线搜索级联菜单
     * 
     * @return
     */
    private boolean initOlSearch()
    {
        // 在线搜索子菜单
        mu_OlSearch = createMenu(LangRes.MENU_TEXT_OLSEARCH, LangRes.MENU_TIPS_OLSEARCH, true);
        pm_MainMenu.add(mu_OlSearch);

        DBAccess dba = new DBAccess();

        try
        {
            if (!dba.wInit())
            {
                return false;
            }

            // 事件侦听器
            java.awt.event.ActionListener al = new java.awt.event.ActionListener()
            {
                public void actionPerformed(java.awt.event.ActionEvent evt)
                {
                    mi_SrchItem_Handler(evt);
                }
            };

            List<K1SV2S> linkList = DA0008.initOlSearchList(dba);
            javax.swing.JMenuItem menuItem;
            K1SV2S kvItem;
            for (int i = 0, j = linkList.size(); i < j; i += 1)
            {
                kvItem = linkList.get(i);

                menuItem = createMenuItem(kvItem.getV1(), kvItem.getV2(), false);
                // 保存链接地址
                menuItem.putClientProperty(ConstUI.PROP_MENU_SRCHURLS, kvItem.getK());
                // 注册事件侦听器
                menuItem.addActionListener(al);

                mu_OlSearch.add(menuItem);
            }

            return true;
        }
        catch (Exception exp)
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
     * 数据编辑级联菜单
     * 
     * @return
     */
    private boolean initDataEdit()
    {
        // 数据编辑子菜单
        mu_DataEdit = createMenu(LangRes.MENU_TEXT_DATAEDIT, LangRes.MENU_TIPS_DATAEDIT, true);
        pm_MainMenu.add(mu_DataEdit);

        // 数据新增（向导）
        mi_InstStep = createMenuItem(LangRes.MENU_TEXT_INSTSTEP, LangRes.MENU_TIPS_INSTSTEP, true);
        mi_InstStep.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_InstStep_Handler(evt);
            }
        });
        mi_InstStep.setVisible(false);
        mu_DataEdit.add(mi_InstStep);

        // 数据更新（向导）
        mi_UpdtStep = createMenuItem(LangRes.MENU_TEXT_UPDTSTEP, LangRes.MENU_TIPS_UPDTSTEP, true);
        mi_UpdtStep.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_UpdtStep_Handler(evt);
            }
        });
        mi_UpdtStep.setVisible(false);
        mu_DataEdit.add(mi_UpdtStep);

        // 分隔符
        // mu_DataEdit.addSeparator();

        // 数据新增（快速）
        mi_InstUser = createMenuItem(LangRes.MENU_TEXT_INSTUSER, LangRes.MENU_TIPS_INSTUSER, true);
        mi_InstUser.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_InstUser_Handler(evt);
            }
        });
        mu_DataEdit.add(mi_InstUser);

        // 数据更新（快速）
        mi_UpdtUser = createMenuItem(LangRes.MENU_TEXT_UPDTUSER, LangRes.MENU_TIPS_UPDTUSER, true);
        mi_UpdtUser.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_UpdtUser_Handler(evt);
            }
        });
        mu_DataEdit.add(mi_UpdtUser);

        // 分隔符
        mu_DataEdit.addSeparator();

        // 数据删除
        mi_DataDelt = createMenuItem(LangRes.MENU_TEXT_DATADELT, LangRes.MENU_TIPS_DATADELT, true);
        mi_DataDelt.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_DataDelt_Handler(evt);
            }
        });
        mu_DataEdit.add(mi_DataDelt);

        return true;
    }

    /**
     * 数据导出级联菜单
     * 
     * @return
     */
    private boolean initDataExpt()
    {
        // 数据导出子菜单
        mu_DataExpt = createMenu(LangRes.MENU_TEXT_DATAEXPT, LangRes.MENU_TIPS_DATAEXPT, true);
        pm_MainMenu.add(mu_DataExpt);

        // 目录文件判断
        File exptFile = new File(EnvCons.FOLDER0_TPLT + EnvCons.PATH_P3010000);
        if (exptFile == null || !exptFile.exists() || !exptFile.isDirectory())
        {
            return true;
        }

        // 获取皮肤列表
        File[] exptList = exptFile.listFiles();
        if (exptList == null || exptList.length < 1)
        {
            return true;
        }

        // 事件侦听器
        java.awt.event.ActionListener al = new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_DataExpt_Handler(evt);
            }
        };

        javax.swing.JMenuItem menuItem;
        String skinName;
        for (int i = 0, j = exptList.length; i < j; i += 1)
        {
            if (!exptList[i].isFile())
            {
                continue;
            }
            // 获取文件夹名称
            skinName = exptList[i].getName();

            // 皮肤菜单项
            menuItem = createMenuItem(skinName, skinName, false);
            // 文件路径标记设置
            menuItem.putClientProperty(ConstUI.PROP_MENU_DATAEXPT, exptList[i].getPath());
            // 注册事件侦听器
            menuItem.addActionListener(al);

            mu_DataExpt.add(menuItem);
        }

        return true;
    }

    /**
     * 数据安全级联菜单
     * 
     * @return
     */
    private boolean initDataSafe()
    {
        // 数据安全子菜单
        mu_DataSafe = createMenu(LangRes.MENU_TEXT_DATASAFE, LangRes.MENU_TIPS_DATASAFE, true);
        pm_MainMenu.add(mu_DataSafe);

        // 数据备份
        mi_DbBackup = createMenuItem(LangRes.MENU_TEXT_DBBACKUP, LangRes.MENU_TIPS_DBBACKUP, true);
        mi_DbBackup.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_DbBackup_Handler(evt);
            }
        });
        mu_DataSafe.add(mi_DbBackup);

        // 数据恢复
        mi_DbPickup = createMenuItem(LangRes.MENU_TEXT_DBPICKUP, LangRes.MENU_TIPS_DBPICKUP, true);
        mi_DbPickup.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_DbPickup_Handler(evt);
            }
        });
        mu_DataSafe.add(mi_DbPickup);

        return true;
    }

    /**
     * 界面语言级联菜单
     * 
     * @return
     */
    private boolean initLangList()
    {
        // 界面语言子菜单
        mu_LangList = createMenu(LangRes.MENU_TEXT_LANGLIST, LangRes.MENU_TIPS_LANGLIST, true);
        pm_MainMenu.add(mu_LangList);

        // 创建数据库操作对象
        DBAccess dba = new DBAccess();
        try
        {
            // 启动事务
            if (!dba.wInit())
            {
                return false;
            }

            // 事件侦听器
            java.awt.event.ActionListener al = new java.awt.event.ActionListener()
            {
                public void actionPerformed(java.awt.event.ActionEvent evt)
                {
                    mi_LangItem_Handler(evt);
                }
            };

            // 语言数据查寻
            List<K1SV2S> langList = DA0008.initLanguageList(dba, DB0008.DBCD_LANG_COMM);
            javax.swing.ButtonGroup bg = new javax.swing.ButtonGroup();

            javax.swing.JCheckBoxMenuItem menuItem;
            K1SV2S kvItem;
            for (int i = 0, j = langList.size(); i < j; i += 1)
            {
                kvItem = langList.get(i);

                menuItem = createCheckBoxMenuItem(kvItem.getV1(), kvItem.getV2(), false);
                // 选中状态设置
                menuItem.setSelected(RmpsUtil.getUserInfo().getCfg(CfgCons.CFG_LANG_ID).equals(kvItem.getK()));
                // 保存语言标记
                menuItem.putClientProperty(ConstUI.PROP_HASH_LANG, kvItem.getK());
                // 注册事件侦听器
                menuItem.addActionListener(al);

                mu_LangList.add(menuItem);
                bg.add(menuItem);
            }
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
        finally
        {
            // 提交事务
            dba.closeConnection();
        }

        // 分隔线
        mu_LangList.addSeparator();

        // 所有语言
        mi_LangAll = createMenuItem(LangRes.MENU_TEXT_LANG_ALL, LangRes.MENU_TIPS_LANG_ALL, true);
        mi_LangAll.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_LangAll_Handler(evt);
            }
        });
        mu_LangList.add(mi_LangAll);

        // 分隔线
        mu_LangList.addSeparator();

        // 语言资源编辑器
        mi_LangEdit = createMenuItem(LangRes.MENU_TEXT_LANGEDIT, LangRes.MENU_TIPS_LANGEDIT, true);
        mi_LangEdit.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_LangEdit_Handler(evt);
            }
        });
        mu_LangList.add(mi_LangEdit);

        return true;
    }

    /**
     * 皮肤列表初始化
     * 
     * @return
     */
    private boolean initSkinList()
    {
        // 界面皮肤子菜单
        mu_SkinList = createMenu(LangRes.MENU_TEXT_SKINLIST, LangRes.MENU_TIPS_SKINLIST, true);
        pm_MainMenu.add(mu_SkinList);

        // 界面皮肤事件处理器
        java.awt.event.ActionListener al = new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_SkinItem_Handler(evt);
            }
        };

        javax.swing.ButtonGroup bg = new javax.swing.ButtonGroup();
        javax.swing.JCheckBoxMenuItem menuItem;
        // 默认风格
        String[] txt =
        {
            LangRes.MENU_TEXT_SKINSYSTEM, LangRes.MENU_TEXT_SKINMETAL, LangRes.MENU_TEXT_SKINMOTIF,
            LangRes.MENU_TEXT_SKINWINXP, LangRes.MENU_TEXT_SKINWINME
        };
        String[] tip =
        {
            LangRes.MENU_TIPS_SKINSYSTEM, LangRes.MENU_TIPS_SKINMETAL, LangRes.MENU_TIPS_SKINMOTIF,
            LangRes.MENU_TIPS_SKINWINXP, LangRes.MENU_TIPS_SKINWINME
        };
        String[] key =
        {
            ISkin.LF_TYPE_SYSTEM, ISkin.LF_NAME_METAL, ISkin.LF_NAME_MOTIF, ISkin.LF_NAME_WINDOWSXP,
            ISkin.LF_NAME_WINDOWSME
        };
        for (int i = 0, j = txt.length; i < j; i += 1)
        {
            menuItem = createCheckBoxMenuItem(txt[i], tip[i], true);
            menuItem.putClientProperty(ConstUI.PROP_MENU_SKINNAME, key[i]);
            menuItem.addActionListener(al);
            mu_SkinList.add(menuItem);
            bg.add(menuItem);
        }

        mu_SkinList.addSeparator();

        // 文件目录判断
        File skinFile = new File(EnvCons.FOLDER0_SKIN);
        if (skinFile == null || !skinFile.exists() || !skinFile.isDirectory())
        {
            return true;
        }

        // 文件过滤器设置
        FilesFilter f = new FilesFilter();
        // 仅显示文本夹
        f.setFilesModel(FilesFilter.FOLDER_ONLY);

        // 获取皮肤列表
        File[] skinList = skinFile.listFiles(f);

        String skinName;
        for (int i = 0, j = skinList.length; i < j; i += 1)
        {
            // 获取文件夹名称
            skinName = skinList[i].getName();

            // 皮肤菜单项
            menuItem = createCheckBoxMenuItem(skinName, skinName, false);
            // 选中状态设置
            menuItem.setSelected(RmpsUtil.getUserInfo().getCfg(CfgCons.CFG_LNF_NAME).equals(skinName));
            // 皮肤标记设置
            menuItem.putClientProperty(ConstUI.PROP_MENU_SKINNAME, ISkin.LF_TYPE_SYNTH);
            // 注册事件侦听器
            menuItem.addActionListener(al);

            mu_SkinList.add(menuItem);
            bg.add(menuItem);
        }

        return true;
    }

    /**
     * 视图模式级联菜单初始化
     * 
     * @return
     */
    private boolean initViewForm()
    {
        // 视图模式子菜单
        mu_ViewForm = createMenu(LangRes.MENU_TEXT_VIEWFORM, LangRes.MENU_TIPS_VIEWFORM, true);
        pm_MainMenu.add(mu_ViewForm);

        // 事件侦听器
        java.awt.event.ActionListener al = new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_ViewForm_Handler(evt);
            }
        };

        // 菜单显示
        String[] txt =
        {
            LangRes.MENU_TEXT_DESPFORM, LangRes.MENU_TEXT_MIMEFORM, LangRes.MENU_TEXT_CORPFORM,
            LangRes.MENU_TEXT_SOFTFORM, LangRes.MENU_TEXT_FILEFORM, LangRes.MENU_TEXT_ASOCFORM,
            LangRes.MENU_TEXT_IDIOFORM
        };
        String[] tip =
        {
            LangRes.MENU_TIPS_DESPFORM, LangRes.MENU_TIPS_MIMEFORM, LangRes.MENU_TIPS_CORPFORM,
            LangRes.MENU_TIPS_SOFTFORM, LangRes.MENU_TIPS_FILEFORM, LangRes.MENU_TIPS_ASOCFORM,
            LangRes.MENU_TIPS_IDIOFORM
        };
        String[] key =
        {
            ConstUI.PROP_ITEM_DESP, ConstUI.PROP_ITEM_MIME, ConstUI.PROP_ITEM_CORP, ConstUI.PROP_ITEM_SOFT,
            ConstUI.PROP_ITEM_FILE, ConstUI.PROP_ITEM_ASOC, ConstUI.PROP_ITEM_IDIO
        };

        javax.swing.JMenuItem menuItem;
        for (int i = 0, j = txt.length; i < j; i += 1)
        {
            menuItem = createMenuItem(txt[i], tip[i], true);
            menuItem.addActionListener(al);
            menuItem.putClientProperty(ConstUI.PROP_MENU_VIEWFORM, key[i]);
            mu_ViewForm.add(menuItem);
        }
        return true;
    }

    /**
     * 用户回馈
     * 
     * @return
     */
    private boolean initFeedBack()
    {
        mu_FeedBack = createMenu(LangRes.MENU_TEXT_HELPAMON, LangRes.MENU_TIPS_HELPAMON, true);
        pm_MainMenu.add(mu_FeedBack);

        // 我有Bug
        mi_HaveBugs = createMenuItem(LangRes.MENU_TEXT_HAVEBUGS, LangRes.MENU_TIPS_HAVEBUGS, true);
        mi_HaveBugs.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_HaveBugs_Handler(evt);
            }
        });
        mu_FeedBack.add(mi_HaveBugs);

        // 我有建议
        mi_HaveIdea = createMenuItem(LangRes.MENU_TEXT_HAVEIDEA, LangRes.MENU_TIPS_HAVEIDEA, true);
        mi_HaveIdea.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_HaveIdea_Handler(evt);
            }
        });
        mu_FeedBack.add(mi_HaveIdea);

        return true;
    }

    /**
     * Amon在线
     */
    private void initAmonSite()
    {
        mu_AmonSite = createMenu(LangRes.MENU_TEXT_AMONSOFT, LangRes.MENU_TIPS_AMONSOFT, true);
        pm_MainMenu.add(mu_AmonSite);

        // 检测更新
        mi_ChckUpdt = createMenuItem(LangRes.MENU_TEXT_CHCKUPDT, LangRes.MENU_TIPS_CHCKUPDT, true);
        mi_ChckUpdt.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_ChckUpdt_Handler(evt);
            }
        });
        mu_AmonSite.add(mi_ChckUpdt);

        // 分隔符
        mu_AmonSite.addSeparator();

        // 人气支持
        mi_PickRank = createMenuItem(LangRes.MENU_TEXT_PICKRANK, LangRes.MENU_TIPS_PICKRANK, true);
        mi_PickRank.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_PickRank_Handler(evt);
            }
        });
        mu_AmonSite.add(mi_PickRank);

        // 分隔符
        mu_AmonSite.addSeparator();

        // 在线查询
        mi_ExtOnline = createMenuItem(LangRes.MENU_TEXT_EXTONLINE, LangRes.MENU_TIPS_EXTONLINE, true);
        mi_ExtOnline.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_ExtOnline_Handler(evt);
            }
        });
        mu_AmonSite.add(mi_ExtOnline);

        // 后缀提交
        mi_ExtSubmit = createMenuItem(LangRes.MENU_TEXT_EXTSUBMIT, LangRes.MENU_TIPS_EXTSUBMIT, true);
        mi_ExtSubmit.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_ExtSubmit_Handler(evt);
            }
        });
        mu_AmonSite.add(mi_ExtSubmit);
    }

    // ////////////////////////////////////////////////////////////////////////
    // 事件处理区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 检测更新
     * 
     * @param evt
     */
    private void mi_ChckUpdt_Handler(java.awt.event.ActionEvent evt)
    {
        Properties updtProp = new Properties();

        // 属性读取
        try
        {
            URL uri = new URL(SysCons.UPDTFILE);
            java.io.InputStream is = uri.openStream();
            updtProp.loadFromXML(is);
            is.close();
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            MesgUtil.showMessageDialog(P3010000.getForm(), P3010000.getMesg(LangRes.MESG_OTHR_0006));
            return;
        }

        // 版本比较
        String nVer = updtProp.getProperty(EnvCons.EXTPARSE_SOFTEDIT, "");
        if (ConstUI.VER_CODE.compareTo(nVer) < 0)
        {
            MesgUtil.showMessageDialog(P3010000.getForm(), P3010000.getMesg(LangRes.MESG_OTHR_0008));
        }
        else
        {
            MesgUtil.showMessageDialog(P3010000.getForm(), P3010000.getMesg(LangRes.MESG_OTHR_0007));
        }
    }

    /**
     * 数据删除事件处理
     */
    private void mi_DataDelt_Handler(java.awt.event.ActionEvent evt)
    {
        // UserData userMeta = Util.getMainPanel().getUserData(true);
        // if (userMeta != null)
        // {
        // Util.getMainPanel().metaDelete(userMeta.getExtsName(),
        // userMeta.getSoftHash());
        // }
    }

    /**
     * 在线查询
     * 
     * @param evt
     */
    private void mi_ExtOnline_Handler(java.awt.event.ActionEvent evt)
    {
        MesgUtil.showMessageDialog(P3010000.getForm(), "此功能正在完善中，敬请关注。。。");
    }

    /**
     * 后缀提交
     * 
     * @param evt
     */
    private void mi_ExtSubmit_Handler(java.awt.event.ActionEvent evt)
    {
        MesgUtil.showMessageDialog(P3010000.getForm(), "此功能正在完善中，敬请关注。。。");
    }

    /**
     * 数据新增事件处理
     */
    private void mi_InstUser_Handler(java.awt.event.ActionEvent evt)
    {
        // Util.showStepForm();
    }

    /**
     * @param evt
     */
    private void mi_InstStep_Handler(java.awt.event.ActionEvent evt)
    {
        // Util.showStepForm();
    }

    /**
     * 数据更新事件处理
     */
    private void mi_UpdtUser_Handler(java.awt.event.ActionEvent evt)
    {
        // Util.showExtsForm();
    }

    /**
     * @param evt
     */
    private void mi_UpdtStep_Handler(java.awt.event.ActionEvent evt)
    {
        // Util.showExtsForm();
    }

    /**
     * 数据备份菜单项事件处理
     */
    private void mi_DbBackup_Handler(java.awt.event.ActionEvent evt)
    {
        // 数据备份确认
        if (0 == MesgUtil.showConfirmDialog(P3010000.getForm(), P3010000.getMesg(LangRes.MESG_SAFE_0001)))
        {
            try
            {
                EnvUtil.shutdownDataBase();
                EnvUtil.backupDatabase();
            }
            catch (Exception exp)
            {
                LogUtil.exception(exp);
            }
        }
    }

    /**
     * 数据恢复菜单项事件处理
     */
    private void mi_DbPickup_Handler(java.awt.event.ActionEvent evt)
    {
        // 数据备份确认
        if (0 == MesgUtil.showConfirmDialog(P3010000.getForm(), P3010000.getMesg(LangRes.MESG_SAFE_0002)))
        {
            try
            {
                EnvUtil.shutdownDataBase();
                EnvUtil.pickupDatabase();
            }
            catch (Exception exp)
            {
                LogUtil.exception(exp);
            }
        }
    }

    /**
     * 合并备选软件窗口事件处理
     */
    private void mi_ViewForm_Handler(java.awt.event.ActionEvent evt)
    {
        // // 事件源判断
        // Object obj = evt.getSource();
        // if (obj == null)
        // {
        // return;
        // }
        //
        // // 面板名称
        // javax.swing.JMenuItem mi = (javax.swing.JMenuItem)obj;
        // String formName =
        // (String)mi.getClientProperty(ConstUI.PROP_VIEWFORM);
        //
        // if (ConstUI.PROP_DESPINFO.equals(formName))
        // {
        // Util.showDespForm();
        // return;
        // }
        // if (ConstUI.PROP_MIMEINFO.equals(formName))
        // {
        // Util.showMimeForm();
        // return;
        // }
        // if (ConstUI.PROP_CORPINFO.equals(formName))
        // {
        // Util.showCorpForm();
        // return;
        // }
        // if (ConstUI.PROP_SOFTINFO.equals(formName))
        // {
        // Util.showSoftForm();
        // return;
        // }
        // if (ConstUI.PROP_FILEINFO.equals(formName))
        // {
        // Util.showFileForm();
        // return;
        // }
        // if (ConstUI.PROP_ASOCINFO.equals(formName))
        // {
        // Util.showAsocForm();
        // }
        // if (ConstUI.PROP_IDIOINFO.equals(formName))
        // {
        // Util.showIdioForm();
        // }
    }

    /**
     * 后缀解析数据导出
     */
    private void mi_DataExpt_Handler(java.awt.event.ActionEvent evt)
    {
        // // 事件源判断
        // Object obj = evt.getSource();
        // if (obj == null)
        // {
        // return;
        // }
        //
        // // 用户输入数据信息取得
        // BaseData baseMeta = Util.getMainPanel().getBaseMeta();
        // if (baseMeta == null)
        // {
        // return;
        // }
        //
        // // 模板文件路径取得
        // javax.swing.JMenuItem mi = (javax.swing.JMenuItem)obj;
        // File tpltFile = new
        // File((String)mi.getClientProperty(ConstUI.PROP_DATAEXPT));
        // if (!tpltFile.exists())
        // {
        // return;
        // }
        //
        // // 导出文件路径取得
        // File exptFile = FileUtil.showSingleFileSave(P3010000.getForm(), true,
        // null);
        // if (exptFile == null)
        // {
        // return;
        // }
        // exptFile = new File(exptFile, baseMeta.getExtsName().substring(1) +
        // FileUtil.getFileExt(tpltFile));
        //
        // // 数据导出
        // try
        // {
        // DX0008.export(exptFile, tpltFile, baseMeta,
        // RmpsUtil.getUserInfo().getCfg(CfgCons.CFG_LANG_ID), true);
        // }
        // catch(IOException e)
        // {
        // e.printStackTrace();
        // }
    }

    /**
     * 我有Bug菜单项事件处理
     * 
     * @param evt
     */
    private void mi_HaveBugs_Handler(java.awt.event.ActionEvent evt)
    {
        EnvUtil.mail(SysCons.MAILADDR + "?subject=我发现了一个Bug&body=Amon您好：");
    }

    /**
     * 我有建议菜单项事件处理
     * 
     * @param evt
     */
    private void mi_HaveIdea_Handler(java.awt.event.ActionEvent evt)
    {
        EnvUtil.mail(SysCons.MAILADDR + "?subject=我想提一个小建议&body=Amon您好：");
    }

    /**
     * 使用帮助菜单项事件处理
     */
    private void mi_HelpTops_Handler(java.awt.event.ActionEvent evt)
    {
        boolean opened = EnvUtil.open(EnvCons.FOLDER0_HELP + EnvCons.COMN_SP_FILE + "index.html");

        if (!opened)
        {
            String mesg = "";
            MesgUtil.showMessageDialog(P3010000.getForm(), mesg);
        }
    }

    /**
     * 关闭窗口事件处理
     */
    private void mi_HideForm_Handler(java.awt.event.ActionEvent evt)
    {
        Rmps.exit(0, true, true);
    }

    /**
     * 软件首页事件处理
     */
    private void mi_HomePage_Handler(java.awt.event.ActionEvent evt)
    {
        boolean ok = EnvUtil.browse(ConstUI.URL_SOFT);
        if (!ok)
        {
            String mesg = "";
            MesgUtil.showMessageDialog(P3010000.getForm(), mesg);
        }
    }

    /**
     * 运行命令事件处理
     */
    private void mi_ICommand_Handler(java.awt.event.ActionEvent evt)
    {
    }

    /**
     * 查看所有语言事件处理
     */
    private void mi_LangAll_Handler(java.awt.event.ActionEvent evt)
    {
        // 实例化数据库操作对象
        DBAccess dba = new DBAccess();

        List<K1SV2S> langList = null;
        try
        {
            // 连接数据库
            if (!dba.wInit())
            {
                return;
            }

            // 语言列表数据查询
            langList = DA0008.initLanguageList(dba, DB0008.DBCD_LANG_REST);
        }
        catch (SQLException exp)
        {
            LogUtil.exception(exp);
            String msg = StringUtil.format(LangRes.MESG_OTHR_0004, LangRes.MESG_INIT_0010);
            MesgUtil.showMessageDialog(P3010000.getForm(), msg);
        }
        finally
        {
            dba.closeConnection();
        }

        // 显示所有语言列表
        if (langList != null)
        {
            // WListForm.showDialog(P3010000.getForm(), LangRes.TITLE_CORPFORM,
            // langList, this);
        }
    }

    /**
     * 语言资源编码菜单项事件处理
     */
    private void mi_LangEdit_Handler(java.awt.event.ActionEvent evt)
    {
        AF010000 langEdit = new AF010000();
        langEdit.wInit();
        langEdit.wShowView(P3010000.VIEW_NORM);
    }

    /**
     * 语言菜单项事件处理
     * 
     * @param langHash
     * @param langName
     * @param chg2Use
     */
    private void mi_LangItem_Handler(java.awt.event.ActionEvent evt)
    {
        // 事件源判断
        Object obj = evt.getSource();
        if (obj == null)
        {
            return;
        }

        // 语言信息取得
        javax.swing.JMenuItem mi = (javax.swing.JMenuItem) obj;
        String langName = mi.getText();
        String langHash = (String) mi.getClientProperty(ConstUI.PROP_HASH_LANG);

        langItem_Handler(langHash, langName, false);
    }

    /**
     * 人气支持
     * 
     * @param evt
     */
    private void mi_PickRank_Handler(java.awt.event.ActionEvent evt)
    {
        MesgUtil.showMessageDialog(P3010000.getForm(), "此功能正在完善中，敬请关注。。。");
    }

    /**
     * 用户皮肤配置信息更新
     * 
     * @param skinName
     */
    private void mi_SkinItem_Handler(java.awt.event.ActionEvent evt)
    {
        // 事件源判断
        Object obj = evt.getSource();
        if (obj == null || !(obj instanceof javax.swing.JCheckBoxMenuItem))
        {
            return;
        }

        // 界面风格名称
        javax.swing.JCheckBoxMenuItem cmi = (javax.swing.JCheckBoxMenuItem) obj;
        String skinName = (String) cmi.getClientProperty(ConstUI.PROP_MENU_SKINNAME);

        // 界面风格改变
        K1SV2S kvItem = new K1SV2S(skinName, "", "");
        if (ISkin.LF_TYPE_SYNTH.equals(skinName))
        {
            kvItem.setV1(cmi.getText());
        }
        Rmps.initLnF(kvItem.getK(), kvItem.getV1());
        javax.swing.SwingUtilities.updateComponentTreeUI(P3010000.getForm());
        javax.swing.SwingUtilities.updateComponentTreeUI(pm_MainMenu);
        // P3010000.getForm().pack();

        // 创建数据库操作对象
        DBAccess dba = new DBAccess();
        try
        {
            // 启动事务
            if (!dba.wInit())
            {
                return;
            }

            // 更新用户界面语言信息
            DC0008.updateBaseMeta(dba, DB0008.DBCD_BASE_UILOOK, kvItem.getK(), kvItem.getV1());
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            return;
        }
        finally
        {
            dba.closeConnection();
        }

        // 提示用户重新启动应用程序
        MesgUtil.showMessageDialog(P3010000.getForm(), P3010000.getMesg(LangRes.MESG_OTHR_0001));
    }

    /**
     * 关于软件事件处理
     */
    private void mi_SoftInfo_Handler(java.awt.event.ActionEvent evt)
    {
    }

    /**
     * 在线搜索菜单项事件处理
     */
    private void mi_SrchItem_Handler(java.awt.event.ActionEvent evt)
    {
        // // 事件源判断
        // Object obj = evt.getSource();
        // if (obj == null)
        // {
        // return;
        // }
        //
        // // 用户数据取得
        // UserData userMeta = Util.getMainPanel().getUserData(false);
        // if (userMeta == null)
        // {
        // return;
        // }
        //
        // // 浏览路径
        // javax.swing.JMenuItem mi = (javax.swing.JMenuItem)obj;
        // String urls = (String)mi.getClientProperty(ConstUI.PROP_SRCHURLS);
        // urls = urls.replace("{0}", userMeta.getExtsName());
        // EnvUtil.browse(urls);
    }

    /**
     * @param langHash
     * @param langName
     * @param chg2Use
     */
    private void langItem_Handler(String langHash, String langName, boolean chg2Use)
    {
    }

    /**
     * @param menuText
     * @param menuTips
     * @return
     */
    private javax.swing.JCheckBoxMenuItem createCheckBoxMenuItem(String menuText, String menuTips, boolean isHash)
    {
        javax.swing.JCheckBoxMenuItem item = new javax.swing.JCheckBoxMenuItem();
        BeanUtil.setWText(item, menuText);
        BeanUtil.setWTips(item, menuTips);

        Dimension size = item.getPreferredSize();
        size.width = 120;
        item.setPreferredSize(size);

        return item;
    }

    /**
     * @param menuText
     * @param menuTips
     * @return
     */
    private javax.swing.JMenu createMenu(String menuText, String menuTips, boolean isHash)
    {
        javax.swing.JMenu menu = new javax.swing.JMenu();
        BeanUtil.setWText(menu, menuText);
        BeanUtil.setWTips(menu, menuTips);
        return menu;
    }

    /**
     * @param menuText
     * @param menuTips
     * @return
     */
    private javax.swing.JMenuItem createMenuItem(String menuText, String menuTips, boolean isHash)
    {
        javax.swing.JMenuItem item = new javax.swing.JMenuItem();
        BeanUtil.setWText(item, menuText);
        BeanUtil.setWTips(item, menuTips);

        Dimension size = item.getPreferredSize();
        size.width = 120;
        item.setPreferredSize(size);

        return item;
    }
    // ////////////////////////////////////////////////////////////////////////
    // 成员变量区域
    // ////////////////////////////////////////////////////////////////////////
    /** 系统菜单 */
    private static SysMenu rm_RmpsMenu;
    // ----------------------------------------------------
    // 系统子菜单
    // ----------------------------------------------------
    /** 数据编辑 */
    private javax.swing.JMenu mu_DataEdit;
    /** 数据导出 */
    private javax.swing.JMenu mu_DataExpt;
    /** 数据安全 */
    private javax.swing.JMenu mu_DataSafe;
    /** 语言列表 */
    private javax.swing.JMenu mu_LangList;
    /** 在线搜索 */
    private javax.swing.JMenu mu_OlSearch;
    /** 皮肤列表 */
    private javax.swing.JMenu mu_SkinList;
    /** 视图模式 */
    private javax.swing.JMenu mu_ViewForm;
    /** 用户回馈 */
    private javax.swing.JMenu mu_FeedBack;
    /** Amon在线 */
    private javax.swing.JMenu mu_AmonSite;
    // ----------------------------------------------------
    // 系统菜单项
    // ----------------------------------------------------
    /** 菜单项：我有 Bug */
    private javax.swing.JMenuItem mi_HaveBugs;
    /** 菜单项：我有建议 */
    private javax.swing.JMenuItem mi_HaveIdea;
    /** 菜单项：更新检测 */
    private javax.swing.JMenuItem mi_ChckUpdt;
    /** 数据删除 */
    private javax.swing.JMenuItem mi_DataDelt;
    /** 数据新增（快速） */
    private javax.swing.JMenuItem mi_InstUser;
    /** 数据更新（快速） */
    private javax.swing.JMenuItem mi_UpdtUser;
    /** 数据新增（向导） */
    private javax.swing.JMenuItem mi_InstStep;
    /** 数据更新（向导） */
    private javax.swing.JMenuItem mi_UpdtStep;
    /** 数据备份 */
    private javax.swing.JMenuItem mi_DbBackup;
    /** 数据恢复 */
    private javax.swing.JMenuItem mi_DbPickup;
    /** 菜单项：在线查询 */
    private javax.swing.JMenuItem mi_ExtOnline;
    /** 菜单项：后缀提交 */
    private javax.swing.JMenuItem mi_ExtSubmit;
    /** 菜单项：使用帮助 */
    private javax.swing.JMenuItem mi_HelpTops;
    /** 菜单项：关闭窗口 */
    private javax.swing.JMenuItem mi_HideForm;
    /** 菜单项：软件首页 */
    private javax.swing.JMenuItem mi_HomePage;
    /** 运行命令 */
    private javax.swing.JMenuItem mi_ICommand;
    /** 所有语言 */
    private javax.swing.JMenuItem mi_LangAll;
    /** 语言资源编辑器 */
    private javax.swing.JMenuItem mi_LangEdit;
    /** 菜单项：人气支持 */
    private javax.swing.JMenuItem mi_PickRank;
    /** 菜单项：关于软件 */
    private javax.swing.JMenuItem mi_SoftInfo;
    /** 系统弹出菜单 */
    private javax.swing.JPopupMenu pm_MainMenu;
    /** 用户菜单区域起始分隔线 */
    private javax.swing.JSeparator sp_Stt;
    /** 用户菜单区域结束分隔线 */
    private javax.swing.JSeparator sp_End;
}
