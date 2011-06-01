using System.Runtime.InteropServices;

namespace com.magickms.api.Struct
{
    [StructLayout(LayoutKind.Sequential)]
    public struct HARDWAREINPUT
    {
        uint uMsg;
        ushort wParamL;
        ushort wParamH;
    }
}
