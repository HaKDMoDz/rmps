<%@ Page Language="C#" AutoEventWireup="true" CodeFile="icon0100.aspx.cs" Inherits="icon_icon0100" %>

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
            <td align="center">
                <div id="dv_TypeInfo" class="TEXT_NOTE1">
                    &nbsp;
                </div>
            </td>
        </tr>
        <tr>
            <td align="center" valign="middle">
                操作类型：
                <asp:DropDownList ID="cb_TypeList" runat="server">
                    <asp:ListItem Value="" Selected="true">【请选择】</asp:ListItem>
                    <asp:ListItem Value="0">清除现有图标</asp:ListItem>
                    <asp:ListItem Value="1">图像文件上传</asp:ListItem>
                    <asp:ListItem Value="2">SVG 图像图标</asp:ListItem>
                    <asp:ListItem Value="3">资源图标提取</asp:ListItem>
                    <asp:ListItem Value="4">选择已有图标</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="bt_NextStep" runat="server" Text="下一步(N)" AccessKey="N" OnClick="bt_NextStep_Click" OnClientClick="return checkNull();" />
                <asp:HiddenField ID="hd_IconPath" runat="server" />
                <asp:HiddenField ID="hd_IconHash" runat="server" />
            </td>
        </tr>
        <tr id="tr_Inner" style="display: none;">
            <td align="center" valign="middle">
                <input id="ck_Load" type="checkbox" onclick="changeStat(this);" /><label for="ck_Load">其它目录：</label>
                <input id="rb_Img" name="load" type="radio" disabled="disabled" value="img" checked="checked" /><label for="rb_Img">上传图像</label>
                <input id="rb_Res" name="load" type="radio" disabled="disabled" value="res" /><label for="rb_Res">资源图标</label>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

<script type="text/javascript" src="icon0100.js"></script>

