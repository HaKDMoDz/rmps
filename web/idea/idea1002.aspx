<%@ Page Language="C#" AutoEventWireup="true" CodeFile="idea1002.aspx.cs" Inherits="idea_idea1002" %>

<%@ Register Src="~/App_Ascx/AmonHead.ascx" TagName="AmonHead" TagPrefix="uc1" %>
<%@ Register Src="~/App_Ascx/AmonFoot.ascx" TagName="AmonFoot" TagPrefix="uc2" %>
<%@ Register Src="~/App_Ascx/AmonGuid.ascx" TagName="AmonGuid" TagPrefix="uc3" %>
<%@ Register Src="ascx/IdeaList.ascx" TagName="AmonList" TagPrefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <%=cons.wrp.WrpCons.TITLE_IDEA%>
    </title>
    <%=cons.wrp.WrpCons.KEYWORDS_IDEA%>
    <%=cons.wrp.WrpCons.DESCRIPTION_IDEA%>
    <%=rmp.wrp.Wrps.ComnHead(cons.wrp.WrpCons.MODULE_IDEA)%>
</head>
<body>
    <form id="AmonForm" runat="server">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td align="left" style="height: 40px;">
                    &nbsp;&nbsp;<span class="TEXT_HEAD2">发表意见</span>
                </td>
            </tr>
            <tr>
                <td height="1" class="TD_LINE">
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
                        <tr>
                            <td align="left">
                                <table border="0" width="100%" id="TB_IDEA" cellspacing="0" cellpadding="2">
                                    <tr id="tr_ErrMsg" visible="false" runat="server">
                                        <td colspan="3" align="center" bgcolor="#cccccc">
                                            <asp:Label ID="lb_ErrMsg" CssClass="TEXT_NOTE1" runat="server" Text="请输入您的留言内容！"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            反馈类型：
                                        </td>
                                        <td width="10">
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="cb_IdeaType" runat="server">
                                                <asp:ListItem Value="0" Text="意见"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="建议"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="问题"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="故障（Bug）"></asp:ListItem>
                                                <asp:ListItem Value="4" Text="其它"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hd_SoftHash" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            昵&nbsp;&nbsp;&nbsp;&nbsp;称：
                                        </td>
                                        <td width="10">
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tf_NickName" Columns="30" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            电子邮件：
                                        </td>
                                        <td width="10">
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tf_UserMail" Columns="30" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            个人首页：
                                        </td>
                                        <td width="10">
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tf_HomePage" runat="server" Columns="30"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top">
                                            <span class="TEXT_NOTE1">*</span> 留言内容：
                                        </td>
                                        <td width="10">
                                        </td>
                                        <td>
                                            <asp:TextBox ID="ta_IdeaText" runat="server" Columns="40" Rows="4" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="30">
                                        </td>
                                        <td width="10" height="30">
                                        </td>
                                        <td height="30">
                                            <asp:Button ID="bt_SaveIdea" runat="server" Text="发表意见" OnClick="bt_SaveIdea_Click" OnClientClick="return checkNull();" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td height="1" class="TD_LINE">
                </td>
            </tr>
            <tr>
                <td>
                    <table width="460" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="left">
                                &nbsp;&nbsp;<span style="color: #A9A9A9">&copy;&nbsp;2008&nbsp;Amonsoft.&nbsp;All&nbsp;Rights&nbsp;Reserved.</span>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>

    <script type="text/javascript">
    var amonForm = document.AmonForm;
    if (!amonForm)
    {
        amonForm = document.forms['AmonForm'];
    }
    function checkNull()
    {
        if(amonForm.ta_IdeaText.value=='')
        {
            alert('请输入您的留言内容！');
            amonForm.ta_IdeaText.focus();
            return false;
        }
        return true;
    }
    </script>

</body>
</html>
