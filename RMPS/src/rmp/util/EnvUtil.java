/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.util;

import java.awt.Desktop;
import java.awt.Dimension;
import java.awt.Toolkit;
import java.awt.Desktop.Action;
import java.awt.datatransfer.Clipboard;
import java.awt.datatransfer.DataFlavor;
import java.awt.datatransfer.StringSelection;
import java.awt.datatransfer.Transferable;
import java.awt.event.ActionEvent;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.net.URI;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;

import javax.swing.AbstractAction;
import javax.swing.Timer;

import rmp.io.db.DBAccess;
import cons.EnvCons;
import cons.SysCons;
import cons.ui.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br />
 * TODO: 使用说明
 * </ul>
 * @author Amon
 */
public final class EnvUtil
{
    /** 当前使用的操作系统平台 */
    private static int osPlat;
    private static int curStep;
    private static int maxStep = 60;
    private static Timer timer;

    /**
     * 
     */
    private EnvUtil()
    {
    }

    // ////////////////////////////////////////////////////////////////////////
    // 系统文件路径
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 用户主工作目录
     * 
     * @return
     */
    public static String getHomeDir()
    {
        return System.getProperty(EnvCons.USER_HOMEDIR);
    }

    /**
     * 用户当前工作目录
     * 
     * @return
     */
    public static String getWorkDir()
    {
        return System.getProperty(EnvCons.USER_WORKDIR);
    }

    // ////////////////////////////////////////////////////////////////////////
    // 公共数据目录
    // ////////////////////////////////////////////////////////////////////////
    // ----------------------------------------------------
    // 用户数据目录
    // ----------------------------------------------------
    /**
     * 用户数据目录
     * 
     * @return
     */
    public static String getUserDir()
    {
        return "" + RmpsUtil.getUserInfo().getUserID();
    }

    // ----------------------------------------------------
    // 用户四级数据目录
    // ----------------------------------------------------
    /**
     * 公司图标目录
     * 
     * @return
     */
    public static String getIconCorpDir()
    {
        return EnvUtil.getUserDir() + EnvCons.PATH_P3010000 + EnvCons.COMN_SP_FILE + EnvCons.FOLDER4_CORPICON;
    }

    /**
     * 文件图标目录
     * 
     * @return
     */
    public static String getIconFileDir()
    {
        return EnvUtil.getUserDir() + EnvCons.PATH_P3010000 + EnvCons.COMN_SP_FILE + EnvCons.FOLDER4_FILEICON;
    }

    /**
     * 个人图标目录
     * 
     * @return
     */
    public static String getIconIdioDir()
    {
        return EnvUtil.getUserDir() + EnvCons.PATH_P3010000 + EnvCons.COMN_SP_FILE + EnvCons.FOLDER4_IDIOICON;
    }

    /**
     * 软件图标目录
     * 
     * @return
     */
    public static String getIconSoftDir()
    {
        return EnvUtil.getUserDir() + EnvCons.PATH_P3010000 + EnvCons.COMN_SP_FILE + EnvCons.FOLDER4_SOFTICON;
    }

    /**
     * 数据库用户名称
     * 
     * @return
     */
    public static String getDbUser()
    {
        return "";
    }

    /**
     * 数据库用户密码
     * 
     * @return
     */
    public static String getDBPwds()
    {
        return "";
    }

    /**
     * 获得当前屏幕的尺寸大小信息
     */
    public static Dimension getScreenSize()
    {
        return Toolkit.getDefaultToolkit().getScreenSize();
    }

    /**
     * 获得程序启动目录
     * 
     * @return
     */
    public static String getProgramFile()
    {
        return System.getenv(EnvCons.WINDOWS_PROGFILE);
    }

    /**
     * 获得当前操作系统的名称
     * 
     * @return
     */
    public static int getCurrOS()
    {
        if (osPlat < SysCons.OS_IDX_UNKNOWN)
        {
            String osName = System.getProperty(EnvCons.OS_NAME);
            if (osName == null || osName.length() < 1)
            {
                osPlat = SysCons.OS_IDX_UNKNOWN;
                return osPlat;
            }

            osName = osName.toLowerCase();

            // Windows平台
            if (osName.indexOf(SysCons.OS_STR_WINDOWS) >= 0)
            {
                osPlat = SysCons.OS_IDX_WINDOWS;
                return osPlat;
            }

            // Unix平台
            if (osName.indexOf(SysCons.OS_STR_UNIX) >= 0)
            {
                osPlat = SysCons.OS_IDX_UNIX;
                return osPlat;
            }

            // Linux平台
            if (osName.indexOf(SysCons.OS_STR_LINUX) >= 0)
            {
                osPlat = SysCons.OS_IDX_LINUX;
                return osPlat;
            }

            // Mac OS平台
            if (osName.indexOf(SysCons.OS_STR_MACOS) >= 0)
            {
                osPlat = SysCons.OS_IDX_MACINTOSH;
                return osPlat;
            }

            // 未知平台
            osPlat = SysCons.OS_IDX_UNKNOWN;
        }
        return osPlat;
    }

    /**
     * 网络浏览
     * 
     * @param url
     * @return
     */
    public static boolean browse(String url)
    {
        // 桌面支持性判断
        if (!Desktop.isDesktopSupported())
        {
            return false;
        }

        // 指定事件可用性判断
        Desktop desktop = Desktop.getDesktop();
        if (!desktop.isSupported(Action.BROWSE))
        {
            return false;
        }

        // 浏览指定地址
        try
        {
            desktop.browse(new URI(url));
            return true;
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            MesgUtil.showMessageDialog(null, StringUtil.format(LangRes.MESG_INET_0001, url, exp.getMessage()));
            return false;
        }
    }

    /**
     * 关闭数据库，将内在中数据回写到数据文件中
     * 
     * @return 数据库是否成功关闭：true成功；false失败
     */
    public static boolean shutdownDataBase()
    {
        if (!DBAccess.isOpened())
        {
            return true;
        }
        LogUtil.log("数据库关闭：开始....");

        // 创建数据库操作对象
        DBAccess dba = new DBAccess();

        // 数据库清理
        try
        {
            // 启动事务
            if (dba.wInit())
            {
                LogUtil.log("数据库关闭：SHUTDOWN...");
                // 执行数据库关闭
                dba.execute("SHUTDOWN");

                LogUtil.log("数据库关闭：关闭成功！");
                return true;
            }
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            MesgUtil.showMessageDialog(null, StringUtil.format(LangRes.MESG_EXIT_0001, exp.getMessage()));
        }
        finally
        {
            // 事务提交
            dba.closeConnection();
        }

        return false;
    }

    /**
     * 数据备份
     */
    public static void backupDatabase() throws Exception
    {
        int uid = RmpsUtil.getUserInfo().getUserID();
        String zip = uid + EnvCons.PATH_BAK + EnvCons.COMN_SP_FILE + "amon.backup";
        ZipUtil.zip(zip, uid + EnvCons.COMN_SP_FILE + "rmp.wsc", uid + EnvCons.PATH_DAT);
    }

    /**
     * 数据恢复
     */
    public static void pickupDatabase() throws Exception
    {
        // 目标备份文件
        File backFile = new File(EnvUtil.getUserDir() + EnvCons.PATH_BAK, "amon.backup");
        // 数据库数据文件
        File dataFile = new File(EnvUtil.getUserDir() + EnvCons.PATH_BAK, "amon.script");

        try
        {
            // 关闭数据库，内在数据回写
            if (!shutdownDataBase())
            {
                MesgUtil.showMessageDialog(null, LangRes.MESG_PICK_0004);
                return;
            }

            // 文件复制
            String errMsg = FileUtil.copyFile(backFile, dataFile, true);
            if (errMsg != null)
            {
                errMsg = StringUtil.format(LangRes.MESG_PICK_0002, errMsg);
                MesgUtil.showMessageDialog(null, errMsg);
                return;
            }

            // 恢复结果提示信息
            MesgUtil.showMessageDialog(null, LangRes.MESG_PICK_0001);
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            String mesg = StringUtil.format(LangRes.MESG_PICK_0003, LangRes.MESG_INIT_0001);
            MesgUtil.showMessageDialog(null, mesg);
        }

        // 资源释放
        dataFile = null;
        backFile = null;
    }

    /**
     * 文件数据摘要
     * 
     * @param file
     * @param hash
     */
    public static void hash(String hash, File file)
    {
        // 文件存在性判断
        if (file == null || !file.exists() || !file.isFile() || !file.canRead())
        {
            MesgUtil.showMessageDialog(null, "指定路径文件 “" + file.getPath() + "” 不存在！");
            return;
        }

        HashUtil.addProvider();

        try
        {
            // 创建文本输入流
            FileInputStream fis = new FileInputStream(file);

            // 读取文件
            byte[] b = new byte[EnvCons.COMN_BUFF_SIZE];
            int r = fis.read(b);
            if (r < 0)
            {
                fis.close();
                return;
            }

            MessageDigest md = MessageDigest.getInstance(hash);

            // 文件信息读取并计算
            while (r >= 0)
            {
                md.update(b);
                r = fis.read(b);
            }
            fis.close();

            // 摘要结果计算
            b = md.digest();
            MesgUtil.showMessageDialog(null, StringUtil.bytesToString(b, true));
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
    }

    /**
     * 字符数据摘要
     * 
     * @param hash
     * @param text
     */
    public static byte[] hash(String hash, String text)
    {
        HashUtil.addProvider();

        try
        {
            MessageDigest md = MessageDigest.getInstance(hash);
            return md.digest(text.getBytes());
        }
        catch (NoSuchAlgorithmException exp)
        {
            LogUtil.exception(exp);
            MesgUtil.showMessageDialog(null, exp.getMessage());
            return null;
        }
    }

    /**
     * 发送电子邮件
     * 
     * @param mailto
     * @return
     */
    public static boolean mail(String mailto)
    {
        LogUtil.log(mailto);

        // 桌面支持性判断
        if (!Desktop.isDesktopSupported())
        {
            return false;
        }

        // 指定事件可用性判断
        Desktop desktop = Desktop.getDesktop();
        if (!desktop.isSupported(Action.MAIL))
        {
            return false;
        }

        // 发送邮件
        try
        {
            if (!mailto.toLowerCase().startsWith("mailto:"))
            {
                mailto = "mailto:" + mailto;
            }
            desktop.mail(new URI(mailto));
            return true;
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            return false;
        }
    }

    /**
     * 打开指定的程序
     * 
     * @param fileName
     */
    public static boolean open(String fileName)
    {
        LogUtil.log(fileName);

        // 文件存在性检测
        File readme = new File(fileName);
        if (!readme.exists())
        {
            return false;
        }

        // 桌面支持性判断
        if (!Desktop.isDesktopSupported())
        {
            return false;
        }

        // 指定事件可用性判断
        Desktop desktop = Desktop.getDesktop();
        if (!desktop.isSupported(Action.OPEN))
        {
            return false;
        }

        // 打开文件
        try
        {
            desktop.open(readme);
            return true;
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            return false;
        }
    }

    /**
     * 运行命令或程序
     */
    public static String run(String command)
    {
        LogUtil.log(command);

        try
        {
            Runtime.getRuntime().exec(command);
            return "";
            // Process p = Runtime.getRuntime().exec(command);
            // String msg = null;
            // if (p.exitValue() != 0)
            // {
            // msg = "Runtime Error";
            // }
            // return msg;
        }
        catch (IOException exp)
        {
            LogUtil.exception(exp);
            return exp.getMessage();
        }
    }

    /**
     * 向系统剪贴板添加数据
     * 
     * @param text
     */
    public static void setClipboardContents(String text)
    {
        StringSelection stringSelection = new StringSelection(text);
        Clipboard clipboard = Toolkit.getDefaultToolkit().getSystemClipboard();
        clipboard.setContents(stringSelection, null);
    }

    /**
     * @param text
     * @param autoClean
     */
    public static void setClipboardContents(String text, boolean autoClean)
    {
        setClipboardContents(text);

        if (timer == null)
        {
            timer = new Timer(100, new AbstractAction()
            {
                private static final long serialVersionUID = 4037202993197057389L;

                @Override
                public void actionPerformed(ActionEvent e)
                {
                    lookSystemClipboard();
                }
            });
        }
        curStep = 0;
        if (!timer.isRunning())
        {
            timer.start();
        }
    }

    /**
     * 系统剪贴板监视
     */
    private static void lookSystemClipboard()
    {
        if (curStep < maxStep)
        {
            curStep += 1;
        }
        else
        {
            clearClipboardContents();
            timer.stop();
        }
    }

    /**
     * 清除系统剪贴板数据
     */
    public static void clearClipboardContents()
    {
        Toolkit.getDefaultToolkit().getSystemClipboard().setContents(new StringSelection(null), null);
    }

    /**
     * 获取系统剪贴板数据（仅字符数据）
     * 
     * @return
     */
    public static String getClipboardContents()
    {
        String result = "";
        Clipboard clipboard = Toolkit.getDefaultToolkit().getSystemClipboard();
        Transferable contents = clipboard.getContents(null);
        if (contents != null && contents.isDataFlavorSupported(DataFlavor.stringFlavor))
        {
            try
            {
                Object obj = contents.getTransferData(DataFlavor.stringFlavor);
                result = (obj instanceof String) ? (String) obj : obj.toString();
            }
            catch (Exception exp)
            {
                LogUtil.exception(exp);
            }
        }
        return result;
    }
}
