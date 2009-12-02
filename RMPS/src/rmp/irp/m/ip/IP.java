/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.m.ip;

import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.IProcess;
import com.amonsoft.rmps.irp.m.IService;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.util.LogUtil;
import java.io.DataInputStream;
import java.io.FileInputStream;
import java.net.URL;
import java.net.URLConnection;
import java.util.Properties;
import java.util.regex.Pattern;
import rmp.irp.c.Control;
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
    private static Properties ipCfg;
    private static Pattern v4Ptn;

    public IP()
    {
    }

    @Override
    public boolean wInit()
    {
        try
        {
            ipCfg = new Properties();
            ipCfg.loadFromXML(new FileInputStream("cfg/ip.xml"));

            v4Ptn = Pattern.compile("(?<![\\d\\.])((25[0-5]|2[0-4]\\d|1\\d{2}|[1-9]\\d|\\d)\\.){3}(25[0-5]|2[0-4]\\d|1\\d{2}|[1-9]\\d|\\d)(?![\\d\\.])");

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
    public int getCode()
    {
        return 0;
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
                Control.appendPath(session, msg);
                msg.append("您输入的IP地址不是一个合适的IPV4地址，请重新输入！");
                Control.appendCopy(session, msg);
                session.send(msg.toString());
                return;
            }

            // 链接地址初始化
            URL url = new URL(ipCfg.getProperty("path") + '?' + StringUtil.format(ipCfg.getProperty("args"), key));
            URLConnection conn = url.openConnection();
            conn.setRequestProperty("Proxy-Connection", "Keep-Alive");
            conn.setUseCaches(false);
            conn.setDoInput(true);

            // 读取返回结果
            DataInputStream dis = new DataInputStream(conn.getInputStream());
            byte d[] = new byte[dis.available()];
            dis.read(d);
            String data = new String(d, "gb2312");

            // 结果信息格式化
            String[] temp = data.split("\"");
            Control.appendPath(session, msg);
            msg.append("IP地址：").append(temp[1]).append(session.newLine());
            msg.append("国　家：").append(temp[3]).append(session.newLine());
            msg.append("地　区：").append(temp[5]).append(session.newLine());
            msg.append("运营商：").append(temp[9]).append(session.newLine());
            Control.appendCopy(session, msg);

            // 发送结果信息
            session.send(msg.toString());

            // 设置下一次操作状态
            IProcess process = session.getProcess();
            process.setType(IProcess.CONTENT);
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
    }
}
