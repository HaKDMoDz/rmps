using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Text;
using System.Web.UI.WebControls;
using cons;
using cons.wrp;
using rmp.comn;
using rmp.io.db;
using rmp.util;
using rmp.wrp;
using rmp.wrp.exts;
using Image = System.Drawing.Image;
using rmp.bean;

/// <summary>
/// 在线制作
/// </summary>
public partial class card_card0002 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 2;
        Session[cons.wrp.WrpCons.GUIDSIZE] = 3;
        Session[cons.wrp.WrpCons.GUIDNAME] = "编辑卡片";
        Session[cons.wrp.WrpCons.SCRIPTID] = "card0002";

        // 页面事件类型判断
        if (IsPostBack)
        {
            return;
        }

        // 用户权限控制
        rmp.comn.user.UserInfo ui = rmp.comn.user.UserInfo.Current(Session);
        bt_SaveData.Visible = ui.UserRank >= cons.comn.user.UserInfo.LEVEL_02;
        bt_CardIcon.Visible = ui.UserRank >= cons.comn.user.UserInfo.LEVEL_02;
        tr_CardNote.Visible = ui.UserRank < cons.comn.user.UserInfo.LEVEL_02;

        // 输入控制
        tf_CardName.MaxLength = cons.io.db.comn.ComnCons.C2010105_SIZE;
        ta_CardDesp.MaxLength = cons.io.db.comn.ComnCons.C2010108_SIZE;

        hd_URI.Value = ui.UserCode;
        // 功能列表客户端事件
        cb_FavList.Attributes.Add("onchange", "chgItem(this.selectedIndex);");
        // 系统字体加载
        foreach (FontFamily f in new InstalledFontCollection().Families)
        {
            pp_family.Items.Add(new ListItem(f.Name, f.Name));
        }
        pp_family.Attributes.Add("onchange", "chgFont('family',this.value,'fontFamily',this.value,'');");

        LoadData();
    }

    private void LoadData()
    {
        DBAccess dba = new DBAccess();

        #region 系统数据
        StringBuilder sys = new StringBuilder("var sys={");

        // 读取系统默认数据
        dba.addTable(cons.io.db.wrp.WrpCons.W2040100);
        dba.addWhere(cons.io.db.wrp.WrpCons.W2040104, "0");
        dba.addSort(cons.io.db.wrp.WrpCons.W2040101, false);

        DataTable dt = dba.executeSelect();
        cb_SysList.DataTextField = cons.io.db.wrp.WrpCons.W2040107;
        cb_SysList.DataValueField = cons.io.db.wrp.WrpCons.W2040103;
        cb_SysList.DataSource = dt;
        cb_SysList.DataBind();

        // 系统数据拼接
        foreach (DataRow row in dt.Rows)
        {
            sys.Append(row[cons.io.db.wrp.WrpCons.W2040103] + ":{");
            sys.Append(string.Format("count:{0},", row[cons.io.db.wrp.WrpCons.W2040102]));
            sys.Append(string.Format("key:'{0}',", row[cons.io.db.wrp.WrpCons.W2040106]));
            sys.Append(string.Format("name:'{0}',", row[cons.io.db.wrp.WrpCons.W2040107]));
            sys.Append(string.Format("title:'{0}',", row[cons.io.db.wrp.WrpCons.W2040108]));
            sys.Append(string.Format("text1:'{0}',", row[cons.io.db.wrp.WrpCons.W2040109]));
            sys.Append(string.Format("text2:'{0}',", row[cons.io.db.wrp.WrpCons.W204010A]));
            sys.Append(string.Format("text3:'{0}',", row[cons.io.db.wrp.WrpCons.W204010B]));
            sys.Append(string.Format("family:'{0}',", row[cons.io.db.wrp.WrpCons.W204010C]));
            sys.Append(string.Format("size:{0},", row[cons.io.db.wrp.WrpCons.W204010D]));
            sys.Append(string.Format("color:'#{0}',", row[cons.io.db.wrp.WrpCons.W204010E]));
            int style = (int)row[cons.io.db.wrp.WrpCons.W204010F];
            sys.Append(string.Format("bold:{0},", (style & (int)FontStyle.Bold) != 0 ? "true" : "false"));
            sys.Append(string.Format("itac:{0},", (style & (int)FontStyle.Italic) != 0 ? "true" : "false"));
            sys.Append(string.Format("strk:{0},", (style & (int)FontStyle.Strikeout) != 0 ? "true" : "false"));
            sys.Append(string.Format("line:{0},", (style & (int)FontStyle.Underline) != 0 ? "true" : "false"));
            sys.Append(string.Format("xpos:{0},", row[cons.io.db.wrp.WrpCons.W2040110]));
            sys.Append(string.Format("ypos:{0}", row[cons.io.db.wrp.WrpCons.W2040111]));
            sys.Append("},");
        }
        if (sys.Length > 9)
        {
            sys.Remove(sys.Length - 1, 1);
        }
        sys.Append("};");
        #endregion

        #region 用户数据
        StringBuilder usr = new StringBuilder("var usr=[");

        // 用户代码
        string sid = Request[WrpCons.SID];
        if (StringUtil.isValidateHash(sid))
        {
            // 卡片名称
            K1V3 item = Comn.ReadCat2Item(sid, hd_URI.Value + SysCons.CARD_HASH);
            tf_CardName.Text = item.K;
            ta_CardDesp.Text = item.V3;

            // 卡片背景
            try
            {
                string path = Server.MapPath(EnvCons.DIR_DAT + "card/" + sid + ".png");
                if (System.IO.File.Exists(path))
                {
                    Image img = Image.FromFile(path);
                    dv_FavCard.Style.Add("background-image", "url(data/" + sid + ".png);");
                    dv_FavCard.Style.Add("width", img.Width + "px;");
                    dv_FavCard.Style.Add("height", img.Height + "px;");
                }
            }
            catch (Exception)
            {
            }

            // 读取用户配置数据
            dba.reset();
            dba.addTable(cons.io.db.wrp.WrpCons.W2040100);
            dba.addWhere(cons.io.db.wrp.WrpCons.W2040104, hd_URI.Value);
            dba.addWhere(cons.io.db.wrp.WrpCons.W2040105, sid);
            dba.addSort(cons.io.db.wrp.WrpCons.W2040101);

            dt = dba.executeSelect();
            cb_FavList.DataTextField = cons.io.db.wrp.WrpCons.W2040107;
            cb_FavList.DataValueField = cons.io.db.wrp.WrpCons.W2040103;
            cb_FavList.DataSource = dt;
            cb_FavList.DataBind();
            hd_SID.Value = sid;

            // 用户数据拼接
            foreach (DataRow row in dt.Rows)
            {
                usr.Append("{");
                usr.Append(string.Format("count:{0},", row[cons.io.db.wrp.WrpCons.W2040102]));
                usr.Append(string.Format("key:'{0}',", WrpUtil.text2Db(row[cons.io.db.wrp.WrpCons.W2040106] + "")));
                usr.Append(string.Format("name:'{0}',", WrpUtil.text2Db(row[cons.io.db.wrp.WrpCons.W2040107] + "")));
                usr.Append(string.Format("title:'{0}',", WrpUtil.text2Db(row[cons.io.db.wrp.WrpCons.W2040108] + "")));
                usr.Append(string.Format("text1:'{0}',", WrpUtil.text2Db(row[cons.io.db.wrp.WrpCons.W2040109] + "")));
                usr.Append(string.Format("text2:'{0}',", WrpUtil.text2Db(row[cons.io.db.wrp.WrpCons.W204010A] + "")));
                usr.Append(string.Format("text3:'{0}',", WrpUtil.text2Db(row[cons.io.db.wrp.WrpCons.W204010B] + "")));
                usr.Append(string.Format("family:'{0}',", WrpUtil.text2Db(row[cons.io.db.wrp.WrpCons.W204010C] + "")));
                usr.Append(string.Format("size:{0},", row[cons.io.db.wrp.WrpCons.W204010D]));
                usr.Append(string.Format("color:'#{0}',", WrpUtil.text2Db(row[cons.io.db.wrp.WrpCons.W204010E] + "")));
                int style = (int)row[cons.io.db.wrp.WrpCons.W204010F];
                usr.Append(string.Format("bold:{0},", (style & (int)FontStyle.Bold) != 0 ? "true" : "false"));
                usr.Append(string.Format("itac:{0},", (style & (int)FontStyle.Italic) != 0 ? "true" : "false"));
                usr.Append(string.Format("strk:{0},", (style & (int)FontStyle.Strikeout) != 0 ? "true" : "false"));
                usr.Append(string.Format("line:{0},", (style & (int)FontStyle.Underline) != 0 ? "true" : "false"));
                usr.Append(string.Format("xpos:{0},", WrpUtil.text2Db(row[cons.io.db.wrp.WrpCons.W2040110] + "")));
                usr.Append(string.Format("ypos:{0}", WrpUtil.text2Db(row[cons.io.db.wrp.WrpCons.W2040111] + "")));
                usr.Append("},");
            }
        }
        if (usr.Length > 9)
        {
            usr.Remove(usr.Length - 1, 1);
        }
        usr.Append("];");
        #endregion

        // 卡片数据客户端操作记录
        dv_Script.InnerHtml = "<script type=\"text/javascript\">" + sys + usr + "</script>";
    }

    /// <summary>
    /// 保存用户卡片
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_SaveData_Click(object sender, EventArgs e)
    {
        string sid = saveCard(hd_CardData.Value, tf_CardName.Text, ta_CardDesp.Text, hd_SID.Value, rmp.comn.user.UserInfo.Current(Session).UserCode)[0];
        if (sid.Length != 16)
        {
            Wrps.ShowMesg(Master, "由于网站空间有限，每用户最多只能上传8张图片，感谢您的理解与支持！");
            return;
        }
        hd_SID.Value = sid;
        Wrps.ShowMesg(Master, "卡片数据保存成功！");
    }

    /// <summary>
    /// 卡片背景图片上传
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_CardIcon_Click(object sender, EventArgs e)
    {
        // 保存卡片数据
        string sid = saveCard(hd_CardData.Value, tf_CardName.Text, ta_CardDesp.Text, hd_SID.Value, rmp.comn.user.UserInfo.Current(Session).UserCode)[0];
        if (sid.Length != 16)
        {
            Wrps.ShowMesg(Master, "由于网站空间有限，每用户最多只能上传8张图片，感谢您的理解与支持！");
            return;
        }
        hd_SID.Value = sid;

        // 保存图片
        if (!StringUtil.isValidate(fu_CardIcon.FileName) && fu_CardIcon.FileContent.Length < 1)
        {
            Wrps.ShowMesg(Master, "请选择您要上传的图片！");
            return;
        }
        try
        {
            // 删除已有文件
            string path = Server.MapPath(EnvCons.DIR_DAT + "card/") + hd_SID.Value + ".png";
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            // 解析图片
            Image img = Image.FromStream(fu_CardIcon.FileContent);
            // 图片缩放
            double p1 = 400d / img.Width;
            double p2 = 240d / img.Height;
            double p = p1 < p2 ? p1 : p2;
            if (p < 1.0)
            {
                img = Exts.GenerateThumbnail(img, p);
            }
            img.Save(path, ImageFormat.Png);

            dv_FavCard.Style.Add("background-image", "url(data/" + hd_SID.Value + ".png);");
            dv_FavCard.Style.Add("width", img.Width + "px;");
            dv_FavCard.Style.Add("height", img.Height + "px;");

            Wrps.ShowMesg(Master, "图片文件上传成功！");
        }
        catch (Exception)
        {
            Wrps.ShowMesg(Master, "上传图片处理错误，请尽量上传JPG、PNG、GIF类型的图片！");
            return;
        }
    }

    /// <summary>
    /// 卡片数据保存
    /// </summary>
    /// <param name="data">用户编辑后的数据</param>
    /// <param name="name">卡片名称</param>
    /// <param name="desp">卡片说明</param>
    /// <param name="updt">更新数据ID</param>
    /// <param name="code">当前登录用户</param>
    public string[] saveCard(string data, string name, string desp, string updt, string code)
    {
        // 用户代码判断
        if (!StringUtil.isValidateCode(code))
        {
            return new string[] { "", "" };
        }
        // 用户权限及卡片数量判断
        code = code.ToUpper();
        if (code != cons.comn.user.UserInfo.COMN_CODE && Comn.ReadCat2List(code + SysCons.CARD_HASH).Rows.Count > 8)
        {
            return new string[] { "", "" };
        }

        DBAccess dba = new DBAccess();

        if (!StringUtil.isValidateHash(updt))
        {
            // 新增卡片记录
            updt = Comn.SaveCat2Data(code + SysCons.CARD_HASH, 0, updt, name, name, "", desp, false);
        }
        else
        {
            // 更新卡片记录
            Comn.SaveCat2Data(code + SysCons.CARD_HASH, 0, updt, name, name, "", desp, true);

            // 删除已有配置数据
            dba.reset();
            dba.addTable(cons.io.db.wrp.WrpCons.W2040100);
            dba.addWhere(cons.io.db.wrp.WrpCons.W2040104, code);
            dba.addWhere(cons.io.db.wrp.WrpCons.W2040105, updt);
            dba.executeDelete();
        }

        // 没有数据时，不进行处理
        if (!StringUtil.isValidate(data))
        {
            return new string[] { updt ?? "", "" };
        }

        // 卡片数据更新
        StringBuilder usr = new StringBuilder();
        int i = 0;
        long t = DateTime.UtcNow.ToBinary();
        foreach (string item in data.Split('\n'))
        {
            if (!StringUtil.isValidate(item))
            {
                continue;
            }

            int style = 0;
            dba.reset();
            dba.addTable(cons.io.db.wrp.WrpCons.W2040100);
            dba.addParam(cons.io.db.wrp.WrpCons.W2040101, i++);
            dba.addParam(cons.io.db.wrp.WrpCons.W2040103, StringUtil.encodeLong(t++, false));
            dba.addParam(cons.io.db.wrp.WrpCons.W2040104, code);
            dba.addParam(cons.io.db.wrp.WrpCons.W2040105, updt);
            usr.Append('{');
            foreach (string prop in item.Split('\r'))
            {
                if (!StringUtil.isValidate(prop))
                {
                    continue;
                }

                string[] temp = prop.Split('\t');
                temp[1] = WrpUtil.text2Db(temp[1]);
                switch (temp[0])
                {
                    case "count":
                        {
                            dba.addParam(cons.io.db.wrp.WrpCons.W2040102, temp[1]);
                            usr.Append(string.Format("count:{0},", temp[1]));
                            break;
                        }
                    case "key":
                        {
                            dba.addParam(cons.io.db.wrp.WrpCons.W2040106, temp[1]);
                            usr.Append(string.Format("key:'{0}',", temp[1]));
                            dba.UpdateStep(cons.io.db.wrp.WrpCons.W2040100, new string[] { cons.io.db.wrp.WrpCons.W2040104, cons.io.db.wrp.WrpCons.W2040106 }, new string[] { "0", temp[1] }, cons.io.db.wrp.WrpCons.W2040101, 1);
                            break;
                        }
                    case "name":
                        {
                            dba.addParam(cons.io.db.wrp.WrpCons.W2040107, temp[1]);
                            usr.Append(string.Format("name:'{0}',", temp[1]));
                            break;
                        }
                    case "title":
                        {
                            dba.addParam(cons.io.db.wrp.WrpCons.W2040108, temp[1]);
                            usr.Append(string.Format("title:'{0}',", temp[1]));
                            break;
                        }
                    case "text1":
                        {
                            dba.addParam(cons.io.db.wrp.WrpCons.W2040109, temp[1]);
                            usr.Append(string.Format("text1:'{0}',", temp[1]));
                            break;
                        }
                    case "text2":
                        {
                            dba.addParam(cons.io.db.wrp.WrpCons.W204010A, temp[1]);
                            usr.Append(string.Format("text2:'{0}',", temp[1]));
                            break;
                        }
                    case "text3":
                        {
                            dba.addParam(cons.io.db.wrp.WrpCons.W204010B, temp[1]);
                            usr.Append(string.Format("text3:'{0}',", temp[1]));
                            break;
                        }
                    case "family":
                        {
                            dba.addParam(cons.io.db.wrp.WrpCons.W204010C, temp[1]);
                            usr.Append(string.Format("family:'{0}',", temp[1]));
                            break;
                        }
                    case "size":
                        {
                            dba.addParam(cons.io.db.wrp.WrpCons.W204010D, temp[1]);
                            usr.Append(string.Format("size:{0},", temp[1]));
                            break;
                        }
                    case "color":
                        {
                            dba.addParam(cons.io.db.wrp.WrpCons.W204010E, (temp[1] ?? "000000").Trim('#'));
                            usr.Append(string.Format("color:'{0}',", temp[1]));
                            break;
                        }
                    case "bold":
                        {
                            if ("true" == temp[1])
                            {
                                style |= (int)FontStyle.Bold;
                            }
                            usr.Append(string.Format("bold:{0},", temp[1]));
                            break;
                        }
                    case "itac":
                        {
                            if ("true" == temp[1])
                            {
                                style |= (int)FontStyle.Italic;
                            }
                            usr.Append(string.Format("itac:{0},", temp[1]));
                            break;
                        }
                    case "strk":
                        {
                            if ("true" == temp[1])
                            {
                                style |= (int)FontStyle.Strikeout;
                            }
                            usr.Append(string.Format("strk:{0},", temp[1]));
                            break;
                        }
                    case "line":
                        {
                            if ("true" == temp[1])
                            {
                                style |= (int)FontStyle.Underline;
                            }
                            usr.Append(string.Format("line:{0},", temp[1]));
                            break;
                        }
                    case "xpos":
                        {
                            dba.addParam(cons.io.db.wrp.WrpCons.W2040110, temp[1]);
                            usr.Append(string.Format("xpos:{0},", temp[1]));
                            break;
                        }
                    case "ypos":
                        {
                            dba.addParam(cons.io.db.wrp.WrpCons.W2040111, temp[1]);
                            usr.Append(string.Format("ypos:{0}", temp[1]));
                            break;
                        }
                    default:
                        break;
                }
            }
            usr.Append("},");
            dba.addParam(cons.io.db.wrp.WrpCons.W204010F, style);
            dba.addParam(cons.io.db.wrp.WrpCons.W2040112, "");
            dba.addParam(cons.io.db.wrp.WrpCons.W2040113, EnvCons.SQL_NOW, false);
            dba.addParam(cons.io.db.wrp.WrpCons.W2040114, EnvCons.SQL_NOW, false);

            dba.executeInsert();
        }
        return new string[] { updt, usr.ToString(0, usr.Length - 1) };
    }
}
