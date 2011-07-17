<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
    <style type="text/css">
        BODY
        {
            background-color: #ffffff;
            color: #330000;
            font-family: "宋体" , "微软雅黑" , simsun, Arial, "Times New Roman";
            font-size: 9pt;
            margin: 3px;
        }
        img
        {
            border-width: 0px;
        }
        .TB_LinkPort
        {
            border: solid 1px #F0F0F0;
        }
        .TR_LinkPort_A
        {
            background-color: #FAFAFA;
        }
        .TR_LinkPort_D
        {
            background-color: #FFFFFF;
        }
    </style>
</head>
<body>
    <form id="AmonForm" runat="server">
    <table border="0" cellpadding="2" cellspacing="0" width="100%">
        <tr>
            <td align="center" style="height: 120px;">
                <img src="_images/winshine.gif" alt="闻讯" width="180" height="60" />
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 80px;">
                <div id="AmonHome" style="width: 670px; height: 66px;">
                </div>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 40px;">
                <div id="AmonGuid" style="width: 500px;">
                </div>
            </td>
        </tr>
        <tr>
            <td align="center">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="440" border="0" cellpadding="3" cellspacing="0">
                    <tr>
                        <td align="left" colspan="2">
                            <strong>&nbsp;常用工具</strong>
                        </td>
                        <td align="left" colspan="2">
                            <strong>&nbsp;Amon在线</strong>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 20%">
                            ·<a target="_blank" href="http://flashhq.gw.com.cn/main.html" title="大智慧">股市行情</a>
                        </td>
                        <td align="left" style="width: 20%">
                            ·<a target="_blank" href="http://www.yp.net.cn/schinese/" title="中国黄页在线">中国黄页</a>
                        </td>
                        <td align="left" style="width: 20%">
                            ·<a href="/iask/iask1305.aspx" title="MD5、SHA-1、SHA-256、SHA-384、SHA-512消息摘要。">消息摘要</a>
                        </td>
                        <td align="left" style="width: 40%">
                            ·<a href="/exts/index.aspx">Amon后缀解析！</a><img src="_images/new.gif" alt="" width="13" height="13" style="vertical-align: middle;" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 20%">
                            ·<a target="_blank" href="http://www.lottery.gov.cn/" title="中国体彩网">体育彩票</a>
                        </td>
                        <td align="left" style="width: 20%">
                            ·<a target="_blank" href="http://www.51job.com/" title="前程无忧">网上求职</a>
                        </td>
                        <td align="left" style="width: 20%">
                            ·<a href="/iask/iask130C.aspx">ＩＰ查询</a>
                        </td>
                        <td align="left" style="width: 40%">
                            ·<a href="/mpwd/index.aspx">Amon魔方密码！</a><img src="_images/new.gif" alt="" width="13" height="13" style="vertical-align: middle;" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 20%">
                            ·<a target="_blank" href="http://www.shike.org.cn/" title="中国铁路时刻网">列表时刻</a>
                        </td>
                        <td align="left" style="width: 20%">
                            ·<a target="_blank" href="http://www.miibeian.gov.cn/" title="工业和信息化部ICP/IP地址信息备案管理系统">信息备案</a>
                        </td>
                        <td align="left" style="width: 20%">
                            ·<a href="/iask/iask13A1.aspx">节目预告</a>
                        </td>
                        <td align="left" style="width: 40%">
                            ·<a href="/inet/index.aspx">Amon网页精灵！</a><img src="_images/new.gif" alt="" width="13" height="13" style="vertical-align: middle;" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 20%">
                            ·<a target="_blank" href="http://nongli.com/item3/index.asp" title="中华农历网">中国农历</a>
                        </td>
                        <td align="left" style="width: 20%">
                            ·<a target="_blank" href="http://www.123cha.com/" title="全库网123查！">生活查询</a>
                        </td>
                        <td align="left" style="width: 20%">
                            ·<a href="/iask/iask13A2.aspx">邮编查询</a>
                        </td>
                        <td align="left" style="width: 40%">
                            ·<a href="/link/index.aspx">Amon网络导航！</a><img src="_images/new.gif" alt="" width="13" height="13" style="vertical-align: middle;" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 20%">
                            ·<a target="_blank" href="http://www.51jiemeng.com/" title="周公解梦">周公解梦</a>
                        </td>
                        <td align="left" style="width: 20%">
                            ·<a target="_blank" href="http://www.linkwan.com/gb/broadmeter/SpeedAuto/" title="世界网络">网速测试</a>
                        </td>
                        <td align="left" style="width: 20%">
                            ·<a href="/iask/iask13A3.aspx">天气预报</a>
                        </td>
                        <td align="left" style="width: 40%">
                            ·<a href="/edit/index.aspx">Amon源码查看！</a><img src="_images/new.gif" alt="" width="13" height="13" style="vertical-align: middle;" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 40px;">
                <table border="0" cellpadding="0" cellspacing="0" width="610" style="background-color: #FAFAFA;">
                    <tr>
                        <td class="sl" align="center" style="height: 22px;">
                            <a href="/exts/">后缀解析</a>
                        </td>
                        <td class="sl" align="center" style="height: 22px;">
                            <a href="/mpwd/">魔方密码</a>
                        </td>
                        <td class="sl" align="center" style="height: 22px;">
                            <a href="/inet/">网页精灵</a>
                        </td>
                        <td class="sl" align="center" style="height: 22px;">
                            <a href="/link/">网络导航</a>
                        </td>
                        <td class="sl" align="center" style="height: 22px;">
                            <a href="/edit/">源码查看</a>
                        </td>
                        <td class="sl" align="center" style="height: 22px;">
                            <a href="/srch/">Amon搜索</a>
                        </td>
                        <td class="sl" align="center" style="height: 22px;">
                            <a href="/card/">Amon卡片</a>
                        </td>
                        <td class="sl" align="center" style="height: 22px;">
                            <a href="/blog/">Amon博客</a>
                        </td>
                        <td class="sl" align="center" style="height: 22px;">
                            <a href="/myim/">即时通讯</a>
                        </td>
                        <td class="sl" align="center" style="height: 22px;">
                            <a href="/date/">时钟秀</a>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                &copy;&nbsp;<asp:Label ID="lb_CopyYear" runat="server"></asp:Label>
                &nbsp;<a href="/info/">Amonsoft</a>.&nbsp;All&nbsp;Rights Reserved.&nbsp;<a href="http://www.miibeian.gov.cn/" title="信息产业部ICP/IP地址/域名信息备案管理系统" target="_blank">沪ICP备09014915号</a>
                <br />
                <a href="http://validator.w3.org/check/referer" target="_blank">
                    <img src="_images/n_vxml.gif" alt="Valid CSS!" width="16" height="16" />
                </a>&nbsp;<a href="https://www.google.com/analytics/home/" title="Google Analytics" target="_blank">
                    <img src="_images/n_copy.gif" alt="Copyright!" width="16" height="16" />
                </a>&nbsp;<a href="http://jigsaw.w3.org/css-validator/check/referer" target="_blank">
                    <img src="_images/n_vcss.gif" alt="Valid XML!" width="16" height="16" />
                </a>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

<script type="text/javascript" src="/<%=cons.EnvCons.PRE_URL%>srch/srch0001.ashx?sid=<%=rmp.comn.user.UserInfo.Current(Session).UserCode%>"></script>

<script type="text/javascript" src="index.js"></script>

<script type="text/javascript" src="http://js.tongji.linezing.com/1078296/tongji.js"></script>

