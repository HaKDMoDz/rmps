using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

using cons.wrp;

using rmp.bean;
using rmp.util;
using rmp.wrp;

/// <summary>
/// 编码查询
/// </summary>
public partial class iask_iask1303 : Page
{
    /// <summary>
    /// 编码方案
    /// </summary>
    protected Encoding code;

    /// <summary>
    /// 结束数据
    /// </summary>
    protected int numE = -1;

    /// <summary>
    /// 起始数据
    /// </summary>
    protected int numS = -1;

    /// <summary>
    /// 查询字符
    /// </summary>
    protected String text;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "编码查询";
        Session[cons.wrp.WrpCons.SCRIPTID] = "iask1303";

        List<K1V2> guidList = Wrps.GuidIask(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = 2;
        K1V2 guidItem = guidList[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/iask/iask1303.aspx";
        guidItem.V1 = "编码查询";
        guidItem.V2 = "编码查询";

        if (IsPostBack)
        {
            return;
        }

        foreach (EncodingInfo info in WrpUtil.GetEncodings(true))
        {
            cb_Char.Items.Add(new ListItem(info.Name, info.CodePage.ToString()));
        }
        cb_Char.SelectedValue = "65001";
        cb_Char.Attributes.Add("onchange", "chgStatus(this);");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_Char_Click(object sender, EventArgs e)
    {
        save();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ck_Char_CheckedChanged(object sender, EventArgs e)
    {
        save();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ck_No16_CheckedChanged(object sender, EventArgs e)
    {
        save();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ck_No10_CheckedChanged(object sender, EventArgs e)
    {
        save();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ck_No08_CheckedChanged(object sender, EventArgs e)
    {
        save();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ck_No02_CheckedChanged(object sender, EventArgs e)
    {
        save();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ck_Fixd_CheckedChanged(object sender, EventArgs e)
    {
        save();
    }

    private void save()
    {
        text = tf_Char.Text;
        if (string.IsNullOrEmpty(text))
        {
            Wrps.ShowMesg(Master, "请输入您要查询的字符串！");
            tf_Char.Focus();
            return;
        }

        try
        {
            code = Encoding.GetEncoding(int.Parse(cb_Char.SelectedValue));
        }
        catch
        {
            code = Encoding.Default;
        }

        // 字符查询
        if (rb_Char.Checked)
        {
            return;
        }

        // 数值查询
        text = text.Trim().Replace("\r", "").Replace("\n", "");
        if (text.IndexOf('~') < 0)
        {
            text += '~' + text;
        }

        String[] temp = text.Split('~');
        if (temp.Length > 2)
        {
            Wrps.ShowMesg(Master, "您输入的数值区间不正确，请重新输入！");
            tf_Char.Focus();
            numS = -1;
            return;
        }
        if (temp.Length < 1)
        {
            numS = -1;
            return;
        }

        try
        {
            numS = radio(temp[0]);
        }
        catch (Exception)
        {
            Wrps.ShowMesg(Master, "您输入的起始结束数据不正确，请重新输入！");
            tf_Char.Focus();
            numS = -1;
            return;
        }

        try
        {
            numE = radio(temp[1]);
        }
        catch (Exception)
        {
            Wrps.ShowMesg(Master, "您输入的区间结束数据不正确，请重新输入！");
            tf_Char.Focus();
            numS = -1;
            return;
        }
    }

    private static int radio(String num)
    {
        num = num.ToLower();
        if (num.StartsWith("0x"))
        {
            return Convert.ToInt32(num.Substring(2), 16);
        }
        if (num.StartsWith("0d"))
        {
            return Convert.ToInt32(num.Substring(2), 10);
        }
        if (num.StartsWith("0o"))
        {
            return Convert.ToInt32(num.Substring(2), 8);
        }
        if (num.StartsWith("0b"))
        {
            return Convert.ToInt32(num.Substring(2), 2);
        }
        return Convert.ToInt32(num);
    }

    /// <summary>
    /// 字符到编码查询时使用的方法
    /// </summary>
    /// <param name="b"></param>
    /// <param name="r">输出进制 </param>
    /// <param name="s">间隔字符</param>
    /// <param name="p">是否定长</param>
    /// <param name="l">定长长度</param>
    /// <returns></returns>
    protected static String ToString(byte[] b, int r, char s, bool p, int l)
    {
        String v = "";
        if (b != null)
        {
            String x;
            foreach (byte t in b)
            {
                x = Convert.ToString(t, r).ToUpper();
                if (p)
                {
                    x = x.PadLeft(l, '0');
                }
                v += x + s;
            }
        }
        return v.TrimEnd(s);
    }

    /// <summary>
    /// 编码到字符查询时使用的方法
    /// </summary>
    /// <param name="i">编码</param>
    /// <param name="r">输出进制</param>
    /// <param name="p">是否定长</param>
    /// <param name="l">定长长度</param>
    /// <returns></returns>
    protected static String ToString(int i, int r, bool p, int l)
    {
        String v = Convert.ToString(i, r).ToUpper();
        return p ? v.PadLeft(l, '0') : v;
    }
}