<%@ Page Language="C#" MasterPageFile="~/exts/exts.master" AutoEventWireup="true" CodeFile="exts0301.aspx.cs" Inherits="exts_exts0301" %>

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
                        <td width="25%">
                            数值签名：
                        </td>
                        <td>
                            <asp:TextBox ID="tf_P3010306" runat="server" Width="90%"></asp:TextBox>
                        </td>
                        <td width="25%">
                            <asp:Button ID="bt_P3010306" runat="server" Text="查询(Q)" AccessKey="Q" OnClick="bt_P3010306_Click" OnClientClick="return checkNull();" />
                        </td>
                    </tr>
                    <tr id="tr_Root" runat="server" visible="false">
                        <td colspan="3">
                            <asp:LinkButton ID="lb_NullFile" runat="server" OnClick="lb_NullFile_Click">显示无效文件</asp:LinkButton>
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
                    <asp:Repeater ID="rp_FileList" runat="server">
                        <HeaderTemplate>
                            <tr>
                                <th align="center" class="TD_DataHead_TL_L" height="24">
                                    所属软件
                                </th>
                                <th align="center" class="TD_DataHead_TL_L" height="24">
                                    数值签名
                                </th>
                                <th align="center" class="TD_DataHead_TL_L" height="24">
                                    字符签名
                                </th>
                                <th align="center" class="TD_DataHead_TL_L" height="24">
                                    管理
                                </th>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td align="center" class="TD_DataItem_TL_L">
                                    &nbsp;<%#Eval(cons.io.db.prp.PrpCons.P3010205)%>
                                </td>
                                <td align="left" class="TD_DataItem_TL_L">
                                    &nbsp;<%#Eval(cons.io.db.prp.PrpCons.P3010306)%>
                                </td>
                                <td align="left" class="TD_DataItem_TL_L">
                                    &nbsp;<%#Eval(cons.io.db.prp.PrpCons.P3010305)%>
                                </td>
                                <td align="center" class="TD_DataItem_TL_L">
                                    <a href="exts0302.aspx?sid=<%#Eval(cons.io.db.prp.PrpCons.P3010302)%>">详细</a>&nbsp; <a href="exts0303.aspx?sid=<%#Eval(cons.io.db.prp.PrpCons.P3010302)%>">更新</a>&nbsp; <a href="exts0304.aspx?sid=<%#Eval(cons.io.db.prp.PrpCons.P3010302)%>">删除</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
