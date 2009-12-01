/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.v.ymsg;

import com.amonsoft.rmps.irp.v.IAccount;
import com.amonsoft.rmps.irp.v.IConnect;
import com.amonsoft.rmps.irp.b.IContact;
import com.amonsoft.rmps.irp.b.IStatus;
import java.awt.Toolkit;
import java.util.List;
import com.amonsoft.util.LogUtil;
import ymsg.network.event.SessionChatEvent;
import ymsg.network.event.SessionConferenceEvent;
import ymsg.network.event.SessionErrorEvent;
import ymsg.network.event.SessionEvent;
import ymsg.network.event.SessionExceptionEvent;
import ymsg.network.event.SessionFileTransferEvent;
import ymsg.network.event.SessionFriendEvent;
import ymsg.network.event.SessionListener;
import ymsg.network.event.SessionNewMailEvent;
import ymsg.network.event.SessionNotifyEvent;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class YMsg implements IAccount, SessionListener
{
    private Connect connect;
    private ymsg.network.Session messenger;
    private Session session;

    public YMsg()
    {
    }

    @Override
    public void exit()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public void sign(int status)
    {
        switch (status)
        {
            case IStatus.INIT:
                connect = new Connect();
                connect.load();
                break;
            case IStatus.LINE:
                try
                {
                    messenger = new ymsg.network.Session();
                    messenger.addSessionListener(this);

                    messenger.login(connect.getUser(), connect.getPwds());
                }
                catch (Exception exp)
                {
                    LogUtil.log(exp);
                }
                break;
            case IStatus.DOWN:
                try
                {
                    messenger.logout();
                }
                catch (Exception exp)
                {
                    LogUtil.exception(exp);
                }
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
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public List<IContact> getContact()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public void fileTransferReceived(SessionFileTransferEvent arg0)
    {
    }

    @Override
    public void connectionClosed(SessionEvent arg0)
    {
    }

    @Override
    public void listReceived(SessionEvent arg0)
    {
    }

    @Override
    public void messageReceived(SessionEvent arg0)
    {
        try
        {
            messenger.sendMessage(arg0.getFrom(), arg0.getMessage());
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
        try
        {
            messenger.sendChatMessage(arg0.getMessage());
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
    }

    @Override
    public void buzzReceived(SessionEvent arg0)
    {
        Toolkit.getDefaultToolkit().beep();
    }

    @Override
    public void offlineMessageReceived(SessionEvent arg0)
    {
    }

    @Override
    public void errorPacketReceived(SessionErrorEvent arg0)
    {
    }

    @Override
    public void inputExceptionThrown(SessionExceptionEvent arg0)
    {
    }

    @Override
    public void newMailReceived(SessionNewMailEvent arg0)
    {
    }

    @Override
    public void notifyReceived(SessionNotifyEvent arg0)
    {
    }

    @Override
    public void contactRequestReceived(SessionEvent arg0)
    {
    }

    @Override
    public void contactRejectionReceived(SessionEvent arg0)
    {
    }

    @Override
    public void conferenceInviteReceived(SessionConferenceEvent arg0)
    {
    }

    @Override
    public void conferenceInviteDeclinedReceived(SessionConferenceEvent arg0)
    {
    }

    @Override
    public void conferenceLogonReceived(SessionConferenceEvent arg0)
    {
    }

    @Override
    public void conferenceLogoffReceived(SessionConferenceEvent arg0)
    {
    }

    @Override
    public void conferenceMessageReceived(SessionConferenceEvent arg0)
    {
    }

    @Override
    public void friendsUpdateReceived(SessionFriendEvent arg0)
    {
    }

    @Override
    public void friendAddedReceived(SessionFriendEvent arg0)
    {
    }

    @Override
    public void friendRemovedReceived(SessionFriendEvent arg0)
    {
    }

    @Override
    public void chatLogonReceived(SessionChatEvent arg0)
    {
    }

    @Override
    public void chatLogoffReceived(SessionChatEvent arg0)
    {
    }

    @Override
    public void chatMessageReceived(SessionChatEvent arg0)
    {
    }

    @Override
    public void chatUserUpdateReceived(SessionChatEvent arg0)
    {
    }

    @Override
    public void chatConnectionClosed(SessionEvent arg0)
    {
    }

    @Override
    public void chatCaptchaReceived(SessionChatEvent arg0)
    {
    }
}
