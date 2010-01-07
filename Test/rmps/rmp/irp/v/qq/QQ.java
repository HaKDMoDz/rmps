/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.v.qq;

import java.util.List;

import rmp.irp.v.live.Connect;
import rmp.irp.v.live.Session;

import com.amonsoft.rmps.irp.b.IContact;
import com.amonsoft.rmps.irp.b.ISession;
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
public class QQ implements IAccount
{
    private IConnect connect;
    private ISession session;
    private JQQ messenger;

    public QQ()
    {
    }

    @Override
    public void sign(int status)
    {
        switch (status)
        {
            case IPresence.INIT:
                connect = new Connect();
                connect.load();
                session = new Session();
                messenger = new JQQ(connect);
                break;
            case IPresence.SIGN:
                messenger.signIn();
                break;
            case IPresence.LINE:
                break;
            case IPresence.DOWN:
                break;
            default:
                break;
        }
    }

    @Override
    public void exit()
    {
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
}
