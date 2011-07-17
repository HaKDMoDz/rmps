<%@ Page Language="C#" AutoEventWireup="true" CodeFile="error.aspx.cs" Inherits="error" %>

<%@ Register Src="App_Ascx/AmonHead.ascx" TagName="AmonHead" TagPrefix="uc1" %>
<%@ Register Src="App_Ascx/AmonFoot.ascx" TagName="AmonFoot" TagPrefix="uc2" %>
<%@ Register Src="App_Ascx/AmonGuid.ascx" TagName="AmonGuid" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>出错了！</title>
    <%= rmp.wrp.Wrps.GetScript(cons.wrp.WrpCons.MODULE_COMN)%>
    <%= rmp.wrp.Wrps.GetStyles(Session, cons.wrp.WrpCons.MODULE_COMN)%>
</head>
<body>
    <form id="AmonForm" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" class="TB_AmonSoft" id="TB_AmonSoft">
        <tr>
            <td>
                <uc1:AmonHead ID="AmonHead1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="TB_AmonBody" id="TB_AmonBody">
                    <tr>
                        <td class="TD_AmonBody_L">
                            &nbsp;<uc3:AmonGuid ID="AmonGuid1" runat="server" />
                        </td>
                        <td width="760" align="center">
                            <table border="0" cellpadding="0" cellspacing="0" class="TB_BODY" id="TB_BODY">
                                <tr>
                                    <td style="height: 10px">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top">
                                        <table cellpadding="0" cellspacing="0" class="TB_HOME" id="TB_HOME">
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" height="300">
                                                    出错了！！！！！
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <uc2:AmonFoot ID="AmonFoot1" runat="server" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
