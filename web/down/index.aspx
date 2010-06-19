<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="down_index" %>

<%@ Register Src="../App_Ascx/AmonHead.ascx" TagName="AmonHead" TagPrefix="uc1" %>
<%@ Register Src="../App_Ascx/AmonFoot.ascx" TagName="AmonFoot" TagPrefix="uc2" %>
<%@ Register Src="../App_Ascx/AmonGuid.ascx" TagName="AmonGuid" TagPrefix="uc3" %>
<%@ Register Src="ascx/DownList.ascx" TagName="AmonList" TagPrefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <%=cons.wrp.WrpCons.TITLE_SOFT%>
    </title>
    <%=cons.wrp.WrpCons.KEYWORDS_SOFT%>
    <%=cons.wrp.WrpCons.DESCRIPTION_SOFT%>
    <%=rmp.wrp.Wrps.ComnHead(cons.wrp.WrpCons.MODULE_DOWN)%>
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
                        <!-- 可编辑代码区域 -->
                        <%--
                        <tr>
                            <td>
                            </td>
                            <td width="760">
                            </td>
                            <td>
                            </td>
                        </tr>
                        --%>
                        <tr>
                            <td class="TD_AmonBody_L">
                                &nbsp;<uc3:AmonGuid ID="AmonGuid1" runat="server" />
                            </td>
                            <td width="760" class="TD_AmonBody_M">
                                <table border="0" cellpadding="0" cellspacing="0" class="TB_BODY" id="TB_BODY">
                                    <tr>
                                        <td style="height: 10px">
                                        </td>
                                        <td style="height: 10px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="220" align="center" valign="top">
                                            <uc4:AmonList ID="AmonList1" runat="server" />
                                        </td>
                                        <td width="540" align="left" valign="top">
                                            <table border="0" cellpadding="0" cellspacing="0" class="TB_VIEW" id="TB_VIEW">
                                                <tr>
                                                    <td height="10px" align="center">
                                                        <table border="0" cellpadding="0" cellspacing="0" class="TB_USER" id="TB_USER">
                                                            <tr>
                                                                <td style="height: 10px;">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    网站导航：<span class="TEXT_NOTE2">软件下载</span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="1" class="TD_LINE">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="30" align="left">
                                                                    &nbsp;&nbsp;<span class="TEXT_HEAD2">软件下载</span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
                                                                        <tr>
                                                                            <td align="left">
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 40px;">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 10px">
                                        </td>
                                        <td style="height: 10px">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td class="TD_AmonBody_R">
                                &nbsp;
                            </td>
                        </tr>
                        <!-- 可编辑代码区域 -->
                        <%--
                        <tr>
                            <td>
                            </td>
                            <td width="760">
                            </td>
                            <td>
                            </td>
                        </tr>
                        --%>
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
