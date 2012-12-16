using System;
using System.Collections.Generic;

namespace Me.Amon.Pcs.M
{
    public abstract class AMeta
    {
        /// <summary>
        /// 系统提示
        /// </summary>
        public abstract string GetMessage();

        /// <summary>
        /// kuaipan 或 app_folder
        /// </summary>
        public abstract string GetRoot();
        /// <summary>
        /// Meta资源路径
        /// </summary>
        /// <returns></returns>
        public abstract string GetMeta();
        /// <summary>
        /// list=true才返回,当前这级文件夹的哈希值。
        /// </summary>
        public abstract string GetHash();
        /// <summary>
        /// path=/,root=kuaipan时不返回。文件唯一标识id。
        /// </summary>
        public abstract string GetMetaId();
        /// <summary>
        /// enum(file,folder)	path=/,root=kuaipan时不返回。folder为文件夹，file为文件。
        /// </summary>
        public abstract int GetMetaType();
        /// <summary>
        /// 文件或文件夹相对<root>的路径
        /// </summary>
        public abstract string GetMetaPath();
        public abstract void SetMetaPath(string path);
        /// <summary>
        /// path=/，root=kuaipan时不返回。文件名。
        /// </summary>
        public abstract string GetMetaName();
        public abstract void SetMetaName(string name);
        /// <summary>
        /// path=/,root=kuaipan时不返回。文件大小。
        /// </summary>
        public abstract int GetSize();
        /// <summary>
        /// path=/,root=kuaipan时不返回。YYYY-MM-DD hh:mm:ss。
        /// </summary>
        public abstract DateTime GetCreateTime();
        /// <summary>
        /// path=/,root=kuaipan时不返回。YYYY-MM-DD hh:mm:ss。
        /// </summary>
        public abstract DateTime GetModifyTime();
        /// <summary>
        /// path=/,root=kuaipan时不返回。
        /// </summary>
        public abstract string GetRevison();
        /// <summary>
        /// path=/，root=kuaipan时不返回。是否被删除的文件。
        /// </summary>
        public abstract bool IsDeleted();

        //public abstract AMeta Parent();

        public abstract List<AMeta> SubMetas();

        public virtual FolderMeta ToMeta(string name)
        {
            var meta = new FolderMeta();
            meta.SetRoot(GetRoot());
            meta.SetMetaPath(GetMetaPath());
            meta.SetMetaName(name);
            meta.SetHash(GetHash());
            meta.SetType(GetMetaType());
            meta.SetId(GetMetaId());
            return meta;
        }
    }
}
