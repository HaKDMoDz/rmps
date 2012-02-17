using System.Data;
using Me.Amon.Da;

namespace Me.Amon.Bean
{
    public class Dir : Vcs
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Tips { get; set; }
        public string Path { get; set; }
        public string Memo { get; set; }

        #region 接口实现
        public override bool Load(DataRow row)
        {
            return true;
        }

        public override bool Read(DBAccess dba, string Id)
        {
            return true;
        }

        public override bool Save(DBAccess dba, bool update)
        {
            return true;
        }
        #endregion

        #region 方法重写
        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (obj is Dir)
            {
                return Id == ((Dir)obj).Id;
            }
            if (obj is string)
            {
                return Id == (string)obj;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Id != null ? Id.GetHashCode() : 0;
        }
        #endregion
    }
}
