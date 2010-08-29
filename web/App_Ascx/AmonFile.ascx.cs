using System;
using rmp.util;
using System.IO;

public partial class App_Ascx_AmonFile : System.Web.UI.UserControl
{
    private bool createEditDiv;
    private bool createViewDiv;
    private bool isImage;
    private String fileExt = ".png";

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public bool SaveFile()
    {
        if (!StringUtil.isValidateHash(hd_SrcHash.Value))
        {
            hd_DstHash.Value = "0";
            return false;
        }

        if (!StringUtil.isValidateHash(hd_DstHash.Value))
        {
            hd_DstHash.Value = HashUtil.getCurrTimeHex(true);
        }

        String srcPath = hd_SrcPath.Value;
        if (!srcPath.EndsWith("/"))
        {
            srcPath += '/';
        }
        String dstPath = hd_DstPath.Value;
        if (!dstPath.EndsWith("/"))
        {
            dstPath += '/';
        }
        File.Copy(Server.MapPath(srcPath) + hd_SrcHash.Value + fileExt, Server.MapPath(dstPath) + hd_DstHash + fileExt);
        return true;
    }

    /// <summary>
    /// 读取或设置目标保存目录
    /// </summary>
    public String DstIconPath
    {
        get
        {
            return hd_DstPath.Value;
        }
        set
        {
            hd_DstPath.Value = value;
        }
    }

    /// <summary>
    /// 读取或设置目标文件名称
    /// </summary>
    public String DstIconHash
    {
        get
        {
            return hd_DstHash.Value;
        }
        set
        {
            hd_DstHash.Value = value;
        }
    }

    /// <summary>
    /// 获取临时保存目录
    /// </summary>
    public String SrcIconPath
    {
        get
        {
            return hd_SrcPath.Value;
        }
    }

    /// <summary>
    /// 获取临时文件名称
    /// </summary>
    public String SrcIconHash
    {
        get
        {
            return hd_SrcHash.Value;
        }
    }

    /// <summary>
    /// 读取或设置是否生成图标编辑DIV
    /// </summary>
    public bool CreateEditDiv
    {
        get
        {
            return createEditDiv;
        }
        set
        {
            createEditDiv = value;
        }
    }

    /// <summary>
    /// 读取或设置是否生成图标查看DIV
    /// </summary>
    public bool CreateViewDiv
    {
        get
        {
            return createViewDiv;
        }
        set
        {
            createViewDiv = value;
        }
    }

    /// <summary>
    /// 是否为图像
    /// </summary>
    public bool IsImage
    {
        get
        {
            return isImage;
        }
        set
        {
            isImage = value;
        }
    }
}
