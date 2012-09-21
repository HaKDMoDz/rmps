namespace Me.Amon.OS.Kuaipan
{
    class AccountInfo
    {
        /// <summary>
        /// 标识用户的唯一id
        /// </summary>
        public int user_id { get; set; }
        /// <summary>
        /// 用户名字
        /// </summary>
        public string user_name { get; set; }
        /// <summary>
        /// 允许上传最大文件
        /// </summary>
        public int max_file_size { get; set; }
        /// <summary>
        /// 用户空间总量，Byte
        /// </summary>
        public long quota_total { get; set; }
        /// <summary>
        /// 用户空间已使用量，Byte
        /// </summary>
        public long quota_used { get; set; }
        /// <summary>
        /// 用户空间的回收站空间使用量，Byte
        /// </summary>
        public long quota_recycled { get; set; }

        public bool Decode()
        {
            return true;
        }
    }
}
