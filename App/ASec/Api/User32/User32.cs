using System.Runtime.InteropServices;
using Me.Amon.Api.Enums;
using Me.Amon.Api.Structures;

namespace Me.Amon.Api.User32
{
    public class User32 : User32API
    {
        /// <summary>
        /// Get the associated Icon for a file or application, this method always returns
        /// an icon.  If the strPath is invalid or there is no idonc the default icon is returned
        /// </summary>
        /// <param name="strPath">full path to the file</param>
        /// <param name="bSmall">if true, the 16x16 icon is returned otherwise the 32x32</param>
        /// <returns></returns>
        public static SHFILEINFO GetFileInfo(string strPath, bool bSmall)
        {
            SHFILEINFO info = new SHFILEINFO();
            int cbFileInfo = Marshal.SizeOf(info);
            FileInfoFlags flags = FileInfoFlags.SHGFI_ICON | FileInfoFlags.SHGFI_DISPLAYNAME | FileInfoFlags.SHGFI_TYPENAME | FileInfoFlags.SHGFI_USEFILEATTRIBUTES;
            flags |= bSmall ? FileInfoFlags.SHGFI_SMALLICON : FileInfoFlags.SHGFI_LARGEICON;

            SHGetFileInfo(strPath, (uint)FileAttributes.Normal, ref info, (uint)cbFileInfo, (uint)flags);
            return info;
        }
    }
}
