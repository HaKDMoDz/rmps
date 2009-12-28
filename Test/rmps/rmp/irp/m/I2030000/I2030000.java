/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.m.I2030000;

import java.io.File;
import java.util.HashMap;
import java.util.List;
import java.util.regex.Pattern;

import org.dom4j.Document;
import org.dom4j.DocumentHelper;
import org.dom4j.Element;
import org.dom4j.io.SAXReader;

import rmp.util.EnvUtil;

import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.IProcess;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.rmps.irp.m.IService;
import com.amonsoft.util.CharUtil;
import com.amonsoft.util.HttpUtil;
import com.amonsoft.util.LogUtil;

import cons.EnvCons;
import cons.irp.a.ConstUI;

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
            Element element = (Element) document.selectSingleNode("/irps/I2030000/item[@id='配置']/map[@key='path']");
            if (element != null)
            {
                path = element.getText();
            }
            element = (Element) document.selectSingleNode("/irps/I2030000/item[@id='配置']/map[@key='args']");
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
        return "52030000";
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
    public void doInit(ISession session, IMessage message)
    {
        session.send("请输入一个15或18号的身份证号码！");
        session.getProcess().setType(IProcess.TYPE_CONTENT);
        session.getProcess().setStep(IProcess.STEP_DEFAULT);
    }

    @Override
    public void doMenu(ISession session, IMessage message)
    {
        session.send("请输入一个15或18号的身份证号码，或输入服务代码切换其它服务！");
        session.getProcess().setType(IProcess.TYPE_KEYCODE);
    }

    @Override
    public void doHelp(ISession session, IMessage message)
    {
        session.send("服务信息完善中……");
    }

    @Override
    public void doDeal(ISession session, IMessage message)
    {
        try
        {
            String key = message.getContent();
            String tmp = key.trim();
            // 号码校验
            if (!idPtn.matcher(tmp).matches())
            {
                session.send("请输入一个15或18位身份证号！");
                return;
            }

            // 发起页面请求
            String xml = HttpUtil.request(path + '?' + CharUtil.format(args, key), "POST", "gb2312");
            int i = xml.indexOf("<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"fontcolor\">");
            int j = xml.indexOf("</table>", i) + 8;
            xml = xml.substring(i, j);
            LogUtil.log("返回结果：" + xml);
            Document doc = DocumentHelper.parseText(xml);

            // 处理结果并显示
            StringBuffer msg = new StringBuffer();
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
            session.send(msg.toString());

            // 设置下一次操作状态
            IProcess proc = session.getProcess();
            proc.setType(IProcess.TYPE_CONTENT);
            proc.setStep(IProcess.STEP_DEFAULT);
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);

            // 设置下一次操作状态
            session.getProcess().setType(IProcess.TYPE_CONTENT);
        }
    }

    public void doDeal0(ISession session, IMessage message)
    {
        try
        {
            String command = message.getContent();
            if (!CharUtil.isValidate(command))
            {
                command = "上海";
            }

            // 读取天气信息
            HashMap<Integer, String> dataList = rmp.prp.aide.P3090000.t.Util.getWeatherByCity(command);

            // 注册天气图标
            // message.registerEmoticon(ConstUI.P3090000_DAY11,
            // CharUtil.format(cons.prp.aide.P3090000.ConstUI.BG_ICON,
            // dataList.get(8)));
            // message.registerEmoticon(ConstUI.P3090000_DAY12,
            // CharUtil.format(cons.prp.aide.P3090000.ConstUI.BG_ICON,
            // dataList.get(9)));
            // message.registerEmoticon(ConstUI.P3090000_DAY21,
            // CharUtil.format(cons.prp.aide.P3090000.ConstUI.BG_ICON,
            // dataList.get(15)));
            // message.registerEmoticon(ConstUI.P3090000_DAY22,
            // CharUtil.format(cons.prp.aide.P3090000.ConstUI.BG_ICON,
            // dataList.get(16)));
            // message.registerEmoticon(ConstUI.P3090000_DAY31,
            // CharUtil.format(cons.prp.aide.P3090000.ConstUI.BG_ICON,
            // dataList.get(20)));
            // message.registerEmoticon(ConstUI.P3090000_DAY32,
            // CharUtil.format(cons.prp.aide.P3090000.ConstUI.BG_ICON,
            // dataList.get(21)));

            // 分段发送天气信息
            StringBuffer sb = new StringBuffer("\r\n");
            int idx = 0;
            while (idx < 11)
            {
                sb.append("ImsRobot.getMesg(ConstUI.P3090000_PRE + (idx + 500))");
                sb.append(dataList.get(idx)).append(ConstUI.NEXT_LINE);
                idx += 1;
            }

            // 向用户发送计算结果
            message.setContent(sb.toString());
            session.send(message);

            sb.delete(2, sb.length());
            while (idx < 12)
            {
                sb.append("ImsRobot.getMesg(ConstUI.P3090000_PRE + (idx + 500))");
                sb.append(dataList.get(idx)).append(ConstUI.NEXT_LINE);
                idx += 1;
            }

            // 向用户发送计算结果
            message.setContent(sb.toString());
            session.send(message);

            sb.delete(2, sb.length());
            while (idx < 22)
            {
                sb.append("ImsRobot.getMesg(ConstUI.P3090000_PRE + (idx + 500))");
                sb.append(dataList.get(idx)).append(ConstUI.NEXT_LINE);
                idx += 1;
            }

            // 向用户发送计算结果
            message.setContent(sb.toString());
            session.send(message);

            sb.delete(2, sb.length());
            while (idx < 23)
            {
                sb.append("ImsRobot.getMesg(ConstUI.P3090000_PRE + (idx + 500))");
                sb.append(dataList.get(idx)).append(ConstUI.NEXT_LINE);
                idx += 1;
            }

            // 向用户发送计算结果
            message.setContent(sb.toString());
            session.send(message);
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            try
            {
                session.send(exp.getMessage());
            }
            catch (Exception e)
            {
                LogUtil.exception(e);
            }
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
}
