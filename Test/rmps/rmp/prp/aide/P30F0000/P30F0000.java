/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P30F0000;

import java.awt.image.BufferedImage;
import java.util.Properties;
import java.util.logging.Level;
import java.util.logging.Logger;

import javax.swing.JMenu;
import javax.swing.JPanel;

import rmp.Rmps;
import rmp.comn.C1010000.C1010000;
import rmp.comn.user.UserInfo;
import rmp.prp.Prps;
import rmp.util.EnvUtil;
import rmp.util.FileUtil;
import rmp.util.MesgUtil;

import com.amonsoft.bean.WForm;
import com.amonsoft.rmps.prp.IPrpPlus;
import com.amonsoft.util.DeskUtil;
import com.amonsoft.util.LangUtil;
import com.amonsoft.util.LogUtil;

import cons.EnvCons;
import cons.id.PrpCons;
import cons.prp.aide.P30F0000.ConstUI;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br>
 * 密码魔方
 * <li>使用说明：</li>
 * <br>
 * </ul>
 * <p>
 * 版本： RMPS V1.0.0.0
 * </p>
 * <p>
 * 作者： Amon
 * </p>
 * <p>
 * 日期： 2008-2-28 下午08:11:32
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class P30F0000 extends WForm implements IPrpPlus
{
    // ////////////////////////////////////////////////////////////////////////
    // 控制变量区域
    // ////////////////////////////////////////////////////////////////////////
    // ----------------------------------------------------
    // 逻辑控制区域
    // ----------------------------------------------------
    /** 当前运行状态标记：参见AppCons.APP_MODE_*** */
    private static int appMode;
    /** 语言资源 */
    private static Properties langRes;
    /** RMPS系统运行目录 */
    private static String baseFolder = "";
    /** 插件程序运行目录 */
    private static String plusFolder = "";
    // ----------------------------------------------------
    // 界面显示区域
    // ----------------------------------------------------
    private LangUtil langUtil;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 默认构造函数
     */
    public P30F0000()
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
    public boolean wInitView()
    {
        return true;
    }

    @Override
    public boolean wInitLang()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public boolean wInitData()
    {
        throw new UnsupportedOperationException("Not supported yet.");
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
        return PrpCons.P30F0000_I;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wGetIcon()
     */
    @Override
    public BufferedImage wGetIconImage(int type)
    {
        // try
        // {
        // switch (type)
        // {
        // case ICON_LOGO0016:
        // return ImageUtil.readJarImage(EnvCons.PATH_P30F0000, "logo10.png");
        // case ICON_LOGO0032:
        // return ImageUtil.readJarImage(EnvCons.PATH_P30F0000, "logo20.png");
        // case ICON_LOGO0048:
        // return ImageUtil.readJarImage(EnvCons.PATH_P30F0000, "logo30.png");
        // case ICON_LOGO0096:
        // return ImageUtil.readJarImage(EnvCons.PATH_P30F0000, "logo60.png");
        // case ICON_LOGO0128:
        // return ImageUtil.readJarImage(EnvCons.PATH_P30F0000, "logo80.png");
        // case ICON_LOGO0256:
        // return ImageUtil.readJarImage(EnvCons.PATH_P30F0000, "logo00.png");
        // default:
        // return BeanUtil.getLogoImage();
        // }
        // }
        // catch (Exception exp)
        // {
        // LogUtil.exception(exp);
        // return null;
        // }
        return null;
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
        try
        {
            DeskUtil.open(EnvCons.FOLDER0_HELP + EnvCons.COMN_SP_FILE + "index.html");
        }
        catch (Exception ex)
        {
            Logger.getLogger(P30F0000.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wShowInfo()
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
        showStep();
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
     * 语言资源查询
     * 
     * @param mesgId
     *            语言资源索引
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
                FileUtil.readLangRes(langRes, EnvUtil.getLangPath(EnvCons.COMN_SOFT_INFO, PrpCons.P30F0000_S, baseFolder));
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
     * @param mesgId
     *            语言资源索引
     * @param defMesg
     *            默认语言资源
     * @return 语言资源内容
     */
    public static String getMesg(String mesgId, String defMesg)
    {
        String v = getMesg(mesgId);
        return v != null ? v : defMesg;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面显示区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 显示高级面板
     */
    private javax.swing.JPanel showMain()
    {
        return null;
    }

    /**
     * 显示迷你面板
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
        // 启动模式标记
        appMode = getAppMode(args);
        // 运行目录标记
        baseFolder = EnvCons.COMN_PATH_HOME;

        UserInfo ui = new UserInfo("Amon", "amon");
        ui.wInit();
        Rmps.setUser(ui);

        // 1、 启动系统日志
        LogUtil.wInit();

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
        if (!Rmps.initLnF())
        {
            System.exit(0);
            return;
        }

        // 5、引用应用对象
        P30F0000 soft = new P30F0000();
        if (soft.wInitView())
        {
            soft.wShowView(VIEW_NORM);
        }
        else
        {
            Rmps.exit(0, false, false);
        }

        // 系统托盘
        // C3010000.getInstance();
        // C3010000.regester("P30F0000", softFForm);
    }
}
