/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.m.help;

import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.IProcess;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.rmps.irp.m.IService;
import rmp.irp.c.Control;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 欢迎屏幕
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author yihaodian
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
        session.send("kakaka");
        session.getProcess().setType(IProcess.TYPE_KEYCODE);
    }

    @Override
    public void doMenu(ISession session, IMessage message)
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
        session.send(msg.toString());
    }

    @Override
    public void doHelp(ISession session, IMessage message)
    {
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
//        msg.append("0、我的应用").append(session.newLine());
//        msg.append("1、新闻资讯").append(session.newLine());
//        msg.append("2、生活服务").append(session.newLine());
//        msg.append("3、财经证券").append(session.newLine());
//        msg.append("4、在线办公").append(session.newLine());
//        msg.append("5、信息检索").append(session.newLine());
//        msg.append("6、休闲娱乐").append(session.newLine());
//        msg.append("7、科学教育").append(session.newLine());
//        msg.append("8、功能扩展").append(session.newLine());
//        msg.append("9、配置管理").append(session.newLine());
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
