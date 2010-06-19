<%@ Page Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeFile="user0002.aspx.cs" Inherits="user_user0002" %>

<%@ Register Src="~/App_Ascx/AmonIcon.ascx" TagName="AmonIcon" TagPrefix="as" %>
<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <asp:ScriptManager ID="sm_Script" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="up_Update" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
                <tr>
                    <td align="center">
                        <asp:Label ID="lb_ErrMsg" runat="server" CssClass="TEXT_NOTE1"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <table width="460" border="0" cellpadding="2" cellspacing="0" class="TB_EXTSINFO" id="TB_EXTSINFO">
                            <tr>
                                <td align="center">
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="TB_DataList_TL" id="IDIOPROP">
                                        <tr>
                                            <td style="height: 80px;" rowspan="2" align="center" class="TD_DataHead_TL_L">
                                                <as:AmonIcon ID="ai_C3010408" runat="server" DstIconPath="idio" ToolTip="个性图标" Enabled="true" CreateDiv="true" />
                                            </td>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                邮&nbsp;&nbsp;&nbsp;&nbsp;件
                                            </th>
                                            <td align="left" class="TD_DataItem_TL_L">
                                                <asp:TextBox ID="tf_C3010406" runat="server" Columns="30"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                昵&nbsp;&nbsp;&nbsp;&nbsp;称
                                            </th>
                                            <td align="left" class="TD_DataItem_TL_L">
                                                <asp:TextBox ID="tf_C3010407" runat="server" Columns="30"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                签&nbsp;&nbsp;&nbsp;&nbsp;名
                                            </th>
                                            <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                <asp:TextBox ID="tf_C3010409" runat="server" Columns="30"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                心&nbsp;&nbsp;&nbsp;&nbsp;情
                                            </th>
                                            <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                <asp:TextBox ID="ta_C301040A" runat="server" Rows="4" TextMode="MultiLine" Width="90%"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Button ID="bt_Update" runat="server" OnClick="bt_Update_Click" Text="保存(S)" AccessKey="S" OnClientClick="return checkNull();" />
                        <asp:HiddenField ID="hd_NextStep" runat="server" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
