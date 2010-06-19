<%@ Page Language="C#" MasterPageFile="~/idea/idea.master" AutoEventWireup="true" CodeFile="idea0001.aspx.cs" Inherits="idea_idea0001" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="left">
                <table border="0" width="100%" id="TB_IDEA" cellspacing="0" cellpadding="2">
                    <tr id="tr_ErrMsg" visible="false" runat="server">
                        <td colspan="3" align="center" bgcolor="#cccccc">
                            <asp:Label ID="lb_ErrMsg" CssClass="TEXT_NOTE1" runat="server" Text="请输入您的留言内容！"></asp:Label>
                        </td>
                    </tr>
                    <tr id="tr_SoftHash" runat="server">
                        <td align="right">
                            软&nbsp;&nbsp;&nbsp;&nbsp;件：
                        </td>
                        <td width="10">
                        </td>
                        <td>
                            <asp:DropDownList ID="cb_SoftIndx" runat="server">
                            </asp:DropDownList>
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
        <tr>
            <td height="200" align="left">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
