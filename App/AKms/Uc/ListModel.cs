
namespace Me.Amon.Uc
{
    public class ListModel<T>
    {
        public ListModel()
        {
        }

        public ListModel(T k, string v)
        {
            K = k;
            V = v;
        }

        public override string ToString()
        {
            return V;
        }

        public T K { get; set; }

        public string V { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is ListModel<T>)
            {
                var k = (ListModel<T>)obj;
                return K.Equals(k.K);
            }
            if (obj is T)
            {
                var k = (T)obj;
                return K.Equals(k);
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return K.GetHashCode();
        }
    }
}
