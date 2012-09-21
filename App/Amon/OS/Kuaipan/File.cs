namespace Me.Amon.OS.Kuaipan
{
    class File
    {
        /// <summary>
        /// 文件唯一标识id
        /// </summary>
        public string file_id { get; set; }
        /// <summary>
        /// folder为文件夹，file为文件。
        /// </summary>
        public MetaType type { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public uint size { get; set; }
        /// <summary>
        /// YYYY-MM-DD hh:mm:ss
        /// </summary>
        public string create_time { get; set; }
        /// <summary>
        /// YYYY-MM-DD hh:mm:ss
        /// </summary>
        public string modify_time { get; set; }
        /// <summary>
        /// 文件名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string rev { get; set; }
        /// <summary>
        /// 是否被删除的文件
        /// </summary>
        public bool is_deleted { get; set; }
    }
}
