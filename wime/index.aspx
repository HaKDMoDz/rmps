<%@ Page Language="C#" MasterPageFile="~/wime/wime.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="wime_index" Title="网页五笔" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="center">
                <table width="460" border="0" cellpadding="0" cellspacing="0" id="BODY_01">
                    <tr>
                        <td align="center">
                            <asp:Image ID="SoftView" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 40px;" align="right">
                            <a href="/wime/wime0001.aspx">在线使用</a> <a href="/wime/wime0002.aspx">获取代码</a>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 1px;" class="TD_LINE">
            </td>
        </tr>
        <tr>
            <td align="center">
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
            <td style="height: 20px;">
            </td>
        </tr>
        <tr>
            <td style="height: 1px;" class="TD_LINE">
            </td>
        </tr>
        <tr>
            <td align="center">
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
            <td style="height: 20px;">
            </td>
        </tr>
        <tr>
            <td style="height: 1px;" class="TD_LINE">
            </td>
        </tr>
        <tr>
            <td align="center">
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
                            作者：Amon<img height="1" alt="" src="" width="24" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
