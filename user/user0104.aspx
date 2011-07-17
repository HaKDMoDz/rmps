<%@ Page Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeFile="user0104.aspx.cs" Inherits="user_user0104" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AmonView" runat="Server">
    <asp:ScriptManager ID="sm_Script" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="up_Update" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
                <tr id="tr_ErrMsg" runat="server">
                    <td align="center">
                        <asp:Label ID="lb_ErrMsg" CssClass="TEXT_NOTE1" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:LinkButton ID="lb_IsCreate" runat="server" OnClick="lb_IsCreate_Click">添加账户</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:GridView ID="gv_DataList" runat="server" Width="460" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gv_DataList_SelectedIndexChanged" DataKeyNames="U0000503">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <Columns>
                                <asp:TemplateField HeaderText="索引">
                                    <ItemTemplate>
                                        <%# Eval(cons.io.db.comn.user.UserCons.C3010501) %><%# GetMajor(Eval(cons.io.db.comn.user.UserCons.C3010506)) %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="通讯类别">
                                    <ItemTemplate>
                                        <%# Eval(cons.io.db.comn.info.C2010000.C2010107)%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="联系方式">
                                    <ItemTemplate>
                                        <%# Eval(cons.io.db.comn.user.UserCons.C3010506) %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowSelectButton="True" SelectText="更新" />
                            </Columns>
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <div id="dv_IsCreate" runat="server" visible="false">
                <table>
                    <tr>
                        <td align="center" style="width: 100px;">
                            通讯类别
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="cb_DataType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cb_DataType_SelectedIndexChanged">
                                <asp:ListItem Text="--请选择--" Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 100px;">
                            通讯方式
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="cb_DataItem" runat="server">
                                <asp:ListItem Text="--请选择--" Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 100px;">
                            通讯信息
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tf_U0000506" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 100px;">
                            口令信息
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tf_U0000507" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="bt_DropData" runat="server" Text="删除(D)" OnClick="bt_DropData_Click" OnClientClick="return dropData();" Visible="false" />
                <asp:Button ID="bt_SaveData" runat="server" Text="保存(S)" OnClick="bt_SaveData_Click" OnClientClick="return saveData();" />
                <asp:HiddenField ID="hd_IsUpdate" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
