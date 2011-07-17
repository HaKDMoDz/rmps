<%@ Page Language="C#" MasterPageFile="~/date/date.master" AutoEventWireup="true" CodeFile="date0002.aspx.cs" Inherits="date_date0002" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="460" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="center">
                            <asp:HiddenField ID="hd_P3100103" runat="server" />
                            <asp:HiddenField ID="hd_FlashObj" runat="server" />
                            <div id="dv_FlashObj">
                                <p>
                                    您尚未安装Adobe Flash Player，点击下面链接下载并安装：<br />
                                    <br />
                                    <a href="http://www.adobe.com/go/getflashplayer">
                                        <img src="http://www.adobe.com/images/shared/download_buttons/get_flash_player.gif" alt="Get Adobe Flash player" />
                                    </a>
                                </p>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            简介：
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;&nbsp;<asp:Label ID="lb_P3100108" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="30%" align="left">
                        </td>
                        <td align="center">
                            <asp:ImageButton ID="ib_P3100101" runat="server" ImageUrl="~/_images/1310Flwr.gif" ToolTip="点击送鲜花" OnClick="ib_P3100101_Click" />
                            鲜花：<asp:Label ID="lb_P3100101" runat="server" CssClass="TEXT_NOTE1">0</asp:Label>
                            &nbsp;
                            <asp:ImageButton ID="ib_P3100102" runat="server" ImageUrl="~/_images/1310Eggs.gif" ToolTip="点击扔鸡蛋" OnClick="ib_P3100102_Click" />
                            鸡蛋：<asp:Label ID="lb_P3100102" runat="server" CssClass="TEXT_NOTE1">0</asp:Label>
                        </td>
                        <td width="30%" align="right">
                            <a href="#" onclick="return openFull();">全屏查看</a>&nbsp;<asp:HyperLink ID="hl_MyIdea" runat="server" Text="发表留言"></asp:HyperLink>&nbsp;<asp:HyperLink ID="hl_Update" runat="server" Visible="false">更新</asp:HyperLink>&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
