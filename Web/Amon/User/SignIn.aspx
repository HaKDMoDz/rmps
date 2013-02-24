<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="Me.Amon.User.SignIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AmonHead" runat="server">
</asp:Content>
<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <div style="background: url(../_img/wrap.png) no-repeat; width: 436px; height: 782px; top: 0px; left: 50%; margin-left: -218px; padding-top: 50px; position: absolute;">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr id="TrErrMsg" runat="server">
                <td colspan="2" align="center" style="height: 40px;">
                    <asp:Label ID="LbErrMsg" runat="server" CssClass="error"></asp:Label>
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
                                <asp:TextBox ID="TbName" runat="server" CssClass="input corner"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th align="center">
                                登录口令：
                            </th>
                            <td align="left">
                                <asp:TextBox ID="TbPass" runat="server" TextMode="password" CssClass="input corner"></asp:TextBox>
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
                                <asp:Button ID="BtSignIn" runat="server" Text="登录" OnClick="BtSignIn_Click" CssClass="button submit" />
                                <input type="button" onclick="javascript:window.location='SignUp.aspx';" value="注册" class="button cancel" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
