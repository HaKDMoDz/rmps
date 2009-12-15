/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *    
 */
package rmp.irp.m.I9000000;

import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.rmps.irp.m.IService;
import rmp.irp.c.Control;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * TODO:
 * <li>使用说明：</li>
 * <br />
 * TODO:
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
        return "help";
    }

    @Override
    public String getDescription()
    {
        return "help";
    }

    @Override
    public void doInit(ISession session, IMessage message)
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
        Control.appendPath(session, msg);
        msg.append("1、我的应用").append(session.newLine());
        msg.append("2、生活服务").append(session.newLine());
        msg.append("3、网络工具").append(session.newLine());
        msg.append("4、信息检索").append(session.newLine());
        msg.append("5、休闲娱乐").append(session.newLine());
        msg.append("6、财务证券").append(session.newLine());
        msg.append("7、新闻资讯").append(session.newLine());
        msg.append("8、").append(session.newLine());
        msg.append("9、").append(session.newLine());
        msg.append("0、配置管理").append(session.newLine());
        Control.appendCopy(session, msg);
        session.send(msg.toString());
    }
}
