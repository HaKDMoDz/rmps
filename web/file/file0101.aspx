<%@ Page Language="C#" AutoEventWireup="true" CodeFile="file0101.aspx.cs" Inherits="file_file0101" %>

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
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="lb_ErrMsg" runat="server" CssClass="TEXT_NOTE1"></asp:Label>
            </td>
        </tr>
        <tr id="tr_P301020A" runat="server" visible="false">
            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                选择图片：
            </th>
            <td colspan="2" align="left" class="TD_DataItem_TL_L">
                <asp:FileUpload ID="fu_FilePath" runat="server" /><asp:Button ID="bt_FilePath" runat="server" Text="上传(L)" AccessKey="L" OnClick="bt_FilePath_Click" />
                <asp:HiddenField ID="hd_FileHash" runat="server" Value="0" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Image ID="im_TmpImg" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <input type="button" value="选择(S)" accesskey="S" onclick="chooseFile();" />
                <input type="button" value="取消(C)" accesskey="C" onclick="returnHome();" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

<script type="text/javascript" src="file0101.js"></script>

