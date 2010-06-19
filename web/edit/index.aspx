<%@ Page Language="C#" MasterPageFile="~/edit/edit.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="edit_index" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="730">
        <tr>
            <td align="left">
                1、<a href="/edit/edit0001.aspx">精简模式</a>
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;在精简模式中，您可以进行简单网页源代码查看及编辑，并默认以UTF-8格式保存。
            </td>
        </tr>
        <tr>
            <td align="left">
                2、<a href="/edit/edit0002.aspx">高级模式</a>
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;在高级模式中，您可以进行所见即所得的网页代码书写，并进行结果的预览。
            </td>
        </tr>
    </table>
</asp:Content>
