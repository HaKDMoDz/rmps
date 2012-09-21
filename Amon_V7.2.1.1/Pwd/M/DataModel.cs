using System.Collections.Generic;
using System.IO;
using Me.Amon.M;

namespace Me.Amon.Pwd.M
{
    public sealed class DataModel
    {
        private UserModel _UserModel;

        public DataModel(UserModel userModel)
        {
            _UserModel = userModel;
        }

        public void Init()
        {
            #region 数据目录
            _CatDir = Path.Combine(_UserModel.DatHome, "CAT");
            if (!Directory.Exists(_CatDir))
            {
                Directory.CreateDirectory(_CatDir);
            }
            _KeyDir = Path.Combine(_UserModel.DatHome, "KEY");
            if (!Directory.Exists(_KeyDir))
            {
                Directory.CreateDirectory(_KeyDir);
            }
            _AttDir = Path.Combine(_UserModel.DatHome, "ATT");
            if (!Directory.Exists(_AttDir))
            {
                Directory.CreateDirectory(_AttDir);
            }
            _AcfDir = Path.Combine(_UserModel.DatHome, "ACF");
            if (!Directory.Exists(_AcfDir))
            {
                Directory.CreateDirectory(_AcfDir);
            }
            #endregion

            _LibList = new List<Lib>();
            foreach (Lib lib in _UserModel.DBA.ListLib())
            {
                _LibList.Add(lib);
            }
            LibModified = 0x7FFFFFFF;
        }

        private string _CatDir;
        public string CatDir { get { return _CatDir; } }

        private string _KeyDir;
        public string KeyDir { get { return _KeyDir; } }

        private string _AttDir;
        public string AttDir { get { return _AttDir; } }

        private string _AcfDir;
        public string AcfDir { get { return _AcfDir; } }

        #region 口令模板
        private IList<Lib> _LibList;
        public IList<Lib> LibList
        {
            get
            {
                return _LibList;
            }
        }
        public int LibModified { get; set; }
        #endregion

        public UdcModel UdcModel { get; set; }
    }
}
