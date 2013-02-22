<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="Me.Amon.User.SignIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AmonHead" runat="server">
    <style type="text/css">
        .user
        {
            width: 160px;
            height: 33px;
            margin: 6px;
            line-height: 33px;
            padding: 5px 5px;
            font-family: "微软雅黑";
            font-size: 16px;
        }
    </style>
</asp:Content>
<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <div style="background: url(../_img/wrap.png) no-repeat; width: 436px; height: 782px; top: 0px; left: 50%; margin-left: -218px; position: absolute; top: 0;">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr id="TrErrMsg" runat="server">
                <td colspan="2" align="center" style="height: 40px;">
                    <asp:Label ID="LbErrMsg" runat="server" CssClass="TEXT_NOTE1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table border="0" cellpadding="4" cellspacing="0" width="320">
                        <tr>
                            <th align="center">
                                登录用户：
                            </th>
                            <td align="left">
                                <asp:TextBox ID="TbName" runat="server" CssClass="user corner"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th align="center">
                                登录口令：
                            </th>
                            <td align="left">
                                <asp:TextBox ID="TbPass" runat="server" TextMode="password" CssClass="user corner"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table border="0" cellpadding="4" cellspacing="0" width="300">
                        <tr>
                            <td align="left">
                                演示账户：demo/demo
                            </td>
                            <td align="right" style="height: 40px;">
                                <asp:Button ID="BtSignIn" runat="server" Text="登录(S)" AccessKey="S" OnClick="BtSignIn_Click" />
                                <a href="SignUp.aspx">注册</a>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
