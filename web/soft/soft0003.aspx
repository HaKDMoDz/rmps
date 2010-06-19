<%@ Page Language="C#" MasterPageFile="~/soft/soft.master" AutoEventWireup="true" CodeFile="soft0003.aspx.cs" Inherits="soft_soft0003" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="right">
                <asp:HyperLink ID="hl_VersJnlp" runat="server">在线启动</asp:HyperLink>
                &nbsp;
                <asp:HyperLink ID="hl_VersDown" runat="server">本地下载</asp:HyperLink>
                &nbsp; <a href="msnim:add?contact=amon.ct@hotmail.com" title="添加Amon机器人">Amon机器人</a>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Literal ID="lt_VersCode" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
