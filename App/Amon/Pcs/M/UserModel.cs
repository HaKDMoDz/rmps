using System;
using System.IO;
using Me.Amon.M;

namespace Me.Amon.Pcs.M
{
    public sealed class UserModel : AUserModel
    {
        public override void Init()
        {
            if (File.Exists("Amon.tag"))
            {
                SysHome = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "阿木云存储");
                if (!Directory.Exists(SysHome))
                {
                    Directory.CreateDirectory(SysHome);
                }
            }
            else
            {
                SysHome = Environment.CurrentDirectory;
            }

            ResHome = SysHome;
            DatHome = Path.Combine(SysHome, "Dat", "A0000000");
        }
    }
}
