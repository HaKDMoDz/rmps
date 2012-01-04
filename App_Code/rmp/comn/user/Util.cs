using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

using cons.io.db.comn;

using rmp.io.db;

namespace rmp.comn.user
{
    public class Util
    {
        private static readonly Dictionary<string, string> userInfo = new Dictionary<string, string>();

        private Util()
        {
        }

        public static ArrayList GetUserList()
        {
            return null;
        }

        public static string GetUserNameByCode(string code)
        {
            if (userInfo.Count < 1)
            {
                ReLoadUserList();
            }
            return userInfo.ContainsKey(code) ? userInfo[code] : "user";
        }

        public static void ReLoadUserList()
        {
            userInfo.Clear();

            DBAccess dba = new DBAccess();
            dba.addTable(cons.io.db.comn.user.UserCons.C3010400);
            dba.addTable(cons.io.db.comn.user.UserCons.C3010300);
            dba.addColumn(cons.io.db.comn.user.UserCons.C3010302);
            dba.addColumn(cons.io.db.comn.user.UserCons.C3010405);
            dba.addWhere(cons.io.db.comn.user.UserCons.C3010402, cons.io.db.comn.user.UserCons.C3010301, false);
            dba.addSort(cons.io.db.comn.user.UserCons.C3010405);

            foreach (DataRow row in dba.executeSelect().Rows)
            {
                userInfo[row[cons.io.db.comn.user.UserCons.C3010302].ToString()] = row[cons.io.db.comn.user.UserCons.C3010405].ToString();
            }
        }

        public static void InitUserList(DropDownList ddList, bool needDL)
        {
            DBAccess dba = new DBAccess();
            dba.addTable(cons.io.db.comn.user.UserCons.C3010400);
            dba.addColumn(cons.io.db.comn.user.UserCons.C3010401);
            dba.addColumn(cons.io.db.comn.user.UserCons.C3010405);
            dba.addSort(cons.io.db.comn.user.UserCons.C3010405);

            ddList.DataSource = dba.executeSelect();
            ddList.DataValueField = cons.io.db.comn.user.UserCons.C3010401;
            ddList.DataTextField = cons.io.db.comn.user.UserCons.C3010405;
            ddList.DataBind();

            if (needDL)
            {
                ddList.Items.Insert(0, new ListItem("请选择", ""));
            }
        }

        public static void InitUserCodeList(DropDownList ddList, bool needDL)
        {
            DBAccess dba = new DBAccess();
            dba.addTable(cons.io.db.comn.user.UserCons.C3010400);
            dba.addTable(cons.io.db.comn.user.UserCons.C3010300);
            dba.addColumn(cons.io.db.comn.user.UserCons.C3010302);
            dba.addColumn(cons.io.db.comn.user.UserCons.C3010405);
            dba.addWhere(cons.io.db.comn.user.UserCons.C3010402, cons.io.db.comn.user.UserCons.C3010301, false);
            dba.addSort(cons.io.db.comn.user.UserCons.C3010405);

            ddList.DataSource = dba.executeSelect();
            ddList.DataValueField = cons.io.db.comn.user.UserCons.C3010302;
            ddList.DataTextField = cons.io.db.comn.user.UserCons.C3010405;
            ddList.DataBind();

            if (needDL)
            {
                ddList.Items.Insert(0, new ListItem("请选择", ""));
            }
        }
    }
}