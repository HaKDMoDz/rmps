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

import com.amonsoft.rmps.irp.b.ICatalog;

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
public class Catalog implements ICatalog
{
    private String id;
    private String name;

    public Catalog(String id, String name)
    {
        this.id = id;
        this.name = name;
    }

    @Override
    public String getId()
    {
        return id;
    }

    @Override
    public String getUri()
    {
        return "";
    }

    @Override
    public String getName()
    {
        return name;
    }

    public String toString()
    {
        return name;
    }
}
