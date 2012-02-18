using System.Collections.Generic;

namespace Me.Amon.Model.Hkey
{
    public class MSIE : Hotkey
    {
        public override bool LoadDef()
        {
            LoadControlKey();
            LoadWindowsKey();
            return true;
        }

        private void LoadControlKey()
        {
            Dictionary<System.Windows.Input.Key, int> keys;
            if (_Hotkeys.ContainsKey(System.Windows.Input.ModifierKeys.Control))
            {
                keys = _Hotkeys[System.Windows.Input.ModifierKeys.Control];
                keys.Clear();
            }
            else
            {
                keys = new Dictionary<System.Windows.Input.Key, int>();
                _Hotkeys[System.Windows.Input.ModifierKeys.Control] = keys;
            }
        }

        private void LoadWindowsKey()
        {
            Dictionary<System.Windows.Input.Key, int> keys;
            if (_Hotkeys.ContainsKey(System.Windows.Input.ModifierKeys.Windows))
            {
                keys = _Hotkeys[System.Windows.Input.ModifierKeys.Windows];
                keys.Clear();
            }
            else
            {
                keys = new Dictionary<System.Windows.Input.Key, int>();
                _Hotkeys[System.Windows.Input.ModifierKeys.Windows] = keys;
            }

            keys[System.Windows.Input.Key.C] = Hotkey.ATT_COPY;
            keys[System.Windows.Input.Key.A] = Hotkey.KEY_APPEND;
            keys[System.Windows.Input.Key.S] = Hotkey.KEY_UPDATE;
        }
    }
}
