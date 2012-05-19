using System.Runtime.InteropServices;
using Me.Amon.Api.Enums;

namespace Me.Amon.Api.Struct
{
    [StructLayout(LayoutKind.Explicit)]
    public struct INPUT
    {
        [FieldOffset(0)]
        internal InputType type;
        [FieldOffset(4)]
        internal MOUSEINPUT mi;
        [FieldOffset(4)]
        internal KEYBDINPUT ki;
        [FieldOffset(4)]
        internal HARDWAREINPUT hi;
    }
}
