<%@ Page Language="C#" MasterPageFile="~/iask/iask.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="iask_index" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                此板块为Amon软件系统的在线模块，目前您可以获得以下的在线服务内容：
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="3" cellspacing="0" width="100%" class="TB_DataList_TL">
                    <tr>
                        <td align="left" class="TD_DataHead_TL_L" style="width: 100px;">
                            <a href="/exts/index.aspx">后缀解析</a>
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            Amon系列软件《后缀解析》的在线部分，您可以在线使用此软件的所有功能。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataHead_TL_L" style="width: 100px;">
                            <a href="/math/index.aspx">计算助理</a>
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            多功能复杂数学表达式计算器，并能够在用户控制下显示逐步的运算过程。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataHead_TL_L">
                            <a href="/srch/index.aspx">在线搜索</a>
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            通过此模块，您可以使用不同的搜索引擎进行相关信息的搜索。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataHead_TL_L">
                            <a href="/link/index.aspx">网络导航</a>
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            常用链接分类管理。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataHead_TL_L">
                            <a href="/date/index.aspx">中国农历</a>
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            显示1900年及其以后的公历、农历及节日信息。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataHead_TL_L">
                            <a href="iask1305.aspx">消息摘要</a>
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            MD5、SHA-1、SHA-256、SHA-384、SHA-512消息摘要。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataHead_TL_L">
                            <a href="iask130C.aspx">ＩＰ查询</a>
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            最新网络IP地址查询。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataHead_TL_L">
                            <a href="iask13A1.aspx">电视节目预告</a>
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            全国各地电视节日预告信息。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataHead_TL_L">
                            <a href="iask13A2.aspx">邮编查询</a>
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            全国各地邮政编码信息查询。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataHead_TL_L">
                            <a href="iask13A3.aspx">天气预报</a>
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            提供各大城市最新天气预报信息。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataHead_TL_L">
                            <a href="iask1311.aspx">正则表达式测试器</a>
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            Javascript正则表达式测试工具，方便快速校验正则表达式的正确性，并提供常用正则表达式代码。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataHead_TL_L">
                            <a href="iask1312.aspx">Open代码生成器</a>
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            方便快捷的Javascript Window.open()函数生成工具！
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataHead_TL_L">
                            <a href="iask13A4.aspx">浏览器信息查看</a>
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            快速查看您的浏览器的一些详细信息！
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
