namespace Me.Amon.Da
{
    public interface DFA
    {
        void Load(string file);

        void Save(string file);

        string Get(string key);

        string Get(string key, string def);

        void Set(string key, string value);

        void Set(string key, string value, string comment);

        void Clear();
    }
}
