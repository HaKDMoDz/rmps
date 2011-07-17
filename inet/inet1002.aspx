<%@ Page Language="C#" MasterPageFile="~/inet/inet.master" AutoEventWireup="true" CodeFile="inet1002.aspx.cs" Inherits="inet_inet1002" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="center">
                <table border="0" cellpadding="0" cellspacing="0" width="460" class="TB_DataList_TL">
                    <tr>
                        <th class="TD_DataHead_TL_L">
                            模式
                        </th>
                        <th class="TD_DataHead_TL_L">
                            说明
                        </th>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            y
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            不定长年份后2位数值（不包含前置0）。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            yy
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            定长后2位年份数值。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            yyy
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            不定长年份后4位数值（不包含前置0）。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            yyyy
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            定长后4位年份数值。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            M
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            不定长月份数值。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            MM
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            定长2位月份数值。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            MMM
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            本地化月份简称。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            MMMM
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            本地化月份全称。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            d
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            不定长日期数值。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            dd
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            定长2位日期数值。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            ddd
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            本地化日期简称。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            dddd
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            本地化日期全称。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            H
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            不定长24制时间数值。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            HH
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            定长2位24制时间数值。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            HHH
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            本地化24制时间简称。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            HHHH
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            本地化24制时间全称。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            h
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            不定长12制时间数值。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            hh
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            定长2位12制时间数值。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            hhh
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            本地化12制时间简称。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            hhhh
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            本地化12制时间全称。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            m
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            不定长分钟数值。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            mm
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            定长2位分钟数值。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            s
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            不定长秒钟数值。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            ss
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            定长秒钟数值。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            w
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            1位星期数值。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            ww
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            定长2位星期数值。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            www
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            本地化星期简称。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            wwww
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            本地化星期全称。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            z
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            12时制上下午简称（A、P）。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            zz
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            12时制上下午全称（AM、PM）。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            zzz
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            本地化12时制上下午简称。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            zzzz
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            本地化12时制上下午全称。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            Z
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            不定长时区数值（含+、-）。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            ZZ
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            定长2位时区数值（含+、-）。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            ZZZ
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            本地化时区简称。
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            ZZZZ
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            本地化时间全称。
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
