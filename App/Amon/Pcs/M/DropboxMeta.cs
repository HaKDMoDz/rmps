using System;
using System.Collections.Generic;

namespace Me.Amon.Pcs.M
{
    public class DropboxMeta : CsMeta
    {
        /// <summary>
        /// A human-readable description of the file size (translated by locale).
        /// </summary>
        public string size;
        /// <summary>
        /// The file size in bytes.
        /// </summary>
        public int bytes;
        /// <summary>
        /// Returns the canonical path to the file or directory.
        /// </summary>
        public string path;
        /// <summary>
        /// Whether the given entry is a folder or not.
        /// </summary>
        public bool is_dir;
        /// <summary>
        /// Whether the given entry is deleted (only included if deleted files are being returned).
        /// </summary>
        public bool is_deleted;
        /// <summary>
        /// A unique identifier for the current revision of a file. This field is the same rev as elsewhere in the API and can be used to detect changes and avoid conflicts.
        /// </summary>
        public string rev;
        /// <summary>
        /// A folder's hash is useful for indicating changes to the folder's contents in later calls to /metadata. This is roughly the folder equivalent to a file's rev.
        /// </summary>
        public string hash;
        /// <summary>
        /// True if the file is an image can be converted to a thumbnail via the /thumbnails call.
        /// </summary>
        public bool thumb_exists;
        /// <summary>
        /// The name of the icon used to illustrate the file type in Dropbox's icon library.
        /// </summary>
        public string icon;
        /// <summary>
        /// The last time the file was modified on Dropbox, in the standard date format (not included for the root folder).
        /// </summary>
        public DateTime modified;
        /// <summary>
        /// For files, this is the modification time set by the desktop client when the file was added to Dropbox, in the standard date format. Since this time is not verified (the Dropbox server stores whatever the desktop client sends up), this should only be used for display purposes (such as sorting) and not, for example, to determine if a file has changed or not.
        /// </summary>
        public DateTime client_mtime;
        /// <summary>
        /// The root or top-level folder depending on your access level. All paths returned are relative to this root level. Permitted values are either dropbox or app_folder.
        /// </summary>
        public string root;
        /// <summary>
        /// A deprecated field that semi-uniquely identifies a file. Use rev instead.
        /// </summary>
        public string revision;

        public string mime_type;

        public DropboxMeta[] contents;

        #region 属性重写
        public override string Root
        {
            get
            {
                return root;
            }
            set
            {
                root = value;
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
                return "";
            }
            set
            {
            }
        }

        public override string Hash
        {
            get
            {
                return is_dir ? hash : rev;
            }
            set
            {
                if (is_dir)
                {
                    hash = value;
                }
                else
                {
                    rev = value;
                }
            }
        }

        public override int Type
        {
            get
            {
                return is_dir ? CPcs.META_TYPE_FOLDER : CPcs.META_TYPE_FILE;
            }
            set
            {
                is_dir = value == CPcs.META_TYPE_FOLDER;
            }
        }

        public override int Size
        {
            get
            {
                return bytes;
            }
            set
            {
                bytes = value;
            }
        }

        public override DateTime CreateTime
        {
            get
            {
                return modified;
            }
            set
            {
            }
        }

        public override DateTime ModifyTime
        {
            get
            {
                return modified;
            }
            set
            {
                modified = value;
            }
        }

        public override string FileId
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
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
                is_deleted = value;
            }
        }

        public override List<CsMeta> SubMetas()
        {
            return new List<CsMeta>();
        }
        #endregion
    }
}
