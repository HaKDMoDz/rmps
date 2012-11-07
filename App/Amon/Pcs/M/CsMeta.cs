using System;
using System.Collections.Generic;

namespace Me.Amon.Pcs.M
{
    public class CsMeta
    {
        /// <summary>
        /// kuaipan 或 app_folder
        /// </summary>
        public string Root;
        /// <summary>
        /// 文件或文件夹相对<root>的路径
        /// </summary>
        public string Path;
        /// <summary>
        /// path=/，root=kuaipan时不返回。文件名。
        /// </summary>
        public string Name;
        /// <summary>
        /// list=true才返回,当前这级文件夹的哈希值。
        /// </summary>
        public string Hash;
        /// <summary>
        /// enum(file,folder)	path=/,root=kuaipan时不返回。folder为文件夹，file为文件。
        /// </summary>
        public int Type;
        /// <summary>
        /// path=/,root=kuaipan时不返回。文件大小。
        /// </summary>
        public int Size;
        /// <summary>
        /// path=/,root=kuaipan时不返回。YYYY-MM-DD hh:mm:ss。
        /// </summary>
        public DateTime CreateTime;
        /// <summary>
        /// path=/,root=kuaipan时不返回。YYYY-MM-DD hh:mm:ss。
        /// </summary>
        public DateTime ModifyTime;
        /// <summary>
        /// path=/,root=kuaipan时不返回。文件唯一标识id。
        /// </summary>
        public string FileId;
        /// <summary>
        /// path=/,root=kuaipan时不返回。
        /// </summary>
        public string Rev;
        /// <summary>
        /// path=/，root=kuaipan时不返回。是否被删除的文件。
        /// </summary>
        [NonSerialized]
        public bool IsDeleted;

        [NonSerialized]
        public List<CsFile> Files;

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return Path.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Path != null ? Path.GetHashCode() : 0;
        }
    }
}
