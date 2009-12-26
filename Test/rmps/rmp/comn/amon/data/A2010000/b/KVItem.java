/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.comn.amon.data.A2010000.b;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br />
 * TODO: 使用说明
 * </ul>
 * @author Amon
 */
public class KVItem
{
    /** 字段名称 */
    private String k;
    /** 数据类别 */
    private String v;
    /** 是否需要加引号 */
    private boolean s;

    /**
     * 
     */
    public KVItem()
    {
        this("", "");
    }

    /**
     * @param k
     * @param v
     */
    public KVItem(String k, String v)
    {
        this.k = k;
        this.v = v;
        this.s = "VARCHAR".equalsIgnoreCase(v) || "TIMESTAMP".equalsIgnoreCase(v);
    }

    /**
     * @return the k
     */
    public String getK()
    {
        return k;
    }

    /**
     * @param k the k to set
     */
    public void setK(String k)
    {
        this.k = k;
    }

    /**
     * @return the v
     */
    public String getV()
    {
        return v;
    }

    /**
     * @param v the v to set
     */
    public void setV(String v)
    {
        this.v = v;
        this.s = "VARCHAR".equalsIgnoreCase(v) || "TIMESTAME".equalsIgnoreCase(v);
    }

    /*
     * (non-Javadoc)
     * 
     * @see java.lang.Object#equals(java.lang.Object)
     */
    public boolean equals(Object o)
    {
        if (o == null || !(o instanceof KVItem))
        {
            return false;
        }

        KVItem kv = (KVItem) o;
        return getK() != null && getK().equals(kv.getK());
    }

    /*
     * (non-Javadoc)
     * 
     * @see java.lang.Object#toString()
     */
    public String toString()
    {
        return k;
    }

    /**
     * @return the s
     */
    public boolean isS()
    {
        return s;
    }

    /**
     * @param s the s to set
     */
    public void setS(boolean s)
    {
        this.s = s;
    }
}
