/*
 * FileName:       PropItem.java
 * CreateDate:     2008-2-29 下午11:11:51
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.P30F0000.b;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br>
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br>
 * TODO: 使用说明
 * </ul>
 * <p>
 * 版本： RMPS V1.0.0.0
 * </p>
 * <p>
 * 作者： Amon
 * </p>
 * <p>
 * 日期： 2008-2-29 下午11:11:51
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class PropItem
{
    /** 记录类别 */
    private int    type;
    /** 记录名称 */
    private String name;
    /** 记录内容 */
    private String data;

    /**
     * 
     */
    public PropItem()
    {
    }

    /**
     * @param type
     */
    public PropItem(int type)
    {
        this.type = type;
        name = "";
        data = "";
    }

    /**
     * @param type
     * @param name
     * @param data
     */
    public PropItem(int type, String name, String data)
    {
        this.type = type;
        this.name = name;
        this.data = data;
    }

    /**
     * @return the type
     */
    public int getType()
    {
        return type;
    }

    /**
     * @param type the type to set
     */
    public void setType(int type)
    {
        this.type = type;
    }

    /**
     * @return the name
     */
    public String getName()
    {
        return name;
    }

    /**
     * @param name the name to set
     */
    public void setName(String name)
    {
        this.name = name;
    }

    /**
     * @return the data
     */
    public String getData()
    {
        return data;
    }

    /**
     * @param data the data to set
     */
    public void setData(String data)
    {
        this.data = data;
    }

    /*
     * (non-Javadoc)
     * 
     * @see java.lang.Object#toString()
     */
    public String toString()
    {
        return name;
    }
}
