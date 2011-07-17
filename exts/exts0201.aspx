<%@ Page Language="C#" MasterPageFile="~/exts/exts.master" AutoEventWireup="true" CodeFile="exts0201.aspx.cs" Inherits="exts_exts0201" %>

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
                            软件名称：
                        </td>
                        <td width="50%">
                            <asp:TextBox ID="tf_P3010205" runat="server" Width="90%"></asp:TextBox>
                        </td>
                        <td width="25%" align="left">
                            <asp:Button ID="bt_P3010205" runat="server" Text="查询(Q)" AccessKey="Q" OnClick="bt_P3010205_Click" OnClientClick="return checkNull();" />
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
                <table width="100%" border="0" cellpadding="3" cellspacing="0" class="TB_DataList_TL">
                    <asp:Repeater ID="rp_SoftList" runat="server">
                        <HeaderTemplate>
                            <tr>
                                <th align="center" class="TD_DataHead_TL_L" height="24">
                                    所属公司
                                </th>
                                <th align="center" class="TD_DataHead_TL_L" height="24">
                                    软件名称
                                </th>
                                <th align="center" class="TD_DataHead_TL_L" height="24">
                                    管理
                                </th>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td align="center" class="TD_DataItem_TL_L">
                                    &nbsp;<%#Eval(cons.io.db.prp.PrpCons.P3010105)%>
                                </td>
                                <td align="left" class="TD_DataItem_TL_L">
                                    &nbsp;<%#Eval(cons.io.db.prp.PrpCons.P3010205)%>
                                    <div style="text-align: right">
                                        <%#rmp.wrp.exts.Exts.ShowDataStatus(Eval(cons.io.db.comn.user.UserCons.C3010407), Eval(cons.io.db.prp.PrpCons.P3010210), Eval(cons.io.db.prp.PrpCons.P301020F))%>
                                    </div>
                                </td>
                                <td align="center" class="TD_DataItem_TL_L">
                                    <a href="exts0202.aspx?sid=<%#Eval(cons.io.db.prp.PrpCons.P3010202)%>&opt=<%#Eval(cons.io.db.prp.PrpCons.P301020F)%>">详细</a>&nbsp; <a href="exts0203.aspx?sid=<%#Eval(cons.io.db.prp.PrpCons.P3010202)%>&opt=<%#Eval(cons.io.db.prp.PrpCons.P301020F)%>">更新</a>&nbsp; <a href="exts0204.aspx?sid=<%#Eval(cons.io.db.prp.PrpCons.P3010202)%>">
                                        删除</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
