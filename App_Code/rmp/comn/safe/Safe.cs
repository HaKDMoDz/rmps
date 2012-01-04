using System;
using System.Collections.Generic;
using System.Text;
using rmp.util;

namespace rmp.comn.safe
{
    /// <summary>
    ///Safe 的摘要说明
    /// </summary>
    public class Safe
    {
        /// <summary>
        /// 验证字符空间
        /// </summary>
        /// <remarks>共57个字符，除 l,o,x,I,O,X,1,0 的所有数字和大写字母</remarks>
        private static String authChar = "abcdefghijkmnpqrstuvwyzABCDEFGHJKLMNPQRSTUVWYZ23456789";
        private static Dictionary<String, String> authDict = new Dictionary<String, String>();
        private static AuthIcon authIcon = new AuthIcon();

        public Safe()
        {
        }

        public String AuthChar
        {
            get
            {
                return authChar;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    authChar = value;
                }
            }
        }

        public static int CharSize
        {
            get
            {
                return authIcon.CodeNum;
            }
            set
            {
                authIcon.CodeNum = value;
            }
        }

        /// <summary>
        /// 产生随机验证字符序列
        /// </summary>
        public static String GenAuthCode(String userHash)
        {
            Random random = new Random();

            StringBuilder buf = new StringBuilder();
            for (int i = 0; i < authIcon.CodeNum; i++)
            {
                buf.Append(authChar[random.Next(authChar.Length)]);
            }

            String authCode = buf.ToString();
            authIcon.AuthCode = authCode;

            userHash = HashUtil.digest(authCode.ToUpper() + userHash, true);
            authDict[userHash] = authCode;

            return userHash;
        }

        /// <summary>
        /// 根据键值获取验证字符序列
        /// </summary>
        /// <param name="authHash"></param>
        /// <returns></returns>
        public static String GetAuthCode(String authHash)
        {
            String authCode = null;
            if (authDict.ContainsKey(authHash))
            {
                authCode = authDict[authHash];
                authDict.Remove(authHash);
            }
            return authCode;
        }

        public static bool IsValidate(String authHash, String authCode)
        {
            return true;
        }
    }
}