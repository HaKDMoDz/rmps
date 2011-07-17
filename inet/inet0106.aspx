<%@ Page Language="C#" MasterPageFile="~/inet/inet.master" AutoEventWireup="true" CodeFile="inet0106.aspx.cs" Inherits="inet_inet0106" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <input type="button" value="添加 IE8 加速器" onclick="addEngine();" />
            </td>
        </tr>
        <tr>
            <td style="height: 60px;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                【说明】
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;1、此功能仅适用于 Microsoft Windows Internet Explorer 8 及以上版本的浏览器，要使用此功能请<a href="http://www.microsoft.com/china/windows/internet-explorer/" target="_blank">下载最新的 Internet Explorer 浏览器</a>！
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;2、此功能与 Windows Internet Explorer 8 加载项资源库网站上的功能有所不同：采用基于您的偏好配置而不是默认用户信息，建议使用此加速器覆盖已有加速器。
            </td>
        </tr>
    </table>
</asp:Content>
