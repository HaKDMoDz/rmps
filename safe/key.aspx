<%@ Page Language="C#" AutoEventWireup="true" CodeFile="key.aspx.cs" Inherits="safe_key" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>密钥对</title>
    <style type="text/css">
        body,td
        {
            font-family: Arial, "Arial Black" , "宋体" , "微软雅黑" , Terminal, Courier;
            font-size: 12px;
        }
    </style>
</head>
<body>
    <form id="AmonForm" runat="server">
    <asp:ScriptManager ID="AmonManager" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="CatUpdate" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        公钥
                    </td>
                    <td>
                        <asp:TextBox ID="TaGk" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        私钥
                    </td>
                    <td>
                        <asp:TextBox ID="TaSk" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="right">
                        <asp:Button ID="BtGk" runat="server" Text="生成(G)" AccessKey="G" OnClick="BtGk_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
