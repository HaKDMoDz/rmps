using System.Drawing;
using System.Runtime.InteropServices;

namespace Me.Amon.Api.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;

        public Rectangle ToRectangle()
        {
            return new Rectangle(left, top, right - left, bottom - top);
        }
    }
}
