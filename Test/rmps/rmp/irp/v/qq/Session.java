/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.v.qq;

import java.io.File;

import rmp.irp.comn.ASession;

import com.amonsoft.rmps.irp.b.IContact;
import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.IMimeMessage;

import edu.tsinghua.lumaqq.qq.QQClient;

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
    QQClient messenger;

    @Override
    public void send()
    {
    }

    @Override
    public void send(String message)
    {
        messenger.im_Send(0, message.getBytes());
    }

    @Override
    public void send(String message, boolean literal)
    {
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
    public void send(IMimeMessage message)
    {
    }

    @Override
    public void send(IMimeMessage message, boolean literal)
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
        return null;
    }

    @Override
    public IMimeMessage createMimeMessage()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }
}
