<%@ Page Language="C#" MasterPageFile="~/comn/comn.master" AutoEventWireup="true" CodeFile="comn0301.aspx.cs" Inherits="comn_comn0301" %>

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
                            登录用户：
                        </td>
                        <td width="50%">
                            <asp:TextBox ID="tf_U0000405" runat="server" Width="90%" AutoPostBack="True" OnTextChanged="tf_U0000405_TextChanged" ToolTip="登录用户或用户编号"></asp:TextBox>
                        </td>
                        <td width="25%" align="left">
                            <asp:Button ID="bt_U0000405" runat="server" Text="查询(Q)" AccessKey="Q" OnClick="bt_U0000405_Click" />
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
                <asp:GridView ID="gv_UserList" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="4" AllowPaging="True" ForeColor="#333333" GridLines="None" PageSize="20" OnPageIndexChanging="gv_UserList_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="注册用户">
                            <HeaderStyle HorizontalAlign="Center" Height="24px" />
                            <ItemStyle HorizontalAlign="center" />
                            <ItemTemplate>
                                <%#Eval(cons.io.db.comn.user.UserCons.C3010405)%>
                                <br />
                                （<%#Eval(cons.io.db.comn.user.UserCons.C3010302)%>）
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="U000040C" HeaderText="更新时间">
                            <HeaderStyle Height="24px" HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="U000040D" HeaderText="注册时间">
                            <HeaderStyle Height="24px" HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="管理">
                            <HeaderStyle HorizontalAlign="Center" Height="24px" />
                            <ItemStyle HorizontalAlign="center" />
                            <ItemTemplate>
                                <a href="user0302.aspx?sid=<%#Eval(cons.io.db.comn.user.UserCons.C3010402)%>">详细</a>&nbsp;<a href="user0303.aspx?sid=<%#Eval(cons.io.db.comn.user.UserCons.C3010402)%>">更新</a>&nbsp;<a href="user0304.aspx?sid=<%#Eval(cons.io.db.comn.user.UserCons.C3010402)%>">删除</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <EditRowStyle BackColor="#999999" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
