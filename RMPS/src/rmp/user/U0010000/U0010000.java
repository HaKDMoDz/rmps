/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.user.U0010000;

import java.awt.Container;
import java.awt.image.BufferedImage;
import java.util.HashMap;
import java.util.Properties;

import javax.swing.JMenu;
import javax.swing.JPanel;

import rmp.Rmps;
import rmp.face.WBackCall;
import com.amonsoft.rmps.prp.ISoft;
import rmp.prp.Prps;
import rmp.ui.form.AForm;
import rmp.ui.form.DForm;
import rmp.ui.form.FForm;
import rmp.user.UserInfo;
import rmp.user.U0010000.v.MainPanel;
import rmp.user.U0010000.v.MiniPanel;
import rmp.user.U0010000.v.NormPanel;
import rmp.user.U0010000.v.TailPanel;
import rmp.util.BeanUtil;
import rmp.util.FileUtil;
import rmp.util.ImageUtil;
import rmp.util.LogUtil;
import rmp.util.MesgUtil;
import rmp.util.RmpsUtil;
import cons.CfgCons;
import cons.EnvCons;
import cons.id.PrpCons;
import cons.user.U0010000.ConstUI;
import com.amonsoft.util.LangUtil;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 用户注册
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class U0010000 extends AForm implements ISoft
{
    // ////////////////////////////////////////////////////////////////////////
    // 控制变量区域
    // ////////////////////////////////////////////////////////////////////////
    // ----------------------------------------------------
    // 逻辑控制区域
    // ----------------------------------------------------
    /** 当前运行状态标记：参见AppCons.APP_MODE_*** */
    private static int appMode;
    private boolean validate;
    private static HashMap<String, WBackCall> hm_PropList;
    private LangUtil langUtil;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 默认构造函数
     */
    public U0010000()
    {
    }

    /**
     * @param form
     */
    public U0010000(javax.swing.JFrame form)
    {
        softFForm = form;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#wInit()
     */
    @Override
    public boolean wInit()
    {
        // 实例化主窗口
        softDForm = new DForm(softFForm, true);
        softDForm.wInit();
        softDForm.setSoft(this);

        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wClosing()
     */
    @Override
    public boolean wClosing()
    {
        softDForm.dispose();
        return true;
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
        return langUtil.getMesg(ConstUI.RES_DESCRIPTION, "");
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
        return PrpCons.U0010000_I;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetIcon()
     */
    @Override
    public BufferedImage wGetIconImage(int type)
    {
        try
        {
            switch (type)
            {
                case ICON_LOGO0016:
                    return ImageUtil.readJarImage(EnvCons.PATH_U0010000, "logo10.png");
                case ICON_LOGO0032:
                    return ImageUtil.readJarImage(EnvCons.PATH_U0010000, "logo20.png");
                case ICON_LOGO0048:
                    return ImageUtil.readJarImage(EnvCons.PATH_U0010000, "logo30.png");
                case ICON_LOGO0096:
                    return ImageUtil.readJarImage(EnvCons.PATH_U0010000, "logo60.png");
                case ICON_LOGO0128:
                    return ImageUtil.readJarImage(EnvCons.PATH_U0010000, "logo80.png");
                case ICON_LOGO0256:
                    return ImageUtil.readJarImage(EnvCons.PATH_U0010000, "logo00.png");
                default:
                    return BeanUtil.getLogoImage();
            }
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            return null;
        }
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetName()
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
     * @see rmp.face.ISoft#wGetTitle()
     */
    @Override
    public String wGetTitle()
    {
        return langUtil.getMesg(ConstUI.RES_TITLE, "");
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
     * @see rmp.face.ISoft#wShowMenu(javax.swing.JMenu)
     */
    @Override
    public boolean wShowMenu(JMenu menu)
    {
        return false;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wShowTail(javax.swing.JPanel)
     */
    @Override
    public boolean wShowTail(JPanel view)
    {
        return false;
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
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wShowInfo()
     */
    @Override
    public void wShowInfo()
    {
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
        return appMode == MODE_APPLET ? softAForm : softDForm;
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
                FileUtil.readLangRes(langRes, EnvCons.PATH_U0010000, EnvCons.COMN_SOFT_LANG);
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
     * 注册回馈对象引用
     * 
     * @param key
     * @param backCall
     */
    public void register(String key, WBackCall backCall)
    {
        if (hm_PropList == null)
        {
            hm_PropList = new HashMap<String, WBackCall>();
        }
        hm_PropList.put(key, backCall);
    }

    /**
     * 指定回馈对象信息回馈
     * 
     * @param key
     */
    public void firePropertyChanged(String key, Object value, String property)
    {
        if (hm_PropList != null)
        {
            WBackCall backCall = hm_PropList.get(key);
            if (backCall != null)
            {
                backCall.wAction(null, value, property);
            }
        }
    }

    /**
     * @return the validate
     */
    public boolean isValidate()
    {
        return validate;
    }

    /**
     * @param validate the validate to set
     */
    public void setValidate(boolean validate)
    {
        this.validate = validate;
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
        if (appMode == MODE_APPLET)
        {
            softAForm.setContentPane(mp_MainPanel);
        }
        // 主程序处理
        else
        {
            softDForm.setContentPane(mp_MainPanel);
            softDForm.pack();
            softDForm.center();
            if (!softDForm.isVisible())
            {
                softDForm.setVisible(true);
            }
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

        // 小程序处理
        if (appMode == MODE_APPLET)
        {
            softAForm.setContentPane(mp_MiniPanel);
        }
        // 主程序处理
        else
        {
            softDForm.setContentPane(mp_MiniPanel);
            softDForm.pack();
            softDForm.center();
            if (!softDForm.isVisible())
            {
                softDForm.setVisible(true);
            }
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
        if (appMode == MODE_APPLET)
        {
            softAForm.setContentPane(np_NormPanel);
        }
        // 主程序处理
        else
        {
            softDForm.setContentPane(np_NormPanel);
            softDForm.pack();
            softDForm.center();
            if (!softDForm.isVisible())
            {
                softDForm.setVisible(true);
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
        if (tp_TailPanel == null)
        {
            tp_TailPanel = new TailPanel(this);
            tp_TailPanel.wInit();
        }
        return tp_TailPanel;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 系统启动区域
    // ////////////////////////////////////////////////////////////////////////
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
        U0010000 soft = new U0010000();
        soft.wInit();
        soft.wShowView(VIEW_MINI);

        // 承载窗口引用
        softDForm.setDefaultCloseOperation(FForm.EXIT_ON_CLOSE);
    }
    // ////////////////////////////////////////////////////////////////////////
    // 界面组件区域
    // ////////////////////////////////////////////////////////////////////////
    /** 程序主窗口 */
    private static AForm softAForm;
    private static DForm softDForm;
    private static javax.swing.JFrame softFForm;
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
    /** serialVersionUID */
    private static final long serialVersionUID = -7628805074517491667L;
}
