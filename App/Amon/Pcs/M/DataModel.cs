using System.Collections.Generic;
using Me.Amon.Da.Db;
using Me.Amon.M;
using Me.Amon.Util;

namespace Me.Amon.Pcs.M
{
    public class DataModel : ADataModel
    {
        public DataModel(AUserModel userModel)
        {
            _UserModel = userModel;
        }

        public void Init()
        {
            _DbEngine = new ODBEngine();
            _DbEngine.DbInit(_UserModel);
            if (_DbEngine.DbVersion.Version != 2)
            {
                _DbEngine.Upgrade();
            }
        }

        public void SavePcs(MPcs pcs)
        {
            if (!CharUtil.IsValidateCode(pcs.UserCode))
            {
                pcs.UserCode = _UserModel.Code;
            }
            _DbEngine.Store(pcs);
        }

        public void SaveMeta(CsMeta meta)
        {
        }

        public void RemovePcs(MPcs pcs)
        {
        }

        public void DeletePcs(MPcs pcs)
        {
            _DbEngine.Delete(pcs);
        }

        public IList<MPcs> ListPcs()
        {
            return _DbEngine.Query<MPcs>(
                delegate(MPcs pcs)
                {
                    return pcs.UserCode == _UserModel.Code;
                });
        }
    }
}
