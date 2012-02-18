using System.Collections.Generic;
using System.Windows.Input;
using Me.Amon.Model.Hkey;

namespace Me.Amon.Model
{
    public delegate void HotkeyEnventHandler();

    public abstract class Hotkey
    {
        protected static Dictionary<ModifierKeys, Dictionary<System.Windows.Input.Key, int>> _Hotkeys = new Dictionary<ModifierKeys, Dictionary<System.Windows.Input.Key, int>>();
        private static Dictionary<int, HotkeyEnventHandler> _Handler = new Dictionary<int, HotkeyEnventHandler>();

        public Hotkey()
        {
        }

        public static Hotkey GetInstance(string key)
        {
            Hotkey hotkey;
            switch (key)
            {
                case "msie":
                    hotkey = new MSIE();
                    break;
                case "chrome":
                    hotkey = new Chrome();
                    break;
                case "firefox":
                    hotkey = new Firefox();
                    break;
                case "safari":
                    hotkey = new Safari();
                    break;
                case "opera":
                    hotkey = new Opera();
                    break;
                default:
                    hotkey = new None();
                    break;
            }
            hotkey.LoadDef();
            return hotkey;
        }

        public static void RegisterHandler(int key, HotkeyEnventHandler handler)
        {
            _Handler[key] = handler;
        }

        public abstract bool LoadDef();

        public HotkeyEnventHandler GetHotKey(ModifierKeys mod, System.Windows.Input.Key key)
        {
            if (!_Hotkeys.ContainsKey(mod))
            {
                return null;
            }
            Dictionary<System.Windows.Input.Key, int> tmp = _Hotkeys[mod];
            if (!tmp.ContainsKey(key))
            {
                return null;
            }
            int idx = tmp[key];
            return _Handler.ContainsKey(idx) ? _Handler[idx] : null;
        }

        #region
        public const int CAT_APPEND = 0;
        public const int CAT_UPDATE = CAT_APPEND + 1;
        public const int CAT_REMOVE = CAT_UPDATE + 1;
        public const int KEY_APPEND = CAT_REMOVE + 1;
        public const int KEY_UPDATE = KEY_APPEND + 1;
        public const int KEY_REMOVE = KEY_UPDATE + 1;
        public const int KEY_LABEL = KEY_REMOVE + 1;
        public const int KEY_MAJOR = KEY_LABEL + 1;
        public const int ATT_APPEND = KEY_MAJOR + 1;
        public const int ATT_UPDATE = ATT_APPEND + 1;
        public const int ATT_REMOVE = ATT_UPDATE + 1;
        public const int ATT_COPY = ATT_REMOVE + 1;
        public const int ATT_SAVE = ATT_COPY + 1;
        public const int ATT_DROP = ATT_SAVE + 1;
        #endregion
    }
}
