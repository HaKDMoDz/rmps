/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.v.ymsg;

import java.io.File;
import java.io.IOException;
import java.util.logging.Level;
import java.util.logging.Logger;

import rmp.irp.comn.ASession;

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
    private ymsg.network.Session messenger;

    public Session(ymsg.network.Session messenger)
    {
        this.messenger = messenger;
    }

    @Override
    public void send()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public void send(String message)
    {
        try
        {
            messenger.sendChatMessage(message);
        }
        catch (IllegalStateException ex)
        {
            Logger.getLogger(Session.class.getName()).log(Level.SEVERE, null, ex);
        }
        catch (IOException ex)
        {
            Logger.getLogger(Session.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    @Override
    public void send(String message, boolean literal)
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public void send(IMessage message)
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public void send(IMessage message, boolean literal)
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public void send(IMimeMessage message)
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public void send(IMimeMessage message, boolean literal)
    {
    }

    @Override
    public void send(File file)
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public void reset()
    {
    }

    @Override
    public String newLine()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public IContact getContact()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public IMessage createMessage()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public IMimeMessage createMimeMessage()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public void setAttribute(String key, Object obj)
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public Object getAttribute(String key)
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }
}
