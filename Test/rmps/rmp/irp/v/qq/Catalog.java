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
package rmp.irp.v.qq;

import com.amonsoft.rmps.irp.b.ICatalog;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Administrator
 * 
 */
public class Catalog implements ICatalog
{
    private String id;
    private String name;
    private int online;

    Catalog()
    {
    }

    Catalog(String id, String name)
    {
        this.id = id;
        this.name = name;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.ICatalog#getId()
     */
    @Override
    public String getId()
    {
        return id;
    }

    public void setId(String id)
    {
        this.id = id;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.ICatalog#getName()
     */
    @Override
    public String getName()
    {
        return name;
    }

    public void setName(String name)
    {
        this.name = name;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.ICatalog#getUri()
     */
    @Override
    public String getUri()
    {
        return "";
    }

    public int getOnline()
    {
        return online;
    }

    public void setOnline(int online)
    {
        this.online = online;
    }
}
