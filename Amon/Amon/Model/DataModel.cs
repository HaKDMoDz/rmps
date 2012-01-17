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
            _AsfDir = _DatDir + "asf" + Path.DirectorySeparatorChar;
            if (!Directory.Exists(_AsfDir))
            {
                Directory.CreateDirectory(_AsfDir);
            }

            #region 口令模板
            DBAccess dba = _UserModel.DBAccess;

            _LibList = new List<LibHeader>();
            _LibList.Insert(0, new LibHeader { Id = "0", Name = "请选择" });
            dba.ReInit();
            dba.AddTable(IDat.APWD0300);
            dba.AddColumn(IDat.APWD0304);
            dba.AddColumn(IDat.APWD0306);
            dba.AddColumn(IDat.APWD0308);
            dba.AddWhere(IDat.APWD0302, "0");
            dba.AddWhere(IDat.APWD0303, _UserModel.Code);
            dba.AddSort(IDat.APWD0301, true);
            using (DataTable dt1 = dba.ExecuteSelect())
            {
                foreach (DataRow r1 in dt1.Rows)
                {
                    LibHeader header = new LibHeader();
                    header.Id = r1[IDat.APWD0304] as string;
                    header.Name = r1[IDat.APWD0306] as string;
                    header.Memo = r1[IDat.APWD0308] as string;
                    _LibList.Add(header);

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
            }
            LibModified = 0x7FFFFFFF;
            #endregion

            #region 字符空间
            _UcsList = new List<Ucs>();
            dba.ReInit();
            dba.AddTable(IDat.AUCS0100);
            dba.AddColumn(IDat.AUCS0103);
            dba.AddColumn(IDat.AUCS0104);
            dba.AddColumn(IDat.AUCS0105);
            dba.AddColumn(IDat.AUCS0106);
            dba.AddColumn(IDat.AUCS0107);
            dba.AddWhere(IDat.AUCS0102, _UserModel.Code);
            dba.AddSort(IDat.AUCS0101, true);
            using (DataTable dt = dba.ExecuteSelect())
            {
                foreach (DataRow row in dt.Rows)
                {
                    Ucs item = new Ucs();
                    item.Id = row[IDat.AUCS0103] as string;
                    item.Name = row[IDat.AUCS0104] as string;
                    item.Tips = row[IDat.AUCS0105] as string;
                    item.Data = row[IDat.AUCS0106] as string;
                    item.Memo = row[IDat.AUCS0107] as string;
                    UcsList.Add(item);

                    if (item.Id == _UcsDefault)
                    {
                        UcsDefault = item;
                    }
                }
            }
            UcsModified = 0x7FFFFFFF;
            #endregion
        }

        private string _DatDir;
        public string DatDir { get { return _DatDir; } }

        private string _CatDir;
        public string CatDir { get { return _CatDir; } }

        private string _KeyDir;
        public string KeyDir { get { return _KeyDir; } }

        private string _AttDir;
        public string AttDir { get { return _AttDir; } }

        private string _AsfDir;
        public string AsfDir { get { return _AsfDir; } }

        #region 口令模板
        private List<LibHeader> _LibList;
        public List<LibHeader> LibList
        {
            get
            {
                return _LibList;
            }
        }
        public int LibModified { get; set; }
        #endregion

        #region 字符集
        private List<Ucs> _UcsList;
        public List<Ucs> UcsList
        {
            get
            {
                return _UcsList;
            }
        }
        public int UcsModified { get; set; }
        private string _UcsDefault;
        public Ucs UcsDefault { get; set; }
        #endregion
    }
}
