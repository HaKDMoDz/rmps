<%@ Page Language="C#" AutoEventWireup="true" CodeFile="code0001.aspx.cs" Inherits="code_code0001" %>

<%@ Register Src="~/App_Ascx/AmonHead.ascx" TagName="AmonHead" TagPrefix="uc1" %>
<%@ Register Src="~/App_Ascx/AmonFoot.ascx" TagName="AmonFoot" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="AmonHead" runat="server">
    <title>
        <%=cons.wrp.WrpCons.TITLE_CODE%>
    </title>
    <%=cons.wrp.WrpCons.KEYWORDS_CODE%>
    <%=cons.wrp.WrpCons.DESCRIPTION_CODE%>
    <%=rmp.wrp.Wrps.ComnHead(cons.wrp.WrpCons.MODULE_CODE)%>
</head>
<body>
    <form id="AmonForm" runat="server">
    <asp:ScriptManager ID="sm_Script" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="up_Update" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td id="CodeHead" align="right" colspan="2">
                    </td>
                </tr>
                <tr>
                    <td id="CodeGuid" align="left">
                        <label>
                            <input type="radio" id="cb_EditText" name="a" onclick="showText();" checked="checked" />普通模式
                        </label>
                        <label>
                            <input type="radio" id="cb_EditHtml" name="a" onclick="showHtml();" />高级模式
                        </label>
                        <label>
                            <input type="radio" id="cb_EditCode" name="a" onclick="showCode();" />代码转换
                        </label>
                        <asp:Label ID="lb_ErrMsg" runat="server"></asp:Label>
                        <asp:HiddenField ID="hd_ErrMsg" runat="server" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td id="CodeBody" align="center">
                        <asp:TextBox ID="ta_UserData" runat="server" TextMode="MultiLine" Width="500" Height="500"></asp:TextBox>
                    </td>
                    <td align="left" valign="top" style="width: 160px;">
                        <table border="0" cellpadding="0" cellspacing="0" width="98%">
                            <tr id="tr_Res">
                                <td>
                                    资源
                                </td>
                            </tr>
                            <tr id="tr_EditOpen" runat="server" style="display: none;">
                                <td>
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td align="right">
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="tf_FilePath" runat="server" Width="100%"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
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
                            <tr id="tr_Opt">
                                <td>
                                    选项
                                </td>
                            </tr>
                            <tr id="tr_EditText" runat="server" style="display: none;">
                                <td align="left">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td align="right">
                                                格式：
                                            </td>
                                            <td align="left">
                                                <asp:CheckBox ID="ck_LineWrap" runat="server" AccessKey="W" Checked="True" Text="代码自动回行(W)" OnCheckedChanged="ck_LineWrap_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                换行：
                                            </td>
                                            <td align="left">
                                                <asp:CheckBox ID="ck_PreBreak" runat="server" AccessKey="L" Checked="True" Text="维持原有断行(L)" /><br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                代码：
                                            </td>
                                            <td align="left">
                                                <asp:CheckBox ID="ck_PrePackr" runat="server" AccessKey="P" Checked="True" Text="探测是否加壳(P)" /><br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                缩进：
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="cb_TabsSize" runat="server">
                                                    <asp:ListItem Value="1" Text="制表符缩进"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="2 空格缩进"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="3 空格缩进"></asp:ListItem>
                                                    <asp:ListItem Value="4" Text="4 空格缩进" Selected="true"></asp:ListItem>
                                                    <asp:ListItem Value="8" Text="8 空格缩进"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Button ID="bt_Beautify" runat="server" AccessKey="B" Text="格式化代码(B)" OnClientClick="return do_js_beautify();" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="tr_EditHtml" runat="server" style="display: none;">
                                <td align="left">
                                </td>
                            </tr>
                            <tr id="tr_EditCode" runat="server" style="display: none;">
                                <td align="left">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td align="right">
                                                行号：
                                            </td>
                                            <td align="left">
                                                <asp:CheckBox ID="ck_ShowLine" runat="server" Text="显示行号" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                样式：
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="cb_Style" runat="server">
                                                    <asp:ListItem Text="内联样式" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="外部样式" Value="1"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                格式：
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="cb_Format" runat="server">
                                                    <asp:ListItem Text="代码优先" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="格式优先" Value="1"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Button ID="bt_EditCode" runat="server" Text="转换" OnClick="bt_EditCode_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td id="CodeFoot" align="center" colspan="2">
                        &copy;&nbsp;<asp:Label ID="lb_CopyYear" runat="server"></asp:Label>
                        &nbsp;<a href="/info/">Amonsoft</a>.&nbsp;All&nbsp;Rights Reserved.
                        <br />
                        <a href="http://www.miibeian.gov.cn/" title="信息产业部ICP/IP地址/域名信息备案管理系统" target="_blank">沪ICP备09014915号</a>
                        <br />
                        <a href="http://validator.w3.org/check/referer" target="_blank">
                            <img src="_images/n_vxml.gif" alt="Valid CSS!" width="16" height="16" />
                        </a>&nbsp; <a href="https://www.google.com/analytics/home/" title="Google Analytics" target="_blank">
                            <img src="_images/n_copy.gif" alt="Copyright!" width="16" height="16" />
                        </a>&nbsp; <a href="http://jigsaw.w3.org/css-validator/check/referer" target="_blank">
                            <img src="_images/n_vcss.gif" alt="Valid XML!" width="16" height="16" />
                        </a>
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

<%= rmp.wrp.Wrps.ComnScript(Session, cons.wrp.WrpCons.MODULE_CODE) %>