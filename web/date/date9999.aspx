<%@ Page Language="C#" MasterPageFile="~/date/date.master" AutoEventWireup="true" CodeFile="date9999.aspx.cs" Inherits="date_date9999" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="center">
                <table width="460" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <th align="center">
                            类型
                        </th>
                        <td align="left">
                            <asp:HiddenField ID="hd_P3100103" runat="server" />
                            <asp:DropDownList ID="cb_P3100104" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cb_P3100104_SelectedIndexChanged">
                                <asp:ListItem>请选择</asp:ListItem>
                                <asp:ListItem Value="D">日历</asp:ListItem>
                                <asp:ListItem Value="T">时钟</asp:ListItem>
                                <asp:ListItem Value="C">综合</asp:ListItem>
                                <asp:ListItem Value="O">其它</asp:ListItem>
                            </asp:DropDownList>
                            <asp:HiddenField ID="hd_P3100104" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <th align="center">
                            类别
                        </th>
                        <td align="left">
                            <asp:DropDownList ID="cb_P3100105" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th align="center">
                            文件
                        </th>
                        <td align="left">
                            <asp:HiddenField ID="hd_P3100106" runat="server" />
                            <asp:FileUpload ID="fu_P3100106" runat="server" />
                            <asp:Button ID="bt_P3100106" runat="server" Text="上传(U)" AccessKey="U" OnClick="bt_P3100106_Click" Visible="false" />
                            <asp:HyperLink ID="hl_P3100106" runat="server" Visible="false">查看</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <th align="center">
                            名称</th>
                        <td align="left">
                            <asp:TextBox ID="tf_P3100107" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="center">
                            说明</th>
                        <td align="left">
                            <asp:TextBox ID="ta_P3100108" runat="server" Rows="4" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                        </th>
                        <td align="left">
                            <asp:Button ID="bt_Update" runat="server" Text="保存(S)" AccessKey="S" OnClick="bt_Update_Click" OnClientClick="return checkNull();" />
                            <asp:HiddenField ID="hd_IsUpdate" runat="server" />
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
