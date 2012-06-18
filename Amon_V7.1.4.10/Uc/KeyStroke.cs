using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Me.Amon.Uc
{
    public class KeyStroke<T>
    {
        public bool Control { get; set; }
        public bool Alt { get; set; }
        public bool Shift { get; set; }
        public bool Meta { get; set; }
        public Keys Code { get; set; }
        public string Key { get; set; }
        public string Memo { get; set; }
        public string Command { get; set; }
        public IAction<T> Action { get; set; }

        public bool Decode(string key)
        {
            Key = Regex.Replace(key, "[^-+=`;',./\\[\\]a-zA-Z0-9]+", " ").Trim();
            key = Key.ToUpper();
            foreach (string t in key.Split(' '))
            {
                if (string.IsNullOrWhiteSpace(t))
                {
                    continue;
                }
                if ("CTRL" == t)
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
                    continue;
                }
                key = t;
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                return false;
            }
            Code = (Keys)Enum.Parse(typeof(Keys), key, true);
            return Code != Keys.None;
        }

        public override string ToString()
        {
            //StringBuilder buffer = new StringBuilder();
            //if (Control)
            //{
            //    buffer.Append(Keys.Control.ToString()).Append(' ');
            //}
            //if (Shift)
            //{
            //    buffer.Append(Keys.Shift.ToString()).Append(' ');
            //}
            //if (Alt)
            //{
            //    buffer.Append(Keys.Alt.ToString()).Append(' ');
            //}
            //buffer.Append(Code.ToString());
            //return buffer.ToString();
            return Key;
        }
    }
}