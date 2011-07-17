<%@ Page Language="C#" MasterPageFile="~/wime/wime.master" AutoEventWireup="true" CodeFile="wime9999.aspx.cs" Inherits="wime_wime9999" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="center">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            文件：
                        </td>
                        <td>
                            <asp:FileUpload ID="fu_File" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            类型：
                        </td>
                        <td>
                            <asp:DropDownList ID="cb_Type" runat="server">
                                <asp:ListItem Value="0" Text="符号"></asp:ListItem>
                                <asp:ListItem Value="1" Text="五笔86（简体）"></asp:ListItem>
                                <asp:ListItem Value="2" Text="五笔86（繁体）"></asp:ListItem>
                                <asp:ListItem Value="3" Text="五笔89（简体）"></asp:ListItem>
                                <asp:ListItem Value="4" Text="五笔89（繁体）"></asp:ListItem>
                                <asp:ListItem Value="11" Text="智能拼音"></asp:ListItem>
                                <asp:ListItem Value="12" Text="内码"></asp:ListItem>
                                <asp:ListItem Value="13" Text="双拼"></asp:ListItem>
                                <asp:ListItem Value="14" Text="全拼"></asp:ListItem>
                                <asp:ListItem Value="15" Text="郑码"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            分隔字符：
                        </td>
                        <td>
                            <asp:TextBox ID="tf_Char" runat="server" Text=" "></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="bt_Save" runat="server" Text="导入" OnClick="bt_Save_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
