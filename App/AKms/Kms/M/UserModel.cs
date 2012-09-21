using System;
using System.IO;
using Me.Amon.M;

namespace Me.Amon.Kms.M
{
    public class UserModel : AUserModel
    {
        private static DataModel _DBA;

        public override void Init()
        {
            SysHome = Environment.CurrentDirectory;
            DatHome = Path.Combine(SysHome, "Dat");
        }
        public override void Load()
        {
            _DBA = new DataModel(this);
        }
    }
}
