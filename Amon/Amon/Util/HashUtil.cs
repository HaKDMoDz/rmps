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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bigCase"></param>
        /// <returns></returns>
        public static String GetCurrTimeHex(bool bigCase)
        {
            return CharUtil.EncodeLong(DateTime.UtcNow.ToBinary(), bigCase);
        }
    }
}
