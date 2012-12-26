
namespace Me.Amon.Hosts
{
    public class KVItem
    {
        public string K { get; set; }

        public string V { get; set; }

        public override int GetHashCode()
        {
            return K != null ? K.GetHashCode() : 0;
        }

        public override bool Equals(object obj)
        {
            if (obj is KVItem)
            {
                KVItem item = obj as KVItem;
                return item.K == K;
            }
            return false;
        }

        public override string ToString()
        {
            return V != null ? V.ToString() : "（空）";
        }
    }
}
