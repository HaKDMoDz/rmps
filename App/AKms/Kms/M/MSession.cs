using System.Collections.Generic;
using Me.Amon.Kms.Enums;
using Me.Amon.Util;

namespace Me.Amon.Kms.M
{
    public class MSession
    {
        private string _language = "0";
        private readonly List<MSentence> _Question = new List<MSentence>();
        private readonly List<MSentence> _Response = new List<MSentence>();

        public string LastInput { get; set; }

        public string Language
        {
            get
            {
                return _language;
            }
            set
            {
                _language = CharUtil.IsValidateHash(value) ? value : "0";
            }
        }

        public EStyle Style { get; set; }

        public List<string> Category { get; set; }

        public List<MSentence> Question { get { return _Question; } }

        public int QIndex { get; set; }

        public List<MSentence> Response { get { return _Response; } }

        public int RIndex { get; set; }
    }
}
