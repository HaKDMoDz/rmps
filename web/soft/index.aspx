<%@ Page Language="C#" MasterPageFile="~/soft/soft.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="soft_index" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="center">
                <table width="460" border="0" cellpadding="3" cellspacing="0" id="TB_04">
                    <asp:Repeater ID="SoftList" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td width="12%" align="center">
                                    <img src="<%#Eval(cons.io.db.comn.ComnCons.C0010109)%>" alt="<%#Eval(cons.io.db.comn.ComnCons.C0010106)%>" width="32" height="32" />
                                </td>
                                <td width="23%" align="left" bgcolor="#F8F8F8">
                                    <a href="soft0001.aspx?sid=<%#Eval(cons.io.db.comn.ComnCons.C0010104)%>">
                                        <%#Eval(cons.io.db.comn.ComnCons.C0010106)%>
                                        <br />
                                        <%#Eval(cons.io.db.comn.ComnCons.C0010105)%>
                                    </a>
                                </td>
                                <td width="50%" align="left" bgcolor="#F8F8F8">
                                    <%#Eval(cons.io.db.comn.ComnCons.C0010108)%>
                                </td>
                                <td width="15%" align="center" bgcolor="#F8F8F8">
                                    <a href="<%#Eval(cons.io.db.comn.ComnCons.C001010B)%>">首页</a>
                                    <br />
                                    <a href="<%#Eval(cons.io.db.comn.ComnCons.C001010F)%>">下载</a>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 10px;">
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </td>
        </tr>
        <tr>
            <td height="20" align="left">
            </td>
        </tr>
        <tr>
            <td height="1" class="TD_LINE">
            </td>
        </tr>
        <tr>
            <td align="center">
                <table id="BODY_01" cellspacing="0" cellpadding="0" width="460" border="0">
                    <tr>
                        <td align="left" style="height: 40px;">
                            <span class="TEXT_HEAD2">简介：</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;&nbsp;&nbsp;&nbsp;Amon 系列软件均基于强大的 Java 语言平台，借助其强大的跨平台性能，本软件系列及其数据系统均具有平台无关的特性，同一应用程序您不需任何改动即可同时运行于 Windows、Linux 等多种平台，方便您在不同的操作系统平台下使用同一数据。<br />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;Amon 系列软件特点：<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1）、代码开源。<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2）、跨平台运行。<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;3）、纯绿色，无需安装。<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;4）、采用Unicode编码，支持多语言。<br />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;Amon 系列软件目标：<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1）、最大程度上为用户提供方便。<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2）、源于用户需求，终于用户满意。
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="20">
            </td>
        </tr>
        <tr>
            <td height="1" class="TD_LINE">
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="460" border="0" cellpadding="0" cellspacing="0" id="BODY_02">
                    <tr>
                        <td height="30" align="left">
                            <span class="TEXT_HEAD2">开源：</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;&nbsp;&nbsp;&nbsp;Amon 系列软件均实行代码开源方案，并且遵守<a href="../java/java0001.html"> GNU GPL 通用公共许可证</a>，您可以在该公约的效力范围内随意拷贝、传播或者修改其中的代码，详细信息请参见 <a href="../java/java0001.html">GNU GPL 公约</a>。
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="20">
            </td>
        </tr>
        <tr>
            <td height="1" class="TD_LINE">
            </td>
        </tr>
        <tr>
            <td align="center">
                <table id="BODY_03" cellspacing="0" cellpadding="0" width="460" border="0">
                    <tr>
                        <td align="left" style="height: 40px;">
                            <span class="TEXT_HEAD2">致谢：</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;&nbsp;&nbsp;&nbsp;衷心感谢各位网友对 Amon 软件的关注与支持，您的意见与建议就是对 Amon 最大的鼓励与回报，也使 Amon 系列软件得以发展与完善，能够更好的为更多的用户提供更加方便的服务。<br />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;如果您喜欢 Amon 系列软件，请介绍给您的朋友；如果您有什么宝贵的意见或建议，欢迎与作者联系！<br />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;感谢您使用 Amon 系列软件！<br />
                            <br />
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
