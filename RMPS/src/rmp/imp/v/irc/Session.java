/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.imp.v.irc;

import com.amonsoft.rmps.imp.b.IContact;
import com.amonsoft.rmps.imp.b.IMessage;
import com.amonsoft.rmps.imp.b.IMimeMessage;
import java.io.File;
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
    @Override
    public void send()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public void send(String message)
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public void send(IMessage message)
    {
        throw new UnsupportedOperationException("Not supported yet.");
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
    public String netLine()
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
