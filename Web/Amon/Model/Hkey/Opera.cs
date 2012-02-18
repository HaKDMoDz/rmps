using System.Collections.Generic;

namespace Me.Amon.Model.Hkey
{
    public class Opera : Hotkey
    {
        public override bool LoadDef()
        {
            LoadControlKey();
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
    }
}
