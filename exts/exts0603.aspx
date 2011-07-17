<%@ Page Language="C#" MasterPageFile="~/exts/exts.master" AutoEventWireup="true" CodeFile="exts0603.aspx.cs" Inherits="exts_exts0603" ValidateRequest="false" %>

<%@ Register Src="~/App_Ascx/AmonAuth.ascx" TagName="AmonAuth" TagPrefix="uc1" %>
<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <asp:ScriptManager ID="sm_Script" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="up_Update" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="bt_P301F208" />
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
                                    <table width="100%" border="0" cellpadding="2" cellspacing="0" class="TB_DataList_TL" id="CORPPROP">
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                语言选项
                                            </th>
                                            <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                <asp:HiddenField ID="hd_P301F203" runat="server" />
                                                <asp:DropDownList ID="cb_P301F204" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cb_P301F204_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:HiddenField ID="hd_P301F20E" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                平台家族
                                            </th>
                                            <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                <asp:DropDownList ID="cb_P301F202" runat="server">
                                                    <asp:ListItem Value="0">未知</asp:ListItem>
                                                    <asp:ListItem Value="4194304">Windows</asp:ListItem>
                                                    <asp:ListItem Value="8388608">Unix</asp:ListItem>
                                                    <asp:ListItem Value="1048576">Linux</asp:ListItem>
                                                    <asp:ListItem Value="2097152">Macintosh</asp:ListItem>
                                                    <asp:ListItem Value="262144">移动平台</asp:ListItem>
                                                    <asp:ListItem Value="524288">其它</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                平台名称
                                            </th>
                                            <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                <asp:TextBox ID="tf_P301F206" runat="server" Columns="30"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                运行截图
                                            </th>
                                            <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                <asp:FileUpload ID="fu_P301F208" runat="server" />
                                                <asp:Button ID="bt_P301F208" runat="server" Text="上传(U)" AccessKey="U" OnClick="bt_P301F208_Click" />
                                                <asp:HiddenField ID="hd_P301F208" runat="server" />
                                                <asp:HiddenField ID="hd_TempHash" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                平台首页
                                            </th>
                                            <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                <asp:TextBox ID="tf_P301F209" runat="server"></asp:TextBox><input id="bt_P301F209" type="button" value="查看(V)" accesskey="V" onclick="viewLink()" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                平台说明
                                            </th>
                                            <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                <asp:TextBox ID="ta_P301F20A" runat="server" Rows="5" TextMode="MultiLine" Width="90%"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                附注信息
                                            </th>
                                            <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                <asp:TextBox ID="ta_P301F20B" runat="server" Rows="5" TextMode="MultiLine" Width="90%"></asp:TextBox>
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
                        <asp:HiddenField ID="hd_NextStep" runat="server" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
