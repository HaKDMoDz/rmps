/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *    
 */
package rmp.irp.m.I2020000;

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

import rmp.bean.K1SV1S;
import rmp.irp.c.Control;
import rmp.util.EnvUtil;
import rmp.util.LogUtil;

import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.IProcess;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.rmps.irp.m.IService;
import com.amonsoft.util.CharUtil;

import cons.EnvCons;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 邮政编码
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
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
            paPtn = Pattern.compile("(\\[')(.*?)('\\])");
            piPtn = Pattern.compile("'(.*?)'");

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
        return "I2020000";
    }

    @Override
    public String getName()
    {
        return "邮政编码";
    }

    @Override
    public String getDescription()
    {
        return "邮政编码查询";
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

        session.getProcess().setType(IProcess.TYPE_KEYCODE | IProcess.TYPE_CONTENT);
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
        msg.append("您可以进行以下操作：").append(session.newLine());
        msg.append("<或《 向上翻页").append(session.newLine());
        msg.append("<<或《《 向上翻页").append(session.newLine());
        msg.append(">或》 向下翻页").append(session.newLine());
        msg.append(">>或》》 向下翻页").append(session.newLine());
        msg.append("?或？ 显示使用帮助；").append(session.newLine());
        msg.append("*或＊ 显示服务菜单；").append(session.newLine());
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
            // 地址校验
            if (!CharUtil.isValidate(tmp))
            {
                session.send(msg.append("请输入您要查询的国家、地区或城市的名称或拼音！").append(session.newLine()).toString());
                return;
            }

            // 链接地址初始化
            URL url = new URL(path + '?' + CharUtil.format(args, key));
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

            // 设置下一次操作状态
            pro.setType(IProcess.TYPE_KEYCODE | IProcess.TYPE_COMMAND | IProcess.TYPE_CONTENT);
            pro.setStep(IProcess.STEP_DEFAULT);
            pro.setMost(list.size());
            session.setAttribute(getCode() + "_m", list);

            if (list.size() < 1)
            {
                session.send(msg.append("请输入您要查询的国家、地区或城市的名称或拼音！").append(session.newLine()).toString());
            }
            else
            {
                // 发送结果信息
                showData(session, list.get(pro.getStep()));
            }
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);

            // 设置下一次操作状态
            pro.setType(IProcess.TYPE_KEYCODE | IProcess.TYPE_CONTENT);
        }
    }

    @Override
    public void doStep(ISession session, IMessage message)
    {
        StringBuffer msg = new StringBuffer(session.newLine());
        IProcess pro = session.getProcess();

        List<?> list = (List<?>) session.getAttribute(getCode() + "_m");
        if (list == null || list.size() < 1)
        {
            session.getProcess().setType(IProcess.TYPE_KEYCODE | IProcess.TYPE_CONTENT);
            pro.setStep(IProcess.STEP_DEFAULT);
            session.send(msg.append("请输入您要查询的国家、地区或城市的名称或拼音！").append(session.newLine()).toString());
            return;
        }

        int step = pro.getStep();
        if (step <= -1)
        {
            pro.setStep(IProcess.STEP_DEFAULT);
            session.send(msg.append("已经是第一页！").append(session.newLine()).toString());
            return;
        }

        if (step >= pro.getMost())
        {
            pro.setStep(pro.getMost());
            session.send(msg.append("已经是最后一页！").append(session.newLine()).toString());
            return;
        }

        session.getProcess().setType(IProcess.TYPE_KEYCODE | IProcess.TYPE_COMMAND | IProcess.TYPE_CONTENT);
        showData(session, "" + list.get(step));
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

    private StringBuffer doMenu(ISession session, StringBuffer message)
    {
        message.append(CharUtil.format("0、继续使用《{0}》服务；", getName())).append(session.newLine());
        message.append("*、返回上级服务选单；").append(session.newLine());
        return message;
    }

    private void showData(ISession session, String data)
    {
        StringBuffer message = new StringBuffer();

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
        session.send(Control.appendPage(session, message).toString());
    }
}
