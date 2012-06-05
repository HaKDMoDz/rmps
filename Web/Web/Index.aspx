<%@ Page Title="阿木密码箱，免费且开源的密码管理软件！" Language="C#" MasterPageFile="~/Amon.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Me.Amon.Index1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="AmonHead">
    <style type="text/css">
        #simplegallery1
        {
            position: relative; /*keep this intact*/
            visibility: hidden; /*keep this intact*/
            border: 5px solid #CCC;
        }
        
        #simplegallery1 .gallerydesctext
        {
            text-align: left;
            padding: 2px 5px;
        }
    </style>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.6.0/jquery.min.js"></script>
    <script type="text/javascript" src="Scripts/simplegallery.js">
        /***********************************************
        * Simple Controls Gallery- (c) Dynamic Drive DHTML code library (www.dynamicdrive.com)
        * This notice MUST stay intact for legal use
        * Visit Dynamic Drive at http://www.dynamicdrive.com/ for this script and 100s more
        ***********************************************/
    </script>
    <script type="text/javascript">
        var mygallery = new simpleGallery({
            wrapperid: "simplegallery1", //ID of main gallery container,
            dimensions: [480, 240], //width/height of gallery in pixels. Should reflect dimensions of the images exactly
            imagearray: [
				["Images/1.png", "", "_new", "用户登录界面"],
				["Images/2.png", "", "_new", "密码箱主界面"],
				["Images/3.png", "", "_new", "专业用户界面"],
				["Images/4.png", "", "_new", "向导用户界面"],
				["Images/5.png", "", "_new", "系统提示界面"],
            //["path_to_image", "optional_link", "optional_linktarget", "optional_textdescription"]
			],
            autoplay: [true, 2500, 1], //[auto_play_boolean, delay_btw_slide_millisec, cycles_before_stopping_int]
            persist: false, //remember last viewed slide and recall within same session?
            fadeduration: 500, //transition duration (milliseconds)
            oninit: function () { //event that fires when gallery has initialized/ ready to run
                //Keyword "this": references current gallery instance (ie: try this.navigate("play/pause"))
            },
            onslide: function (curslide, i) { //event that fires after each slide is shown
                //Keyword "this": references current gallery instance
                //curslide: returns DOM reference to current slide's DIV (ie: try alert(curslide.innerHTML)
                //i: integer reflecting current image within collection being shown (0=1st image, 1=2nd etc)
            }
        })
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="AmonView">
    <table width="100%">
        <tr>
            <td align="center" valign="middle" style="height: 120px">
                <h2>
                    阿木密码箱
                </h2>
                <h3>
                    免费且开源的密码管理软件！
                </h3>
            </td>
        </tr>
        <tr>
            <td align="center">
                <div id="simplegallery1">
                </div>
            </td>
        </tr>
        <tr>
            <td align="center" height="120">
                <asp:HyperLink ID="HlSignUp" runat="server" NavigateUrl="~/down/amon.exe" CssClass="Down Ins" ForeColor="#ffffff">安装版</asp:HyperLink>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:HyperLink ID="HlSignIn" runat="server" NavigateUrl="~/down/amon.zip" CssClass="Down Grn" ForeColor="#555555">绿色版</asp:HyperLink>
            </td>
        </tr>
    </table>
</asp:Content>
