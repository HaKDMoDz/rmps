<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Demo.aspx.cs" Inherits="Me.Amon.Demo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="~/_css/Amon.css" rel="stylesheet" type="text/css" />
    <link href="~/_css/smoothness/jquery-ui-1.10.1.custom.css" rel="stylesheet" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.10.1/jquery-ui.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="DbBase" class="base">
        <div id="DvHead" runat="server" class="head">
            <div class="menu" style="float: left;">
                <ul class="level1 static" tabindex="0" style="position: relative; width: auto; float: left;" role="menubar">
                    <li role="menuitem" class="static" style="position: relative; float: left;"><a class="level1 static" href="/Index.aspx" tabindex="-1">主页</a></li>
                    <li role="menuitem" class="static" style="position: relative; float: left;"><a class="level1 static" href="/blog" tabindex="-1">博客</a></li>
                    <li role="menuitem" class="static" style="position: relative; float: left;"><a class="level1 static" href="/Ideas.aspx" tabindex="-1">留言</a></li>
                    <li role="menuitem" class="static" style="position: relative; float: left;"><a class="level1 static" href="/p/Help" tabindex="-1">帮助</a></li>
                    <li role="menuitem" class="static" style="position: relative; float: left;"><a class="level1 static" href="/About.aspx" tabindex="-1">关于</a></li>
                </ul>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
