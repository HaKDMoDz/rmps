<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AmonHead.ascx.cs" Inherits="App_Ascx_AmonHead" %>
<table border="0" cellpadding="0" cellspacing="0" id="TB_AmonHead">
    <tr>
        <td id="TD_AmonHead_1L">
            &nbsp;
        </td>
        <td id="TD_AmonHead_1M">
            <table border="0" cellpadding="2" cellspacing="0" id="TB_HEAD">
                <tr>
                    <td style="width: 33%; height: 40px;" align="left" valign="bottom" rowspan="2">
                        <a href="/" title="Amon软件">
                            <asp:Image ID="im_AmonLogo" runat="server" />
                        </a>
                    </td>
                    <td style="width: 34%; height: 20px;" align="right">
                        <asp:Label ID="lb_AmonUser" runat="server"></asp:Label>
                    </td>
                    <td style="width: 33%; height: 20px;" align="right">
                        ·中文（简体） ·<a href="#">中文（繁體）</a> ·<a href="#">English</a>
                    </td>
                </tr>
                <tr>
                    <td style="height: 42px;">
                        &nbsp;
                    </td>
                    <td style="height: 42px;">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="height: 18px;" align="left">
                        <div id="AmonDate">
                        </div>
                    </td>
                    <td style="height: 18px;">
                        &nbsp;
                    </td>
                    <td style="height: 18px;" align="right">
                        <div id="AmonHelp">
                        </div>
                    </td>
                </tr>
            </table>
        </td>
        <td id="TD_AmonHead_1R">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td id="TD_AmonHead_2L">
            &nbsp;
        </td>
        <td id="TD_AmonHead_2M" align="center">
            <table border="0" cellpadding="0" cellspacing="0" id="TB_SITE">
                <tr>
                    <td class="TD_SITE_LINK" style="height: 30px;">
                        <a href="<%=cons.EnvCons.PRE_URL%>/">网站首页</a>
                    </td>
                    <td class="TD_SITE_LINK" style="height: 30px;">
                        <a href="<%=cons.EnvCons.PRE_URL%>/exts/">后缀解析</a>
                    </td>
                    <td class="TD_SITE_LINK" style="height: 30px;">
                        <a href="<%=cons.EnvCons.PRE_URL%>/mpwd/">魔方密码</a>
                    </td>
                    <td class="TD_SITE_LINK" style="height: 30px;">
                        <a href="<%=cons.EnvCons.PRE_URL%>/inet/">网页精灵</a>
                    </td>
                    <td class="TD_SITE_LINK" style="height: 30px;">
                        <a href="<%=cons.EnvCons.PRE_URL%>/link/">网络导航</a>
                    </td>
                    <td class="TD_SITE_LINK" style="height: 30px;">
                        <a href="<%=cons.EnvCons.PRE_URL%>/iask/">Amon在线</a>
                    </td>
                    <td class="TD_SITE_LINK" style="height: 30px;">
                        <a href="<%=cons.EnvCons.PRE_URL%>/srch/">Amon搜索</a>
                    </td>
                    <td class="TD_SITE_LINK" style="height: 30px;">
                        <a href="<%=cons.EnvCons.PRE_URL%>/card/">Amon卡片</a>
                    </td>
                    <td class="TD_SITE_LINK" style="height: 30px;">
                        <a href="<%=cons.EnvCons.PRE_URL%>/blog/">Amon博客</a>
                    </td>
                    <td class="TD_SITE_LINK" style="height: 30px;">
                        <a href="<%=cons.EnvCons.PRE_URL%>/info/">关于作者</a>
                    </td>
                    <td class="TD_SITE_USER" style="height: 30px;">
                        <asp:HyperLink ID="hl_SignIn" NavigateUrl="~/user/user0101.aspx" runat="server">登录</asp:HyperLink><asp:LinkButton ID="lb_SignOs" runat="server" OnClick="lb_SignOs_Click">退出</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </td>
        <td id="TD_AmonHead_2R">
            &nbsp;
        </td>
    </tr>
</table>

<script type="text/javascript" charset="utf-8">
function net_amonsoft_user()
{
    iNetHelper.init('AmonDate','time','yyyy年MM月dd日 HH:mm:ss wwww');
    iNetHelper.init('AmonHelp','help');
    iNetHelper.init('AmonHelp','pbse');
    iNetHelper.init('AmonHelp','menu');
}
</script>

