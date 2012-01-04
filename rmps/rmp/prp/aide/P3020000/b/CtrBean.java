/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3020000.b;

import cons.prp.aide.P3020000.ConstUI;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 匹配处理
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public class CtrBean
{
    /** 匹配字符标记 */
    private char vCtr;
    /** 匹配索引，-1表示全字匹配 */
    private int indx;
    /** 是否为末序匹配，true是；indx为-1时此值无效 */
    private boolean last;

    /**
     * @param vMat
     * @param indx
     */
    public CtrBean(char vMat, int indx)
    {
        this.vCtr = vMat;
        this.indx = indx;
    }

    /**
     * @return the vCtr
     */
    public char getVCtr()
    {
        return vCtr;
    }

    /**
     * @param ctr
     *            the vCtr to set
     */
    public void setVCtr(char ctr)
    {
        vCtr = ctr;
    }

    /**
     * @return the indx
     */
    public int getIndx()
    {
        return indx;
    }

    /**
     * @param indx
     *            the indx to set
     */
    public void setIndx(int indx)
    {
        this.indx = indx;
    }

    /**
     * @return the last
     */
    public boolean isLast()
    {
        return last;
    }

    /**
     * @param last
     *            the last to set
     */
    public void setLast(boolean last)
    {
        this.last = last;
    }

    /**
     * 字符匹配转换
     * 
     * @param src
     * @return
     */
    public String convert(String src)
    {
        if (ConstUI.EXPS_CTR_UPP == vCtr)
        {
            if (indx < 0)
            {
                return src.toUpperCase();
            }

            if (indx >= src.length())
            {
                return src;
            }

            char[] t = src.toCharArray();
            t[indx] = Character.toUpperCase(t[indx]);
            return new String(t);
        }
        if (ConstUI.EXPS_CTR_LOW == vCtr)
        {
            if (indx < 0)
            {
                return src.toLowerCase();
            }

            if (indx >= src.length())
            {
                return src;
            }

            char[] t = src.toCharArray();
            t[indx] = Character.toLowerCase(t[indx]);
            return new String(t);
        }
        return src;
    }
}
