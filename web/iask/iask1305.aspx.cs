using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;

using cons.wrp;

using rmp.bean;
using rmp.wrp;

/// <summary>
/// 消息摘要
/// </summary>
public partial class iask_iask1305 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "消息摘要";
        Session[cons.wrp.WrpCons.SCRIPTID] = "iask1305";

        List<K1V2> guidList = Wrps.GuidIask(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = 2;
        K1V2 guidItem = guidList[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/iask/iask1305.aspx";
        guidItem.V1 = "消息摘要";
        guidItem.V2 = "消息摘要";

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