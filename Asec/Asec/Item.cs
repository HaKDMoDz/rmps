namespace Msec
{
    public class Item
    {
        public string K { get; set; }
        public string V { get; set; }
        public string D { get; set; }

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
