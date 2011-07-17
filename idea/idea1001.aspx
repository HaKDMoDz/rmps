<%@ Page Language="C#" AutoEventWireup="true" CodeFile="idea1001.aspx.cs" Inherits="idea_idea1001" %>

<%@ Register Src="~/App_Ascx/AmonHead.ascx" TagName="AmonHead" TagPrefix="uc1" %>
<%@ Register Src="~/App_Ascx/AmonFoot.ascx" TagName="AmonFoot" TagPrefix="uc2" %>
<%@ Register Src="~/App_Ascx/AmonGuid.ascx" TagName="AmonGuid" TagPrefix="uc3" %>
<%@ Register Src="ascx/IdeaList.ascx" TagName="AmonList" TagPrefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <%=cons.wrp.WrpCons.TITLE_IDEA%>
    </title>
    <%=cons.wrp.WrpCons.KEYWORDS_IDEA%>
    <%=cons.wrp.WrpCons.DESCRIPTION_IDEA%>
    <%=rmp.wrp.Wrps.ComnHead(cons.wrp.WrpCons.MODULE_IDEA)%>
</head>
<body>
    <form id="AmonForm" runat="server">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td align="left" style="height: 40px;">
                    &nbsp;&nbsp;<span class="TEXT_HEAD2">留言查看</span>
                </td>
            </tr>
            <tr>
                <td height="1" class="TD_LINE">
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
                        <tr>
                            <td align="right">
                                <asp:HiddenField ID="hd_IdeaHash" runat="server" />
                                共有&nbsp;<asp:Label ID="LB_IdeaSize" runat="server" CssClass="TEXT_NOTE1"></asp:Label>&nbsp;条数据&nbsp;当前第&nbsp;<asp:Label ID="LB_PageIndx" runat="server" CssClass="TEXT_NOTE1"></asp:Label>/<asp:Label ID="LB_PageSize" runat="server" CssClass="TEXT_NOTE1"></asp:Label>&nbsp;页&nbsp;<asp:LinkButton ID="LB_LastPage"
                                    runat="server" OnClick="LastPage_Click" Enabled="false">上一页</asp:LinkButton>&nbsp;<asp:LinkButton ID="LB_NextPage" runat="server" OnClick="NextPage_Click">下一页</asp:LinkButton>
                            </td>
                        </tr>
                        <asp:Repeater ID="ideaView" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td align="center">
                                        <table width="96%" border="0" cellpadding="0" cellspacing="0" id="IDEA_0001">
                                            <tr>
                                                <td>
                                                    <table width="100%" border="0" cellpadding="2" cellspacing="0" id="IDHD_0001">
                                                        <tr>
                                                            <td width="25%" align="left">
                                                                昵称：<a href="<%# Eval(cons.io.db.wrp.WrpCons.IDEADATA_HOMEPAGE) %>" title="点击打开 <%# Eval(cons.io.db.wrp.WrpCons.IDEADATA_NICKNAME) %> 的首页" target="_blank"><%# Eval(cons.io.db.wrp.WrpCons.IDEADATA_NICKNAME)%></a>
                                                            </td>
                                                            <td width="40%" align="left">
                                                                邮件：<a href="mailto:<%# Eval(cons.io.db.wrp.WrpCons.IDEADATA_USERMAIL) %>" title="点击给 <%# Eval(cons.io.db.wrp.WrpCons.IDEADATA_NICKNAME) %> 发邮件"><%# Eval(cons.io.db.wrp.WrpCons.IDEADATA_USERMAIL)%></a>
                                                            </td>
                                                            <td width="35%" align="left">
                                                                日期：<%# Eval(cons.io.db.wrp.WrpCons.IDEADATA_DATETIME)%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="1" class="TD_LINE">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table width="100%" border="0" cellpadding="2" cellspacing="0" id="IDCT_0001">
                                                        <tr>
                                                            <td width="15%" align="center" valign="top">
                                                                留言内容：
                                                            </td>
                                                            <td width="85%" align="left">
                                                                <%# Eval(cons.io.db.wrp.WrpCons.IDEADATA_IDEATEXT)%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td height="1" class="TD_LINE">
                </td>
            </tr>
            <tr>
                <td>
                    <table width="460" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="left">
                                &nbsp;&nbsp;<span style="color: #A9A9A9">&copy;&nbsp;2008&nbsp;Amonsoft.&nbsp;All&nbsp;Rights&nbsp;Reserved.</span>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
