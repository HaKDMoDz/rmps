/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.m.I7010000;

import java.io.DataInputStream;
import java.io.File;
import java.net.URL;
import java.net.URLConnection;
import java.util.ArrayList;
import java.util.List;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import org.dom4j.Document;
import org.dom4j.Element;
import org.dom4j.io.SAXReader;

import rmp.util.EnvUtil;
import rmp.util.StringUtil;

import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.IProcess;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.rmps.irp.m.IService;
import com.amonsoft.util.LogUtil;

import cons.EnvCons;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * IP地址查询
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public class I7010000 implements IService
{
    private static String path;
    private static String args;
    private static Pattern v4Ptn;
    private static Pattern paPtn;
    private static Pattern piPtn;

    public I7010000()
    {
    }

    @Override
    public boolean wInit()
    {
        try
        {
            Document document = new SAXReader().read(new File(EnvUtil.getDataPath(EnvCons.FOLDER1_IRP, getCode() + ".xml")));
            Element element = (Element) document.selectSingleNode("/irps/I7010000/item[@id='配置']/map[@key='path']");
            if (element != null)
            {
                path = element.getText();
            }
            element = (Element) document.selectSingleNode("/irps/I7010000/item[@id='配置']/map[@key='args']");
            if (element != null)
            {
                args = element.getText();
            }

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
        return "57010000";
    }

    @Override
    public String getName()
    {
        return "IP 查询";
    }

    @Override
    public String getDescription()
    {
        return "IP 查询";
    }

    @Override
    public void doInit(ISession session, IMessage message)
    {
        session.send("Welcome to IP:");
        session.getProcess().setType(IProcess.TYPE_KEYCODE | IProcess.TYPE_CONTENT);
        session.getProcess().setStep(IProcess.STEP_DEFAULT);
    }

    @Override
    public void doMenu(ISession session, IMessage message)
    {
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
            String tmp = key.trim();
            StringBuffer msg = new StringBuffer();

            // 地址校验
            if (!v4Ptn.matcher(tmp).matches())
            {
                session.send("您输入的IP地址不是一个合适的IPV4地址，请重新输入！");
                return;
            }

            // 链接地址初始化
            URL url = new URL(path + '?' + StringUtil.format(args, tmp));
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
                process.setType(IProcess.TYPE_CONTENT);
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

        session.getProcess().setType(IProcess.TYPE_KEYCODE | IProcess.TYPE_CONTENT);
    }

    @Override
    public void doStep(ISession session, IMessage message)
    {
    }

    @Override
    public void doExit(ISession session, IMessage message)
    {
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
            message.append("IP地址：").append(list.get(0)).append(session.newLine());
            message.append("国　家：").append(list.get(1)).append(session.newLine());
            message.append("地　区：").append(list.get(2)).append(session.newLine());
            message.append("运营商：").append(list.get(4)).append(session.newLine());
        }
        session.send(message.toString());
    }
}
