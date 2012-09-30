using System;
using System.IO;
using Me.Amon.M;
using Me.Amon.Util;

namespace Me.Amon.Kms.M
{
    public class UserModel : AUserModel
    {
        public string RobotName { get; set; }
        public string OwnerName { get; set; }

        public override void Init()
        {
            SysHome = Environment.CurrentDirectory;
            DatHome = Path.Combine(SysHome, "Dat");
        }

        public override void Load()
        {
            DataModel = new DataModel(this);

            const string file = "magickms.cfg";
            if (!File.Exists(file))
            {
                return;
            }

            Uc.Properties prop = new Uc.Properties();
            prop.Load(file);

            string solHash = prop.Get("sln.hash", "");
            if (CharUtil.IsValidateHash(solHash))
            {
                Solution = DataModel.ReadSolution(solHash);
            }
        }

        public bool Save()
        {
            const string file = "magickms.cfg";

            Uc.Properties prop = new Uc.Properties();
            prop.Load(file);
            prop.Save("magickms.cfg");
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        public void ReloadData(string hash)
        {
            Solution = DataModel.ReadSolution(hash);
        }

        public string Encode(string text)
        {
            return text != null ? text.Replace(RobotName, "$robot_name$").Replace(OwnerName, "$owner_name$") : "";
        }

        public string Decode(string text)
        {
            return text != null ? text.Replace("$owner_name$", OwnerName).Replace("$robot_name$", RobotName) : "";
        }

        public DataModel DataModel { get; private set; }

        public MSolution Solution { get; private set; }
    }
}
