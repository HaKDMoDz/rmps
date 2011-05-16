using System;
/// <summary>
///Misc 的摘要说明
/// </summary>
using System.Collections.Generic;
using System.Data;
using rmp.io.db;

namespace rmp.wrp.misc
{
    public class Misc
    {
        private static W2060100 w2060100;
        private static int lastDay;

        public Misc()
        {
        }

        public static W2060100 GetMisc()
        {
            if (w2060100 == null)
            {
                w2060100 = new W2060100();
            }

            DateTime now = DateTime.Now;
            if (lastDay != now.Day && now.Hour > 9 || w2060100.W2060105 < 1)
            {
                lock (w2060100)
                {
                    DBAccess dba = new DBAccess();
                    dba.addTable(cons.io.db.wrp.WrpCons.W2060100);
                    dba.addTable(cons.io.db.comn.ComnCons.C2010000);
                    dba.addTable(cons.io.db.comn.ComnCons.C2010100);
                    dba.addColumn(cons.io.db.wrp.WrpCons.W2060101);
                    dba.addColumn(cons.io.db.wrp.WrpCons.W2060102);
                    dba.addColumn(cons.io.db.wrp.WrpCons.W2060103);
                    dba.addColumn(cons.io.db.wrp.WrpCons.W2060104);
                    dba.addColumn(cons.io.db.wrp.WrpCons.W2060105);
                    dba.addColumn(cons.io.db.comn.ComnCons.C2010004, cons.io.db.wrp.WrpCons.W2060106);
                    dba.addColumn(cons.io.db.comn.ComnCons.C2010107, cons.io.db.wrp.WrpCons.W2060107);
                    dba.addColumn(cons.io.db.wrp.WrpCons.W2060108);
                    dba.addColumn(cons.io.db.wrp.WrpCons.W2060109);
                    dba.addColumn(cons.io.db.wrp.WrpCons.W206010A);
                    dba.addColumn(cons.io.db.wrp.WrpCons.W206010B);
                    dba.addColumn(cons.io.db.wrp.WrpCons.W206010C);
                    dba.addWhere(cons.io.db.wrp.WrpCons.W2060106, cons.io.db.comn.ComnCons.C2010002, false);
                    dba.addWhere(cons.io.db.wrp.WrpCons.W2060107, cons.io.db.comn.ComnCons.C2010105, false);
					dba.addWhere(cons.io.db.wrp.WrpCons.W2060105, ">", w2060100.W2060105 > 0 ? w2060100.W2060105.ToString() : Wrps.GetProperties("misc", "1"), false);
                    dba.addSort(cons.io.db.wrp.WrpCons.W2060105);
                    dba.addLimit(1);

                    DataTable dt = dba.executeSelect();
                    if (dt.Rows.Count == 1)
                    {
                        DataRow row = dt.Rows[0];
                        w2060100.W2060101 = (int)row[cons.io.db.wrp.WrpCons.W2060101];
                        w2060100.W2060102 = (int)row[cons.io.db.wrp.WrpCons.W2060102];
                        w2060100.W2060103 = (int)row[cons.io.db.wrp.WrpCons.W2060103];
                        w2060100.W2060104 = (int)row[cons.io.db.wrp.WrpCons.W2060104];
                        w2060100.W2060105 = (uint)row[cons.io.db.wrp.WrpCons.W2060105];
                        w2060100.W2060106 = (string)row[cons.io.db.wrp.WrpCons.W2060106];
                        w2060100.W2060107 = (string)row[cons.io.db.wrp.WrpCons.W2060107];
                        w2060100.W2060108 = (string)row[cons.io.db.wrp.WrpCons.W2060108];
                        w2060100.W2060109 = (string)row[cons.io.db.wrp.WrpCons.W2060109];
                        w2060100.W206010A = (string)row[cons.io.db.wrp.WrpCons.W206010A];
                        w2060100.W206010B = (DateTime)row[cons.io.db.wrp.WrpCons.W206010B];
                        w2060100.W206010C = (DateTime)row[cons.io.db.wrp.WrpCons.W206010C];
                        lastDay = now.Day;
                    }
                    else
                    {
                        w2060100.W2060105 = 1;
                        w2060100.W2060106 = "默认";
                        w2060100.W2060107 = "默认";
                        w2060100.W2060108 = "默认";
                        w2060100.W2060109 = "^_^";
                        lastDay = 0;
                    }
                    dt.Dispose();

                    Wrps.SetProperties("misc", w2060100.W2060105.ToString(), "");
                }
            }
            return w2060100;
        }
    }
}