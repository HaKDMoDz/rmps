/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.v.uc;

import com.amonsoft.rmps.irp.v.IConnect;
import com.amonsoft.rmps.irp.b.IContact;
import com.amonsoft.rmps.irp.b.IStatus;
import com.amonsoft.rmps.irp.v.IAccount;

import java.util.List;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class UC implements IAccount
{
    private Connect connect;
    private Session session;

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
                break;
            case IStatus.DOWN:
                break;
            default:
                break;
        }
    }

    @Override
    public IConnect getConnect()
    {
        throw new UnsupportedOperationException("Not supported yet.");
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
}
