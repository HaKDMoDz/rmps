/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.v.ymsg;

import java.io.File;

import rmp.irp.comn.ASession;
import rmp.util.LogUtil;

import com.amonsoft.rmps.irp.b.IContact;
import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.IMimeMessage;

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
public class Session extends ASession
{
    org.openymsg.network.Session messenger;
    org.openymsg.network.event.SessionEvent session;

    Session()
    {
    }

    Session(org.openymsg.network.Session messenger)
    {
        this.messenger = messenger;
    }

    @Override
    public void send()
    {
        try
        {
            messenger.sendTypingNotification(session.getFrom(), true);
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
    }

    @Override
    public void send(String message)
    {
        send(message, true);
    }

    @Override
    public void send(String message, boolean literal)
    {
        try
        {
            messenger.sendMessage(session.getFrom(), literal ? appendCopy(this, appendPath(this, new StringBuffer()).append(message)).toString() : message);
        }
        catch (Exception ex)
        {
            LogUtil.exception(ex);
        }
    }

    @Override
    public void send(IMessage message)
    {
    }

    @Override
    public void send(IMessage message, boolean literal)
    {
    }

    @Override
    public void send(File file)
    {
    }

    @Override
    public void reset()
    {
    }

    @Override
    public IContact getContact()
    {
        return new Contact(session.getFrom());
    }

    @Override
    public IMessage createMessage()
    {
        return null;
    }

    @Override
    public IMimeMessage createMimeMessage()
    {
        return null;
    }
}
