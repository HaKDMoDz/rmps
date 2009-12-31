/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.m.help;

import rmp.irp.c.Control;

import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.IProcess;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.rmps.irp.m.IService;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 欢迎屏幕
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public class Help implements IService
{
    @Override
    public boolean wInit()
    {
        return true;
    }

    @Override
    public String getCode()
    {
        return "help";
    }

    @Override
    public String getName()
    {
        return "欢迎";
    }

    @Override
    public String getDescription()
    {
        return "您好，小木为您服务！";
    }

    @Override
    public void doInit(ISession session, IMessage message)
    {
        StringBuffer msg = new StringBuffer();
        doInit(session, msg);
        msg.append(session.newLine());
        doMenu(session, msg);

        session.getProcess().setType(IProcess.TYPE_KEYCODE);
        session.send(msg.toString());
    }

    @Override
    public void doMenu(ISession session, IMessage message)
    {
        StringBuffer msg = new StringBuffer();
        doMenu(session, msg);

        session.send(msg.toString());
    }

    @Override
    public void doHelp(ISession session, IMessage message)
    {
        StringBuffer msg = new StringBuffer();
        doHelp(session, msg);
        session.send(msg.toString());
    }

    @Override
    public void doDeal(ISession session, IMessage message)
    {
        StringBuffer msg = new StringBuffer();
        msg.append("小木目前能够为您提供以下服务：").append(session.newLine());
        doMenu(session, msg);

        // msg.append("0、我的应用").append(session.newLine());
        // msg.append("1、新闻资讯").append(session.newLine());
        // msg.append("2、生活服务").append(session.newLine());
        // msg.append("3、财经证券").append(session.newLine());
        // msg.append("4、在线办公").append(session.newLine());
        // msg.append("5、信息检索").append(session.newLine());
        // msg.append("6、休闲娱乐").append(session.newLine());
        // msg.append("7、科学教育").append(session.newLine());
        // msg.append("8、功能扩展").append(session.newLine());
        // msg.append("9、配置管理").append(session.newLine());

        if (session.getProcess().getType() == IProcess.TYPE_DEFAULT)
        {
            session.getProcess().setType(IProcess.TYPE_KEYCODE);
        }
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

    private void doInit(ISession session, StringBuffer message)
    {
        message.append("您好，小木为您服务！").append(session.newLine());
        message.append("　　小木致力于为您提供实用而又风格统一的服务，以满足您的日常生活、工作及学习所需，");
        message.append("目前小木的服务功能还在不断的开发与完善过程中，也希望您能提出宝贵的意见或建议！").append(session.newLine());
    }

    private void doHelp(ISession session, StringBuffer message)
    {
        message.append("您可以通过如下的方式使用此服务：").append(session.newLine());
        message.append("　　不同的服务，您只需要通过简单的数字键盘操作即可获得，并且提供了一些快捷键功能以方便您的使用：").append(session.newLine());
        message.append("*或＊ 显示服务的选择菜单；").append(session.newLine());
        message.append("?或？ 获取当前服务的帮助；").append(session.newLine());
        message.append(".或。 征服上一次信息录入；").append(session.newLine());
        message.append("/或／ 跳转到最顶层服务菜单；").append(session.newLine());
        message.append("..   跳转到上一层服务菜单；").append(session.newLine());
        message.append("数字  跳转到下一层服务菜单；").append(session.newLine());
        message.append("&    向作者汇报错误信息；").append(session.newLine());
        message.append("@    给作者留言；");
    }

    private void doMenu(ISession session, StringBuffer message)
    {
        IService serv;
        String func = session.getProcess().getFunc();
        for (int i = 0; i < 10; i += 1)
        {
            serv = Control.getService(func + i);
            if (serv != null)
            {
                message.append(func + i).append('、').append(serv.getName()).append(session.newLine());
            }
        }
        message.append("请输入对应的数字以选择您要使用的服务！");
    }
}
