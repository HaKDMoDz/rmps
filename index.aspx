<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="AmonHead" runat="server">
    <title>
        <%= cons.wrp.WrpCons.TITLE_HOME%>
    </title>
    <%=cons.wrp.WrpCons.KEYWORDS_HOME%>
    <%=cons.wrp.WrpCons.DESCRIPTION_HOME%>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Style-Type" content="text/css" />
    <meta http-equiv="Content-Script-Type" content="text/javascript" />
    <link href="index.css" rel="stylesheet" type="text/css" />
    <link href="_res/jRating/jRating.jquery.css" rel="stylesheet" type="text/css" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js" type="text/javascript"></script>

    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.14/jquery-ui.min.js" type="text/javascript"></script>

</head>
<body>
    <form id="AmonForm" runat="server">
    <table border="0" cellpadding="2" cellspacing="0" width="100%">
        <tr>
            <td style="height: 40px;">
            </td>
        </tr>
        <tr>
            <td align="center">
                <table id="tbCard" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td id="trCardT">
                        </td>
                    </tr>
                    <tr>
                        <td id="trCardM" align="center">
                            <table border="0" cellpadding="0" cellspacing="0" width="700px">
                                <tr>
                                    <td id="tdCardMMenu" align="center" valign="top" style="width: 340px;">
                                        <table id="tbMenu" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td id="tdMenuLogo" align="left" colspan="4">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="tdMenuGuid" align="right" rowspan="8">
                                                    <img alt="" src="_img/0001/logo.png" alt="网站LOGO" />
                                                </td>
                                                <td id="tdMenuLine" rowspan="8">
                                                </td>
                                                <td align="center" class="softIcon">
                                                    &nbsp;
                                                </td>
                                                <td align="left" class="softName">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="softIcon">
                                                    <a href="wlog/" title="Amon博客">
                                                        <img src="logo/blog/logo24.png" alt="" /></a>
                                                </td>
                                                <td align="left" class="softName">
                                                    <a href="wlog/" title="Amon博客">Amon博客</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="softIcon">
                                                    <a href="code/" title="Amon源码">
                                                        <img src="logo/code/logo24.png" alt="" /></a>
                                                </td>
                                                <td align="left" class="softName">
                                                    <a href="code/" title="Amon源码">Amon源码</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="softIcon">
                                                    <a href="mpwd/" title="魔方密码">
                                                        <img src="logo/mpwd/logo24.png" alt="" /></a>
                                                </td>
                                                <td align="left" class="softName">
                                                    <a href="mpwd/" title="魔方密码">魔方密码</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="softIcon">
                                                    <a href="inet/" title="网页精灵">
                                                        <img src="logo/soft/logo24.png" alt="" /></a>
                                                </td>
                                                <td align="left" class="softName">
                                                    <a href="inet/" title="网页精灵">网页精灵</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="softIcon">
                                                    <a href="inet/" title="新浪微博">
                                                        <img src="logo/mlog/logo24.png" alt="" /></a>
                                                </td>
                                                <td align="left" class="softName">
                                                    <a href="http://weibo.com/amonyao" title="新浪微博" target="_blank">新浪微博</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="softIcon">
                                                    &nbsp;
                                                </td>
                                                <td align="left" class="softName">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="height: 140px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" align="left">
                                                    <a target="_self" title="联系作者" href="#">
                                                        <img id="mail" src="_images/share/share_00.gif" alt="联系作者" title="联系作者" width="16" height="16" /></a> <a target="_blank" title="分享到 新浪微博" href="javascript:void(0);" onclick="ShareThis('weibo');">
                                                            <img id="weibo" src="_images/share/share_01.gif" alt="新浪微博" width="16" height="16" /></a> <a target="_blank" title="转播到 腾讯微博" href="javascript:void(0);" onclick="ShareThis('t.qq');">
                                                                <img id="tqq" src="_images/share/share_02.gif" alt="腾讯微博" width="16" height="16" /></a>
                                                    <!--
                                                    <a target="_blank" title="转发到 网易微博" href="javascript:void(0);" onclick="ShareThis('t.163');"><img id="t163" src="_images/share/share_03.gif" alt="网易微博" width="16" height="16" /></a>
                                                    <a target="_blank" title="转发到 搜狐微博" href="javascript:void(0);" onclick="ShareThis('t.sohu');"><img id="tsohu" src="_images/share/share_04.gif" alt="搜狐微博" width="16" height="16" /></a>
                                                    -->
                                                    <a target="_blank" title="推荐到 豆瓣" href="javascript:void(0);" onclick="ShareThis('douban');">
                                                        <img id="douban" src="_images/share/share_06.gif" alt="豆瓣" width="16" height="16" /></a> <a target="_blank" title="发送到 人人网" href="javascript:void(0);" onclick="ShareThis('renren');">
                                                            <img id="renren" src="_images/share/share_07.gif" alt="人人网" width="16" height="16" /></a>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td id="tdCardMLine">
                                    </td>
                                    <td id="tdCardMMisc" align="center" valign="top">
                                        <table id="tbMisc" border="0" cellpadding="0" cellspacing="0" width="90%">
                                            <tr>
                                                <td id="tdMiscHead" align="left" valign="bottom">
                                                    <div id="dvMiscHead" runat="server">
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="tdMiscName" align="center">
                                                    <div id="dvMiscName" runat="server">
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="tdMiscBody" align="left" valign="top">
                                                    <div id="dvMiscBody" runat="server">
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="tdMiscRate" align="left">
                                                    <div id="dvMiscRate" runat="server" class="jRating">
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td id="trCardB">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table id="tbCopy" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 30%;" align="left">
                        </td>
                        <td style="width: 40%;" align="center">
                            ©&nbsp;<asp:Label ID="lb_CopyYear" runat="server"></asp:Label>&nbsp;<a href="/info/">Amon</a>.&nbsp;All&nbsp;Rights Reserved.
                        </td>
                        <td style="width: 30%;" align="right">
                            <a href="http://validator.w3.org/check/referer" target="_blank">
                                <img src="_images/n_vxml.gif" alt="Valid CSS!" width="16" height="16" /></a>&nbsp; <a href="https://www.google.com/analytics/home/" title="Google Analytics" target="_blank">
                                    <img src="_images/n_copy.gif" alt="Copyright!" width="16" height="16" /></a>&nbsp; <a href="http://jigsaw.w3.org/css-validator/check/referer" target="_blank">
                                        <img src="_images/n_vcss.gif" alt="Valid XML!" width="16" height="16" /></a>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

<script type="text/javascript" src="index.js"></script>

<script type="text/javascript" src="http://js.tongji.linezing.com/437983/tongji.js"></script>

