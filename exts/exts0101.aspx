<%@ Page Language="C#" MasterPageFile="~/exts/exts.master" AutoEventWireup="true" CodeFile="exts0101.aspx.cs" Inherits="exts_exts0101" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="center">
                <table width="460" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 25%;" align="right">
                            公司名称：
                        </td>
                        <td style="width: 50%;">
                            <asp:TextBox ID="tf_P3010105" runat="server" Width="90%"></asp:TextBox>
                        </td>
                        <td style="width: 25%;" align="left">
                            <asp:Button ID="bt_P3010105" runat="server" Text="查询(Q)" AccessKey="Q" OnClick="bt_P3010105_Click" OnClientClick="return checkNull();" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" class="TD_LINE_B">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
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
                                    国别信息
                                </th>
                                <th align="center" class="TD_DataHead_TL_L" style="height: 24px;">
                                    公司名称
                                </th>
                                <th align="center" class="TD_DataHead_TL_L" style="height: 24px;">
                                    管理
                                </th>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td align="center" class="TD_DataItem_TL_L">
                                    &nbsp;<%#Eval(cons.io.db.comn.ComnCons.C1110104)%>
                                </td>
                                <td align="left" class="TD_DataItem_TL_L">
                                    &nbsp;<%#Eval(cons.io.db.prp.PrpCons.P3010105)%><br />
                                    <div style="text-align: right; color: #999999;">
                                        更新：<%#Eval(cons.io.db.prp.PrpCons.P301010A, "{0:yyyy-MM-dd HH:mm:ss}")%>
                                    </div>
                                </td>
                                <td align="center" class="TD_DataItem_TL_L">
                                    <a href="exts0102.aspx?sid=<%#Eval(cons.io.db.prp.PrpCons.P3010102)%>&opt=<%#Eval(cons.io.db.prp.PrpCons.P301010C)%>">详细</a>&nbsp; <a href="exts0103.aspx?sid=<%#Eval(cons.io.db.prp.PrpCons.P3010102)%>&opt=<%#Eval(cons.io.db.prp.PrpCons.P301010C)%>">更新</a>&nbsp; <a href="exts0104.aspx?sid=<%#Eval(cons.io.db.prp.PrpCons.P3010102)%>&opt=<%#Eval(cons.io.db.prp.PrpCons.P301010C)%>">删除</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
