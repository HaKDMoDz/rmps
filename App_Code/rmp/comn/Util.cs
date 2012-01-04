using System;
using System.Data;
using System.Web.UI.WebControls;

using rmp.io.db;

namespace rmp.comn
{
    /// <summary>
    /// Util 的摘要说明
    /// </summary>
    public class Util
    {
        private Util()
        {
        }

        /// <summary>
        /// 初始化语言信息到下拉列表
        /// </summary>
        /// <param name="ddList"></param>
        /// <param name="needDL"></param>
        public static void InitLangData(DropDownList ddList, bool needDL)
        {
            if (needDL)
            {
                ddList.Items.Add(new ListItem("请选择", ""));
            }

            foreach (DataRow row in Comn.ReadLangList().Rows)
            {
                ddList.Items.Add(new ListItem(row[cons.io.db.comn.ComnCons.C1010106] + "", row[cons.io.db.comn.ComnCons.C1010103] + ""));
            }
        }

        /// <summary>
        /// 统计语言使用频率
        /// </summary>
        /// <param name="langHash"></param>
        public static void UpdtLangData(String langHash)
        {
            new DBAccess().UpdateStep(cons.io.db.comn.ComnCons.C1010100, cons.io.db.comn.ComnCons.C1010103, langHash, cons.io.db.comn.ComnCons.C1010101, 1);
        }

        /// <summary>
        /// 初始化国别信息到下拉列表
        /// </summary>
        /// <param name="ddList"></param>
        /// <param name="langId"></param>
        /// <param name="needDL"></param>
        public static void InitStatData(DropDownList ddList, String langId, bool needDL)
        {
            if (needDL)
            {
                ddList.Items.Add(new ListItem("请选择", ""));
            }

            foreach (DataRow row in Comn.ReadStatList(langId).Rows)
            {
                ddList.Items.Add(new ListItem(row[cons.io.db.comn.ComnCons.C1110104] + "", row[cons.io.db.comn.ComnCons.C1110102] + ""));
            }
        }

        /// <summary>
        /// 统计国别使用频率
        /// </summary>
        /// <param name="statHash"></param>
        public static void UpdtStatData(String statHash)
        {
            new DBAccess().UpdateStep(cons.io.db.comn.ComnCons.C1110100, cons.io.db.comn.ComnCons.C1110102, statHash, cons.io.db.comn.ComnCons.C1110101, 1);
        }

        /// <summary>
        /// 初始化类别信息到下拉列表
        /// </summary>
        /// <param name="ddList"></param>
        /// <param name="langId"></param>
        /// <param name="softId"></param>
        /// <param name="needDL"></param>
        public static void InitCat1Data(DropDownList ddList, String langId, String softId, bool needDL)
        {
            if (needDL)
            {
                ddList.Items.Add(new ListItem("请选择", ""));
            }

            foreach (DataRow row in Comn.ReadCat1List(softId).Rows)
            {
                ddList.Items.Add(new ListItem(row[cons.io.db.comn.ComnCons.C2010004].ToString(), row[cons.io.db.comn.ComnCons.C2010002].ToString()));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cat1Hash"></param>
        public static void UpdtCat1Data(String cat1Hash)
        {
            new DBAccess().UpdateStep(cons.io.db.comn.ComnCons.C2010000, cons.io.db.comn.ComnCons.C2010002, cat1Hash, cons.io.db.comn.ComnCons.C2010001, 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ddList"></param>
        /// <param name="cat1Id"></param>
        /// <param name="needDL"></param>
        public static void InitCat2Data(DropDownList ddList, String cat1Id, bool needDL)
        {
            if (needDL)
            {
                ddList.Items.Add(new ListItem("请选择", ""));
            }

            foreach (DataRow row in Comn.ReadCat2List(cat1Id).Rows)
            {
                ddList.Items.Add(new ListItem(row[cons.io.db.comn.ComnCons.C2010105].ToString(), row[cons.io.db.comn.ComnCons.C2010103].ToString()));
            }
        }
    }
}