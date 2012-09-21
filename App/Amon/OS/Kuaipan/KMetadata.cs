namespace KApi
{
    /// <summary>
    /// 文件(夹)操作类
    /// </summary>
    public class KMetadata : Oauth
    {
        private OauthCore baseOauth;

        #region 构造函数
        public KMetadata()
        {
            baseOauth = new OauthCore(this.consumer_key, this.consumer_secret);
        }

        public KMetadata(string consumer_key, string consumer_secret, string oauth_token, string oauth_token_secret)
        {
            this.consumer_key = consumer_key;
            this.consumer_secret = consumer_secret;
            this.oauth_token = oauth_token;
            this.oauth_token_secret = oauth_token_secret;
            baseOauth = new OauthCore(this.consumer_key, this.consumer_secret);
        }
        #endregion

        public string GetMetaData()
        {
            return baseOauth.GetMetaData(new OauthToken(oauth_token, oauth_token_secret));
        }

        public string GetMetaData(string path)
        {
            return baseOauth.GetMetaData(new OauthToken(oauth_token, oauth_token_secret), path);
        }

        /// <summary>
        /// 上传文件类
        /// </summary>
        /// <returns></returns>
        public string UpLoad(string folder, string filename, byte[] fileData)
        {
            return baseOauth.UpLoadFile(folder, filename, fileData, new OauthToken(this.oauth_token, this.oauth_token_secret));
        }

        /// <summary>
        /// 下载文件类
        /// </summary>
        /// <returns></returns>
        public byte[] DownLoad(string path)
        {
            return baseOauth.DownLoadFile(path, new OauthToken(this.oauth_token, this.oauth_token_secret));
        }

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string CreateFolder(string path)
        {
            return baseOauth.CreateFolder(path, new OauthToken(this.oauth_token, this.oauth_token_secret));
        }

        /// <summary>
        /// 删除文件或者文件夹
        /// </summary>
        /// <param name="path">要删除的文件路径</param>
        /// <param name="to_recycle">是否放到回收站,否的话彻底删除</param>
        /// <returns></returns>
        public string DeleteFileOrFolder(string path, string to_recycle)
        {
            return baseOauth.DeleteFileOrFolder(path, to_recycle, new OauthToken(this.oauth_token, this.oauth_token_secret));
        }

        /// <summary>
        /// 改名类
        /// </summary>
        /// <param name="FileID"></param>
        /// <param name="OriName"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public string Rename(string form_path, string to_path)
        {
            return baseOauth.MoveFolder(form_path, to_path, new OauthToken(this.oauth_token, this.oauth_token_secret));
        }
    }
}
