<%@ Page Language="C#" MasterPageFile="~/srch/srch.master" AutoEventWireup="true" CodeFile="srch1001.aspx.cs" Inherits="srch_srch1001" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="center">
                <table border="0" cellpadding="5" cellspacing="0" width="460">
                    <tr>
                        <td align="left">
                            &nbsp;&nbsp;&nbsp;&nbsp;全能搜索一款基于用户配置的综合搜索引擎工具，完全由Javascript语言开发，具有良好的跨浏览器运行能力。
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;&nbsp;&nbsp;&nbsp;使用《全能搜索》的方法：
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;&nbsp;&nbsp;&nbsp;1、如果您不是注册用户，您仍然能够使用全部的功能，但是不能进行个性化的功能定制，请跳转到第3步继续。
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;&nbsp;&nbsp;&nbsp;2、您需要首先<a href="/user/user0001.aspx">登录系统</a>，然后进入全能搜索的《<a href="/srch/srch0101.aspx">数据配置</a>》页面，在这里您可以配置喜好的搜索引擎并保存。
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;&nbsp;&nbsp;&nbsp;3、进入《<a href="/srch/srch0103.aspx">获取代码</a>》页面，进行简单的数据配置以获取适合您的页面的代码，此处需要注意的地方是：
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <div class="DV_TEXT1">
                                &nbsp;&nbsp;&nbsp;&nbsp;a、“容器 DIV”栏为您需要《全能搜索》显示的DIV的ID，若为空则系统会默认添加到&lt;BODY&gt;标记内容的末尾；<br />
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;b、“显示宽度”栏为您需要《全能搜索》显示的宽度信息（以像素为单位），为了美观起见，其宽度不能小于300像素。
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;&nbsp;&nbsp;&nbsp;4、复制代码，并将代码置于您的页面的&lt;/html&gt;标记的后面。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <div class="DV_TEXT1">
                                &nbsp;&nbsp;&nbsp;&nbsp;【注】：虽然系统默认采用了动态加载代码的功能，为了尽量不影响您的网页显示速度，还是建议您尽量放置于&lt;/html&gt;标记的后面。
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
