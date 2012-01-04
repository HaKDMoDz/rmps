<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cat.aspx.cs" Inherits="cipher_cat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>字符集</title>
    <link href="index.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="AmonForm" runat="server">
    <asp:ScriptManager ID="AmonManager" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="CatUpdate" runat="server">
        <ContentTemplate>
            <table style="width: 280px;">
                <tr>
                    <td>
                        <%-- Character List：字符集列表 --%>
                        列表：<asp:DropDownList ID="CbCl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CbCl_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        <asp:ImageButton ID="IbCa" runat="server" ToolTip="添加新的字符集" OnClick="IbCa_Click" />
                        <asp:ImageButton ID="IbCs" runat="server" ToolTip="保存当前字符集" OnClick="IbCs_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        标题：<asp:TextBox ID="TbCt" runat="server"></asp:TextBox>
                        <asp:Label ID="LbErr2" runat="server"></asp:Label>
                        <asp:DropDownList ID="CbCs" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 100px;">
                        <asp:TextBox ID="TaCc" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
