<%@ Page Language="C#" MasterPageFile="~/comn/comn.master" AutoEventWireup="true" CodeFile="comn0502.aspx.cs" Inherits="comn_comn0502" Title="无标题页" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="460" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:FileUpload ID="fu_SaveFile" runat="server" /><asp:Button ID="bt_SaveFile" runat="server" Text="上传" OnClick="bt_SaveFile_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
