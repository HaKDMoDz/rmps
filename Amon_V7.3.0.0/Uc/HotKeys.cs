using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Me.Amon.Api.Enums;
using Me.Amon.E;

namespace Me.Amon.Uc
{
    public class Hotkey<T>
    {
        public int Id { get; set; }
        public Keys Code { get; set; }
        public string Key { get; set; }
        public string Memo { get; set; }
        public string Command { get; set; }
        public KeyModifiers Modifiers { get; set; }
        public IAction<T> Action { get; set; }

        public bool Decode(string key)
        {
            Modifiers = KeyModifiers.None;

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
                    Modifiers |= KeyModifiers.Ctrl;
                    continue;
                }
                if ("ALT" == t)
                {
                    Modifiers |= KeyModifiers.Alt;
                    continue;
                }
                if ("SHIFT" == t)
                {
                    Modifiers |= KeyModifiers.Shift;
                    continue;
                }
                if ("META" == t)
                {
                    Modifiers |= KeyModifiers.WindowsKey;
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
            return Key;
        }
    }
}
