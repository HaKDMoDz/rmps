/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.v.dict;

import com.amonsoft.rmps.irp.b.IContact;
import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.IMimeMessage;
import com.amonsoft.rmps.irp.b.IProcess;
import java.io.File;
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
    public void send(String message, boolean useCopy)
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
    public Object getAttribute(String key)
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public void setAttribute(String key, Object obj)
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public IProcess getProcess()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }
}
