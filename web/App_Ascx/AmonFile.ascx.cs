using System;

public partial class App_Ascx_AmonFile : System.Web.UI.UserControl
{
    private bool createEditDiv;
    private bool createViewDiv;
    private bool isImage;

    protected void Page_Load(object sender, EventArgs e)
    {
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
