namespace Me.Amon.Uc
{
    public class Item
    {
        public string K { get; set; }
        public string V { get; set; }
        public string D { get; set; }

        public override bool Equals(object obj)
        {
            return obj.GetHashCode() == GetHashCode();
        }

        public override int GetHashCode()
        {
            return K.GetHashCode();
        }

        public override string ToString()
        {
            return V;
        }
    }
}
