using System;
using System.Data;
using System.Collections;

using cons.io.db.comn;

using rmp.bean;
using rmp.io.db;

namespace rmp.wrp.soft
{
    /// <summary>
    /// Summary description for Soft
    /// </summary>
    public class Soft
    {
        private static ArrayList softList;

        private Soft()
        {
        }

        /// <summary>
        /// 由软件索引获取软件名称
        /// </summary>
        /// <param name="softIndx"></param>
        /// <returns></returns>
        public static String GetSoftName(String softIndx)
        {
            if (softList == null)
            {
                softList = new ArrayList();
                ReLoadSoftList();
            }

            foreach (K1V3 item in softList)
            {
                if (item.K == softIndx)
                {
                    return item.V1;
                }
            }
            return "<未知>";
        }

        /// <summary>
        /// 返回结果K1V3
        /// k:软件索引
        /// v1:软件名称
        /// v2:软件版本
        /// v3:发布日期
        /// </summary>
        public static ArrayList GetSoftList()
        {
            if (softList == null)
            {
                softList = new ArrayList();
                ReLoadSoftList();
            }
            return softList;
        }

        /// <summary>
        /// 返回结果K1V3
        /// k:软件索引
        /// v1:软件名称
        /// v2:软件版本
        /// v3:发布日期
        /// </summary>
        public static void ReLoadSoftList()
        {
            softList.Clear();

            String sqlTable = ComnCons.C0010100;
            String sqlSelect = String.Format("SELECT * FROM {0} WHERE {1}='{2}' ORDER BY {3} ASC", sqlTable, ComnCons.C0010102, "1", ComnCons.C0010104);
            DataView dataView = new DBAccess().CreateView(sqlTable, sqlSelect);

            DataRowView row;
            for (int i = 0, j = dataView.Count; i < j; i += 1)
            {
                row = dataView[i];
                softList.Add(new K1V3(row[ComnCons.C0010104].ToString(), row[ComnCons.C0010106].ToString(), row[ComnCons.C0010105].ToString(), row[ComnCons.C0010107].ToString()));
            }
            dataView.Dispose();
        }

        public static String GetStrategy(int strategy)
        {
            switch (strategy % 10)
            {
                case 1:
                    return "创建";
                case 2:
                    return "开发";
                case 3:
                    return "内测";
                case 4:
                    return "公测";
                case 5:
                    return "候选";
                case 6:
                    return "发行";
                case 7:
                    return "历史";
                default:
                    return "";
            }
        }
    }
}