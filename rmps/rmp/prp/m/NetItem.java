/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.m;

import javax.swing.ImageIcon;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br />
 * TODO: 使用说明
 * </ul>
 * 
 * @author Amon
 */
public class NetItem
{
    private ImageIcon icon;
    private String href;
    private String name;
    private String title;
    private String vendor;
    private String description;

    /**
     * @return the href
     */
    public String getHref()
    {
        return href;
    }

    /**
     * @param href
     *            the href to set
     */
    public void setHref(String href)
    {
        this.href = href;
    }

    /**
     * @return the icon
     */
    public ImageIcon getIcon()
    {
        return icon;
    }

    /**
     * @param icon
     *            the icon to set
     */
    public void setIcon(ImageIcon icon)
    {
        this.icon = icon;
    }

    /**
     * @return the name
     */
    public String getName()
    {
        return name;
    }

    /**
     * @param name
     *            the name to set
     */
    public void setName(String name)
    {
        this.name = name;
    }

    /**
     * @return the title
     */
    public String getTitle()
    {
        return title;
    }

    /**
     * @param title
     *            the title to set
     */
    public void setTitle(String title)
    {
        this.title = title;
    }

    /**
     * @return the vendor
     */
    public String getVendor()
    {
        return vendor;
    }

    /**
     * @param vendor
     *            the vendor to set
     */
    public void setVendor(String vendor)
    {
        this.vendor = vendor;
    }

    /**
     * @return the description
     */
    public String getDescription()
    {
        return description;
    }

    /**
     * @param description
     *            the description to set
     */
    public void setDescription(String description)
    {
        this.description = description;
    }
}
