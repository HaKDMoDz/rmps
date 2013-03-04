<%@ Page Title="我的首页" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Me.Amon.User.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AmonHead" runat="server">
</asp:Content>
<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <div class="body" style="width: 960px; margin: 50px auto 0px auto;">
        <div id="DvPage" runat="server" class="page shadow">
            <div style="margin: 10px;">
                您好，<asp:Label ID="LbUserName" runat="server"></asp:Label>：<br />
                <br />
                欢迎您加入爱梦，我们会尽最大努力为您打造属于您的简易、高效、个性的空间，在这里您可以进行如下的操作：<br />
                1、展示您的<asp:HyperLink ID="HlUserPage" runat="server" ToolTip="点击进行查看">个人网志</asp:HyperLink>；<br />
                2、维护您的<asp:HyperLink ID="HlUserCard" runat="server" ToolTip="点击进行查看">个性卡片</asp:HyperLink>；<br />
                3、展示您的<asp:HyperLink ID="HlUserImgs" runat="server" ToolTip="点击进行查看">精彩图册</asp:HyperLink>。<br />
            </div>
        </div>
        <div id="DvLoad" runat="server" class="load corner" style="width: 300px; height: 80px; margin-left: -150px; margin-top: -40px; text-align: center">
            <a href="/Auth/Kuaipan.aspx" target="_self" title="绑定金山快盘账户">
                <img src="/_img/kuaipan_o.png" alt="绑定金山快盘账户" /></a><br />
            <br />
            您尚未绑定金山快盘账号，点击此处进行<a href="/Auth/Kuaipan.aspx" title="绑定金山快盘账户">绑定</a>！
        </div>
    </div>
</asp:Content>
