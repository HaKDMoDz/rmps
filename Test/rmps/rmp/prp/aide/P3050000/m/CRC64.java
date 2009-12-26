/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3050000.m;

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
public class CRC64 implements java.util.zip.Checksum
{
    private static final long POLY64 = 0xD800000000000000L;
    private static final long[] crcTable = new long[256];
    private long crc;

    static
    {
        for (int i = 0; i < 256; ++i)
        {
            long part = i;
            for (int j = 0; j < 8; ++j)
            {
                part = ((part & 1) != 0) ? (part >>> 1) ^ POLY64 : (part >>> 1);
            }
            crcTable[i] = part;
        }
    }

    public void update(int b)
    {
        long low = crc >>> 8;
        long high = crcTable[(int) ((crc ^ b) & 0xFF)];
        crc = low ^ high;
    }

    public void update(byte[] b, int offset, int length)
    {
        for (int i = offset; i < length; ++i)
        {
            update(b[i]);
        }
    }

    public void update(String s)
    {
        // update(s.getBytes(), 0, s.length());
        int size = s.length();
        for (int i = 0; i < size; ++i)
        {
            update(s.charAt(i));
        }
    }

    public long getValue()
    {
        return crc;
    }

    /**
     * Returns a zero-padded 16 character wide string containing the current
     * value of this checksum in uppercase hexadecimal format.
     */
    @Override
    public String toString()
    {
        StringBuilder builder = new StringBuilder();
        builder.append(Long.toHexString(crc >>> 4));
        builder.append(Long.toHexString(crc & 0xF));
        for (int i = 16 - builder.length(); i > 0; --i)
        {
            builder.insert(0, '0');
        }
        return builder.toString().toUpperCase();
    }

    public void reset()
    {
        crc = 0;
    }
}
