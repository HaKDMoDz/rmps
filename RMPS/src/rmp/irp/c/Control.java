/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.c;

import com.amonsoft.rmps.irp.c.IControl;
import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.IProcess;
import com.amonsoft.rmps.irp.m.IService;
import com.amonsoft.rmps.irp.b.ISession;
import java.io.FileInputStream;
import java.util.HashMap;
import java.util.Properties;
import java.util.regex.Pattern;
import rmp.irp.m.root.Root;
import com.amonsoft.util.LogUtil;
import java.util.Iterator;
import rmp.util.StringUtil;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class Control implements IControl
{
    private static Control control;
    private static Properties command;
    private static HashMap<Integer, IService> services;
    private static Pattern keyReg;
    private static Pattern numReg;

    private Control()
    {
    }

    private synchronized void init()
    {
        try
        {
            // 提供服务加载
            services = new HashMap<Integer, IService>();
            command = new Properties();
            command.loadFromXML(new FileInputStream("dat/60000000/irp/irp.xml"));
            Iterator<String> sets = command.stringPropertyNames().iterator();
            String key;
            Object obj;
            while (sets.hasNext())
            {
                key = sets.next();
                obj = Class.forName(command.getProperty(key)).newInstance();
                if (obj instanceof IService)
                {
                    services.put(Integer.parseInt(key), (IService) obj);
                }
            }

            // 系统命令加载
            command.clear();
            command.loadFromXML(new FileInputStream("cfg/50000000.xml"));

            // 正则表达式
            StringBuffer reg = new StringBuffer("^[");
            sets = command.stringPropertyNames().iterator();
            while (sets.hasNext())
            {
                reg.append(sets.next());
            }
            keyReg = Pattern.compile(reg.append("]{1,2}$").toString());
            numReg = Pattern.compile("^\\d*[０１２３４５６７８９]*$");
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
    }

    /**
     * 
     * @return
     */
    public static IControl getInstance()
    {
        if (control == null)
        {
            control = new Control();
            control.init();
        }
        return control;
    }

    @Override
    public void loginCompleted(ISession session)
    {
    }

    @Override
    public void willLogout(ISession session)
    {
    }

    @Override
    public void instantMessageReceived(ISession session, IMessage message)
    {
        session.send();

        String msg = message.getContent();
        // 消息内容为空
        if (msg == null || msg.length() < 1)
        {
            session.send("无法确认您输入的内容，可不要考验阿木的智商哟！:)");
            return;
        }

        // 无意义消息文本
        if (msg.trim().length() < 1)
        {
            session.send(StringUtil.format("您好像只输入了 {0} 个空格，请问您想做什么？:-o", "" + msg.length()));
            return;
        }

        // 判断是否为管理人员
        boolean root = "amon.wk@live.com".equalsIgnoreCase(session.getContact().getEmail());
        // 管理人员处理方式
        if (root)
        {
            IService service = services.get(00000000);
            if (service == null)
            {
                service = new Root();
            }
            service.doDeal(session, message);
        }

        IProcess process = session.getProcess();
        if (process.getType() == IProcess.KEYCODE)
        {
            if (!keyReg.matcher(msg.trim()).matches())
            {
                showHelp(session);
                return;
            }
            msg = command.getProperty(msg, "");
            // 上级目录
            if ("..".equals(msg))
            {
                int func = process.getFunc();
                int step = process.getStep();
                func &= 0;

                return;
            }
            // 顶级目录
            if ("/".equals(msg))
            {
                return;
            }
            // 使用帮助
            if ("?".equals(msg))
            {
                showHelp(session);
                return;
            }
            // 问题汇报
            if ("#".equals(msg))
            {
                return;
            }
            // 发表留言
            if ("@".equals(msg))
            {
                return;
            }
            // 邀请作者
            if ("$".equals(msg))
            {
                return;
            }

            // 用户选择功能
            if (numReg.matcher(msg).matches())
            {
                int step = process.getFunc();
                step |= Integer.parseInt(msg);
            }
        }

        // 具体功能分析
        session.send(message);
    }

    @Override
    public void systemMessageReceived(ISession session, IMessage message)
    {
        LogUtil.log("systemMessageReceived:" + message.getContent());
    }

    @Override
    public void controlMessageReceived(ISession session, IMessage message)
    {
        LogUtil.log("controlMessageReceived:" + message.getContent());
    }

    @Override
    public void datacastMessageReceived(ISession session, IMessage message)
    {
        LogUtil.log("datacastMessageReceived:");
    }

    @Override
    public void unknownMessageReceived(ISession session, IMessage message)
    {
        LogUtil.log("unknownMessageReceived:");
    }

    @Override
    public void contactListInitCompleted(ISession session)
    {
        LogUtil.log("contactListInitCompleted:");
    }

    @Override
    public void contactListSyncCompleted(ISession session)
    {
        LogUtil.log("contactListSyncCompleted:");
    }

    @Override
    public void contactStatusChanged()
    {
        LogUtil.log("contactStatusChanged:");
    }

    @Override
    public void contactAddedMe()
    {
        LogUtil.log("contactAddedMe:");
    }

    @Override
    public void contactRemovedMe()
    {
        LogUtil.log("contactRemovedMe:");
    }

    @Override
    public void sessionClosed(ISession session)
    {
        LogUtil.log("switchboardClosed:");
    }

    @Override
    public void sessionOpened(ISession session)
    {
        StringBuffer msg = new StringBuffer();
        appendPath(session, msg);
        msg.append("1:").append(session.netLine());
        msg.append("2:").append(session.netLine());
        msg.append("3:").append(session.netLine());
        msg.append("4:").append(session.netLine());
        msg.append("5:").append(session.netLine());
        msg.append("6:").append(session.netLine());
        msg.append("7:").append(session.netLine());
        msg.append("8:").append(session.netLine());
        msg.append("9:").append(session.netLine());
        msg.append("0:使用帮助").append(session.netLine());
        msg.append(session.netLine());

        session.send(appendCopy(session, msg).toString());
    }

    @Override
    public void contactJoinMeeting()
    {
        LogUtil.log("contactJoinSwitchboard:");
    }

    @Override
    public void contactLeaveMeeting()
    {
        LogUtil.log("contactLeaveSwitchboard:");
    }

    /**
     * 显示使用帮助
     * @param session
     */
    private void showHelp(ISession session)
    {
        StringBuffer msg = new StringBuffer();
        appendPath(session, msg);
        msg.append("1、我的应用").append(session.netLine());
        msg.append("2、生活服务").append(session.netLine());
        msg.append("3、网络工具").append(session.netLine());
        msg.append("4、信息检索").append(session.netLine());
        msg.append("5、休闲娱乐").append(session.netLine());
        msg.append("6、财务证券").append(session.netLine());
        msg.append("7、新闻资讯").append(session.netLine());
        msg.append("8、").append(session.netLine());
        msg.append("9、").append(session.netLine());
        msg.append("0、配置管理").append(session.netLine());
        appendCopy(session, msg);
        session.send(msg.toString());
    }

    /**
     * 添加路径信息
     * @param session
     * @param message
     * @return
     */
    private StringBuffer appendPath(ISession session, StringBuffer message)
    {
        IProcess process = session.getProcess();
        message.append('/').append(process.getStep()).append(':');
        IService service = services.get(process.getFunc());
        if (service != null)
        {
            message.append(service.getName());
        }
        message.append(session.netLine()).append("------------------------------").append(session.netLine());
        return message;
    }

    /**
     * 添加版权信息
     * @param session
     * @param message
     * @return
     */
    public StringBuffer appendCopy(ISession session, StringBuffer message)
    {
        message.append(session.netLine()).append("------------------------------");
        message.append(session.netLine()).append("@ Amonsoft http://amonsoft.cn/");
        return message;
    }

    @Override
    public void exceptionCaught(ISession session)
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }
}
