<%@ Page Language="C#" MasterPageFile="~/inet/inet.master" AutoEventWireup="true" CodeFile="inet0105.aspx.cs" Inherits="inet_inet0105" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="center">
                <div class="DV_TEXT1">
                    【说明】：<br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;某些版本的浏览器可能出现无法预览的情况，请刷新一次预览窗口即可！
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <textarea id="ta_Code" cols="20" rows="8" style="width: 90%" readonly="readOnly"></textarea>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <div style="width: 90%; text-align: right;">
                    <input id="bt_View" type="button" value="预览(P)" accesskey="P" onclick="preview();" /><asp:HiddenField ID="hd_UserCode" runat="server" />
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="TD_LINE" style="height: 1px;">
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                【第一步】输入显示容器（必选）：
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <table border="0" cellpadding="0" cellspacing="0" width="320">
                    <tr>
                        <td align="left">
                            <input type="text" id="tf_Pane" onblur="viewText(this, '', false);" />
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
            <td align="left">
                【第二步】选择功能类型（必选）：
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <table border="0" cellpadding="0" cellspacing="0" width="320">
                    <tr>
                        <td align="left">
                            <select id="cb_Type" onchange="return viewType(this);">
                                <option value="">请选择</option>
                                <option value="help">集成菜单</option>
                                <option value="link">快捷方式</option>
                                <option value="list">下拉列表</option>
                                <option value="pbse">划词搜索</option>
                                <option value="form">内置窗口</option>
                                <option value="date">日历</option>
                                <option value="time">时间</option>
                            </select>
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
            <td align="left">
                【第三步】设置显示参数（可选）：
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr id="tr_help" style="display: none;">
            <td align="center">
                <table border="0" cellpadding="2" cellspacing="0" width="320" class="TB_DataList_TL">
                    <tr>
                        <td align="right" class="TD_DataHead_TL_L">
                            显示风格：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <select id="cb_MenuView" onchange="viewText(this, 'icon_text', false);">
                                <option value="icon_text">图标及文本</option>
                                <option value="icon">仅图标</option>
                                <option value="text">仅文本</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="TD_DataHead_TL_L">
                            页面标题：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <input id="tf_MenuT" type="text" style="width: 160px;" onblur="viewText(this, '', false);" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="TD_DataHead_TL_L">
                            链接地址：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <input id="tf_MenuU" type="text" style="width: 160px;" onblur="viewText(this, '', false);" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="TD_DataHead_TL_L">
                            内容概要：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <textarea id="ta_MenuD" cols="30" rows="2" style="width: 200px;" onblur="viewText(this, '', false);"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="TD_DataHead_TL_L">
                            激发控件：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <input id="tf_MenuC" type="text" style="width: 160px;" onblur="viewText(this, '', false);" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="tr_link" style="display: none;">
            <td align="center">
                <table border="0" cellpadding="2" cellspacing="0" width="320" class="TB_DataList_TL">
                    <tr>
                        <td align="right" class="TD_DataHead_TL_L">
                            显示类别：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:DropDownList ID="cb_LinkType" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="TD_DataHead_TL_L">
                            显示风格：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <select id="cb_LinkView" onchange="viewText(this, 'icon_text', false);">
                                <option value="icon_text">图标及文本</option>
                                <option value="icon">仅图标</option>
                                <option value="text">仅文本</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="TD_DataHead_TL_L">
                            显示行数：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <input id="tf_LinkRows" type="text" style="width: 160px;" onblur="viewText(this, '1', true);" value="1" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="TD_DataHead_TL_L">
                            显示列数：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <input id="tf_LinkCols" type="text" style="width: 160px;" onblur="viewText(this, '8', true);" value="8" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="TD_DataHead_TL_L">
                            页面标题：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <input id="tf_LinkT" type="text" style="width: 160px;" onblur="viewText(this, '', false);" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="TD_DataHead_TL_L">
                            链接地址：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <input id="tf_LinkU" type="text" style="width: 160px;" onblur="viewText(this, '', false);" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="TD_DataHead_TL_L">
                            内容概要：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <textarea id="ta_LinkD" cols="30" rows="2" style="width: 200px;" onblur="viewText(this, '', false);"></textarea>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="tr_list" style="display: none;">
            <td align="center">
                <table border="0" cellpadding="2" cellspacing="0" width="320" class="TB_DataList_TL">
                    <tr>
                        <td align="right" class="TD_DataHead_TL_L">
                            显示类别：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:DropDownList ID="cb_ListType" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="TD_DataHead_TL_L">
                            显示数量：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <input id="tf_ListSize" type="text" style="width: 160px;" onblur="viewText(this, '8', true);" value="8" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="TD_DataHead_TL_L">
                            页面标题：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <input id="tf_ListT" type="text" style="width: 160px;" onblur="viewText(this, '', false);" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="TD_DataHead_TL_L">
                            链接地址：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <input id="tf_ListU" type="text" style="width: 160px;" onblur="viewText(this, '', false);" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="TD_DataHead_TL_L">
                            内容概要：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <textarea id="ta_ListD" cols="30" rows="2" style="width: 200px;" onblur="viewText(this, '', false);"></textarea>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="tr_pbse" style="display: none;">
            <td align="center">
                <table border="0" cellpadding="2" cellspacing="0" width="320" class="TB_DataList_TL">
                    <tr>
                        <td align="right" class="TD_DataHead_TL_L">
                            显示方式：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <input id="tf_PbseS" type="text" style="width: 160px;" onblur="viewText(this, '8', true);" value="8" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="tr_date" style="display: none;">
            <td align="center">
                <table border="0" cellpadding="2" cellspacing="0" width="320" class="TB_DataList_TL">
                    <tr>
                        <td align="right" class="TD_DataHead_TL_L">
                            显示方式：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <select id="cb_DateType" onchange="viewCode();$X('tf_DateS').disabled=(this.value!='menu');">
                                <option value="link">文本模式</option>
                                <option value="menu">菜单模式</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="TD_DataHead_TL_L">
                            日期格式：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <input id="tf_DateF" type="text" style="width: 160px;" onblur="viewText(this, 'yyyy-MM-dd', false);" value="yyyy-MM-dd" />
                            <a href="/inet/inet1002.aspx" title="日期及时间的格式信息">参见</a>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="TD_DataHead_TL_L">
                            窗口宽度：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <input id="tf_DateW" type="text" style="width: 160px;" onblur="viewText(this, '160', true);" value="160" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="TD_DataHead_TL_L">
                            窗口高度：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <input id="tf_DateH" type="text" style="width: 160px;" onblur="viewText(this, '120', true);" value="120" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="TD_DataHead_TL_L">
                            关联组件：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <input id="tf_DateD" type="text" style="width: 160px;" onblur="viewText(this, '', false);" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="TD_DataHead_TL_L">
                            激发组件：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <input id="tf_DateS" type="text" style="width: 160px;" onblur="viewText(this, '', false);" disabled="disabled" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="tr_time" style="display: none;">
            <td align="center">
                <table border="0" cellpadding="2" cellspacing="0" width="320" class="TB_DataList_TL">
                    <tr>
                        <td align="right" class="TD_DataHead_TL_L">
                            时间格式：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <input id="tf_TimeF" type="text" style="width: 160px;" onblur="viewText(this, 'yyyy年MM月dd日 HH:mm:ss wwww', false);" value="yyyy年MM月dd日 HH:mm:ss wwww" />
                            <a href="/inet/inet1002.aspx" title="日期及时间的格式信息">参见</a>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="TD_DataHead_TL_L">
                            关联组件：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <input id="tf_TimeD" type="text" style="width: 160px;" onblur="viewText(this, '', false);" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="tr_form" style="display: none;">
            <td align="center">
                <table border="0" cellpadding="2" cellspacing="0" width="320" class="TB_DataList_TL">
                    <tr>
                        <td align="right" class="TD_DataHead_TL_L">
                            窗口名称：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <input id="tf_Form1" type="text" style="width: 160px;" onblur="viewText(this, '', false);" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="TD_DataHead_TL_L">
                            窗口宽度：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <input id="tf_Form2" type="text" style="width: 160px;" onblur="viewText(this, '120', true);" value="120" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="TD_DataHead_TL_L">
                            窗口高度：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <input id="tf_Form3" type="text" style="width: 160px;" onblur="viewText(this, '100', true);" value="100" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="TD_DataHead_TL_L">
                            横向偏移：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <input id="tf_Form4" type="text" style="width: 160px;" onblur="viewText(this, '0', true);" value="0" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="TD_DataHead_TL_L">
                            纵向偏移：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <input id="tf_Form5" type="text" style="width: 160px;" onblur="viewText(this, '0', true);" value="0" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="TD_DataHead_TL_L">
                            水平对齐：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <select id="cb_Form6" onchange="viewText(this, 'left', false);">
                                <option value="left" selected="selected">左部对齐</option>
                                <option value="center">水平居中</option>
                                <option value="right">右部对齐</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="TD_DataHead_TL_L">
                            垂直对齐：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <select id="cb_Form7" onchange="viewText(this, 'top', false);">
                                <option value="top" selected="selected">项部对齐</option>
                                <option value="middle">垂直居中</option>
                                <option value="bottom">底部对齐</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="TD_DataHead_TL_L">
                            可最小化：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <input id="ck_Form8" type="checkbox" checked="checked" onclick="viewCode();" />允许最小化
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="TD_DataHead_TL_L">
                            可关闭：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <input id="ck_Form9" type="checkbox" checked="checked" onclick="viewCode();" />允许关闭
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
