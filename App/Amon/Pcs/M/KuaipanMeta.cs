using System;
using System.Collections.Generic;

namespace Me.Amon.Pcs.M
{
    public class KuaipanMeta : AMeta
    {
        #region 属性
        /// <summary>
        /// 提示信息
        /// </summary>
        public string msg;
        /// <summary>
        /// kuaipan 或 app_folder
        /// </summary>
        public string root;
        /// <summary>
        /// 文件或文件夹相对<root>的路径
        /// </summary>
        public string path;
        /// <summary>
        /// path=/，root=kuaipan时不返回。文件名。
        /// </summary>
        public string name;
        /// <summary>
        /// list=true才返回,当前这级文件夹的哈希值。
        /// </summary>
        public string hash;
        /// <summary>
        /// enum(file,folder)	path=/,root=kuaipan时不返回。folder为文件夹，file为文件。
        /// </summary>
        public string type;
        /// <summary>
        /// path=/,root=kuaipan时不返回。文件大小。
        /// </summary>
        public int size;
        /// <summary>
        /// path=/,root=kuaipan时不返回。YYYY-MM-DD hh:mm:ss。
        /// </summary>
        public DateTime create_time;
        /// <summary>
        /// path=/,root=kuaipan时不返回。YYYY-MM-DD hh:mm:ss。
        /// </summary>
        public DateTime modify_time;
        /// <summary>
        /// path=/,root=kuaipan时不返回。文件唯一标识id。
        /// </summary>
        public string file_id;
        public string sha1;
        public string share_id;
        /// <summary>
        /// path=/,root=kuaipan时不返回。
        /// </summary>
        public string rev;
        /// <summary>
        /// path=/，root=kuaipan时不返回。是否被删除的文件。
        /// </summary>
        public bool is_deleted;

        public KuaipanMeta[] files;
        #endregion

        #region 判等重写
        public override string ToString()
        {
            return name;
        }

        public override bool Equals(object obj)
        {
            return path.Equals(obj);
        }

        public override int GetHashCode()
        {
            return path != null ? path.GetHashCode() : 0;
        }
        #endregion

        #region 函数重写
        public override string GetMessage()
        {
            return "";
        }

        public override string GetRoot()
        {
            return root;
        }

        public override string GetPath()
        {
            return path;
        }

        public override void SetPath(string path)
        {
            this.path = path;
        }

        public override string GetName()
        {
            return name;
        }

        public override void SetName(string name)
        {
            this.name = name;
        }

        public override string GetHash()
        {
            return hash;
        }

        public override int GetMetaType()
        {
            type = (type ?? "").ToLower();
            if (type == "folder")
            {
                return CPcs.META_TYPE_FOLDER;
            }
            if (type == "file")
            {
                return CPcs.META_TYPE_FILE;
            }
            return CPcs.META_TYPE_UNKNOWN;
        }

        public override int GetSize()
        {
            return size;
        }

        public override DateTime GetCreateTime()
        {
            return create_time;
        }

        public override DateTime GetModifyTime()
        {
            return modify_time;
        }

        public override string GetMetaId()
        {
            return file_id;
        }

        public override string GetRevison()
        {
            return rev;
        }

        public override bool IsDeleted()
        {
            return is_deleted;
        }

        public override List<AMeta> SubMetas()
        {
            List<AMeta> metas = new List<AMeta>();
            if (files != null)
            {
                foreach (var meta in files)
                {
                    meta.path = path;
                    metas.Add(meta);
                }
            }
            return metas;
        }
        #endregion
    }
}
