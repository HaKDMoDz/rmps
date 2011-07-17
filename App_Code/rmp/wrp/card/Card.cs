using System;
using System.Collections.Generic;
using rmp.soap.P30C0000;

namespace rmp.wrp.card
{
    /// <summary>
    /// Summary description for Card
    /// </summary>
    public class Card
    {
        private static readonly IpAddressSearchWebService ipss = new IpAddressSearchWebService();

        /// <summary>
        /// IP缓冲
        /// </summary>
        private static readonly IDictionary<string, string> ipList = new Dictionary<string, string>();
        /// <summary>
        /// 日期记忆
        /// </summary>
        private static int lastDay;

        private Card()
        {
        }

        public static string IpLoc(string ip)
        {
            if (string.IsNullOrEmpty(ip))
            {
                return "";
            }

            // 判断每日清空数据
            int t = DateTime.Now.Day;
            if (t != lastDay)
            {
                lastDay = t;
                ipList.Clear();
            }

            // 判断是否需要重新进行数据查询
            if (!ipList.ContainsKey(ip))
            {
                try
                {
                    ipList[ip] = ipss.getCountryCityByIp(ip)[1];
                }
                catch (Exception)
                {
                }
            }
            return ipList[ip];
        }
    }
}
