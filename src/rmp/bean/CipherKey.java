/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.bean;

import javax.crypto.SecretKey;

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
public final class CipherKey implements SecretKey
{
    /**  */
    private static final long serialVersionUID = 1L;
    /** 加密算法 */
    private String algorithm = "";
    /** 加密方式 */
    private String format = "RAW";
    /** 加密口令 */
    private byte[] keys = null;
    /** 用于加密解密的口令字节数组的长度 */
    private int cdSize = 16;
    /** 用于加密解密的iv数组长度。 */
    private int ivSize = 16;

    /**
     * 
     */
    public CipherKey(byte[] key)
    {
        this.keys = key;
    }

    /*
     * (non-Javadoc)
     * 
     * @see java.security.Key#getAlgorithm()
     */
    public String getAlgorithm()
    {
        return algorithm;
    }

    /*
     * (non-Javadoc)
     * 
     * @see java.security.Key#getEncoded()
     */
    public byte[] getEncoded()
    {
        return keys;
    }

    /*
     * (non-Javadoc)
     * 
     * @see java.security.Key#getFormat()
     */
    public String getFormat()
    {
        return format;
    }

    /**
     * @return the ivSize
     */
    public int getIvSize()
    {
        return ivSize;
    }

    /**
     * @param ivSize the ivSize to set
     */
    public void setIvSize(int ivSize)
    {
        this.ivSize = ivSize;
    }

    /**
     * @param algorithm the algorithm to set
     */
    public void setAlgorithm(String algorithm)
    {
        this.algorithm = algorithm;
    }

    /**
     * @param format the format to set
     */
    public void setFormat(String format)
    {
        this.format = format;
    }

    /**
     * @return
     */
    public byte[] getIV()
    {
        return keys;
    }

    /**
     * @return the cdSize
     */
    public int getCdSize()
    {
        return cdSize;
    }

    /**
     * @param cdSize the cdSize to set
     */
    public void setCdSize(int cdSize)
    {
        this.cdSize = cdSize;
    }
}
