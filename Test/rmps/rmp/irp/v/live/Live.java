/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.v.live;

import java.util.HashMap;
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
import rmp.util.LogUtil;

import com.amonsoft.rmps.irp.b.IContact;
import com.amonsoft.rmps.irp.b.IPresence;
import com.amonsoft.rmps.irp.v.IAccount;
import com.amonsoft.rmps.irp.v.IConnect;

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
public class Live extends MsnAdapter implements IAccount
{
    private Connect connect;
    private MsnMessenger messenger;
    private HashMap<String, Session> sessions;

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
            case IPresence.INIT:
                try
                {
                    sessions = new HashMap<String, Session>();
                    connect = new Connect();
                    connect.load();
                }
                catch (Exception exp)
                {
                    LogUtil.exception(exp);
                }
                break;
            case IPresence.SIGN:

                messenger = MsnMessengerFactory.createMsnMessenger(connect.getUser(), connect.getPwds());
                messenger.setSupportedProtocol(new MsnProtocol[]
                { MsnProtocol.MSNP12, MsnProtocol.MSNP11, MsnProtocol.MSNP10, MsnProtocol.MSNP9, MsnProtocol.MSNP8 });
                // messenger.setLogIncoming(true);
                // messenger.setLogOutgoing(true);
                messenger.addListener(this);
                messenger.login();
                messenger.getOwner().setInitStatus(MsnUserStatus.ONLINE);
                // messenger.getOwner().setDisplayName("小木");
                // messenger.getOwner().getDisplayName();
                break;
            case IPresence.DOWN:
                messenger.logout();
                LogUtil.wExit();
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
        LogUtil.log("exceptionCaught:" + throwable.toString());
    }

    @Override
    public void loginCompleted(MsnMessenger messenger)
    {
        LogUtil.log("loginCompleted.");
    }

    @Override
    public void logout(MsnMessenger messenger)
    {
        LogUtil.log("logout.");
    }

    @Override
    public void instantMessageReceived(MsnSwitchboard switchboard, MsnInstantMessage message, MsnContact friend)
    {
        LogUtil.log("instantMessageReceived from " + friend.getEmail().getEmailAddress() + ':' + message.getContent());

        Session session = getSession(friend.getEmail().getEmailAddress());
        session.switchboard = switchboard;
        session.contact.contact = friend;
        Control.getInstance().instantMessageReceived(session, new Message(message));
    }

    @Override
    public void systemMessageReceived(MsnMessenger messenger, MsnSystemMessage message)
    {
        LogUtil.log("systemMessageReceived:" + message.getContent());

        Control.getInstance().systemMessageReceived(null, null);
    }

    @Override
    public void controlMessageReceived(MsnSwitchboard switchboard, MsnControlMessage message, MsnContact contact)
    {
        // LogUtil.log("controlMessageReceived:" + message.getContentType());
        //
        // session.switchboard = switchboard;
        // session.contact.contact = contact;
        // Control.getInstance().controlMessageReceived(session, null);
    }

    @Override
    public void datacastMessageReceived(MsnSwitchboard switchboard, MsnDatacastMessage message, MsnContact friend)
    {
        LogUtil.log("datacastMessageReceived from " + friend.getEmail().getEmailAddress() + ':' + message.getContentType());
        Session session = getSession(friend.getEmail().getEmailAddress());
        Control.getInstance().datacastMessageReceived(session, null);
    }

    @Override
    public void unknownMessageReceived(MsnSwitchboard switchboard, MsnUnknownMessage message, MsnContact friend)
    {
        LogUtil.log("unknownMessageReceived from " + friend.getEmail().getEmailAddress() + ':' + message.getContent());
    }

    @Override
    public void contactListInitCompleted(MsnMessenger messenger)
    {
        LogUtil.log("contactListInitCompleted.");
    }

    @Override
    public void contactListSyncCompleted(MsnMessenger messenger)
    {
        LogUtil.log("contactListSyncCompleted.");
    }

    @Override
    public void contactStatusChanged(MsnMessenger messenger, MsnContact friend)
    {
        LogUtil.log("contactStatusChanged from " + friend.getEmail().getEmailAddress());
    }

    @Override
    public void ownerStatusChanged(MsnMessenger messenger)
    {
        LogUtil.log("ownerStatusChanged.");
    }

    @Override
    public void contactAddedMe(MsnMessenger messenger, MsnContact friend)
    {
        messenger.addFriend(friend.getEmail(), "irps");
        Session session = getSession(friend.getEmail().getEmailAddress());
        Control.getInstance().contactAddedMe(session);
        LogUtil.log("contactAddedMe from " + friend.getEmail().getEmailAddress());
    }

    @Override
    public void contactRemovedMe(MsnMessenger messenger, MsnContact friend)
    {
        LogUtil.log("contactRemovedMe from " + friend.getEmail().getEmailAddress());
    }

    @Override
    public void switchboardClosed(MsnSwitchboard switchboard)
    {
        LogUtil.log("switchboardClosed.");
    }

    @Override
    public void switchboardStarted(MsnSwitchboard switchboard)
    {
        LogUtil.log("switchboardStarted.");
    }

    @Override
    public void contactJoinSwitchboard(MsnSwitchboard switchboard, MsnContact friend)
    {
        LogUtil.log("contactJoinSwitchboard from " + friend.getEmail().getEmailAddress());
    }

    @Override
    public void contactLeaveSwitchboard(MsnSwitchboard switchboard, MsnContact friend)
    {
        LogUtil.log("contactLeaveSwitchboard from " + friend.getEmail().getEmailAddress());
    }

    private Session getSession(String user)
    {
        Session session = sessions.get(user);
        if (session == null)
        {
            session = new Session();
            sessions.put(user, session);
        }
        return session;
    }
}
