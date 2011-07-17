<%@ Page Language="C#" MasterPageFile="~/iask/iask.master" AutoEventWireup="true" CodeFile="iask13A3.aspx.cs" Inherits="iask_iask13A3" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                省份：<asp:DropDownList ID="cb_ProvList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cb_ProvList_SelectedIndexChanged">
                </asp:DropDownList>
                城市：<asp:DropDownList ID="cb_CityList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cb_CityList_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td height="1" class="TD_LINE">
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr id="tr_Guid" runat="server" visible="false">
            <td align="right" height="18">
                <asp:LinkButton ID="lb_Mini" runat="server" Visible="false" OnClick="lb_Mini_Click">精简</asp:LinkButton>
                <asp:LinkButton ID="lb_Full" runat="server" Visible="true" OnClick="lb_Full_Click">更多</asp:LinkButton>&nbsp;
            </td>
        </tr>
        <tr id="tr_Mini" runat="server" visible="false">
            <td align="center">
                <table border="0" cellpadding="3" cellspacing="0" width="96%" class="TB_DataList_TL">
                    <tr>
                        <td align="center" rowspan="3" width="100" class="TD_DataItem_TL_L">
                            <asp:HyperLink ID="hl_T00" ToolTip="点击查看大图" runat="server">
                                <asp:Image ID="im_T00" Width="100" Height="70" runat="server" />
                            </asp:HyperLink>
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_T00" runat="server"></asp:Label>
                        </td>
                        <td align="center" rowspan="2" width="70" class="TD_DataItem_TL_L">
                            <asp:Image ID="im_T01" runat="server" />&nbsp;&nbsp;<asp:Image ID="im_T02" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_T05" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_T07" runat="server"></asp:Label>
                        </td>
                        <td align="center" width="70" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_T06" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" rowspan="3" width="100" class="TD_DataItem_TL_L">
                            <asp:LinkButton ID="lb_24" runat="server" OnClick="lb_24_Click">24小时</asp:LinkButton><br />
                            <asp:LinkButton ID="lb_48" runat="server" OnClick="lb_48_Click">48小时</asp:LinkButton><br />
                            <asp:LinkButton ID="lb_72" runat="server" OnClick="lb_72_Click">72小时</asp:LinkButton></td>
                        <td align="left" colspan="2" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_T11" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_T12" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_T13" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="tr_Full" runat="server" visible="false">
            <td align="center">
                <table border="0" cellpadding="3" cellspacing="0" width="96%" class="TB_DataList_TL">
                    <tr>
                        <td rowspan="3" width="8%" align="center" class="TD_DataHead_TL_L">
                            概况
                        </td>
                        <td width="20%" align="center" class="TD_DataHead_TL_L">
                            省份
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_W00" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" align="center" class="TD_DataHead_TL_L">
                            城市
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_W01" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" align="center" class="TD_DataHead_TL_L">
                            最后更新时间
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_W02" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="1" width="8%" align="center" class="TD_DataHead_TL_L">
                            &nbsp;
                        </td>
                        <td width="20%" align="center" class="TD_DataHead_TL_L">
                            &nbsp;
                        </td>
                        <td align="left" class="TD_DataHead_TL_L">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="6" width="8%" align="center" class="TD_DataHead_TL_L">
                            今日
                        </td>
                        <td width="20%" align="center" class="TD_DataHead_TL_L">
                            气温
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_W05" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" align="center" class="TD_DataHead_TL_L">
                            概况
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_W06" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" align="center" class="TD_DataHead_TL_L">
                            风向和风力
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_W07" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" align="center" class="TD_DataHead_TL_L">
                            天气趋势
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:Image ID="im_W08" runat="server" />
                            <asp:Image ID="im_W09" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" align="center" class="TD_DataHead_TL_L">
                            天气实况
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_W10" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" align="center" class="TD_DataHead_TL_L">
                            天气和生活指数
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_W11" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="1" width="8%" align="center" class="TD_DataHead_TL_L">
                            &nbsp;
                        </td>
                        <td width="20%" align="center" class="TD_DataHead_TL_L">
                            &nbsp;
                        </td>
                        <td align="left" class="TD_DataHead_TL_L">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="4" width="8%" align="center" class="TD_DataHead_TL_L">
                            明日
                        </td>
                        <td width="20%" align="center" class="TD_DataHead_TL_L">
                            气温
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_W12" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" align="center" class="TD_DataHead_TL_L">
                            概况
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_W13" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" align="center" class="TD_DataHead_TL_L">
                            风向和风力
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_W14" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" align="center" class="TD_DataHead_TL_L">
                            天气趋势
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:Image ID="im_W15" runat="server" />
                            <asp:Image ID="im_W16" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="1" width="8%" align="center" class="TD_DataHead_TL_L">
                            &nbsp;
                        </td>
                        <td width="20%" align="center" class="TD_DataHead_TL_L">
                            &nbsp;
                        </td>
                        <td align="left" class="TD_DataHead_TL_L">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="4" width="8%" align="center" class="TD_DataHead_TL_L">
                            后日
                        </td>
                        <td width="20%" align="center" class="TD_DataHead_TL_L">
                            气温
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_W17" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" align="center" class="TD_DataHead_TL_L">
                            概况
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_W18" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" align="center" class="TD_DataHead_TL_L">
                            风向和风力
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_W19" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" align="center" class="TD_DataHead_TL_L">
                            天气趋势
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:Image ID="im_W20" runat="server" />
                            <asp:Image ID="im_W21" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td width="8%" align="center" class="TD_DataHead_TL_L">
                            &nbsp;
                        </td>
                        <td width="20%" align="center" class="TD_DataHead_TL_L">
                            &nbsp;
                        </td>
                        <td align="left" class="TD_DataHead_TL_L">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="2" align="center" class="TD_DataHead_TL_L" width="8%">
                            简介
                        </td>
                        <td align="center" width="20%" class="TD_DataHead_TL_L">
                            图片
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:HyperLink ID="hl_W00" ToolTip="点击查看大图" runat="server">
                                <asp:Image ID="im_W00" Width="148" Height="100" runat="server" />
                            </asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="TD_DataHead_TL_L" width="20%">
                            说明
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:Literal ID="lt_W22" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
