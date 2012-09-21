using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Me.Amon.OS.Kuaipan;
using Newtonsoft.Json;

namespace KApi
{
    /// <summary>
    /// 授权核心算法
    /// </summary>
    public class OauthCore
    {
        #region 类成员
        private string _http_method = "GET";
        public string http_method
        {
            get
            {
                return _http_method;
            }
            set
            {
                _http_method = value;
            }
        }

        private string _oauth_version = "1.0";
        public string oauth_version
        {
            get
            {
                return _oauth_version;
            }
            set
            {
                _oauth_version = value;
            }
        }


        private string _oauth_signature_method = "HMAC-SHA1";
        public string oauth_signature_method
        {
            get
            {
                return _oauth_signature_method;
            }
            set
            {
                _oauth_signature_method = value;
            }
        }

        public string oauth_consumer_key { set; get; }

        public string consumer_secret { get; set; }
        #endregion

        private WebClient wc;

        #region 构造函数
        public OauthCore()
        {
            wc = new WebClient();
        }
        public OauthCore(Consumer kconsumer)
        {
            this.oauth_consumer_key = kconsumer.consumer_key;
            this.consumer_secret = kconsumer.consumer_secret;
            wc = new WebClient();
        }
        public OauthCore(string oauth_consumer_key, string consumer_secret)
        {
            this.oauth_consumer_key = oauth_consumer_key;
            this.consumer_secret = consumer_secret;
            wc = new WebClient();
        }
        public OauthCore(string oauth_consumer_key, string consumer_secret, string oauth_callback)
        {
            this.oauth_consumer_key = oauth_consumer_key;
            this.consumer_secret = consumer_secret;
            //KConst.oauth_callback = oauth_callback;
            wc = new WebClient();
        }
        #endregion

        /// <summary>
        /// requestToken
        /// 第一步：获取未授权的临时 token
        /// </summary>
        /// <returns></returns>
        public OauthToken RequestToken()
        {
            SortedDictionary<string, string> ParamList = new SortedDictionary<string, string>();
            ParamList.Add("oauth_consumer_key", this.oauth_consumer_key);
            ParamList.Add("oauth_nonce", GetRandomString(8));
            ParamList.Add("oauth_signature_method", this.oauth_signature_method);
            ParamList.Add("oauth_timestamp", GetTimeStamp());
            ParamList.Add("oauth_version", this.oauth_version);
            //ParamList.Add("oauth_callback", KConst.URI_OAUTH_CALLBACK);
            string SourceString = GetApiSourceString(KConst.URI_REQUEST_TOKEN, ParamList);
            string SecretKey = GetSecretKey(this.consumer_secret, "");
            string Sign = GetSignature(SourceString, SecretKey);
            ParamList.Add("oauth_signature", Sign);
            string TokenUrl = KConst.URI_REQUEST_TOKEN + "?" + ParamToUrl(ParamList, false);

            string JsonToken = wc.GetHtml(TokenUrl);
            if (string.IsNullOrWhiteSpace(JsonToken))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<OauthToken>(JsonToken);
        }

        /// <summary>
        /// accessToken
        /// 第三步：用临时 token 换取 access token
        /// </summary>
        /// <param name="ot"></param>
        /// <returns></returns>
        public OauthToken AccessToken(OauthToken ot)
        {
            string accessUrl = GetAccessTokenUrl(ot.oauth_token, ot.oauth_token_secret);
            string JsonToken = wc.GetHtml(accessUrl);
            if (!String.IsNullOrEmpty(JsonToken))
            {
                object obj = Newtonsoft.Json.JsonConvert.DeserializeObject(JsonToken);
                if (obj != null)
                {
                    Dictionary<string, object> dict = (Dictionary<string, object>)obj;
                    OauthToken Result = new OauthToken();
                    Result.oauth_token = dict["oauth_token"].ToString();
                    Result.oauth_token_secret = dict["oauth_token_secret"].ToString();
                    return Result;
                }

            }
            return null;
        }

        public void authorise()
        {
        }

        /// <summary>
        /// 获取授权帐号信息
        /// </summary>
        /// <param name="kot"></param>
        /// <returns></returns>
        public string GetAccountInfo(OauthToken kot)
        {
            string url = GetAccountInfoUrl(kot.oauth_token, kot.oauth_token_secret);
            string text = wc.GetHtml(url);
            text = System.Text.RegularExpressions.Regex.Unescape(text);
            return text;
        }

        /// <summary>
        /// 获取文件(夹)信息
        /// </summary>
        /// <param name="kot"></param>
        /// <returns></returns>
        public string GetMetaData(OauthToken kot, string path)
        {
            string metaurl = GetMetadataUrl(kot.oauth_token, kot.oauth_token_secret, path);
            string text = wc.GetHtml(metaurl);
            text = System.Text.RegularExpressions.Regex.Unescape(text);
            return text;
        }

        /// <summary>
        /// 获取根目录的文件信息
        /// </summary>
        /// <param name="kot"></param>
        /// <returns></returns>
        public string GetMetaData(OauthToken kot)
        {
            return GetMetaData(kot, "");
        }

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="path"></param>
        /// <param name="kot"></param>
        /// <returns></returns>
        public string CreateFolder(string path, OauthToken kot)
        {
            string createUrl = GetCreateFolderUrl(path, kot.oauth_token, kot.oauth_token_secret);
            string text = wc.GetHtml(createUrl);
            text = Regex.Unescape(text);
            return text;
        }

        /// <summary>
        /// 删除文件或文件夹
        /// </summary>
        /// <param name="path"></param>
        /// <param name="to_recycle"></param>
        /// <param name="kot"></param>
        /// <returns></returns>
        public string DeleteFileOrFolder(string path, string to_recycle, OauthToken kot)
        {
            string deleteUrl = GetDeleteFileOrFolderUrl(path, to_recycle, kot.oauth_token, kot.oauth_token_secret);
            string text = wc.GetHtml(deleteUrl);
            text = Regex.Unescape(text);
            return text;
        }

        /// <summary>
        /// 重命名文件夹
        /// </summary>
        /// <param name="path"></param>
        /// <param name="to_path"></param>
        /// <param name="kot"></param>
        /// <returns></returns>
        public string MoveFolder(string path, string to_path, OauthToken kot)
        {
            string moveUrl = GetMoveFolderUrl(path, to_path, kot.oauth_token, kot.oauth_token_secret);
            string text = wc.GetHtml(moveUrl);
            text = System.Text.RegularExpressions.Regex.Unescape(text);
            return text;
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="filename"></param>
        /// <param name="fileData"></param>
        /// <param name="kot"></param>
        /// <returns></returns>
        public string UpLoadFile(string folder, string filename, byte[] fileData, OauthToken kot)
        {
            string result = "";
            //第一步 获取loate url
            string locate_Request_url = GetUploadLocateUrl(kot.oauth_token, kot.oauth_token_secret);
            string JsonLocateUrl = wc.GetHtml(locate_Request_url);
            object jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(JsonLocateUrl);
            if (jsonObj != null)
            {
                Dictionary<string, object> dictUrl = (Dictionary<string, object>)jsonObj;
                string url = dictUrl["url"].ToString();
                this.http_method = "POST";
                string uploadUrl = GetUploadFileUrl(url, folder, filename, kot.oauth_token, kot.oauth_token_secret);
                MultipartForm mf = new MultipartForm();
                mf.AddFlie("file", filename, fileData, 0);
                result = wc.Post(uploadUrl, mf);
            }
            return result;
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="kot"></param>
        /// <returns></returns>
        public byte[] DownLoadFile(string path, OauthToken kot)
        {
            string downloadurl = GetDownloadFileUrl(path, kot.oauth_token, kot.oauth_token_secret);
            byte[] data = wc.GetData(downloadurl);
            return data;
        }

        /// <summary>
        /// 获取缩略图
        /// </summary>
        /// <param name="path"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="kot"></param>
        /// <returns></returns>
        public byte[] GetThumbnail(string path, int width, int height, OauthToken kot)
        {
            string thnailUrl = GetThumbnailUrl(path, width, height, kot.oauth_token, kot.oauth_token_secret);
            return wc.GetData(thnailUrl);
        }

        #region 私有方法
        /// <summary>
        /// 第三步:用临时的token ,secret获取真正的token
        /// </summary>
        /// <param name="oauth_token"></param>
        /// <param name="oauth_token_secret"></param>
        /// <returns></returns>
        private string GetAccessTokenUrl(string oauth_token, string oauth_token_secret)
        {
            return BuildUrl(KConst.URI_ACCESS_TOKEN, oauth_token, oauth_token_secret);
        }

        /// <summary>
        /// 获取帐号信息对应的URL
        /// </summary>
        /// <param name="oauth_token"></param>
        /// <param name="oauth_token_secret"></param>
        /// <returns></returns>
        private string GetAccountInfoUrl(string oauth_token, string oauth_token_secret)
        {
            return BuildUrl(KConst.URI_ACCOUNT_INFO, oauth_token, oauth_token_secret);
        }

        /// <summary>
        /// 获取文件夹信息
        /// </summary>
        /// <param name="oauth_token"></param>
        /// <param name="oauth_token_secret"></param>
        /// <returns></returns>
        private string GetMetadataUrl(string oauth_token, string oauth_token_secret, string path)
        {
            return BuildUrl(KConst.URI_METADATA + UrlEncode(path.Trim('/'), new char[] { '/' }), oauth_token, oauth_token_secret);
        }

        /// <summary>
        /// 获取上传文件地址
        /// </summary>
        /// <param name="oauth_token"></param>
        /// <param name="oauth_token_secret"></param>
        /// <returns></returns>
        private string GetUploadLocateUrl(string oauth_token, string oauth_token_secret)
        {
            return BuildUrl(KConst.URI_UPLOAD_LOCATE, oauth_token, oauth_token_secret);
        }

        /// <summary>
        /// 获取上传文件的参数
        /// </summary>
        /// <param name="uploadUrl"></param>
        /// <param name="folder"></param>
        /// <param name="fileName"></param>
        /// <param name="oauth_token"></param>
        /// <param name="oauth_token_secret"></param>
        /// <returns></returns>
        private string GetUploadFileUrl(string uploadUrl, string folder, string fileName, string oauth_token, string oauth_token_secret)
        {
            string Url = String.Format("{0}1/fileops/upload_file", uploadUrl);
            SortedDictionary<string, string> ParamList = new SortedDictionary<string, string>();
            ParamList.Add("overwrite", "true");
            ParamList.Add("root", "app_folder");
            ParamList.Add("path", String.Format("{0}/{1}", folder, fileName));
            return BuildUrl(Url, oauth_token, oauth_token_secret, ParamList);
        }

        private string GetDownloadFileUrl(string path, string oauth_token, string oauth_token_secret)
        {
            SortedDictionary<string, string> ParamList = new SortedDictionary<string, string>();
            ParamList.Add("root", "app_folder");
            ParamList.Add("path", path);
            return BuildUrl(KConst.URI_DOWNLOAD, oauth_token, oauth_token_secret, ParamList);
        }

        private string GetCreateFolderUrl(string path, string oauth_token, string oauth_token_secret)
        {
            SortedDictionary<string, string> ParamList = new SortedDictionary<string, string>();
            ParamList.Add("root", "app_folder");
            ParamList.Add("path", path);
            return BuildUrl(KConst.URI_CREATE_FOLDER, oauth_token, oauth_token_secret, ParamList);
        }

        private string GetDeleteFileOrFolderUrl(string path, string to_recycle, string oauth_token, string oauth_token_secret)
        {
            SortedDictionary<string, string> ParamList = new SortedDictionary<string, string>();
            ParamList.Add("root", "app_folder");
            ParamList.Add("path", path);
            ParamList.Add("to_recycle", to_recycle);
            return BuildUrl(KConst.URI_DELETE_FOLDERORFILE, oauth_token, oauth_token_secret, ParamList);
        }


        private string GetMoveFolderUrl(string from_path, string to_path, string oauth_token, string oauth_token_secret)
        {
            SortedDictionary<string, string> ParamList = new SortedDictionary<string, string>();
            ParamList.Add("root", "app_folder");
            ParamList.Add("from_path", from_path);
            ParamList.Add("to_path", to_path);
            return BuildUrl(KConst.URI_MOVE_FOLDER, oauth_token, oauth_token_secret, ParamList);
        }

        private string GetThumbnailUrl(string path, int width, int height, string oauth_token, string oauth_token_secret)
        {
            SortedDictionary<string, string> ParamList = new SortedDictionary<string, string>();
            ParamList.Add("root", "app_folder");
            ParamList.Add("path", path);
            ParamList.Add("width", width.ToString());
            ParamList.Add("height", height.ToString());
            return BuildUrl(KConst.URI_THUMBNAIL, oauth_token, oauth_token_secret, ParamList);
        }

        #endregion

        #region 辅助函数
        /// <summary>
        /// 根据API地址和授权类型生成URL
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="oauth_token"></param>
        /// <param name="oauth_token_secret"></param>
        /// <returns></returns>
        private string BuildUrl(string Url, string oauth_token, string oauth_token_secret)
        {
            return BuildUrl(Url, oauth_token, oauth_token_secret, null);
        }

        /// <summary>
        /// 根据API地址和授权类型生成URL
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="oauth_token"></param>
        /// <param name="oauth_token_secret"></param>
        /// <returns></returns>
        private string BuildUrl(string Url, string oauth_token, string oauth_token_secret, SortedDictionary<string, string> ParamListEx)
        {
            SortedDictionary<string, string> ParamList = new SortedDictionary<string, string>();
            ParamList.Add("oauth_consumer_key", this.oauth_consumer_key);
            ParamList.Add("oauth_nonce", GetRandomString(8));
            ParamList.Add("oauth_signature_method", this.oauth_signature_method);
            ParamList.Add("oauth_timestamp", GetTimeStamp());
            ParamList.Add("oauth_token", oauth_token);
            ParamList.Add("oauth_version", this.oauth_version);

            if (ParamListEx != null && ParamListEx.Count > 0)
            {
                foreach (KeyValuePair<string, string> key in ParamListEx)
                {
                    ParamList.Add(key.Key, key.Value);
                }
            }
            string SourceString = GetApiSourceString(Url, ParamList);
            string SecretKey = GetSecretKey(this.consumer_secret, oauth_token_secret);
            string Sign = GetSignature(SourceString, SecretKey);
            ParamList.Add("oauth_signature", Sign);

            return Url + "?" + ParamToUrl(ParamList, false);
        }

        /// <summary>
        /// 获取源串.
        /// </summary>
        /// <returns></returns>
        private string GetApiSourceString(string baseUrl, SortedDictionary<string, string> ParamList)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(http_method + "&");
            sb.Append(UrlEncode(baseUrl) + "&");
            string InnerParam = ParamToUrl(ParamList, true);

            sb.Append(UrlEncode(InnerParam));
            return sb.ToString();
        }

        /// <summary>
        /// 获取签名值.
        /// </summary>
        /// <param name="SourceString"></param>
        /// <param name="SecretKey"></param>
        /// <returns></returns>
        private string GetSignature(string SourceString, string SecretKey)
        {
            return UrlEncode(Hmac_Sha1AndBase64(SourceString, SecretKey));
        }

        /// <summary>
        /// 获取密钥
        /// </summary>
        /// <param name="consumer_secret"></param>
        /// <param name="oauth_token_secret"></param>
        /// <returns></returns>
        private string GetSecretKey(string consumer_secret, string oauth_token_secret)
        {
            return consumer_secret + "&" + oauth_token_secret;
        }

        /// <summary>
        /// 将参数字典转换为URL 参数.用&符号拼接
        /// </summary>
        /// <param name="dictParam"></param>
        /// <param name="isEncode">是否编码</param>
        /// <returns></returns>
        private string ParamToUrl(SortedDictionary<string, string> dictParam, bool isEncode)
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, string> key in dictParam)
            {
                if (isEncode)
                {
                    sb.AppendFormat("&{0}={1}", UrlEncode(key.Key), UrlEncode(key.Value));
                }
                else
                {
                    if (key.Key.IndexOf("path") > -1)
                    {
                        sb.AppendFormat("&{0}={1}", UrlEncode(key.Key), UrlEncode(key.Value, new char[] { '/' }));
                    }
                    else
                        sb.AppendFormat("&{0}={1}", key.Key, key.Value);
                }
            }
            return sb.ToString().TrimStart('&');
        }

        private string UrlEncode(string str)
        {
            return UrlEncode(str, null);
        }

        private string UrlEncode(string url, char[] exstring)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byStr = System.Text.Encoding.UTF8.GetBytes(url); //默认是System.Text.Encoding.Default.GetBytes(str)
            for (int i = 0; i < byStr.Length; i++)
            {
                if ((byStr[i] >= 48 && byStr[i] <= 57)
                    || (byStr[i] >= 97 && byStr[i] <= 122)
                    || (byStr[i] >= 65 && byStr[i] <= 90)
                    || (byStr[i] == 46)
                || byStr[i] == 45
                    || byStr[i] == 95
                    || byStr[i] == 126
                    || (exstring != null && exstring.Length > 0 && exstring.Contains((char)byStr[i]))
                   )
                {
                    sb.Append((char)byStr[i]);
                }
                else
                {
                    string t = Convert.ToString(byStr[i], 16);
                    sb.AppendFormat(@"%{0}", t.ToUpper());
                }
            }
            return sb.ToString();
        }

        private string Hmac_Sha1AndBase64(string Source, string SecretKey)
        {
            System.Security.Cryptography.HMACSHA1 hmacsha1 = new System.Security.Cryptography.HMACSHA1();
            hmacsha1.Key = System.Text.Encoding.ASCII.GetBytes(SecretKey);
            byte[] dataBuffer = System.Text.Encoding.ASCII.GetBytes(Source); //signatureBase要进行签名的基础字符串
            byte[] hashBytes = hmacsha1.ComputeHash(dataBuffer);
            return Convert.ToBase64String(hashBytes);
        }

        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        private string GetTimeStamp()
        {
            TimeSpan toNow = DateTime.Now - new DateTime(1970, 1, 1).ToLocalTime();
            return Math.Floor(toNow.TotalSeconds).ToString();
        }

        /// <summary>
        /// 获取随机字符串
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private string GetRandomString(int length)
        {
            string result = System.Guid.NewGuid().ToString();
            result = result.Replace("-", "");
            return result.Substring(0, length);
        }

        #endregion
    }
}
