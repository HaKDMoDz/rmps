<%@ Page Language="C#" MasterPageFile="~/soft/soft.master" AutoEventWireup="true" CodeFile="soft0101.aspx.cs" Inherits="soft_soft0101" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <asp:ScriptManager ID="sm_Script" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="up_Update" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
                <tr>
                    <td align="left">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <table width="460" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width: 25%;" align="right">
                                    项目查询：
                                </td>
                                <td style="width: 50%;">
                                    <asp:TextBox ID="tf_C0010100" runat="server" Width="90%"></asp:TextBox>
                                </td>
                                <td style="width: 25%;" align="left">
                                    <asp:Button ID="bt_C0010100" runat="server" Text="查询(Q)" AccessKey="Q" OnClick="bt_C0010100_Click" OnClientClick="return checkNull();" Style="height: 26px" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="height: 1px;" class="TD_LINE">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <table width="100%" border="0" cellpadding="3" cellspacing="0" class="TB_DataList_TL">
                            <asp:Repeater ID="rp_SoftList" runat="server">
                                <HeaderTemplate>
                                    <tr>
                                        <th align="center" class="TD_DataHead_TL_L" style="height: 24px;">
                                            项目编码
                                        </th>
                                        <th align="center" class="TD_DataHead_TL_L" style="height: 24px;">
                                            项目名称
                                        </th>
                                        <th align="center" class="TD_DataHead_TL_L" style="height: 24px;">
                                            概要介绍
                                        </th>
                                    </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td align="center" class="TD_DataItem_TL_L">
                                            <%#Eval(cons.io.db.comn.ComnCons.C0010104)%>
                                        </td>
                                        <td align="left" class="TD_DataItem_TL_L">
                                            <a href="<%= nextPage %>?sid=<%#Eval(cons.io.db.comn.ComnCons.C0010103)%>">
                                                <%#Eval(cons.io.db.comn.ComnCons.C0010106)%>
                                            </a>
                                        </td>
                                        <td align="left" class="TD_DataItem_TL_L">
                                            <%#Eval(cons.io.db.comn.ComnCons.C0010108)%>&nbsp;
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
