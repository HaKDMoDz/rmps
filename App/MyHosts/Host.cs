using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Me.Amon.Hosts
{
    /// <summary>
    /// Description of Hosts.
    /// </summary>
    public class Host
    {
        private const string PATTERN_READ = "^(#\\s*)?[.:0-9a-fA-F]{3,}\\s+\\w+";
        private const string FORMAT_WRITE = "######{0}######";

        public Host()
        {
        }

        #region
        public string Group { get; set; }

        private string _IPSrc;
        private string _IPDst;
        public string IP
        {
            get
            {
                return _IPDst;
            }
            set
            {
                _IPDst = value;
                Modified = _IPSrc != _IPDst || _DomainSrc != _DomainDst || _CommentSrc != _CommentDst;
            }
        }

        private string _DomainSrc;
        private string _DomainDst;
        public string Domain
        {
            get
            {
                return _DomainDst;
            }
            set
            {
                _DomainDst = value;
                Modified = _IPSrc != _IPDst || _DomainSrc != _DomainDst || _CommentSrc != _CommentDst;
            }
        }

        private string _CommentSrc;
        private string _CommentDst;
        public string Comment
        {
            get
            {
                return _CommentDst;
            }
            set
            {
                _CommentDst = value;
                Modified = _IPSrc != _IPDst || _DomainSrc != _DomainDst || _CommentSrc != _CommentDst;
            }
        }

        private bool _EnabledSrc;
        public bool Enabled { get; set; }
        #endregion

        public bool Modified { get; private set; }

        public static bool IsMatch(string text)
        {
            return Regex.IsMatch(text, PATTERN_READ);
        }

        public bool FromString(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            text = text.Trim();
            if (text[0] == '#')
            {
                _EnabledSrc = false;
                text = text.Substring(1).Trim();
            }
            else
            {
                _EnabledSrc = true;
            }

            var arr = Regex.Split(text, "\\s+");
            if (arr.Length < 2)
            {
                return false;
            }

            int i = 0;
            _IPSrc = arr[i++];
            _DomainSrc = arr[i++];
            _CommentSrc = "";
            while (i < arr.Length)
            {
                _CommentSrc += arr[i++];
            }
            _CommentSrc = _CommentSrc.TrimStart('#').Trim();

            Enabled = _EnabledSrc;
            IP = _IPSrc;
            Domain = _DomainSrc;
            Comment = _CommentSrc;
            return true;
        }

        public void Save(StreamWriter writer)
        {
            StringBuilder buffer = new StringBuilder();
            if (!Enabled)
            {
                buffer.Append("# ");
            }

            buffer.Append(IP);
            buffer.Append('\t');
            if (buffer.Length < 16)
            {
                buffer.Append('\t');
            }
            _IPSrc = IP;

            buffer.Append(Domain);
            buffer.Append('\t');
            _DomainSrc = Domain;

            buffer.Append(Comment);
            _CommentSrc = Comment;

            writer.WriteLine(buffer.ToString());
        }

        #region Equals and GetHashCode implementation
        public override int GetHashCode()
        {
            return (IP + Domain).GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Host other = obj as Host;
            if (other == null)
                return false;
            return this.IP == other.IP && this.Domain == other.Domain;
        }

        public static bool operator ==(Host lhs, Host rhs)
        {
            if (ReferenceEquals(lhs, rhs))
                return true;
            if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
                return false;
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Host lhs, Host rhs)
        {
            return !(lhs == rhs);
        }
        #endregion

    }
}
