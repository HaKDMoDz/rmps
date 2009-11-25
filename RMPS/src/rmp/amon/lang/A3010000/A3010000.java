/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.amon.lang.A3010000;

import com.amonsoft.bean.WForm;
import com.amonsoft.rmps.prp.ISoft;

import cons.CfgCons;
import cons.EnvCons;
import cons.SysCons;
import cons.amon.lang.A3010000.ConstUI;
import cons.id.ComnCons;

import java.awt.Container;
import java.awt.image.BufferedImage;
import java.util.Properties;

import javax.swing.JMenu;
import javax.swing.JPanel;

import rmp.amon.lang.A3010000.v.MainPanel;
import rmp.amon.lang.A3010000.v.MiniPanel;
import rmp.amon.lang.A3010000.v.NormPanel;
import rmp.amon.lang.A3010000.v.SubMenu;
import rmp.amon.lang.A3010000.v.TailPanel;
import rmp.comn.info.C1010000.C1010000;


import rmp.Rmps;
import rmp.prp.Prps;
import rmp.user.UserInfo;
import rmp.util.BeanUtil;
import rmp.util.EnvUtil;
import rmp.util.FileUtil;
import rmp.util.LogUtil;
import rmp.util.MesgUtil;
import rmp.util.RmpsUtil;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 语言资源编辑
 * <li>使用说明：</li>
 * <br />
 * 1）、用户配置模板文件：<br />
 * 2）、生成语言资源事项：<br />
 * a)片段标记后两位为00的ID仅用于存放当前片段中语言资源的数量，不能用于语言资源内容存放；<br />
 * </ul>
 * @author Amon
 */
public class A3010000 extends WForm implements ISoft
{
    // ////////////////////////////////////////////////////////////////////////
    // 控制变量区域
    // ////////////////////////////////////////////////////////////////////////
    // ----------------------------------------------------
    // 逻辑控制区域
    // ----------------------------------------------------
    /** 当前运行状态标记：参见AppCons.APP_MODE_*** */
    private static int appMode;
    /** 程序主窗口 */
    private static WForm winForm;
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

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 默认构造函数
     */
    public A3010000()
    {
    }

    // ////////////////////////////////////////////////////////////////////////
    // 接口实现区域
    // ////////////////////////////////////////////////////////////////////////
    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#wInit()
     */
    @Override
    public boolean wInit()
    {
        // 实例化主窗口
        winForm = new WForm();
        winForm.wInit(false);
        winForm.setVisible(true);
//        winForm.setSoft(this);

        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wDispose()
     */
    @Override
    public void wDispose()
    {
        mp_MiniPanel = null;
        np_NormPanel = null;
        mp_MainPanel = null;
        tp_TailPanel = null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetBaseFolder()
     */
    @Override
    public String wGetBaseFolder()
    {
        return baseFolder;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetDescription()
     */
    @Override
    public String wGetDescription()
    {
        return Prps.getMesg(ConstUI.RES_DESCRIPTION);
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetHomepage()
     */
    @Override
    public String wGetHomepage()
    {
        return ConstUI.URL_SOFT;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wCode()
     */
    @Override
    public int wCode()
    {
        return ComnCons.C0FF0000_I;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetIcon()
     */
    @Override
    public BufferedImage wGetIconImage(int type)
    {
        return BeanUtil.getLogoImage();
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetName()
     */
    @Override
    public String wGetName()
    {
        return Prps.getMesg(ConstUI.RES_NAME);
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetPlusFolder()
     */
    @Override
    public String wGetPlusFolder()
    {
        return plusFolder;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetTitle()
     */
    @Override
    public String wGetTitle()
    {
        return Prps.getMesg(ConstUI.RES_TITLE);
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetVersion()
     */
    @Override
    public String wGetVersion()
    {
        return ConstUI.VER_CODE;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wInitMenu(javax.swing.JMenu)
     */
    @Override
    public boolean wInitMenu(JMenu menu)
    {
        if (sm_SubMenu == null)
        {
            sm_SubMenu = new SubMenu(this, menu);
            sm_SubMenu.wInit();
        }
        return false;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wInitTail(javax.swing.JPanel)
     */
    @Override
    public boolean wInitTail(JPanel view)
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
     * @see rmp.face.ISoft#wSetBaseFolder(java.lang.String)
     */
    @Override
    public void wSetBaseFolder(String folder)
    {
        baseFolder = folder;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wSetPlusFolder(java.lang.String)
     */
    @Override
    public void wSetPlusFolder(String folder)
    {
        plusFolder = folder;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wShowHelp()
     */
    @Override
    public void wShowHelp()
    {
        EnvUtil.open(EnvCons.FOLDER0_HELP + EnvCons.COMN_SP_FILE + "index.html");
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wShowInfo()
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
     * @see rmp.face.ISoft#wShowView(int)
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
     * @see rmp.face.ISoft#wStart()
     */
    @Override
    public boolean wStart()
    {
        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wStop()
     */
    @Override
    public boolean wStop()
    {
        return true;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 模块接口区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 程序当前运行方式：Application、Applet、Web Start
     * 
     * @return
     */
    public static int getAppMode()
    {
        return appMode;
    }

    /**
     * 软件主窗口获取
     * 
     * @return 软件主窗口
     */
    public static Container getForm()
    {
        return winForm;
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
                FileUtil.readLangRes(langRes, EnvCons.PATH_A3010000, EnvCons.COMN_SOFT_LANG);
            }
            catch (Exception exp)
            {
                LogUtil.exception(exp);
                MesgUtil.showMessageDialog(getForm(), exp.getMessage());
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
            mp_MainPanel = new MainPanel(this);
            mp_MainPanel.wInit();
        }

        // 小程序处理
        winForm.setContentPane(mp_MainPanel);
        winForm.pack();
        winForm.center(null);
        if (!winForm.isVisible())
        {
            winForm.setVisible(true);
        }
        return mp_MainPanel;
    }

    /**
     * 显示迷你面板
     */
    private javax.swing.JPanel showMini()
    {
        // 面板实例化
        if (mp_MiniPanel == null)
        {
            mp_MiniPanel = new MiniPanel(this);
            mp_MiniPanel.wInit();
        }

        winForm.setContentPane(mp_MiniPanel);
        winForm.pack();
        winForm.center(null);
        if (!winForm.isVisible())
        {
            winForm.setVisible(true);
        }
        return mp_MiniPanel;
    }

    /**
     * 显示正常面板
     */
    private javax.swing.JPanel showNorm()
    {
        // 面板实例化
        if (np_NormPanel == null)
        {
            np_NormPanel = new NormPanel(this);
            np_NormPanel.wInit();
        }

        // 小程序处理
        winForm.setContentPane(np_NormPanel);
        winForm.pack();
        winForm.center(null);
        if (!winForm.isVisible())
        {
            winForm.setVisible(true);
        }
        return np_NormPanel;
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

    // ////////////////////////////////////////////////////////////////////////
    // 系统启动区域
    // ////////////////////////////////////////////////////////////////////////
    /*
     * (non-Javadoc)
     * 
     * @see java.applet.Applet#init()
     */
    @Override
    public void init()
    {
        super.init();

        // 启动模式标记
        appMode = MODE_APPLET;
        // 运行目录标记
        baseFolder = EnvCons.COMN_PATH_JNLP;

        UserInfo ui = new UserInfo("Amon", "amon");
        ui.wInit();
        RmpsUtil.setUserInfo(ui);

        // 显示主窗口 启动应用程序
        wShowView(VIEW_NORM);
    }

    /**
     * 主程序启动入口
     * 
     * @param args
     */
    public static void main(String[] args)
    {
        // 启动模式标记
        appMode = MODE_APPLICATION;
        for (String str : args)
        {
            if (ARGS_WEB_START.equalsIgnoreCase(str))
            {
                appMode = MODE_WEB_START;
                break;
            }
        }
        // 运行目录标记
        baseFolder = EnvCons.COMN_PATH_HOME;

        UserInfo ui = new UserInfo("Amon", "amon");
        ui.wInit();
        RmpsUtil.setUserInfo(ui);

        // 1、 启动系统日志
        LogUtil.init();

        // 2、 运行环境检测
        if (!Rmps.checkJre())
        {
            System.exit(0);
            return;
        }

        // 3、 用户配置加载
        if (!ui.loadCfg(baseFolder, appMode))
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
        A3010000 soft = new A3010000();
        soft.wInit();
        soft.wShowView(VIEW_NORM);

        // 承载窗口引用
        winForm.setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
    }
}
