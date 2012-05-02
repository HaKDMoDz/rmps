using System.Text.RegularExpressions;
using Me.Amon.Pwd.E;

namespace Me.Amon.Uc
{
    public class KeyStroke<T>
    {
        public bool Control { get; set; }
        public bool Alt { get; set; }
        public bool Shift { get; set; }
        public bool Meta { get; set; }
        public char Code { get; set; }
        public string Key { get; set; }
        public string Memo { get; set; }
        public IAction<T> Action { get; set; }

        public bool Decode(string key)
        {
            key = Regex.Replace(key, "[^-=`;',./\\[\\]a-zA-Z0-9]+", " ").Trim().ToUpper();
            foreach (string t in key.Split(' '))
            {
                if (string.IsNullOrWhiteSpace(t))
                {
                    continue;
                }
                if ("CONTROL" == t)
                {
                    Control = true;
                    continue;
                }
                if ("ALT" == t)
                {
                    Alt = true;
                    continue;
                }
                if ("SHIFT" == t)
                {
                    Shift = true;
                    continue;
                }
                if ("META" == t)
                {
                    Meta = true;
                }
                Code = t[0];
            }
            return Code != '\0';
        }
    }
}