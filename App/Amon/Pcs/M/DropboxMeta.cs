using System;
using System.Collections.Generic;

namespace Me.Amon.Pcs.M
{
    public class DropboxMeta : AMeta
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

        public string mime_type;

        public DropboxMeta[] contents;

        #region 属性重写
        public override string GetMessage()
        {
            return "";
        }

        public override string GetRoot()
        {
            return root;
        }

        public override string GetMeta()
        {
            return path;
        }

        public override string GetMetaPath()
        {
            return path;
        }

        public override void SetMetaPath(string path)
        {
        }

        public override string GetMetaName()
        {
            return "";
        }

        public override void SetMetaName(string name)
        {
        }

        public override string GetHash()
        {
            return is_dir ? hash : rev;
        }

        public override int GetMetaType()
        {
            return is_dir ? CPcs.META_TYPE_FOLDER : CPcs.META_TYPE_FILE;
        }

        public override int GetSize()
        {
            return bytes;
        }

        public override DateTime GetCreateTime()
        {
            return modified;
        }

        public override DateTime GetModifyTime()
        {
            return modified;
        }

        public override string GetMetaId()
        {
            return "";
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
            return new List<AMeta>();
        }
        #endregion
    }
}
