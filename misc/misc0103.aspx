<%@ Page Language="C#" AutoEventWireup="true" CodeFile="misc0103.aspx.cs" Inherits="misc_misc0103" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm_Script" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="up_Update" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="right">
                        一级类别
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="cbCat1List" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cbCat1List_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        二级类别
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="cbCat2List" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        标题
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbHead" runat="server" MaxLength="128"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        内容
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbBody" runat="server" MaxLength="256" TextMode="MultiLine" Rows="4"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="right">
                        <asp:Label ID="lbMesg" runat="server"></asp:Label>
                        <asp:Button ID="btSave" runat="server" Text="Button" OnClick="btSave_Click" />
                        <asp:HiddenField ID="hdHash" runat="server" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
