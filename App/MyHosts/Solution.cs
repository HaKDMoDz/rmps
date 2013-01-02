using System.IO;
using System.Text.RegularExpressions;

namespace Me.Amon.Hosts
{
    public class Solution
    {
        private const string PATTERN_READ = "^#\\s*[=]+[^.]*";
        private const string FORMAT_WRITE = "# ===================={0}====================";

        public Solution()
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
                Text = match.Value;
                return true;
            }
            return false;
        }

        public void Save(StreamWriter writer)
        {
            if (!string.IsNullOrWhiteSpace(Text))
            {
                writer.WriteLine(string.Format(FORMAT_WRITE, Text));
            }
        }
    }
}
