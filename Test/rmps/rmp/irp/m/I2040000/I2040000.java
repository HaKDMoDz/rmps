/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *    
 */
package rmp.irp.m.I2040000;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.File;
import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URLConnection;
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
 * 号码归属
 * <li>使用说明：</li>
 * <br />
 * 手机号码归属地查询
 * </ul>
 * 
 * @author Amon
 */
public class I2040000 implements IService
{
    private static String path;
    private static String args;
    private static Pattern mpPtn;
    private static Pattern msPtn;

    @Override
    public boolean wInit()
    {
        try
        {
            Document document = new SAXReader().read(new File(EnvUtil.getDataPath(EnvCons.FOLDER1_IRP, getCode() + ".xml")));
            Element element = (Element) document.selectSingleNode("/irps/item/map[@key='path']");
            if (element != null)
            {
                path = element.getText();
            }
            element = (Element) document.selectSingleNode("/irps/item/map[@key='args']");
            if (element != null)
            {
                args = element.getText();
            }

            msPtn = Pattern.compile("^\\+(86)?\\s?");
            mpPtn = Pattern.compile("^1[3|5|8][0-9]\\d{4,8}$");

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
        return "52040000";
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
            String txt = message.getContent().trim();
            StringBuffer msg = new StringBuffer();

            // 地址校验
            Matcher m = msPtn.matcher(txt);
            if (!m.find())
            {
                session.send("请以加号（+＋）起始，输入您要查询的11位手机号码或其前7位！");
                return;
            }

            txt = txt.replace(m.group(), "");
            if (!mpPtn.matcher(txt).matches())
            {
                session.send("请以加号（+＋）起始，输入您要查询的11位手机号码或其前7位！");
                return;
            }

            // 链接地址初始化
            URL url = new URL(path + '?' + StringUtil.format(args, txt));
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
            msg.append("号码段：").append(temp[1]).append(session.newLine());
            msg.append("归属地：").append(temp[3]).append(' ').append(temp[5]).append(session.newLine());
            msg.append("卡类型：").append(temp[7]).append(session.newLine());
            msg.append("区　号：").append(temp[9]).append(session.newLine());

            // 发送结果信息
            session.send(msg.toString());

            // 设置下一次操作状态
            IProcess process = session.getProcess();
            process.setType(IProcess.TYPE_CONTENT);
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
    }

    @Override
    public void doStep(ISession session, IMessage message)
    {
    }

    @Override
    public void doExit(ISession session, IMessage message)
    {
    }

    public void dd(ISession session, IMessage message)
    {
        try
        {
            String key = message.getContent();
            // 地址校验
            if (!mpPtn.matcher(key).matches())
            {
                session.send("您输入的IP地址不是一个合适的IPV4地址，请重新输入！");
                return;
            }

            // 链接地址初始化
            URL url = new URL(path);
            HttpURLConnection conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("POST");
            conn.setRequestProperty("Proxy-Connection", "Keep-Alive");
            conn.setDoOutput(true);
            conn.setDoInput(true);

            // 发送POST信息
            DataOutputStream dos = new DataOutputStream(conn.getOutputStream());
            dos.write(StringUtil.format(args, key).getBytes());
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
            msg.append("IP地址：").append(temp[1]).append(session.newLine());
            msg.append("国　家：").append(temp[3]).append(session.newLine());
            msg.append("地　区：").append(temp[5]).append(session.newLine());
            msg.append("运营商：").append(temp[9]).append(session.newLine());

            // 发送结果信息
            session.send(msg.toString());

            // 设置下一次操作状态
            IProcess process = session.getProcess();
            process.setType(IProcess.TYPE_CONTENT);
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
    }
}
