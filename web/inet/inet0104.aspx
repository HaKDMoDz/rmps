<%@ Page Language="C#" MasterPageFile="~/inet/inet.master" AutoEventWireup="true" CodeFile="inet0104.aspx.cs" Inherits="inet_inet0104" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="left">
                月流量视图（<span class="TEXT_NOTE2">30</span>天）：<asp:DropDownList ID="cb_UserList" runat="server" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="cb_UserList_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Image ID="ib_StatView" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                日流量视图（<asp:Label ID="lb_PVCount" runat="server" CssClass="TEXT_NOTE2"></asp:Label>次）：
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:RadioButtonList ID="rb_DaysView" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="rb_DaysView_SelectedIndexChanged" RepeatLayout="Flow">
                    <asp:ListItem Text="今天" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="昨天"></asp:ListItem>
                    <asp:ListItem Text="前天"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gv_StatList" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="100%" ForeColor="#333333" GridLines="None" AllowPaging="true" PageSize="100" OnPageIndexChanging="gv_StatList_PageIndexChanging">
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="W2012103" HeaderText="时间" SortExpression="W2012103" />
                        <asp:TemplateField HeaderText="元素" ItemStyle-HorizontalAlign="left">
                            <ItemTemplate>
                                <a href="#" title="<%# Eval("W2019107")%>">
                                    <img src="/data/inet/<%# Eval("W2019105")%>.gif" alt="" /><%# Eval("W2019106")%>
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="内容" ItemStyle-HorizontalAlign="left">
                            <ItemTemplate>
                                <%#Trim(((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2012105], false)%>
                                <br />
                                <%#Trim(((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2012106], true)%>
                                <br />
                                <%#Trim(((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2012107], false)%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="W2012108" HeaderText="IP" SortExpression="W2012108" />
                        <asp:TemplateField HeaderText="浏览器" ItemStyle-HorizontalAlign="center">
                            <ItemTemplate>
                                <a title="<%# Eval("W2012109")%>">
                                    <%# Eval("W201210A")%>
                                    <br />
                                    （<%# Eval("W201210B")%>） </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <PagerSettings Mode="NumericFirstLast" />
                </asp:GridView>
                <asp:Label ID="lb_ErrMsg" runat="server" Text="当前时段没有访问记录！"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
