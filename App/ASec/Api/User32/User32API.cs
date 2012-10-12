using System;
using System.Runtime.InteropServices;
using Me.Amon.Api.Structures;

namespace Me.Amon.Api.User32
{
    public class User32API
    {
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);
    }
}
