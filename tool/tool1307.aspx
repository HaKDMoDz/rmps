<%@ Page Language="C#" MasterPageFile="~/tool/tool.master" AutoEventWireup="true" CodeFile="tool1307.aspx.cs" Inherits="tool_tool1307" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="460" border="0" cellpadding="3" cellspacing="0" class="TB_DataList_TL">
                    <tr>
                        <td style="width: 20%;" class="TD_DataHead_TL_L" align="center">
                            链接类别
                        </td>
                        <td style="width: 80%;" class="TD_DataItem_TL_L" align="left">
                            <input id="tf_P3070A05" runat="server" type="text" style="width: 280px; cursor: pointer;" readonly="readonly" onclick="return checkType();" />
                            <asp:ImageButton ID="im_P3070A05" runat="server" ImageUrl="~/_images/srch.png" ImageAlign="middle" ToolTip="选择链接类别" Width="16" Height="16" OnClientClick="return checkType();" />
                            <div id="dv_P3070104" style="position: absolute; z-index: 1; width: 284px; height: 200px; background-color: #FFFFFF; border: solid 1px #E0E0E0; overflow: auto; display: none;">
                                <asp:TreeView ID="tv_P3070A05" runat="server" ImageSet="Arrows" ShowCheckBoxes="All" Width="100%" Height="99%">
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
                            从属网站
                        </td>
                        <td style="width: 80%;" class="TD_DataItem_TL_L" align="left">
                            <input id="tf_P3070104" type="text" style="width: 280px;" />
                            <asp:ImageButton ID="im_P3070104" runat="server" ImageUrl="~/_images/srch.png" ImageAlign="middle" ToolTip="查找下一个匹配网站" Width="16" Height="16" OnClientClick="return checkPort();" />
                            <br />
                            <asp:DropDownList ID="cb_P3070104" runat="server" Width="200">
                            </asp:DropDownList>
                            <asp:CheckBox ID="ck_P3070104" runat="server" Text="使用相同徽标" Checked="true" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%;" class="TD_DataHead_TL_L" align="center">
                            链接名称
                        </td>
                        <td style="width: 80%;" class="TD_DataItem_TL_L" align="left">
                            <asp:TextBox ID="tf_P3070107" runat="server" Width="280"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td style="width: 20%;" class="TD_DataHead_TL_L" align="center">
                            网站标题
                        </td>
                        <td style="width: 80%;" class="TD_DataItem_TL_L" align="left">
                            <asp:TextBox ID="tf_P3070108" runat="server" Width="280"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%;" class="TD_DataHead_TL_L" align="center">
                            链接路径
                        </td>
                        <td style="width: 80%;" class="TD_DataItem_TL_L" align="left">
                            <asp:TextBox ID="tf_P3070109" runat="server" Width="280"></asp:TextBox>
                            <asp:ImageButton ID="im_P3070109" runat="server" ImageUrl="~/_images/srch.png" ImageAlign="middle" ToolTip="自动查找网站LOGO" Width="16" Height="16" OnClick="im_P3070109_Click" OnClientClick="return checkLink();" Style="display: none;" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%;" class="TD_DataHead_TL_L" align="center">
                            网站LOGO
                        </td>
                        <td style="width: 80%;" class="TD_DataItem_TL_L" align="left">
                            <asp:Image ID="im_P3070106" runat="server" ImageUrl="link/0.png" ImageAlign="middle" Width="16" Height="16" />
                            <asp:FileUpload ID="fu_P3070106" runat="server" Style="display: none;" />
                            <asp:Button ID="bt_P3070106" runat="server" Text="上传(U)" AccessKey="U" OnClick="bt_P3070106_Click" Style="display: none;" />
                            <asp:HiddenField ID="hd_P3070106" runat="server" Value="0" />
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td style="width: 20%;" class="TD_DataHead_TL_L" align="center">
                            关键搜索
                        </td>
                        <td style="width: 80%;" class="TD_DataItem_TL_L" align="left">
                            <asp:TextBox ID="tf_P307010A" runat="server" Width="280"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td style="width: 20%;" class="TD_DataHead_TL_L" align="center">
                            网站描述
                        </td>
                        <td style="width: 80%;" class="TD_DataItem_TL_L" align="left">
                            <asp:TextBox ID="ta_P307010B" runat="server" TextMode="MultiLine" Columns="44" Rows="6"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%;" class="TD_DataHead_TL_L" align="center">
                            相关说明
                        </td>
                        <td style="width: 80%;" class="TD_DataItem_TL_L" align="left">
                            <asp:TextBox ID="ta_P307010C" runat="server" TextMode="MultiLine" Columns="44" Rows="6"></asp:TextBox>
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
                <input type="button" value="关闭(R)" accesskey="R" onclick="histBack();" />
                <asp:HiddenField ID="hd_P3070105" runat="server" />
                <asp:HiddenField ID="hd_IsUpdate" runat="server" />
                <asp:HiddenField ID="hd_HistBack" runat="server" Value="/link/link0101.aspx" />
            </td>
        </tr>
    </table>
</asp:Content>
