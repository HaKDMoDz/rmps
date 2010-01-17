/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.m.I2030000;

import java.io.File;
import java.util.List;
import java.util.regex.Pattern;

import org.dom4j.Document;
import org.dom4j.DocumentHelper;
import org.dom4j.Element;
import org.dom4j.io.SAXReader;

import rmp.bean.K1SV1S;
import rmp.irp.c.Control;
import rmp.util.EnvUtil;
import rmp.util.LogUtil;

import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.IProcess;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.rmps.irp.m.IService;
import com.amonsoft.util.CharUtil;
import com.amonsoft.util.HttpUtil;

import cons.EnvCons;
import cons.irp.ConsEnv;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 身份查询
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public class I2030000 implements IService
{
    private static String path;
    private static String args;
    private static Pattern idPtn;

    @Override
    public boolean wInit()
    {
        try
        {
            Document document = new SAXReader().read(new File(EnvUtil.getDataPath(EnvCons.FOLDER1_IRP, getCode() + ".xml")));
            Element root = (Element) document.selectSingleNode("/irps/" + getCode());
            Element element = (Element) root.selectSingleNode("item[@id='配置']/map[@key='path']");
            if (element != null)
            {
                path = element.getText();
            }
            element = (Element) root.selectSingleNode("item[@id='配置']/map[@key='args']");
            if (element != null)
            {
                args = element.getText();
            }

            idPtn = Pattern.compile("^\\d{15}|\\d{17}[\\dxX]{1}$");
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
        return "I2030000";
    }

    @Override
    public String getName()
    {
        return "身份查询";
    }

    @Override
    public String getDescription()
    {
        return "全国公民身份信息查询！";
    }

    @Override
    public List<K1SV1S> getHelpTips()
    {
        return null;
    }

    @Override
    public void doInit(ISession session, IMessage message)
    {
        StringBuffer msg = new StringBuffer(session.newLine());
        doInit(session, msg);
        doHelp(session, msg.append(session.newLine()));
        msg.append(session.newLine()).append("请输入一个15或18号的身份证号码！").append(session.newLine());

        session.getProcess().setType(IProcess.TYPE_CONTENT);
        session.getProcess().setItem(IProcess.ITEM_DEFAULT);
        session.getProcess().setStep(IProcess.STEP_DEFAULT);
        session.send(msg.toString());
    }

    @Override
    public void doMenu(ISession session, IMessage message)
    {
        IProcess pro = session.getProcess();

        if (IProcess.ITEM_DEFAULT.equals(pro.getItem()))
        {
            StringBuffer msg = new StringBuffer(session.newLine());
            doMenu(session, msg);

            pro.setItem(Constant.ITEM_SUBMENU);
            session.send(msg.toString());
            return;
        }

        if (pro.setFunc(".."))
        {
            Control.getService(pro.getFunc()).doInit(session, message);
        }
    }

    @Override
    public void doHelp(ISession session, IMessage message)
    {
        StringBuffer msg = new StringBuffer(session.newLine());
        doHelp(session, msg);
        session.send(msg.toString());
    }

    @Override
    public void doDeal(ISession session, IMessage message)
    {
        String key = message.getContent();
        String tmp = key.trim();
        StringBuffer msg = new StringBuffer(session.newLine());
        IProcess pro = session.getProcess();

        try
        {
            // 用户输入选单
            if (ConsEnv.KEY_FUNC.equals(tmp))
            {
                doMenu(session, msg);

                pro.setItem(Constant.ITEM_SUBMENU);
                session.send(msg.toString());
                return;
            }

            // 选单交互过程
            if (!IProcess.ITEM_DEFAULT.equals(pro.getItem()))
            {
                // 返回服务选单
                if (ConsEnv.KEY_FUNC.equals(tmp))
                {
                    if (pro.setFunc(".."))
                    {
                        Control.getService(pro.getFunc()).doInit(session, message);
                    }
                }
                else
                {
                    pro.setItem(IProcess.ITEM_DEFAULT);
                    session.send(msg.append("请输入一个15或18位身份证号！").append(session.newLine()).toString());
                }
                return;
            }

            // 号码校验
            if (!idPtn.matcher(tmp).matches())
            {
                session.send(msg.append("请输入一个15或18位身份证号！").append(session.newLine()).toString());
                return;
            }

            // 发起页面请求
            String xml = HttpUtil.request(path + '?' + CharUtil.format(args, key), "POST", "gb2312", null);
            int i = xml.indexOf("<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"fontcolor\">");
            int j = xml.indexOf("</table>", i) + 8;
            xml = xml.substring(i, j);
            Document doc = DocumentHelper.parseText(xml);

            // 处理结果并显示
            List<?> l1 = doc.selectNodes("/table/tr");
            if (l1.size() == 4)
            {
                String[] title =
                { "发 证 地：", "出生日期：", "性　　别：", "18位号码：" };
                for (int t = 0; t < title.length; t += 1)
                {
                    List<?> l2 = ((Element) l1.get(t)).selectNodes("td");
                    if (l2.size() == 2)
                    {
                        msg.append(title[t]).append(((Element) l2.get(1)).getTextTrim()).append(session.newLine());
                    }
                }
            }

            // 设置下一次操作状态
            pro.setStep(IProcess.STEP_DEFAULT);
            session.send(msg.toString());
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);

            // 设置下一次操作状态
            pro.setType(IProcess.TYPE_CONTENT);
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

    @Override
    public void doRoot(ISession session, IMessage message)
    {
    }

    private StringBuffer doInit(ISession session, StringBuffer message)
    {
        message.append(CharUtil.format("欢迎使用《{0}》服务！", getName())).append(session.newLine());
        message.append(CharUtil.format("　　《{0}》服务目前支持15及18位身份证号码查询，并提供15位号码到18位号码的转换服务！", getName())).append(session.newLine());
        return message;
    }

    private StringBuffer doHelp(ISession session, StringBuffer message)
    {
        message.append("您可以通过如下的方式使用此服务：").append(session.newLine());
        message.append("　　1、直接输入您要查询的15或18位身份证号码；").append(session.newLine());
        return message;
    }

    private void doMenu(ISession session, StringBuffer message)
    {
        message.append(CharUtil.format("0、继续使用《{0}》服务；", getName())).append(session.newLine());
        message.append("*、返回上级服务选单；").append(session.newLine());
        message.append("请输入对应的数字选择您要使用的验证方法：").append(session.newLine());
    }
}
