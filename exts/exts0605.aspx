<%@ Page Language="C#" MasterPageFile="~/exts/exts.master" AutoEventWireup="true" CodeFile="exts0605.aspx.cs" Inherits="exts_exts0605" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gv_PlatList" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="50" OnPageIndexChanging="gv_PlatList_PageIndexChanging">
                    <PagerSettings Mode="NumericFirstLast" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" HorizontalAlign="Left" />
                    <Columns>
                        <asp:BoundField DataField="P301F206" HeaderText="名称" >
                            <HeaderStyle Height="22px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="徽标">
                            <ItemTemplate>
                                <img alt="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.prp.PrpCons.P301F206]%>" src="/data/plat/l_<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.prp.PrpCons.P301F207]%>.png" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="网站">
                            <ItemTemplate>
                                <%#ReadLink(((System.Data.DataRowView)Container.DataItem)[cons.io.db.prp.PrpCons.P301F209]+"")%>
                            </ItemTemplate>
                            <HeaderStyle Height="22px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
