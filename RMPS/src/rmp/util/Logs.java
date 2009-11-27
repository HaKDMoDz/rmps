/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.util;

import java.io.File;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.HashMap;

/**
 *
 * @author Amon
 */
public class Logs
{
    private static HashMap<String, PrintWriter> map;

    private Logs()
    {
    }

    public static void log(String log)
    {
        System.out.println(log);
    }

    public static void log(Exception exp)
    {
        exp.printStackTrace();
    }

    public static void log(Object obj)
    {
        System.out.println(obj.toString());
    }

    /**
     * @param im IM类型
     * @param sa 服务账户
     * @param ca 用户账户
     * @return
     */
    public static PrintWriter getLog(String im, String sa, String ca) throws IOException
    {
        // IM类型目录
        File file = new File("log", im);
        if (!file.exists())
        {
            file.mkdirs();
        }
        // 服务账户目录
        file = new File(file, sa);
        if (!file.exists())
        {
            file.mkdir();
        }
        // 客户账户日志
        file = new File(file, ca);
        if (!file.exists())
        {
            file.createNewFile();
        }
        return new PrintWriter(file);
    }
}
