/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.v.live;

import com.amonsoft.rmps.irp.v.IAccount;
import com.amonsoft.rmps.irp.v.IConnect;
import com.amonsoft.rmps.irp.b.IContact;
import com.amonsoft.rmps.irp.b.IStatus;
import cons.irp.ConsEnv;
import java.io.PrintWriter;
import java.util.Date;
import java.util.List;
import net.sf.jml.MsnContact;
import net.sf.jml.MsnMessenger;
import net.sf.jml.MsnProtocol;
import net.sf.jml.MsnSwitchboard;
import net.sf.jml.MsnUserStatus;
import net.sf.jml.event.MsnAdapter;
import net.sf.jml.impl.MsnMessengerFactory;
import net.sf.jml.message.MsnControlMessage;
import net.sf.jml.message.MsnDatacastMessage;
import net.sf.jml.message.MsnInstantMessage;
import net.sf.jml.message.MsnSystemMessage;
import net.sf.jml.message.MsnUnknownMessage;
import rmp.irp.c.Control;
import rmp.util.Logs;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class Live extends MsnAdapter implements IAccount
{
    private Connect connect;
    private MsnMessenger messenger;
    private Session session;
    private PrintWriter printer;

    public Live()
    {
    }

    @Override
    public void exit()
    {
    }

    @Override
    public void sign(int status)
    {
        switch (status)
        {
            case IStatus.INIT:
                try
                {
                    connect = new Connect();
                    connect.load();

                    session = new Session();
                    printer = Logs.getLog(ConsEnv.IM_LIVE, connect.getMail(), "abc");
                }
                catch (Exception exp)
                {
                }
                break;
            case IStatus.LINE:

                messenger = MsnMessengerFactory.createMsnMessenger(connect.getUser(), connect.getPwds());
                messenger.setSupportedProtocol(new MsnProtocol[]
                        {
                            MsnProtocol.MSNP12,
                            MsnProtocol.MSNP11,
                            MsnProtocol.MSNP10,
                            MsnProtocol.MSNP9,
                            MsnProtocol.MSNP8
                        });
                // messenger.setLogIncoming(true);
                // messenger.setLogOutgoing(true);
                messenger.addListener(this);
                messenger.login();
                messenger.getOwner().setInitStatus(MsnUserStatus.ONLINE);
                //messenger.getOwner().setDisplayName("Amon");
                messenger.getOwner().getDisplayName();
                break;
            case IStatus.DOWN:
                messenger.logout();
                printer.flush();
                printer.close();
                break;
            default:
                break;
        }
    }

    @Override
    public IConnect getConnect()
    {
        return connect;
    }

    @Override
    public IContact getContact(String user)
    {
        return null;
    }

    @Override
    public List<IContact> getContact()
    {
        MsnContact[] cons = messenger.getContactList().getContacts();
        for (MsnContact con : cons)
        {
            System.out.println(con.getDisplayName());
            System.out.println(con.getEmail());
            System.out.println(con.getStatus());
            System.out.println(con.getPersonalMessage());
        }
        return null;
    }

    @Override
    public void exceptionCaught(MsnMessenger messenger, Throwable throwable)
    {
        printer.print(new Date());
        printer.println(throwable);
    }

    @Override
    public void loginCompleted(MsnMessenger messenger)
    {
        printer.print(new Date());
        printer.println("loginCompleted.");

        Control.getInstance().loginCompleted(session);
    }

    @Override
    public void logout(MsnMessenger messenger)
    {
        printer.print(new Date());
        printer.println("logout.");

        Control.getInstance().willLogout(session);
    }

    @Override
    public void instantMessageReceived(MsnSwitchboard switchboard, MsnInstantMessage message, MsnContact friend)
    {
        printer.print(new Date());
        printer.print("instantMessageReceived - ");
        printer.println(friend.getEmail());
        printer.println(message);

        session.switchboard = switchboard;
        session.contact.contact = friend;
        if ("~".equals(message.getContent()))
        {
            sign(IStatus.DOWN);
        }
        Control.getInstance().instantMessageReceived(session, new Message(message));
    }

    @Override
    public void systemMessageReceived(MsnMessenger messenger, MsnSystemMessage message)
    {
        printer.print(new Date());
        printer.print("systemMessageReceived - ");
        printer.println(message);

        session.messenger = messenger;
        Control.getInstance().systemMessageReceived(session, null);
    }

    @Override
    public void controlMessageReceived(MsnSwitchboard switchboard, MsnControlMessage message, MsnContact contact)
    {
        printer.print(new Date());
        printer.println("controlMessageReceived");
        printer.println(message);

        session.switchboard = switchboard;
        session.contact.contact = contact;
        Control.getInstance().controlMessageReceived(session, null);
    }

    @Override
    public void datacastMessageReceived(MsnSwitchboard switchboard, MsnDatacastMessage message, MsnContact friend)
    {
        printer.print(new Date());
        printer.print("datacastMessageReceived - ");
        printer.println(friend.getEmail());
        printer.println(message);

        Control.getInstance().datacastMessageReceived(session, null);
    }

    @Override
    public void unknownMessageReceived(MsnSwitchboard switchboard, MsnUnknownMessage message, MsnContact friend)
    {
        printer.print(new Date());
        printer.print("unknownMessageReceived - ");
        printer.println(friend.getEmail());
        printer.println(message);

    }

    @Override
    public void contactListInitCompleted(MsnMessenger messenger)
    {
        printer.print(new Date());
        printer.println("contactListInitCompleted.");
    }

    @Override
    public void contactListSyncCompleted(MsnMessenger messenger)
    {
        printer.print(new Date());
        printer.println("contactListSyncCompleted.");
    }

    @Override
    public void contactStatusChanged(MsnMessenger messenger, MsnContact friend)
    {
        printer.print(new Date());
        printer.print("contactStatusChanged - ");
        printer.println(friend.getEmail());
    }

    @Override
    public void ownerStatusChanged(MsnMessenger messenger)
    {
        printer.print(new Date());
        printer.println("ownerStatusChanged.");
    }

    @Override
    public void contactAddedMe(MsnMessenger messenger, MsnContact friend)
    {
        printer.print(new Date());
        printer.print("contactAddedMe - ");
        printer.println(friend.getEmail());
    }

    @Override
    public void contactRemovedMe(MsnMessenger messenger, MsnContact friend)
    {
        printer.print(new Date());
        printer.print("contactRemovedMe - ");
        printer.println(friend.getEmail());
    }

    @Override
    public void switchboardClosed(MsnSwitchboard switchboard)
    {
        printer.print(new Date());
        printer.println("switchboardClosed.");
    }

    @Override
    public void switchboardStarted(MsnSwitchboard switchboard)
    {
        printer.print(new Date());
        printer.println("switchboardStarted.");
    }

    @Override
    public void contactJoinSwitchboard(MsnSwitchboard switchboard, MsnContact friend)
    {
        printer.print(new Date());
        printer.print("contactJoinSwitchboard - ");
        printer.println(friend.getEmail());
    }

    @Override
    public void contactLeaveSwitchboard(MsnSwitchboard switchboard, MsnContact friend)
    {
        printer.print(new Date());
        printer.print("contactLeaveSwitchboard - ");
        printer.println(friend.getEmail());
    }
}
