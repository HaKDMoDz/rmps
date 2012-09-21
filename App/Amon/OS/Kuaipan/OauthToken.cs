using System;
using System.Collections.Generic;
using System.Xml;

namespace KApi
{
    public class OauthToken
    {
        public string id { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        public string oauth_verifier { get; set; }
        /// <summary>
        /// 未授权的token
        /// </summary>
        public string oauth_token { get; set; }
        /// <summary>
        /// 对应secret
        /// </summary>
        public string oauth_token_secret { get; set; }
        /// <summary>
        /// True/False，callback是否接收
        /// </summary>
        public bool oauth_callback_confirmed { get; set; }

        #region 构造函数
        public OauthToken() { }

        public OauthToken(string oauth_token, string oauth_token_secret)
        {
            this.id = "-1";
            this.oauth_verifier = "-1";
            this.oauth_token = oauth_token;
            this.oauth_token_secret = oauth_token_secret;
        }

        public OauthToken(string id, string oauth_verifier, string oauth_token, string oauth_token_secret)
        {
            this.id = id;
            this.oauth_verifier = oauth_verifier;
            this.oauth_token = oauth_token;
            this.oauth_token_secret = oauth_token_secret;
        }
        #endregion

        public static List<OauthToken> GetList()
        {
            List<OauthToken> list = new List<OauthToken>();
            string xmlUrl = "";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlUrl);
            XmlNodeList xnlist = xmlDoc.SelectNodes("/userlist/user");
            foreach (XmlNode xn in xnlist)
            {
                OauthToken user = new OauthToken();
                user.id = xn.SelectSingleNode("id").InnerText;
                user.oauth_verifier = xn.SelectSingleNode("oauth_verifier").InnerText;
                user.oauth_token = xn.SelectSingleNode("oauth_token").InnerText;
                user.oauth_token_secret = xn.SelectSingleNode("oauth_token_secret").InnerText;
                list.Add(user);
            }
            return list;
        }

        public static OauthToken GetUser(string id)
        {
            List<OauthToken> list = GetList();
            foreach (OauthToken user in list)
            {
                if (String.Compare(id, user.id) > 0)
                {
                    return user;
                }
            }
            return null;
        }
    }
}
