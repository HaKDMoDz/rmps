using System;
using System.Runtime.InteropServices;
using com.magickms.api.Enum;

namespace com.magickms.api.Struct
{
    [StructLayout(LayoutKind.Sequential)]
    public struct KEYBDINPUT
    {
        public ushort wVk;
        public ushort wScan;
        public uint dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    }
}
