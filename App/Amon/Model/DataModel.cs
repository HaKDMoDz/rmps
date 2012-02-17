using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using Me.Amon.Bean;
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
            #region 数据目录
            _DatDir = IEnv.DATA_DIR + Path.DirectorySeparatorChar + _UserModel.Code + Path.DirectorySeparatorChar;
            if (!Directory.Exists(_DatDir))
            {
                Directory.CreateDirectory(_DatDir);
            }
            _CatDir = _DatDir + "CAT" + Path.DirectorySeparatorChar;
            if (!Directory.Exists(_CatDir))
            {
                Directory.CreateDirectory(_CatDir);
            }
            _KeyDir = _DatDir + "KEY" + Path.DirectorySeparatorChar;
            if (!Directory.Exists(_KeyDir))
            {
                Directory.CreateDirectory(_KeyDir);
            }
            _AttDir = _DatDir + "ATT" + Path.DirectorySeparatorChar;
            if (!Directory.Exists(_AttDir))
            {
                Directory.CreateDirectory(_AttDir);
            }
            _AcfDir = _DatDir + "ACF" + Path.DirectorySeparatorChar;
            if (!Directory.Exists(_AcfDir))
            {
                Directory.CreateDirectory(_AcfDir);
            }
            #endregion

            #region 读取配置
            UcsLength = 8;
            _UcsKey = "aucs000000000005";
            #endregion

            #region 口令模板
            DBAccess dba = _UserModel.DBAccess;

            _LibList = new ObservableCollection<LibHeader>();
            _LibList.Insert(0, new LibHeader { Id = "0", Name = "请选择" });
            dba.ReInit();
            dba.AddTable(DBConst.APWD0300);
            dba.AddColumn(DBConst.APWD0304);
            dba.AddColumn(DBConst.APWD0306);
            dba.AddColumn(DBConst.APWD0308);
            dba.AddWhere(DBConst.APWD0302, "0");
            dba.AddWhere(DBConst.APWD0303, _UserModel.Code);
            dba.AddSort(DBConst.APWD0301, true);
            using (DataTable dt1 = dba.ExecuteSelect())
            {
                foreach (DataRow r1 in dt1.Rows)
                {
                    LibHeader header = new LibHeader();
                    header.Id = r1[DBConst.APWD0304] as string;
                    header.Name = r1[DBConst.APWD0306] as string;
                    header.Memo = r1[DBConst.APWD0308] as string;
                    _LibList.Add(header);

                    dba.ReInit();
                    dba.AddTable(DBConst.APWD0300);
                    dba.AddColumn(DBConst.APWD0302);
                    dba.AddColumn(DBConst.APWD0304);
                    dba.AddColumn(DBConst.APWD0306);
                    dba.AddColumn(DBConst.APWD0307);
                    dba.AddColumn(DBConst.APWD0308);
                    dba.AddWhere(DBConst.APWD0305, header.Id);
                    dba.AddWhere(DBConst.APWD0303, _UserModel.Code);
                    dba.AddSort(DBConst.APWD0301, true);

                    DataTable dt2 = dba.ExecuteSelect();
                    foreach (DataRow r2 in dt2.Rows)
                    {
                        LibDetail detail = new LibDetail();
                        detail.Type = (int)r2[DBConst.APWD0302];
                        detail.Id = r2[DBConst.APWD0304] as string;
                        detail.Name = r2[DBConst.APWD0306] as string;
                        detail.Data = r2[DBConst.APWD0307] as string;
                        detail.Memo = r2[DBConst.APWD0308] as string;
                        header.Details.Add(detail);
                    }
                }
            }
            LibModified = -1;
            #endregion

            #region 字符空间
            _UcsList = new ObservableCollection<Udc>();
            _UcsList.Add(new Udc { Id = "aucs000000000001", Name = "仅数字", Tips = "仅数字", Data = "0123456789" });
            _UcsList.Add(new Udc { Id = "aucs000000000002", Name = "大写字母", Tips = "大写字母", Data = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" });
            _UcsList.Add(new Udc { Id = "aucs000000000003", Name = "小写字母", Tips = "小写字母", Data = "abcdefghijklmnopqrstuvwxyz" });
            _UcsList.Add(new Udc { Id = "aucs000000000004", Name = "大小写字母", Tips = "大小写字母", Data = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz" });
            _UcsList.Add(new Udc { Id = "aucs000000000005", Name = "数字及字母", Tips = "数字及字母", Data = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz" });
            _UcsList.Add(new Udc { Id = "aucs000000000006", Name = "可输入英文符号", Tips = "可输入英文符号", Data = "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~" });
            foreach (Udc item in _UcsList)
            {
                if (item.Id == _UcsKey)
                {
                    UcsDefault = item;
                }
            }

            dba.ReInit();
            dba.AddTable(DBConst.AUDC0100);
            dba.AddColumn(DBConst.AUDC0103);
            dba.AddColumn(DBConst.AUDC0104);
            dba.AddColumn(DBConst.AUDC0105);
            dba.AddColumn(DBConst.AUDC0106);
            dba.AddColumn(DBConst.AUDC0107);
            dba.AddWhere(DBConst.AUDC0102, _UserModel.Code);
            dba.AddSort(DBConst.AUDC0101, true);
            using (DataTable dt = dba.ExecuteSelect())
            {
                foreach (DataRow row in dt.Rows)
                {
                    Udc item = new Udc();
                    item.Id = row[DBConst.AUDC0103] as string;
                    item.Name = row[DBConst.AUDC0104] as string;
                    item.Tips = row[DBConst.AUDC0105] as string;
                    item.Data = row[DBConst.AUDC0106] as string;
                    item.Memo = row[DBConst.AUDC0107] as string;
                    UcsList.Add(item);

                    if (item.Id == _UcsKey)
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

        private string _AcfDir;
        public string AcfDir { get { return _AcfDir; } }

        #region 口令模板
        private ObservableCollection<LibHeader> _LibList;
        public ObservableCollection<LibHeader> LibList
        {
            get
            {
                return _LibList;
            }
        }
        public int LibModified { get; set; }
        #endregion

        #region 字符集
        private ObservableCollection<Udc> _UcsList;
        public ObservableCollection<Udc> UcsList
        {
            get
            {
                return _UcsList;
            }
        }
        public int UcsModified { get; set; }
        private string _UcsKey;
        public Udc UcsDefault { get; set; }
        public int UcsLength { get; set; }
        #endregion
    }
}
