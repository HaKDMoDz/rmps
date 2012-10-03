using System.Collections.Generic;
using Me.Amon.Api.Enums;

namespace Me.Amon.Api.Input
{
    /// <summary>
    /// The service contract for a keyboard simulator for the Windows platform.
    /// </summary>
    public interface IKeyboardSimulator
    {
        /// <summary>
        /// Simulates the key down gesture for the specified key.
        /// </summary>
        /// <param name="keyCode">The <see cref="VirtualKey"/> for the key.</param>
        void KeyDown(VirtualKey keyCode);

        /// <summary>
        /// Simulates the key press gesture for the specified key.
        /// </summary>
        /// <param name="keyCode">The <see cref="VirtualKey"/> for the key.</param>
        void KeyPress(VirtualKey keyCode);

        /// <summary>
        /// Simulates the key up gesture for the specified key.
        /// </summary>
        /// <param name="keyCode">The <see cref="VirtualKey"/> for the key.</param>
        void KeyUp(VirtualKey keyCode);

        /// <summary>
        /// Simulates a modified keystroke where there are multiple modifiers and multiple keys like CTRL-ALT-K-C where CTRL and ALT are the modifierKeys and K and C are the keys.
        /// The flow is Modifiers KeyDown in order, Keys Press in order, Modifiers KeyUp in reverse order.
        /// </summary>
        /// <param name="modifierKeyCodes">The list of <see cref="VirtualKey"/>s for the modifier keys.</param>
        /// <param name="keyCodes">The list of <see cref="VirtualKey"/>s for the keys to simulate.</param>
        void ModifiedKeyStroke(IEnumerable<VirtualKey> modifierKeyCodes, IEnumerable<VirtualKey> keyCodes);

        /// <summary>
        /// Simulates a modified keystroke where there are multiple modifiers and one key like CTRL-ALT-C where CTRL and ALT are the modifierKeys and C is the key.
        /// The flow is Modifiers KeyDown in order, Key Press, Modifiers KeyUp in reverse order.
        /// </summary>
        /// <param name="modifierKeyCodes">The list of <see cref="VirtualKey"/>s for the modifier keys.</param>
        /// <param name="keyCode">The <see cref="VirtualKey"/> for the key.</param>
        void ModifiedKeyStroke(IEnumerable<VirtualKey> modifierKeyCodes, VirtualKey keyCode);

        /// <summary>
        /// Simulates a modified keystroke where there is one modifier and multiple keys like CTRL-K-C where CTRL is the modifierKey and K and C are the keys.
        /// The flow is Modifier KeyDown, Keys Press in order, Modifier KeyUp.
        /// </summary>
        /// <param name="modifierKey">The <see cref="VirtualKey"/> for the modifier key.</param>
        /// <param name="keyCodes">The list of <see cref="VirtualKey"/>s for the keys to simulate.</param>
        void ModifiedKeyStroke(VirtualKey modifierKey, IEnumerable<VirtualKey> keyCodes);

        /// <summary>
        /// Simulates a simple modified keystroke like CTRL-C where CTRL is the modifierKey and C is the key.
        /// The flow is Modifier KeyDown, Key Press, Modifier KeyUp.
        /// </summary>
        /// <param name="modifierKeyCode">The <see cref="VirtualKey"/> for the  modifier key.</param>
        /// <param name="keyCode">The <see cref="VirtualKey"/> for the key.</param>
        void ModifiedKeyStroke(VirtualKey modifierKeyCode, VirtualKey keyCode);

        /// <summary>
        /// Simulates uninterrupted text entry via the keyboard.
        /// </summary>
        /// <param name="text">The text to be simulated.</param>
        void TextEntry(string text);

        void TextEntry(char text);
    }
}
