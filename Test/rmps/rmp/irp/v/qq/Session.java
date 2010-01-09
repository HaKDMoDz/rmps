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
    Contact contact;
    int qq;

    @Override
    public void send()
    {
    }

    @Override
    public void send(String message)
    {
        send(message, true);
    }

    @Override
    public void send(String message, boolean literal)
    {
        if (literal)
        {
            message = appendCopy(this, appendPath(this, new StringBuffer()).append(message)).toString();
        }
        messenger.im_Send(contact.friend.qqNum, message.getBytes());
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
        return contact;
    }

    @Override
    public IMessage createMessage()
    {
        return new Message();
    }

    @Override
    public IMimeMessage createMimeMessage()
    {
        return null;
    }
}
