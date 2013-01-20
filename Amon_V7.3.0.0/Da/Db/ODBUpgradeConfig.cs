using Db4objects.Db4o.Config;

namespace Me.Amon.Da.Db
{
    class ODBUpgradeConfig : IAlias
    {
        public string ResolveRuntimeName(string runtimeTypeName)
        {
            return null;
        }

        public string ResolveStoredName(string storedTypeName)
        {
            if (storedTypeName.IndexOf(".M.") < 0)
            {
                if (storedTypeName.IndexOf(".Gtd.") >= 0)
                {
                    return storedTypeName.Replace(".Gtd.", ".Gtd.M.");
                }
                if (storedTypeName.IndexOf(".Pwd.") >= 0)
                {
                    return storedTypeName.Replace(".Pwd.", ".Pwd.M.");
                }
            }
            return null;
        }
    }
}
