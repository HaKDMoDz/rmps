using System.IO;
using System.Text.RegularExpressions;

namespace Me.Amon.Hosts
{
    /// <summary>
    /// Description of Group.
    /// </summary>
    public class Group
    {
        private const string PATTERN_READ = "^#\\s*[-]+[^.]*";
        private const string FORMAT_WRITE = "# --------------------{0}--------------------";

        public Group()
        {
        }

        public string Key { get; set; }

        public string Text { get; set; }

        public static bool IsMatch(string text)
        {
            return Regex.IsMatch(text, PATTERN_READ);
        }

        public bool FromString(string text)
        {
            Match match = Regex.Match(text, "\\w+");
            if (match.Success)
            {
                Key = match.Value;
                Text = Key;
                return true;
            }
            return false;
        }

        public void Save(StreamWriter writer)
        {
            if (!string.IsNullOrWhiteSpace(Key))
            {
                writer.WriteLine(string.Format(FORMAT_WRITE, Text));
            }
        }

        public override string ToString()
        {
            return Text;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Group))
            {
                return false;
            }
            var group = obj as Group;
            return group.Key == Key;
        }
    }
}
