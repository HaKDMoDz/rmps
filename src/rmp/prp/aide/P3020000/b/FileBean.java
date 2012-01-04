/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3020000.b;

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
public class FileBean
{
    /** 原文件名称 */
    private String srcName;
    /** 命名后名称 */
    private String dstName;
    /** 临时文件名称 */
    private String tmpName;

    /**
     * 
     */
    public FileBean()
    {
        this("");
    }

    /**
     * @param srcName
     */
    public FileBean(String srcName)
    {
        this(srcName, srcName);
    }

    /**
     * @param srcName
     * @param dstName
     */
    public FileBean(String srcName, String dstName)
    {
        this.srcName = srcName;
        this.dstName = dstName;
    }

    /**
     * @return the srcName
     */
    public String getSrcName()
    {
        return srcName;
    }

    /**
     * @param srcName the srcName to set
     */
    public void setSrcName(String srcName)
    {
        this.srcName = srcName;
    }

    /**
     * @return the dstName
     */
    public String getDstName()
    {
        return dstName;
    }

    /**
     * @param dstName the dstName to set
     */
    public void setDstName(String dstName)
    {
        this.dstName = dstName;
    }

    /**
     * @return the tmpName
     */
    public String getTmpName()
    {
        return tmpName;
    }

    /**
     * @param tmpName the tmpName to set
     */
    public void setTmpName(String tmpName)
    {
        this.tmpName = tmpName;
    }

    /**
     * 0：全部大写<br />
     * 1：名称大写<br />
     * 2：扩展大写<br />
     * 
     * @param type
     */
    public void toUpper(int type)
    {
        if (type == 0)
        {
            dstName = srcName.toUpperCase();
            return;
        }

        int ldi = srcName.lastIndexOf('.');
        if (ldi < 0)
        {
            ldi = srcName.length();
        }
        String n = srcName.substring(0, ldi);
        String e = srcName.substring(ldi);
        if (type == 1)
        {
            dstName = n.toUpperCase() + e;
            return;
        }
        if (type == 2)
        {
            dstName = n + e.toUpperCase();
            return;
        }
    }

    /**
     * 0：全部大写<br />
     * 1：名称大写<br />
     * 2：扩展大写<br />
     * 
     * @param type
     */
    public void toLower(int type)
    {
        if (type == 0)
        {
            dstName = srcName.toLowerCase();
            return;
        }

        int ldi = srcName.lastIndexOf('.');
        if (ldi < 0)
        {
            ldi = srcName.length();
        }
        String n = srcName.substring(0, ldi);
        String e = srcName.substring(ldi);
        if (type == 1)
        {
            dstName = n.toLowerCase() + e;
            return;
        }
        if (type == 2)
        {
            dstName = n + e.toLowerCase();
            return;
        }
    }
}
