<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Page.aspx.cs" Inherits="Page" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>爱梦·网志</title>
    <link type="text/css" rel="stylesheet" href="_css/Amon.css" />
    <link type="text/css" rel="stylesheet" href="~/_css/smoothness/jquery-ui-1.10.1.custom.min.css" />
    <link type="text/css" rel="stylesheet" href="~/_js/jstree/themes/default/style.css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.10.1/jquery-ui.min.js"></script>
    <script type="text/javascript" src="/Amon/_js/jstree/jstree.min.js"></script>
    <style type="text/css">
        #log
        {
            border: 0;
            width: 900px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="DbBase" class="base">
        <img alt="" src="" width="0" height="0" style="border-width: 0px;" />
        <div id="DvHead" runat="server" class="head">
            <div class="clear hideSkiplink">
                <a href="#NavigationMenu_SkipLink">
                    <img alt="跳过导航链接" src="" width="0" height="0" style="border-width: 0px;" />
                </a>
                <div class="menu" id="NavigationMenu" style="float: left;">
                    <ul class="level1 static" tabindex="0" style="position: relative; width: auto; float: left;" role="menubar">
                        <li role="menuitem" class="static" style="position: relative; float: left;"><a class="level1 static" href="Default.aspx" tabindex="-1">主页</a></li>
                        <li role="menuitem" class="static" style="position: relative; float: left;"><a class="level1 static" href="About.aspx" tabindex="-1">关于</a></li>
                    </ul>
                </div>
                <div style="clear: left;">
                </div>
            </div>
        </div>
        <div id="DvBody" runat="server" class="body">
            <div id="DvList" runat="server" class="list">
                123
            </div>
            <div id="DvPage" runat="server" class="page">
                <iframe id="Iframe1" style="width: 960px; border: 0px;" src="Page.ashx"></iframe>
            </div>
            <div class="clear">
            </div>
        </div>
        <div id="DvIdea" runat="server" class="idea">
            abc
        </div>
        <div id="DvLoad" class="load" style="width: 300px; height: 80px; margin-left: -150px; margin-top: -40px;">
            <img alt="Loading" src="" width="10" height="10" /><br />
            正在努力为您加载，请稍候……
        </div>
    </div>
    </form>
</body>
<script type="text/javascript">
    $.ajax({
        type: "POST",
        url: "Page.ashx?t=cat",
        success: function (data) {
            alert(data);
            //$("#DvList").jstree(data).bind("select_node.jstree", function (e, data) { alert(data.rslt.obj.data("id")); });
            $("#DvLoad").hide();
        }
    });
    //$("#main").load(function(){
    //var mainheight = $(this).contents().find("body").height()+30;
    //$(this).height(mainheight);
    //}); 
</script>
</html>
