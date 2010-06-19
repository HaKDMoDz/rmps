<%@ Page Language="C#" AutoEventWireup="true" CodeFile="icon0101.aspx.cs" Inherits="icon_icon0101" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%=cons.wrp.WrpCons.TITLE_ICON%>
    </title>
    <%=cons.wrp.WrpCons.KEYWORDS_ICON%>
    <%=cons.wrp.WrpCons.DESCRIPTION_ICON%>
    <%=rmp.wrp.Wrps.ComnHead(cons.wrp.WrpCons.MODULE_ICON)%>
    <%= rmp.wrp.Wrps.GetScript(cons.wrp.WrpCons.MODULE_SYNC) %>
</head>
<body>
    <form id="form1" runat="server">
        <table border="0" cellpadding="5" cellspacing="0" width="100%">
            <tr>
                <td align="center" class="TD_DataHead_TL_L">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="left">
                                大小(D)：
                                <asp:DropDownList ID="cb_ImgScale" runat="server" AccessKey="D">
                                    <asp:ListItem Value="-1">默认大小</asp:ListItem>
                                    <asp:ListItem Value="0">指定大小</asp:ListItem>
                                    <asp:ListItem Value="16">16 * 16</asp:ListItem>
                                    <asp:ListItem Value="24">24 * 24</asp:ListItem>
                                    <asp:ListItem Value="32">32 * 32</asp:ListItem>
                                    <asp:ListItem Value="48" Selected="true">48 * 48</asp:ListItem>
                                    <asp:ListItem Value="64">64 * 64</asp:ListItem>
                                    <asp:ListItem Value="96">96 * 96</asp:ListItem>
                                    <asp:ListItem Value="128">128 * 128</asp:ListItem>
                                    <asp:ListItem Value="256">256 * 256</asp:ListItem>
                                </asp:DropDownList>
                                宽(W)：<input type="text" id="tf_ImgWidth" runat="server" accesskey="W" size="5" value="48" style="text-align: right;" readonly="readonly" />
                                高(H)：<input type="text" id="tf_ImgHight" runat="server" accesskey="H" size="5" value="48" style="text-align: right;" readonly="readonly" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                缩放&nbsp;&nbsp;&nbsp;：
                                <asp:CheckBox ID="ck_ImgScale" runat="server" Checked="true" AccessKey="T" Text="缩放图像(T)" ToolTip="缩放图像以适应大小" />
                                <asp:CheckBox ID="ck_ImgRatio" runat="server" Checked="true" AccessKey="M" Text="保持比例(M)" ToolTip="保持图像宽高比例" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                文件(F)：
                                <asp:FileUpload ID="fu_FileUpld" runat="server" AccessKey="F" />
                                <asp:Button ID="bt_FileUpld" runat="server" Text="上传(U)" AccessKey="U" OnClick="bt_FileUpld_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="lb_ErrMsg" runat="server" CssClass="TEXT_NOTE1"></asp:Label>&nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" class="TD_DataItem_TL_L">
                    <div style="width: 100%; overflow: scroll;">
                        <asp:HiddenField ID="hd_DeltFile" runat="server" />
                        <table border="0" cellpadding="3" cellspacing="0" width="100%">
                            <tr>
                                <% 
                                    foreach (String img in iconList)
                                    { 
                                %>
                                <td align="center">
                                    <img src="<%= DIR_PATH + img %>" alt="" />
                                </td>
                                <% 
                                    }
                                %>
                            </tr>
                            <tr>
                                <% 
                                    foreach (String img in iconList)
                                    {
                                        lb_DeltFile.OnClientClick = "$X('hd_DeltFile').value = '" + img + "';";
                                %>
                                <td align="center">
                                    <asp:LinkButton ID="lb_DeltFile" runat="server" OnClick="lb_DeltFile_Click">删除</asp:LinkButton>
                                </td>
                                <% 
                                    }
                                %>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <th align="left" class="TD_DataHead_TL_L" style="height: 30px;">
                    &nbsp;
                </th>
            </tr>
            <tr>
                <td align="right">
                    <asp:HiddenField ID="hd_IconHash" runat="server" />
                    <input id="ck_Append" type="checkbox" checked="checked" accesskey="A" title="追加所选择的图片" />追加(A)
                    <input id="bt_Select" type="button" value="选择(S)" accesskey="S" onclick="chooseImage();" />
                    <input id="bt_Return" type="button" value="返回(R)" accesskey="S" onclick="returnHome();" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

<script type="text/javascript" src="icon0101.js"></script>