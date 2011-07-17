<%@ Page Language="C#" MasterPageFile="~/exts/exts.master" AutoEventWireup="true" CodeFile="exts0020.aspx.cs" Inherits="exts_exts0020" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="center">
                <table border="0" cellpadding="2" cellspacing="0" width="460">
                    <tr>
                        <td align="left">
                            ·<asp:HyperLink ID="hl_GModel" runat="server" NavigateUrl="~/exts/exts0010.aspx" Text="向导模式"></asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            ·<span class="TEXT_NOTE1">快捷模式</span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Button ID="bt_NextStep" runat="Server" Text="下一步(N)" AccessKey="N" OnClick="bt_NextStep_Click" />
                            <asp:HiddenField ID="hd_SoftHash" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
