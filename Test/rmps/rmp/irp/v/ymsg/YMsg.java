/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.v.ymsg;

import java.util.HashMap;
import java.util.List;

import org.openymsg.network.FireEvent;
import org.openymsg.network.ServiceType;
import org.openymsg.network.event.SessionEvent;
import org.openymsg.network.event.SessionListener;

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
public class YMsg implements IAccount, SessionListener
{
    private Connect connect;
    private org.openymsg.network.Session messenger;
    private HashMap<String, Session> sessions;

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
            case IPresence.INIT:
                sessions = new HashMap<String, Session>();
                connect = new Connect();
                connect.load();
                break;
            case IPresence.SIGN:
                try
                {
                    messenger = new org.openymsg.network.Session();
                    messenger.addSessionListener(this);
                    messenger.login(connect.getUser(), connect.getPwds());
                }
                catch (Exception exp)
                {
                    LogUtil.exception(exp);
                }
                break;
            case IPresence.DOWN:
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
        return null;
    }

    @Override
    public List<IContact> getContact()
    {
        return null;
    }

    @Override
    public void dispatch(FireEvent evt)
    {
        ServiceType type = evt.getType();
        SessionEvent event = evt.getEvent();
        if (ServiceType.MESSAGE == type)
        {
            Session session = getSession(event.getFrom());
            session.session = event;
            Control.getInstance().instantMessageReceived(session, new Message(event.getMessage()));
        }
    }

    private Session getSession(String name)
    {
        Session session = sessions.get(name);
        if (session == null)
        {
            session = new Session(messenger);
            sessions.put(name, session);
        }
        return session;
    }
}
