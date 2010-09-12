using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using cons;

using rmp.bean;
using rmp.io.db;
using rmp.util;
using Image = System.Drawing.Image;
using WrpCons = cons.wrp.WrpCons;

namespace rmp.wrp.exts
{
    /// <summary>
    /// Summary description for Exts
    /// </summary>
    public class Exts
    {
        private static int extsSize = -1;
        /// <summary>
        /// 系统用户最后更新的后缀数据
        /// </summary>
        private static ArrayList recentUpdate;
        private static int updtSize = 27;

        private Exts()
        {
        }

        /// <summary>
        /// 后缀记录总量
        /// </summary>
        public static int ExtsSize
        {
            get
            {
                if (extsSize == -1)
                {
                    extsSize = CountExts();
                }
                return extsSize;
            }
            set { extsSize = value; }
        }

        /// <summary>
        /// 所显示的最近更新的数量
        /// </summary>
        public static int RecentUpdateCount
        {
            get { return updtSize; }
            set { updtSize = value; }
        }

        /// <summary>
        /// 查询后缀记录个数
        /// </summary>
        /// <returns></returns>
        public static int CountExts()
        {
            DBAccess dba = new DBAccess();
            DataTable dataList = dba.executeSelect(String.Format("SELECT COUNT({1}) AS {1} FROM {0}", cons.io.db.prp.PrpCons.P3010000, cons.io.db.prp.PrpCons.P3010003));
            int size = Int32.Parse(dataList.Rows[0][cons.io.db.prp.PrpCons.P3010003].ToString());
            dataList.Dispose();
            return size;
        }

        /// <summary>
        /// 记录用户查询历史信息
        /// </summary>
        /// <param name="Session"></param>
        /// <param name="exts"></param>
        public static void appendHistory(HttpSessionState Session, String exts)
        {
            ArrayList list = searchHistory(Session);
            if (list.Count >= 20)
            {
                list.RemoveAt(0);
            }
            list.Add(new K1V1(DateTime.Now.ToString(), exts));
        }

        /// <summary>
        /// 获取用户查询历史记录列表
        /// </summary>
        /// <param name="Session"></param>
        /// <returns></returns>
        public static ArrayList searchHistory(HttpSessionState Session)
        {
            ArrayList list = (ArrayList)Session[cons.wrp.WrpCons.P3010000_LIST];
            if (list == null)
            {
                list = new ArrayList(32);
                Session.Add(WrpCons.P3010000_LIST, list);
            }
            return list;
        }

        /// <summary>
        /// 记录用户当前查询信息
        /// </summary>
        /// <param name="Session"></param>
        /// <param name="extsHash"></param>
        /// <param name="extsName"></param>
        /// <param name="extsCase"></param>
        public static void saveQuery(HttpSessionState Session, String extsHash, String extsName, String extsCase)
        {
            Session[WrpCons.P3010000_EXTS] = new K1V2(extsHash, extsName, extsCase);
        }

        /// <summary>
        /// 读取用户已有查询信息，系统保证此对象总不为空
        /// </summary>
        /// <param name="Session"></param>
        /// <returns></returns>
        public static K1V2 readQuery(HttpSessionState Session)
        {
            K1V2 exts = (K1V2)Session[cons.wrp.WrpCons.P3010000_EXTS];
            if (exts == null)
            {
                exts = new K1V2();
                Session[WrpCons.P3010000_EXTS] = exts;
            }
            return exts;
        }

        /// <summary>
        /// 读取或设置是否需要重新加载页面数据，此方法用于返回Session中已有标记状态，并重置为新的标记状态。
        /// </summary>
        /// <param name="Session"></param>
        /// <param name="srch"></param>
        public static bool needQuery(HttpSessionState Session, bool srch)
        {
            String need = (String)Session[cons.wrp.WrpCons.P3010000_SRCH];
            Session[WrpCons.P3010000_SRCH] = srch ? "1" : "0";
            return "1" == need;
        }

        /// <summary>
        /// 获取最近更新列表
        /// </summary>
        /// <returns></returns>
        public static ArrayList getRecentUpdate()
        {
            if (recentUpdate == null)
            {
                recentUpdate = new ArrayList();
                reLoadRecentUpdate();
            }
            return recentUpdate;
        }

        /// <summary>
        /// 记录最近更新后缀信息
        /// </summary>
        /// <param name="extsName"></param>
        public static void addRecentUpdate(String extsName)
        {
            if (recentUpdate == null)
            {
                recentUpdate = new ArrayList();
                reLoadRecentUpdate();
            }

            int idx = 0;
            foreach (K1V1 item in recentUpdate)
            {
                if (item.V.ToUpper() == extsName.ToUpper())
                {
                    break;
                }
                idx += 1;
            }
            if (idx >= updtSize)
            {
                idx = updtSize - 1;
            }
            recentUpdate.RemoveAt(idx);
            recentUpdate.Insert(0, new K1V1(DateTime.Now.ToString(), extsName));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="extsName"></param>
        /// <param name="dateTime"></param>
        public static void addRecentUpdate(String extsName, String dateTime)
        {
            foreach (K1V1 item in recentUpdate)
            {
                if (item.V.ToUpper() == extsName.ToUpper())
                {
                    return;
                }
            }
            recentUpdate.Add(new K1V1(dateTime, extsName));
        }

        /// <summary>
        /// 重新读取最近更新后缀信息
        /// </summary>
        public static void reLoadRecentUpdate()
        {
            recentUpdate.Clear();

            DBAccess dba = new DBAccess();
            dba.addTable(cons.io.db.prp.PrpCons.P3010000);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010013);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010011);
            dba.addSort(cons.io.db.prp.PrpCons.P3010011, false);

            DataTable dataList = dba.executeSelect();
            int t = dataList.Rows.Count;
            if (t > updtSize)
            {
                t = updtSize;
            }
            int i = 0;
            while (recentUpdate.Count < t)
            {
                DataRow row = dataList.Rows[i++];
                addRecentUpdate("." + row[cons.io.db.prp.PrpCons.P3010013], row[cons.io.db.prp.PrpCons.P3010011].ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bits"></param>
        /// <returns></returns>
        public static String decodeArchBits(int bits)
        {
            const string sp = "、";
            String ab = "";

            // 64位
            if ((bits & SysCons.BITS_IDX_64) != 0)
            {
                ab += sp + "64位";
            }
            // 32位
            if ((bits & SysCons.BITS_IDX_32) != 0)
            {
                ab += sp + "32位";
            }
            // 16位
            if ((bits & SysCons.BITS_IDX_16) != 0)
            {
                ab += sp + "16位";
            }
            // 其它
            if (SysCons.BITS_IDX_00 == bits)
            {
                ab += sp + "其它";
            }

            // 去除分隔符
            if (ab.Length > 1)
            {
                ab = ab.Substring(sp.Length);
            }
            return ab;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="platForm"></param>
        /// <returns></returns>
        public static String decodePlatForm(int platForm)
        {
            // 平台通用
            if (SysCons.OS_IDX_ALL == platForm)
            {
                return "平台通用";
            }

            const string sp = "、";
            String pf = "";

            // Windows平台
            if ((platForm & SysCons.OS_IDX_WINDOWS) != 0)
            {
                pf += sp + "Windows";
            }
            // Mac OS平台
            if ((platForm & SysCons.OS_IDX_MACINTOSH) != 0)
            {
                pf += sp + "Macintosh";
            }
            // Linux平台
            if ((platForm & SysCons.OS_IDX_LINUX) != 0)
            {
                pf += sp + "Linux";
            }
            // Unix平台
            if ((platForm & SysCons.OS_IDX_UNIX) != 0)
            {
                pf += sp + "Unix";
            }
            // 移动平台
            if ((platForm & SysCons.OS_IDX_MOBILE) != 0)
            {
                pf += sp + "移动平台";
            }
            // 其它平台
            if ((platForm & SysCons.OS_IDX_UNKNOWN) != 0)
            {
                pf += sp + "其它平台";
            }

            // 去除分隔符
            if (pf.Length > 1)
            {
                pf = pf.Substring(sp.Length);
            }
            return pf;
        }

        /// <summary>
        /// 根据后缀摘要进行数据查询
        /// </summary>
        /// <param name="dba"></param>
        /// <param name="extsHash"></param>
        /// <param name="softHash"></param>
        public static DataTable srchHash(DBAccess dba, String extsHash, String softHash)
        {
            dba.reset();

            dba.addTable("P3010000 LEFT JOIN P3010200 ON P3010006=P3010202");

            dba.addColumn(cons.io.db.prp.PrpCons.P3010001);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010002);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010003);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010004);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010005);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010006);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010007);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010008);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010009);
            dba.addColumn(cons.io.db.prp.PrpCons.P301000A);
            dba.addColumn(cons.io.db.prp.PrpCons.P301000B);
            dba.addColumn(cons.io.db.prp.PrpCons.P301000C);
            dba.addColumn(cons.io.db.prp.PrpCons.P301000D);
            dba.addColumn(cons.io.db.prp.PrpCons.P301000E);
            dba.addColumn(cons.io.db.prp.PrpCons.P301000F);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010010);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010011);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010012);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010013);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010014);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010015);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010016);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010205);
            dba.addWhere(cons.io.db.prp.PrpCons.P3010003, extsHash);
            if (StringUtil.isValidate(softHash))
            {
                dba.addWhere(cons.io.db.prp.PrpCons.P3010006, softHash);
            }
            dba.addSort(cons.io.db.prp.PrpCons.P3010001, false);

            return dba.executeSelect();
        }

        /// <summary>
        /// 根据后缀名称进行数据查询
        /// </summary>
        /// <param name="dba"></param>
        /// <param name="extsName"></param>
        /// <param name="softHash"></param>
        public static DataTable srchName(DBAccess dba, String extsName, String softHash)
        {
            dba.reset();

            dba.addTable("P3010000 LEFT JOIN P3010200 ON P3010006=P3010202");

            dba.addColumn(cons.io.db.prp.PrpCons.P3010001);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010002);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010003);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010004);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010005);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010006);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010007);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010008);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010009);
            dba.addColumn(cons.io.db.prp.PrpCons.P301000A);
            dba.addColumn(cons.io.db.prp.PrpCons.P301000B);
            dba.addColumn(cons.io.db.prp.PrpCons.P301000C);
            dba.addColumn(cons.io.db.prp.PrpCons.P301000D);
            dba.addColumn(cons.io.db.prp.PrpCons.P301000E);
            dba.addColumn(cons.io.db.prp.PrpCons.P301000F);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010010);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010011);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010012);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010013);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010014);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010015);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010016);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010205);
            dba.addWhere(cons.io.db.prp.PrpCons.P3010013, extsName);
            if (StringUtil.isValidate(softHash))
            {
                dba.addWhere(cons.io.db.prp.PrpCons.P3010006, softHash);
            }
            dba.addSort(cons.io.db.prp.PrpCons.P3010001, false);

            return dba.executeSelect();
        }

        /// <summary>
        /// 描述信息
        /// </summary>
        /// <param name="dba"></param>
        /// <param name="despHash"></param>
        /// <returns></returns>
        public static DataTable ReadDesp(DBAccess dba, String despHash)
        {
            dba.reset();

            dba.addTable(String.Format("{0} LEFT JOIN {1} ON {2}={3}", cons.io.db.prp.PrpCons.P3010500, cons.io.db.comn.user.UserCons.C3010400, cons.io.db.prp.PrpCons.P3010509, cons.io.db.comn.user.UserCons.C3010402));
            dba.addColumn(cons.io.db.prp.PrpCons.P3010501);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010503);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010504);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010505);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010506);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010507);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010508);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010509);
            dba.addColumn(cons.io.db.comn.user.UserCons.C3010407);
            dba.addWhere(cons.io.db.prp.PrpCons.P3010501, despHash);
            dba.addWhere(cons.io.db.prp.PrpCons.P3010502, SysCons.UI_LANGHASH);
            dba.addSort(cons.io.db.prp.PrpCons.P3010505, false);
            dba.addLimit(1);

            return dba.executeSelect();
        }

        /// <summary>
        /// MIME信息
        /// </summary>
        /// <param name="dba"></param>
        /// <param name="mimeHash"></param>
        /// <returns></returns>
        public static DataTable ReadMime(DBAccess dba, String mimeHash)
        {
            dba.reset();

            dba.addTable(String.Format("{0} LEFT JOIN {1} ON {2}={3}", cons.io.db.prp.PrpCons.P3010600, cons.io.db.prp.PrpCons.P301F100, cons.io.db.prp.PrpCons.P3010603, cons.io.db.prp.PrpCons.P301F102));
            dba.addTable(cons.io.db.comn.user.UserCons.C3010400);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010603);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010604);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010607);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010608);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010609);
            dba.addColumn(cons.io.db.prp.PrpCons.P301F104);
            dba.addColumn(cons.io.db.comn.user.UserCons.C3010407);
            dba.addWhere(cons.io.db.prp.PrpCons.P3010609, cons.io.db.comn.user.UserCons.C3010402, false);
            dba.addWhere(cons.io.db.prp.PrpCons.P3010602, mimeHash);
            dba.addWhere(cons.io.db.prp.PrpCons.P301F103, SysCons.UI_LANGHASH);
            dba.addSort(cons.io.db.prp.PrpCons.P3010601, false);

            return dba.executeSelect();
        }

        /// <summary>
        /// 操作平台
        /// </summary>
        /// <param name="dba"></param>
        /// <param name="platHash"></param>
        /// <returns></returns>
        public static DataTable ReadPlat(DBAccess dba, String platHash)
        {
            dba.reset();

            dba.addTable(String.Format("{0} LEFT JOIN {1} ON {2}={3}", cons.io.db.prp.PrpCons.P3010800, cons.io.db.prp.PrpCons.P301F200, cons.io.db.prp.PrpCons.P3010803, cons.io.db.prp.PrpCons.P301F203));
            dba.addTable(cons.io.db.comn.user.UserCons.C3010400);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010803);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010804);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010807);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010808);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010809);
            dba.addColumn(cons.io.db.prp.PrpCons.P301F206);
            dba.addColumn(cons.io.db.comn.user.UserCons.C3010407);
            dba.addWhere(cons.io.db.prp.PrpCons.P3010809, cons.io.db.comn.user.UserCons.C3010402, false);
            dba.addWhere(cons.io.db.prp.PrpCons.P3010802, platHash);
            dba.addWhere(cons.io.db.prp.PrpCons.P301F204, SysCons.UI_LANGHASH);
            dba.addSort(cons.io.db.prp.PrpCons.P3010801, false);

            return dba.executeSelect();
        }

        /// <summary>
        /// 文档信息
        /// </summary>
        /// <param name="dba"></param>
        /// <param name="docsHash"></param>
        /// <returns></returns>
        public static DataTable ReadDocs(DBAccess dba, String docsHash)
        {
            dba.reset();

            dba.addTable(String.Format("{0} LEFT JOIN {1} ON {2}={3}", cons.io.db.prp.PrpCons.P3010400, cons.io.db.comn.user.UserCons.C3010400, cons.io.db.prp.PrpCons.P301040E, cons.io.db.comn.user.UserCons.C3010402));
            dba.addColumn(cons.io.db.prp.PrpCons.P3010402);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010404);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010405);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010406);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010407);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010408);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010409);
            dba.addColumn(cons.io.db.prp.PrpCons.P301040A);
            dba.addColumn(cons.io.db.prp.PrpCons.P301040B);
            dba.addColumn(cons.io.db.prp.PrpCons.P301040C);
            dba.addColumn(cons.io.db.prp.PrpCons.P301040D);
            dba.addColumn(cons.io.db.prp.PrpCons.P301040E);
            dba.addColumn(cons.io.db.comn.user.UserCons.C3010407);
            dba.addWhere(cons.io.db.prp.PrpCons.P3010402, docsHash);
            dba.addWhere(cons.io.db.prp.PrpCons.P3010403, SysCons.UI_LANGHASH);
            dba.addSort(cons.io.db.prp.PrpCons.P301040A, false);
            dba.addLimit(1);

            return dba.executeSelect();
        }

        /// <summary>
        /// 公司信息
        /// </summary>
        /// <param name="dba"></param>
        /// <param name="corpHash"></param>
        /// <returns></returns>
        public static DataTable ReadCorp(DBAccess dba, String corpHash)
        {
            dba.reset();

            dba.addTable(String.Format("{0} LEFT JOIN {1} ON {2}={3}", cons.io.db.prp.PrpCons.P3010100, cons.io.db.comn.user.UserCons.C3010400, cons.io.db.prp.PrpCons.P301010E, cons.io.db.comn.user.UserCons.C3010402));
            dba.addColumn(cons.io.db.prp.PrpCons.P3010102);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010103);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010104);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010105);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010106);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010107);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010108);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010109);
            dba.addColumn(cons.io.db.prp.PrpCons.P301010A);
            dba.addColumn(cons.io.db.prp.PrpCons.P301010B);
            dba.addColumn(cons.io.db.prp.PrpCons.P301010C);
            dba.addColumn(cons.io.db.prp.PrpCons.P301010D);
            dba.addColumn(cons.io.db.prp.PrpCons.P301010E);
            dba.addColumn(cons.io.db.comn.user.UserCons.C3010407);
            dba.addWhere(cons.io.db.prp.PrpCons.P3010102, corpHash);
            dba.addSort(cons.io.db.prp.PrpCons.P301010A, false);
            dba.addLimit(1);

            return dba.executeSelect();
        }

        /// <summary>
        /// 软件信息
        /// </summary>
        /// <param name="dba"></param>
        /// <param name="softHash"></param>
        /// <returns></returns>
        public static DataTable ReadSoft(DBAccess dba, String softHash)
        {
            dba.reset();

            dba.addTable(String.Format("{0} LEFT JOIN {1} ON {2}={3}", cons.io.db.prp.PrpCons.P3010200, cons.io.db.comn.user.UserCons.C3010400, cons.io.db.prp.PrpCons.P3010211, cons.io.db.comn.user.UserCons.C3010402));
            dba.addColumn(cons.io.db.prp.PrpCons.P3010202);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010204);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010205);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010206);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010207);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010208);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010209);
            dba.addColumn(cons.io.db.prp.PrpCons.P301020A);
            dba.addColumn(cons.io.db.prp.PrpCons.P301020B);
            dba.addColumn(cons.io.db.prp.PrpCons.P301020C);
            dba.addColumn(cons.io.db.prp.PrpCons.P301020D);
            dba.addColumn(cons.io.db.prp.PrpCons.P301020E);
            dba.addColumn(cons.io.db.prp.PrpCons.P301020F);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010210);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010211);
            dba.addColumn(cons.io.db.comn.user.UserCons.C3010407);
            dba.addWhere(cons.io.db.prp.PrpCons.P3010202, softHash);
            dba.addSort(cons.io.db.prp.PrpCons.P301020D, false);
            dba.addLimit(1);

            return dba.executeSelect();
        }

        /// <summary>
        /// 文件信息
        /// </summary>
        /// <param name="dba"></param>
        /// <param name="fileHash"></param>
        /// <returns></returns>
        public static DataTable ReadFile(DBAccess dba, String fileHash)
        {
            dba.reset();

            dba.addTable(String.Format("{0} LEFT JOIN {1} ON {2}={3}", cons.io.db.prp.PrpCons.P3010300, cons.io.db.comn.user.UserCons.C3010400, cons.io.db.prp.PrpCons.P3010311, cons.io.db.comn.user.UserCons.C3010402));
            dba.addColumn(cons.io.db.prp.PrpCons.P3010302);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010303);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010304);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010305);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010306);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010307);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010308);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010309);
            dba.addColumn(cons.io.db.prp.PrpCons.P301030A);
            dba.addColumn(cons.io.db.prp.PrpCons.P301030B);
            dba.addColumn(cons.io.db.prp.PrpCons.P301030C);
            dba.addColumn(cons.io.db.prp.PrpCons.P301030D);
            dba.addColumn(cons.io.db.prp.PrpCons.P301030E);
            dba.addColumn(cons.io.db.prp.PrpCons.P301030F);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010310);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010311);
            dba.addColumn(cons.io.db.comn.user.UserCons.C3010407);
            dba.addWhere(cons.io.db.prp.PrpCons.P3010302, fileHash);
            dba.addSort(cons.io.db.prp.PrpCons.P301030D, false);
            dba.addLimit(1);

            return dba.executeSelect();
        }

        /// <summary>
        /// 人员信息
        /// </summary>
        /// <param name="dba"></param>
        /// <param name="idioHash"></param>
        /// <returns></returns>
        public static DataTable ReadIdio(DBAccess dba, String idioHash)
        {
            dba.reset();

            dba.addTable(cons.io.db.comn.user.UserCons.C3010400);
            dba.addColumn(cons.io.db.comn.user.UserCons.C3010401);
            dba.addColumn(cons.io.db.comn.user.UserCons.C3010405);
            dba.addColumn(cons.io.db.comn.user.UserCons.C3010406);
            dba.addColumn(cons.io.db.comn.user.UserCons.C3010407);
            dba.addColumn(cons.io.db.comn.user.UserCons.C3010408);
            dba.addColumn(cons.io.db.comn.user.UserCons.C3010409);
            dba.addColumn(cons.io.db.comn.user.UserCons.C301040A);
            dba.addColumn(cons.io.db.comn.user.UserCons.C301040B);
            dba.addWhere(cons.io.db.comn.user.UserCons.C3010401, idioHash);

            return dba.executeSelect();
        }

        /// <summary>
        /// 备选软件
        /// </summary>
        /// <param name="dba"></param>
        /// <param name="asocHash"></param>
        /// <returns></returns>
        public static DataTable ReadAsoc(DBAccess dba, String asocHash)
        {
            dba.reset();

            dba.addTable(String.Format("{0} LEFT JOIN {1} ON {2}={3}", cons.io.db.prp.PrpCons.P3010700, cons.io.db.prp.PrpCons.P3010200, cons.io.db.prp.PrpCons.P3010704, cons.io.db.prp.PrpCons.P3010202));
            dba.addTable(cons.io.db.comn.user.UserCons.C3010400);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010702);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010704);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010705);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010706);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010709);
            dba.addColumn(cons.io.db.prp.PrpCons.P301070A);
            dba.addColumn(cons.io.db.prp.PrpCons.P301070B);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010204);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010205);
            dba.addColumn(cons.io.db.comn.user.UserCons.C3010407);
            dba.addWhere(cons.io.db.prp.PrpCons.P301070B, cons.io.db.comn.user.UserCons.C3010402, false);
            dba.addWhere(cons.io.db.prp.PrpCons.P3010703, asocHash);
            dba.addSort(cons.io.db.prp.PrpCons.P3010702, false);
            dba.addSort(cons.io.db.prp.PrpCons.P3010701, false);

            return dba.executeSelect();
        }

        /// <summary>
        /// 保存后缀基本信息数据
        /// </summary>
        /// <param name="bean"></param>
        /// <returns></returns>
        public static String SaveBase(Bean bean)
        {
            DBAccess dba = new DBAccess();
            dba.addTable(cons.io.db.prp.PrpCons.P3010000);
            dba.addParam(cons.io.db.prp.PrpCons.P3010002, bean.P3010002); //处理字长
            dba.addParam(cons.io.db.prp.PrpCons.P3010004, bean.P3010004); //国别信息
            dba.addParam(cons.io.db.prp.PrpCons.P3010005, bean.P3010005); //公司索引
            dba.addParam(cons.io.db.prp.PrpCons.P3010006, bean.P3010006); //软件索引
            dba.addParam(cons.io.db.prp.PrpCons.P3010007, bean.P3010007); //文件索引
            dba.addParam(cons.io.db.prp.PrpCons.P3010008, bean.P3010008); //文档格式
            dba.addParam(cons.io.db.prp.PrpCons.P301000C, bean.P301000C); //类别索引
            dba.addParam(cons.io.db.prp.PrpCons.P301000D, bean.P301000D); //家族平台
            dba.addParam(cons.io.db.prp.PrpCons.P301000F, bean.P301000F); //人员索引
            dba.addParam(cons.io.db.prp.PrpCons.P3010010, WrpUtil.text2Db(bean.P3010010)); //附注信息
            dba.addParam(cons.io.db.prp.PrpCons.P3010011, EnvCons.SQL_NOW, false); //更新日期

            String hash;
            if (bean.IsUpdate)
            {
                hash = bean.P3010009;

                dba.addWhere(cons.io.db.prp.PrpCons.P3010003, bean.P3010003); //后缀索引
                dba.addWhere(cons.io.db.prp.PrpCons.P3010006, bean.SoftHash); //软件索引

                dba.executeUpdate();
                addRecentUpdate(bean.P3010013);
            }
            else
            {
                // 附注信息、MIME类型、备选软件等索引
                hash = HashUtil.getCurrTimeHex(false);

                // 后缀索引
                dba.addParam(cons.io.db.prp.PrpCons.P3010003, bean.P3010003); //后缀索引
                dba.addParam(cons.io.db.prp.PrpCons.P3010009, hash);
                dba.addParam(cons.io.db.prp.PrpCons.P301000A, hash);
                dba.addParam(cons.io.db.prp.PrpCons.P301000B, hash);
                dba.addParam(cons.io.db.prp.PrpCons.P301000E, hash);
                dba.addParam(cons.io.db.prp.PrpCons.P3010001, 0);
                dba.addParam(cons.io.db.prp.PrpCons.P3010012, EnvCons.SQL_NOW, false);
                dba.addParam(cons.io.db.prp.PrpCons.P3010013, WrpUtil.text2Db(bean.P3010013.Substring(1)));

                dba.executeInsert();
                bean.IsUpdate = true;
                ExtsSize = ExtsSize + 1;
                addRecentUpdate(bean.P3010013);
            }

            return hash;
        }

        public static String NextFile(String dstPath, String dstHash)
        {
            if (dstPath.EndsWith("/"))
            {
                dstPath = dstPath.Substring(0, dstPath.Length - 1);
            }
            String dir = HttpContext.Current.Server.MapPath(EnvCons.DIR_DAT + dstPath);
            int i = 1000;
            String tmp;
            while (true)
            {
                tmp = dir + Path.DirectorySeparatorChar + i;
                if (!Directory.Exists(tmp))
                {
                    return dstPath + ',' + i + ',' + dstHash;
                }

                String[] files = Directory.GetFiles(tmp);
                if (files.Length < 512)
                {
                    return dstPath + ',' + i + ',' + dstHash;
                }
                i += 1;
            }
            return "";
        }

        public static String SaveFile(String srcPath, String srcHash, String srcExts, String dstHash, bool isManage, long operate)
        {
            // 图像更新
            if (StringUtil.isValidatePath(dstHash))
            {
                String file = HttpContext.Current.Server.MapPath(EnvCons.DIR_DAT) + Path.DirectorySeparatorChar + dstHash.Replace(',', Path.DirectorySeparatorChar) + srcExts;
                if (File.Exists(file))
                {
                    if (isManage)
                    {
                        File.Delete(file);
                    }
                    else
                    {
                        String temp = file.Substring(0, file.Length - srcExts.Length) + "_" + operate + srcExts;
                        if (File.Exists(temp))
                        {
                            return dstHash;
                        }
                        File.Move(file, temp);
                    }
                }

                DirectoryInfo path = Directory.GetParent(file);
                if (!path.Exists)
                {
                    path.Create();
                }
                File.Copy(HttpContext.Current.Server.MapPath(EnvCons.DIR_TMP + srcPath) + srcHash + srcExts, file);
            }
            return dstHash;
        }

        public static String NextIcon(String updtIcon, String dstPath, String dstHash)
        {
            if (updtIcon.Trim() != "1" || !StringUtil.isValidate(dstPath, 4))
            {
                return dstHash;
            }

            String dir = HttpContext.Current.Server.MapPath(EnvCons.DIR_DAT);
            dir += dstPath;
            if (!Directory.Exists(dir))
            {
                return "";
            }

            int i = 1000;
            String tmp;
            while (true)
            {
                tmp = dir + Path.DirectorySeparatorChar + i;
                // 判断二级目录如corp/1000/是否存在
                if (!Directory.Exists(tmp))
                {
                    return dstPath + ',' + i + ',' + HashUtil.getCurrTimeHex(true);
                }

                // 判断二级目录所含图像数量
                String[] dirs = Directory.GetDirectories(tmp);
                if (dirs == null)
                {
                    break;
                }
                if (dirs.Length < 512)
                {
                    // 生成新图标文件名称
                    return dstPath + ',' + i + ',' + HashUtil.getCurrTimeHex(true);
                }
                i += 1;
            }

            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moreIcon">图标存储方式：0：无操作，1新增，2覆盖，3追加</param>
        /// <param name="srcPath">图像来源文件路径</param>
        /// <param name="srcHash">图像来源文件名称</param>
        /// <param name="dstHash">图像保存文件名称</param>
        /// <param name="manager">是否管理人员</param>
        /// <param name="operate">操作流水</param>
        /// <returns></returns>
        public static String SaveIcon(String updtIcon, String srcPath, String srcHash, String dstHash, bool manager, long operate)
        {
            updtIcon = (updtIcon ?? "").Trim();
            if (updtIcon != "1" && updtIcon != "2" && updtIcon != "3")
            {
                return "";
            }
            if (!StringUtil.isValidatePath(dstHash))
            {
                return "";
            }

            String dir = HttpContext.Current.Server.MapPath(EnvCons.DIR_DAT);
            String dstPath = dir + dstHash.Trim(' ', ',', '/', '\\').Replace(',', Path.DirectorySeparatorChar);

            // 新增图片
            if (updtIcon == "1")
            {
                // 图标新增，图标目录不应存在
                if (Directory.Exists(dstPath))
                {
                    return "";
                }

                Directory.CreateDirectory(dstPath);
                CopyIcon(srcPath, srcHash, dstPath, false);

                return dstHash;
            }

            // 图标更新，判断图标目录是否存在
            if (!Directory.Exists(dstPath))
            {
                return "";
            }

            // 覆盖操作
            if (updtIcon == "2")
            {
                //网络人员，仅改目录改名
                if (!manager)
                {
                    Directory.Move(dstPath, dstPath + '_' + operate);
                    Directory.CreateDirectory(dstPath);
                }
                // 管理人员，可直接删除目录
                else
                {
                    foreach (String file in Directory.GetFiles(dstPath))
                    {
                        File.Delete(file);
                    }
                }

                CopyIcon(srcPath, srcHash, dstPath, true);

                return dstHash;
            }

            // 追加操作
            if (updtIcon == "3")
            {
                //网络人员，需要备份目录
                if (!manager)
                {
                    String tmp = dstPath + '_' + operate;
                    Directory.CreateDirectory(tmp);
                    foreach (String file in Directory.GetFiles(dstPath))
                    {
                        File.Copy(file, file.Replace(dstPath, tmp));
                    }
                }

                CopyIcon(srcPath, srcHash, dstPath, false);

                return dstHash;
            }

            return "";
        }

        private static bool CopyIcon(String srcPath, String srcHash, String dstPath, bool overide)
        {
            // 来源文件路径
            srcPath = HttpContext.Current.Server.MapPath(srcPath.StartsWith("/") ? '~' + srcPath : srcPath);
            if (srcPath[srcPath.Length - 1] != Path.DirectorySeparatorChar)
            {
                srcPath += Path.DirectorySeparatorChar;
            }
            if (dstPath[dstPath.Length - 1] != Path.DirectorySeparatorChar)
            {
                dstPath += Path.DirectorySeparatorChar;
            }

            // SVG图像
            String srcFile = srcPath + srcHash + ".svg";
            if (File.Exists(srcFile))
            {
                File.Copy(srcFile, dstPath + "0000.svg", true);
                return true;
            }

            // PNG图像
            String[] files = Directory.GetFiles(srcPath, srcHash + "*.png");
            if (files == null || files.Length < 1)
            {
                return false;
            }

            foreach (String src in files)
            {
                if (!File.Exists(src))
                {
                    continue;
                }

                String dst = dstPath + Path.GetFileName(src).Replace(srcHash, "");
                if (overide || !File.Exists(dst))
                {
                    File.Copy(src, dst, overide);
                }
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="original"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="scale">是否要进行缩放</param>
        /// <param name="ratio">在进行缩放处理的情况下，是否要保持原有比例</param>
        /// <returns></returns>
        public static Image GenerateThumbnail(Image original, int width, int height, bool scale, bool ratio)
        {
            if (width < 1 || height < 1)
            {
                throw new Exception("缩放后的图像大小不能低于1*1像素！");
            }
            Bitmap tn = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(tn);
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            int w = original.Width;
            int h = original.Height;
            if (scale)
            {
                if (ratio)
                {
                    double sw = (double)width / w;
                    double sh = (double)height / h;
                    double ss = sw <= sh ? sw : sh;
                    w = (int)(ss * w);
                    h = (int)(ss * h);
                }
                else
                {
                    w = width;
                    h = height;
                }
            }
            int x = (width - w) >> 1;
            int y = (height - h) >> 1;
            g.DrawImage(original, new Rectangle(x, y, w, h), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel);
            g.Dispose();
            return tn;
        }

        public static Image GenerateThumbnail(Image original, double percentage)
        {
            Bitmap tn = new Bitmap((int)(original.Width * percentage), (int)(original.Height * percentage));
            Graphics g = Graphics.FromImage(tn);
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.DrawImage(original, new Rectangle(0, 0, tn.Width, tn.Height), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel);
            g.Dispose();
            return tn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ddList"></param>
        /// <param name="statId"></param>
        /// <param name="needDL"></param>
        public static void InitCorpData(DropDownList ddList, String statId, bool needDL)
        {
            if (needDL)
            {
                ddList.Items.Add(new ListItem("请选择", ""));
            }

            DBAccess dba = new DBAccess();
            dba.addTable(cons.io.db.prp.PrpCons.P3010100);
            dba.addWhere(cons.io.db.prp.PrpCons.P3010103, statId);
            dba.addSort(cons.io.db.prp.PrpCons.P3010101, false);

            foreach (DataRow row in dba.executeSelect().Rows)
            {
                ddList.Items.Add(new ListItem(row[cons.io.db.prp.PrpCons.P3010105].ToString(), row[cons.io.db.prp.PrpCons.P3010102].ToString()));
            }
        }

        public static void UpdtCorpData(String corpHash)
        {
            new DBAccess().UpdateStep(cons.io.db.prp.PrpCons.P3010100, new string[] { cons.io.db.prp.PrpCons.P3010102 }, new string[] { corpHash }, cons.io.db.prp.PrpCons.P3010101, 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ddList"></param>
        /// <param name="corpId"></param>
        /// <param name="needDL"></param>
        public static void InitSoftData(DropDownList ddList, String corpId, bool needDL)
        {
            if (needDL)
            {
                ddList.Items.Add(new ListItem("请选择", ""));
            }

            DBAccess dba = new DBAccess();
            dba.addTable(cons.io.db.prp.PrpCons.P3010200);
            dba.addWhere(cons.io.db.prp.PrpCons.P3010203, corpId);
            dba.addSort(cons.io.db.prp.PrpCons.P3010201, false);

            foreach (DataRow row in dba.executeSelect().Rows)
            {
                ddList.Items.Add(new ListItem(row[cons.io.db.prp.PrpCons.P3010205].ToString(), row[cons.io.db.prp.PrpCons.P3010202].ToString()));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ddList"></param>
        /// <param name="softId"></param>
        /// <param name="needDL"></param>
        public static void InitFileData(DropDownList ddList, String softId, bool needDL)
        {
            if (needDL)
            {
                ddList.Items.Add(new ListItem("请选择", ""));
            }

            DBAccess dba = new DBAccess();
            dba.addTable(cons.io.db.prp.PrpCons.P3010300);
            dba.addWhere(cons.io.db.prp.PrpCons.P3010303, softId);
            dba.addSort(cons.io.db.prp.PrpCons.P3010301, false);


            foreach (DataRow row in dba.executeSelect().Rows)
            {
                ddList.Items.Add(new ListItem(row[cons.io.db.prp.PrpCons.P3010306].ToString(), row[cons.io.db.prp.PrpCons.P3010302].ToString()));
            }
        }

        public static String ShowDataStatus(Object usr, Object opt, Object cnt)
        {
            if (usr == null || opt == null)
            {
                return "";
            }
            String str = opt.ToString();
            if (str == cons.wrp.WrpCons.OPT_INSERT)
            {
                return String.Format("由 {0} <span class=\"TEXT_NOTE3\">添加</span>", usr);
            }
            if (str == cons.wrp.WrpCons.OPT_DELETE)
            {
                return String.Format("被 {0} <span class=\"TEXT_NOTE4\">删除</span>", usr);
            }
            if (str == cons.wrp.WrpCons.OPT_UPDATE)
            {
                return String.Format("经 {0} <span class=\"TEXT_NOTE4\">更新</span>", usr);
            }
            return "默认";
        }
    }
}