namespace Me.Amon.Model
{
    public class Dir : Vcs
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Tips { get; set; }
        public string Path { get; set; }
        public string Memo { get; set; }

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
    }
}
