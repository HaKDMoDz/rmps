/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.imp.v.xmpp;

import com.amonsoft.rmps.imp.b.IContact;
import com.amonsoft.rmps.imp.b.IMessage;
import com.amonsoft.rmps.imp.b.IMimeMessage;
import java.io.File;
import java.util.logging.Level;
import java.util.logging.Logger;
import org.jivesoftware.smack.Chat;
import org.jivesoftware.smack.XMPPException;
import rmp.imp._comn.ASession;

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
    Chat chat;

    @Override
    public void send()
    {
    }

    @Override
    public void send(String message)
    {
        try
        {
            chat.sendMessage(message);
        }
        catch (XMPPException ex)
        {
            Logger.getLogger(Session.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    @Override
    public void send(IMessage message)
    {
        try
        {
            if (message instanceof Message)
            {
                chat.sendMessage(((Message) message).message);
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
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public void send(File file)
    {
        throw new UnsupportedOperationException("Not supported yet.");
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
        throw new UnsupportedOperationException("Not supported yet.");
    }
}
