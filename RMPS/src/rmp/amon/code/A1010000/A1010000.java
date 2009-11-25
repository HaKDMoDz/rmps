/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.amon.code.A1010000;

import java.awt.Container;
import java.awt.image.BufferedImage;
import java.util.Properties;

import javax.swing.JMenu;
import javax.swing.JPanel;

import rmp.Rmps;
import rmp.amon.code.A1010000.v.MainPanel;
import rmp.amon.code.A1010000.v.MiniPanel;
import rmp.amon.code.A1010000.v.NormPanel;
import rmp.amon.code.A1010000.v.TailPanel;
import rmp.comn.info.C1010000.C1010000;
import com.amonsoft.rmps.prp.ISoft;
import rmp.prp.Prps;
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
import cons.amon.code.A1010000.ConstUI;
import cons.id.AmonCons;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * Amon软件代码安全软件
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class A1010000 extends AForm implements ISoft
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
    /** 高级面板 */
    private MainPanel mp_MainPanel;
    /** 迷你面板 */
    private MiniPanel mp_MiniPanel;
    /** 正常面板 */
    private NormPanel np_NormPanel;
    /** 内嵌面板 */
    private TailPanel tp_TailPanel;

    /**
     * 
     */
    public A1010000()
    {
    }

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

        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#dispose()
     */
    @Override
    public void wDispose()
    {
        Rmps.exit(0, false, false);
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
     * @see rmp.face.ISoft#getDescription()
     */
    @Override
    public String wGetDescription()
    {
        return Prps.getMesg(ConstUI.RES_DESCRIPTION);
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#getHomepage()
     */
    @Override
    public String wGetHomepage()
    {
        return SysCons.HOMEPAGE;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#getID()
     */
    @Override
    public int wCode()
    {
        return AmonCons.A1010000_I;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#getIcon()
     */
    @Override
    public BufferedImage wGetIconImage(int type)
    {
        return BeanUtil.getLogoImage();
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#getName()
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
        return Prps.getMesg(ConstUI.RES_TITLE);
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#getVersion()
     */
    @Override
    public String wGetVersion()
    {
        return ConstUI.VER_CODE;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#initMenu(javax.swing.JMenu)
     */
    @Override
    public boolean wInitMenu(JMenu menu)
    {
        return false;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#initTail(javax.swing.JPanel)
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
        C1010000.setInfo("");
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
                FileUtil.readLangRes(langRes, EnvCons.PATH_A1010000, EnvCons.COMN_SOFT_LANG);
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
     * 显示高级面板
     */
    private javax.swing.JPanel showMain()
    {
        if (mp_MainPanel == null)
        {
            mp_MainPanel = new MainPanel(this);
            mp_MainPanel.wInit();
        }

        softFForm.setContentPane(mp_MainPanel);
        softFForm.pack();
        softFForm.center();
        if (!softFForm.isVisible())
        {
            softFForm.setVisible(true);
        }

        return mp_MainPanel;
    }

    /**
     * 显示迷你面板
     */
    private javax.swing.JPanel showMini()
    {
        if (mp_MiniPanel == null)
        {
            mp_MiniPanel = new MiniPanel(this);
            mp_MiniPanel.wInit();
        }

        // 小程序处理
        if (appMode == MODE_APPLET)
        {
            softAForm.setContentPane(mp_MiniPanel);
        }
        // 主程序处理
        else
        {
            softFForm.setContentPane(mp_MiniPanel);
            softFForm.pack();
            softFForm.center();
            if (!softFForm.isVisible())
            {
                softFForm.setVisible(true);
            }
        }
        return mp_MiniPanel;
    }

    /**
     * 显示正常面板
     */
    private javax.swing.JPanel showNorm()
    {
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
        // 主程序处理
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
        wShowView(VIEW_MAIN);
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
            if (SysCons.ARGS_WEBSTART.equalsIgnoreCase(str))
            {
                appMode = MODE_WEB_START;
                break;
            }
        }
        // 运算目录标记
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
        A1010000 soft = new A1010000();
        soft.wInit();
        soft.wShowView(VIEW_MAIN);

        // 承载窗口引用
        softFForm.setDefaultCloseOperation(FForm.EXIT_ON_CLOSE);
    }
    /** serialVersionUID */
    private static final long serialVersionUID = -3469384942595039787L;
}
