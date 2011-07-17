<%@ Page Language="C#" MasterPageFile="~/soft/soft.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="soft9999.aspx.cs" Inherits="soft_soft9999" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="96%" border="0" cellpadding="0" cellspacing="0">
                    <tr id="tr_ErrMsg" runat="server" visible="false">
                        <td colspan="3" align="center">
                            <asp:Label ID="lb_ErrMsg" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">
                            软件标记：
                        </td>
                        <td width="10">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tf_SoftIndx" runat="server" Columns="32" MaxLength="8"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">
                            发行版本：
                        </td>
                        <td width="10">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tf_SoftVers" runat="server" Columns="32" MaxLength="16"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">
                            软件名称：
                        </td>
                        <td width="10">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tf_SoftName" runat="server" Columns="32" MaxLength="32"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">
                            发布日期：
                        </td>
                        <td width="10">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tf_PubsTime" runat="server" Columns="32" MaxLength="10"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">
                            介绍摘要：
                        </td>
                        <td width="10">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tf_VersTips" runat="server" Columns="50" MaxLength="255"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">
                            软件图标：
                        </td>
                        <td width="10">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tf_VersLogo" runat="server" Columns="50" MaxLength="1024"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">
                            软件界面：
                        </td>
                        <td width="10">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tf_VersPict" runat="server" Columns="50" MaxLength="1024"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">
                            下载路径：
                        </td>
                        <td width="10">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tf_VersDown" runat="server" Columns="50" MaxLength="1024"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">
                            在线使用：
                        </td>
                        <td width="10">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tf_VersJnlp" runat="server" Columns="50" MaxLength="1024"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">
                            网页代码：
                        </td>
                        <td width="10">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tf_VersCode" TextMode="multiLine" runat="server" Columns="40" Rows="4"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">
                            软件介绍：
                        </td>
                        <td width="10">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:TextBox ID="ta_VersInfo" TextMode="multiLine" runat="server" Columns="40" Rows="6"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">
                            更新列表：
                        </td>
                        <td width="10">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:TextBox ID="ta_VersBugs" TextMode="multiLine" runat="server" Columns="40" Rows="6"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">
                            相关说明：
                        </td>
                        <td width="10">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:TextBox ID="ta_VersDesp" TextMode="multiLine" runat="server" Columns="40" Rows="6"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">
                            当前版本：
                        </td>
                        <td width="10">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="dl_SoftProp" runat="server">
                                <asp:ListItem Value="0">历史版本</asp:ListItem>
                                <asp:ListItem Value="1">当前版本</asp:ListItem>
                                <asp:ListItem Value="2">主程序</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" style="height: 40px;">
                            &nbsp;
                        </td>
                        <td width="10" style="height: 40px;">
                            &nbsp;
                        </td>
                        <td align="left" style="height: 40px;">
                            <asp:Button ID="bt_SaveVers" runat="server" Text="保存" OnClick="bt_SaveVers_Click" />
                            <asp:HiddenField ID="bt_IsUpdate" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
