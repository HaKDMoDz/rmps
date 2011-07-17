using System;
using rmp.comn.user;
using rmp.util;
using cons;
using System.IO;
using System.Text;

/// <summary>
/// 图像文件处理
/// </summary>
public partial class file_file0101 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserInfo.Current(Session).UserRank < cons.comn.user.UserInfo.LEVEL_02)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        if (IsPostBack)
        {
            return;
        }

        String dir = cons.EnvCons.DIR_TMP + (Request[cons.wrp.WrpCons.OPT] ?? "").Trim();
        if (!dir.EndsWith("/"))
        {
            dir += '/';
        }
        String tmp = Server.MapPath(dir);

        // 记录已有图像名称
        String[] files = Directory.GetFiles(tmp, "*.png");
        StringBuilder buf = new StringBuilder();
        foreach (String file in files)
        {
            buf.Append(new FileInfo(file).Name.Replace(".png", "")).Append(',');
        }
        hd_FileList.Value = buf.Length > 0 ? buf.ToString(0, buf.Length - 1) : "";
        hd_FileIndx.Value = "0";

        // 显示默认图片
        String sid = (Request[cons.wrp.WrpCons.SID] ?? "").Trim();
        if (!StringUtil.isValidateHash(sid))
        {
            sid = "0";
        }
        hd_FileHash.Value = sid;
        im_ViewFile.ImageUrl = String.Format("{0}{1}.png", dir, sid);

        // 记录图片路径
        hd_FilePath.Value = dir.Substring(1);
    }

    protected void bt_FilePath_Click(object sender, EventArgs e)
    {
        String name = fu_FilePath.FileName;
        if (!StringUtil.isValidate(name) || !fu_FilePath.HasFile || fu_FilePath.FileContent.Length < 1)
        {
            lb_ErrMsg.Text = "请选择您要上传的图像。";
            return;
        }

        if (!StringUtil.isValidateHash(hd_FileHash.Value))
        {
            hd_FileHash.Value = HashUtil.getCurrTimeHex(true);
        }

        String imgUrl = String.Format("{0}view/{1}.png", EnvCons.DIR_TMP, hd_FileHash.Value);
        try
        {
            System.Drawing.Image image = System.Drawing.Image.FromStream(fu_FilePath.FileContent);
            image.Save(Server.MapPath(imgUrl), System.Drawing.Imaging.ImageFormat.Png);
            lb_ErrMsg.Text = "图像上传成功！";
        }
        catch (Exception exp)
        {
            lb_ErrMsg.Text = "图像上传出错：" + exp.Message;
        }

        fu_FilePath.FileContent.Close();
        im_ViewFile.ImageUrl = imgUrl;
    }
}
