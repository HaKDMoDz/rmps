<%@ Page Language="C#" MasterPageFile="~/exts/exts.master" AutoEventWireup="true" CodeFile="exts0403.aspx.cs" Inherits="exts_exts0403" ValidateRequest="false" %>

<%@ Register Src="~/App_Ascx/AmonAuth.ascx" TagName="AmonAuth" TagPrefix="uc1" %>
<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <asp:ScriptManager ID="sm_Script" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="up_Update" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="bt_P3010404" />
        </Triggers>
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
                                    <table width="100%" border="0" cellpadding="2" cellspacing="0" class="TB_DataList_TL" id="DOCSPROP">
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                格式文档
                                            </th>
                                            <td align="left" class="TD_DataItem_TL_L">
                                                <asp:HiddenField ID="hd_P3010402" runat="server" />
                                                <asp:FileUpload ID="fu_P3010404" runat="server" />
                                                <asp:Button ID="bt_P3010404" runat="server" OnClick="bt_P3010404_Click" Text="上传" />
                                                <asp:HiddenField ID="hd_P3010404" runat="server" />
                                                <asp:HiddenField ID="hd_TempHash" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                文档名称
                                            </th>
                                            <td align="left" class="TD_DataItem_TL_L">
                                                <asp:TextBox ID="tf_P3010405" runat="server" Columns="30"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                发行版本
                                            </th>
                                            <td align="left" class="TD_DataItem_TL_L">
                                                <asp:TextBox ID="tf_P3010406" runat="server" Columns="30"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                发行日期
                                            </th>
                                            <td align="left" class="TD_DataItem_TL_L">
                                                <asp:TextBox ID="tf_P3010407" runat="server" Columns="30"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                文档摘要
                                            </th>
                                            <td align="left" class="TD_DataItem_TL_L">
                                                <asp:TextBox ID="ta_P3010408" runat="server" Rows="4" TextMode="MultiLine" Width="90%"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                附注信息
                                            </th>
                                            <td align="left" class="TD_DataItem_TL_L">
                                                <asp:TextBox ID="ta_P3010409" runat="server" Rows="4" TextMode="MultiLine" Width="90%"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                身份校验
                                            </th>
                                            <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                <uc1:AmonAuth ID="aa_AmonAuth" runat="server" />
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
                        <asp:HiddenField ID="hd_P301040B" runat="server" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
