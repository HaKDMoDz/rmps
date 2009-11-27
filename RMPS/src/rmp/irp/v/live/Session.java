/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.v.live;

import com.amonsoft.rmps.irp.b.IContact;
import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.IMimeMessage;
import java.io.File;
import net.sf.jml.MsnMessenger;
import net.sf.jml.MsnSwitchboard;
import net.sf.jml.message.MsnControlMessage;
import net.sf.jml.message.MsnInstantMessage;
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
    MsnMessenger messenger;
    MsnSwitchboard switchboard;
    Contact contact = new Contact();
    MsnControlMessage writing;

    @Override
    public void send()
    {
        if (writing == null)
        {
            writing = new MsnControlMessage();
        }
        switchboard.sendMessage(writing);
    }

    @Override
    public void send(String text)
    {
        switchboard.sendText(text);
    }

    @Override
    public void send(IMessage message)
    {
        if (message instanceof Message)
        {
            switchboard.sendMessage(((Message) message).message);
        }
    }

    @Override
    public void send(IMimeMessage message)
    {
    }

    @Override
    public void send(File file)
    {
        switchboard.sendFile(file);
    }

    @Override
    public IContact getContact()
    {
        return contact;
    }

    @Override
    public IMessage createMessage()
    {
        return new Message(new MsnInstantMessage());
    }

    @Override
    public IMimeMessage createMimeMessage()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }
}
