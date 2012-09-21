
namespace Me.Amon.OS.Kuaipan
{
    class Folder
    {
        /// <summary>
        /// 文件或文件夹相对<root>的路径
        /// </summary>
        public string path { get; set; }
        /// <summary>
        /// kuaipan 或 app_folder
        /// </summary>
        public string root { get; set; }
        /// <summary>
        /// list=true才返回,当前这级文件夹的哈希值。
        /// </summary>
        public string hash { get; set; }
        /// <summary>
        /// path=/,root=kuaipan时不返回。文件唯一标识id。
        /// </summary>
        public string file_id { get; set; }
        /// <summary>
        /// path=/,root=kuaipan时不返回。folder为文件夹，file为文件。
        /// </summary>
        public MetaType type { get; set; }//	N	enum(file,folder)	
        /// <summary>
        /// path=/,root=kuaipan时不返回。文件大小。
        /// </summary>
        public uint size { get; set; }
        /// <summary>
        /// path=/,root=kuaipan时不返回。YYYY-MM-DD hh:mm:ss。
        /// </summary>
        public string create_time { get; set; }
        /// <summary>
        /// path=/,root=kuaipan时不返回。YYYY-MM-DD hh:mm:ss。
        /// </summary>
        public string modify_time { get; set; }
        /// <summary>
        /// path=/，root=kuaipan时不返回。文件名。
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// path=/,root=kuaipan时不返回。
        /// </summary>
        public string rev { get; set; }
        /// <summary>
        /// path=/，root=kuaipan时不返回。是否被删除的文件。
        /// </summary>
        public bool is_deleted { get; set; }
    }
}
