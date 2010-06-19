<%@ Page Language="C#" MasterPageFile="~/edit/edit.master" AutoEventWireup="true" CodeFile="edit0002.aspx.cs" Inherits="edit_edit0002" ValidateRequest="false" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <asp:ScriptManager ID="sm_Script" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="up_Update" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="738">
                <tr>
                    <td align="right">
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
                    <td align="left" style="background-color: #FFFFFF;">
                        <asp:HiddenField ID="hd_UserData" runat="server" Value="&nbsp;" />

                        <script type="text/javascript" src="edit.js"></script>

                        <script type="text/javascript">
                            var editor = new KindEditor("editor");
                            editor.hiddenName = "ctl00$AmonView$hd_UserData";
                            editor.skinPath = "skin/";
                            editor.iconPath = "icon/";
                            editor.imageAttachPath = "pict/";
                            editor.imageUploadCgi = "load/upload.php";
                            editor.cssPath = "/_styles/comn.css";
                            editor.editorWidth = "738px";
                            editor.editorHeight = "500px";
                            editor.menuBorderColor = '#CCCCCC';
                            editor.menuBgColor = '#F0F0EE';
                            editor.menuTextColor = '#222222';
                            editor.menuSelectedColor = '#CCCCCC';
                            editor.toolbarBorderColor = '#CCCCCC';
                            editor.toolbarBgColor = '#F0F0EE';
                            editor.formBorderColor = '#CCCCCC';
                            editor.buttonColor = '#DDDDDD';
                            editor.show();
                        </script>

                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
