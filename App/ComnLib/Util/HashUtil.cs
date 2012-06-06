using System;

namespace Me.Amon.Util
{/// <summary>
    /// HashUtil 的摘要说明
    /// </summary>
    public class HashUtil
    {
        private HashUtil()
        {
        }

        public static long LocTime()
        {
            return DateTime.Now.ToFileTime();
        }

        public static long UtcTime()
        {
            return DateTime.UtcNow.ToFileTime();
        }

        public static string UtcTimeInHex()
        {
            return Convert.ToString(DateTime.UtcNow.ToFileTime(), 16).ToUpper().PadLeft(16, '0');
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bigCase"></param>
        /// <returns></returns>
        public static String UtcTimeInEnc(bool bigCase)
        {
            return CharUtil.EncodeLong(DateTime.UtcNow.ToFileTime(), bigCase);
        }
    }
}
