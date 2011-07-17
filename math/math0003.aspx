<%@ Page Language="C#" MasterPageFile="~/math/math.master" AutoEventWireup="true" CodeFile="math0003.aspx.cs" Inherits="math_math0003" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="center">
                <table width="240" border="0" cellpadding="5" cellspacing="0" id="tb_MiniMath">
                    <tr class="TH_MATH">
                        <td align="center" style="height: 24px;">
                            <input type="text" id="tb_MiniExps" class="BT_MATH" readonly="readonly" />
                        </td>
                    </tr>
                    <tr class="TR_MATH">
                        <td align="center">
                            <table width="220" border="0" cellspacing="0" cellpadding="1">
                                <tr align="center">
                                    <td style="width: 25%;">
                                        &nbsp;
                                    </td>
                                    <td style="width: 25%;">
                                        &nbsp;
                                    </td>
                                    <td style="width: 25%;">
                                        <input name="cb" type="button" class="BT_MATH" id="cb" value="退格" onclick="pDel();" />
                                    </td>
                                    <td style="width: 25%;">
                                        <input name="cc" type="button" class="BT_MATH" id="cc" value="清除" onclick="pClr();" />
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td style="width: 25%;">
                                        <input name="n7" type="button" class="BT_MATH" id="n7" value="7" onclick="pNum('7');" />
                                    </td>
                                    <td style="width: 25%;">
                                        <input name="n8" type="button" class="BT_MATH" id="n8" value="8" onclick="pNum('8');" />
                                    </td>
                                    <td style="width: 25%;">
                                        <input name="n9" type="button" class="BT_MATH" id="n9" value="9" onclick="pNum('9');" />
                                    </td>
                                    <td style="width: 25%;">
                                        <input name="sa" type="button" class="BT_MATH" id="sa" value="+" onclick="pSgn('+');" />
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td style="width: 25%;">
                                        <input name="n4" type="button" class="BT_MATH" id="n4" value="4" onclick="pNum('4');" />
                                    </td>
                                    <td style="width: 25%;">
                                        <input name="n5" type="button" class="BT_MATH" id="n5" value="5" onclick="pNum('5');" />
                                    </td>
                                    <td style="width: 25%;">
                                        <input name="n6" type="button" class="BT_MATH" id="n6" value="6" onclick="pNum('6');" />
                                    </td>
                                    <td style="width: 25%;">
                                        <input name="sm" type="button" class="BT_MATH" id="sm" value="-" onclick="pSgn('-');" />
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td style="width: 25%;">
                                        <input name="n1" type="button" class="BT_MATH" id="n1" value="1" onclick="pNum('1');" />
                                    </td>
                                    <td style="width: 25%;">
                                        <input name="n2" type="button" class="BT_MATH" id="n2" value="2" onclick="pNum('2');" />
                                    </td>
                                    <td style="width: 25%;">
                                        <input name="n3" type="button" class="BT_MATH" id="n3" value="3" onclick="pNum('3');" />
                                    </td>
                                    <td style="width: 25%;">
                                        <input name="sp" type="button" class="BT_MATH" id="sp" value="*" onclick="pSgn('*');" />
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td style="width: 25%;">
                                        <input name="n0" type="button" class="BT_MATH" id="n0" value="0" onclick="pNum('0');" />
                                    </td>
                                    <td style="width: 25%;">
                                        <input name="nd" type="button" class="BT_MATH" id="nd" value="." onclick="pDot('.');" />
                                    </td>
                                    <td style="width: 25%;">
                                        <input name="eq" type="button" class="BT_MATH" id="eq" value="=" onclick="pCal();" />
                                    </td>
                                    <td style="width: 25%;">
                                        <input name="sd" type="button" class="BT_MATH" id="sd" value="/" onclick="pSgn('/');" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
