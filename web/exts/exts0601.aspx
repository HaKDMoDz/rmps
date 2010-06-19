<%@ Page Language="C#" MasterPageFile="~/exts/exts.master" AutoEventWireup="true" CodeFile="exts0601.aspx.cs" Inherits="exts_exts0601" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="460" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="25%" align="right">
                            平台名称：
                        </td>
                        <td width="50%">
                            <asp:TextBox ID="tf_P301F206" runat="server" Width="90%"></asp:TextBox>
                        </td>
                        <td width="25%" align="left">
                            <asp:Button ID="bt_P301F206" runat="server" Text="查询(Q)" AccessKey="Q" OnClick="bt_P301F206_Click" OnClientClick="return checkNull();" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" height="1" class="TD_LINE">
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
        <tr>
            <td align="center">
                <table width="100%" border="0" cellpadding="3" cellspacing="0" class="TB_EXTSINFO">
                    <asp:Repeater ID="rp_PlatList" runat="server">
                        <HeaderTemplate>
                            <tr>
                                <th align="center" class="TD_DataHead_TL_L" height="24">
                                    家族信息
                                </th>
                                <th align="center" class="TD_DataHead_TL_L" height="24">
                                    平台名称
                                </th>
                                <th align="center" class="TD_DataHead_TL_L" height="24">
                                    管理
                                </th>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td align="center" class="TD_DataItem_TL_L">
                                    &nbsp;<%#decodePlat(((System.Data.DataRowView)Container.DataItem)[cons.io.db.prp.PrpCons.P301F202].ToString())%>
                                </td>
                                <td align="left" class="TD_DataItem_TL_L">
                                    &nbsp;<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.prp.PrpCons.P301F206]%>
                                </td>
                                <td align="center" class="TD_DataItem_TL_L">
                                    <a href="exts0602.aspx?sid=<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.prp.PrpCons.P301F203]%>">详细</a>&nbsp;<a href="exts0603.aspx?sid=<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.prp.PrpCons.P301F203]%>">更新</a>&nbsp;<a href="exts0604.aspx?sid=<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.prp.PrpCons.P301F203]%>">删除</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
