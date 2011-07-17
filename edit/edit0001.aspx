<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit0001.aspx.cs" Inherits="edit_edit0001" %>

<%@ Register Src="~/App_Ascx/AmonHead.ascx" TagName="AmonHead" TagPrefix="uc1" %>
<%@ Register Src="~/App_Ascx/AmonFoot.ascx" TagName="AmonFoot" TagPrefix="uc2" %>
<%@ Register Src="ascx/EditList.ascx" TagName="AmonList" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="AmonHead" runat="server">
    <title>
        <%=cons.wrp.WrpCons.TITLE_EDIT%>
    </title>
    <%=cons.wrp.WrpCons.KEYWORDS_EDIT%>
    <%=cons.wrp.WrpCons.DESCRIPTION_EDIT%>
    <%=rmp.wrp.Wrps.ComnHead(cons.wrp.WrpCons.MODULE_EDIT)%>
</head>
<body>
    <form id="AmonForm" runat="server">
    <asp:ScriptManager ID="sm_Script" runat="server">
    </asp:ScriptManager>
    <label>
        <input type="radio" name="a" onclick="showText();" checked="checked" />普通模式
    </label>
    <label>
        <input type="radio" name="a" onclick="showHtml();" />高级模式
    </label>
    <label>
        <input type="radio" name="a" onclick="showCode();" />代码转换
    </label>
    <asp:UpdatePanel ID="up_Update" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="right" colspan="2">
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2" style="background-color: #FFFFFF;">
                        <asp:TextBox ID="ta_UserData" runat="server" TextMode="MultiLine" Width="90%" Height="500"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="2">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lb_ErrMsg" runat="server"></asp:Label>
                                    <asp:TextBox ID="tf_FilePath" runat="server"></asp:TextBox><asp:HiddenField ID="hd_ErrMsg" runat="server" />
                                </td>
                                <td align="right">
                                    <asp:CheckBox ID="ck_OverRide" runat="server" Text="覆盖已有文件(R)" AccessKey="R" />
                                    <asp:Button ID="bt_OpenData" runat="server" Text="打开(O)" AccessKey="O" OnClick="bt_OpenData_Click" OnClientClick="return editPrompt();" />
                                    <asp:Button ID="bt_SaveData" runat="server" Text="保存(S)" AccessKey="S" OnClick="bt_SaveData_Click" OnClientClick="return editSubmit();" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="tr_EditText" runat="server">
                    <td align="left">
                        <asp:CheckBox ID="ck_LineWrap" runat="server" AccessKey="W" Checked="True" Text="代码自动回行(W)" OnCheckedChanged="ck_LineWrap_CheckedChanged" AutoPostBack="true" />
                    </td>
                    <td align="right">
                        <asp:CheckBox ID="ck_PreBreak" runat="server" AccessKey="L" Checked="True" Text="维持原有断行(L)" />
                        <asp:CheckBox ID="ck_PrePackr" runat="server" AccessKey="P" Checked="True" Text="探测是否加壳(P)" />
                        <asp:DropDownList ID="cb_TabsSize" runat="server">
                            <asp:ListItem Value="1" Text="制表符缩进"></asp:ListItem>
                            <asp:ListItem Value="2" Text="2 空格缩进"></asp:ListItem>
                            <asp:ListItem Value="3" Text="3 空格缩进"></asp:ListItem>
                            <asp:ListItem Value="4" Text="4 空格缩进" Selected="true"></asp:ListItem>
                            <asp:ListItem Value="8" Text="8 空格缩进"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="bt_Beautify" runat="server" AccessKey="B" Text="格式化代码(B)" OnClientClick="return do_js_beautify();" />
                    </td>
                </tr>
                <tr id="tr_EditHtml" runat="server">
                    <td align="left">
                    </td>
                    <td align="right">
                    </td>
                </tr>
                <tr id="tr_EditCode" runat="server">
                    <td align="left">
                        <asp:CheckBox ID="ck_ShowLine" runat="server" Text="显示行号" />
                        <asp:CheckBoxList ID="cb_Style" runat="server">
                            <asp:ListItem Text="内联样式" Value="0"></asp:ListItem>
                            <asp:ListItem Text="外部样式" Value="1"></asp:ListItem>
                        </asp:CheckBoxList>
                        <asp:CheckBoxList ID="cb_Format" runat="server">
                            <asp:ListItem Text="代码优先" Value="0"></asp:ListItem>
                            <asp:ListItem Text="格式优先" Value="1"></asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                    <td align="right">
                        <asp:Button ID="bt_EditCode" runat="server" Text="转换" OnClick="bt_EditCode_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

<script type="text/javascript" charset="utf-8" src="beautify.js"></script>

<script type="text/javascript" charset="utf-8" src="HTML-Beautify.js"></script>

<script type="text/javascript" src="kindeditor-min.js"></script>

<%= rmp.wrp.Wrps.ComnScript(Session, cons.wrp.WrpCons.MODULE_EDIT) %>