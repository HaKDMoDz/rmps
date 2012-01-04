using System;
using System.Data;

using rmp.io.db;
using rmp.util;

namespace rmp.comn.root
{
    /// <summary>
    ///C0000000 的摘要说明
    /// </summary>
    public class C0000000
    {
        private C0000000()
        {
        }

        public static DataTable Load(DBAccess dba, String code, String name)
        {
            dba.reset();
            dba.addTable(cons.io.db.comn.ComnCons.C0010100);
            dba.addColumn(cons.io.db.comn.ComnCons.C0010103);
            dba.addColumn(cons.io.db.comn.ComnCons.C0010104);
            dba.addColumn(cons.io.db.comn.ComnCons.C0010105);
            dba.addColumn(cons.io.db.comn.ComnCons.C0010106);
            dba.addColumn(cons.io.db.comn.ComnCons.C0010107);
            dba.addColumn(cons.io.db.comn.ComnCons.C0010108);
            if (StringUtil.isValidateCode(code))
            {
                dba.addWhere(cons.io.db.comn.ComnCons.C0010104, code);
            }
            if (StringUtil.isValidate(name))
            {
                dba.addWhere(cons.io.db.comn.ComnCons.C0010106, "LIKE", '%' + name.Replace(" ", "%") + '%', true);
            }
            dba.addSort(cons.io.db.comn.ComnCons.C0010104);

            return dba.executeSelect();
        }
    }
}