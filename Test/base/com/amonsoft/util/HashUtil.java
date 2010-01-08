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
package com.amonsoft.util;

import java.security.MessageDigest;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Administrator
 * 
 */
public class HashUtil
{
    public static byte[] digest(byte[] data, String cipher)
    {
        try
        {
            return MessageDigest.getInstance(cipher).digest(data);
        }
        catch (Exception exp)
        {
            return null;
        }
    }
}
