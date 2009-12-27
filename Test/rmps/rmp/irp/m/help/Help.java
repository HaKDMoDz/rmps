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
    private static String init;
    private static String menu;
    private static String help;

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
        if (init == null)
        {
            StringBuffer msg = new StringBuffer();
            msg.append("您好，小木为您服务！");
            init = msg.toString();
        }
        session.send(init);
        session.getProcess().setType(IProcess.TYPE_KEYCODE);
    }

    @Override
    public void doMenu(ISession session, IMessage message)
    {
        if (menu == null)
        {
            StringBuffer msg = new StringBuffer();
            String func = session.getProcess().getFunc();
            IService serv;
            for (int i = 0; i < 10; i += 1)
            {
                serv = Control.getService(func + i);
                if (serv != null)
                {
                    msg.append(func + i).append('、').append(serv.getName()).append(session.newLine());
                }
            }
            msg.append("您可以通过数字键0-9选择您要进行的操作！");
            menu = msg.toString();
        }
        session.send(menu);
    }

    @Override
    public void doHelp(ISession session, IMessage message)
    {
        if (help == null)
        {
            StringBuffer msg = new StringBuffer();
            msg.append("您只要通过数字键即可以获得小木为您提供的所有服务！").append(session.newLine());
            msg.append("并且在使用的过程，为您提供以下的快捷键功能：").append(session.newLine());
            msg.append("?或？ 获取当前服务的帮助信息；").append(session.newLine());
            msg.append("*或＊ 显示当前服务的选项菜单；").append(session.newLine());
            msg.append("/或／ 跳转到最顶层服务菜单；").append(session.newLine());
            msg.append("..   跳转到上一层服务菜单；").append(session.newLine());
            msg.append("数字  跳转到下一层服务菜单；").append(session.newLine());
            //msg.append("#数字 选择当前服务的功能选项；").append(session.newLine());
            msg.append("&    向作者汇报错误信息；").append(session.newLine());
            msg.append("@    给作者留言；");
            help = msg.toString();
        }
        session.send(help);
    }

    @Override
    public void doDeal(ISession session, IMessage message)
    {
        StringBuffer msg = new StringBuffer();
        String func = session.getProcess().getFunc();
        IService serv;
        for (int i = 0; i < 10; i += 1)
        {
            serv = Control.getService(func + i);
            if (serv != null)
            {
                msg.append(func + i).append('、').append(serv.getName()).append(session.newLine());
            }
        }
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
        session.send(msg.toString());

        session.getProcess().setType(IProcess.TYPE_KEYCODE);
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
