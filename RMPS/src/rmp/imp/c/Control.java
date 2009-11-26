/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.imp.c;

import com.amonsoft.rmps.imp.c.IControl;
import com.amonsoft.rmps.imp.b.IMessage;
import com.amonsoft.rmps.imp.b.IProcess;
import com.amonsoft.rmps.imp.m.IService;
import com.amonsoft.rmps.imp.b.ISession;
import java.io.FileInputStream;
import java.io.IOException;
import java.util.Enumeration;
import java.util.HashMap;
import java.util.Properties;
import java.util.logging.Level;
import java.util.logging.Logger;
import java.util.regex.Pattern;
import rmp.imp.m.root.Root;
import rmp.util.Logs;
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
    private static HashMap<String, IService> services;
    private static Pattern keyReg;

    private Control()
    {
    }

    private synchronized void init()
    {
        try
        {
            command = new Properties();
            command.loadFromXML(new FileInputStream("dat/cfg.xml"));

            StringBuffer reg = new StringBuffer("^[");
            Enumeration<?> enums = command.propertyNames();
            while (enums.hasMoreElements())
            {
                reg.append(enums.nextElement());
            }
            keyReg = Pattern.compile(reg.append("]{1,2}$").toString());

            services = new HashMap<String, IService>();
        }
        catch (IOException ex)
        {
            Logger.getLogger(Control.class.getName()).log(Level.SEVERE, null, ex);
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

        IProcess step = session.getProcess();
        if (step.getType() == IProcess.KEYCODE)
        {
            if (!keyReg.matcher(msg.trim()).matches())
            {
                return;
            }
            // 空白信息
            if (msg.trim().length() < 1)
            {
                session.send("空白信息。。。");
                return;
            }
            msg = command.getProperty(msg, "");
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
        }

        if ("amon.wk@live.com".equalsIgnoreCase(session.getContact().getEmail()))
        {
            IService service = services.get("");
            if (service == null)
            {
                service = new Root();
            }
            service.doDeal(session, message);
        }

        // 具体功能分析
        session.send(message);
    }

    @Override
    public void systemMessageReceived(ISession session, IMessage message)
    {
        Logs.log("systemMessageReceived:" + message.getContent());
    }

    @Override
    public void controlMessageReceived(ISession session, IMessage message)
    {
        Logs.log("controlMessageReceived:" + message.getContent());
    }

    @Override
    public void datacastMessageReceived(ISession session, IMessage message)
    {
        Logs.log("datacastMessageReceived:");
    }

    @Override
    public void unknownMessageReceived(ISession session, IMessage message)
    {
        Logs.log("unknownMessageReceived:");
    }

    @Override
    public void contactListInitCompleted(ISession session)
    {
        Logs.log("contactListInitCompleted:");
    }

    @Override
    public void contactListSyncCompleted(ISession session)
    {
        Logs.log("contactListSyncCompleted:");
    }

    @Override
    public void contactStatusChanged()
    {
        Logs.log("contactStatusChanged:");
    }

    @Override
    public void contactAddedMe()
    {
        Logs.log("contactAddedMe:");
    }

    @Override
    public void contactRemovedMe()
    {
        Logs.log("contactRemovedMe:");
    }

    @Override
    public void sessionClosed(ISession session)
    {
        Logs.log("switchboardClosed:");
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
        Logs.log("contactJoinSwitchboard:");
    }

    @Override
    public void contactLeaveMeeting()
    {
        Logs.log("contactLeaveSwitchboard:");
    }

    /**
     * 显示使用帮助
     * @param session
     */
    private void showHelp(ISession session)
    {
        StringBuffer msg = new StringBuffer();
        appendPath(session, msg);
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
