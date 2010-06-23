<%@ Page Language="C#" MasterPageFile="~/exts/exts.master" AutoEventWireup="true" CodeFile="exts0091.aspx.cs" Inherits="exts_exts0091" %>

<%@ Register Src="~/App_Ascx/AmonAuth.ascx" TagName="AmonAuth" TagPrefix="as" %>
<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <asp:ScriptManager ID="sm_Script" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="up_Update" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
                <tr id="tr_StepGuid" runat="server" style="height: 20px;">
                    <td align="left">
                        【可选第一步】输入描述信息：
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <div class="DV_TEXT1">
                            &nbsp;您可以在此处添加或修改后缀的描述信息，改变语言选项，可以更新不同语言的描述信息。
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label ID="lb_ErrMsg" runat="server" CssClass="TEXT_NOTE1"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <table width="460" border="0" cellpadding="2" cellspacing="0" class="TB_DataList_TL" id="DESPPROP">
                            <tr>
                                <th style="width: 80px;" align="center" class="TD_DataHead_TL_L">
                                    语言选项
                                </th>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:DropDownList ID="cb_P3010502" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cb_P3010502_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:HiddenField ID="hd_P3010501" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <th style="width: 80px;" align="center" class="TD_DataHead_TL_L">
                                    描述信息
                                </th>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:TextBox ID="ta_P3010503" runat="server" Rows="4" TextMode="MultiLine" Width="260"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th style="width: 80px;" align="center" class="TD_DataHead_TL_L">
                                    附注信息
                                </th>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:TextBox ID="ta_P3010504" runat="server" Rows="4" TextMode="MultiLine" Width="260"></asp:TextBox>
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
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="left">
                                    <asp:Button ID="bt_Insert" runat="server" Text="添加(S)" AccessKey="S" OnClick="bt_Insert_Click" />
                                </td>
                                <td align="right">
                                    <asp:Button ID="bt_LastStep" runat="server" Text="上一步(P)" AccessKey="P" />
                                    <asp:Button ID="bt_NextStep" runat="server" Text="下一步(N)" AccessKey="N" OnClick="bt_NextStep_Click" />
                                    <asp:Button ID="bt_SaveData" runat="server" Text="完成(O)" AccessKey="O" OnClick="bt_SaveData_Click" />
                                    <asp:HiddenField ID="hd_NextStep" runat="server" />
                                    <asp:HiddenField ID="hd_IsUpdate" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
