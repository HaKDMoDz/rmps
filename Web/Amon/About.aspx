<%@ Page Title="爱梦·关于" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Amon.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="AmonHead">
    <style type="text/css">
        .help
        {
            font-size: .90em;
            font-family: 微软雅黑, "Helvetica Neue" , "Lucida Grande" , "Segoe UI" , Arial, Helvetica, Verdana, sans-serif;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="AmonView">
    <div class="body" style="width: 960px; margin: 50px auto 0px auto;">
        <div class="page shadow">
            <table cellpadding="0" cellspacing="0" border="0" style="width: 940px; margin: 10px;">
                <tr>
                    <td>
                        <h3>
                            关于爱梦
                        </h3>
                    </td>
                </tr>
                <tr>
                    <td class="help">
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;爱梦，一个可以协助您轻松实现建站梦想的地方。其充分利用现有开放云存储平台的大容量、便捷性等特点，并实现本地文件管理-在线实时预览的目标，在这里您可以打造个性化的卡片、网站、图册、读书等内容。<br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <a href="http://amon.me/p/demo">&gt;&gt;&gt;&gt;查看演示</a>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3>
                            更新历史
                        </h3>
                    </td>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <br />
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
                </asp:Repeater>
            </table>
        </div>
    </div>
</asp:Content>
