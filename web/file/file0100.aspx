<%@ Page Language="C#" AutoEventWireup="true" CodeFile="file0100.aspx.cs" Inherits="file_file0100" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <%=cons.wrp.WrpCons.TITLE_ICON%>
    </title>
    <%=cons.wrp.WrpCons.KEYWORDS_ICON%>
    <%=cons.wrp.WrpCons.DESCRIPTION_ICON%>
    <%=rmp.wrp.Wrps.ComnHead(cons.wrp.WrpCons.MODULE_ICON)%>
    <%= rmp.wrp.Wrps.GetScript(cons.wrp.WrpCons.MODULE_SYNC) %>
</head>
<body>
    <form id="AmonForm" runat="server">
    <table border="0" cellpadding="5" cellspacing="0" width="100%">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" valign="middle">
                操作类型：
                <asp:DropDownList ID="cb_TypeList" runat="server">
                    <asp:ListItem Value="" Selected="true">【请选择】</asp:ListItem>
                    <asp:ListItem Value="0">清除现有文件</asp:ListItem>
                    <asp:ListItem Value="1">图像文件上传</asp:ListItem>
                    <asp:ListItem Value="2">普通文件上传</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="bt_NextStep" runat="server" Text="下一步(N)" AccessKey="N" OnClick="bt_NextStep_Click" />
                <asp:HiddenField ID="hd_FileHash" runat="server" />
                <asp:HiddenField ID="hd_FilePath" runat="server" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

<script type="text/javascript" src="file0100.js"></script>

