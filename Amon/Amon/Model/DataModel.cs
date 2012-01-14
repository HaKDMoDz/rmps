using System.Collections.Generic;
using System.Data;
using System.IO;
using Me.Amon.Da;

namespace Me.Amon.Model
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
            _LibKey = new List<LibHeader>();
            _LibKey.Insert(0, new LibHeader { Id = "0", Name = "请选择" });

            DBAccess dba = _UserModel.DBAccess;
            dba.ReInit();
            dba.AddTable(IDat.APWD0300);
            dba.AddColumn(IDat.APWD0304);
            dba.AddColumn(IDat.APWD0306);
            dba.AddColumn(IDat.APWD0308);
            dba.AddWhere(IDat.APWD0302, "0");
            dba.AddWhere(IDat.APWD0303, _UserModel.Code);
            dba.AddSort(IDat.APWD0301, true);
            DataTable dt1 = dba.ExecuteSelect();
            foreach (DataRow r1 in dt1.Rows)
            {
                LibHeader header = new LibHeader();
                header.Id = r1[IDat.APWD0304] as string;
                header.Name = r1[IDat.APWD0306] as string;
                header.Memo = r1[IDat.APWD0308] as string;
                _LibKey.Add(header);

                dba.ReInit();
                dba.AddTable(IDat.APWD0300);
                dba.AddColumn(IDat.APWD0302);
                dba.AddColumn(IDat.APWD0304);
                dba.AddColumn(IDat.APWD0306);
                dba.AddColumn(IDat.APWD0307);
                dba.AddColumn(IDat.APWD0308);
                dba.AddWhere(IDat.APWD0305, header.Id);
                dba.AddWhere(IDat.APWD0303, _UserModel.Code);
                dba.AddSort(IDat.APWD0301, true);

                DataTable dt2 = dba.ExecuteSelect();
                foreach (DataRow r2 in dt2.Rows)
                {
                    LibDetail detail = new LibDetail();
                    detail.Type = (int)r2[IDat.APWD0302];
                    detail.Id = r2[IDat.APWD0304] as string;
                    detail.Name = r2[IDat.APWD0306] as string;
                    detail.Data = r2[IDat.APWD0307] as string;
                    detail.Memo = r2[IDat.APWD0308] as string;
                    header.Details.Add(detail);
                }
            }

            _DatDir = "dat" + Path.DirectorySeparatorChar + _UserModel.Code + Path.DirectorySeparatorChar;
            if (!Directory.Exists(_DatDir))
            {
                Directory.CreateDirectory(_DatDir);
            }
            _CatDir = _DatDir + "cat" + Path.DirectorySeparatorChar;
            if (!Directory.Exists(_CatDir))
            {
                Directory.CreateDirectory(_CatDir);
            }
            _KeyDir = _DatDir + "key" + Path.DirectorySeparatorChar;
            if (!Directory.Exists(_KeyDir))
            {
                Directory.CreateDirectory(_KeyDir);
            }
            _AttDir = _DatDir + "att" + Path.DirectorySeparatorChar;
            if (!Directory.Exists(_AttDir))
            {
                Directory.CreateDirectory(_AttDir);
            }
        }

        private string _DatDir;
        public string DatDir { get { return _DatDir; } }

        private string _CatDir;
        public string CatDir { get { return _CatDir; } }

        private string _KeyDir;
        public string KeyDir { get { return _KeyDir; } }

        private string _AttDir;
        public string AttDir { get { return _AttDir; } }

        #region 口令模板
        private List<LibHeader> _LibKey;
        public List<LibHeader> LibKey
        {
            get
            {
                return _LibKey;
            }
        }
        #endregion
    }
}
