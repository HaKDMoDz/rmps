/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package com.amonsoft.util;

import java.util.Arrays;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public class CharUtil
{
    private static final char[] HEX_DIGITS =
    { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

    public static String toHex(byte b)
    {
        char[] c = new char[2];
        c[0] = HEX_DIGITS[(b >>> 4) & 0x0F];
        c[1] = HEX_DIGITS[b & 0x0F];
        return new String(c);
    }

    static String toHex(byte[] b)
    {
        char[] c = new char[b.length << 1];
        int i = 0;
        for (byte t : b)
        {
            c[i++] = HEX_DIGITS[(t >>> 4) & 0x0F];
            c[i++] = HEX_DIGITS[t & 0x0F];
        }
        return new String(c);
    }

    /**
     * 左填充指定字符，使原字符串达到指定的长度
     * 
     * @param s
     * @param length
     * @param c
     * @return
     */
    public static String lPad(String s, int length, char c)
    {
        if (length <= s.length())
        {
            return s;
        }

        char[] pad = new char[length - s.length()];
        Arrays.fill(pad, c);
        return new String(pad) + s;
    }

    /**
     * 去除左空白
     * 
     * @param s
     * @return
     */
    public static String lTrim(String s)
    {
        return lTrim(s, " ");
    }

    /**
     * @param s
     * @param c
     * @return
     */
    public static String lTrim(String s, String c)
    {
        return (s != null) ? s.replaceAll("^[\\s" + c + "]+", c) : s;
    }

    /**
     * 右填充指定字符，使原字符串达到指定的长度
     * 
     * @param s
     * @param length
     * @param c
     * @return
     */
    public static String rPad(String s, int length, char c)
    {
        if (length <= s.length())
        {
            return s;
        }

        char[] pad = new char[length - s.length()];
        Arrays.fill(pad, c);
        return s + new String(pad);
    }

    /**
     * 去除右空白
     * 
     * @param s
     * @return
     */
    public static String rTrim(String s)
    {
        return (s != null) ? s.replaceAll("[\\s　]+$", "") : s;
    }
}
