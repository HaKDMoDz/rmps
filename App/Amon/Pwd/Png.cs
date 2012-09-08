using System.Drawing;
using Me.Amon.Util;

namespace Me.Amon.Pwd
{
    public class Png
    {
        public string Path { get; set; }

        public string File { get; set; }

        public Image LargeImage { get; set; }

        public Image SmallImage { get; set; }

        public Image LoadImage(string dir, string ext, Image def)
        {
            string temp;
            if (CharUtil.IsValidateHash(Path))
            {
                temp = System.IO.Path.Combine(dir, Path, File + ext);
            }
            else
            {
                temp = System.IO.Path.Combine(dir, File + ext);
            }
            return BeanUtil.ReadImage(temp, def);
        }
    }
}
