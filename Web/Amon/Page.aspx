<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page.aspx.cs" Inherits="Me.Amon.Page" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>爱梦·网志</title>
    <link type="text/css" rel="stylesheet" href="/_css/Amon.css" />
    <link type="text/css" rel="stylesheet" href="/_css/smoothness/jquery-ui-1.10.1.custom.min.css" />
    <link type="text/css" rel="stylesheet" href="/_js/zt/themes/zTreeStyle.css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.10.1/jquery-ui.min.js"></script>
    <script type="text/javascript" src="/_js/zt/jquery.ztree.core-3.5.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="DbBase" class="base">
        <div id="DvBody" runat="server" class="body">
            <div id="DvList" runat="server" class="list shadow">
                <ul id="UlList" class="ztree">
                </ul>
            </div>
            <div id="DvPage" runat="server" class="page shadow">
                <iframe id="IfPage" runat="server" style="width: 100%; height: 420px; min-width: 300px; min-height: 420px; border: 0px;"></iframe>
            </div>
            <div class="clear">
            </div>
        </div>
        <div id="DvIdea" runat="server" class="idea shadow">
            abc
        </div>
        <div id="DvLoad" class="load corner" style="width: 300px; height: 80px; margin-left: -150px; margin-top: -40px; text-align: center">
            <br />
            <img alt="Loading" src="/_img/Loading.gif" /><br />
            <br />
            正在努力为您加载中……
        </div>
        <div id="DvHome" runat="server" style="position: fixed; width: 80px; height: 18px; top: 0px; right: 80px; border: 1px solid #eee; background-color: #fff; text-align: center; border-bottom: 2px solid #FD8712;">
            <a href="/User/Index.aspx">我的首页</a>
        </div>
    </div>
    <asp:HiddenField ID="HdCode" runat="server" />
    </form>
    <script type="text/javascript">
        function reload(url) {
            $('#IfPage').attr("src", "/Page.ashx?c=" + code + "&f=" + escape(url));
            $("#IfPage").load(function () {
                var h = $(this).contents().find("body").height() + 30;
                if (h < 420) { h = 420; }
                $(this).height(h);
            });
        }
        reload("/index.html");
        function onClick(event, treeId, treeNode, clickFlag) {
            if (treeNode.v) {
                $('#IfPage').attr("src", "/Page.ashx?c=" + code + "&f=" + escape(treeNode.v));
            }
        }

        var setting = {
            data: {
                key: {
                    name: "name",
                    title: "name"
                },
                simpleData: {
                    enable: true,
                    idKey: "id",
                    pIdKey: "pId",
                    rootPId: "0"
                }
            },
            callback: {
                onClick: onClick
            }
        };
        var zNodes = [];
        var zTree = $("#UlList");
        var code = $('#HdCode').val();

        $.ajax({
            type: "POST",
            url: "/Page.ashx?t=cat&c=" + code,
            success: function (data) {
                zNodes = eval(data);
                $.fn.zTree.init(zTree, setting, zNodes);
                $("#DvLoad").hide();
            },
            error: function (data) {
                $.fn.zTree.init(zTree, setting, [{ id: '0', pId: '0', name: '我的网志', isParent: true, open: true}]);
                $("#DvLoad").hide();
                alert(data.toString());
                //alert('数据加载出错，请稍后尝试！');
            }
        });
    </script>
    <!-- Baidu Button BEGIN -->
    <script type="text/javascript" id="bdshare_js" data="type=slide&amp;img=3&amp;pos=right&amp;uid=6614751"></script>
    <script type="text/javascript" id="bdshell_js"></script>
    <script type="text/javascript">
        var bds_config = { "bdTop": 80 };
        document.getElementById("bdshell_js").src = "http://bdimg.share.baidu.com/static/js/shell_v2.js?cdnversion=" + Math.ceil(new Date() / 3600000);
    </script>
    <!-- Baidu Button END -->
</body>
</html>
