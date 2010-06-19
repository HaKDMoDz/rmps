<%@ Page Language="C#" MasterPageFile="~/link/link.master" AutoEventWireup="true" CodeFile="link0203.aspx.cs" Inherits="link_link0203" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="center">
                <table width="460" border="0" cellpadding="3" cellspacing="0" class="TB_DataList_TL">
                    <tr>
                        <td style="width: 20%;" class="TD_DataHead_TL_L" align="center">
                            上级类别
                        </td>
                        <td style="width: 80%;" class="TD_DataItem_TL_L" align="left">
                            <input id="tf_P3070A04" runat="server" type="text" value="--请选择--" style="width: 280px; cursor: pointer;" readonly="readonly" onclick="return checkType();" />
                            <asp:ImageButton ID="im_P3070A04" runat="server" ImageUrl="~/_images/srch.png" ImageAlign="middle" ToolTip="选择链接类别" Width="16" Height="16" OnClientClick="return checkType();" />
                            <div id="dv_P3070A04" style="position: absolute; z-index: 1; width: 284px; height: 200px; background-color: #FFFFFF; border: solid 1px #E0E0E0; overflow: auto; display: none;">
                                <asp:TreeView ID="tv_P3070A04" runat="server" ImageSet="Arrows" ShowCheckBoxes="All" Width="100%" Height="99%">
                                    <ParentNodeStyle Font-Bold="False" />
                                    <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                                    <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px" />
                                    <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
                                </asp:TreeView>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%;" class="TD_DataHead_TL_L" align="center">
                            类别名称
                        </td>
                        <td style="width: 80%;" class="TD_DataItem_TL_L" align="left">
                            <asp:TextBox ID="tf_P3070A06" runat="server" Width="280"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%;" class="TD_DataHead_TL_L" align="center">
                            相关说明
                        </td>
                        <td style="width: 80%;" class="TD_DataItem_TL_L" align="left">
                            <asp:TextBox ID="ta_P3070A07" runat="server" TextMode="MultiLine" Columns="44" Rows="6"></asp:TextBox>
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
            <td align="center">
                <asp:Button ID="bt_SaveData" runat="server" Text="保存(S)" AccessKey="S" OnClick="bt_SaveData_Click" OnClientClick="return checkNull();" />
                <input type="button" value="返回(R)" accesskey="R" onclick="histBack();" />
                <asp:HiddenField ID="hd_P3070A05" runat="server" />
                <asp:HiddenField ID="hd_IsUpdate" runat="server" />
                <asp:HiddenField ID="hd_HistBack" runat="server" Value="/link/link0201.aspx" />
            </td>
        </tr>
    </table>
</asp:Content>
