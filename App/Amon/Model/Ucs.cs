namespace Me.Amon.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Ucs : Vcs
    {
        public int Order { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Tips { get; set; }
        public string Data { get; set; }
        public string Memo { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (obj is Ucs)
            {
                return Id == ((Ucs)obj).Id;
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
    }
}
