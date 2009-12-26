/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.v.xmpp;

import org.jivesoftware.smack.RosterEntry;

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
    private RosterEntry contact;

    public Contact(RosterEntry contact)
    {
        this.contact = contact;
    }

    @Override
    public String getDisplayName()
    {
        return contact.getName();
    }

    @Override
    public String getEmail()
    {
        return contact.getUser();
    }

    @Override
    public String getStatus()
    {
        return contact.getStatus().toString();
    }

    @Override
    public String getPersonalMessage()
    {
        return "";
    }

    @Override
    public ICatalog[] getGroups()
    {
        return null;
    }
}
