using System;
using System.IO;
using System.Web.UI;
using cons.wrp;
using rmp.bean;
using rmp.io.db;
using rmp.util;
using rmp.wrp;

public partial class wime_wime9999 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "网页五笔";
        Session[cons.wrp.WrpCons.SCRIPTID] = "wime9999";

        K1V2 guidItem = Wrps.GuidWime(Session)[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/wime/wime9999.aspx";
        guidItem.V1 = "词库管理";
        guidItem.V2 = "词库管理";

        Session[cons.wrp.WrpCons.GUIDSIZE] = 2;
    }

    protected void bt_Save_Click(object sender, EventArgs e)
    {
        if (!StringUtil.isValidate(fu_File.FileName))
        {
            return;
        }
        if (fu_File.FileContent.Length < 1)
        {
            return;
        }
        if (tf_Char.Text.Length != 1)
        {
            return;
        }
        StreamReader sr = new StreamReader(fu_File.FileContent);
        ImportData(sr, tf_Char.Text[0], cb_Type.SelectedIndex);
        sr.Close();
    }

    private static void ImportData(TextReader sr, char pchr, int type)
    {
        long l = DateTime.UtcNow.ToBinary();
        DBAccess dba = new DBAccess();
        const string sql = "insert into w2020100 values(0, {0}, '{1}', '42020000', '{2}', '{3}', '', now(), now())";

        String line = sr.ReadLine();
        String[] keys;
        while (line != null)
        {
            keys = line.Trim().Split(pchr);
            for (int i = 1; i < keys.Length; i += 1)
            {
                dba.executeInsert(String.Format(sql, type, StringUtil.encodeLong(l++, false), keys[0], keys[i]));
            }
            line = sr.ReadLine();
        }
        sr.Close();
    }
}