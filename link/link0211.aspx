<%@ Page Language="C#" AutoEventWireup="true" CodeFile="link0211.aspx.cs" Inherits="link_link0211" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="AmonForm" runat="server">
    <asp:TreeView ID="KindList" runat="server" AccessKey="K" Width="100%" ShowCheckBoxes="Leaf">
    </asp:TreeView>
    <div style="text-align: right">
        <asp:HiddenField ID="MaxCnt" runat="server" />
        <asp:HiddenField ID="MinCnt" runat="server" />
        <input type="button" value="选择" onclick="" />
    </div>
    </form>
</body>
</html>
