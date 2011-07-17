using System;
using System.Data;
using rmp.io.db;
using rmp.util;

namespace rmp.comn.info
{
    /// <summary>
    ///C2010000 的摘要说明
    /// </summary>
    public class C2010000
    {
        private C2010000()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dba"></param>
        /// <param name="hash">类别索引</param>
        /// <param name="type">上级类别</param>
        /// <param name="code">系统代码</param>
        /// <param name="step">类别级别</param>
        /// <returns></returns>
        public static DataTable Read(DBAccess dba, String hash, String type, String code, int step)
        {
            dba.reset();
            dba.addTable(cons.io.db.comn.info.C2010000.C2010100);
            if (StringUtil.isValidateHash(hash))
            {
                dba.addWhere(cons.io.db.comn.info.C2010000.C2010105, hash);
            }
            if (type == "0" || StringUtil.isValidateHash(type))
            {
                dba.addWhere(cons.io.db.comn.info.C2010000.C2010106, type);
            }
            if (StringUtil.isValidateCode(code))
            {
                dba.addWhere(cons.io.db.comn.info.C2010000.C2010104, code);
            }
            if (step >= 0)
            {
                dba.addWhere(cons.io.db.comn.info.C2010000.C2010103, step.ToString());
            }
            return dba.executeSelect();
        }

        /// <summary>
        /// 添加一个类别
        /// </summary>
        /// <param name="dba"></param>
        /// <param name="hash">类别索引</param>
        /// <param name="code">系统或用户代码</param>
        /// <param name="type">上级类别索引</param>
        /// <param name="name">类别名称</param>
        /// <param name="tips">类别提示</param>
        /// <param name="value">类别键值</param>
        /// <param name="desc">类别描述</param>
        /// <param name="stat">使用状态</param>
        /// <returns></returns>
        public static String Save(DBAccess dba, String hash, String code, String type, String name, String tips, String value, String desc, int stat)
        {
            if (!StringUtil.isValidateCode(code) || (type != "0" && !StringUtil.isValidateHash(type)))
            {
                return null;
            }

            dba.reset();
            dba.addTable(cons.io.db.comn.info.C2010000.C2010100);
            dba.addParam(cons.io.db.comn.info.C2010000.C2010102, stat);
            dba.addParam(cons.io.db.comn.info.C2010000.C2010104, code);
            dba.addParam(cons.io.db.comn.info.C2010000.C2010106, type);
            dba.addParam(cons.io.db.comn.info.C2010000.C2010107, name);
            dba.addParam(cons.io.db.comn.info.C2010000.C2010108, tips);
            dba.addParam(cons.io.db.comn.info.C2010000.C2010109, value);
            dba.addParam(cons.io.db.comn.info.C2010000.C201010A, desc);
            dba.addParam(cons.io.db.comn.info.C2010000.C201010B, cons.EnvCons.SQL_NOW, false);

            // 数据更新
            if (StringUtil.isValidateHash(hash))
            {
                dba.addWhere(cons.io.db.comn.info.C2010000.C2010105, hash);
                return dba.executeUpdate() > 0 ? hash : "";
            }

            // 新增数据
            hash = HashUtil.getCurrTimeHex(false);
            dba.addParam(cons.io.db.comn.info.C2010000.C2010101, "0");
            dba.addParam(cons.io.db.comn.info.C2010000.C2010103, "0");
            dba.addParam(cons.io.db.comn.info.C2010000.C2010105, hash);
            dba.addParam(cons.io.db.comn.info.C2010000.C201010C, cons.EnvCons.SQL_NOW, false);
            return dba.executeInsert() == 1 ? hash : "";
        }
    }
}