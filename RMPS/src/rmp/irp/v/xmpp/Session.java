/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.v.xmpp;

import com.amonsoft.rmps.irp.b.IContact;
import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.IMimeMessage;
import java.io.File;
import java.util.logging.Level;
import java.util.logging.Logger;
import org.jivesoftware.smack.Chat;
import org.jivesoftware.smack.XMPPException;
import rmp.irp.comn.ASession;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class Session extends ASession
{
    Chat session;

    @Override
    public void send()
    {
    }

    @Override
    public void send(String message)
    {
        try
        {
            session.sendMessage(message);
        }
        catch (XMPPException ex)
        {
            Logger.getLogger(Session.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    @Override
    public void send(String message, boolean useCopy)
    {
    }

    @Override
    public void send(IMessage message)
    {
        try
        {
            if (message instanceof Message)
            {
                session.sendMessage(((Message) message).message);
            }
        }
        catch (XMPPException ex)
        {
            Logger.getLogger(Session.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    @Override
    public void send(IMimeMessage message)
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
        return null;
    }

    @Override
    public IMessage createMessage()
    {
        return new Message(new org.jivesoftware.smack.packet.Message());
    }

    @Override
    public IMimeMessage createMimeMessage()
    {
        return null;
    }
}
