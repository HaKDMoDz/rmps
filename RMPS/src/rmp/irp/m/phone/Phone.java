/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

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
import java.net.HttpURLConnection;
import java.net.URL;
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
    private static Properties ipCfg;
    private static Pattern v4Ptn;

    @Override
    public boolean wInit()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public int getCode()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public String getName()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public String getDescription()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public void doInit(ISession session, IMessage message)
    {
        throw new UnsupportedOperationException("Not supported yet.");
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
            // 地址校验
            if (!v4Ptn.matcher(key).matches())
            {
                session.send("您输入的IP地址不是一个合适的IPV4地址，请重新输入！");
                return;
            }

            // 链接地址初始化
            URL url = new URL(ipCfg.getProperty("path"));
            HttpURLConnection conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("POST");
            conn.setRequestProperty("Proxy-Connection", "Keep-Alive");
            conn.setDoOutput(true);
            conn.setDoInput(true);

            // 发送POST信息
            DataOutputStream dos = new DataOutputStream(conn.getOutputStream());
            dos.write(StringUtil.format(ipCfg.getProperty("args"), key).getBytes());
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
