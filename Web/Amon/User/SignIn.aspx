<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="Me.Amon.User.SignIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AmonHead" runat="server">
</asp:Content>
<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr id="TrErrMsg" runat="server">
            <td align="center" style="height: 40px;">
                <asp:Label ID="LbErrMsg" runat="server" CssClass="TEXT_NOTE1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table border="0" cellpadding="4" cellspacing="0" width="300" class="TB_DataList_TL">
                    <tr>
                        <th align="center" class="TD_DataHead_TL_L">
                            登录用户：
                        </th>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:TextBox ID="TbName" runat="server" Style="width: 160px;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="center" class="TD_DataHead_TL_L">
                            登录口令：
                        </th>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:TextBox ID="TbPass" runat="server" TextMode="password" Style="width: 160px;"></asp:TextBox>
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
</asp:Content>
