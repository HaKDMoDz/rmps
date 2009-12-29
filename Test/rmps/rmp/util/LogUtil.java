/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.util;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.PrintStream;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;

import com.amonsoft.util.CharUtil;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br />
 * TODO: 使用说明
 * </ul>
 * 
 * @author Amon
 */
public final class LogUtil
{
    /**
     * 私有构造器，不可被外界使用
     */
    private LogUtil()
    {
    }

    /**
     * 日志系统启动
     * 
     * @return
     */
    public static boolean wInit(String path)
    {
        try
        {
            // 创建日志文件对象
            File logFile = new File(path, "exception_" + new SimpleDateFormat("yyyy-MM-dd").format(new Date()) + ".log");

            // 错误日志文件是否存在
            if (!logFile.exists())
            {
                File pFile = logFile.getParentFile();
                if (!pFile.exists())
                {
                    if (!pFile.mkdirs())
                    {
                        return false;
                    }
                }
                if (!logFile.createNewFile())
                {
                    return false;
                }
            }

            // 创建文本输出流，在原数据的基本上进行扩展写出
            logStream = new PrintStream(new FileOutputStream(logFile, true), true, "UTF-8");
            return true;
        }
        catch (IOException exp)
        {
            exp.printStackTrace();
            return false;
        }
    }

    /**
     * 日志系统退出
     * 
     * @return
     */
    public static boolean wExit()
    {
        if (logStream != null)
        {
            logStream.flush();
            logStream.close();
        }
        return true;
    }

    /**
     * 异常信息写出
     * 
     * @param exp
     */
    public static void exception(Exception exp)
    {
        if (exp != null)
        {
            log(exp.toString());
            exp.printStackTrace();
        }
    }

    /**
     * 常规信息写出
     * 
     * @param msg
     */
    public static void log(String msg, String... args)
    {
        String date = dateFormat.format(new Date());

        if (logStream != null)
        {
            int i = 0;
            for (String t : args)
            {
                msg = msg.replace("{" + i + "}", t);
            }
            // 日志写出
            logStream.print(date);
            logStream.print("\t");
            logStream.println(msg);
        }

        System.out.print(date);
        System.out.print("\t");
        System.out.println(msg);
    }

    /**
     * 输出字符串数组
     * 
     * @param b
     */
    public static final void log(byte[] b)
    {
        log(b, 10);
    }

    /**
     * 以指定进制输出字符串数组
     * 
     * @param b
     * @param radio
     *            进制信息
     */
    public static final void log(byte[] b, int radio)
    {
        log(b, radio, b.length);
    }

    /**
     * 以指定进制输出字符串数组，并指定每行输出元素个数
     * 
     * @param b
     * @param radio
     * @param length
     *            每行输出元素个数
     */
    public static final void log(byte[] b, int radio, int length)
    {
        log(b, radio, length, false);
    }

    /**
     * @param b
     *            等输出字节数组
     * @param radio
     *            输出字节进制
     * @param length
     *            每行输出元素个数
     * @param lpad
     *            是否需要左填充
     */
    public static final void log(byte[] b, int radio, int length, boolean lpad)
    {
        // log(b, radio, length, lpad, ",\t", '0');
    }

    /**
     * @param a
     *            待输出字节数组
     * @param r
     *            输出字节进制
     * @param l
     *            是否需要左填充
     * @param f
     *            左填充后显示长度
     * @param p
     *            左填充字符信息
     * @param s
     *            元素输出分隔符
     * @param n
     *            每行输出元素个数
     */
    public static final void log(byte[] a, int r, boolean l, int f, char p, String s, int n)
    {
        // 数组为空的情况
        if (a == null)
        {
            System.out.println("Byte Array is NULL!");
            return;
        }

        // 数据长度不合法
        if (a.length < 1)
        {
            System.out.println("Invalidate Length: " + a.length);
        }

        String t;
        // 循环输出数组元素
        for (int i = 0, j = a.length; i < j;)
        {
            t = Integer.toString(a[i] & 0xFF, r);

            if (l)
            {
                t = CharUtil.lPad(t, f, p);
            }

            i += 1;

            // 回行显示
            if (i % n != 0)
            {
                System.out.print(t + s);
            }
            else
            {
                System.out.println(t + s);
            }
        }
    }

    public static final void log(String[] s)
    {
        log(s, s.length);
    }

    public static final void log(String[] s, int length)
    {
        log(s, length, false);
    }

    public static final void log(String[] s, int length, boolean lpad)
    {
        log(s, false, 0, ' ', ",", 1);
    }

    /**
     * @param a
     *            待输出字节数组
     * @param l
     *            是否需要左填充
     * @param f
     *            左填充后显示长度
     * @param p
     *            左填充字符信息
     * @param s
     *            元素输出分隔符
     * @param n
     *            每行输出元素个数
     */
    public static final void log(String[] a, boolean l, int f, char p, String s, int n)
    {
        // 数组为空的情况
        if (a == null)
        {
            System.out.println("Byte Array is NULL!");
            return;
        }

        // 数据长度不合法
        if (a.length < 1)
        {
            System.out.println("Invalidate Length: " + a.length);
        }

        String t;
        // 循环输出数组元素
        for (int i = 0, j = a.length; i < j;)
        {
            t = a[i];

            if (l)
            {
                t = CharUtil.lPad(t, f, p);
            }

            i += 1;

            // 回行显示
            if (i % n != 0)
            {
                System.out.print(t + s);
            }
            else
            {
                System.out.println(t + s);
            }
        }
    }

    public static final void log(Object[] obj)
    {
        for (Object o : obj)
        {
            log(o.toString());
        }
    }

    /** 日期格式化对象 */
    private static DateFormat dateFormat = DateFormat.getDateTimeInstance();
    /** 日志输出流 */
    private static PrintStream logStream;
}
