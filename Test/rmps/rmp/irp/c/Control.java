/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.c;

import java.io.FileInputStream;
import java.util.HashMap;

import org.dom4j.Document;
import org.dom4j.Element;
import org.dom4j.io.SAXReader;

import rmp.irp.m.help.Help;
import rmp.irp.m.root.Root;
import rmp.util.EnvUtil;
import rmp.util.LogUtil;

import com.amonsoft.rmps.irp.b.IContact;
import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.IProcess;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.rmps.irp.c.IControl;
import com.amonsoft.rmps.irp.m.IService;
import com.amonsoft.util.CharUtil;

import cons.EnvCons;
import cons.irp.ConsEnv;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public class Control implements IControl
{
    private static Control control;
    private static HashMap<String, String> command;
    private static HashMap<String, String> manager;
    private static HashMap<String, IService> services;

    private Control()
    {
    }

    private synchronized void init()
    {
        try
        {
            LogUtil.log("IRPS：Control 初始化……");
            Document document = new SAXReader().read(new FileInputStream(EnvUtil.getDataPath(EnvCons.FOLDER1_IRP, "irps.xml")));

            Element ele;

            // 键盘映射
            LogUtil.log("IRPS：键盘映射加载……");
            command = new HashMap<String, String>();
            for (Object obj : document.selectNodes("/irps/item[@id='配置']/map"))
            {
                if (obj instanceof Element)
                {
                    ele = (Element) obj;
                    LogUtil.log(ele.attributeValue("key") + " - " + ele.getText());
                    command.put(ele.attributeValue("key"), ele.getText());
                }
            }

            // 管理账号
            LogUtil.log("IRPS：管理账号加载……");
            manager = new HashMap<String, String>();
            for (Object obj : document.selectNodes("/irps/item[@id='管理']/map"))
            {
                if (obj instanceof Element)
                {
                    ele = (Element) obj;
                    LogUtil.log("IRPS：" + ele.getText());
                    manager.put(ele.getText(), ele.attributeValue("key"));
                }
            }

            // 提供服务
            IService ims;
            services = new HashMap<String, IService>();
            LogUtil.log("IRPS：提供服务加载……");
            for (Object obj : document.selectNodes("/irps/item[@id='服务']/map"))
            {
                if (obj instanceof Element)
                {
                    ele = (Element) obj;
                    LogUtil.log(ele.getText());

                    obj = Class.forName(ele.getText()).newInstance();
                    if (obj instanceof IService)
                    {
                        ims = (IService) obj;
                        if (ims.wInit())
                        {
                            services.put(ele.attributeValue("key"), ims);
                        }
                    }
                }
            }

            // 基本功能
            Help help = new Help();
            help.wInit();
            services.put("", help);
            Root root = new Root();
            root.wInit();
            services.put("$", root);

            LogUtil.log("IRPS：Control 初始化成功！");
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
        // 发送正在输入状态
        session.send();

        String msg = message.getContent();
        // 消息内容为空
        if (msg == null || msg.length() < 1)
        {
            // session.send("无法确认您输入的内容，可不要考验阿木的智商哟！:)");
            return;
        }

        // 管理人员处理方式
        IContact contact = session.getContact();
        if (contact == null)
        {
            return;
        }

        IProcess process = session.getProcess();

        // 特殊命令转换
        String tmp = getCommand(msg);
        String email = contact.getEmail();
        if (CharUtil.isValidate(email))
        {
            if (manager.get(email.toLowerCase()) != null)
            {
                if ("$".equals(tmp))
                {
                    // IService service = services.get(00000000);
                    // if (service == null)
                    // {
                    // service = new Root();
                    // }
                    // service.doDeal(session, message);
                }
            }
        }

        // 优先处理命令
        if (tmp != null)
        {
            // 服务菜单
            if (ConsEnv.KEY_MENU.equals(tmp))
            {
                services.get(process.getFunc()).doMenu(session, message);
                return;
            }

            if ((process.getType() & IProcess.TYPE_NACTION) == 0)
            {
                // 重复输入
                if (ConsEnv.KEY_REDO.equals(tmp))
                {
                    if (session.read() != null)
                    {
                        message = session.read();
                        msg = message.getContent();
                        tmp = getCommand(msg);
                    }
                }

                // 显示菜单
                if (ConsEnv.KEY_FUNC.equals(tmp))
                {
                    if (process.setFunc(".."))
                    {
                        services.get(process.getFunc()).doInit(session, message);
                    }
                    return;
                }
                // 使用帮助
                if (ConsEnv.KEY_HELP.equals(tmp))
                {
                    services.get(process.getFunc()).doHelp(session, message);
                    return;
                }
                // 问题汇报
                if (ConsEnv.KEY_BUGS.equals(tmp))
                {
                    services.get("").doInit(session, message);
                    return;
                }
                // 发表留言
                if (ConsEnv.KEY_IDEA.equals(tmp))
                {
                    services.get("").doInit(session, message);
                    return;
                }
                // 邀请作者
                if (ConsEnv.KEY_AMON.equals(tmp))
                {
                    services.get("").doInit(session, message);
                    return;
                }
            }
        }

        // 记录上次输入
        session.save(message);

        // 功能选择事件
        if ((process.getType() & IProcess.TYPE_KEYCODE) != 0)
        {
            if (process.setFunc(msg.trim()))
            {
                // 选择功能初始化
                services.get(process.getFunc()).doInit(session, message);
                return;
            }

            // 判断是否继续
            if (process.getType() <= IProcess.TYPE_KEYCODE)
            {
                services.get(process.getFunc()).doDeal(session, message);
                return;
            }
        }

        // 命令录入事件
        if ((process.getType() & IProcess.TYPE_COMMAND) != 0)
        {
            if (">".equals(tmp))
            {
                process.setStep(process.getStep() + 1);
                services.get(process.getFunc()).doStep(session, message);
                return;
            }

            if ("<".equals(tmp))
            {
                process.setStep(process.getStep() - 1);
                services.get(process.getFunc()).doStep(session, message);
                return;
            }

            if (">>".equals(tmp))
            {
                process.setStep(process.getMost() - 1);
                services.get(process.getFunc()).doStep(session, message);
                return;
            }

            if ("<<".equals(tmp))
            {
                process.setStep(0);
                services.get(process.getFunc()).doStep(session, message);
                return;
            }

            // 自定义命令
            // services.get(process.getFunc()).doDeal(session, message);

            // 判断是否继续
            if (process.getType() <= IProcess.TYPE_COMMAND)
            {
                return;
            }
        }

        // 内容输入事件
        if ((process.getType() & IProcess.TYPE_CONTENT) != 0)
        {
            services.get(process.getFunc()).doDeal(session, message);
            return;
        }

        // 容错处理
        services.get(IProcess.FUNC_DEFAULT).doDeal(session, message);
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
    public void contactPresenceChanged(ISession session)
    {
        LogUtil.log("contactStatusChanged:");
    }

    @Override
    public void contactAddedMe(ISession session)
    {
        session.send("您好，小木为您服务！");
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
        IService serv = services.get(IProcess.FUNC_DEFAULT);
        if (serv != null)
        {
            serv.doInit(session, null);
        }
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

    @Override
    public void exceptionCaught(ISession session)
    {
    }

    /**
     * 获取给定的服务对象
     * 
     * @param code
     * @return
     */
    public static IService getService(String code)
    {
        return services != null ? services.get(code) : null;
    }

    /**
     * 获取影射键盘
     * 
     * @param code
     * @return
     */
    public static String getCommand(String code)
    {
        return command.get(code);
    }

    /**
     * 
     * @param session
     * @param message
     * @return
     */
    public static StringBuffer appendPage(ISession session, StringBuffer message)
    {
        IProcess proc = session.getProcess();
        message.append(session.newLine()).append(CharUtil.format("〖第 {0}/{1} 页 <<首页 <前页 >后页 >>尾页〗", proc.getStep() + 1, proc.getMost()));
        return message;
    }
    //
    // private boolean processSpecial()
    // {
    // return true;
    // }
    //
    // private boolean processKeycode()
    // {
    // return true;
    // }
    //
    // private boolean processCommand()
    // {
    // return true;
    // }
    //
    // private boolean processContent()
    // {
    // return true;
    // }
}
