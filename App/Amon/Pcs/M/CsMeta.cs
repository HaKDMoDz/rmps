using System;
using System.Collections.Generic;

namespace Me.Amon.Pcs.M
{
    public abstract class CsMeta
    {
        /// <summary>
        /// 系统提示
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// kuaipan 或 app_folder
        /// </summary>
        public abstract string Root { get; set; }
        /// <summary>
        /// 文件或文件夹相对<root>的路径
        /// </summary>
        public abstract string Path { get; set; }
        /// <summary>
        /// path=/，root=kuaipan时不返回。文件名。
        /// </summary>
        public abstract string Name { get; set; }
        /// <summary>
        /// list=true才返回,当前这级文件夹的哈希值。
        /// </summary>
        public abstract string Hash { get; set; }
        /// <summary>
        /// enum(file,folder)	path=/,root=kuaipan时不返回。folder为文件夹，file为文件。
        /// </summary>
        public abstract int Type { get; set; }
        /// <summary>
        /// path=/,root=kuaipan时不返回。文件大小。
        /// </summary>
        public abstract int Size { get; set; }
        /// <summary>
        /// path=/,root=kuaipan时不返回。YYYY-MM-DD hh:mm:ss。
        /// </summary>
        public abstract DateTime CreateTime { get; set; }
        /// <summary>
        /// path=/,root=kuaipan时不返回。YYYY-MM-DD hh:mm:ss。
        /// </summary>
        public abstract DateTime ModifyTime { get; set; }
        /// <summary>
        /// path=/,root=kuaipan时不返回。文件唯一标识id。
        /// </summary>
        public abstract string FileId { get; set; }
        /// <summary>
        /// path=/,root=kuaipan时不返回。
        /// </summary>
        public abstract string Rev { get; set; }
        /// <summary>
        /// path=/，root=kuaipan时不返回。是否被删除的文件。
        /// </summary>
        public abstract bool IsDeleted { get; set; }

        public abstract List<CsMeta> SubMetas();
    }
}
