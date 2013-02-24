<%@ Page Title="爱梦·关于" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Amon.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="AmonHead">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="AmonView">
    <div class="body" style="width: 960px; margin: 50px auto 0px auto;">
        <div class="page shadow">
            <h3>
                关于
            </h3>
            <p>
                爱梦，一个简易的基于云计算的文件应用，可以轻易的帮您生成个性化的网站。
            </p>
            <h3>
                更新历史
            </h3>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <table width="100%">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem,"LOGS0104") %>
                            <%# DataBinder.Eval(Container.DataItem,"LOGS0105") %>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem,"LOGS0106") %>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
