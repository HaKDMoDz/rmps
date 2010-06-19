<%@ Page Language="C#" MasterPageFile="~/inet/inet.master" AutoEventWireup="true" CodeFile="inet0107.aspx.cs" Inherits="inet_inet0107" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <input type="button" value="添加 Firefox 扩展" onclick="addAddons();" />
            </td>
        </tr>
        <tr>
            <td style="height: 100px;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                【说明】此功能仅适用于Mozilla Firefox 1.5及以上版本的浏览器，要使用此功能，请<a href="http://www.mozilla.com/firefox/" target="_blank">下载最新的 Firefox 浏览器</a>！
            </td>
        </tr>
    </table>
</asp:Content>
