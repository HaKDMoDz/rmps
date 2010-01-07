/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.v.xmpp;

import java.util.ArrayList;
import java.util.Collection;
import java.util.HashMap;
import java.util.List;

import org.jivesoftware.smack.Chat;
import org.jivesoftware.smack.ChatManagerListener;
import org.jivesoftware.smack.ConnectionConfiguration;
import org.jivesoftware.smack.ConnectionListener;
import org.jivesoftware.smack.MessageListener;
import org.jivesoftware.smack.PacketListener;
import org.jivesoftware.smack.Roster;
import org.jivesoftware.smack.RosterEntry;
import org.jivesoftware.smack.RosterListener;
import org.jivesoftware.smack.SASLAuthentication;
import org.jivesoftware.smack.XMPPConnection;
import org.jivesoftware.smack.XMPPException;
import org.jivesoftware.smack.filter.PacketFilter;
import org.jivesoftware.smack.packet.Packet;
import org.jivesoftware.smack.packet.Presence;
import org.jivesoftware.smack.packet.RosterPacket;

import rmp.irp.c.Control;
import rmp.util.LogUtil;

import com.amonsoft.rmps.irp.b.IContact;
import com.amonsoft.rmps.irp.b.IPresence;
import com.amonsoft.rmps.irp.v.IAccount;
import com.amonsoft.rmps.irp.v.IConnect;
import com.amonsoft.util.CharUtil;

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
public class XMPP implements IAccount, ConnectionListener, PacketListener, RosterListener, MessageListener, ChatManagerListener
{
    protected IConnect connect;
    private XMPPConnection messenger;
    private HashMap<String, Session> sessions;

    public XMPP()
    {
        // XMPPConnection.DEBUG_ENABLED = true;
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
                getConnect();
                sessions = new HashMap<String, Session>();
                break;
            case IPresence.SIGN:
                try
                {
                    ConnectionConfiguration config = new ConnectionConfiguration(connect.getHost(), connect.getPort(), connect.getServer());
                    // config.setCompressionEnabled(true);
                    // config.setSASLAuthenticationEnabled(true);

                    messenger = new XMPPConnection(config);
                    messenger.connect();
                    SASLAuthentication.supportSASLMechanism("PLAIN", 0);
                    messenger.login(connect.getUser(), connect.getPwds());

                    Presence presence = new Presence(Presence.Type.available);
                    presence.setStatus("小木为您服务！");
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
                    // messenger.addPacketWriterListener(this, filter);

                    messenger.getChatManager().addChatListener(this);
                    // Chat chat =
                    // messenger.getChatManager().createChat("amon.hm@gmail.com",
                    // this);
                    // chat.sendMessage("haha");
                }
                catch (XMPPException exp)
                {
                    LogUtil.exception(exp);
                }
                break;

            case IPresence.AWAY:
                Presence presence = new Presence(Presence.Type.unavailable);
                presence.setStatus("Gone fishing");
                messenger.sendPacket(presence);
                break;

            case IPresence.DOWN:
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
            list.add(new Contact(re));
        }
        return list;
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
    }

    @Override
    public void processPacket(Packet packet)
    {
        String user = packet.getFrom();
        Session session = sessions.get(user);
        if (session == null)
        {
            session = new Session();
            sessions.put(user, session);
        }

        if (packet instanceof org.jivesoftware.smack.packet.Message)
        {
            org.jivesoftware.smack.packet.Message message = (org.jivesoftware.smack.packet.Message) packet;
            LogUtil.log("XMPP: processPacket:Message－(" + user + ")" + message.getBody());

            if (session.session == null)
            {
                user = getUser(user);
                session.session = messenger.getChatManager().createChat(user, this);
                Contact contact = new Contact(messenger.getRoster().getEntry(user));
                session.contact = contact;
            }
            Control.getInstance().instantMessageReceived(session, new Message(message));
            return;
        }

        if (packet instanceof Presence)
        {
            Presence presence = (Presence) packet;
            LogUtil.log("XMPP: processPacket:Presence－" + presence.getType().name());

            if (presence.getType() == Presence.Type.available)
            {
                Control.getInstance().loginCompleted(session);
            }

            if (presence.getType() == Presence.Type.subscribe)
            {
                try
                {
                    messenger.getRoster().createEntry(presence.getFrom(), presence.getFrom(), null);
                    Control.getInstance().contactAddedMe(session);
                }
                catch (XMPPException exp)
                {
                    LogUtil.exception(exp);
                }
            }
            return;
        }

        if (packet instanceof org.jivesoftware.smack.packet.RosterPacket)
        {
            LogUtil.log("XMPP: processPacket:RosterPacket");
            RosterPacket rp = (org.jivesoftware.smack.packet.RosterPacket) packet;
            for (org.jivesoftware.smack.packet.RosterPacket.Item item : rp.getRosterItems())
            {
                LogUtil.log(item.getUser());
            }
            return;
        }

        LogUtil.log("XMPP: processPacket:unknownMessage");
        Control.getInstance().unknownMessageReceived(session, new Message(null));
    }

    @Override
    public void chatCreated(Chat arg0, boolean arg1)
    {
        LogUtil.log("chatCreated:" + arg1);
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

    private String getUser(String from)
    {
        if (CharUtil.isValidate(from))
        {
            int i = from.indexOf('/');
            if (i > 0)
            {
                from = from.substring(0, i);
            }
        }
        return from;
    }
}
