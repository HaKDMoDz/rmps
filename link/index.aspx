<%@ Page Language="C#" MasterPageFile="~/link/link.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="link_index" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="center">
                <div id="AmonSrch">
                </div>

                <script type="text/javascript" src="/<%=cons.EnvCons.PRE_URL%>srch/srch0001.ashx?sid=<%=rmp.comn.user.UserInfo.Current(Session).UserCode%>"></script>

            </td>
        </tr>
        <tr id="tr_User0001" style="display: none;">
            <td style="height: 30px;">
                &nbsp;
            </td>
        </tr>
        <tr id="tr_User0002" style="display: none;">
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <th align="left" style="height: 25px;">
                            <img src="/_images/1307srch.png" alt="" width="16" height="16" style="vertical-align: middle;" />&nbsp;导航搜索
                        </th>
                        <td align="right">
                            <img src="/_images/exit.png" alt="关闭" title="关闭搜索结果" width="16" height="16" style="cursor: pointer;" onclick="return hide();" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="tr_User0003" style="display: none;">
            <td id="td_UserSrch" align="center">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 30px;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <th align="left" style="height: 25px;">
                <img src="/_images/1307user.png" alt="" width="16" height="16" style="vertical-align: middle;" />&nbsp;我的导航
                <asp:HiddenField ID="hd_UserCode" runat="server" />
            </th>
        </tr>
        <tr>
            <td id="td_UserLink" align="center" runat="server">
            </td>
        </tr>
        <tr>
            <td style="height: 30px;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <th align="left" style="height: 25px;">
                <img src="/_images/1307port.png" alt="" width="16" height="16" style="vertical-align: middle;" />&nbsp;门户网站
            </th>
        </tr>
        <tr>
            <td id="td_PortLink" align="center" runat="server">
            </td>
        </tr>
    </table>
</asp:Content>
