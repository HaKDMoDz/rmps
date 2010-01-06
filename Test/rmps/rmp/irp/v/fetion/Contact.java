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
package rmp.irp.v.fetion;

import java.util.ArrayList;
import java.util.List;

import com.amonsoft.rmps.irp.b.ICatalog;
import com.amonsoft.rmps.irp.b.IContact;

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
    private String uri;
    private String id;
    private String name;
    private String email;
    private String display;
    private String personal;
    private List<ICatalog> catalogs = new ArrayList<ICatalog>();

    Contact()
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IContact#getId()
     */
    @Override
    public String getId()
    {
        return id;
    }

    /**
     * @param id
     */
    public void setId(String id)
    {
        this.id = id;
    }

    @Override
    public String getName()
    {
        return name;
    }

    /**
     * @param name
     */
    public void getName(String name)
    {
        this.name = name;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IContact#getDisplayName()
     */
    @Override
    public String getDisplayName()
    {
        return display;
    }

    /**
     * @param displayName
     */
    public void setDisplayName(String displayName)
    {
        this.display = displayName;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IContact#getEmail()
     */
    @Override
    public String getEmail()
    {
        return email;
    }

    /**
     * @param email
     */
    public void setEmail(String email)
    {
        this.email = email;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IContact#getGroups()
     */
    @Override
    public List<ICatalog> getCatalogs()
    {
        return catalogs;
    }

    /**
     * @param catalog
     */
    public void addCatalog(ICatalog catalog)
    {
        catalogs.add(catalog);
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IContact#getPersonalMessage()
     */
    @Override
    public String getPersonalMessage()
    {
        return personal;
    }

    /**
     * @param personalMessage
     */
    public void setPersonalMessage(String personalMessage)
    {
        this.personal = personalMessage;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IContact#getStatus()
     */
    @Override
    public String getStatus()
    {
        return null;
    }

    /**
     * @return
     */
    public String getUri()
    {
        return uri;
    }

    /**
     * @param uri
     */
    public void setUri(String uri)
    {
        this.uri = uri;
    }
}
