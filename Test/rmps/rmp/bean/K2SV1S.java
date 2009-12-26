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
public final class K2SV1S implements Serializable, Cloneable
{
    /**  */
    private static final long serialVersionUID = 9179785310845748409L;
    /** Key1 */
    private String k1;
    /** Key2 */
    private String k2;
    /** Value */
    private String v;

    /**
     * 
     */
    public K2SV1S()
    {
        this("", "", "");
    }

    /**
     * @param k1
     * @param k2
     * @param v
     */
    public K2SV1S(String k1, String k2, String v)
    {
        this.k1 = k1;
        this.k2 = k2;
        this.v = v;
    }

    /**
     * @return the k1
     */
    public String getK1()
    {
        return k1;
    }

    /**
     * @param k1
     *            the k1 to set
     */
    public void setK1(String k1)
    {
        this.k1 = k1;
    }

    /**
     * @return the k2
     */
    public String getK2()
    {
        return k2;
    }

    /**
     * @param k2
     *            the k2 to set
     */
    public void setK2(String k2)
    {
        this.k2 = k2;
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
     * @see java.lang.Object#equals(java.lang.Object)
     */
    public boolean equals(Object o)
    {
        if (o == null || !(o instanceof K2SV1S))
        {
            return false;
        }

        K2SV1S kv = (K2SV1S) o;
        if (getK1() != null && getK1().equals(kv.getK1()))
        {
            if (getK2() != null && getK2().equals(kv.getK2()))
            {
                return true;
            }
        }
        return false;
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
}
