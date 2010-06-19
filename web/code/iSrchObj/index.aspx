<%@ Page Language="C#" MasterPageFile="~/code/code.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="code_iSrchObj_index" Title="Amon网摘" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="left">
                一、什么是划词搜索
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;划词搜索是指您在浏览器（Microsoft Internet Explorer、Mozilla Firefox、Apple Safari或其它）中浏览网页内容时，鼠标左键选取一段文字后，会在选取文字附近出现一个快捷搜索按钮，包含了一些常用的搜索引擎（Google、Yahoo!、有道、百度等），您只需要直接点击此按钮，即可将选取的内容作为搜索关键词进行搜索。
            </td>
        </tr>
        <tr>
            <td align="left" style="height: 40px;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                二、Amon划词搜索（Javascript版）
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;由Amon制作的基于Javascript语言的划词搜索（以下简称Amon划词搜索）具有以下几个特点：
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;1）、不是网络上所说的流氓软件：
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;Amon划词搜索是在您（站长或网站管理员）认为需要为用户提供便捷搜索的地方进行提供，并且只有在添加了相关的Javascript脚本的页面出现此功能，不会对用户操作系统造成任何影响。
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;2）、跨浏览器平台运行：
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;Amon划词搜索可以同时在多个浏览器下良好运行：<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&diams;&nbsp;&nbsp;Microsoft Internet Explorer；<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&diams;&nbsp;&nbsp;Mozilla Firefox；<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&diams;&nbsp;&nbsp;Apple Safari；<br />
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;3）、可以自行添加搜索引擎：
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;Amon划词搜索提供了良好的扩展性能，<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1、定制搜索引擎：您（站长或网站管理员）可以自行添加或设定搜索引擎，而不是仅限于某一个特定的搜索引擎。<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2、定制界面皮肤：您可以自行定制Amon划词搜索的用户界面。
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;4）、记录用户使用偏好
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;Amon划词搜索会在用户使用过程中记录用户使用偏好，用户可以自行选择常用搜索引擎。
            </td>
        </tr>
        <tr>
            <td align="left" style="height: 40px;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                三、如何使用Amon划词搜索
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;Amon划词搜索界面默认界面如下：
            </td>
        </tr>
        <tr>
            <td align="center">
                <img src="i/srch0001.png" alt="" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;当然，本页面已经添加了划词搜索的功能，您只要在本页面上任意选择几个文字，便会出现以上的效果。
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;1、使用Amon划词搜索：
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;您只需要把以下代码放入您的页面，并置于&lt;/body&gt;标签之前即可，效果如下：
            </td>
        </tr>
        <tr>
            <td align="center">
                <div class="DV_TEXT1">
                    &lt;script type="text/javascript" charset="utf-8"<br />
                    &nbsp;&nbsp;src="http://www.amonsoft.cn/code/iSrchObj/demo/iSrchObj.js"&gt;<br />
                    &lt;/script&gt;<br />
                    &lt;script type="text/javascript" charset="utf-8"<br />
                    &nbsp;&nbsp;src="http://www.amonsoft.cn/code/iSrchObj/demo/iSrchDat.js"&gt;<br />
                    &lt;/script&gt;
                </div>
            </td>
        </tr>
        <tr>
            <td align="center">
                <img src="i/srch0002.png" alt="" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;系统默认提供四个搜索引擎，显示界面如下：
            </td>
        </tr>
        <tr>
            <td align="center">
                <img src="i/srch0003.png" alt="" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;2、添加更多搜索引擎：
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;您也可自行添加搜索引擎，代码如下：
            </td>
        </tr>
        <tr>
            <td align="center">
                <div class="DV_TEXT1">
                    &lt;script type="text/javascript"&gt;<br />
                    &nbsp;&nbsp;iso.addSearchEngine('Yahoo','','http://one.cn.yahoo.com/s?p={0}');<br />
                    &lt;/script&gt;
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;3、定制默认搜索引擎：
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;您可以使用像下面的代码一样，定制Amon划词搜索的默认搜索引擎：
            </td>
        </tr>
        <tr>
            <td align="center">
                <div class="DV_TEXT1">
                    &lt;script type="text/javascript"&gt;<br />
                    &nbsp;&nbsp;iso.setDefaultSearchEngine('0');<br />
                    &lt;/script&gt;
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
