<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AmonList.ascx.cs" Inherits="App_Ascx_AmonList" %>
<table border="0" cellpadding="0" cellspacing="0" id="TB_LIST">
    <tr>
        <td height="10px">
        </td>
    </tr>
    <tr>
        <td align="center">
            <table border="0" cellpadding="2" cellspacing="0" class="TB_LIST_ITEM">
                <tr>
                    <td class="TD_LIST_HEAD">
                        Amon在线
                    </td>
                </tr>
                <tr>
                    <td class="TD_LIST_BODY">
                        ·&nbsp;
                        <asp:HyperLink ID="hl_Exts" NavigateUrl="~/exts/index.aspx" runat="server">后缀解析</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="TD_LIST_BODY">
                        ·&nbsp;
                        <asp:HyperLink ID="hl_0001" NavigateUrl="~/iask/iask1310.aspx" runat="server">源码查看</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="TD_LIST_BODY">
                        ·&nbsp;
                        <asp:HyperLink ID="hl_1305" NavigateUrl="~/iask/iask1305.aspx" runat="server">消息摘要</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="TD_LIST_BODY">
                        ·&nbsp;
                        <asp:HyperLink ID="hl_130C" NavigateUrl="~/iask/iask130C.aspx" runat="server">ＩＰ查询</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="TD_LIST_BODY">
                        ·&nbsp;
                        <asp:HyperLink ID="hl_13A1" NavigateUrl="~/iask/iask13A1.aspx" runat="server">节目预告</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="TD_LIST_BODY">
                        ·&nbsp;
                        <asp:HyperLink ID="hl_13A2" NavigateUrl="~/iask/iask13A2.aspx" runat="server">邮编查询</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="TD_LIST_BODY">
                        ·&nbsp;
                        <asp:HyperLink ID="hl_13A3" NavigateUrl="~/iask/iask13A3.aspx" runat="server">天气预报</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="TD_LIST_BODY">
                        ·&nbsp;
                        <asp:HyperLink ID="hl_Date" NavigateUrl="~/date/index.aspx" runat="server">中国农历</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="TD_LIST_FOOT">
                        更多
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td height="10px">
        </td>
    </tr>
</table>
