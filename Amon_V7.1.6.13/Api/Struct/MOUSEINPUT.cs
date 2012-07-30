using System;
using System.Runtime.InteropServices;

namespace Me.Amon.Api.Struct
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MOUSEINPUT
    {
        int dx;
        int dy;
        uint mouseData;
        uint dwFlags;
        uint time;
        IntPtr dwExtraInfo;
    }
}
