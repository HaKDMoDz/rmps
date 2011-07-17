<%@ WebHandler Language="C#" Class="exts0001" %>

using System;
using System.Data;
using System.Text;
using System.Web;

using rmp.util;

public class exts0001 : IHttpHandler
{
    /// <summary>
    /// 输入查寻条件为空
    /// </summary>
    public const String FAIL_01 = "1";
    /// <summary>
    /// 输入格式不对
    /// </summary>
    public const String FAIL_02 = "2";
    /// <summary>
    /// 查寻结果为空
    /// </summary>
    public const String FAIL_03 = "3";
    /// <summary>
    /// 服务器错误
    /// </summary>
    public const String FAIL_04 = "4";
    /// <summary>
    /// 处理出错
    /// </summary>
    public const String FAIL_05 = "5";

    /// <summary>
    /// 
    /// </summary>
    public bool IsReusable
    {
        get
        {
            return true;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/xml";
        context.Response.ContentEncoding = Encoding.UTF8;

        String extsName = context.Request["exts"];

        // FLEX页面调用
        if (extsName != null)
        {
            context.Response.Write(ReadExts(extsName, context.Request["case"], context.Request["soft"], context.Request["type"]));
            context.Response.End();
        }
        else
        {
            context.Response.Redirect("");
        }
    }

    /// <summary>
    /// 返回结果为XML数据，其基本格式如下：
    /// &lt;?xml>
    /// &lt;P3010000>
    ///     &lt;size>&lt;/size>
    ///     &lt;fail>&lt;/fail>
    /// 1:输入查寻条件为空
    /// 2:输入格式不对
    /// 3:查寻结果为空
    /// 4:服务器错误
    /// 5:处理出错
    ///     &lt;info>
    ///         &lt;hash>&lt;/hash>
    ///         &lt;name>&lt;/name>
    ///     &lt;/info>
    ///     &lt;exts>
    ///         &lt;base>&lt;/base>
    ///         &lt;desp>&lt;/desp>
    ///         &lt;mime>&lt;/mime>
    ///         &lt;docs>&lt;/docs>
    ///         &lt;corp>&lt;/corp>
    ///         &lt;soft>&lt;/soft>
    ///         &lt;file>&lt;/file>
    ///         &lt;idio>&lt;/idio>
    ///         &lt;asoc>&lt;/asoc>
    ///     &lt;/exts>
    /// &lt;/P3010000>
    /// </summary>
    /// <returns></returns>
    private static String ReadExts(String extsName, String extsCase, String softHash, String type)
    {
        StringBuilder data = new StringBuilder();
        data.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
        data.Append("<P3010000>");

        // 参数为空检测
        data.Append("<info>");

        // 用户传入后缀名称
        data.Append("<name>");
        data.Append(extsName);
        data.Append("</name>");

        extsName = extsName.Trim();
        if (extsName == "")
        {
            data.Append("<size>");
            data.Append(0);
            data.Append("</size>");

            data.Append("<fail>");
            data.Append(FAIL_01);
            data.Append("</fail>");

            data.Append("</info>");
            data.Append("</P3010000>");
            return data.ToString();
        }

        // 参数合法性检测
        extsName = extsName.TrimStart(new char[] { '.', '.' });
        if (extsName == ".")
        {
            data.Append("<size>");
            data.Append(0);
            data.Append("</size>");

            data.Append("<fail>");
            data.Append(FAIL_02);
            data.Append("</fail>");

            data.Append("</info>");
            data.Append("</P3010000>");
            return data.ToString();
        }

        // 后缀字符串校正
        if (extsName.StartsWith("."))
        {
            extsName = extsName.Substring(1);
        }

        // 执行数据查询
        DataTable dataView;
        String extsHash = null;
        rmp.io.db.DBAccess dba = new rmp.io.db.DBAccess();
        if (extsCase == cons.wrp.exts.ExtsCons.EXTS_CASE_UPPR)
        {
            extsName = extsName.ToUpper();
            extsHash = HashUtil.digest(extsName, false);
            dataView = rmp.wrp.exts.Exts.srchHash(dba, extsHash, softHash);
        }
        else if (extsCase == cons.wrp.exts.ExtsCons.EXTS_CASE_LOWR)
        {
            extsName = extsName.ToLower();
            extsHash = HashUtil.digest(extsName, false);
            dataView = rmp.wrp.exts.Exts.srchHash(dba, extsHash, softHash);
        }
        else if (extsCase == cons.wrp.exts.ExtsCons.EXTS_CASE_BLUR)
        {
            dataView = rmp.wrp.exts.Exts.srchName(dba, extsName, softHash);
        }
        else
        {
            extsHash = HashUtil.digest(extsName, false);
            dataView = rmp.wrp.exts.Exts.srchHash(dba, extsHash, softHash);
        }

        // 数据信息读取
        if (dataView != null && dataView.Rows.Count > 0)
        {
            int extsSize = dataView.Rows.Count;

            data.Append("<size>").Append(extsSize).Append("</size>");

            ReadInfo(data, dataView);
            data.Append("</info>");

            // 类型不为list时，仅显示一个数据
            if (type == null || type.ToLower() != "list")
            {
                extsSize = 1;
            }

            DataRow row;
            for (int i = 0; i < extsSize; i += 1)
            {
                row = dataView.Rows[i];

                data.Append("<exts id=\"").Append(i).Append("\">");
                ReadBase(data, row);
                ReadDesp(data, row, dba);
                ReadMime(data, row, dba);
                ReadPlat(data, row, dba);
                ReadDocs(data, row, dba);
                ReadCorp(data, row, dba);
                ReadSoft(data, row, dba);
                ReadFile(data, row, dba);
                ReadIdio(data, row, dba);
                ReadAsoc(data, row, dba);
                data.Append("</exts>");
            }
        }
        else
        {
            data.Append("<size>");
            data.Append(0);
            data.Append("</size>");

            data.Append("<fail>");
            data.Append(FAIL_03);
            data.Append("</fail>");

            data.Append("</info>");
        }

        data.Append("</P3010000>");

        // 查询统计
        if (extsHash != null)
        {
            dba.UpdateStep(cons.io.db.prp.PrpCons.P3010000, cons.io.db.prp.PrpCons.P3010003, extsHash, cons.io.db.prp.PrpCons.P3010001, 1);
        }
        return data.ToString();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <param name="view"></param>
    private static void ReadInfo(StringBuilder data, DataTable view)
    {
        int id = 0;
        foreach (DataRow row in view.Rows)
        {
            data.Append("<item");
            data.Append(" id=\"").Append(id++).Append("\"");
            data.Append(" name=\"").Append(row[cons.io.db.prp.PrpCons.P3010205].ToString()).Append("\"");
            data.Append(" hash=\"").Append(row[cons.io.db.prp.PrpCons.P3010006].ToString()).Append("\"");
            data.Append(" />");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <param name="row0"></param>
    private static void ReadBase(StringBuilder data, DataRow row0)
    {
        data.Append("<base>");

        data.Append("<ExtsName>");
        data.Append(".").Append(row0[cons.io.db.prp.PrpCons.P3010013].ToString());
        data.Append("</ExtsName>");

        data.Append("<QuickUrl>");
        data.Append(cons.EnvCons.SITE_SOFT + "?.").Append(row0[cons.io.db.prp.PrpCons.P3010013].ToString());
        data.Append("</QuickUrl>");

        Append(data, "ExtsHash", cons.io.db.prp.PrpCons.P3010003, row0, false);

        data.Append("<ExtsSoft>");
        data.Append(row0[cons.io.db.prp.PrpCons.P3010205].ToString());
        data.Append("</ExtsSoft>");

        data.Append("<ExtsType>");
        data.Append(rmp.comn.Comn.ReadCat1Item(row0[cons.io.db.prp.PrpCons.P301000C].ToString(), "13010000").K);
        data.Append("</ExtsType>");

        data.Append("<PlatForm>");
        data.Append(rmp.wrp.exts.Exts.decodePlatForm(int.Parse(row0[cons.io.db.prp.PrpCons.P301000D].ToString())));
        data.Append("</PlatForm>");

        data.Append("<ArchBits>");
        data.Append(rmp.wrp.exts.Exts.decodeArchBits(int.Parse(row0[cons.io.db.prp.PrpCons.P3010002].ToString())));
        data.Append("</ArchBits>");

        Append(data, "LastUpdt", cons.io.db.prp.PrpCons.P3010011, row0, false);
        Append(data, "QueryFeq", cons.io.db.prp.PrpCons.P3010001, row0, false);

        Append(data, "MarkData", cons.io.db.prp.PrpCons.P3010010, row0, true);

        data.Append("</base>");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <param name="row0"></param>
    /// <param name="dba"></param>
    private static void ReadDesp(StringBuilder data, DataRow row0, rmp.io.db.DBAccess dba)
    {
        DataTable view = rmp.wrp.exts.Exts.ReadDesp(dba, row0[cons.io.db.prp.PrpCons.P3010009].ToString());

        data.Append("<desp>");
        if (view.Rows.Count > 0)
        {
            Append(data, "DespHash", cons.io.db.prp.PrpCons.P3010501, view.Rows[0], false);
            Append(data, "DespInfo", cons.io.db.prp.PrpCons.P3010503, view.Rows[0], true);
            Append(data, "MarkData", cons.io.db.prp.PrpCons.P3010504, view.Rows[0], true);
        }
        data.Append("</desp>");
        view.Dispose();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <param name="row0"></param>
    /// <param name="dba"></param>
    private static void ReadMime(StringBuilder data, DataRow row0, rmp.io.db.DBAccess dba)
    {
        DataTable view = rmp.wrp.exts.Exts.ReadMime(dba, row0[cons.io.db.prp.PrpCons.P301000A].ToString());

        data.Append("<mime>");

        data.Append("<size>");
        data.Append(view.Rows.Count);
        data.Append("</size>");

        Append(data, "hash", cons.io.db.prp.PrpCons.P301000A, row0, false);

        data.Append("<list>");
        int id = 0;
        foreach (DataRow row in view.Rows)
        {
            data.Append("<item");
            data.Append(" id=\"").Append(id++).Append("\"");
            data.Append(" name=\"").Append(row[cons.io.db.prp.PrpCons.P301F104].ToString()).Append("\"");
            data.Append(" desp=\"").Append(row[cons.io.db.prp.PrpCons.P3010604].ToString()).Append("\"");
            data.Append(" link=\"/exts/exts0502.aspx?sid=").Append(row[cons.io.db.prp.PrpCons.P3010603].ToString()).Append("\"");
            data.Append(" />");
        }
        data.Append("</list>");

        data.Append("</mime>");
        view.Dispose();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <param name="row0"></param>
    /// <param name="dba"></param>
    private static void ReadPlat(StringBuilder data, DataRow row0, rmp.io.db.DBAccess dba)
    {
        DataTable view = rmp.wrp.exts.Exts.ReadPlat(dba, row0[cons.io.db.prp.PrpCons.P301000E].ToString());

        data.Append("<plat>");

        data.Append("<size>");
        data.Append(view.Rows.Count);
        data.Append("</size>");

        Append(data, "hash", cons.io.db.prp.PrpCons.P301000E, row0, false);

        data.Append("<list>");
        int id = 0;
        foreach (DataRow row in view.Rows)
        {
            data.Append("<item ");
            data.Append(" id=\"").Append(id++).Append("\"");
            data.Append(" name=\"").Append(row[cons.io.db.prp.PrpCons.P301F206].ToString()).Append("\"");
            data.Append(" desp=\"").Append(row[cons.io.db.prp.PrpCons.P3010804].ToString()).Append("\"");
            data.Append(" link=\"/exts/exts0602.aspx?sid=").Append(row[cons.io.db.prp.PrpCons.P3010803].ToString()).Append("\"");
            data.Append(" />");
        }
        data.Append("</list>");
        data.Append("</plat>");
        view.Dispose();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <param name="row0"></param>
    /// <param name="dba"></param>
    private static void ReadDocs(StringBuilder data, DataRow row0, rmp.io.db.DBAccess dba)
    {
        DataTable view = rmp.wrp.exts.Exts.ReadDocs(dba, row0[cons.io.db.prp.PrpCons.P3010008].ToString());

        data.Append("<docs>");
        if (view.Rows.Count > 0)
        {
            Append(data, "DocsHash", cons.io.db.prp.PrpCons.P3010402, view.Rows[0], false);
            data.Append("<FilePath>");
            data.Append("/file/file0001.ashx?sid=").Append(view.Rows[0][cons.io.db.prp.PrpCons.P3010404].ToString());
            data.Append("</FilePath>");
            Append(data, "FileName", cons.io.db.prp.PrpCons.P3010405, view.Rows[0], true);
            Append(data, "FileVers", cons.io.db.prp.PrpCons.P3010406, view.Rows[0], true);
            Append(data, "PubsDate", cons.io.db.prp.PrpCons.P3010407, view.Rows[0], false);
            Append(data, "DocsInfo", cons.io.db.prp.PrpCons.P3010408, view.Rows[0], true);
            Append(data, "MarkData", cons.io.db.prp.PrpCons.P3010409, view.Rows[0], true);
        }
        data.Append("</docs>");
        view.Dispose();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <param name="row0"></param>
    /// <param name="dba"></param>
    private static void ReadCorp(StringBuilder data, DataRow row0, rmp.io.db.DBAccess dba)
    {
        DataTable view = rmp.wrp.exts.Exts.ReadCorp(dba, row0[cons.io.db.prp.PrpCons.P3010005].ToString());

        data.Append("<corp>");
        if (view.Rows.Count > 0)
        {
            Append(data, "CorpHash", cons.io.db.prp.PrpCons.P3010102, view.Rows[0], false);
            data.Append("<StatInfo>");
            data.Append(rmp.comn.Comn.ReadStatItem(view.Rows[0][cons.io.db.prp.PrpCons.P3010103].ToString(), cons.SysCons.UI_LANGHASH).V1);
            data.Append("</StatInfo>");
            data.Append("<CorpLogo>");
            data.Append("/icon/icon0001.ashx?sid=").Append(view.Rows[0][cons.io.db.prp.PrpCons.P3010104].ToString()).Append("&amp;u=corp");
            data.Append("</CorpLogo>");
            Append(data, "NameCN", cons.io.db.prp.PrpCons.P3010105, view.Rows[0], true);
            Append(data, "NameEN", cons.io.db.prp.PrpCons.P3010106, view.Rows[0], true);
            Append(data, "CorpSite", cons.io.db.prp.PrpCons.P3010107, view.Rows[0], true);
            Append(data, "CorpInfo", cons.io.db.prp.PrpCons.P3010108, view.Rows[0], true);
            Append(data, "MarkData", cons.io.db.prp.PrpCons.P3010109, view.Rows[0], true);
        }
        data.Append("</corp>");
        view.Dispose();
    }

    private static void ReadSoft(StringBuilder data, DataRow row0, rmp.io.db.DBAccess dba)
    {
        DataTable view = rmp.wrp.exts.Exts.ReadSoft(dba, row0[cons.io.db.prp.PrpCons.P3010006].ToString());

        data.Append("<soft>");
        if (view.Rows.Count > 0)
        {
            Append(data, "SoftHash", cons.io.db.prp.PrpCons.P3010202, view.Rows[0], false);
            data.Append("<SoftIcon>");
            data.Append("/icon/icon0001.ashx?sid=").Append(view.Rows[0][cons.io.db.prp.PrpCons.P3010204].ToString()).Append("&amp;u=soft");
            data.Append("</SoftIcon>");
            Append(data, "NameCN", cons.io.db.prp.PrpCons.P3010205, view.Rows[0], true);
            Append(data, "NameEN", cons.io.db.prp.PrpCons.P3010206, view.Rows[0], true);
            Append(data, "MailAddr", cons.io.db.prp.PrpCons.P3010207, view.Rows[0], true);
            Append(data, "SoftPage", cons.io.db.prp.PrpCons.P3010208, view.Rows[0], true);
            Append(data, "ExtsList", cons.io.db.prp.PrpCons.P3010209, view.Rows[0], false);
            data.Append("<SoftView>");
            data.Append("/exts/view/").Append(view.Rows[0][cons.io.db.prp.PrpCons.P301020A].ToString()).Append(".png");
            data.Append("</SoftView>");
            Append(data, "SoftInfo", cons.io.db.prp.PrpCons.P301020B, view.Rows[0], true);
            Append(data, "MarkData", cons.io.db.prp.PrpCons.P301020C, view.Rows[0], true);
        }
        data.Append("</soft>");
        view.Dispose();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <param name="row0"></param>
    /// <param name="dba"></param>
    private static void ReadFile(StringBuilder data, DataRow row0, rmp.io.db.DBAccess dba)
    {
        DataTable view = rmp.wrp.exts.Exts.ReadFile(dba, row0[cons.io.db.prp.PrpCons.P3010007].ToString());

        data.Append("<file>");
        if (view.Rows.Count > 0)
        {
            Append(data, "FileHash", cons.io.db.prp.PrpCons.P3010302, view.Rows[0], false);
            data.Append("<FileIcon>");
            data.Append("/icon/icon0001.ashx?sid=").Append(view.Rows[0][cons.io.db.prp.PrpCons.P3010304].ToString()).Append("&amp;u=file");
            data.Append("</FileIcon>");
            Append(data, "SignChar", cons.io.db.prp.PrpCons.P3010305, view.Rows[0], true);
            Append(data, "SignCode", cons.io.db.prp.PrpCons.P3010306, view.Rows[0], false);
            Append(data, "Offset", cons.io.db.prp.PrpCons.P3010307, view.Rows[0], false);
            Append(data, "Cipher", cons.io.db.prp.PrpCons.P3010308, view.Rows[0], true);
            Append(data, "HeadData", cons.io.db.prp.PrpCons.P3010309, view.Rows[0], true);
            Append(data, "FootData", cons.io.db.prp.PrpCons.P301030A, view.Rows[0], true);
            Append(data, "FileInfo", cons.io.db.prp.PrpCons.P301030B, view.Rows[0], true);
            Append(data, "MarkData", cons.io.db.prp.PrpCons.P301030C, view.Rows[0], true);
        }
        data.Append("</file>");
        view.Dispose();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <param name="row0"></param>
    /// <param name="dba"></param>
    private static void ReadIdio(StringBuilder data, DataRow row0, rmp.io.db.DBAccess dba)
    {
        DataTable view = rmp.wrp.exts.Exts.ReadIdio(dba, row0[cons.io.db.prp.PrpCons.P301000F].ToString());

        data.Append("<idio>");
        if (view.Rows.Count > 0)
        {
            Append(data, "IdioHash", cons.io.db.comn.user.UserCons.C3010401, view.Rows[0], false);
            Append(data, "UserName", cons.io.db.comn.user.UserCons.C3010407, view.Rows[0], true);
            Append(data, "MailAddr", cons.io.db.comn.user.UserCons.C3010406, view.Rows[0], true);
            Append(data, "NickName", cons.io.db.comn.user.UserCons.C3010407, view.Rows[0], true);
            data.Append("<IdioLogo>");
            data.Append("/icon/icon0001.ashx?sid=").Append(view.Rows[0][cons.io.db.comn.user.UserCons.C3010408].ToString()).Append("&amp;u=idio");
            data.Append("</IdioLogo>");
            Append(data, "IdioSign", cons.io.db.comn.user.UserCons.C3010409, view.Rows[0], true);
            Append(data, "HomePage", cons.io.db.comn.user.UserCons.C301040A, view.Rows[0], true);
            Append(data, "IdioInfo", cons.io.db.comn.user.UserCons.C301040B, view.Rows[0], true);
            data.Append("<MarkData></MarkData>");
        }
        data.Append("</idio>");
        view.Dispose();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <param name="row0"></param>
    /// <param name="dba"></param>
    private static void ReadAsoc(StringBuilder data, DataRow row0, rmp.io.db.DBAccess dba)
    {
        DataTable view = rmp.wrp.exts.Exts.ReadAsoc(dba, row0[cons.io.db.prp.PrpCons.P301000B].ToString());

        data.Append("<asoc>");

        data.Append("<size>");
        data.Append(view.Rows.Count);
        data.Append("</size>");

        Append(data, "hash", cons.io.db.prp.PrpCons.P301000B, row0, false);

        data.Append("<list>");
        int id = 0;
        foreach (DataRow row in view.Rows)
        {
            data.Append("<item ");
            data.Append(" id=\"").Append(id++).Append("\"");
            data.Append(" name=\"").Append(row[cons.io.db.prp.PrpCons.P3010205].ToString()).Append("\"");
            data.Append(" desp=\"").Append(row[cons.io.db.prp.PrpCons.P3010706].ToString()).Append("\"");
            data.Append(" link=\"/exts/exts0202.aspx?sid=").Append(row[cons.io.db.prp.PrpCons.P3010704].ToString()).Append("\"");
            data.Append(" icon=\"/icon/icon0001.ashx?uri=soft&amp;sid=").Append(row[cons.io.db.prp.PrpCons.P3010204].ToString()).Append("\"");
            data.Append(" exec=\"").Append(row[cons.io.db.prp.PrpCons.P3010705].ToString()).Append("\"");
            data.Append(" >");
            data.Append("<plat default=\"/icon/icon0001.ashx?sid=comn,_DEF\">");
            int P3010702 = int.Parse(row[cons.io.db.prp.PrpCons.P3010702].ToString());
            if (P3010702 == cons.SysCons.OS_IDX_ALL)
            {
                data.Append("<all>");
                data.Append("/icon/icon0001.ashx?sid=comn,_ALL");
                data.Append("</all>");
            }
            else
            {
                // Windows平台
                if ((P3010702 & cons.SysCons.OS_IDX_WINDOWS) != 0)
                {
                    data.Append("<windows>");
                    data.Append("/icon/icon0001.ashx?sid=comn,_WIN");
                    data.Append("</windows>");
                }
                // Mac OS平台
                if ((P3010702 & cons.SysCons.OS_IDX_MACINTOSH) != 0)
                {
                    data.Append("<macintosh>");
                    data.Append("/icon/icon0001.ashx?sid=comn,_MAC");
                    data.Append("</macintosh>");
                }
                // Linux平台
                if ((P3010702 & cons.SysCons.OS_IDX_LINUX) != 0)
                {
                    data.Append("<linux>");
                    data.Append("/icon/icon0001.ashx?sid=comn,_LNX");
                    data.Append("</linux>");
                }
                // Unix平台
                if ((P3010702 & cons.SysCons.OS_IDX_UNIX) != 0)
                {
                    data.Append("<unix>");
                    data.Append("/icon/icon0001.ashx?sid=comn,_UNX");
                    data.Append("</unix>");
                }
                // 移动平台
                if ((P3010702 & cons.SysCons.OS_IDX_MOBILE) != 0)
                {
                    data.Append("<mobile>");
                    data.Append("/icon/icon0001.ashx?sid=comn,_MBL");
                    data.Append("</mobile>");
                }
                // 其它平台
                if ((P3010702 & cons.SysCons.OS_IDX_UNKNOWN) != 0)
                {
                    data.Append("<special>");
                    data.Append("/icon/icon0001.ashx?sid=comn,_SPC");
                    data.Append("</special>");
                }
            }
            data.Append("</plat>");
            data.Append("</item>");
        }
        data.Append("</list>");

        data.Append("</asoc>");
        view.Dispose();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <param name="key"></param>
    /// <param name="val"></param>
    /// <param name="view"></param>
    /// <param name="trim"></param>
    private static void Append(StringBuilder data, String key, String val, DataRow view, bool trim)
    {
        if (trim)
        {
            data.Append("<").Append(key).Append(">").Append(WrpUtil.db2Xml(view[val])).Append("</").Append(key).Append(">");
        }
        else
        {
            data.Append("<").Append(key).Append(">").Append(view[val].ToString()).Append("</").Append(key).Append(">");
        }
    }
}