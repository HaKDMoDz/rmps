<%@ Page Language="C#" MasterPageFile="~/soft/soft.master" AutoEventWireup="true" CodeFile="soft0103.aspx.cs" Inherits="soft_soft0103" ValidateRequest="false" %>

<%@ Register Src="~/App_Ascx/AmonAuth.ascx" TagName="AmonAuth" TagPrefix="uc1" %>
<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <asp:ScriptManager ID="sm_Ajax" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="up_Ajax" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
                <tr>
                    <td align="center">
                        <asp:Label ID="lb_ErrMsg" runat="server" CssClass="TEXT_NOTE1"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <table width="96%" border="0" cellpadding="2" cellspacing="0" class="TB_DataList_TL">
                            <tr>
                                <td align="right" style="width: 80px;" class="TD_DataHead_TL_L">
                                    发行状态：
                                </td>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:DropDownList ID="cb_C0010102" runat="server">
                                        <asp:ListItem Value="1">创建</asp:ListItem>
                                        <asp:ListItem Value="2">开发</asp:ListItem>
                                        <asp:ListItem Value="3">内测</asp:ListItem>
                                        <asp:ListItem Value="4">公测</asp:ListItem>
                                        <asp:ListItem Value="5">候选</asp:ListItem>
                                        <asp:ListItem Value="6">发行</asp:ListItem>
                                        <asp:ListItem Value="7">历史</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RadioButtonList ID="rb_C0010102" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="0" Text="待定"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="一级类别"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="二级类别"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="三级类别"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 80px;" class="TD_DataHead_TL_L">
                                    软件名称：
                                </td>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:TextBox ID="tf_C0010106" runat="server" Width="240px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 80px;" class="TD_DataHead_TL_L">
                                    软件代码：
                                </td>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:DropDownList ID="cb_System" runat="server" OnSelectedIndexChanged="cb_System_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="cb_Module" runat="server" OnSelectedIndexChanged="cb_Module_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="tf_C0010104" runat="server" Columns="10" ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 80px;" class="TD_DataHead_TL_L">
                                    发行版本：
                                </td>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:TextBox ID="tf_C0010105" runat="server" Columns="12"></asp:TextBox><asp:CheckBox ID="ck_C0010105" runat="server" Text="更新" />
                                    <asp:HiddenField ID="hd_C0010105" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 80px;" class="TD_DataHead_TL_L">
                                    发布日期：
                                </td>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:TextBox ID="tf_C0010107" runat="server" Columns="12"></asp:TextBox><asp:CheckBox ID="ck_C0010107" runat="server" Text="今日" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 80px;" class="TD_DataHead_TL_L">
                                    概要介绍：
                                </td>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:TextBox ID="tf_C0010108" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 80px;" class="TD_DataHead_TL_L">
                                    软件图标：
                                </td>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:TextBox ID="tf_C0010109" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 80px;" class="TD_DataHead_TL_L">
                                    软件界面：
                                </td>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:TextBox ID="tf_C001010A" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 80px;" class="TD_DataHead_TL_L">
                                    软件首页：
                                </td>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:TextBox ID="tf_C001010B" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 80px;" class="TD_DataHead_TL_L">
                                    软件论坛：
                                </td>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:TextBox ID="tf_C001010C" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 80px;" class="TD_DataHead_TL_L">
                                    软件博客：
                                </td>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:TextBox ID="tf_C001010D" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 80px;" class="TD_DataHead_TL_L">
                                    项目首页：
                                </td>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:TextBox ID="tf_C001010E" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 80px;" class="TD_DataHead_TL_L">
                                    下载路径：
                                </td>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:TextBox ID="tf_C001010F" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 80px;" class="TD_DataHead_TL_L">
                                    在线使用：
                                </td>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:TextBox ID="tf_C0010110" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 80px;" class="TD_DataHead_TL_L">
                                    网页代码：
                                </td>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:TextBox ID="tf_C0010111" TextMode="multiLine" runat="server" Rows="6" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 80px;" class="TD_DataHead_TL_L">
                                    软件介绍：
                                </td>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:TextBox ID="ta_C0010112" TextMode="multiLine" runat="server" Rows="6" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 80px;" class="TD_DataHead_TL_L">
                                    更新列表：
                                </td>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:TextBox ID="ta_C0010113" TextMode="multiLine" runat="server" Rows="6" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 80px;" class="TD_DataHead_TL_L">
                                    相关说明：
                                </td>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:TextBox ID="ta_C0010114" TextMode="multiLine" runat="server" Rows="6" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 80px;" class="TD_DataHead_TL_L">
                                    更新日期：
                                </td>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:Label ID="lb_C0010115" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 80px;" class="TD_DataHead_TL_L">
                                    创建日期：
                                </td>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:Label ID="lb_C0010116" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 80px;" class="TD_DataHead_TL_L">
                                    身份校验：
                                </td>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <uc1:AmonAuth ID="aa_AmonAuth" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="height: 40px;">
                        <asp:Button ID="bt_SaveData" runat="server" Text="保存(S)" OnClick="bt_SaveData_Click" AccessKey="S" OnClientClick="return saveData();" />
                        <asp:HiddenField ID="hd_C0010103" runat="server" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
