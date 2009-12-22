/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *    
 */
package rmp.irp.m.I2020000;

import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.IProcess;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.rmps.irp.m.IService;
import com.amonsoft.util.LogUtil;
import cons.EnvCons;
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
import rmp.irp.c.Control;
import rmp.util.CheckUtil;
import rmp.util.EnvUtil;
import rmp.util.StringUtil;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 邮政编码
 * <li>使用说明：</li>
 * <br />
 * TODO:
 * </ul>
 * @author yihaodian
 */
public class I2020000 implements IService
{
    private static String path;
    private static String args;
    /**
     * 数据列表匹配
     */
    private static Pattern paPtn;
    /**
     * 单个数据匹配
     */
    private static Pattern piPtn;

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

            paPtn = Pattern.compile("(\\[')(.*?)('\\])");
            piPtn = Pattern.compile("'(.*?)'");

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
        return "52020000";
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
        session.getProcess().setStep(0);
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
            IProcess proc = session.getProcess();
            int step;

            // 地址校验
            if (!CheckUtil.isValidate(key))
            {
                session.send("请输入您要查询的国家、地区或城市的名称或拼音！");
                return;
            }

            // 翻页命令
            if (proc.getType() == IProcess.TYPE_COMMAND)
            {
                List<String> list = (List<String>) session.getAttribute(getCode() + "_m");
                if (list == null || list.size() < 1)
                {
                    session.send("请输入您要查询的国家、地区或城市的名称或拼音！");
                    return;
                }

                step = proc.getStep();
                if (step <= -1)
                {
                    session.send("已经是第一页！");
                    proc.setStep(-1);
                }
                else if (step >= proc.getMost())
                {
                    session.send("已经是最后一页！");
                    proc.setStep(proc.getMost());
                }
                else
                {
                    showData(session, msg, list.get(step));
                }
            }
            else
            {
                // 链接地址初始化
                URL url = new URL(path + '?' + StringUtil.format(args, key));
                URLConnection conn = url.openConnection();
                conn.setRequestProperty("Proxy-Connection", "Keep-Alive");
                conn.setUseCaches(false);
                conn.setDoInput(true);

                // 读取返回结果
                DataInputStream dis = new DataInputStream(conn.getInputStream());
                byte d[] = new byte[dis.available()];
                dis.read(d);
                String data = new String(d, "gb2312");

                // 保存用户查询结果
                Matcher matcher = paPtn.matcher(data);
                List<String> list = new ArrayList<String>();
                while (matcher.find())
                {
                    list.add(matcher.group());
                }
                step = 0;
                proc.setStep(step);
                proc.setMost(list.size());
                session.setAttribute(getCode() + "_m", list);

                if (list.size() < 1)
                {
                    session.send("请输入您要查询的国家、地区或城市的名称或拼音！");
                }
                else
                {
                    // 发送结果信息
                    showData(session, msg, list.get(step));
                }
            }
            // 设置下一次操作状态
            proc.setType(IProcess.TYPE_CONTENT);
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
    }

    private void showData(ISession session, StringBuffer message, String data)
    {
        Control.appendPath(session, message);

        // 结果信息格式化
        Matcher matcher = piPtn.matcher(data);
        List<String> list = new ArrayList<String>();
        while (matcher.find())
        {
            list.add(matcher.group().replaceAll("^'|'$", ""));
        }

        if (list.size() != 5)
        {
            message.append("数据查询错误，请重试！");
        }
        else
        {
            message.append("国家/地区/城市：").append(list.get(4)).append(session.newLine());
            message.append("编　码：").append(list.get(0)).append(session.newLine());
            message.append("区　号：").append(list.get(1)).append(session.newLine());
            message.append("所在地：").append(list.get(2)).append(' ').append(list.get(3)).append(session.newLine());
        }
        Control.appendPage(session, message);
        Control.appendCopy(session, message);
        session.send(message.toString());
    }
}
