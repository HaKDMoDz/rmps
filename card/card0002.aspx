<%@ Page Language="C#" MasterPageFile="~/card/card.master" AutoEventWireup="true" CodeFile="card0002.aspx.cs" Inherits="card_card0002" EnableEventValidation="false" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <asp:ScriptManager ID="sm_Manager" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="up_Script" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" id="Table1">
                <tr id="tr_CardNote" runat="server">
                    <td align="center" class="TEXT_NOTE1">
                        您需要<a href="/user/user0001.aspx" title="用户登录">登录</a>后才能保存对卡片所做的修改！<br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <table border="0" cellspacing="2" cellpadding="0" width="400">
                            <tr>
                                <td align="right" style="width: 80px;">
                                    卡片名称：
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="tf_CardName" runat="server" Width="260"></asp:TextBox>
                                    <asp:HiddenField ID="hd_CardData" runat="server" />
                                    <asp:HiddenField ID="hd_SID" runat="server" />
                                    <asp:HiddenField ID="hd_URI" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    卡片背景：
                                </td>
                                <td align="left">
                                    <asp:FileUpload ID="fu_CardIcon" runat="server" Style="width: 170px;" />
                                    <asp:Button ID="bt_CardIcon" runat="server" Text="上传(U)" AccessKey="U" OnClick="bt_CardIcon_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    卡片说明：
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="ta_CardDesp" runat="server" TextMode="multiLine" Rows="3" Width="260"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <table border="0" cellspacing="0" cellpadding="0" width="400">
                            <tr>
                                <td colspan="2" align="center">
                                    <div id="dv_FavCard" runat="server" style="width: 400px; height: 300px; background-color: #FCFCFC; position: relative; overflow: hidden;">
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px;">
                                    &nbsp;
                                </td>
                                <td style="width: 300px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top" rowspan="3">
                                    <asp:ListBox ID="cb_FavList" runat="server" Width="96%" Rows="13"></asp:ListBox>
                                    <br />
                                    <input type="button" id="bt_DelItem" value="删除(D)" accesskey="D" onclick="delItem();" />
                                </td>
                                <td align="left">
                                    &nbsp;&nbsp;&nbsp;&nbsp;选项：
                                    <asp:DropDownList ID="cb_SysList" runat="server" Width="140">
                                    </asp:DropDownList>
                                    <input type="button" id="bt_FavItem" value="添加(A)" accesskey="A" onclick="newItem();" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top">
                                    <fieldset style="width: 96%;">
                                        <legend>属性</legend>
                                        <table border="0" cellspacing="0" cellpadding="1" width="96%">
                                            <tr>
                                                <td align="right" style="width: 50px;">
                                                    标题：
                                                </td>
                                                <td align="left">
                                                    <input type="text" id="pp_title" style="width: 70px;" onblur="chgHead(this)" />
                                                </td>
                                                <td align="right" style="width: 50px;">
                                                    文本1：
                                                </td>
                                                <td align="left">
                                                    <input type="text" id="pp_text1" style="width: 70px;" onblur="chgHead(this)" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    文本2：
                                                </td>
                                                <td align="left">
                                                    <input type="text" id="pp_text2" style="width: 70px;" onblur="chgHead(this)" />
                                                </td>
                                                <td align="right">
                                                    文本3：
                                                </td>
                                                <td align="left">
                                                    <input type="text" id="pp_text3" style="width: 70px;" onblur="chgHead(this)" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    字体：
                                                </td>
                                                <td align="left" colspan="3">
                                                    <asp:DropDownList ID="pp_family" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    大小：
                                                </td>
                                                <td align="left">
                                                    <input type="text" id="pp_size" style="width: 70px;" onblur="chgProp('size',this.value,'fontSize','px');" />
                                                </td>
                                                <td align="right">
                                                    颜色：
                                                </td>
                                                <td align="left">
                                                    <input type="text" id="pp_color" style="width: 70px;" onblur="chgClor(this)" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    风格：
                                                </td>
                                                <td align="left" colspan="3">
                                                    <label>
                                                        <input type="checkbox" id="pp_bold" onclick="chgFont('bold',this.checked,'fontWeight','bold','normal');" />粗体
                                                    </label>
                                                    <label>
                                                        <input type="checkbox" id="pp_itac" onclick="chgFont('itac',this.checked,'fontStyle','italic','normal');" />斜体
                                                    </label>
                                                    <label>
                                                        <input type="checkbox" id="pp_strk" onclick="chgFont('strk',this.checked,'textDecoration','line-through','none');" />删除线
                                                    </label>
                                                    <label>
                                                        <input type="checkbox" id="pp_line" onclick="chgLine(this);" />下划线
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    位置：
                                                </td>
                                                <td align="left" colspan="3">
                                                    <table border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td rowspan="2">
                                                                水平(px)
                                                            </td>
                                                            <td rowspan="2">
                                                                <input id="pp_xpos" type="text" size="4" onblur="chgStep('xpos',0,'left');" />
                                                            </td>
                                                            <td>
                                                                <img alt="" src="/_images/4204arru.gif" width="8" height="8" style="cursor: pointer;" title="增加1像素" onclick="chgStep('xpos',1,'left');" />
                                                            </td>
                                                            <td rowspan="2">
                                                                垂直(px)
                                                            </td>
                                                            <td rowspan="2">
                                                                <input id="pp_ypos" type="text" size="4" onblur="chgStep('ypos',0,'top');" />
                                                            </td>
                                                            <td>
                                                                <img alt="" src="/_images/4204arru.gif" width="8" height="8" style="cursor: pointer;" title="增加1像素" onclick="chgStep('ypos',1,'top');" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <img alt="" src="/_images/4204arrd.gif" width="8" height="8" style="cursor: pointer;" title="减少1像素" onclick="chgStep('xpos',-1,'left');" />
                                                            </td>
                                                            <td>
                                                                <img alt="" src="/_images/4204arrd.gif" width="8" height="8" style="cursor: pointer;" title="减少1像素" onclick="chgStep('ypos',-1,'top');" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
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
                        <asp:Button ID="bt_SaveData" runat="server" Text="保存卡片" OnClick="bt_SaveData_Click" OnClientClick="return checkNull();" />
                        <input type="button" value="获取代码" onclick="window.location.href='card0001.aspx?sid='+$E('hd_SID').value;" />
                        <input type="button" value="新增卡片" onclick="window.location.href='card0002.aspx'" />
                    </td>
                </tr>
            </table>
            <div id="dv_Script" runat="server" style="display: none;">
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
