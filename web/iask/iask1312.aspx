<%@ Page Language="C#" MasterPageFile="~/iask/iask.master" AutoEventWireup="true" CodeFile="iask1312.aspx.cs" Inherits="iask_iask1312" Title="Untitled Page" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellspacing="0" cellpadding="0" id="TB_DATA">
        <tr>
            <td align="center">
                <textarea id="code" cols="20" rows="5" style="width: 460px;"></textarea>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <table border="0" cellspacing="0" cellpadding="2" width="460" class="TB_DataList_TL">
                    <tr>
                        <td align="center" class="TD_DataItem_TL_L" colspan="4">
                            窗口地址：<input id="url" type="text" style="width: 76%;" value="http://" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="TD_DataItem_TL_L" width="25%">
                            顶距：<input id="top" type="text" size="6" />
                        </td>
                        <td align="center" class="TD_DataItem_TL_L" width="25%">
                            左距：<input id="left" type="text" size="6" />
                        </td>
                        <td align="center" class="TD_DataItem_TL_L" width="25%">
                            宽度：<input id="width" type="text" size="6" />
                        </td>
                        <td align="center" class="TD_DataItem_TL_L" width="25%">
                            高度：<input id="height" type="text" size="6" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="TD_DataItem_TL_L" width="25%">
                            <input id="ck1" type="checkbox" />显示菜单栏
                        </td>
                        <td align="center" class="TD_DataItem_TL_L" width="25%">
                            <input id="ck2" type="checkbox" />显示工具栏
                        </td>
                        <td align="center" class="TD_DataItem_TL_L" width="25%">
                            <input id="ck3" type="checkbox" />显示状态栏
                        </td>
                        <td align="center" class="TD_DataItem_TL_L" width="25%">
                            <input id="ck4" type="checkbox" />显示滚动条
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="TD_DataItem_TL_L" width="25%">
                            <input id="ck5" type="checkbox" />全屏显示&nbsp;&nbsp;
                        </td>
                        <td align="center" class="TD_DataItem_TL_L" width="25%">
                            <input id="ck6" type="checkbox" />显示地址栏
                        </td>
                        <td align="center" class="TD_DataItem_TL_L" width="25%">
                            <input id="ck7" type="checkbox" />窗口可调整
                        </td>
                        <td align="center" class="TD_DataItem_TL_L" width="25%">
                            <input id="ck8" type="checkbox" checked="checked" />打开新窗口
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <input type="button" id="g" value="生成(G)" onclick="gOpen();" />
                <input type="button" id="t" value="测试(T)" onclick="tOpen();" />
            </td>
        </tr>
    </table>
</asp:Content>
