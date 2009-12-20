/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.v.xmpp;

import com.amonsoft.rmps.irp.v.IAccount;
import com.amonsoft.rmps.irp.v.IConnect;
import com.amonsoft.rmps.irp.b.IContact;
import com.amonsoft.rmps.irp.b.IStatus;
import java.util.Collection;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import org.jivesoftware.smack.Chat;
import org.jivesoftware.smack.ChatManagerListener;
import org.jivesoftware.smack.ConnectionConfiguration;
import org.jivesoftware.smack.ConnectionListener;
import org.jivesoftware.smack.MessageListener;
import org.jivesoftware.smack.PacketListener;
import org.jivesoftware.smack.XMPPConnection;
import org.jivesoftware.smack.XMPPException;
import org.jivesoftware.smack.packet.Packet;
import org.jivesoftware.smack.packet.Presence;
import com.amonsoft.util.LogUtil;
import java.util.ArrayList;
import org.jivesoftware.smack.Roster;
import org.jivesoftware.smack.RosterEntry;
import org.jivesoftware.smack.RosterListener;
import org.jivesoftware.smack.SASLAuthentication;
import org.jivesoftware.smack.filter.PacketFilter;
import rmp.irp.c.Control;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class XMPP implements IAccount, ConnectionListener, PacketListener, RosterListener, MessageListener, ChatManagerListener
{
    protected IConnect connect;
    private XMPPConnection messenger;
    private Session session;

    public XMPP()
    {
        XMPPConnection.DEBUG_ENABLED = true;
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
                getConnect();
                break;
            case IStatus.LINE:
                try
                {
                    ConnectionConfiguration config = new ConnectionConfiguration(connect.getHost(), connect.getPort(), connect.getServer());
//                    config.setCompressionEnabled(true);
//                    config.setSASLAuthenticationEnabled(true);

                    messenger = new XMPPConnection(config);
                    messenger.connect();
                    SASLAuthentication.supportSASLMechanism("PLAIN", 0);
                    messenger.login(connect.getUser(), connect.getPwds());

                    Presence presence = new Presence(Presence.Type.available);
                    presence.setStatus("I'm Coming...");
                    messenger.sendPacket(presence);

                    PacketFilter filter = new PacketFilter()
                    {
                        @Override
                        public boolean accept(Packet arg0)
                        {
                            return true;
                        }
                    };
                    messenger.addConnectionListener(this);
                    messenger.addPacketListener(this, filter);

                    Roster roster = messenger.getRoster();
                    roster.setSubscriptionMode(Roster.SubscriptionMode.accept_all);
                    roster.addRosterListener(this);
//                    messenger.addPacketWriterListener(this, filter);

                    messenger.getChatManager().addChatListener(this);
//                    Chat chat = messenger.getChatManager().createChat("amon.hm@gmail.com", this);
//                    chat.sendMessage("haha");
                }
                catch (XMPPException exp)
                {
                    LogUtil.exception(exp);
                }
                break;

            case IStatus.AWAY:
                Presence presence = new Presence(Presence.Type.unavailable);
                presence.setStatus("Gone fishing");
                messenger.sendPacket(presence);
                break;

            case IStatus.DOWN:
                messenger.disconnect();
                break;
            default:
                break;
        }
    }

    @Override
    public IConnect getConnect()
    {
        if (connect == null)
        {
            connect = new Connect();
            connect.load();
        }
        return connect;
    }

    @Override
    public IContact getContact(String user)
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public List<IContact> getContact()
    {
        List<IContact> list = new ArrayList<IContact>();
        for (RosterEntry re : messenger.getRoster().getEntries())
        {
        }
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public void connectionClosed()
    {
        LogUtil.log("connectionClosed");
    }

    @Override
    public void connectionClosedOnError(Exception arg0)
    {
        LogUtil.log("connectionClosedOnError");
    }

    @Override
    public void reconnectingIn(int arg0)
    {
        LogUtil.log("reconnectingIn");
    }

    @Override
    public void reconnectionSuccessful()
    {
        LogUtil.log("reconnectionSuccessful");
    }

    @Override
    public void reconnectionFailed(Exception arg0)
    {
        LogUtil.log("reconnectionFailed");
    }

    @Override
    public void processMessage(Chat chat, org.jivesoftware.smack.packet.Message message)
    {
        LogUtil.log("processMessage");
        try
        {
            chat.sendMessage(message.getBody());
        }
        catch (XMPPException e)
        {
            LogUtil.exception(e);
        }
    }

    @Override
    public void processPacket(Packet packet)
    {
        LogUtil.log("processPacket：" + packet);
        if (packet instanceof Presence)
        {
            Presence p = (Presence) packet;  //shouldn't be a problem since we are filtering for presence packets.
            if (p.getType() == Presence.Type.available)
            {
                Control.getInstance().loginCompleted(session);
            }
            // only listen to presence requests
            if (p.getType() == Presence.Type.subscribe)
            {
                try
                {
                    messenger.getRoster().createEntry(p.getFrom(), p.getFrom(), null);
                    Control.getInstance().contactAddedMe();
                }
                catch (XMPPException exp)
                {
                    LogUtil.exception(exp);
                }
            }
            return;
        }

        if (packet instanceof org.jivesoftware.smack.packet.Message)
        {
            Control.getInstance().instantMessageReceived(session, new Message((org.jivesoftware.smack.packet.Message) packet));
            return;
        }
        Control.getInstance().unknownMessageReceived(session, new Message(null));
        System.out.println("rooooooo");
    }

    @Override
    public void chatCreated(Chat arg0, boolean arg1)
    {
        LogUtil.log("chatCreated");
    }

    @Override
    public void entriesAdded(Collection<String> clctn)
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public void entriesUpdated(Collection<String> clctn)
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public void entriesDeleted(Collection<String> clctn)
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public void presenceChanged(Presence prsnc)
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }
}
