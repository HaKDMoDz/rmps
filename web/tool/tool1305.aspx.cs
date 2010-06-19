using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;

using cons.wrp;

public partial class tool_tool1305 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDNAME] = "消息摘要";
        Session[cons.wrp.WrpCons.SCRIPTID] = "1305";

        if (IsPostBack)
        {
            return;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_MsgDigest_Click(object sender, EventArgs e)
    {
        byte[] src = Encoding.Default.GetBytes(ta_SrcDigest.Text);
        byte[] dst;
        switch (cb_TpDigest.SelectedValue)
        {
            case "md5":
                dst = MD5.Create().ComputeHash(src);
                break;
            case "sha1":
                dst = SHA1.Create().ComputeHash(src);
                break;
            case "sha256":
                dst = SHA256.Create().ComputeHash(src);
                break;
            case "sha384":
                dst = SHA384.Create().ComputeHash(src);
                break;
            case "sha512":
                dst = SHA512.Create().ComputeHash(src);
                break;
            default:
                dst = new byte[0];
                break;
        }

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < dst.Length; i += 1)
        {
            sb.Append(Convert.ToString(dst[i], 16).PadLeft(2, '0'));
        }
        tf_DstDigest.Text = sb.ToString();
    }
}