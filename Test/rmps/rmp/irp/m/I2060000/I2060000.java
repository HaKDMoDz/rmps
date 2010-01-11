/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.m.I2060000;

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
 * 迷你日历
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public class I2060000 implements IService
{
    private static String path;
    private static String args;
    private static Pattern dtPtn;

    @Override
    public boolean wInit()
    {
        try
        {
            dtPtn = Pattern.compile("\\d{0,4}\\-(0?[1-9]|1[012])\\-(0?[1-9]|[12][0-9]|3[01])");
            Document document = new SAXReader().read(new File(EnvUtil.getDataPath(EnvCons.FOLDER1_IRP, getCode() + ".xml")));
            Element element = (Element) document.selectSingleNode("/irps/I2060000/item[@id='配置']/map[@key='path']");
            if (element != null)
            {
                path = element.getText();
            }
            element = (Element) document.selectSingleNode("/irps/I2060000/item[@id='配置']/map[@key='args']");
            if (element != null)
            {
                args = element.getText();
            }
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
        return true;
    }

    @Override
    public String getCode()
    {
        return "52060000";
    }

    @Override
    public String getName()
    {
        return "迷你日历";
    }

    @Override
    public String getDescription()
    {
        return "";
    }

    @Override
    public void doInit(ISession session, IMessage message)
    {
        StringBuffer msg = new StringBuffer(session.newLine());
        doInit(session, msg);
        doHelp(session, msg.append(session.newLine()));

        ReadDataM(session, msg);

        session.getProcess().setType(IProcess.TYPE_CONTENT);
        session.getProcess().setItem(IProcess.ITEM_DEFAULT);
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
        message.append("　　1、直接输入您要查询的国家、地区或城市的名字：如上海；").append(session.newLine());
        message.append("　　2、输入您要查询的国家、地区或城市的拼音：如shanghai；").append(session.newLine());
        message.append("　　3、输入您要查询的国家、地区或城市的拼音首字母：如sh；").append(session.newLine());
        return message;
    }

    /**
     * 读取指定月份
     * 
     * @param session
     * @param message
     */
    private void ReadDataM(ISession session, StringBuffer message)
    {
        try
        {
            StringBuffer tmp1 = new StringBuffer(path);
            tmp1.append("?y=").append(session.getAttribute(getCode() + Constant.SESSION_YEAR));
            tmp1.append("&m=").append(session.getAttribute(getCode() + Constant.SESSION_MONTH));

            String data = HttpUtil.request(tmp1.toString(), "GET", "UTF-8", null);
            Document document = DocumentHelper.parseText(data);
            Element date = (Element) document.selectSingleNode("amonsoft/date");
            String week = date.attributeValue("week");
            if (!CharUtil.isValidateInteger(week))
            {
                message.append("系统处理错误！");
                return;
            }
            List<?> days = date.selectNodes("day");
            if (days == null || days.size() < 1)
            {
                message.append("系统处理错误！");
                return;
            }
            int t1 = Integer.parseInt(week);
            int t2 = days.size();

            // 前置空格
            tmp1.delete(0, tmp1.length());
            StringBuffer tmp2 = new StringBuffer();
            for (int i = 0; i < t1; i += 1)
            {
                tmp1.append("      ");
                tmp2.append(" 　　 ");
            }

            // 日期数据
            for (int i = 0; i < t2; i += 1)
            {
                tmp1.append(' ');
                if (i < 10)
                {
                    tmp1.append(' ');
                }
                tmp1.append(i).append(' ');
                tmp2.append(' ').append(date.selectSingleNode("").getText()).append(' ');
                t1 += 1;
                if (t1 % 7 == 0)
                {
                    message.append(tmp1.toString()).append(session.newLine());
                    message.append(tmp2.toString()).append(session.newLine());
                    tmp1.delete(0, tmp1.length());
                    tmp2.delete(0, tmp2.length());
                }
            }
            message.append(tmp1.toString()).append(session.newLine());
            message.append(tmp2.toString()).append(session.newLine());
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
    }

    /**
     * 读取指定日期
     * 
     * @param session
     * @param message
     */
    private static void ReadDateD(ISession session, StringBuffer message)
    {
    }
}
