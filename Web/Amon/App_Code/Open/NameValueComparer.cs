using System.Collections.Generic;

namespace Me.Amon.Open
{
    public class NameValueComparer : IComparer<KeyValuePair<string, string>>
    {
        public int Compare(KeyValuePair<string, string> x, KeyValuePair<string, string> y)
        {
            if (x.Key != y.Key)
            {
                return string.CompareOrdinal(x.Key, y.Key);
            }

            return string.CompareOrdinal(x.Value, y.Value);
        }
    }
}
