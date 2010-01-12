/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.m.I2060000;

import java.io.File;
import java.util.ArrayList;
import java.util.Calendar;
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
    /**
     * 帮助
     */
    private static List<K1SV1S> htList;

    @Override
    public boolean wInit()
    {
        try
        {
            dtPtn = Pattern.compile("\\d{0,4}\\-(0?[1-9]|1[012])(\\-(0?[1-9]|[12][0-9]|3[01]))?");
            htList = new ArrayList<K1SV1S>();
            htList.add(new K1SV1S("<<", "上一年"));
            htList.add(new K1SV1S("<", "上一月"));
            htList.add(new K1SV1S(">", "下一月"));
            htList.add(new K1SV1S(">>", "下一年"));

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
        return "I2060000";
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
    public List<K1SV1S> getHelpTips()
    {
        return htList;
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
        String txt = message.getContent();
        String tmp = Control.getCommand(txt.trim());
        StringBuffer msg = new StringBuffer(session.newLine());
        IProcess pro = session.getProcess();

        // 命令处理
        if (CharUtil.isValidate(tmp))
        {
            if (ConsEnv.KEY_MENU.equals(tmp))
            {
                if (IProcess.ITEM_DEFAULT.equals(pro.getItem()))
                {
                    doMenu(session, msg);
                    pro.setItem(Constant.ITEM_SUBMENU);

                    session.send(msg.toString());
                }
                else if (pro.setFunc(".."))
                {
                    Control.getService(pro.getFunc()).doInit(session, message);
                }
                return;
            }
            if ("<<".equals(tmp))
            {
                tmp = (String) session.getAttribute(getCode() + Constant.SESSION_YEAR);
                int y = (CharUtil.isValidateInteger(tmp) ? Integer.parseInt(tmp) : Calendar.getInstance().get(Calendar.YEAR)) - 1;
                session.setAttribute(getCode() + Constant.SESSION_YEAR, Integer.toString(y));
            }
            else if ("<".equals(tmp))
            {
                tmp = (String) session.getAttribute(getCode() + Constant.SESSION_MONTH);
                int m = (CharUtil.isValidateInteger(tmp) ? Integer.parseInt(tmp) : Calendar.getInstance().get(Calendar.MONTH)) - 1;
                session.setAttribute(getCode() + Constant.SESSION_MONTH, Integer.toString(m));
            }
            else if (">".equals(tmp))
            {
                tmp = (String) session.getAttribute(getCode() + Constant.SESSION_MONTH);
                int m = (CharUtil.isValidateInteger(tmp) ? Integer.parseInt(tmp) : Calendar.getInstance().get(Calendar.MONTH)) + 1;
                session.setAttribute(getCode() + Constant.SESSION_MONTH, Integer.toString(m));
            }
            else if (">>".equals(tmp))
            {
                tmp = (String) session.getAttribute(getCode() + Constant.SESSION_YEAR);
                int y = (CharUtil.isValidateInteger(tmp) ? Integer.parseInt(tmp) : Calendar.getInstance().get(Calendar.YEAR)) - 1;
                session.setAttribute(getCode() + Constant.SESSION_YEAR, Integer.toString(y));
            }
            else
            {
                session.send(msg.append("暂不支持您输入的命令！").append(session.newLine()).toString());
                return;
            }
        }
        else
        {
            // 日期处理
            tmp = txt.replaceAll("\\s+", "").replace("/", "-").replace(".", "-");
            if (!dtPtn.matcher(tmp).matches())
            {
                session.send(msg.append("无法读取您输入的日期格式，请按如下格式输入：2010-01或2010-01-01").append(session.newLine()).toString());
                return;
            }

            String[] arr = tmp.split("-");
            if (arr.length > 0)
            {
                session.setAttribute(getCode() + Constant.SESSION_YEAR, arr[0]);
                if (arr.length > 1)
                {
                    session.setAttribute(getCode() + Constant.SESSION_MONTH, arr[1]);
                    if (arr.length > 2)
                    {
                        session.setAttribute(getCode() + Constant.SESSION_DAY, arr[2]);
                    }
                }
            }
        }

        ReadDataM(session, msg);
        session.send(msg.toString());
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
        message.append(CharUtil.format("　　《{0}》服务目前支持1900-2500年之间任意年份的农历信息查询！", getName())).append(session.newLine());
        return message;
    }

    private StringBuffer doHelp(ISession session, StringBuffer message)
    {
        message.append("您可以通过如下的方式使用此服务：").append(session.newLine());
        message.append("　　1、直接输入指定年月信息，查看月历：如2010-01-01；").append(session.newLine());
        message.append("　　2、使用<<或>>进行年份切换；").append(session.newLine());
        message.append("　　3、使用<或>进行月份切换；").append(session.newLine());
        return message;
    }

    private void doMenu(ISession session, StringBuffer message)
    {
        message.append(CharUtil.format("0、继续使用《{0}》服务；", getName())).append(session.newLine());
        message.append("*、返回上级服务选单；").append(session.newLine());
        message.append("请输入对应的数字选择您要使用的验证方法：").append(session.newLine());
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
            String data = HttpUtil.request(CharUtil.format(path + '?' + args, "", "", "", ""), "GET", "UTF-8", null);
            Document document = DocumentHelper.parseText(data);
            Element date = (Element) document.selectSingleNode("amonsoft/date");
            String days = date.attributeValue("count");
            if (!CharUtil.isValidateInteger(days))
            {
                // message.append(message.append("系统处理错误！").append(session.newLine()));
                // return;
            }
            String week = date.selectSingleNode("week").getText();
            if (!CharUtil.isValidateInteger(week))
            {
                message.append(message.append("系统处理错误！").append(session.newLine()));
                return;
            }
            int t1 = Integer.parseInt(week);
            int t2 = 30;// Integer.parseInt(days);

            // 前置空格
            StringBuffer tmp1 = new StringBuffer(" ");
            StringBuffer tmp2 = new StringBuffer(" ");
            for (int i = 0; i < t1; i += 1)
            {
                tmp1.append("　　　");
                tmp2.append("　　　");
            }

            // 日期数据
            for (int d = 1; d <= t2; d += 1)
            {
                tmp1.append('　');
                if (d < 10)
                {
                    tmp1.append(' ');
                }
                tmp1.append(d).append('　');
                tmp2.append(date.selectSingleNode(CharUtil.format("day[@id='{0}']", d)).getText()).append('　');

                t1 += 1;
                if (t1 % 7 == 0)
                {
                    message.append(tmp1.toString()).append(session.newLine());
                    message.append(tmp2.toString()).append(session.newLine());
                    tmp1.delete(1, tmp1.length());
                    tmp2.delete(1, tmp2.length());
                }
            }
            if (tmp1.length() > 0)
            {
                message.append(tmp1.toString()).append(session.newLine());
                message.append(tmp2.toString()).append(session.newLine());
            }
            message.append(date.attributeValue("value")).append(session.newLine());
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
    public static void ReadDateD(ISession session, StringBuffer message)
    {
    }
}
