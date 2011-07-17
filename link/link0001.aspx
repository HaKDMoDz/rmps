<%@ Page Language="C#" MasterPageFile="~/link/link.master" AutoEventWireup="true" CodeFile="link0001.aspx.cs" Inherits="link_link0001" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="center">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr id="tr_Manager" runat="server">
                        <td align="right" colspan="2">
                            <a href="link0103.aspx" onclick="return editLink();">添加链接</a>&nbsp;<a href="link0203.aspx" onclick="return editType();">添加类别</a>
                        </td>
                    </tr>
                    <tr>
                        <td id="dv_TopType" runat="server" class="TD_TopType" align="center" valign="top" style="width: 80px;">
                        </td>
                        <td align="right" valign="top">
                            <table width="380" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td id="dv_SubType" runat="server" align="center">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td id="dv_CurLink" runat="server" align="center">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hd_TOP" runat="server" />
    <asp:HiddenField ID="hd_SID" runat="server" />
    <asp:HiddenField ID="hd_UID" runat="server" />
    <asp:HiddenField ID="hd_OPT" runat="server" />
</asp:Content>
