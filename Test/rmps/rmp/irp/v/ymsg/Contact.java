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
package rmp.irp.v.ymsg;

import java.util.List;

import com.amonsoft.rmps.irp.b.ICatalog;
import com.amonsoft.rmps.irp.b.IContact;
import com.amonsoft.rmps.irp.b.IPresence;

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
 * @author Administrator
 * 
 */
public class Contact implements IContact
{
    private String user;

    Contact()
    {
    }

    Contact(String user)
    {
        this.user = user;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IContact#getCatalogs()
     */
    @Override
    public List<ICatalog> getCatalogs()
    {
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
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IContact#getName()
     */
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
        return null;
    }
}
