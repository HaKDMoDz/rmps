<%@ Page Title="关于作者" Language="C#" MasterPageFile="~/Amon.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Me.Amon.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="AmonHead">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="AmonView">
    <table width="100%">
        <tr>
            <td align="center" valign="middle" style="height: 120px">
                <h2>
                    阿木密码箱
                </h2>
                <h3>
                    免费且开源的密码管理软件！
                </h3>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table style="width: 600px">
                    <tr>
                        <th align="right" style="width: 100px;">
                            软件名称：
                        </th>
                        <td align="left">
                            阿木密码箱
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            当前版本：
                        </th>
                        <td align="left">
                            7.0.3.8
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                        </th>
                        <td align="left">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;阿木密码箱是一款免费且开源的密码管理软件，能够帮助您以一个安全的方式管理您的账户信息。软件采用目前国际上通用的标准商用加密算法保证您的数据机密性，支持用户自定义数据、支持随机密码生成、支持基于云存储的数据备份与恢复等功能。
                            <br />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1、实行代码开源机制，用户可以免费使用及传播；<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2、采用SHA-256算法进行身份认证，及AES算法进行数据加密；<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;3、采用系统操作日志、退出备份、用户手动本地及远程备份机制，充分保障用户数据安全；<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;4、用户完全自定义密码类别及模板，可根据需要添加或删除属性，且不限属性个数及数据长度。<br />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" height="120">
                <asp:HyperLink ID="HlSignUp" runat="server" NavigateUrl="~/down/amon.exe" CssClass="Down Ins" ForeColor="#ffffff">安装版</asp:HyperLink>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:HyperLink ID="HlSignIn" runat="server" NavigateUrl="~/down/amon.zip" CssClass="Down Grn" ForeColor="#555555">绿色版</asp:HyperLink>
            </td>
        </tr>
    </table>
</asp:Content>
