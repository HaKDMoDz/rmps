/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.v.sip;

import java.io.File;

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
}
