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
 * 此类主要用于包装三个对象：Key与Value1、Value2，实现一些构件的模型的共通性， 其toString()方法默认返回Value2的值
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public final class K1SV2S implements Serializable, Cloneable
{
    /**  */
    private static final long serialVersionUID = -7850578789980909658L;
    /** Key */
    private String k;
    /** Value1 */
    private String v1;
    /** Value2 */
    private String v2;

    /**
     * 
     */
    public K1SV2S()
    {
        this("", "", "");
    }

    /**
     * @param key
     * @param value1
     * @param value2
     */
    public K1SV2S(String key, String value1, String value2)
    {
        k = key;
        v1 = value1;
        v2 = value2;
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
     * @return the v1
     */
    public final String getV1()
    {
        return v1;
    }

    /**
     * @param v1
     *            the v1 to set
     */
    public final void setV1(String v1)
    {
        this.v1 = v1;
    }

    /**
     * @return the v2
     */
    public final String getV2()
    {
        return v2;
    }

    /**
     * @param v2
     *            the v2 to set
     */
    public final void setV2(String v2)
    {
        this.v2 = v2;
    }

    /*
     * (non-Javadoc)
     * 
     * @see java.lang.Object#equals(java.lang.Object)
     */
    public boolean equals(Object o)
    {
        if (getK() == null)
        {
            return o == null;
        }

        if (o == null)
        {
            return false;
        }

        if (o instanceof String)
        {
            return getK().equals(o);
        }

        if (o instanceof K1SV2S)
        {
            K1SV2S kv = (K1SV2S) o;
            return getK().equals(kv.getK());
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
        return v1;
    }

    /*
     * (non-Javadoc)
     * 
     * @see java.lang.Object#clone()
     */
    public Object clone() throws CloneNotSupportedException
    {
        K1SV2S kv = (K1SV2S) super.clone();
        kv.setK(getK());
        kv.setV1(getV1());
        kv.setV2(getV2());
        return kv;
    }
}
