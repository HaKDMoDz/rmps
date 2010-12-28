<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="App_Ascx/AmonFile.ascx" TagName="AmonFile" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>默认</title>
    <%= rmp.wrp.Wrps.GetScript(cons.wrp.WrpCons.MODULE_COMN)%>
    <%= rmp.wrp.Wrps.GetStyles(Session, cons.wrp.WrpCons.MODULE_COMN)%>
    <%=rmp.wrp.Wrps.ComnHead(cons.wrp.WrpCons.MODULE_EXTS)%>
</head>
<body>
    <form id="form1" runat="server">
    </form>
</body>
</html>
