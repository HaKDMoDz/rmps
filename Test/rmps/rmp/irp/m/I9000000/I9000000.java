/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *    
 */
package rmp.irp.m.I9000000;

import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.IProcess;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.rmps.irp.m.IService;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 配置管理
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public class I9000000 implements IService
{
    @Override
    public boolean wInit()
    {
        return true;
    }

    @Override
    public String getCode()
    {
        return "59000000";
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
        session.getProcess().setType(IProcess.TYPE_KEYCODE);
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
        StringBuffer msg = new StringBuffer();
        msg.append("0、我的应用").append(session.newLine());
        msg.append("1、新闻资讯").append(session.newLine());
        msg.append("2、生活服务").append(session.newLine());
        msg.append("3、财经证券").append(session.newLine());
        msg.append("4、在线办公").append(session.newLine());
        msg.append("5、信息检索").append(session.newLine());
        msg.append("6、休闲娱乐").append(session.newLine());
        msg.append("7、科学教育").append(session.newLine());
        msg.append("8、功能扩展").append(session.newLine());
        msg.append("9、配置管理").append(session.newLine());
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

    @Override
    public void doRoot(ISession session, IMessage message)
    {
    }
}
