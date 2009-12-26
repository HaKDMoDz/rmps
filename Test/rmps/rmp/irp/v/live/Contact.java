/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.v.live;

import net.sf.jml.MsnContact;

import com.amonsoft.rmps.irp.b.ICatalog;
import com.amonsoft.rmps.irp.b.IContact;

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
public class Contact implements IContact
{
    MsnContact contact;

    @Override
    public String getDisplayName()
    {
        return contact.getDisplayName();
    }

    @Override
    public String getEmail()
    {
        return contact.getEmail().getEmailAddress();
    }

    @Override
    public String getStatus()
    {
        return contact.getStatus().getStatus();
    }

    @Override
    public String getPersonalMessage()
    {
        return contact.getPersonalMessage();
    }

    @Override
    public ICatalog[] getGroups()
    {
        return null;
    }
}
