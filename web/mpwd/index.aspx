<%@ Page Language="C#" MasterPageFile="~/mpwd/mpwd.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="mpwd_index" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td align="right" style="height: 20px; width: 80px;">
                最新版本：
            </td>
            <td align="left" style="height: 20px;">
                <asp:Label ID="lb_SoftVers" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 20px;">
                更新日期：
            </td>
            <td align="left" style="height: 20px;">
                <asp:Label ID="lb_PubsTime" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 20px;">
                运行平台：
            </td>
            <td align="left" style="height: 20px;">
                跨平台运行
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 20px;">
                环境需求：
            </td>
            <td align="left" style="height: 20px;">
                JavaSE 1.6及以上版本
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 20px;">
                界面截图：
            </td>
            <td align="left" style="height: 20px;">
                <asp:HyperLink ID="hl_Win" runat="server">Windows</asp:HyperLink>&nbsp;&nbsp;<asp:HyperLink ID="hl_Lin" runat="server">Linux</asp:HyperLink>&nbsp;&nbsp;<asp:HyperLink ID="hl_Sub" runat="server">Java</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 20px;">
                软件下载：
            </td>
            <td align="left" style="height: 20px;">
				<table border="0" style="width: 100%;">
					<tr>
						<td>
							平台无关版本
						</td>
					</tr>
					<tr>
						<td>
							<asp:HyperLink ID="hl_DownZip" runat="server" ToolTip="平台无关版本"><img src="/icon/icon0001.ashx?sid=comn,_ALL&uri=32" /></asp:HyperLink>&nbsp;
						</td>
					</tr>
					<tr>
						<td>
							含JRE版本
						</td>
					</tr>
					<tr>
						<td>
							<asp:HyperLink ID="hl_DownWinJ" runat="server" ToolTip="Windows 版本"><img src="/icon/icon0001.ashx?sid=comn,_WIN&uri=32" /></asp:HyperLink>&nbsp;
							<asp:HyperLink ID="hl_DownLnxJ" runat="server" ToolTip="Linux 版本"><img src="/icon/icon0001.ashx?sid=comn,_LNX&uri=32" /></asp:HyperLink>
						</td>
					</tr>
					<tr>
						<td>
							无JRE版本
						</td>
					</tr>
					<tr>
						<td>
							<asp:HyperLink ID="hl_DownWinN" runat="server" ToolTip="Windows 版本"><img src="/icon/icon0001.ashx?sid=comn,_WIN&uri=32" /></asp:HyperLink>&nbsp;
							<asp:HyperLink ID="hl_DownLnxN" runat="server" ToolTip="Linux 版本"><img src="/icon/icon0001.ashx?sid=comn,_LNX&uri=32" /></asp:HyperLink>
						</td>
					</tr>
				</table>
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 20px;">
                在线使用：
            </td>
            <td align="left" style="height: 20px;">
                <asp:HyperLink ID="hl_SoftJnlp" runat="server"><img src="../_images/jnlp.png" alt="在线使用" /></asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 20px;">
                协作开发：
            </td>
            <td align="left" style="height: 20px;">
                <a href="http://code.google.com/p/magicpwd/" target="_blank">项目首页</a>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="TD_LINE_B">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <table id="BODY_02" cellspacing="0" cellpadding="0" width="460" border="0">
                    <tr>
                        <td align="left" style="height: 40px;">
                            <span class="TEXT_HEAD2">软件介绍：</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Literal ID="SoftInfo" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="TD_LINE_B">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <table id="BODY_03" cellspacing="0" cellpadding="0" width="460" border="0">
                    <tr>
                        <td align="left" style="height: 40px;">
                            <span class="TEXT_HEAD2">软件升级：</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            ■<asp:Literal ID="PubsTime" runat="server"></asp:Literal>：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Literal ID="SoftVers" runat="server"></asp:Literal><br />
                            <asp:Literal ID="BugList" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="TD_LINE_B">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table id="BODY_04" cellspacing="0" cellpadding="0" width="460" border="0">
                    <tr>
                        <td align="left" style="height: 40px;">
                            <span class="TEXT_HEAD2">致谢：</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;&nbsp;&nbsp;&nbsp;衷心感谢各位网友对Amon软件的关注与支持，您的意见与建议就是对Amon最大的鼓励与回报，也使Amon系列软件得以发展与完善，能够更好的为更多的用户提供更加方便的服务。<br />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;如果您喜欢Amon系列软件，请介绍给您的朋友；如果您有什么宝贵的意见或建议，欢迎与作者联系！<br />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;感谢您使用Amon系列软件！<br />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            作者：Amon<img style="height: 1px;" alt="" src="" width="24" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
