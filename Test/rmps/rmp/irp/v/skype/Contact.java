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

import rmp.irp.comn.AContact;

import com.amonsoft.rmps.irp.b.ICatalog;
import com.amonsoft.rmps.irp.b.IPresence;
import com.skype.Friend;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * TODO:
 * <li>使用说明：</li>
 * <br />
 * TODO:
 * </ul>
 * 
 * @author Amon
 * 
 */
public class Contact extends AContact
{
    Friend contact;

    Contact()
    {
    }

    Contact(Friend contact)
    {
        this.contact = contact;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IContact#getCatalogs()
     */
    @Override
    public List<ICatalog> getCatalogs()
    {
        // TODO Auto-generated method stub
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IContact#getDisplayName()
     */
    @Override
    public String getDisplayName()
    {
        // TODO Auto-generated method stub
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IContact#getEmail()
     */
    @Override
    public String getEmail()
    {
        // TODO Auto-generated method stub
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IContact#getId()
     */
    @Override
    public String getId()
    {
        // TODO Auto-generated method stub
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IContact#getName()
     */
    @Override
    public String getUser()
    {
        // TODO Auto-generated method stub
        return null;
    }

    @Override
    public String getName()
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IContact#getPersonalMessage()
     */
    @Override
    public String getPersonalMessage()
    {
        // TODO Auto-generated method stub
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IContact#getPresence()
     */
    @Override
    public IPresence getPresence()
    {
        // TODO Auto-generated method stub
        return null;
    }

}
