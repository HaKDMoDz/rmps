using System;
using System.IO;
using System.Text;

namespace me.amon
{
    /// <summary>
    ///Safe 的摘要说明
    /// </summary>
    public class Safe
    {
        public Safe()
        {
        }

        /// <summary>
        /// 16进制字符串转换为数组
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static byte[] Hex2Bytes(string source)
        {
            int t = 0;
            bool f = false;
            MemoryStream stream = new MemoryStream(source.Length);
            foreach (char b in source.ToUpper().ToCharArray())
            {
                if (b >= '0' && b <= '9')
                {
                    if (f)
                    {
                        t |= (b - '0');
                        stream.WriteByte((byte)t);
                        t = 0;
                        f = false;
                        continue;
                    }

                    t = (b - '0') << 4;
                    f = true;
                    continue;
                }

                if (b >= 'A' && b <= 'F')
                {
                    if (f)
                    {
                        t |= (b - 'A' + 10);
                        stream.WriteByte((byte)t);
                        t = 0;
                        f = false;
                        continue;
                    }

                    t = (b - 'A' + 10) << 4;
                    f = true;
                    continue;
                }
            }
            byte[] a = stream.ToArray();
            stream.Close();
            return a;
        }

        /// <summary>
        /// 数组转换为16进制字符串
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string Bytes2Hex(byte[] array)
        {
            return Bytes2Hex(array, 0, array.Length);
        }

        public static string Bytes2Hex(byte[] array, int index, int count)
        {
            count += index;
            StringBuilder buf = new StringBuilder();
            while (index < count)
            {
                buf.Append(Convert.ToString(array[index++], 16).ToUpper().PadLeft(2, '0'));
            }
            return buf.ToString();
        }
    }
}