<%@ Page Language="C#" MasterPageFile="~/iask/iask.master" AutoEventWireup="true" CodeFile="iask1311.aspx.cs" Inherits="iask_iask1311" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="center">
                <table width="460" border="0" cellpadding="2" cellspacing="0" class="TB_DataList_TL">
                    <tr>
                        <td title="Test Pattern" align="right" width="80" class="TD_DataHead_TL_L">
                            匹配模式：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <input id="_r" type="text" size="30" />
                            <select id="_p" onchange="p()">
                                <option value="-1">预设模式</option>
                                <optgroup label="数字">
                                    <option value="n001">整数</option>
                                    <option value="n002">正整数</option>
                                    <option value="n003">负整数</option>
                                    <option value="n004">非负整数</option>
                                    <option value="n005">非正整数</option>
                                    <option value="n006">小数</option>
                                    <option value="n007">仅数字</option>
                                    <option value="n008">邮政编码</option>
                                    <option value="n009">手机号码</option>
                                </optgroup>
                                <optgroup label="字符">
                                    <option value="c001">大写字母</option>
                                    <option value="c002">小写字母</option>
                                    <option value="c003">大小写字母</option>
                                    <option value="c004">字母及数字</option>
                                    <option value="c005">字母、数字及下划线</option>
                                    <option value="c006">登录姓名</option>
                                    <option value="c007">电子邮件</option>
                                </optgroup>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td title="Test Flags" align="right" width="80" class="TD_DataHead_TL_L">
                            匹配选项：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <input id="_g" type="checkbox" value="g" />
                            全文匹配
                            <input id="_i" type="checkbox" value="i" />
                            忽略大小写
                            <input id="_m" type="checkbox" value="m" />
                            多行匹配
                        </td>
                    </tr>
                    <tr>
                        <td title="Test String" align="right" width="80" class="TD_DataHead_TL_L">
                            输入数据：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <textarea id="_s" rows="5" cols="40" style="width: 96%"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td title="Test Method" align="right" width="80" class="TD_DataHead_TL_L">
                            测试方法：
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <select id="_t">
                                <option value="test">test</option>
                                <option value="exec">exec</option>
                                <option value="match">match</option>
                                <option value="search">search</option>
                                <option value="replace">replace</option>
                                <option value="split">split</option>
                            </select>
                            <input id="_b" type="button" value="测试(R)" accesskey="R" onclick="check()" />
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
            <td class="TD_LINE">
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="460" border="0" cellpadding="3" cellspacing="0" class="TB_DataList_TL">
                    <tr>
                        <td title="Dest Pattern" align="right" width="80" class="TD_DataHead_TL_L">
                            匹配模式：
                        </td>
                        <td id="$r" align="left" class="TD_DataItem_TL_L">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td title="Dest Expression" align="right" width="80" class="TD_DataHead_TL_L">
                            运算过程：
                        </td>
                        <td id="$x" align="left" class="TD_DataItem_TL_L">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td title="Return Type" align="right" width="80" class="TD_DataHead_TL_L">
                            返回类型：
                        </td>
                        <td id="$t" align="left" class="TD_DataItem_TL_L">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td title="Result" align="right" width="80" class="TD_DataHead_TL_L">
                            运行结果：
                        </td>
                        <td id="$m" align="left" class="TD_DataItem_TL_L">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td title="lastIndex" align="right" width="80" class="TD_DataHead_TL_L">
                            匹配索引：
                        </td>
                        <td id="$i" align="left" class="TD_DataItem_TL_L">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
