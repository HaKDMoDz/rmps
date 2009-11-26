/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3050000;

import java.awt.Container;
import java.awt.image.BufferedImage;
import java.security.Security;
import java.util.Properties;

import javax.swing.JMenu;
import javax.swing.JPanel;

import rmp.Rmps;
import rmp.comn.info.C1010000.C1010000;
import com.amonsoft.rmps.prp.ISoft;
import rmp.prp.Prps;
import rmp.prp.aide.P3050000.v.NormPanel;
import rmp.prp.aide.P3050000.v.TailPanel;
import rmp.ui.form.AForm;
import rmp.ui.form.FForm;
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
import cons.id.PrpCons;
import cons.prp.aide.P3050000.ConstUI;
import cryptix.jce.provider.CryptixCrypto;
import com.amonsoft.util.LangUtil;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 数据安全
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class P3050000 extends AForm implements ISoft
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
    private static AForm softAForm;
    private static FForm softFForm;
    /** 语言资源 */
    private static Properties langRes;
    /** RMPS系统运行目录 */
    private static String baseFolder = "";
    /** 插件程序运行目录 */
    private static String plusFolder = "";
    // ----------------------------------------------------
    // 界面显示区域
    // ----------------------------------------------------
    private TailPanel tp_TailPanel = null;
    private NormPanel np_NormPanel = null;
    private LangUtil langUtil;
    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////

    /**
     * 默认构造函数
     */
    public P3050000()
    {
    }

    // ////////////////////////////////////////////////////////////////////////
    // 接口实现区域
    // ////////////////////////////////////////////////////////////////////////
    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    @Override
    public boolean wInit()
    {
        // 实例化主窗口
        softFForm = new FForm();
        softFForm.wInit();
        softFForm.setSoft(this);

        // 注册算法提供商
        if (Security.getProvider("CryptixCrypto") == null)
        {
            CryptixCrypto cryptix = new CryptixCrypto();
            Security.addProvider(cryptix);
        }
        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#dispose()
     */
    @Override
    public boolean wClosing()
    {
        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#getBaseFolder()
     */
    @Override
    public String wGetBaseFolder()
    {
        return baseFolder;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#setBaseFolder(java.lang.String)
     */
    @Override
    public void wSetBaseFolder(String folder)
    {
        baseFolder = folder;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#getSoftDescription()
     */
    @Override
    public String wGetDescription()
    {
        return langUtil.getMesg(ConstUI.RES_DESCRIPTION, "");
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#getHomepage()
     */
    @Override
    public String wGetHomepage()
    {
        return ConstUI.URL_SOFT;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#getSoftLogo()
     */
    @Override
    public BufferedImage wGetIconImage(int type)
    {
        return BeanUtil.getLogoImage();
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#getSoftID()
     */
    @Override
    public int wCode()
    {
        return PrpCons.P3050000_I;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#getSoftName()
     */
    @Override
    public String wGetName()
    {
        return langUtil.getMesg(ConstUI.RES_NAME, "");
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
     * @see rmp.face.ISoft#getTitle()
     */
    @Override
    public String wGetTitle()
    {
        return langUtil.getMesg(ConstUI.RES_TITLE, "");
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#getSoftVersion()
     */
    @Override
    public String wGetVersion()
    {
        return ConstUI.VER_CODE;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#initSoftMenu(javax.swing.JMenu)
     */
    @Override
    public boolean wShowMenu(JMenu menu)
    {
        return false;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#initSoftTail(javax.swing.JPanel)
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
        Prps.getSoftInfo().wSetBaseFolder(baseFolder);
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
     * @see rmp.face.ISoft#wIconified()
     */
    @Override
    public boolean wIconified()
    {
        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wDeiconified()
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
        return appMode == MODE_APPLET ? softAForm : softFForm;
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
                FileUtil.readLangRes(langRes, EnvCons.PATH_P3050000, EnvCons.COMN_SOFT_LANG);
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
        sb.append(EnvCons.PATH_P3050000).append(EnvCons.COMN_SP_FILE);
        sb.append(EnvCons.COMN_SOFT_INFO).append(RmpsUtil.getUserInfo().getCfg(CfgCons.CFG_LANG_ID));
        sb.append(SysCons.EXTS_INFO);
        return sb.toString();
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面显示区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 
     */
    private javax.swing.JPanel showMain()
    {
        return null;
    }

    /**
     * 
     */
    private javax.swing.JPanel showMini()
    {
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
            np_NormPanel = new NormPanel(this);
            np_NormPanel.wInit();
        }

        // 小程序处理
        if (appMode == MODE_APPLET)
        {
            softAForm.setContentPane(np_NormPanel);
        }
        else
        {
            softFForm.setContentPane(np_NormPanel);
            softFForm.pack();
            softFForm.center();
            if (!softFForm.isVisible())
            {
                softFForm.setVisible(true);
            }
        }
        return np_NormPanel;
    }

    /**
     * 
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

    /*
     * (non-Javadoc)
     * 
     * @see java.applet.Applet#init()
     */
    public void init()
    {
        // 启动模式标记
        appMode = MODE_APPLET;
        // 运行目录标记
        baseFolder = EnvCons.COMN_PATH_JNLP;

        UserInfo ui = new UserInfo("Amon", "amon");
        ui.wInit();
        RmpsUtil.setUserInfo(ui);

        // 承载窗口引用
        softAForm = this;
        // 显示主窗口 启动应用程序
        wShowView(VIEW_NORM);
    }

    /**
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
        P3050000 soft = new P3050000();
        soft.wInit();
        soft.wShowView(VIEW_MINI);

        // 承载窗口引用
        softFForm.setDefaultCloseOperation(FForm.EXIT_ON_CLOSE);
    }
    /** serialVersionUID */
    private static final long serialVersionUID = 4623903530200603927L;
}
