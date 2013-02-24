<%@ Page Title="爱梦·我的云梦空间！" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Me.Amon.Index" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="AmonHead">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="AmonView">
    <div id="DvBody" style="position: absolute; width: 820px; height: 300px; line-height: 300px; left: 50%; top: 150px; margin-left: -410px; text-align: center; overflow: hidden;">
        <table width="820">
            <tr>
                <td width="400" align="right">
                </td>
                <td width="20" align="center" rowspan="2">
                    <div class="line" />
                </td>
                <td width="400" style="height: 160px;" align="left">
                    <table width="360">
                        <tr>
                            <th align="left">
                                最近更新
                            </th>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LbVer" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LbDsp" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center" style="height: 42px">
                    <a href="/User/SignUp.aspx" class="button submit" style="color: #fff; padding: 10px 20px; font-size: 18px;">开启我的追梦之旅</a>
                </td>
                <td align="center" style="height: 42px">
                    <a href="/About.aspx" class="button cancel" style="color: #666; padding: 10px 20px; font-size: 18px;">了解更多</a> <a href="http://demo.amon.me/Page.aspx" class="button cancel" style="color: #666; padding: 10px 20px; font-size: 18px;">使用说明</a>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
