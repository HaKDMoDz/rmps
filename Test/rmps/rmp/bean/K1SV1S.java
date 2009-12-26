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
 * 此类主要用于包装两个对象：Key与Value，实现一些构件的模型的共通性，其toString()方法默认返回Value的值
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public final class K1SV1S implements Serializable, Cloneable
{
    /** Key值 */
    private String k;
    /** Value值 */
    private String v;

    /**
     * 默认构造器
     */
    public K1SV1S()
    {
        this("", "");
    }

    /**
     * 默认构造器
     * 
     * @param key
     *            key值
     * @param value
     *            value值
     */
    public K1SV1S(String key, String value)
    {
        k = key;
        v = value;
    }

    /**
     * @return the k
     */
    public final String getK()
    {
        return k;
    }

    /**
     * @param k
     *            the k to set
     */
    public final void setK(String k)
    {
        this.k = k;
    }

    /**
     * @return the v
     */
    public final String getV()
    {
        return v;
    }

    /**
     * @param v
     *            the v to set
     */
    public final void setV(String v)
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
        return new K1SV1S(k, v);
    }

    /*
     * (non-Javadoc)
     * 
     * @see java.lang.Object#equals(java.lang.Object)
     */
    public boolean equals(Object o)
    {
        if (o == null || !(o instanceof K1SV1S))
        {
            return false;
        }

        K1SV1S kv = (K1SV1S) o;
        return getK() != null && getK().equals(kv.getK());
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
