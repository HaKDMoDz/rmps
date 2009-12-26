/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.comn.C1010000;

import java.awt.image.BufferedImage;
import java.util.HashMap;
import java.util.Properties;
import java.util.logging.Level;
import java.util.logging.Logger;

import javax.swing.JMenu;
import javax.swing.JPanel;

import rmp.Rmps;
import rmp.comn.C1010000.v.MainPanel;
import rmp.comn.C1010000.v.MiniPanel;
import rmp.comn.C1010000.v.NormPanel;
import rmp.comn.C1010000.v.TailPanel;
import rmp.comn.user.UserInfo;
import rmp.prp.Prps;
import rmp.util.BeanUtil;
import rmp.util.EnvUtil;
import rmp.util.FileUtil;
import rmp.util.MesgUtil;

import com.amonsoft.bean.WForm;
import com.amonsoft.cons.ConsSys;
import com.amonsoft.rmps.prp.IPrpPlus;
import com.amonsoft.util.DeskUtil;
import com.amonsoft.util.LangUtil;
import com.amonsoft.util.LogUtil;

import cons.EnvCons;
import cons.comn.info.C1010000.ConstUI;
import cons.id.ComnCons;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 关于软件
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public class C1010000 extends WForm implements IPrpPlus
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
    private NormPanel np_NormPanel;
    private MiniPanel mp_MiniPanel;
    private MainPanel mp_MainPanel;
    private TailPanel tp_TailPanel;
    private LangUtil langUtil;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 默认构造函数，用于显示默认软件信息
     */
    public C1010000()
    {
    }

    @Override
    public boolean wInitView()
    {
        wInit(false);
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
        return baseFolder;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#setBaseFolder(java.lang.String)
     */
    @Override
    public void wSetBaseFolder(String folder)
    {
        baseFolder = folder;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#getSoftDescription()
     */
    @Override
    public String wGetDescription()
    {
        return langUtil.getMesg(ConstUI.RES_DESCRIPTION, "");
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#getHomepage()
     */
    @Override
    public String wGetHomepage()
    {
        return ConstUI.URL_SOFT;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#getSoftLogo()
     */
    @Override
    public BufferedImage wGetIconImage(int type)
    {
        return BeanUtil.getLogoImage();
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#getSystemID()
     */
    @Override
    public int wCode()
    {
        return ComnCons.C0000000_I;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#getSystemName()
     */
    @Override
    public String wGetName()
    {
        return ConstUI.RES_NAME;
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
        return langUtil.getMesg(ConstUI.RES_TITLE, "");
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#getSystemVersion()
     */
    @Override
    public String wGetVersion()
    {
        return ConstUI.VER_CODE;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#initSoftMenu(javax.swing.JMenu)
     */
    @Override
    public boolean wShowMenu(JMenu menu)
    {
        return false;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#initSoftTail(javax.swing.JPanel)
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
            Logger.getLogger(C1010000.class.getName()).log(Level.SEVERE, null, ex);
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
        C1010000.setInfo(EnvUtil.getLangPath(EnvCons.COMN_SOFT_INFO, "C1010000", baseFolder));
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
                FileUtil.readLangRes(langRes, EnvUtil.getLangPath(EnvCons.COMN_SOFT_LANG, ComnCons.C0000000_S, baseFolder));
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

    /**
     * @param infoPath
     */
    public static void setInfo(String infoPath)
    {
    }

    /**
     * @return
     */
    public static HashMap<String, String> getInfoRes()
    {
        // LogUtil.log("关于软件语言资源读取：" + infoFile.getPath());

        // 信息封装对象
        HashMap<String, String> propMap = new HashMap<String, String>();

        // // 文件存在性判断
        // if (infoFile == null || !infoFile.exists() || !infoFile.isFile() ||
        // !infoFile.canRead())
        // {
        // LogUtil.log("无法访问语言资源文档：" + infoFile.getPath());
        // return propMap;
        // }
        //
        // // 字符缓冲输入流
        // BufferedReader br = null;
        //
        // try
        // {
        // // 单行属性
        // String[] keys = {ConstUI.INFO_BUILD_TXT, ConstUI.INFO_BUILD_TIP,
        // ConstUI.INFO_BUILD_KEY,
        // ConstUI.INFO_COPYRIGHT_TXT, ConstUI.INFO_COPYRIGHT_TIP,
        // ConstUI.INFO_COPYRIGHT_KEY,
        // ConstUI.INFO_DESP_TIP, ConstUI.INFO_DESP_KEY,
        // ConstUI.INFO_HOMEPAGE_TXT, ConstUI.INFO_HOMEPAGE_TIP,
        // ConstUI.INFO_HOMEPAGE_KEY, ConstUI.INFO_LOGO00_PATH,
        // ConstUI.INFO_LOGO00_TIPS,
        // ConstUI.INFO_LOGO10_PATH, ConstUI.INFO_LOGO10_TIPS,
        // ConstUI.INFO_LOGO20_PATH, ConstUI.INFO_LOGO20_TIPS,
        // ConstUI.INFO_LOGO30_PATH, ConstUI.INFO_LOGO30_TIPS,
        // ConstUI.INFO_MAIL_TXT, ConstUI.INFO_MAIL_TIP,
        // ConstUI.INFO_MAIL_KEY, ConstUI.INFO_MAIL_SUB, ConstUI.INFO_TITLE_TXT,
        // ConstUI.INFO_TITLE_TIP,
        // ConstUI.INFO_TITLE_KEY, ConstUI.INFO_VENDOR_TXT,
        // ConstUI.INFO_VENDOR_TIP, ConstUI.INFO_VENDOR_KEY,
        // ConstUI.INFO_VERSION_TXT, ConstUI.INFO_VERSION_TIP,
        // ConstUI.INFO_VERSION_KEY};
        //
        // // 字符缓冲对象
        // StringBuffer desp = new StringBuffer();
        // StringBuffer mail = new StringBuffer();
        //
        // int spIdx;
        // String idStr;
        //
        // // 读取文件信息
        // String text;
        //
        // br = FileUtil.getReader(infoFile, SysCons.FILE_ENCODING);
        // while (true)
        // {
        // // 读取一行信息
        // text = br.readLine();
        //
        // // 文件结束退出循环
        // if (text == null)
        // {
        // break;
        // }
        //
        // // 空行及注释行处理
        // if (text.length() < 1 || '#' == text.charAt(0))
        // {
        // continue;
        // }
        //
        // // 信息标记判断
        // spIdx = text.indexOf('=');
        // if (spIdx < 0)
        // {
        // continue;
        // }
        //
        // idStr = text.substring(0, spIdx);
        //
        // // 描述信息
        // if (ConstUI.INFO_DESP_TXT.equalsIgnoreCase(idStr))
        // {
        // desp.append(text.substring(spIdx + 1)).append("\n");
        // continue;
        // }
        //
        // // 邮件内容
        // if (ConstUI.INFO_MAIL_CTX.equalsIgnoreCase(idStr))
        // {
        // mail.append(text.substring(spIdx + 1)).append("\n");
        // continue;
        // }
        //
        // // 其它单行信息
        // for (int i = 0, j = keys.length; i < j; i += 1)
        // {
        // if (keys[i].equalsIgnoreCase(idStr))
        // {
        // propMap.put(keys[i], text.substring(spIdx + 1));
        // break;
        // }
        // }
        // }
        //
        // propMap.put(ConstUI.INFO_DESP_TXT, desp.toString());
        // propMap.put(ConstUI.INFO_MAIL_CTX, mail.toString());
        // desp = null;
        // mail = null;
        // }
        // catch(IOException ioe)
        // {
        // LogUtil.exception(ioe);
        // }
        // finally
        // {
        // // 关闭输入流
        // if (br != null)
        // {
        // try
        // {
        // br.close();
        // }
        // catch(IOException exp)
        // {
        // LogUtil.exception(exp);
        // }
        // }
        // }
        return propMap;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面显示区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 显示迷你窗口
     */
    private javax.swing.JPanel showMini()
    {
        if (mp_MiniPanel == null)
        {
            mp_MiniPanel = new MiniPanel(this);
            mp_MiniPanel.wInit();
        }
        mp_MiniPanel.showInfo();

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
     * 显示高级窗口
     */
    private javax.swing.JPanel showMain()
    {
        if (mp_MainPanel == null)
        {
            mp_MainPanel = new MainPanel(this);
            mp_MainPanel.wInit();
        }
        mp_MainPanel.showInfo();

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
     * 显示普通窗口
     */
    private javax.swing.JPanel showNorm()
    {
        if (np_NormPanel == null)
        {
            np_NormPanel = new NormPanel(this);
            np_NormPanel.wInit();
        }
        np_NormPanel.showInfo();

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
        appMode = appMode = getAppMode(args);
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
        C1010000 soft = new C1010000();
        soft.wInitView();
        soft.wShowView(VIEW_NORM);
    }
}
