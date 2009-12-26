/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3050000.m;

import java.security.Key;

import javax.crypto.SecretKey;
import javax.crypto.spec.SecretKeySpec;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 密码加密算法用户口令封装类，用于生成合适的密码密钥
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public final class SecureKey implements Key
{
    /** serialVersionUID */
    private static final long serialVersionUID = -7462080105937053891L;
    /** 密码算法 */
    private String algorithm;
    /** 用户口令 */
    private byte[] encoded;

    /**
     * 构造函数
     * 
     * @param alg
     *            密码算法
     * @param pwd
     *            用户口令
     * @param len
     *            密钥长度
     */
    public SecureKey(String alg, byte[] pwd, int len)
    {
        this.algorithm = alg;

        // 密钥初始化
        encoded = new byte[len];

        int tmp = pwd.length <= len ? pwd.length : len;
        for (int i = 0; i < tmp; i += 1)
        {
            encoded[i] = pwd[i];
        }

        for (; tmp < len; tmp += 1)
        {
            encoded[tmp] = (byte) tmp;
        }
    }

    /**
     * 用户口令初始化
     * 
     * @param algorithm
     *            加密算法名称
     * @param userPwd
     *            用户口令
     * @param keySize
     *            密钥长度
     * @return
     */
    public static final SecretKey initKeys(String algorithm, byte[] userPwd, int keySize)
    {
        byte[] pwds = new byte[keySize];
        for (int i = 0, j = userPwd.length; i < j; i += 1)
        {
            pwds[i] = userPwd[i];
        }
        for (int i = userPwd.length; i < keySize; i += 1)
        {
            pwds[i] = (byte) i;
        }
        return new SecretKeySpec(pwds, algorithm);
    }

    /*
     * (non-Javadoc)
     * 
     * @see java.security.Key#getAlgorithm()
     */
    @Override
    public String getAlgorithm()
    {
        return algorithm;
    }

    /*
     * (non-Javadoc)
     * 
     * @see java.security.Key#getEncoded()
     */
    @Override
    public byte[] getEncoded()
    {
        return encoded;
    }

    /*
     * (non-Javadoc)
     * 
     * @see java.security.Key#getFormat()
     */
    @Override
    public String getFormat()
    {
        return "RAW";
    }
}
