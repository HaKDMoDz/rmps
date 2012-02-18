using System.Collections.Generic;

namespace Me.Amon.Model.Hkey
{
    public class Chrome : Hotkey
    {
        public override bool LoadDef()
        {
            LoadControlKey();
            LoadAltKey();
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

            keys[System.Windows.Input.Key.S] = Hotkey.ATT_SAVE;
        }

        private void LoadAltKey()
        {
            Dictionary<System.Windows.Input.Key, int> keys;
            if (_Hotkeys.ContainsKey(System.Windows.Input.ModifierKeys.Alt))
            {
                keys = _Hotkeys[System.Windows.Input.ModifierKeys.Alt];
                keys.Clear();
            }
            else
            {
                keys = new Dictionary<System.Windows.Input.Key, int>();
                _Hotkeys[System.Windows.Input.ModifierKeys.Alt] = keys;
            }

            keys[System.Windows.Input.Key.C] = Hotkey.ATT_COPY;
        }
    }
}
