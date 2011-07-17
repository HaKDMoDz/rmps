<%@ Page Language="C#" MasterPageFile="~/soft/soft.master" AutoEventWireup="true" CodeFile="soft0104.aspx.cs" Inherits="soft_soft0104" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                <table id="TB_VERSLIST" cellspacing="0" cellpadding="0" width="460" border="0">
                    <asp:Repeater ID="VersList" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td align="left">
                                    <a name="<%#Eval(cons.io.db.comn.ComnCons.C0010105)%>" id="<%#Eval(cons.io.db.comn.ComnCons.C0010105)%>"></a>■<%#Eval(cons.io.db.comn.ComnCons.C0010107)%>：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval(cons.io.db.comn.ComnCons.C0010105)%><br />
                                    <%#String.Format(Eval(cons.io.db.comn.ComnCons.C0010113).ToString(), "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")%>
                                </td>
                                <td width="30" align="left" valign="top">
                                    <a href="<%#Eval(cons.io.db.comn.ComnCons.C001010A)%>" title="<%#Eval(cons.io.db.comn.ComnCons.C0010106)%>_<%#Eval(cons.io.db.comn.ComnCons.C0010105)%>" target="_blank">界面</a><br>
                                    <a href="http://www.google.cn/search?complete=1&amp;hl=zh-CN&amp;newwindow=1&amp;q=<%#Eval(cons.io.db.comn.ComnCons.C0010106)%> <%#Eval(cons.io.db.comn.ComnCons.C0010105)%>&amp;meta=" title="<%#Eval(cons.io.db.comn.ComnCons.C0010106)%>_<%#Eval(cons.io.db.comn.ComnCons.C0010105)%>"
                                        target="_blank">下载</a>
                                    <a href="soft9999.aspx?sid=<%#Eval(cons.io.db.comn.ComnCons.C0010104)%>&ver=<%#Eval(cons.io.db.comn.ComnCons.C0010105)%>" title="编辑软件信息">删除</a>
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
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
