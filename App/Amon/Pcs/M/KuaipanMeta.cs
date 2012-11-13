using System;
using System.Collections.Generic;

namespace Me.Amon.Pcs.M
{
    public class KuaipanMeta : CsMeta
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
        #endregion

        public override string Root
        {
            get
            {
                return root;
            }
            set
            {
            }
        }

        public override string Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
            }
        }

        public override string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public override string Hash
        {
            get
            {
                return hash;
            }
            set
            {
                hash = value;
            }
        }

        public override int Type
        {
            get
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
            set
            {
                type = "folder";
            }
        }

        public override int Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }

        public override DateTime CreateTime
        {
            get
            {
                return create_time;
            }
            set
            {
                create_time = value;
            }
        }

        public override DateTime ModifyTime
        {
            get
            {
                return modify_time;
            }
            set
            {
                modify_time = value;
            }
        }

        public override string FileId
        {
            get
            {
                return file_id;
            }
            set
            {
                file_id = value;
            }
        }

        public override string Rev
        {
            get
            {
                return rev;
            }
            set
            {
                rev = value;
            }
        }

        public override bool IsDeleted
        {
            get
            {
                return is_deleted;
            }
            set
            {
                IsDeleted = value;
            }
        }

        public override List<CsMeta> SubMetas()
        {
            List<CsMeta> metas = new List<CsMeta>();
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
    }
}
