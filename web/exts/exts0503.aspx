<%@ Page Language="C#" MasterPageFile="~/exts/exts.master" AutoEventWireup="true" CodeFile="exts0503.aspx.cs" Inherits="exts_exts0503" ValidateRequest="false" %>

<%@ Register Src="~/App_Ascx/AmonAuth.ascx" TagName="AmonAuth" TagPrefix="as" %>
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
                                    <table width="100%" border="0" cellpadding="2" cellspacing="0" class="TB_DataList_TL" id="CORPPROP">
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                语言选项
                                            </th>
                                            <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                <asp:HiddenField ID="hd_P301F102" runat="server" />
                                                <asp:HiddenField ID="hd_P301F109" runat="server" />
                                                <asp:DropDownList ID="cb_P301F103" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cb_P301F103_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                MIME名称
                                            </th>
                                            <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                <asp:TextBox ID="tf_P301F104" runat="server" Columns="30"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                MIME简介
                                            </th>
                                            <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                <asp:TextBox ID="ta_P301F105" runat="server" Rows="4" TextMode="MultiLine" Width="90%"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                附注信息
                                            </th>
                                            <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                <asp:TextBox ID="ta_P301F106" runat="server" Rows="4" TextMode="MultiLine" Width="90%"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                身份校验
                                            </th>
                                            <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                <as:AmonAuth ID="aa_AmonAuth" runat="server" />
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
                        <asp:HiddenField ID="hd_P301F108" runat="server" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
