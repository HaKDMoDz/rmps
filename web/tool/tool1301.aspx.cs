using System;
using System.Data;
using System.Web.UI;

using cons.io.db.prp;
using cons.wrp.exts;

using rmp.bean;
using rmp.io.db;
using rmp.util;
using rmp.wrp.exts;

public partial class tool_tool1301 : Page
{
    protected DBAccess dba;
    protected DataTable dv_DataView;

    protected void Page_Load(object sender, EventArgs e)
    {
        Session[cons.wrp.WrpCons.GUIDNAME] = "后缀解析";
        Session[cons.wrp.WrpCons.SCRIPTID] = "1301";

        if (IsPostBack)
        {
            return;
        }

        // 界面数据处理
        LoadData();

        tr_ExtsSrch.Visible = (Request["view"] == "1");
        hd_DataSize.Value = dv_DataView != null ? dv_DataView.Rows.Count.ToString() : "0";
        tf_ExtsName.Focus();
    }

    /// <summary>
    /// 查询按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_ExtsName_Click(object sender, EventArgs e)
    {
        String extsName = tf_ExtsName.Text;
        String extsHash;
        dba = new DBAccess();
        if (hd_ExtsCase.Value == ExtsCons.EXTS_CASE_UPPR)
        {
            extsName = extsName.ToUpper();
            extsHash = HashUtil.digest(extsName.Substring(1), false);
            Exts.saveQuery(Session, extsHash, extsName, ExtsCons.EXTS_CASE_UPPR);
            tf_ExtsName.Text = extsName;
            dv_DataView = Exts.srchHash(dba, extsHash, null);
        }
        else if (hd_ExtsCase.Value == ExtsCons.EXTS_CASE_LOWR)
        {
            extsName = extsName.ToLower();
            extsHash = HashUtil.digest(extsName.Substring(1), false);
            Exts.saveQuery(Session, extsHash, extsName, ExtsCons.EXTS_CASE_LOWR);
            tf_ExtsName.Text = extsName;
            dv_DataView = Exts.srchHash(dba, extsHash, null);
        }
        else if (hd_ExtsCase.Value == ExtsCons.EXTS_CASE_BLUR)
        {
            extsHash = HashUtil.digest(extsName.Substring(1), false);
            Exts.saveQuery(Session, extsHash, extsName, ExtsCons.EXTS_CASE_BLUR);
            dv_DataView = Exts.srchName(dba, extsName, null);
        }
        else
        {
            extsHash = HashUtil.digest(extsName.Substring(1), false);
            Exts.saveQuery(Session, extsHash, extsName, ExtsCons.EXTS_CASE_CASE);
            dv_DataView = Exts.srchHash(dba, extsHash, null);
        }

        Exts.appendHistory(Session, extsName); //查询历史
        hd_DataSize.Value = dv_DataView.Rows.Count.ToString(); //查询结果
        hd_ExtsName.Value = extsName;
        tf_ExtsName.Focus(); //焦点事件

        if (extsHash != null)
        {
            dba.UpdateStep(PrpCons.P3010000, PrpCons.P3010003, extsHash, PrpCons.P3010001, 1);
        }
    }

    /// <summary>
    /// 界面数据加载
    /// </summary>
    private void LoadData()
    {
        // 页面参数获得
        String extsName = Request.Params["exts"];
        String extsCase = Request.Params["case"];
        String extsHash;

        // 外部传入参数处理
        if (StringUtil.isValidate(extsName))
        {
            hd_ExtsCase.Value = extsCase ?? ExtsCons.EXTS_CASE_CASE;
            extsName = extsName.Trim().TrimStart(new char[] {'.', '.'});
            if (extsName == ".")
            {
                return;
            }
            if (!extsName.StartsWith("."))
            {
                extsName = "." + extsName;
            }

            // 界面数据显示
            dba = new DBAccess();
            if (extsCase == ExtsCons.EXTS_CASE_UPPR)
            {
                extsName = extsName.ToUpper();
                extsHash = HashUtil.digest(extsName.Substring(1), false);
                Exts.saveQuery(Session, extsHash, extsName, extsCase);
                dv_DataView = Exts.srchHash(dba, extsHash, null);
            }
            else if (extsCase == ExtsCons.EXTS_CASE_LOWR)
            {
                extsName = extsName.ToLower();
                extsHash = HashUtil.digest(extsName.Substring(1), false);
                Exts.saveQuery(Session, extsHash, extsName, extsCase);
                dv_DataView = Exts.srchHash(dba, extsHash, null);
            }
            else if (extsCase == ExtsCons.EXTS_CASE_BLUR)
            {
                extsHash = HashUtil.digest(extsName.Substring(1), false);
                Exts.saveQuery(Session, extsHash, extsName, extsCase);
                dv_DataView = Exts.srchName(dba, extsName, null);
            }
            else
            {
                extsHash = HashUtil.digest(extsName.Substring(1), false);
                Exts.saveQuery(Session, extsHash, extsName, extsCase);
                dv_DataView = Exts.srchHash(dba, extsHash, null);
            }

            Exts.appendHistory(Session, extsName); //查询历史

            if (extsHash != null)
            {
                dba.UpdateStep(PrpCons.P3010000, PrpCons.P3010003, extsHash, PrpCons.P3010001, 1);
            }
            return;
        }

        // 其它页面转来事件处理
        if (Exts.needQuery(Session, false))
        {
            K1V2 extsItem = Exts.readQuery(Session);
            extsHash = extsItem.K;
            extsName = extsItem.V1;
            extsCase = extsItem.V2;

            dba = new DBAccess();
            if (StringUtil.isValidate(extsName))
            {
                // 界面数据显示
                switch (extsCase)
                {
                    case ExtsCons.EXTS_CASE_UPPR:
                        dv_DataView = Exts.srchHash(dba, extsHash, null);
                        break;
                    case ExtsCons.EXTS_CASE_LOWR:
                        dv_DataView = Exts.srchHash(dba, extsHash, null);
                        break;
                    case ExtsCons.EXTS_CASE_BLUR:
                        dv_DataView = Exts.srchName(dba, extsName, null);
                        break;
                    default:
                        dv_DataView = Exts.srchHash(dba, extsHash, null);
                        break;
                }
            }
            Exts.appendHistory(Session, extsName); //查询历史

            if (extsHash != null)
            {
                dba.UpdateStep(PrpCons.P3010000, PrpCons.P3010003, extsHash, PrpCons.P3010001, 1);
            }
            return;
        }
    }

    protected static String Text(DataRow row, String col)
    {
        return Text(row, col, "&nbsp;");
    }

    protected static String Text(DataRow row, String col, String def)
    {
        if (row == null)
        {
            return def;
        }
        col = row[col].ToString();
        if (col.Trim() == "")
        {
            return def;
        }
        return col.Replace("  ", "&nbsp;&nbsp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\n", "<br />");
    }
}