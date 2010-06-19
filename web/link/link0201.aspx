<%@ Page Language="C#" MasterPageFile="~/link/link.master" AutoEventWireup="true" CodeFile="link0201.aspx.cs" Inherits="link_link0201" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
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
                            类别名称：
                        </td>
                        <td style="width: 50%;">
                            <asp:TextBox ID="tf_P3070A06" runat="server" Width="90%"></asp:TextBox>
                            <asp:HiddenField ID="hd_P3070A06" runat="server" />
                        </td>
                        <td style="width: 25%;" align="left">
                            <asp:Button ID="bt_P3070A06" runat="server" Text="查询(Q)" AccessKey="Q" OnClick="bt_P3070A06_Click" OnClientClick="return checkNull();" />
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
                <asp:GridView ID="gv_TypeList" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="4" AllowPaging="True" ForeColor="#333333" GridLines="None" PageSize="50" OnPageIndexChanging="gv_TypeList_PageIndexChanging">
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <EditRowStyle BackColor="#999999" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="P3070A06" HeaderText="类别名称">
                            <HeaderStyle Height="24px" HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="P3070A07" HeaderText="相关说明">
                            <HeaderStyle Height="24px" HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="管理">
                            <HeaderStyle HorizontalAlign="Center" Height="24px" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <a href="link0202.aspx?sid=<%#Eval(cons.io.db.comn.info.C2010000.C2010105)%>">详细</a>&nbsp;<a href="link0203.aspx?sid=<%#Eval(cons.io.db.comn.info.C2010000.C2010105)%>">更新</a>&nbsp;<a href="link0204.aspx?sid=<%#Eval(cons.io.db.comn.info.C2010000.C2010105)%>">删除</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
