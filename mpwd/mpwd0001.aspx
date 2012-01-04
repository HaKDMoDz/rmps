<%@ Page Language="C#" MasterPageFile="~/mpwd/mpwd.master" AutoEventWireup="true" CodeFile="mpwd0001.aspx.cs" Inherits="mpwd_mpwd0001" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table>
        <tr>
            <td align="center">
                <table id="TB_VERSLIST" cellspacing="0" cellpadding="0" width="460" border="0">
                    <asp:Repeater ID="VersList" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td align="left">
                                    <a name="<%#Eval(cons.io.db.comn.ComnCons.C0010A05)%>" id="<%#Eval(cons.io.db.comn.ComnCons.C0010A05)%>"></a>■<%#Eval(cons.io.db.comn.ComnCons.C0010A07)%>：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval(cons.io.db.comn.ComnCons.C0010A05)%><br />
                                    <%#rmp.util.WrpUtil.db2Html(Eval(cons.io.db.comn.ComnCons.C0010A13).ToString())%>
                                </td>
                                <td width="30" align="left" valign="top">
                                    <a href="<%#Eval(cons.io.db.comn.ComnCons.C0010A0A)%>" title="<%#Eval(cons.io.db.comn.ComnCons.C0010A06)%>_<%#Eval(cons.io.db.comn.ComnCons.C0010A05)%>" target="_blank">界面</a><br>
                                    <a href="http://www.google.cn/search?complete=1&amp;hl=zh-CN&amp;newwindow=1&amp;q=<%#Eval(cons.io.db.comn.ComnCons.C0010A06)%> <%#Eval(cons.io.db.comn.ComnCons.C0010A05)%>&amp;meta=" title="<%#Eval(cons.io.db.comn.ComnCons.C0010A06)%>_<%#Eval(cons.io.db.comn.ComnCons.C0010A05)%>"
                                        target="_blank">下载</a>
                                    <% 
                                        if (rmp.comn.user.UserInfo.Current(Session).UserRank == cons.comn.user.UserInfo.LEVEL_09)
                                        {
                                    %>
                                    <a href="/soft/soft0103.aspx?sid=<%#Eval(cons.io.db.comn.ComnCons.C0010A04)%>&ver=<%#Eval(cons.io.db.comn.ComnCons.C0010A05)%>" title="编辑软件信息">编辑</a>
                                    <% 
                                        }
                                    %>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 10px;">
                                </td>
                                <td style="height: 10px;">
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
