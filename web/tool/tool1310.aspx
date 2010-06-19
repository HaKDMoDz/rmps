<%@ Page Language="C#" MasterPageFile="~/tool/tool.master" AutoEventWireup="true" CodeFile="tool1310.aspx.cs" Inherits="tool_tool1310" ValidateRequest="false" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="center">
                网页地址：<asp:TextBox ID="tf_ViewSrc" runat="server" Columns="30" AutoPostBack="True" OnTextChanged="tf_ViewSrc_TextChanged">http://</asp:TextBox>
                <asp:Button ID="bt_ViewSrc" runat="server" AccessKey="V" Text="查看(V)" OnClick="bt_ViewSrc_Click" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:TextBox ID="ta_SrcText" runat="server" Rows="20" TextMode="MultiLine" Width="460" Columns="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:CheckBox ID="ck_LineWrap" runat="server" AccessKey="W" Checked="True" OnCheckedChanged="ck_LineWrap_CheckedChanged" Text="自动回行(W)" AutoPostBack="True" />
            </td>
        </tr>
        <tr id="tr_FilePath" runat="server">
            <td align="left" style="height: 12px">
                &nbsp;&nbsp;保存路径：<asp:TextBox ID="tf_FilePath" runat="server"></asp:TextBox>
                <asp:Button ID="bt_FilePath" runat="server" AccessKey="S" Text="保存(S)" OnClick="bt_FilePath_Click" />
                [注]：默认保存路径为$site/iask
            </td>
        </tr>
    </table>
</asp:Content>
