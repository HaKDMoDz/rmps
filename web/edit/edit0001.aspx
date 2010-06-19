<%@ Page Language="C#" MasterPageFile="~/edit/edit.master" AutoEventWireup="true" CodeFile="edit0001.aspx.cs" Inherits="edit_edit0001" ValidateRequest="false" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <asp:ScriptManager ID="sm_Script" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="up_Update" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="730">
                <tr>
                    <td align="right" colspan="2">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="left">
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
                <tr>
                    <td align="center" colspan="2" style="background-color: #FFFFFF;">
                        <asp:TextBox ID="ta_UserData" runat="server" TextMode="MultiLine" Width="730" Height="500"></asp:TextBox>
                    </td>
                </tr>
                <tr>
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
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript" src="beautify.js"></script>

    <script type="text/javascript" src="HTML-Beautify.js"></script>

</asp:Content>
