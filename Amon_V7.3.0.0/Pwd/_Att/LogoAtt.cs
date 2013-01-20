using System.Drawing;
using Me.Amon.Util;

namespace Me.Amon.Pwd._Att
{
    public class LogoAtt : Att
    {
        public const int SPEC_LOGO_DIR = 0;// 字符空间索引
        public Image SmallIcon { get; set; }
        public Image LargeIcon { get; set; }

        public LogoAtt()
            : base(TYPE_LOGO, "", "")
        {
            Order = "徽标";
        }

        public override void SetDefault()
        {
            if (_Spec == null)
            {
                _Spec = new string[1];
            }

            _Spec[SPEC_LOGO_DIR] = ".";
        }

        public override string ToString()
        {
            return Data;
        }

        public Image LoadImage(string dir, string path, string file, string ext, Image def)
        {
            string temp;
            if (CharUtil.IsValidateHash(path))
            {
                temp = System.IO.Path.Combine(dir, path, file + ext);
            }
            else
            {
                temp = System.IO.Path.Combine(dir, file + ext);
            }
            return BeanUtil.ReadImage(temp, def);
        }
    }
}
