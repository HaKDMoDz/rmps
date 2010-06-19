<%@ Page Language="C#" MasterPageFile="~/idea/idea.master" AutoEventWireup="true" CodeFile="idea9999.aspx.cs" Inherits="idea_idea9999" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
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
                        <table width="96%" border="0" cellpadding="3" cellspacing="0" id="IDEA_0001">
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" id="IDHD_0001">
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
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" id="IDCT_0001">
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
                                <td align="right">
                                    <a href="idea9998.aspx?o=e&e=<%# Eval(cons.io.db.wrp.WrpCons.IDEADATA_IDEAINDX) %>">编辑</a>&nbsp;<a href="idea9998.aspx?o=d&d=<%# Eval(cons.io.db.wrp.WrpCons.IDEADATA_IDEAINDX) %>">删除</a>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
