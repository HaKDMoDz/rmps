<%@ Page Language="C#" MasterPageFile="~/exts/exts.master" AutoEventWireup="true" CodeFile="exts1009.aspx.cs" Inherits="exts_exts1009" Title="Windows Internet Explorer 加速器" %>

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
            <td style="height: 100px;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                【说明】此功能仅适用于 Microsoft Windows Internet Explorer 8 及以上版本的浏览器，要使用此功能，请<a href="http://www.microsoft.com/china/windows/products/winfamily/ie/default.mspx" target="_blank">下载最新的 Internet Explorer 浏览器</a>！
            </td>
        </tr>
    </table>
</asp:Content>
