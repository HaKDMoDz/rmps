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

import javax.swing.JFrame;
import javax.swing.UIManager;
import javax.swing.plaf.synth.SynthLookAndFeel;

import rmp.prp.Prps;
import rmp.user.UserInfo;
import rmp.util.EnvUtil;
import com.amonsoft.util.LogUtil;
import rmp.util.MesgUtil;
import rmp.util.RmpsUtil;
import rmp.util.StringUtil;
import cons.CfgCons;
import cons.EnvCons;
import cons.ui.LangRes;
import com.amonsoft.skin.ISkin;

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
    /**
     * @param args
     */
    public static void main(String[] args)
    {
        UserInfo ui = new UserInfo("Amon", "amon");
        ui.wInit();
        RmpsUtil.setUserInfo(ui);

        // 1、 启动系统日志
        LogUtil.wInit();

        // 2、 运行环境检测
        if (!checkJre())
        {
            System.exit(0);
            return;
        }

        // 3、 用户配置加载
        if (!initCfg())
        {
            System.exit(0);
            return;
        }

        // 4、 应用界面风格
        if (!initLnF(ui.getCfg(CfgCons.CFG_LNF_TYPE), ui.getCfg(CfgCons.CFG_LNF_NAME)))
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
            RmpsUtil.getUserInfo().saveCfg();
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
     * 加载用户配置数据信息
     * 
     * @return 用户配置是否加载成功：true加载成功
     */
    public static boolean initCfg()
    {
        LogUtil.log("系统启动：用户配置数据信息加载！");

        RmpsUtil.getUserInfo().loadCfg(EnvCons.COMN_PATH_HOME, ConsSys.MODE_APPLICATION);

        return true;
    }

    /**
     * 加载用户当前界面方案
     * 
     * @param type 界面风格类别
     * @param name 界面风格名称
     * @return 界面方案是否加载成功：true加载成功
     */
    public static boolean initLnF(String type, String name)
    {
        if (type == null)
        {
            type = ISkin.LF_TYPE_SYSTEM;
        }
        type = type.trim();

        // 使用当前系统界面样式
        if ("".equals(type) || ISkin.LF_TYPE_SYSTEM.equalsIgnoreCase(type))
        {
            name = UIManager.getSystemLookAndFeelClassName();
        }

        LogUtil.log("系统启动：当前使用界面风格信息 (" + type + ", " + name + ")");
        RmpsUtil.getUserInfo().setUserSkin(type, name);

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

        Prps prp = new Prps();
        prp.initView();
        prp.initLang();
        prp.initData();
        return true;
    }
}
