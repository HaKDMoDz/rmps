using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Me.Amon.Pcs.M
{
    public class NativeMeta : CsMeta
    {
        #region 属性
        /// <summary>
        /// kuaipan 或 app_folder
        /// </summary>
        public override string Root { get; set; }
        /// <summary>
        /// 文件或文件夹相对<root>的路径
        /// </summary>
        public override string Path { get; set; }
        /// <summary>
        /// path=/，root=kuaipan时不返回。文件名。
        /// </summary>
        public override string Name { get; set; }
        /// <summary>
        /// list=true才返回,当前这级文件夹的哈希值。
        /// </summary>
        public override string Hash { get; set; }
        /// <summary>
        /// enum(file,folder)	path=/,root=kuaipan时不返回。folder为文件夹，file为文件。
        /// </summary>
        public override int Type { get; set; }
        /// <summary>
        /// path=/,root=kuaipan时不返回。文件大小。
        /// </summary>
        public override int Size { get; set; }
        /// <summary>
        /// path=/,root=kuaipan时不返回。YYYY-MM-DD hh:mm:ss。
        /// </summary>
        public override DateTime CreateTime { get; set; }
        /// <summary>
        /// path=/,root=kuaipan时不返回。YYYY-MM-DD hh:mm:ss。
        /// </summary>
        public override DateTime ModifyTime { get; set; }
        /// <summary>
        /// path=/,root=kuaipan时不返回。文件唯一标识id。
        /// </summary>
        public override string FileId { get; set; }
        /// <summary>
        /// path=/,root=kuaipan时不返回。
        /// </summary>
        public override string Rev { get; set; }
        /// <summary>
        /// path=/，root=kuaipan时不返回。是否被删除的文件。
        /// </summary>
        public override bool IsDeleted { get; set; }
        #endregion

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

        public override List<CsMeta> SubMetas()
        {
            throw new NotImplementedException();
        }
    }
}
