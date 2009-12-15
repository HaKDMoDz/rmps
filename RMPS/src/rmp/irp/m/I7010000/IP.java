/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.m.I7010000;

import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.IProcess;
import com.amonsoft.rmps.irp.m.IService;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.util.LogUtil;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.net.URL;
import java.net.URLConnection;
import java.util.ArrayList;
import java.util.List;
import java.util.Properties;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import rmp.util.StringUtil;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * IP地址查询
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class IP implements IService
{
    private static Properties isCfg;
    private static Pattern v4Ptn;
    private static Pattern paPtn;
    private static Pattern piPtn;

    public IP()
    {
    }

    @Override
    public boolean wInit()
    {
        try
        {
            isCfg = new Properties();
            isCfg.loadFromXML(new FileInputStream(new File("cfg", getCode() + ".xml")));

            v4Ptn = Pattern.compile("(?<![\\d\\.])((25[0-5]|2[0-4]\\d|1\\d{2}|[1-9]\\d|\\d)\\.){3}(25[0-5]|2[0-4]\\d|1\\d{2}|[1-9]\\d|\\d)(?![\\d\\.])");

            paPtn = Pattern.compile("(\\(\")(.*?)(\"\\))");
            piPtn = Pattern.compile("\"(.*?)\"");

            LogUtil.log(getName() + " 初始化成功！");
            return true;
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            return false;
        }
    }

    @Override
    public String getCode()
    {
        return "ip";
    }

    @Override
    public String getName()
    {
        return "IP";
    }

    @Override
    public String getDescription()
    {
        return "";
    }

    @Override
    public void doInit(ISession session, IMessage message)
    {
        session.send("Welcome to IP:");
        session.getProcess().setType(IProcess.CONTENT);
    }

    @Override
    public void doHelp(ISession session, IMessage message)
    {
    }

    @Override
    public void doDeal(ISession session, IMessage message)
    {
        try
        {
            String key = message.getContent();
            StringBuffer msg = new StringBuffer();

            // 地址校验
            if (!v4Ptn.matcher(key).matches())
            {
                session.send("您输入的IP地址不是一个合适的IPV4地址，请重新输入！");
                return;
            }

            // 链接地址初始化
            URL url = new URL(isCfg.getProperty("path") + '?' + StringUtil.format(isCfg.getProperty("args"), key));
            URLConnection conn = url.openConnection();
            conn.setRequestProperty("Proxy-Connection", "Keep-Alive");
            conn.setUseCaches(false);
            conn.setDoInput(true);

            // 读取返回结果
            DataInputStream dis = new DataInputStream(conn.getInputStream());
            byte d[] = new byte[dis.available()];
            dis.read(d);
            String data = new String(d, "gb2312");

            Matcher matcher = paPtn.matcher(data);
            if (matcher.find())
            {
                // 发送结果信息
                showData(session, msg, matcher.group());

                // 设置下一次操作状态
                IProcess process = session.getProcess();
                process.setType(IProcess.CONTENT);
            }
            else
            {
                session.send("");
            }
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
    }

    private void showData(ISession session, StringBuffer message, String data)
    {
        List<String> list = new ArrayList<String>();
        Matcher matcher = piPtn.matcher(data);
        while (matcher.find())
        {
            list.add(matcher.group().replaceAll("^\"|\"$", ""));
        }

        if (list.size() != 5)
        {
            message.append("数据查询错误，请重试！");
        }
        else
        {
            // 结果信息格式化
            message.append("IP地址：").append(list.get(1)).append(session.newLine());
            message.append("国　家：").append(list.get(3)).append(session.newLine());
            message.append("地　区：").append(list.get(5)).append(session.newLine());
            message.append("运营商：").append(list.get(9)).append(session.newLine());
        }
        session.send(message.toString());
    }
}
