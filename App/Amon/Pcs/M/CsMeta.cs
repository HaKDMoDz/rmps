 using System;
using System.Collections.Generic;
using System.Drawing;

namespace Me.Amon.Pcs.M
{
    public class CsMeta
    {
        /// <summary>
        /// 文件或文件夹相对<root>的路径
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// kuaipan 或 app_folder
        /// </summary>
        public string Root { get; set; }
        /// <summary>
        /// list=true才返回,当前这级文件夹的哈希值。
        /// </summary>
        public string Hash { get; set; }
        /// <summary>
        /// path=/,root=kuaipan时不返回。文件唯一标识id。
        /// </summary>
        public string FileId { get; set; }
        /// <summary>
        /// enum(file,folder)	path=/,root=kuaipan时不返回。folder为文件夹，file为文件。
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// path=/,root=kuaipan时不返回。文件大小。
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// path=/,root=kuaipan时不返回。YYYY-MM-DD hh:mm:ss。
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// path=/,root=kuaipan时不返回。YYYY-MM-DD hh:mm:ss。
        /// </summary>
        public DateTime ModifyTime { get; set; }
        /// <summary>
        /// path=/，root=kuaipan时不返回。文件名。
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// path=/,root=kuaipan时不返回。
        /// </summary>
        public string Rev { get; set; }
        /// <summary>
        /// path=/，root=kuaipan时不返回。是否被删除的文件。
        /// </summary>
        public bool IsDeleted { get; set; }

        public string Display { get; set; }

        public List<CsFile> Files { get; set; }
    }
}
