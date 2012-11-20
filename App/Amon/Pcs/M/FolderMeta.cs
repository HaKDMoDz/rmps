using System;
using System.Collections.Generic;

namespace Me.Amon.Pcs.M
{
    public class FolderMeta : AMeta
    {
        private string _Id;

        private string _Root;

        private string _Path;

        private string _Name;

        private string _Hash;

        private int _Type;

        private string _Revision;

        public string ServerType { get; set; }

        public string ServerUser { get; set; }

        public string UserCode { get; set; }

        public void SetRoot(string root)
        {
            _Root = root;
        }

        public void SetHash(string hash)
        {
            _Hash = hash;
        }

        public void SetType(int type)
        {
            _Type = type;
        }

        public void SetId(string id)
        {
            _Id = id;
        }

        public void SetRevision(string revision)
        {
            _Revision = revision;
        }

        #region 接口实现
        public override string GetMessage()
        {
            return "";
        }

        public override string GetRoot()
        {
            return _Root;
        }

        public override string GetMeta()
        {
            return "";
        }

        public override string GetMetaPath()
        {
            return _Path;
        }

        public override void SetMetaPath(string path)
        {
            this._Path = path;
        }

        public override string GetMetaName()
        {
            return _Name;
        }

        public override void SetMetaName(string name)
        {
            this._Name = name;
        }

        public override string GetHash()
        {
            return _Hash;
        }

        public override int GetMetaType()
        {
            return CPcs.META_TYPE_FOLDER;
        }

        public override string GetMetaId()
        {
            return _Id;
        }

        public override int GetSize()
        {
            return 0;
        }

        public override DateTime GetCreateTime()
        {
            return DateTime.Now;
        }

        public override DateTime GetModifyTime()
        {
            return DateTime.Now;
        }

        public override string GetRevison()
        {
            return "0";
        }

        public override bool IsDeleted()
        {
            return false;
        }

        public override List<AMeta> SubMetas()
        {
            return null;
        }

        public override FolderMeta ToMeta(string name)
        {
            return this;
        }
        #endregion
    }
}
