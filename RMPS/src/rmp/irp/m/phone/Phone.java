/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *    
 */
package rmp.irp.m.phone;

import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.IProcess;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.rmps.irp.m.IService;
import com.amonsoft.util.LogUtil;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.net.HttpURLConnection;
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
 * TODO:
 * <li>使用说明：</li>
 * <br />
 * TODO:
 * </ul>
 * @author yihaodian
 */
public class Phone implements IService
{
    private static Properties isCfg;
    private static Pattern phone;

    @Override
    public boolean wInit()
    {
        try
        {
            isCfg = new Properties();
            isCfg.loadFromXML(new FileInputStream(new File("cfg", getCode() + ".xml")));

            phone = Pattern.compile("^1[3|5|8][0-9]\\d{4,8}$");

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
        return "phone";
    }

    @Override
    public String getName()
    {
        return "Phone";
    }

    @Override
    public String getDescription()
    {
        return "Phone";
    }

    @Override
    public void doInit(ISession session, IMessage message)
    {
        session.send("Welcome to Phone:");
        session.getProcess().setType(IProcess.CONTENT);
    }

    @Override
    public void doHelp(ISession session, IMessage message)
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public void doDeal(ISession session, IMessage message)
    {
        try
        {
            String key = message.getContent();
            StringBuffer msg = new StringBuffer();

            // 地址校验
            if (!phone.matcher(key).matches())
            {
                Control.appendPath(session, msg);
                msg.append("请输入11位手机号码或其前7位！");
                Control.appendCopy(session, msg);
                session.send(msg.toString());
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

            // 结果信息格式化
            String[] temp = data.split("'");
            Control.appendPath(session, msg);
            msg.append("号码段：").append(temp[1]).append(session.newLine());
            msg.append("归属地：").append(temp[3]).append(' ').append(temp[5]).append(session.newLine());
            msg.append("卡类型：").append(temp[7]).append(session.newLine());
            msg.append("区　号：").append(temp[9]).append(session.newLine());
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

    public void dd(ISession session, IMessage message)
    {
        try
        {
            String key = message.getContent();
            // 地址校验
            if (!phone.matcher(key).matches())
            {
                session.send("您输入的IP地址不是一个合适的IPV4地址，请重新输入！");
                return;
            }

            // 链接地址初始化
            URL url = new URL(isCfg.getProperty("path"));
            HttpURLConnection conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("POST");
            conn.setRequestProperty("Proxy-Connection", "Keep-Alive");
            conn.setDoOutput(true);
            conn.setDoInput(true);

            // 发送POST信息
            DataOutputStream dos = new DataOutputStream(conn.getOutputStream());
            dos.write(StringUtil.format(isCfg.getProperty("args"), key).getBytes());
            dos.flush();
            dos.close();

            // 读取返回结果
            DataInputStream dis = new DataInputStream(conn.getInputStream());
            byte d[] = new byte[dis.available()];
            dis.read(d);
            String data = new String(d, "gb2312");

            conn.disconnect();

            // 结果信息格式化
            String[] temp = data.split("\"");
            StringBuffer msg = new StringBuffer();
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
