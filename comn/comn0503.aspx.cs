using System;
using System.Data;
using System.IO;

using rmp.io.db;
using rmp.comn.user;
using rmp.util;
using rmp.wrp;
using rmp.wrp.exts;
using rmp.wrp.inet;
using rmp.wrp.link;
using rmp.wrp.soft;
using rmp.wrp.srch;
using rmp.wrp.wime;
using cons;

public partial class comn_comn0503 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserInfo.Current(Session).UserRank != cons.comn.user.UserInfo.LEVEL_09)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 2;
        Session[cons.wrp.WrpCons.GUIDNAME] = "网站数据维护";
        Session[cons.wrp.WrpCons.SCRIPTID] = "comn0503";
        Session[cons.wrp.WrpCons.GUIDSIZE] = Wrps.GuidComn(Session).Count;

        tr_ErrMsg.Visible = false;

        if (IsPostBack)
        {
            return;
        }
    }
    protected void bt_ExtsCorp_Click(object sender, EventArgs e)
    {
        String time = DateTime.Now.ToString("_yyyyMMddHHmmss");
        String path = Server.MapPath(EnvCons.DIR_DAT);
        CleanIco(new DBAccess(), path + "corp/", path + "corp" + time + "/", cons.io.db.prp.PrpCons.P3010100, cons.io.db.prp.PrpCons.P3010104, "", ""); //公司LOGO
        tr_ErrMsg.Visible = true;
        lb_ErrMsg.Text = "公司图标数据清理成功！";
    }
    protected void bt_ExtsSoft_Click(object sender, EventArgs e)
    {
        String time = DateTime.Now.ToString("_yyyyMMddHHmmss");
        String path = Server.MapPath(EnvCons.DIR_DAT);
        DBAccess dba = new DBAccess();
        CleanIco(dba, path + "soft/", path + "soft" + time + "/", cons.io.db.prp.PrpCons.P3010200, cons.io.db.prp.PrpCons.P3010204, "", ""); //软件图标
        CleanIco(dba, path + "view/", path + "view" + time + "/", cons.io.db.prp.PrpCons.P3010200, cons.io.db.prp.PrpCons.P301020A, "", ""); //软件截图
        tr_ErrMsg.Visible = true;
        lb_ErrMsg.Text = "软件图标数据清理成功！";
    }
    protected void bt_ExtsFile_Click(object sender, EventArgs e)
    {
        String time = DateTime.Now.ToString("_yyyyMMddHHmmss");
        String path = Server.MapPath(EnvCons.DIR_DAT);
        CleanIco(new DBAccess(), path + "file/", path + "file" + time + "/", cons.io.db.prp.PrpCons.P3010300, cons.io.db.prp.PrpCons.P3010304, "", ""); //文件图标
        tr_ErrMsg.Visible = true;
        lb_ErrMsg.Text = "文件图标数据清理成功！";
    }
    protected void bt_UserIdio_Click(object sender, EventArgs e)
    {
        String time = DateTime.Now.ToString("_yyyyMMddHHmmss");
        String path = Server.MapPath(EnvCons.DIR_DAT);
        CleanIco(new DBAccess(), path + "idio/", path + "idio" + time + "/", cons.io.db.comn.user.UserCons.C3010400, cons.io.db.comn.user.UserCons.C3010408, "", ""); //用户图标
        tr_ErrMsg.Visible = true;
        lb_ErrMsg.Text = "个性图标数据清理成功！";
    }
    protected void bt_ExtsPlat_Click(object sender, EventArgs e)
    {
        String time = DateTime.Now.ToString("_yyyyMMddHHmmss");
        String path = Server.MapPath(EnvCons.DIR_DAT);
        CleanPlat(new DBAccess(), path + "plat/", path + "plat" + time + "/"); //操作平台
        tr_ErrMsg.Visible = true;
        lb_ErrMsg.Text = "平台图标数据清理成功！";
    }
    /// <summary>
    /// 网页精灵图标清理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_InetIcon_Click(object sender, EventArgs e)
    {
        String time = DateTime.Now.ToString("_yyyyMMddHHmmss");
        String path = Server.MapPath(EnvCons.DIR_DAT);
        CleanIco(new DBAccess(), path + "inet/", path + "inet" + time + "/", cons.io.db.wrp.WrpCons.W2019100, cons.io.db.wrp.WrpCons.W2019105, "", ""); //网页精灵
        tr_ErrMsg.Visible = true;
        lb_ErrMsg.Text = "网页精灵图标清理成功！";
    }
    protected void bt_LinkIcon_Click(object sender, EventArgs e)
    {
        String time = DateTime.Now.ToString("_yyyyMMddHHmmss");
        String path = Server.MapPath(EnvCons.DIR_DAT);
        CleanIco(new DBAccess(), path + "link/", path + "link" + time + "/", cons.io.db.prp.PrpCons.P3070100, cons.io.db.prp.PrpCons.P3070106, "", ""); //网络导航
        tr_ErrMsg.Visible = true;
        lb_ErrMsg.Text = "网络导航图标清理成功！";
    }
    protected void bt_Icon_Click(object sender, EventArgs e)
    {
        String path = Server.MapPath(EnvCons.DIR_DAT);
        RemoveRes(path, "img/");
        RemoveRes(path, "res/");
        RemoveRes(path, "svg/");

        tr_ErrMsg.Visible = true;
        lb_ErrMsg.Text = "上传图标清除成功！";
    }
    protected void bt_ExtsSize_Click(object sender, EventArgs e)
    {
        try
        {
            Exts.RecentUpdateCount += int.Parse(hd_TempData.Value);
            Exts.reLoadRecentUpdate();
            tr_ErrMsg.Visible = true;
            lb_ErrMsg.Text = "后缀数据最近更新处理成功！";
        }
        catch (Exception exp)
        {
            tr_ErrMsg.Visible = true;
            lb_ErrMsg.Text = "后缀数据最近更新处理异常：" + exp.Message;
        }
    }
    protected void bt_Soft_Click(object sender, EventArgs e)
    {
        Soft.ReLoadSoftList();
        tr_ErrMsg.Visible = true;
        lb_ErrMsg.Text = "Amon软件列表更新成功！";
    }
    /// <summary>
    /// 网站友情链接更新
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_LinkGuid_Click(object sender, EventArgs e)
    {
        Link.ReadExts();
        Link.ReadInet();
        Link.ReadGuid();
        tr_ErrMsg.Visible = true;
        lb_ErrMsg.Text = "友情链接数据更新成功！";
    }
    /// <summary>
    /// 网络导航门户网站读取
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_LinkPort_Click(object sender, EventArgs e)
    {
        Link.ReadPort(4);
        tr_ErrMsg.Visible = true;
        lb_ErrMsg.Text = "网络导航数据更新成功！";
    }
    /// <summary>
    /// 网页精灵代码读取
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_InetCode_Click(object sender, EventArgs e)
    {
        Inet.LoadData(hd_TempData.Value != "1");
        tr_ErrMsg.Visible = true;
        lb_ErrMsg.Text = "网页精灵代码重新加载成功！";
    }
    /// <summary>
    /// 网页五笔代码读取
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_WimeCode_Click(object sender, EventArgs e)
    {
        Wime.LoadData(hd_TempData.Value != "1");
        tr_ErrMsg.Visible = true;
        lb_ErrMsg.Text = "网页五笔代码重新加载成功！";
    }
    /// <summary>
    /// Amon搜索代码读取
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_SrchCode_Click(object sender, EventArgs e)
    {
        Srch.LoadData(hd_TempData.Value != "1");
        tr_ErrMsg.Visible = true;
        lb_ErrMsg.Text = "全能搜索代码重新加载成功！";
    }
    /// <summary>
    /// Amon搜索图标清理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_SrchIcon_Click(object sender, EventArgs e)
    {
        String time = DateTime.Now.ToString("_yyyyMMddHHmmss");
        String path = Server.MapPath(EnvCons.DIR_DAT);
        CleanIco(new DBAccess(), path + "srch/", path + "srch" + time + "/", cons.io.db.wrp.WrpCons.W2039100, cons.io.db.wrp.WrpCons.W2039106, "", ""); //文件图标
        tr_ErrMsg.Visible = true;
        lb_ErrMsg.Text = "文件图标数据清理成功！";
    }
    /// <summary>
    /// Amon卡片图标清理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_Card_Click(object sender, EventArgs e)
    {
        String time = DateTime.Now.ToString("_yyyyMMddHHmmss");
        String path = Server.MapPath(EnvCons.DIR_DAT);
        CleanIco(new DBAccess(), path + "card/", path + "card" + time + "/", cons.io.db.comn.ComnCons.C2010100, cons.io.db.comn.ComnCons.C2010103, "", ""); //文件图标
        tr_ErrMsg.Visible = true;
        lb_ErrMsg.Text = "文件图标数据清理成功！";
    }
    /// <summary>
    /// 图片数据增量备份
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_DataBack_Click(object sender, EventArgs e)
    {
        String data = Server.MapPath(EnvCons.DIR_DAT);
        String temp = Server.MapPath(EnvCons.DIR_BAK);

        try
        {
            String text = File.ReadAllText(data + "amon.txt");
            DateTime now = DateTime.Now;
            DateTime old = StringUtil.isValidate(text) ? DateTime.Parse(text) : now;

            foreach (string dir in Directory.GetDirectories(data))
            {
                // 获取目录名称
                text = temp + Path.GetFileName(dir) + '/';
                // 创建对应目录
                if (!Directory.Exists(text))
                {
                    Directory.CreateDirectory(text);
                }

                // 复制最近更新的文件到temp目录
                foreach (FileInfo file in new DirectoryInfo(dir).GetFiles())
                {
                    if (file.LastWriteTime > old)
                    {
                        file.CopyTo(text + file.Name, true);
                    }
                }
            }
            File.WriteAllText(data + "amon.txt", now.ToString("yyyy-MM-dd HH:mm:ss"));
            tr_ErrMsg.Visible = true;
            lb_ErrMsg.Text = "文件增量备份成功！";
        }
        catch (Exception exp)
        {
            tr_ErrMsg.Visible = true;
            lb_ErrMsg.Text = "文件增量备份失败：" + exp.Message;
        }
    }

    /// <summary>
    /// 文件删除
    /// </summary>
    /// <param name="path"></param>
    /// <param name="name"></param>
    private static void RemoveRes(String path, String name)
    {
        String[] file = Directory.GetFiles(path + name);
        foreach (String temp in file)
        {
            File.Delete(temp);
        }
    }

    /// <summary>
    /// 根据数据库中现有数据信息，清除文件夹中已经无效的图片文件数据。
    /// </summary>
    /// <param name="dba"></param>
    /// <param name="path">待进行清除处理的目标文件夹</param>
    /// <param name="temp">清理后无效文件放置文件夹</param>
    /// <param name="table">对应的数据库表格</param>
    /// <param name="column">对应的数据库字段</param>
    /// <param name="prefix">图片文件前缀</param>
    /// <param name="surfix">图片文件后缀</param>
    private static void CleanIco(DBAccess dba, String path, String temp, String table, String column, String prefix, String surfix)
    {
        if (!Directory.Exists(path))
        {
            return;
        }
        Directory.Move(path, temp); //把原有文件夹命名为临时文件夹
        Directory.CreateDirectory(path); //创建一个同名文件夹

        String fileName;
        String[] fileList;
        DataTable dt = dba.executeSelect(String.Format("SELECT {1} FROM {0}", table, column)); //数据库中图标文件数据查询
        foreach (DataRow row in dt.Rows)
        {
            fileList = Directory.GetFiles(temp, prefix + row[column] + surfix + "*"); //取得名称匹配文件列表
            if (fileList == null || fileList.Length < 1)
            {
                continue;
            }
            //匹配文件移动
            foreach (string s in fileList)
            {
                fileName = Path.GetFileName(s);
                File.Move(temp + fileName, path + fileName);
            }
        }
        dt.Dispose();
    }
    /// <summary>
    /// 运行平台数据清理
    /// </summary>
    /// <param name="dba"></param>
    /// <param name="path"></param>
    /// <param name="temp"></param>
    private static void CleanPlat(DBAccess dba, String path, String temp)
    {
        Directory.Move(path, temp); //把原有文件夹命名为临时文件夹
        Directory.CreateDirectory(path); //创建一个同名文件夹

        String fileName;
        String[] fileList;
        DataView dv = dba.CreateView(cons.io.db.prp.PrpCons.P301F200, String.Format("SELECT {1}, {2} FROM {0}", cons.io.db.prp.PrpCons.P301F200, cons.io.db.prp.PrpCons.P301F207, cons.io.db.prp.PrpCons.P301F208)); //数据库中图标文件数据查询
        foreach (DataRowView row in dv)
        {
            fileList = Directory.GetFiles(temp, "l_" + row[cons.io.db.prp.PrpCons.P301F207] + "*"); //平台图标
            if (fileList != null && fileList.Length > 0)
            {
                //匹配文件移动
                foreach (string s in fileList)
                {
                    fileName = Path.GetFileName(s);
                    File.Move(temp + fileName, path + fileName);
                }
            }
            fileList = Directory.GetFiles(temp, "r_" + row[cons.io.db.prp.PrpCons.P301F208] + "*"); //运行截图
            if (fileList != null && fileList.Length > 0)
            {
                //匹配文件移动
                foreach (string s in fileList)
                {
                    fileName = Path.GetFileName(s);
                    File.Move(temp + fileName, path + fileName);
                }
            }
        }
        dv.Dispose();
    }
}
