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
package rmp.bean;

import java.io.Serializable;

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
 * @author amon
 * 
 */
public class K1SV3S extends K1SV2S implements Serializable, Cloneable
{
    private String v3;

    public K1SV3S()
    {
        this("", "", "", "");
    }

    public K1SV3S(String key, String value1, String value2, String value3)
    {
        super(key, value1, value2);
        this.v3 = value3;
    }

    /**
     * @return the v2
     */
    public final String getV3()
    {
        return v3;
    }

    /**
     * @param v3
     *            the v3 to set
     */
    public final void setV3(String v3)
    {
        this.v3 = v3;
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

        if (o instanceof K1SV1S)
        {
            K1SV1S kv = (K1SV1S) o;
            return getK().equals(kv.getK());
        }
        return false;
    }

    /*
     * (non-Javadoc)
     * 
     * @see java.lang.Object#clone()
     */
    public Object clone() throws CloneNotSupportedException
    {
        K1SV3S kv = (K1SV3S) super.clone();
        kv.setK(getK());
        kv.setV1(getV1());
        kv.setV2(getV2());
        kv.setV3(getV3());
        return kv;
    }
}
