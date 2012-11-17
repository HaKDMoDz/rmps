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
        /// 文件或文件夹相对<root>的路径
        /// </summary>
        public abstract string GetPath();
        public abstract void SetPath(string path);
        /// <summary>
        /// path=/，root=kuaipan时不返回。文件名。
        /// </summary>
        public abstract string GetName();
        public abstract void SetName(string name);
        /// <summary>
        /// list=true才返回,当前这级文件夹的哈希值。
        /// </summary>
        public abstract string GetHash();
        /// <summary>
        /// enum(file,folder)	path=/,root=kuaipan时不返回。folder为文件夹，file为文件。
        /// </summary>
        public abstract int GetMetaType();
        /// <summary>
        /// path=/,root=kuaipan时不返回。文件唯一标识id。
        /// </summary>
        public abstract string GetMetaId();
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

        public abstract List<AMeta> SubMetas();

        public virtual FolderMeta ToMeta(string name)
        {
            var meta = new FolderMeta();
            meta.SetRoot(GetRoot());
            meta.SetPath(GetPath());
            meta.SetName(name);
            meta.SetHash(GetHash());
            meta.SetType(GetMetaType());
            meta.SetId(GetMetaId());
            return meta;
        }
    }
}
