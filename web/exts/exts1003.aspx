<%@ Page Language="C#" MasterPageFile="~/exts/exts.master" AutoEventWireup="true" CodeFile="exts1003.aspx.cs" Inherits="exts_exts1003" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;MIME类型就是设定某种扩展名的文件用一种应用程序来打开的方式类型，当该扩展名文件被访问的时候，浏览器会自动使用指定应用程序来打开。多用于指定一些客户端自定义的文件名，以及一些媒体文件打开方式。
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;MIME的英文全称是&quot;Multipurpose Internet Email Extension&quot;，比较确切的中文名称为“多用途互联网邮件扩展”，它是一种多用途网际邮件扩充协议，也是当前广泛应用的一种电子邮件技术规范，基本内容定义于RFC 2045-2049，在1992年最早应用于电子邮件系统，但后来也应用到浏览器。服务器会将它们发送的多媒体数据的类型告诉浏览器，而通知手段就是说明该多媒体数据的MIME类型，从而让浏览器知道接收到的信息哪些是MP3文件，哪些是Shockwave文件等等。服务器将MIME标志符放入传送的数据中来告诉浏览器使用哪种插件读取相关文件。
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;浏览器接收到文件后，会进入插件系统进行查找，查找出哪种插件可以识别读取接收到的文件。如果浏览器不清楚调用哪种插件系统，它可能会告诉用户缺少某插件，或者直接选择某现有插件来试图读取接收到的文件，后者可能会导致系统的崩溃。传输的信息中缺少MIME标识可能导致的情况很难估计，因为某些计算机系统可能不会出现什么故障，但某些计算机可能就会因此而崩溃。
            </td>
        </tr>
    </table>
</asp:Content>
