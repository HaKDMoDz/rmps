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
        if (IsPostBack)
        {
            return;
        }
    }

    public String NextFile()
    {
        if (!StringUtil.isValidatePath(hd_DstHash.Value))
        {
            hd_DstHash.Value = rmp.wrp.exts.Exts.NextFile(hd_DstPath.Value, HashUtil.getCurrTimeHex(true));
        }
        return hd_DstHash.Value;
    }

    public bool SaveFile(bool isManage, long operate)
    {
        if (!StringUtil.isValidateHash(hd_SrcHash.Value))
        {
            hd_DstHash.Value = "0";
            return true;
        }

        if (!StringUtil.isValidatePath(hd_DstHash.Value))
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

        hd_DstHash.Value = rmp.wrp.exts.Exts.SaveFile(srcPath, hd_SrcHash.Value, fileExt, hd_DstHash.Value, isManage, operate);
        return true;
    }

    /// <summary>
    /// 读取或设置目标保存目录
    /// </summary>
    public String DstFilePath
    {
        get
        {
            return hd_DstPath.Value;
        }
        set
        {
            String path = value;
            if (!path.EndsWith("/"))
            {
                path += '/';
            }
            hd_DstPath.Value = path;
        }
    }

    /// <summary>
    /// 读取或设置目标文件名称
    /// </summary>
    public String DstFileHash
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
    public String SrcFilePath
    {
        get
        {
            return hd_SrcPath.Value;
        }
        set
        {
            String path = value;
            if (!path.EndsWith("/"))
            {
                path += '/';
            }
            hd_SrcPath.Value = path;
        }
    }

    /// <summary>
    /// 获取临时文件名称
    /// </summary>
    public String SrcFileHash
    {
        get
        {
            return hd_SrcHash.Value;
        }
        set
        {
            hd_SrcHash.Value = value;
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
