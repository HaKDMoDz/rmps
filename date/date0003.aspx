<%@ Page Language="C#" AutoEventWireup="true" CodeFile="date0003.aspx.cs" Inherits="date_date0003" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%=cons.wrp.WrpCons.TITLE_DATE%>
    </title>
    <%=cons.wrp.WrpCons.KEYWORDS_DATE%>
    <%=cons.wrp.WrpCons.DESCRIPTION_DATE%>
    <%=rmp.wrp.Wrps.ComnHead(cons.wrp.WrpCons.MODULE_DATE)%>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="dv_FlashObj">
                <p>
                    您尚未安装Adobe Flash Player，点击下面链接下载并安装：<br />
                    <br />
                    <a href="http://www.adobe.com/go/getflashplayer">
                        <img src="http://www.adobe.com/images/shared/download_buttons/get_flash_player.gif" alt="Get Adobe Flash player" />
                    </a>
                </p>
            </div>
            <asp:HiddenField ID="hd_FlashObj" runat="server" />
        </div>
    </form>
</body>
</html>

<script type="text/javascript" src="date0003.js"></script>

