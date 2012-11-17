using System;
using System.Collections.Generic;

namespace Me.Amon.Pcs.M
{
    public class NativeMeta : AMeta
    {
        #region 属性
        public override string GetMessage()
        {
            return "";
        }

        public string root;
        public override string GetRoot()
        {
            return root;
        }

        public string path;
        public override string GetPath()
        {
            return path;
        }

        public override void SetPath(string path)
        {
            this.path = path;
        }

        public string name;
        public override string GetName()
        {
            return name;
        }

        public override void SetName(string name)
        {
            this.name = name;
        }

        public string hash;
        public override string GetHash()
        {
            return hash;
        }

        public int type;
        public override int GetMetaType()
        {
            return type;
        }

        public int size;
        public override int GetSize()
        {
            return size;
        }

        public DateTime createTime;
        public override DateTime GetCreateTime()
        {
            return createTime;
        }

        public DateTime modifyTime;
        public override DateTime GetModifyTime()
        {
            return modifyTime;
        }

        public string fileId;
        public override string GetMetaId()
        {
            return fileId;
        }

        public string revison;
        public override string GetRevison()
        {
            return revison;
        }

        public bool isDeleted;
        public override bool IsDeleted()
        {
            return isDeleted;
        }
        #endregion

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

        public override List<AMeta> SubMetas()
        {
            throw new NotImplementedException();
        }
    }
}
