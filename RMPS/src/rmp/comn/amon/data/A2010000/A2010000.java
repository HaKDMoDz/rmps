/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.comn.amon.data.A2010000;

import com.amonsoft.bean.WForm;
import com.amonsoft.cons.ConsSys;
import java.awt.image.BufferedImage;
import java.util.Properties;

import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JMenu;
import javax.swing.JPanel;

import rmp.Rmps;
import rmp.comn.amon.data.A2010000.v.MainPanel;
import rmp.comn.amon.data.A2010000.v.MiniPanel;
import rmp.comn.amon.data.A2010000.v.NormPanel;
import rmp.comn.amon.data.A2010000.v.TailPanel;
import rmp.comn.C1010000.C1010000;
import com.amonsoft.rmps.prp.IPrpPlus;
import rmp.prp.Prps;
import rmp.comn.user.UserInfo;
import rmp.util.FileUtil;
import com.amonsoft.util.LogUtil;
import rmp.util.MesgUtil;
import rmp.util.RmpsUtil;
import cons.CfgCons;
import cons.EnvCons;
import cons.SysCons;
import cons.id.AmonCons;
import com.amonsoft.util.DeskUtil;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 数据管理
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class A2010000 extends WForm implements IPrpPlus
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
    /** 高级面板 */
    private MainPanel mp_MainPanel;
    /** 迷你面板 */
    private MiniPanel mp_MiniPanel;
    /** 正常面板 */
    private NormPanel np_NormPanel;
    /** 内嵌面板 */
    private TailPanel tp_TailPanel;

    @Override
    public boolean wInitView()
    {
        throw new UnsupportedOperationException("Not supported yet.");
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
     * @see rmp.face.IPrpPlus#dispose()
     */
    @Override
    public boolean wClosing()
    {
        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#getBaseFolder()
     */
    @Override
    public String wGetBaseFolder()
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#getDescription()
     */
    @Override
    public String wGetDescription()
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#getHomepage()
     */
    @Override
    public String wGetHomepage()
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#getID()
     */
    @Override
    public int wCode()
    {
        return AmonCons.A2010000_I;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#getIcon()
     */
    @Override
    public BufferedImage wGetIconImage(int type)
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#getName()
     */
    @Override
    public String wGetName()
    {
        return null;
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
     * @see rmp.face.IPrpPlus#getTitle()
     */
    @Override
    public String wGetTitle()
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#getVersion()
     */
    @Override
    public String wGetVersion()
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#initMenu(javax.swing.JMenu)
     */
    @Override
    public boolean wShowMenu(JMenu menu)
    {
        return false;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#initTail(javax.swing.JPanel)
     */
    @Override
    public boolean wShowTail(JPanel view)
    {
        if (tp_TailPanel == null)
        {
        }
        return false;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#setBaseFolder(java.lang.String)
     */
    @Override
    public void wSetBaseFolder(String folder)
    {
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
            Logger.getLogger(A2010000.class.getName()).log(Level.SEVERE, null, ex);
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
                FileUtil.readLangRes(langRes, EnvCons.PATH_A2010000, EnvCons.COMN_SOFT_LANG);
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
        sb.append(EnvCons.COMN_SOFT_INFO).append(Rmps.getUser().getCfg(CfgCons.CFG_LANG_ID));
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
            // mp_MainPanel = new MainPanel(this);
            mp_MainPanel.wInit();
        }

        setContentPane(mp_MainPanel);
        pack();
        center(null);
        if (!isVisible())
        {
            setVisible(true);
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
            mp_MiniPanel = new MiniPanel();
            mp_MiniPanel.wInit();
        }

        setContentPane(mp_MiniPanel);
        pack();
        center(null);
        if (!isVisible())
        {
            setVisible(true);
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

        setContentPane(np_NormPanel);
        pack();
        center(null);
        if (!isVisible())
        {
            setVisible(true);
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
     * @see java.applet.Applet#wInit()
     */
    @Override
    public void init()
    {
        // 启动模式标记
        appMode = ConsSys.MODE_APPLET;
        // 运行目录标记
        baseFolder = EnvCons.COMN_PATH_JNLP;

        UserInfo ui = new UserInfo("Amon", "amon");
        ui.wInit();
        Rmps.setUser(ui);

        // 显示主窗口 启动应用程序
        wShowView(VIEW_NORM);
    }

    /**
     * @param args
     */
    public static void main(String[] args)
    {
        // 启动模式标记
        appMode = getAppMode(args);
        // 运算目录标记
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
        A2010000 soft = new A2010000();
        soft.wInitView();
        soft.wShowView(VIEW_NORM);
    }
}
