/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.m.I7010000;

import java.io.File;
import java.util.List;
import java.util.regex.Pattern;

import org.dom4j.Document;
import org.dom4j.DocumentHelper;
import org.dom4j.Element;
import org.dom4j.io.SAXReader;

import rmp.util.EnvUtil;
import rmp.util.LogUtil;

import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.IProcess;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.rmps.irp.m.IService;
import com.amonsoft.util.CharUtil;
import com.amonsoft.util.HttpUtil;

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
        return "ＩＰ查询";
    }

    @Override
    public String getDescription()
    {
        return "ＩＰ查询";
    }

    @Override
    public void doInit(ISession session, IMessage message)
    {
        StringBuffer msg = new StringBuffer();
        doInit(session, msg);
        msg.append(session.newLine());
        doHelp(session, msg);

        session.getProcess().setType(IProcess.TYPE_KEYCODE | IProcess.TYPE_CONTENT);
        session.getProcess().setStep(IProcess.STEP_DEFAULT);
        session.send(msg.toString());
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

            // 地址校验
            if (!v4Ptn.matcher(tmp).matches())
            {
                session.send("您输入的IP地址不是一个合适的IPV4地址，请重新输入！");
                return;
            }

            // 页面数据请求
            String xml = HttpUtil.request(path + '?' + CharUtil.format(args, tmp), "GET", "gb2312");
            if (!CharUtil.isValidate(xml))
            {
                return;
            }

            StringBuffer msg = new StringBuffer();
            msg.append("IP地址：").append(tmp).append(session.newLine());

            int i = xml.indexOf("<ul onmouseup=\"javascript:callclip(cresult);\">");
            int j = xml.indexOf("</ul>", i) + 5;
            int m = xml.indexOf("<li style=\"margin-top:-16px;margin-left:-12px;\">");
            int n = xml.indexOf("</div>", m);
            Document doc = DocumentHelper.parseText(xml.substring(i, j).replace("&nbsp;", " "));
            List<?> l = doc.selectNodes("/ul/li");
            Element e;
            if (l.size() > 2)
            {
                tmp = ((Element) l.get(2)).getText();
                String[] arr = tmp.split(" ");
                msg.append("国家地区：").append(arr[1]).append(session.newLine());
                msg.append("运 营 商：").append(arr[2]).append(session.newLine());
            }
            else
            {
                msg.append("国家地区：").append(session.newLine());
                msg.append("运 营 商：").append(session.newLine());
            }

            doc = DocumentHelper.parseText("<ul>" + xml.substring(m, n) + "</ul>");
            for (Object o : doc.selectNodes("/ul/li"))
            {
                e = (Element) o;
                msg.append(e.getText()).append(session.newLine());
            }

            // 设置下一次操作状态
            IProcess process = session.getProcess();
            process.setType(IProcess.TYPE_CONTENT);
            session.send(msg.toString());
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

    @Override
    public void doRoot(ISession session, IMessage message)
    {
    }

    private void doInit(ISession session, StringBuffer message)
    {
        message.append("欢迎使用《ＩＰ查询》服务！").append(session.newLine());
        message.append("　　ＩＰ查询目前支持国内及国外的IP地址查询，并且支持IPv4地IPv6地址的转换。").append(session.newLine());
    }

    private void doHelp(ISession session, StringBuffer message)
    {
        message.append("您可以通过如下的方式使用此服务：").append(session.newLine());
        message.append("　　1、直接输入您的查询的IPv4地址：如127.0.0.1；").append(session.newLine());
        message.append("　　2、输入您要查询的网站域名：如www.amonsoft.com；").append(session.newLine());
    }
}
