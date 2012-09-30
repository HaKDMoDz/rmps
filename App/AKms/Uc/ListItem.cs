namespace Me.Amon.Uc
{
    public class ListItem<T>
    {
        public ListItem()
        {
        }

        public ListItem(T k, string v)
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
            if (obj is ListItem<T>)
            {
                var k = (ListItem<T>)obj;
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
