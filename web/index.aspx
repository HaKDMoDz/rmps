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
    </style>
</head>
<body>
    <form id="AmonForm" runat="server">
    <table border="0" cellpadding="2" cellspacing="0" width="100%">
        <tr>
            <td align="right">
                <div id="s" runat="server">
                    <asp:HyperLink ID="si" runat="server" NavigateUrl="~/user/user0101.aspx">登录</asp:HyperLink>
                </div>
                <div id="u" runat="server">
                    您好，
                    <asp:HyperLink ID="un" runat="server" NavigateUrl="~/user/user0001.aspx"></asp:HyperLink>
                    ！
                    <asp:LinkButton ID="so" runat="server" OnClick="lb_AmonUser_Click">退出</asp:LinkButton>
                </div>
                <asp:HiddenField ID="uc" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 500px; background-image: url(_images/line.png);background-repeat:no-repeat;background-position:center center;">
            	<table border="0" cellpadding="2" cellspacing="0" width="540">
			        <tr>
			            <td align="center" rowspan="4" style="width:280px;">
			            	<img src="_images/winshine.png" />
			            </td>
			            <td align="center" style="width:52px; height: 40px;">
			                <a href="blog/" title="Amon博客"><img src="logo/blog/logo32.png" /></a>
			            </td>
			            <td align="left" style="font-size:18px;">
			            	<a href="blog/" title="Amon博客">Amon博客</a>
			            </td>
			        </tr>
			        <tr>
			            <td align="center" style="width:52px; height: 40px;">
			            	<a href="exts/" title="后缀解析"><img src="logo/exts/logo32.png" /></a>
			            </td>
			            <td align="left" style="font-size:18px;">
			            	<a href="exts/" title="后缀解析">后缀解析</a>
			            </td>
			        </tr>
			        <tr>
			            <td align="center" style="width:52px; height: 40px;">
			            	<a href="mpwd/" title="魔方密码"><img src="logo/mpwd/logo32.png" /></a>
			            </td>
			            <td align="left" style="font-size:18px;">
			            	<a href="mpwd/" title="魔方密码">魔方密码</a>
			            </td>
			        </tr>
			        <tr>
			            <td align="center" style="width:52px; height: 40px;">
			                <a href="inet/" title="网页精灵"><img src="logo/soft/logo32.png" /></a>
			            </td>
			            <td align="left" style="font-size:18px;">
			            	<a href="inet/" title="网页精灵">网页精灵</a>
			            </td>
			        </tr>
            	</table>
            </td>
        </tr>
        <tr>
            <td align="center">
                &copy;&nbsp;<asp:Label ID="lb_CopyYear" runat="server"></asp:Label>
                &nbsp;<a href="/info/">Amonsoft</a>.&nbsp;All&nbsp;Rights Reserved.
                <br />
                <a href="http://www.miibeian.gov.cn/" title="信息产业部ICP/IP地址/域名信息备案管理系统" target="_blank">沪ICP备09014915号</a>
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

<script type="text/javascript" src="index.js"></script>

<script type="text/javascript" src="http://js.tongji.linezing.com/1078296/tongji.js"></script>

