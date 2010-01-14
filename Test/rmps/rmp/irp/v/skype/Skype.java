/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
/*
 * 
 */
package rmp.irp.v.skype;

import java.util.List;

import com.amonsoft.rmps.irp.b.IContact;
import com.amonsoft.rmps.irp.v.IAccount;
import com.amonsoft.rmps.irp.v.IConnect;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * Skype
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 * 
 */
public class Skype implements IAccount
{
    @Override
    public void exit()
    {
    }

    @Override
    public void sign(int status)
    {
    }

    @Override
    public IConnect getConnect()
    {
        return null;
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
