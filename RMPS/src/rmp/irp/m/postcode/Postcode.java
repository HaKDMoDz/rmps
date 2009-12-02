/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *    
 */
package rmp.irp.m.postcode;

import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.IProcess;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.rmps.irp.m.IService;
import com.amonsoft.util.LogUtil;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.net.URL;
import java.net.URLConnection;
import java.util.Properties;
import rmp.irp.c.Control;
import rmp.util.CheckUtil;
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
public class Postcode implements IService
{
    private static Properties isCfg;

    @Override
    public boolean wInit()
    {
        try
        {
            isCfg = new Properties();
            isCfg.loadFromXML(new FileInputStream(new File("cfg", getCode() + ".xml")));

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
        return "postcode";
    }

    @Override
    public String getName()
    {
        return "postcode";
    }

    @Override
    public String getDescription()
    {
        return "postcode";
    }

    @Override
    public void doInit(ISession session, IMessage message)
    {
        session.send("您可以输入任意一个国家国家、地区或城市的名称或者拼音！");
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
            if (!CheckUtil.isValidate(key))
            {
                Control.appendPath(session, msg);
                msg.append("请输入您要查询的国家、地区或城市的名称或拼音！");
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
}
