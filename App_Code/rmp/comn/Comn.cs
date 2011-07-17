using System;
using System.Data;
using cons;
using cons.io.db.comn;
using rmp.bean;
using rmp.io.db;
using rmp.util;

namespace rmp.comn
{
    /// <summary>
    /// Summary description for Comn
    /// </summary>
    public class Comn
    {
        private Comn()
        {
        }

        /// <summary>
        /// 获取国家列表信息
        /// </summary>
        /// <returns>
        /// ArrayList(K1V2):
        /// K:国家索引
        /// V1:国家简称
        /// V2:国家全称
        /// </returns>
        public static DataTable ReadStatList(string langHash)
        {
            DBAccess dba = new DBAccess();
            dba.addTable(ComnCons.C1110100);
            dba.addColumn(ComnCons.C1110102);
            dba.addColumn(ComnCons.C1110104);
            dba.addColumn(ComnCons.C1110105);
            dba.addWhere(ComnCons.C1110103, langHash);
            dba.addSort(ComnCons.C1110101, false);
            return dba.executeSelect();
        }

        /// <summary>
        /// 获取指定语言的国家信息
        /// </summary>
        /// <param name="langHash"></param>
        /// <param name="statHash"></param>
        /// <returns></returns>
        public static K1V2 ReadStatItem(string statHash, string langHash)
        {
            DBAccess dba = new DBAccess();
            dba.addTable(ComnCons.C1110100);
            dba.addColumn(ComnCons.C1110104);
            dba.addColumn(ComnCons.C1110105);
            dba.addWhere(ComnCons.C1110102, statHash);
            dba.addWhere(ComnCons.C1110103, langHash);
            DataTable dt = dba.executeSelect();
            K1V2 item = new K1V2();
            if (dt != null && dt.Rows.Count == 1)
            {
                item.K = langHash;
                item.V1 = dt.Rows[0][ComnCons.C1110104] + "";
                item.V2 = dt.Rows[0][ComnCons.C1110105] + "";
            }
            return item;
        }

        /// <summary>
        /// 获取语言列表信息
        /// </summary>
        /// <returns></returns>
        public static DataTable ReadLangList()
        {
            DBAccess dba = new DBAccess();
            dba.addTable(ComnCons.C1010100);
            dba.addColumn(ComnCons.C1010103);
            dba.addColumn(ComnCons.C1010106);
            dba.addColumn(ComnCons.C1010107);
            dba.addSort(ComnCons.C1010101, false);
            return dba.executeSelect();
        }

        /// <summary>
        /// 获取一级类别键值
        /// </summary>
        /// <param name="softHash">系统软件索引</param>
        /// <returns></returns>
        public static DataTable ReadCat1List(String softHash)
        {
            DBAccess dba = new DBAccess();
            dba.addTable(ComnCons.C2010000);
            dba.addWhere(ComnCons.C2010003, softHash);
            dba.addSort(ComnCons.C2010001, false);
            return dba.executeSelect();
        }

        /// <summary>
        /// 根据类别ID获取类别名称
        /// </summary>
        /// <param name="cat1Hash">一级类别索引</param>
        /// <param name="softHash">系统软件索引</param>
        /// <returns></returns>
        public static K1V3 ReadCat1Item(String cat1Hash, String softHash)
        {
            DBAccess dba = new DBAccess();
            dba.addTable(ComnCons.C2010000);
            dba.addColumn(ComnCons.C2010004);
            dba.addColumn(ComnCons.C2010005);
            dba.addColumn(ComnCons.C2010006);
            dba.addColumn(ComnCons.C2010007);
            dba.addWhere(ComnCons.C2010002, cat1Hash);
            dba.addWhere(ComnCons.C2010003, softHash);

            DataTable dt = dba.executeSelect();
            K1V3 item = new K1V3();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                item.K = row[ComnCons.C2010004] + ""; //类别名称
                item.V1 = row[ComnCons.C2010005] + ""; //类别提示
                item.V2 = row[ComnCons.C2010006] + ""; //类别键值
                item.V3 = row[ComnCons.C2010007] + ""; //类别描述
            }
            dt.Dispose();
            return item;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cat1Hash"></param>
        /// <returns></returns>
        public static DataTable ReadCat2List(String cat1Hash)
        {
            DBAccess dba = new DBAccess();
            dba.addTable(ComnCons.C2010100);
            dba.addWhere(ComnCons.C2010104, cat1Hash);
            dba.addSort(ComnCons.C2010101);
            return dba.executeSelect();
        }

        /// <summary>
        /// 根据类别ID获取类别名称
        /// </summary>
        /// <param name="cat2Hash">二级类别索引</param>
        /// <param name="cat1Hash">一级类别索引</param>
        /// <returns></returns>
        public static K1V3 ReadCat2Item(String cat2Hash, String cat1Hash)
        {
            DBAccess dba = new DBAccess();
            dba.addTable(ComnCons.C2010100);
            dba.addColumn(ComnCons.C2010105);
            dba.addColumn(ComnCons.C2010106);
            dba.addColumn(ComnCons.C2010107);
            dba.addColumn(ComnCons.C2010108);
            dba.addWhere(ComnCons.C2010103, cat2Hash);
            dba.addWhere(ComnCons.C2010104, cat1Hash);

            DataTable dt = dba.executeSelect();
            K1V3 item = new K1V3();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                item.K = row[ComnCons.C2010105] + ""; //类别名称
                item.V1 = row[ComnCons.C2010106] + ""; //类别提示
                item.V2 = row[ComnCons.C2010107] + ""; //类别键值
                item.V3 = row[ComnCons.C2010108] + ""; //类别描述
            }
            dt.Dispose();
            return item;
        }

        public static string SaveCat2Data(string cat1Hash, int cat2Indx, string cat2Hash, string cat2Name, string cat2Tips, string cat2Keys, string cat2Desp, bool isUpdate)
        {
            if (!StringUtil.isValidateHash(cat2Hash))
            {
                cat2Hash = HashUtil.getCurrTimeHex(false);
                isUpdate = false;
            }
            DBAccess dba = new DBAccess();
            dba.addTable(ComnCons.C2010100);
            dba.addParam(ComnCons.C2010101, cat2Indx);
            dba.addParam(ComnCons.C2010102, "1");
            dba.addParam(ComnCons.C2010105, WrpUtil.text2Db(cat2Name));
            dba.addParam(ComnCons.C2010106, WrpUtil.text2Db(cat2Tips));
            dba.addParam(ComnCons.C2010107, WrpUtil.text2Db(cat2Keys));
            dba.addParam(ComnCons.C2010108, WrpUtil.text2Db(cat2Desp));
            dba.addParam(ComnCons.C2010109, EnvCons.SQL_NOW, false);

            if (isUpdate)
            {
                dba.addWhere(ComnCons.C2010103, cat2Hash);
                dba.addWhere(ComnCons.C2010104, cat1Hash);
                dba.executeUpdate();
            }
            else
            {
                dba.addParam(ComnCons.C2010103, cat2Hash);
                dba.addParam(ComnCons.C2010104, cat1Hash);
                dba.addParam(ComnCons.C201010A, EnvCons.SQL_NOW, false);
                dba.executeInsert();
            }
            return cat2Hash;
        }
    }
}