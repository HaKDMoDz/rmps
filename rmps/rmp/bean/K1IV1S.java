/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.bean;

import java.io.Serializable;

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
public class K1IV1S implements Serializable, Cloneable
{
    /** 区分键值 */
    private int k;
    /** 显示信息 */
    private String v;

    /**
     * 
     */
    public K1IV1S()
    {
        this(0, "");
    }

    /**
     * @param k
     * @param v
     */
    public K1IV1S(int k, String v)
    {
        this.k = k;
        this.v = v;
    }

    /**
     * @return the k
     */
    public int getK()
    {
        return k;
    }

    /**
     * @param k
     *            the k to set
     */
    public void setK(int k)
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
     * @param v
     *            the v to set
     */
    public void setV(String v)
    {
        this.v = v;
    }

    /*
     * (non-Javadoc)
     * 
     * @see java.lang.Object#clone()
     */
    public Object clone() throws CloneNotSupportedException
    {
        K1IV1S kv = new K1IV1S();
        kv.setK(k);
        kv.setV(v);
        return kv;
    }

    /*
     * (non-Javadoc)
     * 
     * @see java.lang.Object#equals(java.lang.Object)
     */
    public boolean equals(Object obj)
    {
        if (obj instanceof K1IV1S)
        {
            K1IV1S kv = (K1IV1S) obj;
            return getK() == kv.getK();
        }
        return (getV() != null && getV().equals(obj));
    }

    /*
     * (non-Javadoc)
     * 
     * @see java.lang.Object#toString()
     */
    public String toString()
    {
        return v;
    }

    /** serialVersionUID */
    private static final long serialVersionUID = -6047857216561464032L;
}
