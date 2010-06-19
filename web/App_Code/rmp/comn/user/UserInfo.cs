using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Web.SessionState;

using cons;

using rmp.io.db;
using rmp.util;

namespace rmp.comn.user
{
    /// <summary>
    /// UserInfo 的摘要说明
    /// </summary>
    public class UserInfo
    {
        private int userRank = cons.comn.user.UserInfo.LEVEL_00;
        private String userHash = "";
        private String userCode = "A0000000";
        private String userName = "用户";
        private String userMail = "user@amonsoft.cn";

        private UserInfo()
        {
        }

        public int UserRank
        {
            get
            {
                return userRank;
            }
        }

        public String UserHash
        {
            get
            {
                return userHash;
            }
        }

        public String UserCode
        {
            get
            {
                return userCode;
            }
        }

        public String UserName
        {
            get
            {
                return userName;
            }
        }

        public String UserMail
        {
            get
            {
                return userMail;
            }
        }

        public String UserRole
        {
            get
            {
                switch (UserRank)
                {
                    case cons.comn.user.UserInfo.LEVEL_00:
                        return "游客";
                    case cons.comn.user.UserInfo.LEVEL_01:
                        return "匿名用户";
                    case cons.comn.user.UserInfo.LEVEL_02:
                        return "一般用户";
                    case cons.comn.user.UserInfo.LEVEL_03:
                        return "高级用户";
                    case cons.comn.user.UserInfo.LEVEL_04:
                        return "专用用户";
                    case cons.comn.user.UserInfo.LEVEL_05:
                        return "客服用户";
                    case cons.comn.user.UserInfo.LEVEL_06:
                        return "网站管理员";
                    case cons.comn.user.UserInfo.LEVEL_07:
                        return "数据库管理员";
                    case cons.comn.user.UserInfo.LEVEL_08:
                        return "超级用户";
                    case cons.comn.user.UserInfo.LEVEL_09:
                        return "系统管理员";
                    default:
                        return "";
                }
            }
        }

        public static UserInfo Current(HttpSessionState Session)
        {
            var ui = (UserInfo)Session[cons.wrp.WrpCons.USERINFO];
            if (ui == null)
            {
                ui = new UserInfo();
                Session.Add(cons.wrp.WrpCons.USERINFO, ui);
            }
            return ui;
        }

        /// <summary>
        /// 用户退出
        /// </summary>
        /// <returns></returns>
        public bool signOs()
        {
            userRank = cons.comn.user.UserInfo.LEVEL_00;
            userHash = "";
            userCode = "A0000000";
            userName = "用户";
            userMail = "user@amonsoft.cn";
            return true;
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="n">登录用户</param>
        /// <param name="p">用户口令</param>
        /// <param name="m">电子邮件</param>
        /// <returns></returns>
        public bool signUp(String n, String p, String m)
        {
            // 获取用户编号
            var dba = new DBAccess();
            dba.addTable(cons.io.db.comn.user.UserCons.C3010300);
            dba.addColumn(String.Format("MAX({0}) {0}", cons.io.db.comn.user.UserCons.C3010302));
            dba.addWhere(String.Format("LENGTH({0})=8", cons.io.db.comn.user.UserCons.C3010302));
            DataTable dt = dba.executeSelect();
            String tmpCode = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                tmpCode = dt.Rows[0][0].ToString();
            }
            if (!StringUtil.isValidate(tmpCode, 8))
            {
                tmpCode = "A0000000";
            }

            // 用户编号自增一位
            char[] sc = tmpCode.ToCharArray();
            for (int i = sc.Length - 1; i >= 0; i -= 1)
            {
                char c = ++sc[i];
                if (c < '0')
                {
                    return false;
                }
                if (c > 'Z')
                {
                    sc[i] = '0';
                    continue;
                }
                if (c > '9' && c < 'A')
                {
                    sc[i] = 'A';
                }
                break;
            }
            tmpCode = new String(sc);

            // 用户索引
            String tmpHash = HashUtil.getCurrTimeHex(false);
            String tmpName = WrpUtil.text2Db(n);
            String tmpMail = WrpUtil.text2Db(m);

            // 真实信息
            dba.reset();
            dba.addTable(cons.io.db.comn.user.UserCons.C3010300);
            dba.addParam(cons.io.db.comn.user.UserCons.C3010301, tmpHash);
            dba.addParam(cons.io.db.comn.user.UserCons.C3010302, tmpCode);
            dba.addParam(cons.io.db.comn.user.UserCons.C3010303, "");
            dba.addParam(cons.io.db.comn.user.UserCons.C3010304, "");
            dba.addParam(cons.io.db.comn.user.UserCons.C3010305, "");
            dba.addParam(cons.io.db.comn.user.UserCons.C3010306, null);
            dba.addParam(cons.io.db.comn.user.UserCons.C3010307, "");
            dba.addParam(cons.io.db.comn.user.UserCons.C3010308, EnvCons.SQL_NOW, false);
            dba.addParam(cons.io.db.comn.user.UserCons.C3010309, EnvCons.SQL_NOW, false);
            if (dba.executeInsert() != 1)
            {
                return false;
            }

            // 在线信息
            dba.reset();
            dba.addTable(cons.io.db.comn.user.UserCons.C3010400);
            dba.addParam(cons.io.db.comn.user.UserCons.C3010401, tmpHash);
            dba.addParam(cons.io.db.comn.user.UserCons.C3010402, tmpCode);
            dba.addParam(cons.io.db.comn.user.UserCons.C3010403, "0");
            dba.addParam(cons.io.db.comn.user.UserCons.C3010404, "0");
            dba.addParam(cons.io.db.comn.user.UserCons.C3010405, tmpName);
            dba.addParam(cons.io.db.comn.user.UserCons.C3010406, tmpMail);
            dba.addParam(cons.io.db.comn.user.UserCons.C3010407, tmpName);
            dba.addParam(cons.io.db.comn.user.UserCons.C3010408, "0");
            dba.addParam(cons.io.db.comn.user.UserCons.C3010409, "");
            dba.addParam(cons.io.db.comn.user.UserCons.C301040A, "");
            dba.addParam(cons.io.db.comn.user.UserCons.C301040B, "");
            dba.addParam(cons.io.db.comn.user.UserCons.C301040C, EnvCons.SQL_NOW, false);
            dba.addParam(cons.io.db.comn.user.UserCons.C301040D, EnvCons.SQL_NOW, false);
            if (dba.executeInsert() != 1)
            {
                return false;
            }

            // 联系方式
            dba.reset();
            dba.addTable(cons.io.db.comn.user.UserCons.C3010500);
            dba.addParam(cons.io.db.comn.user.UserCons.C3010501, "0");
            dba.addParam(cons.io.db.comn.user.UserCons.C3010502, cons.comn.user.UserInfo.MAJOR_04);
            dba.addParam(cons.io.db.comn.user.UserCons.C3010503, tmpHash);
            dba.addParam(cons.io.db.comn.user.UserCons.C3010504, tmpCode);
            dba.addParam(cons.io.db.comn.user.UserCons.C3010505, "sctteqacvfxgqgtb");// 电子邮件
            dba.addParam(cons.io.db.comn.user.UserCons.C3010506, tmpMail);
            dba.addParam(cons.io.db.comn.user.UserCons.C3010507, "");
            dba.addParam(cons.io.db.comn.user.UserCons.C3010508, cons.EnvCons.SQL_NOW, false);
            dba.addParam(cons.io.db.comn.user.UserCons.C3010509, cons.EnvCons.SQL_NOW, false);
            if (dba.executeInsert() != 1)
            {
                return false;
            }

            // 安全信息
            SHA512 sha = SHA512.Create();
            String tmpPwds = StringUtil.EncodeBytes(sha.ComputeHash(Encoding.UTF8.GetBytes(p)), false);
            dba.reset();
            dba.addTable(cons.io.db.comn.user.UserCons.C3010600);
            dba.addParam(cons.io.db.comn.user.UserCons.C3010601, tmpHash);
            dba.addParam(cons.io.db.comn.user.UserCons.C3010602, tmpHash);
            dba.addParam(cons.io.db.comn.user.UserCons.C3010603, tmpPwds);
            dba.addParam(cons.io.db.comn.user.UserCons.C3010604, tmpMail);
            dba.addParam(cons.io.db.comn.user.UserCons.C3010605, "");
            dba.addParam(cons.io.db.comn.user.UserCons.C3010606, "");
            dba.addParam(cons.io.db.comn.user.UserCons.C3010607, "");
            dba.addParam(cons.io.db.comn.user.UserCons.C3010608, "");
            dba.addParam(cons.io.db.comn.user.UserCons.C3010609, "");
            dba.addParam(cons.io.db.comn.user.UserCons.C301060A, "");
            dba.addParam(cons.io.db.comn.user.UserCons.C301060B, "");
            dba.addParam(cons.io.db.comn.user.UserCons.C301060C, "");
            dba.addParam(cons.io.db.comn.user.UserCons.C301060D, "");
            dba.addParam(cons.io.db.comn.user.UserCons.C301060E, "");
            dba.addParam(cons.io.db.comn.user.UserCons.C301060F, EnvCons.SQL_NOW, false);
            dba.addParam(cons.io.db.comn.user.UserCons.C3010610, EnvCons.SQL_NOW, false);
            if (dba.executeInsert() != 1)
            {
                return false;
            }

            // 权限分配
            dba.reset();
            dba.addTable(cons.io.db.comn.user.UserCons.C3010200);
            dba.addParam(cons.io.db.comn.user.UserCons.C3010201, tmpHash);
            dba.addParam(cons.io.db.comn.user.UserCons.C3010202, tmpHash);
            dba.addParam(cons.io.db.comn.user.UserCons.C3010203, "sctvsxyttfzeqqgq");//一般用户
            dba.addParam(cons.io.db.comn.user.UserCons.C3010204, "42010000");
            dba.addParam(cons.io.db.comn.user.UserCons.C3010205, "");
            dba.addParam(cons.io.db.comn.user.UserCons.C3010206, EnvCons.SQL_NOW, false);
            dba.addParam(cons.io.db.comn.user.UserCons.C3010207, EnvCons.SQL_NOW, false);
            if (dba.executeInsert() != 1)
            {
                return false;
            }

            //userName = n;
            //userHash = tmpHash;
            //userCode = tmpCode;
            //userRank = cons.comn.user.UserInfo.LEVEL_02;//一般用户

            return true;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="n"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool signIn(String n, String p)
        {
            var dba = new DBAccess();

            // 登录用户验证
            dba.reset();
            dba.addTable(cons.io.db.comn.user.UserCons.C3010400);
            dba.addTable(cons.io.db.comn.user.UserCons.C3010300);
            dba.addColumn(cons.io.db.comn.user.UserCons.C3010401);
            dba.addColumn(cons.io.db.comn.user.UserCons.C3010302);
            dba.addWhere(cons.io.db.comn.user.UserCons.C3010405, WrpUtil.text2Db(n));
            dba.addWhere(cons.io.db.comn.user.UserCons.C3010402, cons.io.db.comn.user.UserCons.C3010302, false);
            DataTable dt = dba.executeSelect();
            if (dt == null || dt.Rows.Count != 1)
            {
                return false;
            }

            String tmpHash = dt.Rows[0][cons.io.db.comn.user.UserCons.C3010401].ToString();
            String tmpCode = dt.Rows[0][cons.io.db.comn.user.UserCons.C3010302].ToString();

            SHA512 sha = SHA512.Create();
            String tmpPwds = StringUtil.EncodeBytes(sha.ComputeHash(Encoding.UTF8.GetBytes(p)), false);

            // 登录口令验证
            dba.reset();
            dba.addTable(cons.io.db.comn.user.UserCons.C3010600);
            dba.addColumn(cons.io.db.comn.user.UserCons.C3010603);
            dba.addWhere(cons.io.db.comn.user.UserCons.C3010602, tmpHash);
            dt = dba.executeSelect();
            if (dt == null || dt.Rows.Count != 1)
            {
                return false;
            }

            if (tmpPwds != dt.Rows[0][cons.io.db.comn.user.UserCons.C3010603].ToString())
            {
                return false;
            }

            // 登录权限读取
            dba.reset();
            dba.addTable(cons.io.db.comn.user.UserCons.C3010F00);
            dba.addTable(cons.io.db.comn.user.UserCons.C3010200);
            dba.addColumn(cons.io.db.comn.user.UserCons.C3010F02);
            dba.addWhere(cons.io.db.comn.user.UserCons.C3010203, cons.io.db.comn.user.UserCons.C3010F03, false);
            dba.addWhere(cons.io.db.comn.user.UserCons.C3010202, tmpHash);
            dba.addWhere(cons.io.db.comn.user.UserCons.C3010204, "42010000");
            dt = dba.executeSelect();
            if (dt == null || dt.Rows.Count != 1)
            {
                return false;
            }

            userName = n;
            userHash = tmpHash;
            userCode = tmpCode;
            userRank = (int)dt.Rows[0][cons.io.db.comn.user.UserCons.C3010F02];

            return true;
        }

        /// <summary>
        /// 登录口令修改
        /// </summary>
        /// <param name="oldPwds"></param>
        /// <param name="newPwds"></param>
        /// <returns></returns>
        public bool signPk(String oldPwds, String newPwds)
        {
            // 口令验证
            SHA512 sha = SHA512.Create();
            String tmpPwds = StringUtil.EncodeBytes(sha.ComputeHash(Encoding.UTF8.GetBytes(oldPwds)), false);

            // 执行查询
            var dba = new DBAccess();
            dba.addTable(cons.io.db.comn.user.UserCons.C3010600);
            dba.addColumn(cons.io.db.comn.user.UserCons.C3010603);
            dba.addWhere(cons.io.db.comn.user.UserCons.C3010602, userHash);
            DataTable dt = dba.executeSelect();

            // 数据验证
            if (dt.Rows.Count != 1)
            {
                return false;
            }
            oldPwds = dt.Rows[0][0].ToString();
            if (tmpPwds != oldPwds)
            {
                return false;
            }

            tmpPwds = StringUtil.EncodeBytes(sha.ComputeHash(Encoding.UTF8.GetBytes(newPwds)), false);

            // 修改口令
            dba.reset();
            dba.addTable(cons.io.db.comn.user.UserCons.C3010600);
            dba.addParam(cons.io.db.comn.user.UserCons.C3010603, tmpPwds);
            dba.addParam(cons.io.db.comn.user.UserCons.C301060F, EnvCons.SQL_NOW, false);
            dba.addWhere(cons.io.db.comn.user.UserCons.C3010602, UserHash);
            return dba.executeUpdate() == 1;
        }
    }
}