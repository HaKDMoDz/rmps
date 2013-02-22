namespace Me.Amon.Open.V1.Web.Pcs
{
    public class KuaipanAccount : OAuthPcsAccount
    {
        /// <summary>
        /// 标识用户的唯一id
        /// </summary>
        public string user_id;
        /// <summary>
        /// 用户名字
        /// </summary>
        public string user_name;
        /// <summary>
        /// 允许上传最大文件
        /// </summary>
        public int max_file_size;
        /// <summary>
        /// 用户空间总量，Byte
        /// </summary>
        public long quota_total;
        /// <summary>
        /// 用户空间已使用量，Byte
        /// </summary>
        public long quota_used;
        /// <summary>
        /// 用户空间的回收站空间使用量，Byte
        /// </summary>
        public long quota_recycled;

        public override string Id
        {
            get { return user_id; }
        }

        public override string Name
        {
            get { return user_name; }
        }

        public override int Limit
        {
            get { return max_file_size; }
        }

        public override long Size
        {
            get { return quota_total; }
        }

        public override long Used
        {
            get { return quota_used; }
        }

        public override long Recycled
        {
            get { return quota_recycled; }
        }
    }
}
